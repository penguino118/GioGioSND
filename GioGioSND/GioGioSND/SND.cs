using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static GioGioSND.GioGioSND.HD;
using static GioGioSND.GioGioSND.SND.SoundSequence;

namespace GioGioSND.GioGioSND
{
    internal class SND
    {

        public class SoundSequence {
            
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public class SampleEntry
            {
                public byte _sample_index; //based on SmplSCEI
                public byte _volume;
                
                [DisplayName("Sample Index")]
                public byte sample_index
                {
                    get { return _sample_index; }
                    set { _sample_index = value; }
                }
                [DisplayName("Volume")]
                public byte volume
                {
                    get { return _volume; }
                    set { _volume = value; }
                }
                public override string ToString()
                {
                    return String.Format("Sample Index={0}, Volume={1}", this.sample_index ^ 0x80, this.volume ^ 0x80);
                }
            };
            

            public short list_flag_unknown;
            public required SampleEntry sample_1;
            public required SampleEntry sample_2;
            public required SampleEntry sample_3;
            public required SampleEntry sample_4;
            public byte master_volume;
            public byte playback_length;
            public byte length_multiplier;
            public required SampleEntry end_sample; 
            public byte[] unknown = new byte[7];


            [DisplayName("List Flag")]
            public short display_list_flag_unknown
            {
                get { return list_flag_unknown; } 
                set { list_flag_unknown = value;  }
            }
            [DisplayName("Sample Entry 1")]
            public SampleEntry display_sample_1
            {
                get { return sample_1; }
                set { sample_1 = value; }
            }
            [DisplayName("Sample Entry 2")]
            public SampleEntry display_sample_2
            {
                get { return sample_2; }
                set { sample_2 = value; }
            }
            [DisplayName("Sample Entry 3")]
            public SampleEntry display_sample_3
            {
                get { return sample_3; }
                set { sample_3 = value; }
            }
            [DisplayName("Sample Entry 4")]
            public SampleEntry display_sample_4
            {
                get { return sample_4; }
                set { sample_4 = value; }
            }
            
            [DisplayName("Master Volume")]
            public byte display_master_volume
            {
                get { return master_volume; }
                set { master_volume = value; }
            }

            [DisplayName("Playback Length")]
            public byte display_playback_length
            {
                get { return playback_length; }
                set { playback_length = value; }
            }
            [DisplayName("Length Multiplier")]
            public byte display_length_multiplier
            {
                get { return length_multiplier; }
                set { length_multiplier = value; }
            }
            [DisplayName("Transition Sample")]
            public SampleEntry display_end_sample
            {
                get { return end_sample; }
                set { end_sample = value; }
            }
            [DisplayName("Unknown")]
            public byte[] display_unknown
            { 
                get { return unknown; }
                set { unknown = value; }
            }
        }


        static public List<byte[]> GetFilesFromSND(byte[] input_file)
        {
            List<byte[]> file_list = new List<byte[]>();

            using (var stream = new MemoryStream(input_file))
            {
                using (var reader = new BinaryReader(stream))
                {
                    int magic = reader.ReadInt32();
                    if (magic != 0x4F4D4F4D) return file_list;

                    int file_count = reader.ReadInt32();

                    for (int i = 0; i < file_count; i++)
                    {
                        int file_offset = reader.ReadInt32();
                        int file_size = reader.ReadInt32();

                        long original_stream_position = stream.Position;
                        stream.Position = file_offset; // get da files
                        byte[] file_buffer = reader.ReadBytes(file_size); // get bytes
                        file_list.Add(file_buffer);
                        stream.Position = original_stream_position;

                    }
                }
            }

            return file_list;
        }
        static public void WriteOutputData(List<byte[]> file_list, List<VagEntry> vag_list, 
            List<SampleProperties> sample_list, List<SoundSequence> sequence_list, FileStream stream)
        {
            file_list[0] = HD.UpdateHD(file_list[0], vag_list, sample_list);
            file_list[1] = HD.BDFromVagList(vag_list);
            file_list[2] = UpdateSequence(file_list[2], sequence_list);
            //byte[] unk_data = file_list[3];

            List<int> offset_list = new List<int>();
            using (var writer = new BinaryWriter(stream))
            {
                writer.Seek(0x40, SeekOrigin.Begin);
                for (int i = 0; i < file_list.Count; i++)
                {
                    offset_list.Add((int)writer.BaseStream.Position);
                    writer.Write(file_list[i]);
                    PadUntilAligned(writer, 0xFF);
                }

                // build header
                writer.Seek(0x00, SeekOrigin.Begin);
                writer.Write(0x4F4D4F4D); //MOMO
                writer.Write((int)file_list.Count);
                for (int i = 0; i<file_list.Count; i++)
                {
                    writer.Write((int)offset_list[i]);
                    writer.Write((int)file_list[i].Length);
                    //PadUntilAligned(writer, 0x00);
                }
            }
        }

