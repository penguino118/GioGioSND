namespace GioGioSND
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            StripFile = new ToolStripMenuItem();
            StripFileOpen = new ToolStripMenuItem();
            StripFileAFSOpen = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            StripFileSave = new ToolStripMenuItem();
            StripFileSaveAs = new ToolStripMenuItem();
            StripExtract = new ToolStripMenuItem();
            StripExtractInner = new ToolStripMenuItem();
            StripExtractHD = new ToolStripMenuItem();
            StripExtractBD = new ToolStripMenuItem();
            StripExtractSequence = new ToolStripMenuItem();
            StripExtractFile4Unknown = new ToolStripMenuItem();
            StripExtractSound = new ToolStripMenuItem();
            asWAVToolStripMenuItem = new ToolStripMenuItem();
            batchExportVAGToolStripMenuItem = new ToolStripMenuItem();
            VAGListView = new ListView();
            IndexColumn = new ColumnHeader();
            LenghtColumn = new ColumnHeader();
            SampleRateColumn = new ColumnHeader();
            LoopedColumn = new ColumnHeader();
            VAGContextMenu = new ContextMenuStrip(components);
            ContextVAGPlay = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ContextVAGExportWAV = new ToolStripMenuItem();
            ContextVAGImportWAV = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            ContextVAGSave = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ContextVAGBatch = new ToolStripMenuItem();
            ContextVAGBatchExportWAV = new ToolStripMenuItem();
            ContextVAGBatchImportWAV = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            VAGContextBatchExportVAG = new ToolStripMenuItem();
            VAGPlayButton = new Button();
            VAGStopButton = new Button();
            VAGPause = new Button();
            SNDTabControl = new TabControl();
            tabPage1 = new TabPage();
            VAGListSplitContainer = new SplitContainer();
            tabPage2 = new TabPage();
            SampleDataGrid = new DataGridView();
            tabPage3 = new TabPage();
            splitContainer1 = new SplitContainer();
            SequenceTreeView = new TreeView();
            SequencePropertyGrid = new PropertyGrid();
            FormatTabControl = new TabControl();
            SNDTab = new TabPage();
            SNDStripContainer = new ToolStripContainer();
            ADXTab = new TabPage();
            tabControl1 = new TabControl();
            ADXSingleTab = new TabPage();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            ADXOpenButton = new Button();
            ADXPlayButton = new Button();
            ADXPauseButton = new Button();
            ADXStopButton = new Button();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            ADXLoopCheckbox = new CheckBox();
            ADXLoopEndInput = new NumericUpDown();
            ADXLoopStartInput = new NumericUpDown();
            ADXSaveButton = new Button();
            ADXBatchTab = new TabPage();
            ADXBatchSplitContainer = new SplitContainer();
            ADXBatchInputSplitContainer = new SplitContainer();
            ADXBatchOpenFolder = new Button();
            ADXBatchActionPicker = new ComboBox();
            label3 = new Label();
            ADXBatchFileList = new ListView();
            ADXBatchSaveFolder = new Button();
            ADXBatchConvert = new Button();
            ADXContextMenu = new ContextMenuStrip(components);
            ADXContextOpenFile = new ToolStripMenuItem();
            ADXContextOpenAFS = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            VAGContextMenu.SuspendLayout();
            SNDTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VAGListSplitContainer).BeginInit();
            VAGListSplitContainer.Panel1.SuspendLayout();
            VAGListSplitContainer.Panel2.SuspendLayout();
            VAGListSplitContainer.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SampleDataGrid).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            FormatTabControl.SuspendLayout();
            SNDTab.SuspendLayout();
            SNDStripContainer.ContentPanel.SuspendLayout();
            SNDStripContainer.TopToolStripPanel.SuspendLayout();
            SNDStripContainer.SuspendLayout();
            ADXTab.SuspendLayout();
            tabControl1.SuspendLayout();
            ADXSingleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ADXLoopEndInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ADXLoopStartInput).BeginInit();
            ADXBatchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ADXBatchSplitContainer).BeginInit();
            ADXBatchSplitContainer.Panel1.SuspendLayout();
            ADXBatchSplitContainer.Panel2.SuspendLayout();
            ADXBatchSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ADXBatchInputSplitContainer).BeginInit();
            ADXBatchInputSplitContainer.Panel1.SuspendLayout();
            ADXBatchInputSplitContainer.Panel2.SuspendLayout();
            ADXBatchInputSplitContainer.SuspendLayout();
            ADXContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { StripFile, StripExtract });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(370, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // StripFile
            // 
            StripFile.DropDownItems.AddRange(new ToolStripItem[] { StripFileOpen, StripFileAFSOpen, toolStripSeparator5, StripFileSave, StripFileSaveAs });
            StripFile.Image = GioGioSND.Properties.Resources.StripFile;
            StripFile.Name = "StripFile";
            StripFile.Size = new Size(53, 20);
            StripFile.Text = "File";
            // 
            // StripFileOpen
            // 
            StripFileOpen.Image = GioGioSND.Properties.Resources.StripFileOpen;
            StripFileOpen.Name = "StripFileOpen";
            StripFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            StripFileOpen.Size = new Size(180, 22);
            StripFileOpen.Text = "Open";
            StripFileOpen.Click += StripFileOpen_Click;
            // 
            // StripFileAFSOpen
            // 
            StripFileAFSOpen.Name = "StripFileAFSOpen";
            StripFileAFSOpen.Size = new Size(180, 22);
            StripFileAFSOpen.Text = "Open From AFS";
            StripFileAFSOpen.Click += StripFileAFSOpen_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(177, 6);
            // 
            // StripFileSave
            // 
            StripFileSave.Enabled = false;
            StripFileSave.Image = GioGioSND.Properties.Resources.StripFileSave;
            StripFileSave.Name = "StripFileSave";
            StripFileSave.ShortcutKeys = Keys.Control | Keys.S;
            StripFileSave.Size = new Size(180, 22);
            StripFileSave.Text = "Save";
            StripFileSave.Click += StripFileSave_Click;
            // 
            // StripFileSaveAs
            // 
            StripFileSaveAs.Enabled = false;
            StripFileSaveAs.Name = "StripFileSaveAs";
            StripFileSaveAs.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            StripFileSaveAs.Size = new Size(180, 22);
            StripFileSaveAs.Text = "Save as";
            StripFileSaveAs.Click += StripFileSaveAs_Click;
            // 
            // StripExtract
            // 
            StripExtract.DropDownItems.AddRange(new ToolStripItem[] { StripExtractInner, StripExtractSound });
            StripExtract.Enabled = false;
            StripExtract.Image = GioGioSND.Properties.Resources.StripExtract;
            StripExtract.Name = "StripExtract";
            StripExtract.Size = new Size(71, 20);
            StripExtract.Text = "Extract";
            // 
            // StripExtractInner
            // 
            StripExtractInner.DropDownItems.AddRange(new ToolStripItem[] { StripExtractHD, StripExtractBD, StripExtractSequence, StripExtractFile4Unknown });
            StripExtractInner.Name = "StripExtractInner";
            StripExtractInner.Size = new Size(137, 22);
            StripExtractInner.Text = "Inner Files";
            // 
            // StripExtractHD
            // 
            StripExtractHD.Name = "StripExtractHD";
            StripExtractHD.Size = new Size(175, 22);
            StripExtractHD.Text = "Audio Header (,hd)";
            StripExtractHD.Click += StripExtractHD_Click;
            // 
            // StripExtractBD
            // 
            StripExtractBD.Name = "StripExtractBD";
            StripExtractBD.Size = new Size(175, 22);
            StripExtractBD.Text = "Audio Body (.bd)";
            StripExtractBD.Click += StripExtractBD_Click;
            // 
            // StripExtractSequence
            // 
            StripExtractSequence.Name = "StripExtractSequence";
            StripExtractSequence.Size = new Size(175, 22);
            StripExtractSequence.Text = "Sequence Data";
            StripExtractSequence.Click += StripExtractSequence_Click;
            // 
            // StripExtractFile4Unknown
            // 
            StripExtractFile4Unknown.Name = "StripExtractFile4Unknown";
            StripExtractFile4Unknown.Size = new Size(175, 22);
            StripExtractFile4Unknown.Text = "Unknown";
            StripExtractFile4Unknown.Click += StripExtractFile4Unknown_Click;
            // 
            // StripExtractSound
            // 
            StripExtractSound.DropDownItems.AddRange(new ToolStripItem[] { asWAVToolStripMenuItem, batchExportVAGToolStripMenuItem });
            StripExtractSound.Name = "StripExtractSound";
            StripExtractSound.Size = new Size(180, 22);
            StripExtractSound.Text = "Sound Clips";
            // 
            // asWAVToolStripMenuItem
            // 
            asWAVToolStripMenuItem.Name = "asWAVToolStripMenuItem";
            asWAVToolStripMenuItem.Size = new Size(180, 22);
            asWAVToolStripMenuItem.Text = "Batch Export (WAV)";
            asWAVToolStripMenuItem.Click += ContextVAGBatchExportWAV_Click;
            // 
            // batchExportVAGToolStripMenuItem
            // 
            batchExportVAGToolStripMenuItem.Name = "batchExportVAGToolStripMenuItem";
            batchExportVAGToolStripMenuItem.Size = new Size(177, 22);
            batchExportVAGToolStripMenuItem.Text = "Batch Export (VAG)";
            batchExportVAGToolStripMenuItem.Click += VAGContextBatchExportVAG_Click;
            // 
            // VAGListView
            // 
            VAGListView.Columns.AddRange(new ColumnHeader[] { IndexColumn, LenghtColumn, SampleRateColumn, LoopedColumn });
            VAGListView.Dock = DockStyle.Fill;
            VAGListView.FullRowSelect = true;
            VAGListView.GridLines = true;
            VAGListView.Location = new Point(0, 0);
            VAGListView.Name = "VAGListView";
            VAGListView.Size = new Size(356, 226);
            VAGListView.TabIndex = 3;
            VAGListView.UseCompatibleStateImageBehavior = false;
            VAGListView.View = View.Details;
            VAGListView.MouseClick += VAGListView_MouseClick;
            VAGListView.MouseDoubleClick += VAGListView_MouseDoubleClick;
            // 
            // IndexColumn
            // 
            IndexColumn.Text = "Index";
            // 
            // LenghtColumn
            // 
            LenghtColumn.Text = "Length";
            LenghtColumn.Width = 90;
            // 
            // SampleRateColumn
            // 
            SampleRateColumn.Text = "Sample Rate";
            SampleRateColumn.Width = 90;
            // 
            // LoopedColumn
            // 
            LoopedColumn.Text = "Looped";
            LoopedColumn.Width = 90;
            // 
            // VAGContextMenu
            // 
            VAGContextMenu.Items.AddRange(new ToolStripItem[] { ContextVAGPlay, toolStripSeparator1, ContextVAGExportWAV, ContextVAGImportWAV, toolStripSeparator3, ContextVAGSave, toolStripSeparator2, ContextVAGBatch });
            VAGContextMenu.Name = "contextMenuStrip1";
            VAGContextMenu.Size = new Size(139, 132);
            // 
            // ContextVAGPlay
            // 
            ContextVAGPlay.Image = GioGioSND.Properties.Resources.PlaybackPlay;
            ContextVAGPlay.Name = "ContextVAGPlay";
            ContextVAGPlay.Size = new Size(180, 22);
            ContextVAGPlay.Text = "Play";
            ContextVAGPlay.Click += ContextVAGPlay_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(135, 6);
            // 
            // ContextVAGExportWAV
            // 
            ContextVAGExportWAV.Image = GioGioSND.Properties.Resources.StripFileSave;
            ContextVAGExportWAV.Name = "ContextVAGExportWAV";
            ContextVAGExportWAV.Size = new Size(138, 22);
            ContextVAGExportWAV.Text = "Export WAV";
            ContextVAGExportWAV.Click += ContextVAGExportWAV_Click;
            // 
            // ContextVAGImportWAV
            // 
            ContextVAGImportWAV.Image = GioGioSND.Properties.Resources.FileImport;
            ContextVAGImportWAV.Name = "ContextVAGImportWAV";
            ContextVAGImportWAV.Size = new Size(138, 22);
            ContextVAGImportWAV.Text = "Import WAV";
            ContextVAGImportWAV.Click += ContextVAGImportWAV_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(135, 6);
            // 
            // ContextVAGSave
            // 
            ContextVAGSave.Name = "ContextVAGSave";
            ContextVAGSave.Size = new Size(138, 22);
            ContextVAGSave.Text = "Export VAG";
            ContextVAGSave.Click += ContextVAGSave_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(135, 6);
            // 
            // ContextVAGBatch
            // 
            ContextVAGBatch.DropDownItems.AddRange(new ToolStripItem[] { ContextVAGBatchExportWAV, ContextVAGBatchImportWAV, toolStripSeparator4, VAGContextBatchExportVAG });
            ContextVAGBatch.Image = GioGioSND.Properties.Resources.RootICO;
            ContextVAGBatch.Name = "ContextVAGBatch";
            ContextVAGBatch.Size = new Size(180, 22);
            ContextVAGBatch.Text = "Batch";
            // 
            // ContextVAGBatchExportWAV
            // 
            ContextVAGBatchExportWAV.Image = GioGioSND.Properties.Resources.StripBatchExport;
            ContextVAGBatchExportWAV.Name = "ContextVAGBatchExportWAV";
            ContextVAGBatchExportWAV.Size = new Size(180, 22);
            ContextVAGBatchExportWAV.Text = "Batch Export (WAV)";
            ContextVAGBatchExportWAV.Click += ContextVAGBatchExportWAV_Click;
            // 
            // ContextVAGBatchImportWAV
            // 
            ContextVAGBatchImportWAV.Image = GioGioSND.Properties.Resources.StripBatchImport;
            ContextVAGBatchImportWAV.Name = "ContextVAGBatchImportWAV";
            ContextVAGBatchImportWAV.Size = new Size(180, 22);
            ContextVAGBatchImportWAV.Text = "Batch Import (WAV)";
            ContextVAGBatchImportWAV.Click += ContextVAGBatchImportWAV_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(176, 6);
            // 
            // VAGContextBatchExportVAG
            // 
            VAGContextBatchExportVAG.Name = "VAGContextBatchExportVAG";
            VAGContextBatchExportVAG.Size = new Size(180, 22);
            VAGContextBatchExportVAG.Text = "Batch Export (VAG)";
            VAGContextBatchExportVAG.Click += VAGContextBatchExportVAG_Click;
            // 
            // VAGPlayButton
            // 
            VAGPlayButton.Image = (Image)resources.GetObject("VAGPlayButton.Image");
            VAGPlayButton.Location = new Point(3, 3);
            VAGPlayButton.Name = "VAGPlayButton";
            VAGPlayButton.Size = new Size(60, 23);
            VAGPlayButton.TabIndex = 4;
            VAGPlayButton.Text = "Play";
            VAGPlayButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            VAGPlayButton.UseVisualStyleBackColor = true;
            VAGPlayButton.Click += VAGPlayButton_Click;
            // 
            // VAGStopButton
            // 
            VAGStopButton.Image = (Image)resources.GetObject("VAGStopButton.Image");
            VAGStopButton.Location = new Point(140, 3);
            VAGStopButton.Name = "VAGStopButton";
            VAGStopButton.Size = new Size(61, 23);
            VAGStopButton.TabIndex = 5;
            VAGStopButton.Text = "Stop";
            VAGStopButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            VAGStopButton.UseVisualStyleBackColor = true;
            VAGStopButton.Click += VAGStopButton_Click;
            // 
            // VAGPause
            // 
            VAGPause.Image = (Image)resources.GetObject("VAGPause.Image");
            VAGPause.Location = new Point(69, 3);
            VAGPause.Name = "VAGPause";
            VAGPause.Size = new Size(65, 23);
            VAGPause.TabIndex = 6;
            VAGPause.Text = "Pause";
            VAGPause.TextImageRelation = TextImageRelation.ImageBeforeText;
            VAGPause.UseVisualStyleBackColor = true;
            VAGPause.Click += VAGPause_Click;
            // 
            // SNDTabControl
            // 
            SNDTabControl.Controls.Add(tabPage1);
            SNDTabControl.Controls.Add(tabPage2);
            SNDTabControl.Controls.Add(tabPage3);
            SNDTabControl.Dock = DockStyle.Fill;
            SNDTabControl.Enabled = false;
            SNDTabControl.Location = new Point(0, 0);
            SNDTabControl.Name = "SNDTabControl";
            SNDTabControl.SelectedIndex = 0;
            SNDTabControl.Size = new Size(370, 292);
            SNDTabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(VAGListSplitContainer);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(362, 264);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "VAG List";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // VAGListSplitContainer
            // 
            VAGListSplitContainer.Dock = DockStyle.Fill;
            VAGListSplitContainer.FixedPanel = FixedPanel.Panel1;
            VAGListSplitContainer.IsSplitterFixed = true;
            VAGListSplitContainer.Location = new Point(3, 3);
            VAGListSplitContainer.Name = "VAGListSplitContainer";
            VAGListSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // VAGListSplitContainer.Panel1
            // 
            VAGListSplitContainer.Panel1.Controls.Add(VAGPlayButton);
            VAGListSplitContainer.Panel1.Controls.Add(VAGStopButton);
            VAGListSplitContainer.Panel1.Controls.Add(VAGPause);
            // 
            // VAGListSplitContainer.Panel2
            // 
            VAGListSplitContainer.Panel2.Controls.Add(VAGListView);
            VAGListSplitContainer.Size = new Size(356, 258);
            VAGListSplitContainer.SplitterDistance = 28;
            VAGListSplitContainer.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(SampleDataGrid);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(362, 261);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Sample List";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SampleDataGrid
            // 
            SampleDataGrid.AllowUserToAddRows = false;
            SampleDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            SampleDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            SampleDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SampleDataGrid.Dock = DockStyle.Fill;
            SampleDataGrid.Location = new Point(3, 3);
            SampleDataGrid.Name = "SampleDataGrid";
            SampleDataGrid.Size = new Size(356, 255);
            SampleDataGrid.TabIndex = 0;
            SampleDataGrid.CellEndEdit += SampleDataGrid_CellEndEdit;
            SampleDataGrid.RowPostPaint += SampleDataGrid_RowPostPaint;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(splitContainer1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(362, 261);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Sequence Data";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(SequenceTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(SequencePropertyGrid);
            splitContainer1.Size = new Size(362, 261);
            splitContainer1.SplitterDistance = 110;
            splitContainer1.TabIndex = 1;
            // 
            // SequenceTreeView
            // 
            SequenceTreeView.Dock = DockStyle.Fill;
            SequenceTreeView.Location = new Point(0, 0);
            SequenceTreeView.Name = "SequenceTreeView";
            SequenceTreeView.Size = new Size(362, 110);
            SequenceTreeView.TabIndex = 0;
            SequenceTreeView.AfterSelect += SequenceTreeView_AfterSelect;
            // 
            // SequencePropertyGrid
            // 
            SequencePropertyGrid.Dock = DockStyle.Fill;
            SequencePropertyGrid.HelpVisible = false;
            SequencePropertyGrid.Location = new Point(0, 0);
            SequencePropertyGrid.Name = "SequencePropertyGrid";
            SequencePropertyGrid.PropertySort = PropertySort.NoSort;
            SequencePropertyGrid.Size = new Size(362, 147);
            SequencePropertyGrid.TabIndex = 0;
            SequencePropertyGrid.PropertyValueChanged += SequencePropertyGrid_PropertyValueChanged;
            // 
            // FormatTabControl
            // 
            FormatTabControl.Controls.Add(SNDTab);
            FormatTabControl.Controls.Add(ADXTab);
            FormatTabControl.Dock = DockStyle.Fill;
            FormatTabControl.Location = new Point(0, 0);
            FormatTabControl.Name = "FormatTabControl";
            FormatTabControl.SelectedIndex = 0;
            FormatTabControl.Size = new Size(384, 350);
            FormatTabControl.TabIndex = 8;
            // 
            // SNDTab
            // 
            SNDTab.Controls.Add(SNDStripContainer);
            SNDTab.Location = new Point(4, 24);
            SNDTab.Name = "SNDTab";
            SNDTab.Padding = new Padding(3);
            SNDTab.Size = new Size(376, 322);
            SNDTab.TabIndex = 0;
            SNDTab.Text = "SND";
            SNDTab.UseVisualStyleBackColor = true;
            // 
            // SNDStripContainer
            // 
            SNDStripContainer.BottomToolStripPanelVisible = false;
            // 
            // SNDStripContainer.ContentPanel
            // 
            SNDStripContainer.ContentPanel.Controls.Add(SNDTabControl);
            SNDStripContainer.ContentPanel.Size = new Size(370, 292);
            SNDStripContainer.Dock = DockStyle.Fill;
            SNDStripContainer.LeftToolStripPanelVisible = false;
            SNDStripContainer.Location = new Point(3, 3);
            SNDStripContainer.Name = "SNDStripContainer";
            SNDStripContainer.RightToolStripPanelVisible = false;
            SNDStripContainer.Size = new Size(370, 316);
            SNDStripContainer.TabIndex = 9;
            SNDStripContainer.Text = "toolStripContainer2";
            // 
            // SNDStripContainer.TopToolStripPanel
            // 
            SNDStripContainer.TopToolStripPanel.Controls.Add(menuStrip1);
            // 
            // ADXTab
            // 
            ADXTab.Controls.Add(tabControl1);
            ADXTab.Location = new Point(4, 24);
            ADXTab.Name = "ADXTab";
            ADXTab.Padding = new Padding(3);
            ADXTab.Size = new Size(376, 322);
            ADXTab.TabIndex = 1;
            ADXTab.Text = "ADX";
            ADXTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(ADXSingleTab);
            tabControl1.Controls.Add(ADXBatchTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(370, 316);
            tabControl1.TabIndex = 16;
            // 
            // ADXSingleTab
            // 
            ADXSingleTab.Controls.Add(splitContainer2);
            ADXSingleTab.Location = new Point(4, 24);
            ADXSingleTab.Name = "ADXSingleTab";
            ADXSingleTab.Padding = new Padding(3);
            ADXSingleTab.Size = new Size(362, 288);
            ADXSingleTab.TabIndex = 0;
            ADXSingleTab.Text = "Single File";
            ADXSingleTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox1);
            splitContainer2.Panel1MinSize = 77;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox3);
            splitContainer2.Size = new Size(356, 282);
            splitContainer2.SplitterDistance = 77;
            splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ADXOpenButton);
            groupBox1.Controls.Add(ADXPlayButton);
            groupBox1.Controls.Add(ADXPauseButton);
            groupBox1.Controls.Add(ADXStopButton);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(356, 77);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Audio";
            // 
            // ADXOpenButton
            // 
            ADXOpenButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ADXOpenButton.Image = GioGioSND.Properties.Resources.ADXWAVOpen;
            ADXOpenButton.ImageAlign = ContentAlignment.MiddleRight;
            ADXOpenButton.Location = new Point(6, 22);
            ADXOpenButton.MaximumSize = new Size(135, 40);
            ADXOpenButton.MinimumSize = new Size(128, 38);
            ADXOpenButton.Name = "ADXOpenButton";
            ADXOpenButton.Size = new Size(135, 40);
            ADXOpenButton.TabIndex = 0;
            ADXOpenButton.Text = "Open Input Audio\r\n(WAV / ADX)";
            ADXOpenButton.TextAlign = ContentAlignment.MiddleLeft;
            ADXOpenButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXOpenButton.UseVisualStyleBackColor = true;
            ADXOpenButton.Click += ADXOpenButton_Click;
            // 
            // ADXPlayButton
            // 
            ADXPlayButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ADXPlayButton.Image = (Image)resources.GetObject("ADXPlayButton.Image");
            ADXPlayButton.Location = new Point(152, 28);
            ADXPlayButton.MaximumSize = new Size(60, 27);
            ADXPlayButton.MinimumSize = new Size(60, 27);
            ADXPlayButton.Name = "ADXPlayButton";
            ADXPlayButton.Size = new Size(60, 27);
            ADXPlayButton.TabIndex = 7;
            ADXPlayButton.Text = "Play";
            ADXPlayButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXPlayButton.UseVisualStyleBackColor = true;
            ADXPlayButton.Click += ADXPlayButton_Click;
            // 
            // ADXPauseButton
            // 
            ADXPauseButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ADXPauseButton.Image = (Image)resources.GetObject("ADXPauseButton.Image");
            ADXPauseButton.Location = new Point(218, 28);
            ADXPauseButton.MaximumSize = new Size(65, 27);
            ADXPauseButton.MinimumSize = new Size(65, 27);
            ADXPauseButton.Name = "ADXPauseButton";
            ADXPauseButton.Size = new Size(65, 27);
            ADXPauseButton.TabIndex = 9;
            ADXPauseButton.Text = "Pause";
            ADXPauseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXPauseButton.UseVisualStyleBackColor = true;
            ADXPauseButton.Click += ADXPauseButton_Click;
            // 
            // ADXStopButton
            // 
            ADXStopButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ADXStopButton.Image = (Image)resources.GetObject("ADXStopButton.Image");
            ADXStopButton.Location = new Point(289, 28);
            ADXStopButton.MaximumSize = new Size(61, 27);
            ADXStopButton.MinimumSize = new Size(61, 27);
            ADXStopButton.Name = "ADXStopButton";
            ADXStopButton.Size = new Size(61, 27);
            ADXStopButton.TabIndex = 8;
            ADXStopButton.Text = "Stop";
            ADXStopButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXStopButton.UseVisualStyleBackColor = true;
            ADXStopButton.Click += ADXStopButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(ADXSaveButton);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(356, 201);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Output Audio";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(ADXLoopCheckbox);
            groupBox2.Controls.Add(ADXLoopEndInput);
            groupBox2.Controls.Add(ADXLoopStartInput);
            groupBox2.Location = new Point(6, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(344, 118);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Loop Settings";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(6, 80);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 15;
            label2.Text = "Loop End Sample";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(6, 51);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 14;
            label1.Text = "Loop Start Sample";
            // 
            // ADXLoopCheckbox
            // 
            ADXLoopCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ADXLoopCheckbox.AutoSize = true;
            ADXLoopCheckbox.Enabled = false;
            ADXLoopCheckbox.Location = new Point(6, 22);
            ADXLoopCheckbox.Name = "ADXLoopCheckbox";
            ADXLoopCheckbox.Size = new Size(108, 19);
            ADXLoopCheckbox.TabIndex = 11;
            ADXLoopCheckbox.Text = "Enable Looping";
            ADXLoopCheckbox.UseVisualStyleBackColor = true;
            ADXLoopCheckbox.CheckedChanged += ADXLoopCheckbox_CheckedChanged;
            // 
            // ADXLoopEndInput
            // 
            ADXLoopEndInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ADXLoopEndInput.Enabled = false;
            ADXLoopEndInput.Location = new Point(218, 78);
            ADXLoopEndInput.Name = "ADXLoopEndInput";
            ADXLoopEndInput.Size = new Size(120, 23);
            ADXLoopEndInput.TabIndex = 13;
            // 
            // ADXLoopStartInput
            // 
            ADXLoopStartInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ADXLoopStartInput.Enabled = false;
            ADXLoopStartInput.Location = new Point(218, 49);
            ADXLoopStartInput.Name = "ADXLoopStartInput";
            ADXLoopStartInput.Size = new Size(120, 23);
            ADXLoopStartInput.TabIndex = 12;
            // 
            // ADXSaveButton
            // 
            ADXSaveButton.Anchor = AnchorStyles.Bottom;
            ADXSaveButton.Enabled = false;
            ADXSaveButton.Image = GioGioSND.Properties.Resources.ADXWAVSave;
            ADXSaveButton.ImageAlign = ContentAlignment.MiddleRight;
            ADXSaveButton.Location = new Point(91, 156);
            ADXSaveButton.MaximumSize = new Size(174, 30);
            ADXSaveButton.MinimumSize = new Size(174, 30);
            ADXSaveButton.Name = "ADXSaveButton";
            ADXSaveButton.Size = new Size(174, 30);
            ADXSaveButton.TabIndex = 1;
            ADXSaveButton.Text = "Save Output Audio";
            ADXSaveButton.TextAlign = ContentAlignment.MiddleLeft;
            ADXSaveButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXSaveButton.UseVisualStyleBackColor = true;
            ADXSaveButton.Click += ADXSaveButton_Click;
            // 
            // ADXBatchTab
            // 
            ADXBatchTab.Controls.Add(ADXBatchSplitContainer);
            ADXBatchTab.Location = new Point(4, 24);
            ADXBatchTab.Name = "ADXBatchTab";
            ADXBatchTab.Padding = new Padding(3);
            ADXBatchTab.Size = new Size(362, 288);
            ADXBatchTab.TabIndex = 1;
            ADXBatchTab.Text = "Batch";
            ADXBatchTab.UseVisualStyleBackColor = true;
            // 
            // ADXBatchSplitContainer
            // 
            ADXBatchSplitContainer.Dock = DockStyle.Fill;
            ADXBatchSplitContainer.FixedPanel = FixedPanel.Panel2;
            ADXBatchSplitContainer.IsSplitterFixed = true;
            ADXBatchSplitContainer.Location = new Point(3, 3);
            ADXBatchSplitContainer.Name = "ADXBatchSplitContainer";
            ADXBatchSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // ADXBatchSplitContainer.Panel1
            // 
            ADXBatchSplitContainer.Panel1.Controls.Add(ADXBatchInputSplitContainer);
            ADXBatchSplitContainer.Panel1MinSize = 246;
            // 
            // ADXBatchSplitContainer.Panel2
            // 
            ADXBatchSplitContainer.Panel2.Controls.Add(ADXBatchSaveFolder);
            ADXBatchSplitContainer.Panel2.Controls.Add(ADXBatchConvert);
            ADXBatchSplitContainer.Size = new Size(356, 282);
            ADXBatchSplitContainer.SplitterDistance = 247;
            ADXBatchSplitContainer.TabIndex = 6;
            // 
            // ADXBatchInputSplitContainer
            // 
            ADXBatchInputSplitContainer.Dock = DockStyle.Fill;
            ADXBatchInputSplitContainer.FixedPanel = FixedPanel.Panel1;
            ADXBatchInputSplitContainer.IsSplitterFixed = true;
            ADXBatchInputSplitContainer.Location = new Point(0, 0);
            ADXBatchInputSplitContainer.Name = "ADXBatchInputSplitContainer";
            ADXBatchInputSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // ADXBatchInputSplitContainer.Panel1
            // 
            ADXBatchInputSplitContainer.Panel1.Controls.Add(ADXBatchOpenFolder);
            ADXBatchInputSplitContainer.Panel1.Controls.Add(ADXBatchActionPicker);
            ADXBatchInputSplitContainer.Panel1.Controls.Add(label3);
            ADXBatchInputSplitContainer.Panel1MinSize = 35;
            // 
            // ADXBatchInputSplitContainer.Panel2
            // 
            ADXBatchInputSplitContainer.Panel2.Controls.Add(ADXBatchFileList);
            ADXBatchInputSplitContainer.Size = new Size(356, 247);
            ADXBatchInputSplitContainer.SplitterDistance = 35;
            ADXBatchInputSplitContainer.TabIndex = 0;
            // 
            // ADXBatchOpenFolder
            // 
            ADXBatchOpenFolder.Image = GioGioSND.Properties.Resources.RootICO;
            ADXBatchOpenFolder.ImageAlign = ContentAlignment.MiddleRight;
            ADXBatchOpenFolder.Location = new Point(5, 6);
            ADXBatchOpenFolder.Name = "ADXBatchOpenFolder";
            ADXBatchOpenFolder.Size = new Size(127, 23);
            ADXBatchOpenFolder.TabIndex = 2;
            ADXBatchOpenFolder.Text = "Open Input Folder";
            ADXBatchOpenFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXBatchOpenFolder.UseVisualStyleBackColor = true;
            ADXBatchOpenFolder.Click += ADXBatchOpenFolder_Click;
            // 
            // ADXBatchActionPicker
            // 
            ADXBatchActionPicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ADXBatchActionPicker.FormattingEnabled = true;
            ADXBatchActionPicker.Items.AddRange(new object[] { "WAV to ADX", "ADX to WAV" });
            ADXBatchActionPicker.Location = new Point(232, 6);
            ADXBatchActionPicker.Name = "ADXBatchActionPicker";
            ADXBatchActionPicker.Size = new Size(121, 23);
            ADXBatchActionPicker.TabIndex = 1;
            ADXBatchActionPicker.SelectedIndexChanged += ADXBatchActionPicker_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(151, 10);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 3;
            label3.Text = "Batch Action:";
            // 
            // ADXBatchFileList
            // 
            ADXBatchFileList.Dock = DockStyle.Fill;
            ADXBatchFileList.Location = new Point(0, 0);
            ADXBatchFileList.Name = "ADXBatchFileList";
            ADXBatchFileList.Size = new Size(356, 208);
            ADXBatchFileList.TabIndex = 0;
            ADXBatchFileList.UseCompatibleStateImageBehavior = false;
            ADXBatchFileList.View = View.List;
            // 
            // ADXBatchSaveFolder
            // 
            ADXBatchSaveFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ADXBatchSaveFolder.Image = GioGioSND.Properties.Resources.StripExtract;
            ADXBatchSaveFolder.ImageAlign = ContentAlignment.MiddleRight;
            ADXBatchSaveFolder.Location = new Point(3, 2);
            ADXBatchSaveFolder.Name = "ADXBatchSaveFolder";
            ADXBatchSaveFolder.Size = new Size(142, 27);
            ADXBatchSaveFolder.TabIndex = 5;
            ADXBatchSaveFolder.Text = "Select Output Folder";
            ADXBatchSaveFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXBatchSaveFolder.UseVisualStyleBackColor = true;
            ADXBatchSaveFolder.Click += ADXBatchSaveFolder_Click;
            // 
            // ADXBatchConvert
            // 
            ADXBatchConvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ADXBatchConvert.Enabled = false;
            ADXBatchConvert.Image = GioGioSND.Properties.Resources.ADXWAV;
            ADXBatchConvert.Location = new Point(250, 2);
            ADXBatchConvert.Name = "ADXBatchConvert";
            ADXBatchConvert.Size = new Size(103, 27);
            ADXBatchConvert.TabIndex = 4;
            ADXBatchConvert.Text = "Convert All";
            ADXBatchConvert.TextImageRelation = TextImageRelation.ImageBeforeText;
            ADXBatchConvert.UseVisualStyleBackColor = true;
            ADXBatchConvert.Click += ADXBatchConvert_Click;
            // 
            // ADXContextMenu
            // 
            ADXContextMenu.Items.AddRange(new ToolStripItem[] { ADXContextOpenFile, ADXContextOpenAFS });
            ADXContextMenu.Name = "ADXContextMenu";
            ADXContextMenu.Size = new Size(126, 48);
            // 
            // ADXContextOpenFile
            // 
            ADXContextOpenFile.Name = "ADXContextOpenFile";
            ADXContextOpenFile.Size = new Size(125, 22);
            ADXContextOpenFile.Text = "From File";
            ADXContextOpenFile.Click += ADXContextOpenFile_Click;
            // 
            // ADXContextOpenAFS
            // 
            ADXContextOpenAFS.Name = "ADXContextOpenAFS";
            ADXContextOpenAFS.Size = new Size(125, 22);
            ADXContextOpenAFS.Text = "From AFS";
            ADXContextOpenAFS.Click += ADXContextOpenAFS_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 350);
            Controls.Add(FormatTabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(400, 386);
            Name = "Form1";
            Text = "Moody Blues";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            VAGContextMenu.ResumeLayout(false);
            SNDTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            VAGListSplitContainer.Panel1.ResumeLayout(false);
            VAGListSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)VAGListSplitContainer).EndInit();
            VAGListSplitContainer.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SampleDataGrid).EndInit();
            tabPage3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            FormatTabControl.ResumeLayout(false);
            SNDTab.ResumeLayout(false);
            SNDStripContainer.ContentPanel.ResumeLayout(false);
            SNDStripContainer.TopToolStripPanel.ResumeLayout(false);
            SNDStripContainer.TopToolStripPanel.PerformLayout();
            SNDStripContainer.ResumeLayout(false);
            SNDStripContainer.PerformLayout();
            ADXTab.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ADXSingleTab.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ADXLoopEndInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)ADXLoopStartInput).EndInit();
            ADXBatchTab.ResumeLayout(false);
            ADXBatchSplitContainer.Panel1.ResumeLayout(false);
            ADXBatchSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ADXBatchSplitContainer).EndInit();
            ADXBatchSplitContainer.ResumeLayout(false);
            ADXBatchInputSplitContainer.Panel1.ResumeLayout(false);
            ADXBatchInputSplitContainer.Panel1.PerformLayout();
            ADXBatchInputSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ADXBatchInputSplitContainer).EndInit();
            ADXBatchInputSplitContainer.ResumeLayout(false);
            ADXContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem StripFile;
        private ToolStripMenuItem StripFileOpen;
        private ToolStripMenuItem StripFileSave;
        private ToolStripMenuItem StripFileSaveAs;
        private ListView VAGListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ContextMenuStrip VAGContextMenu;
        private ToolStripMenuItem ContextVAGPlay;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ContextVAGExportWAV;
        private ToolStripMenuItem ContextVAGImportWAV;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ContextVAGSave;
        private Button VAGPlayButton;
        private Button VAGStopButton;
        private Button VAGPause;
        private TabControl SNDTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabControl FormatTabControl;
        private TabPage SNDTab;
        private TabPage ADXTab;
        private DataGridView SampleDataGrid;
        private SplitContainer VAGListSplitContainer;
        private PropertyGrid SequencePropertyGrid;
        private SplitContainer splitContainer1;
        private TreeView SequenceTreeView;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader IndexColumn;
        private ColumnHeader LenghtColumn;
        private ColumnHeader SampleRateColumn;
        private ColumnHeader LoopedColumn;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ContextVAGBatch;
        private ToolStripMenuItem ContextVAGBatchExportWAV;
        private ToolStripMenuItem ContextVAGBatchImportWAV;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem VAGContextBatchExportVAG;
        private ToolStripContainer SNDStripContainer;
        private Button ADXSaveButton;
        private Button ADXOpenButton;
        private Button ADXPlayButton;
        private Button ADXStopButton;
        private Button ADXPauseButton;
        private CheckBox ADXLoopCheckbox;
        private NumericUpDown ADXLoopEndInput;
        private NumericUpDown ADXLoopStartInput;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private GroupBox groupBox3;
        private TabControl tabControl1;
        private TabPage ADXSingleTab;
        private TabPage ADXBatchTab;
        private SplitContainer splitContainer2;
        private ComboBox ADXBatchActionPicker;
        private ListView ADXBatchFileList;
        private Button ADXBatchOpenFolder;
        private Label label3;
        private Button ADXBatchSaveFolder;
        private Button ADXBatchConvert;
        private SplitContainer ADXBatchSplitContainer;
        private SplitContainer ADXBatchInputSplitContainer;
        private ContextMenuStrip ADXContextMenu;
        private ToolStripMenuItem ADXContextOpenFile;
        private ToolStripMenuItem ADXContextOpenAFS;
        private ToolStripMenuItem StripFileAFSOpen;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem StripExtract;
        private ToolStripMenuItem StripExtractInner;
        private ToolStripMenuItem StripExtractHD;
        private ToolStripMenuItem StripExtractBD;
        private ToolStripMenuItem StripExtractSequence;
        private ToolStripMenuItem StripExtractFile4Unknown;
        private ToolStripMenuItem StripExtractSound;
        private ToolStripMenuItem asWAVToolStripMenuItem;
        private ToolStripMenuItem batchExportVAGToolStripMenuItem;
    }
}
