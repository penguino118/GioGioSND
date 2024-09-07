using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GioGioSND.GioGioSND
{
    internal class HD
    {
        public class SampleProperties
        {
            public short sample_index;
            public byte sample_group;
            public byte sample_priority;
            public byte sample_volume;

            [DisplayName("VAG Index")]
            public string display_sample_index {
                get { return sample_index.ToString(); }
                set { if (short.TryParse(value, out _)) sample_index = short.Parse(value);
                    else MessageBox.Show("Error parsing sample set index value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } }

            [DisplayName("Group")]
            public string display_group
            {
                get { return sample_group.ToString(); }
                set
                {
                    if (byte.TryParse(value, out _)) sample_group = byte.Parse(value);
                    else MessageBox.Show("Error parsing sample set group value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            [DisplayName("Priority")]
            public string display_priority
            {
                get { return sample_priority.ToString(); }
                set
                {
                    if (byte.TryParse(value, out _)) sample_priority = byte.Parse(value);
                    else MessageBox.Show("Error parsing sample set priority value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            [DisplayName("Volume")]
            public string display_volume
            {
                get { return sample_volume.ToString(); }
                set
                {
                    if (byte.TryParse(value, out _)) sample_volume = byte.Parse(value);
                    else MessageBox.Show("Error parsing sample set volume value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public struct VagEntry
        {
            public ushort sample_rate;
            public bool looped;
            public byte[] vag;
        }

        public static byte[] UpdateHD(byte[] hd_data, List<VagEntry> vag_list, List<SampleProperties> sample_properties)
        {
            int depth = 5;
            int offset = 0x0;

            for (int i = 0; i < depth; i++)
            {
                try
                {
                    string test = System.Text.Encoding.Default.GetString(hd_data, offset, 8);
                    switch (test)
                    {
                        case "IECSigaV":
                            { int skip_offset = offset + BitConverter.ToInt32(hd_data, offset + 0x8);
                            offset += 0x10 + ((vag_list.Count) * 4);
                            int vag_index = 0;
                            foreach (VagEntry vag in vag_list)
                            {
                                int vag_offset = GetBDOffset(vag_list, vag_index);
                                byte[] vag_offset_bytes = BitConverter.GetBytes(vag_offset);
                                byte[] vag_samplerate_bytes = BitConverter.GetBytes(vag.sample_rate);

                                for (int ii = 0; ii < 4; ii++) // write new offset
                                {
                                    hd_data[offset + ii] = vag_offset_bytes[ii];
                                }
                                offset += 0x4;
                                for (int ii = 0; ii < 2; ii++) // write new sample rate
                                {
                                    hd_data[offset + ii] = vag_samplerate_bytes[ii];
                                }
                                offset += 0x4;
                                vag_index++;
                            }
                            offset = skip_offset; }
                            break;
                        case "IECSlpmS":
                            { int skip_offset = offset + BitConverter.ToInt32(hd_data, offset + 0x8);
                            offset += 0x10 + ((sample_properties.Count + 1) * 4);
                            foreach (SampleProperties property in sample_properties)
                            {
                                byte[] index_bytes = BitConverter.GetBytes(property.sample_index);
                                for (int ii = 0; ii < 2; ii++) // write new index
                                {
                                    hd_data[offset + ii] = index_bytes[ii];
                                }
                                hd_data[offset + 0x0E] = property.sample_group;
                                hd_data[offset + 0x0F] = property.sample_priority;
                                hd_data[offset + 0x10] = property.sample_volume;
                                offset += 0x2A;
                            }
                            offset = skip_offset; }
                            break;
                        default:
                            int chunk_size = BitConverter.ToInt32(hd_data, offset+0x8);
                            offset += chunk_size;
                            break;
                    }
                }
                catch (Exception e)
                {

                }
            }

            return hd_data;
        }

        public static byte[] BDFromVagList(List<VagEntry> vag_list)
        {
            List<byte> output = new List<byte>();

            foreach (VagEntry vag in vag_list)
            {
                for (int i = 0; i < vag.vag.Length; i++)
                {
                    output.Add(vag.vag[i]);
                }
            }

            return output.ToArray();
        }

        public static int GetBDOffset(List<VagEntry> vag_list, int sound_index)
        {
            if (sound_index == vag_list.Count) return -1;

            int offset = 0x00;

            for (int i = 0; i < sound_index; i++)
            {
                offset += vag_list[i].vag.Length;
            }

            return offset;
        }

        public static bool CheckLoop(byte[] vag)
        {
            bool looped = false;

            for (int i = 0; i < (vag.Length / 0x10);  i++)
            {
                if (vag[(i*0x10+1)] == 2)
                {
                    looped = true;
                    break;
                }
            }

            return looped;
        }

        static public List<VagEntry> GetVagList(byte[] hd_data, byte[] bd_data)
        {
            List<VagEntry> vag_list = new List<VagEntry>();

            using (var reader = new BinaryReader(new MemoryStream(hd_data)))
            {
                reader.BaseStream.Position = 0x58;
                int chunk_size = reader.ReadInt32();
                int sample_count = reader.ReadInt32() + 1;
                reader.BaseStream.Position += (sample_count)*0x4;

                for (int i = 0; i < sample_count; i++)
                {
                    uint offset = reader.ReadUInt32();
                    ushort sample_rate = reader.ReadUInt16();
                    reader.BaseStream.Position += 0x2;
                    uint next_offset = reader.ReadUInt32();
                    reader.BaseStream.Position -= 0x4;
                    
                    uint vag_size;
                    if (next_offset == 0xFFFFFFFF || reader.BaseStream.Position >= (0x50 + chunk_size))  // last entry on list
                    { 
                        vag_size = (uint)bd_data.Length - offset;
                    } 
                    else vag_size = next_offset - offset;

                    byte[] vag_data = new byte[vag_size];
                    Array.Copy(bd_data, offset, vag_data, 0, vag_size);
                    
                    vag_list.Add(new VagEntry { 
                        sample_rate = sample_rate,
                        looped = CheckLoop(vag_data),
                        vag = vag_data
                    });

                }

            }

            return vag_list;
        }

        static public List<SampleProperties> GetSampleList(byte[] hd_data)
        {
            List<SampleProperties> vag_list = new List<SampleProperties>();

            using (var reader = new BinaryReader(new MemoryStream(hd_data)))
            {
                
                while (reader.BaseStream.Position <= hd_data.Length-8) // todo: DANGEROUS!!
                {
                    long test_magic = reader.ReadInt64();
                    if (test_magic != 0x536D706C53434549)
                    {
                        reader.BaseStream.Position += 0x8;
                    }
                    else
                    {
                        reader.BaseStream.Position += 0x4;
                        int sample_count = reader.ReadInt32();
                        reader.BaseStream.Position += (1+sample_count)*0x4;
                        for (int i=0; i<sample_count; i++)
                        {
                            short vag_index = reader.ReadInt16();
                            reader.BaseStream.Position += 0xC;
                            byte vag_group = reader.ReadByte();
                            byte vag_priority = reader.ReadByte();
                            byte vag_volume = reader.ReadByte();
                            reader.BaseStream.Position += 0x19;
                            vag_list.Add(new SampleProperties
                            {
                                sample_index = vag_index,
                                sample_group = vag_group,
                                sample_priority = vag_priority,
                                sample_volume = vag_volume
                            });
                        }
                    }
                }
            }

            return vag_list;
        }
    }
}