        private static void PadUntilAligned(BinaryWriter writer, byte pad_byte)
        {
            while (writer.BaseStream.Position % 0x40 != 0) writer.Write(pad_byte); // alignment padding
        }

        static public byte[] UpdateSequence(byte[] sequence_data, List<SoundSequence> sequence_list)
        {
            int offset = 0x10;

            foreach (SoundSequence modded_sequence in sequence_list)
            {
                short sequence_offset = BitConverter.ToInt16(sequence_data, offset);
                byte[] sequence_flag_bytes = BitConverter.GetBytes(modded_sequence.list_flag_unknown);
                for (int ii = 0; ii < 2; ii++) // write new list flag
                {
                    sequence_data[(offset+0x2) + ii] = sequence_flag_bytes[ii];
                }
                // sequence properties
                sequence_data[sequence_offset] = modded_sequence.sample_1.sample_index;
                sequence_data[sequence_offset + 0x01] = modded_sequence.sample_1.volume;
                sequence_data[sequence_offset + 0x02] = modded_sequence.sample_2.sample_index;
                sequence_data[sequence_offset + 0x03] = modded_sequence.sample_2.volume;
                sequence_data[sequence_offset + 0x04] = modded_sequence.sample_3.sample_index;
                sequence_data[sequence_offset + 0x05] = modded_sequence.sample_3.volume;
                sequence_data[sequence_offset + 0x06] = modded_sequence.sample_4.sample_index;
                sequence_data[sequence_offset + 0x07] = modded_sequence.sample_4.volume;
                sequence_data[sequence_offset + 0x08] = modded_sequence.master_volume;
                sequence_data[sequence_offset + 0x09] = modded_sequence.playback_length;
                sequence_data[sequence_offset + 0x0A] = modded_sequence.length_multiplier;
                sequence_data[sequence_offset + 0x0B] = modded_sequence.end_sample.sample_index;
                sequence_data[sequence_offset + 0x0C] = modded_sequence.end_sample.volume;
                for (int i = 0; i < 7; i++)
                {
                    sequence_data[(sequence_offset + 0x0D) + i] = modded_sequence.unknown[i];
                }
                offset += 0x4;
            }

            return sequence_data;
        }

        static public List<SoundSequence> GetSequenceList(byte[] sequence_data)
        {
            List<SoundSequence> sequence_list = new List<SoundSequence>();

            using (var reader = new BinaryReader(new MemoryStream(sequence_data)))
            {
                long magic = reader.ReadInt64();

                if (magic == 0x5473657154534452)
                {
                    reader.BaseStream.Position += 0x6;
                    short sequence_count = reader.ReadInt16();

                    for (int i = 0; i < sequence_count; i++) 
                    {
                        short sequence_offset = reader.ReadInt16();
                        short sequence_flag = reader.ReadInt16();
                        
                        long original_stream_position = reader.BaseStream.Position;
                        reader.BaseStream.Position = sequence_offset;


                        short list_flag_unknown = sequence_flag;

                        SampleEntry sample_1 = new SampleEntry
                        {
                            sample_index = reader.ReadByte(),
                            volume = reader.ReadByte()
                        };

                        SampleEntry sample_2 = new SampleEntry
                        {
                            sample_index = reader.ReadByte(),
                            volume = reader.ReadByte()
                        };

                        SampleEntry sample_3 = new SampleEntry
                        {
                            sample_index = reader.ReadByte(),
                            volume = reader.ReadByte()
                        };

                        SampleEntry sample_4 = new SampleEntry
                        {
                            sample_index = reader.ReadByte(),
                            volume = reader.ReadByte()
                        };

                        byte master_volume = reader.ReadByte();
                        byte playback_length = reader.ReadByte();
                        byte length_multiplier = reader.ReadByte();

                        SampleEntry end_sample = new SampleEntry
                        {
                            sample_index = reader.ReadByte(),
                            volume = reader.ReadByte()
                        };

                        byte[] unknown = new byte[7];

                        for (int ii = 0; ii<7; ii++)
                        {
                            byte val = reader.ReadByte();
                            unknown[ii] = val;
                        }

                        sequence_list.Add(new SoundSequence
                        {
                            list_flag_unknown = list_flag_unknown,
                            sample_1 = sample_1,
                            sample_2 = sample_2,
                            sample_3 = sample_3,
                            sample_4 = sample_4,
                            master_volume = master_volume,
                            playback_length = playback_length,
                            length_multiplier = length_multiplier,
                            end_sample = end_sample,
                            unknown = unknown
                        });

                        reader.BaseStream.Position = original_stream_position;
                    }

                }

            }

            return sequence_list;
        }

        public static string GetFileName(string input_file, int file_index, string extension)
        {
            return Path.GetFileNameWithoutExtension(input_file) + "_" + file_index.ToString("D3") + "." + extension;
        }
    }
}
