using GioGioSND.GioGioSND;
using AFSLib;
using NAudio.Wave;
using PS2VagTool;
using PS2VagTool.Vag_Functions;
using VGAudio.Containers.Adx;
using VGAudio.Containers.Wave;
using VGAudio.Formats.Pcm16;
using static GioGioSND.GioGioSND.HD;
using static GioGioSND.GioGioSND.SND;
namespace GioGioSND
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ADXBatchActionPicker.DropDownStyle = ComboBoxStyle.DropDownList;
            ADXBatchActionPicker.SelectedIndex = 0;
        }

        string afs_path = "";
        string input_file = "";
        string output_file = "";
        readonly OpenFileDialog ofd = new OpenFileDialog();
        readonly SaveFileDialog sfd = new SaveFileDialog();
        readonly FolderPicker ffd = new FolderPicker();
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        AFS current_afs = new AFS();

        // SND Stuff
        List<SoundSequence> sequence_list = new List<SoundSequence>();
        List<VagEntry> vag_list = new List<VagEntry>();
        List<byte[]>? file_list = new List<byte[]>();
        List<SampleProperties> sample_list;


        // ADX Stuff
        WaveReader WAV_reader = new WaveReader();
        WaveWriter WAV_writer = new WaveWriter();
        AdxReader ADX_reader = new AdxReader();
        AdxWriter ADX_writer = new AdxWriter
        {
            Configuration = new AdxConfiguration()
            {
                Version = 3
            }
        };
        string ADXTab_current_format = "wav";
        byte[] ADX_current_input;
        string ADX_batch_input = "";
        string ADX_batch_output = "";


        private void StripFileOpen_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select SND File";
            ofd.Filter = "SND Files|*.snd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                input_file = ofd.FileName;
                LoadSND(File.ReadAllBytes(input_file), false);
            }
        }
        private void StripFileAFSOpen_Click(object sender, EventArgs e)
        {
            if (afs_path.Length != 0) ofd.InitialDirectory = Path.GetDirectoryName(afs_path);
            ofd.Title = "Select AFS File";
            ofd.Filter = "AFS Files|*.afs";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string input_afs = ofd.FileName;
                afs_path = input_afs;
                current_afs = new AFS(input_afs);
                OpenAFSPicker(afs_path);
            }
        }

        private void LoadSND(byte[] input_file, bool is_afs)
        {
            SNDTabControl.Enabled = false;
            StripFileSave.Enabled = false;
            StripFileSaveAs.Enabled = false;
            file_list = GetFilesFromSND(input_file);

            if (file_list.Count <= 0 | file_list[0].Length <= 0 | file_list[1].Length <= 0 | file_list[2].Length <= 0)
            {
                MessageBox.Show("The file is empty or contains no samples.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                vag_list = GetVagList(file_list[0], file_list[1]);
                sample_list = GetSampleList(file_list[0]);
                sequence_list = GetSequenceList(file_list[2]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from SDN.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            if (!is_afs) StripFileSave.Enabled = true;
            StripFileSaveAs.Enabled = true;
            SNDTabControl.Enabled = true;
            SetVAGListView();
            SetSampleDataGrid();
            SetSequenceTreeView();
        }

        private void StripFileSave_Click(object sender, EventArgs e)
        {
            if (input_file is null)
            {
                MessageBox.Show("The ouput path for the file is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var stream = File.Open(input_file, FileMode.OpenOrCreate))
            {
                List<byte> output_data = new List<byte>();

                if (file_list is null)
                {
                    MessageBox.Show("The file list is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var writer = new BinaryWriter(stream))
                {
                    SND.WriteOutputData(file_list, vag_list, sample_list, sequence_list, stream);
                }
            }
        }

        private void StripFileSaveAs_Click(object sender, EventArgs e)
        {
            sfd.Title = "Select SND File";
            sfd.Filter = ".SND Files|*.SND";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                output_file = sfd.FileName;

                if (output_file is null)
                {
                    MessageBox.Show("The ouput path for the file is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (file_list is null)
                {
                    MessageBox.Show("The file list is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var stream = File.Open(output_file, FileMode.Create))
                {
                    SND.WriteOutputData(file_list, vag_list, sample_list, sequence_list, stream);
                }

                input_file = output_file;
                if (input_file != "") // to enable save after saving "as" once after afs load
                {
                    StripFileSave.Enabled = true;
                }
            }
        }

        private void ADXOpenButton_Click(object sender, EventArgs e)
        {
            ADXContextMenu.Show(Cursor.Position);
        }

        private void ADXContextOpenFile_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select WAV or ADX File";
            ofd.Filter = "WAV or ADX Files|*.wav;*.adx|WAV Files|*.wav|ADX Files|*.adx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                input_file = ofd.FileName;
                ADXLoopCheckbox.Enabled = false;
                ADXSaveButton.Enabled = false;
                string input_extension = Path.GetExtension(input_file);
                bool is_wav = String.Equals(input_extension, ".wav", StringComparison.OrdinalIgnoreCase);
                bool is_adx = String.Equals(input_extension, ".adx", StringComparison.OrdinalIgnoreCase);

                if (!is_wav & !is_adx)
                {
                    MessageBox.Show("Input is neither wav or adx!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenWAVADX(File.ReadAllBytes(input_file), input_extension);
            }
        }

        private void ADXContextOpenAFS_Click(object sender, EventArgs e)
        {
            if (afs_path.Length != 0) ofd.InitialDirectory = Path.GetDirectoryName(afs_path);
            ofd.Title = "Select AFS File";
            ofd.Filter = "AFS Files|*.afs";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string input_afs = ofd.FileName;
                afs_path = input_afs;
                current_afs = new AFS(input_afs);
                OpenAFSPicker(afs_path);
            }
        }

        private void OpenWAVADX(byte[] input_file, string input_extension)
        {
            try
            {
                ADX_current_input = input_file;
                ADXTab_current_format = input_extension;
                bool is_wav = String.Equals(input_extension, ".wav", StringComparison.OrdinalIgnoreCase);

                if (is_wav)
                {
                    ADXLoopCheckbox.Enabled = true;
                }

                long sample_count = GetSampleCount();
                SetLoopLimits(sample_count);
                string output_extension = GetOutputExtension();
                ADXSaveButton.Text = "Save Output Audio (" + output_extension.ToUpper() + ")";
                ADXSaveButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading " + input_extension + " from file or AFS.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void LoadFileFromAFS(int file_index)
        {
            try
            {
                StreamEntry afs_file = current_afs.Entries[file_index] as StreamEntry;
                if (afs_file != null)
                {
                    Stream filestream = afs_file.GetStream();
                    string input_extension = Path.GetExtension(afs_file.Name);
                    input_file = afs_file.Name;
                    if (FormatTabControl.SelectedTab == null)
                    {
                        MessageBox.Show("No format tab is selected. How did you even make this happen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (FormatTabControl.SelectedTab.Name == "SNDTab") // BAD
                    {
                        LoadSND(ByteArrayFromStream(filestream), true);
                    }
                    else // adx
                    {
                        OpenWAVADX(ByteArrayFromStream(filestream), input_extension);
                    }
                }
                else
                {
                    MessageBox.Show("Error loading from AFS.\n" + "AFS file is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading from AFS.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void OpenAFSPicker(string input_afs)
        {
            List<string> filelist = new List<string>();
            foreach (StreamEntry entry in current_afs.Entries)
            {
                filelist.Add(entry.Name);
            }
            using (var filepicker_form = new AFSFilePicker(this))
            {
                filepicker_form.BuildTree(Path.GetFileName(input_afs), filelist);
                filepicker_form.ShowDialog();
            }
        }

        private long GetSampleCount()
        {
            long sample_count = 0;
            using (Stream stream = new MemoryStream(ADX_current_input))
            {
                if (String.Equals(ADXTab_current_format, ".wav", StringComparison.OrdinalIgnoreCase))
                {
                    var audioFile = new WaveFileReader(stream);
                    int sample_rate = audioFile.WaveFormat.SampleRate;
                    sample_count = audioFile.SampleCount * audioFile.WaveFormat.Channels;
                    if (sample_rate != 12000 | sample_rate != 24000 | sample_rate != 48000)
                    {
                        MessageBox.Show("Your input file's sample rate (" + sample_rate + ") is incompatible with GioGio's Bizarre Adventure. " +
                            "The game only supports ADX playback at 12000hz, 24000hz or 48000hz.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (String.Equals(ADXTab_current_format, ".adx", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] wav_convert = GetWAVFromADX(stream); //this is dumb
                    var audioFile = new WaveFileReader(new MemoryStream(wav_convert));
                    sample_count = audioFile.SampleCount * audioFile.WaveFormat.Channels;
                }
            }
            return sample_count;
        }
        private void GetUILoopSettings(out bool loop_enabled, out int loop_start, out int loop_end)
        {
            loop_enabled = ADXLoopCheckbox.Checked;
            loop_start = (int)ADXLoopStartInput.Value;
            loop_end = (int)ADXLoopEndInput.Value;
        }

        public byte[] GetADXFromWAV(Stream input_stream, bool loop_enabled, int loop_start, int loop_end)
        {
            byte[] ADX_output;

            try
            {
                var audioData = WAV_reader.Read(input_stream);
                audioData.SetLoop(loop_enabled, loop_start, loop_end);
                var format = audioData.GetFormat<Pcm16Format>();

                using (var ms = new MemoryStream())
                {
                    ADX_writer.WriteToStream(audioData, ms);
                    ADX_output = ms.ToArray();
                }
                return ADX_output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting WAV to ADX." + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public byte[] GetWAVFromADX(Stream input_stream)
        {
            byte[] WAV_output;
            var audioData = ADX_reader.ReadFormat(input_stream);
            using (var ms = new MemoryStream())
            {
                WAV_writer.WriteToStream(audioData, ms);
                WAV_output = ms.ToArray();
            }
            return WAV_output;
        }

        public string GetOutputExtension()
        {
            if (String.Equals(ADXTab_current_format, ".wav", StringComparison.OrdinalIgnoreCase)) return ".adx";
            else return ".wav";
        }
        private void ADXSaveButton_Click(object sender, EventArgs e)
        {
            byte[] convert_output;
            bool is_input_wav = String.Equals(ADXTab_current_format, ".wav", StringComparison.OrdinalIgnoreCase);
            using (Stream stream = new MemoryStream(ADX_current_input))
            {
                if (is_input_wav)
                {
                    bool loop_enabled;
                    int loop_start, loop_end;
                    GetUILoopSettings(out loop_enabled, out loop_start, out loop_end);
                    convert_output = GetADXFromWAV(stream, loop_enabled, loop_start, loop_end);
                }
                else convert_output = GetWAVFromADX(stream);
            }

            if (convert_output == null)
            {
                MessageBox.Show("The " + ADXTab_current_format.ToUpper() + " converted output is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string output_extension = GetOutputExtension();
            string initial_output_name = Path.GetFileNameWithoutExtension(input_file) + output_extension;

            sfd.Title = "Save " + output_extension.ToUpper() + " File";
            sfd.Filter = output_extension.ToUpper() + " Files|*" + output_extension;
            sfd.FileName = initial_output_name;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                output_file = sfd.FileName;

                if (output_file is null)
                {
                    MessageBox.Show("The ouput path for the file is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                File.WriteAllBytes(output_file, convert_output);
            }
        }

        private void ADXPlayButton_Click(object sender, EventArgs e)
        {
            if (ADX_current_input == null) return;
            using (Stream stream = new MemoryStream(ADX_current_input))
            {
                if (String.Equals(ADXTab_current_format, ".wav", StringComparison.OrdinalIgnoreCase))
                {
                    var audioFile = new AudioFileReader(input_file);
                    StartWAVPlayback(audioFile);
                }
                else if (String.Equals(ADXTab_current_format, ".adx", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] wav_convert = GetWAVFromADX(stream); // this is dumb
                    var audioFile = new WaveFileReader(new MemoryStream(wav_convert));
                    StartWAVPlayback(audioFile);
                }
            }
        }
        private void ADXPauseButton_Click(object sender, EventArgs e)
        {
            PauseWAVPlayback();
        }

        private void ADXStopButton_Click(object sender, EventArgs e)
        {
            StopWAVPlayback();
        }


        private void SetLoopLimits(long max_sample)
        {
            ADXLoopStartInput.Maximum = max_sample;
            ADXLoopEndInput.Maximum = max_sample;
        }

        private void SetVAGListView()
        {
            if (vag_list.Count <= 0) return;

            VAGListView.Items.Clear();
            int index = 0;
            foreach (VagEntry vag in vag_list)
            {

                string string_index = "Sound " + index.ToString();
                string string_size = vag.vag.Length.ToString("X8");
                string string_samplerate = vag.sample_rate.ToString();
                string string_looped = vag.looped.ToString();
                ListViewItem sound_item = new ListViewItem(string_index);
                sound_item.SubItems.Add(string_size);
                sound_item.SubItems.Add(string_samplerate);
                sound_item.SubItems.Add(string_looped);
                VAGListView.Items.Add(sound_item);

                index++;
            }
        }
        private void SetSampleDataGrid()
        {
            if (sample_list.Count <= 0) return;
            SampleDataGrid.DataSource = sample_list;
            foreach (DataGridViewColumn column in SampleDataGrid.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetSequenceTreeView()
        {
            if (sequence_list.Count <= 0) return;
            for (int i = 0; i < sequence_list.Count; i++)
            {
                TreeNode ListNode = new TreeNode();
                ListNode.Text = "Sequence " + i;
                SequenceTreeView.Nodes.Add(ListNode);
            }
        }

        private void SetSequencePropertyGrid()
        {
            if (sequence_list.Count <= 0) return;
            if (SequenceTreeView.SelectedNode == null) return;
            int sequence_index = SequenceTreeView.SelectedNode.Index;
            SequencePropertyGrid.SelectedObject = sequence_list[sequence_index];
        }

        private void VAGListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = VAGListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    VAGContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void VAGListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var focusedItem = VAGListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    PlayVAG();
                }
            }
        }

        private void ContextVAGSave_Click(object sender, EventArgs e)
        {
            if (VAGListView.FocusedItem == null) return;
            int selected_clip_index = VAGListView.FocusedItem.Index;
            if (selected_clip_index < 0) return;

            VagEntry vag = vag_list.ElementAt(selected_clip_index);
            string initial_output_name = SND.GetFileName(input_file, selected_clip_index, "vag");

            sfd.Title = "Save VAG";
            sfd.Filter = "VAG Files|.vag";
            sfd.FileName = initial_output_name;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string exported_file = sfd.FileName;

                if (exported_file is null)
                {
                    MessageBox.Show("The ouput path for the file is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                File.WriteAllBytes(exported_file, vag.vag);
            }
        }

        private void ContextVAGExportWAV_Click(object sender, EventArgs e)
        {
            int selected_clip_index = VAGListView.FocusedItem.Index;
            if (selected_clip_index < 0) return;

            VagEntry vag = vag_list.ElementAt(selected_clip_index);
            string initial_output_name = SND.GetFileName(input_file, selected_clip_index, "wav");

            sfd.Title = "Save WAV";
            sfd.Filter = "WAV Files|.wav";
            sfd.FileName = initial_output_name;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string exported_file = sfd.FileName;

                if (exported_file is null)
                {
                    MessageBox.Show("The ouput path for the file is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                VAGExportToWav(vag, exported_file);
            }
        }



        private void ContextVAGImportWAV_Click(object sender, EventArgs e)
        {
            int selected_clip_index = VAGListView.FocusedItem.Index;
            if (selected_clip_index < 0) return;

            VagEntry vag = vag_list.ElementAt(selected_clip_index);
            string initial_output_name = SND.GetFileName(input_file, selected_clip_index, "wav");
            ofd.Title = "Select WAV File";
            ofd.Filter = "WAV Files|*.wav";
            sfd.FileName = initial_output_name;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string input_wav = ofd.FileName;
                VAGImportFromWav(selected_clip_index, vag, input_wav);
            }

        }

        private void VAGExportToWav(VagEntry vag, string wav_path)
        {
            byte[] pcmData = SonyVag.Decode(vag.vag);

            IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(pcmData), new WaveFormat(vag.sample_rate, 16, 1));

            try
            {
                WaveFileWriter.CreateWaveFile(wav_path, provider);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VAGImportFromWav(int selected_clip_index, VagEntry vag, string wav_path)
        {
            VagEntry imported_vag = ProgramFunctions.GetEntryFromEncoder(wav_path, vag.looped);

            vag_list.RemoveAt(selected_clip_index);
            vag_list.Insert(selected_clip_index, imported_vag);

            SetVAGListView();
        }

        private void ContextVAGPlay_Click(object sender, EventArgs e)
        {
            PlayVAG();
        }

        private void PlayVAG()
        {
            if (VAGListView.FocusedItem == null) return;
            int selected_clip_index = VAGListView.FocusedItem.Index;
            if (selected_clip_index < 0) return;
            VagEntry vag = vag_list.ElementAt(selected_clip_index);

            byte[] pcmData = SonyVag.Decode(vag.vag);
            IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(pcmData), new WaveFormat(vag.sample_rate, 16, 1));
            StartWAVPlayback(provider);
        }

        private void StartWAVPlayback(IWaveProvider wave_provider)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
            }
            if (outputDevice.PlaybackState == PlaybackState.Playing) StopWAVPlayback();
            if (outputDevice.PlaybackState != PlaybackState.Paused) outputDevice.Init(wave_provider);

            outputDevice.Play();
        }

        private void StopWAVPlayback()
        {
            outputDevice?.Stop();
        }

        private void PauseWAVPlayback()
        {
            outputDevice?.Pause();
        }

        private void VAGStopButton_Click(object sender, EventArgs e)
        {
            StopWAVPlayback();
        }

        private void VAGPlayButton_Click(object sender, EventArgs e)
        {
            PlayVAG();
        }

        private void VAGPause_Click(object sender, EventArgs e)
        {
            PauseWAVPlayback();
        }

        private void SampleDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void SequenceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetSequencePropertyGrid();
        }

        private void ContextVAGBatchExportWAV_Click(object sender, EventArgs e)
        {
            if (ffd.ShowDialog(this.Handle) == true)
            {
                int index = 0;
                foreach (VagEntry vag in vag_list)
                {

                    string output_filename = SND.GetFileName(input_file, index, "wav");
                    string output_path = Path.Join(ffd.ResultPath, output_filename);
                    VAGExportToWav(vag, output_path);
                    index++;
                }
                MessageBox.Show(index + " files were exported successfully.\n" + // this sucks
                    "Please refrain from modifying the filenames if you're gonna use the Batch Import option later. ",
                    "Batch Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ContextVAGBatchImportWAV_Click(object sender, EventArgs e)
        {
            if (ffd.ShowDialog(this.Handle) == true)
            {
                string input_path = ffd.ResultPath;
                int replaced_count = 0;
                foreach (string file_import in Directory.EnumerateFiles(input_path, "*.wav"))
                {
                    for (int i = 0; i < vag_list.Count; i++)
                    {
                        VagEntry vag = vag_list.ElementAt(i);
                        string test_filename = SND.GetFileName(input_file, i, "wav");
                        if (test_filename == Path.GetFileName(file_import))
                        {
                            VAGImportFromWav(i, vag, file_import);
                            replaced_count++;
                        }
                    }
                }
                MessageBox.Show("Replaced " + replaced_count + " file(s).", "Batch Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetVAGListView();
            }
        }

        private void VAGContextBatchExportVAG_Click(object sender, EventArgs e)
        {
            if (ffd.ShowDialog(this.Handle) == true)
            {
                int index = 0;
                foreach (VagEntry vag in vag_list)
                {

                    string output_filename = SND.GetFileName(input_file, index, "vag");
                    string output_path = Path.Join(ffd.ResultPath, output_filename);
                    File.WriteAllBytes(output_path, vag.vag);
                    index++;
                }
                MessageBox.Show(index + " files were exported successfully.\n",
                    "Batch Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ADXLoopCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ADXLoopStartInput.Enabled = ADXLoopCheckbox.Checked;
            ADXLoopEndInput.Enabled = ADXLoopCheckbox.Checked;
        }

        private void ADXBatchOpenFolder_Click(object sender, EventArgs e)
        {
            if (ffd.ShowDialog(this.Handle) == true)
            {
                ADX_batch_input = ffd.ResultPath;
                ADXBatchFileListRefresh();
            }
        }

        private void ADXBatchSaveFolder_Click(object sender, EventArgs e)
        {
            if (ffd.ShowDialog(this.Handle) == true)
            {
                ADX_batch_output = ffd.ResultPath;
                if (ffd.ResultPath == "") ADXBatchConvert.Enabled = false;
                else ADXBatchConvert.Enabled = true;
            }
        }

        private void ADXBatchConvert_Click(object sender, EventArgs e)
        {
            if (ADX_batch_output == "")
            {
                MessageBox.Show("The output path is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string scan_extension = (ADXBatchActionPicker.SelectedIndex == 0) ? "*.wav" : "*.adx";
            string output_extension = (ADXBatchActionPicker.SelectedIndex == 1) ? ".wav" : ".adx";
            foreach (var file in Directory.EnumerateFiles(ADX_batch_input, scan_extension))
            {
                string output_filename = Path.GetFileNameWithoutExtension(file) + output_extension;
                byte[] output_bytes = null;

                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    output_bytes = output_extension == ".adx" ? GetADXFromWAV(stream, false, 0, 0) : GetWAVFromADX(stream);
                }
                if (output_bytes == null)
                {
                    MessageBox.Show("Couldn't convert " + Path.GetFileName(file), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                File.WriteAllBytes(Path.Combine(ADX_batch_output, output_filename), output_bytes);
            }
        }

        private void ADXBatchFileListRefresh()
        {
            ADXBatchFileList.Clear();
            if (ADX_batch_input == "") return;

            string scan_extension = (ADXBatchActionPicker.SelectedIndex == 0) ? "*.wav" : "*.adx";
            foreach (var file in Directory.EnumerateFiles(ADX_batch_input, scan_extension))
            {
                ADXBatchFileList.Items.Add(Path.GetFileName(file));
            }
        }

        private void ADXBatchActionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ADXBatchFileListRefresh();
        }

        private byte[] ByteArrayFromStream(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        
    }
}
