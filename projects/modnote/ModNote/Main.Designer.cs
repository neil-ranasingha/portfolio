namespace ModNote
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotesPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripNotesLabel = new System.Windows.Forms.ToolStripLabel();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.AssessmentsPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAssessments4 = new System.Windows.Forms.Label();
            this.txtAssessments3 = new System.Windows.Forms.RichTextBox();
            this.txtAssessments2 = new System.Windows.Forms.RichTextBox();
            this.lblAssessments3 = new System.Windows.Forms.Label();
            this.CbAssessments1 = new System.Windows.Forms.ComboBox();
            this.lblAssessments2 = new System.Windows.Forms.Label();
            this.lblAssessments1 = new System.Windows.Forms.Label();
            this.ModulesPage = new System.Windows.Forms.TabPage();
            this.txtModules3 = new System.Windows.Forms.RichTextBox();
            this.txtModules2 = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CbModules1 = new System.Windows.Forms.ComboBox();
            this.lblModules4 = new System.Windows.Forms.Label();
            this.lblModules3 = new System.Windows.Forms.Label();
            this.lblModules2 = new System.Windows.Forms.Label();
            this.lblModules1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblModules8 = new System.Windows.Forms.Label();
            this.lblModules5 = new System.Windows.Forms.Label();
            this.lblModules7 = new System.Windows.Forms.Label();
            this.txtModules7 = new System.Windows.Forms.TextBox();
            this.lblModules6 = new System.Windows.Forms.Label();
            this.txtModules4 = new System.Windows.Forms.TextBox();
            this.txtModules5 = new System.Windows.Forms.TextBox();
            this.txtModules6 = new System.Windows.Forms.TextBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.AboutPage = new System.Windows.Forms.TabPage();
            this.lblAbout1 = new System.Windows.Forms.Label();
            this.lblAbout2 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.TabPage();
            this.NotesPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.AssessmentsPage.SuspendLayout();
            this.ModulesPage.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.AboutPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // NotesPage
            // 
            this.NotesPage.BackColor = System.Drawing.Color.White;
            this.NotesPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NotesPage.Controls.Add(this.panel1);
            this.NotesPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.NotesPage.Location = new System.Drawing.Point(4, 22);
            this.NotesPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NotesPage.Name = "NotesPage";
            this.NotesPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NotesPage.Size = new System.Drawing.Size(681, 305);
            this.NotesPage.TabIndex = 7;
            this.NotesPage.Text = "Notes";
            this.NotesPage.Leave += new System.EventHandler(this.NotesPage_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip);
            this.panel1.Controls.Add(this.txtNotes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 299);
            this.panel1.TabIndex = 5;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.editToolStripDropDownButton,
            this.saveToolStripButton,
            this.saveAsToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton,
            this.toolStripNotesLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(675, 31);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(59, 28);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(64, 28);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // editToolStripDropDownButton
            // 
            this.editToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldToolStripMenuItem,
            this.underlineToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.colourToolStripMenuItem,
            this.sizeToolStripMenuItem});
            this.editToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripDropDownButton.Name = "editToolStripDropDownButton";
            this.editToolStripDropDownButton.Size = new System.Drawing.Size(40, 28);
            this.editToolStripDropDownButton.Text = "Edit";
            this.editToolStripDropDownButton.ToolTipText = "Edit";
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.Image = global::ModNote.Properties.Resources.Bold_11689_24;
            this.boldToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.boldToolStripMenuItem.Text = "Bold";
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.boldToolStripMenuItem_Click);
            // 
            // underlineToolStripMenuItem
            // 
            this.underlineToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("underlineToolStripMenuItem.Image")));
            this.underlineToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.underlineToolStripMenuItem.Name = "underlineToolStripMenuItem";
            this.underlineToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.underlineToolStripMenuItem.Text = "Underline";
            this.underlineToolStripMenuItem.Click += new System.EventHandler(this.underlineToolStripMenuItem_Click);
            // 
            // italicToolStripMenuItem
            // 
            this.italicToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("italicToolStripMenuItem.Image")));
            this.italicToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            this.italicToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.italicToolStripMenuItem.Text = "Italic";
            this.italicToolStripMenuItem.Click += new System.EventHandler(this.italicToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Image = global::ModNote.Properties.Resources.Font_6007_24;
            this.fontToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fontToolStripMenuItem_DropDownItemClicked);
            // 
            // colourToolStripMenuItem
            // 
            this.colourToolStripMenuItem.Image = global::ModNote.Properties.Resources.Color_font;
            this.colourToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.colourToolStripMenuItem.Name = "colourToolStripMenuItem";
            this.colourToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.colourToolStripMenuItem.Text = "Colour";
            this.colourToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.colourToolStripMenuItem_DropDownItemClicked);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sizeToolStripMenuItem.Image")));
            this.sizeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sizeToolStripMenuItem_DropDownItemClicked);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(59, 28);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // saveAsToolStripButton
            // 
            this.saveAsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripButton.Image")));
            this.saveAsToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveAsToolStripButton.Name = "saveAsToolStripButton";
            this.saveAsToolStripButton.Size = new System.Drawing.Size(72, 28);
            this.saveAsToolStripButton.Text = "SaveAs";
            this.saveAsToolStripButton.Click += new System.EventHandler(this.saveAsToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // toolStripNotesLabel
            // 
            this.toolStripNotesLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNotesLabel.Name = "toolStripNotesLabel";
            this.toolStripNotesLabel.Size = new System.Drawing.Size(0, 28);
            this.toolStripNotesLabel.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(-3, 25);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(681, 277);
            this.txtNotes.TabIndex = 1;
            this.txtNotes.Text = "";
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // AssessmentsPage
            // 
            this.AssessmentsPage.BackColor = System.Drawing.Color.White;
            this.AssessmentsPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentsPage.Controls.Add(this.label1);
            this.AssessmentsPage.Controls.Add(this.lblAssessments4);
            this.AssessmentsPage.Controls.Add(this.txtAssessments3);
            this.AssessmentsPage.Controls.Add(this.txtAssessments2);
            this.AssessmentsPage.Controls.Add(this.lblAssessments3);
            this.AssessmentsPage.Controls.Add(this.CbAssessments1);
            this.AssessmentsPage.Controls.Add(this.lblAssessments2);
            this.AssessmentsPage.Controls.Add(this.lblAssessments1);
            this.AssessmentsPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.AssessmentsPage.Location = new System.Drawing.Point(4, 22);
            this.AssessmentsPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AssessmentsPage.Name = "AssessmentsPage";
            this.AssessmentsPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AssessmentsPage.Size = new System.Drawing.Size(681, 305);
            this.AssessmentsPage.TabIndex = 6;
            this.AssessmentsPage.Text = "Assessments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 42);
            this.label1.TabIndex = 39;
            this.label1.Text = "Assessment Types:\r\nAssignment - Assignments are projects that require practical w" +
    "ork.\r\nIn-Class Test - This is a test that will be completed in class under super" +
    "vised conditions.";
            // 
            // lblAssessments4
            // 
            this.lblAssessments4.AutoSize = true;
            this.lblAssessments4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssessments4.Location = new System.Drawing.Point(383, 62);
            this.lblAssessments4.Name = "lblAssessments4";
            this.lblAssessments4.Size = new System.Drawing.Size(144, 28);
            this.lblAssessments4.TabIndex = 38;
            this.lblAssessments4.Text = "Key:\r\nw/c - Week Commencing";
            // 
            // txtAssessments3
            // 
            this.txtAssessments3.Location = new System.Drawing.Point(277, 79);
            this.txtAssessments3.Name = "txtAssessments3";
            this.txtAssessments3.ReadOnly = true;
            this.txtAssessments3.Size = new System.Drawing.Size(100, 113);
            this.txtAssessments3.TabIndex = 37;
            this.txtAssessments3.Text = "";
            // 
            // txtAssessments2
            // 
            this.txtAssessments2.Location = new System.Drawing.Point(8, 79);
            this.txtAssessments2.Name = "txtAssessments2";
            this.txtAssessments2.ReadOnly = true;
            this.txtAssessments2.Size = new System.Drawing.Size(263, 113);
            this.txtAssessments2.TabIndex = 34;
            this.txtAssessments2.Text = "";
            // 
            // lblAssessments3
            // 
            this.lblAssessments3.AutoSize = true;
            this.lblAssessments3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssessments3.Location = new System.Drawing.Point(279, 62);
            this.lblAssessments3.Name = "lblAssessments3";
            this.lblAssessments3.Size = new System.Drawing.Size(93, 14);
            this.lblAssessments3.TabIndex = 36;
            this.lblAssessments3.Text = "Due Date Check";
            // 
            // CbAssessments1
            // 
            this.CbAssessments1.FormattingEnabled = true;
            this.CbAssessments1.Location = new System.Drawing.Point(8, 28);
            this.CbAssessments1.Name = "CbAssessments1";
            this.CbAssessments1.Size = new System.Drawing.Size(121, 21);
            this.CbAssessments1.TabIndex = 33;
            this.CbAssessments1.SelectedIndexChanged += new System.EventHandler(this.CbAssessments1_SelectedIndexChanged);
            // 
            // lblAssessments2
            // 
            this.lblAssessments2.AutoSize = true;
            this.lblAssessments2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssessments2.Location = new System.Drawing.Point(7, 62);
            this.lblAssessments2.Name = "lblAssessments2";
            this.lblAssessments2.Size = new System.Drawing.Size(86, 14);
            this.lblAssessments2.TabIndex = 31;
            this.lblAssessments2.Text = "Assessments";
            // 
            // lblAssessments1
            // 
            this.lblAssessments1.AutoSize = true;
            this.lblAssessments1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssessments1.Location = new System.Drawing.Point(7, 11);
            this.lblAssessments1.Name = "lblAssessments1";
            this.lblAssessments1.Size = new System.Drawing.Size(58, 14);
            this.lblAssessments1.TabIndex = 30;
            this.lblAssessments1.Text = "ModuleID";
            // 
            // ModulesPage
            // 
            this.ModulesPage.BackColor = System.Drawing.Color.White;
            this.ModulesPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModulesPage.Controls.Add(this.txtModules3);
            this.ModulesPage.Controls.Add(this.txtModules2);
            this.ModulesPage.Controls.Add(this.toolStrip2);
            this.ModulesPage.Controls.Add(this.CbModules1);
            this.ModulesPage.Controls.Add(this.lblModules4);
            this.ModulesPage.Controls.Add(this.lblModules3);
            this.ModulesPage.Controls.Add(this.lblModules2);
            this.ModulesPage.Controls.Add(this.lblModules1);
            this.ModulesPage.Controls.Add(this.panel2);
            this.ModulesPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.ModulesPage.Location = new System.Drawing.Point(4, 22);
            this.ModulesPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModulesPage.Name = "ModulesPage";
            this.ModulesPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModulesPage.Size = new System.Drawing.Size(681, 305);
            this.ModulesPage.TabIndex = 3;
            this.ModulesPage.Text = "Modules";
            // 
            // txtModules3
            // 
            this.txtModules3.Location = new System.Drawing.Point(8, 165);
            this.txtModules3.Name = "txtModules3";
            this.txtModules3.ReadOnly = true;
            this.txtModules3.Size = new System.Drawing.Size(345, 131);
            this.txtModules3.TabIndex = 28;
            this.txtModules3.Text = "";
            // 
            // txtModules2
            // 
            this.txtModules2.Location = new System.Drawing.Point(8, 113);
            this.txtModules2.Name = "txtModules2";
            this.txtModules2.ReadOnly = true;
            this.txtModules2.Size = new System.Drawing.Size(201, 20);
            this.txtModules2.TabIndex = 24;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripButton,
            this.EditToolStripButton,
            this.DeleteToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(675, 25);
            this.toolStrip2.TabIndex = 39;
            this.toolStrip2.Text = "toolStrip";
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripButton.Image")));
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(33, 22);
            this.AddToolStripButton.Text = "Add";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // EditToolStripButton
            // 
            this.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripButton.Image")));
            this.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStripButton.Name = "EditToolStripButton";
            this.EditToolStripButton.Size = new System.Drawing.Size(31, 22);
            this.EditToolStripButton.Text = "Edit";
            this.EditToolStripButton.Click += new System.EventHandler(this.EditToolStripButton_Click);
            // 
            // DeleteToolStripButton
            // 
            this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
            this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripButton.Name = "DeleteToolStripButton";
            this.DeleteToolStripButton.Size = new System.Drawing.Size(44, 22);
            this.DeleteToolStripButton.Text = "Delete";
            this.DeleteToolStripButton.Click += new System.EventHandler(this.DeleteToolStripButton_Click);
            // 
            // CbModules1
            // 
            this.CbModules1.FormattingEnabled = true;
            this.CbModules1.Location = new System.Drawing.Point(8, 57);
            this.CbModules1.Name = "CbModules1";
            this.CbModules1.Size = new System.Drawing.Size(121, 21);
            this.CbModules1.TabIndex = 29;
            this.CbModules1.SelectedIndexChanged += new System.EventHandler(this.CbModules1_SelectedIndexChanged);
            // 
            // lblModules4
            // 
            this.lblModules4.AutoSize = true;
            this.lblModules4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules4.Location = new System.Drawing.Point(356, 73);
            this.lblModules4.Name = "lblModules4";
            this.lblModules4.Size = new System.Drawing.Size(117, 14);
            this.lblModules4.TabIndex = 26;
            this.lblModules4.Text = "Learning Objectives";
            // 
            // lblModules3
            // 
            this.lblModules3.AutoSize = true;
            this.lblModules3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules3.Location = new System.Drawing.Point(7, 148);
            this.lblModules3.Name = "lblModules3";
            this.lblModules3.Size = new System.Drawing.Size(58, 14);
            this.lblModules3.TabIndex = 25;
            this.lblModules3.Text = "Synopsis";
            // 
            // lblModules2
            // 
            this.lblModules2.AutoSize = true;
            this.lblModules2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules2.Location = new System.Drawing.Point(7, 96);
            this.lblModules2.Name = "lblModules2";
            this.lblModules2.Size = new System.Drawing.Size(75, 14);
            this.lblModules2.TabIndex = 23;
            this.lblModules2.Text = "Module Title";
            // 
            // lblModules1
            // 
            this.lblModules1.AutoSize = true;
            this.lblModules1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules1.Location = new System.Drawing.Point(7, 40);
            this.lblModules1.Name = "lblModules1";
            this.lblModules1.Size = new System.Drawing.Size(58, 14);
            this.lblModules1.TabIndex = 22;
            this.lblModules1.Text = "ModuleID";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblModules8);
            this.panel2.Controls.Add(this.lblModules5);
            this.panel2.Controls.Add(this.lblModules7);
            this.panel2.Controls.Add(this.txtModules7);
            this.panel2.Controls.Add(this.lblModules6);
            this.panel2.Controls.Add(this.txtModules4);
            this.panel2.Controls.Add(this.txtModules5);
            this.panel2.Controls.Add(this.txtModules6);
            this.panel2.Location = new System.Drawing.Point(359, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 206);
            this.panel2.TabIndex = 27;
            // 
            // lblModules8
            // 
            this.lblModules8.AutoSize = true;
            this.lblModules8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules8.Location = new System.Drawing.Point(8, 149);
            this.lblModules8.Name = "lblModules8";
            this.lblModules8.Size = new System.Drawing.Size(28, 14);
            this.lblModules8.TabIndex = 17;
            this.lblModules8.Text = "LO4";
            // 
            // lblModules5
            // 
            this.lblModules5.AutoSize = true;
            this.lblModules5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules5.Location = new System.Drawing.Point(8, 14);
            this.lblModules5.Name = "lblModules5";
            this.lblModules5.Size = new System.Drawing.Size(28, 14);
            this.lblModules5.TabIndex = 11;
            this.lblModules5.Text = "LO1";
            // 
            // lblModules7
            // 
            this.lblModules7.AutoSize = true;
            this.lblModules7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules7.Location = new System.Drawing.Point(8, 104);
            this.lblModules7.Name = "lblModules7";
            this.lblModules7.Size = new System.Drawing.Size(28, 14);
            this.lblModules7.TabIndex = 15;
            this.lblModules7.Text = "LO3";
            // 
            // txtModules7
            // 
            this.txtModules7.Location = new System.Drawing.Point(41, 149);
            this.txtModules7.Multiline = true;
            this.txtModules7.Name = "txtModules7";
            this.txtModules7.ReadOnly = true;
            this.txtModules7.Size = new System.Drawing.Size(241, 39);
            this.txtModules7.TabIndex = 16;
            // 
            // lblModules6
            // 
            this.lblModules6.AutoSize = true;
            this.lblModules6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules6.Location = new System.Drawing.Point(8, 59);
            this.lblModules6.Name = "lblModules6";
            this.lblModules6.Size = new System.Drawing.Size(28, 14);
            this.lblModules6.TabIndex = 13;
            this.lblModules6.Text = "LO2";
            // 
            // txtModules4
            // 
            this.txtModules4.Location = new System.Drawing.Point(41, 14);
            this.txtModules4.Multiline = true;
            this.txtModules4.Name = "txtModules4";
            this.txtModules4.ReadOnly = true;
            this.txtModules4.Size = new System.Drawing.Size(241, 39);
            this.txtModules4.TabIndex = 10;
            // 
            // txtModules5
            // 
            this.txtModules5.Location = new System.Drawing.Point(41, 59);
            this.txtModules5.Multiline = true;
            this.txtModules5.Name = "txtModules5";
            this.txtModules5.ReadOnly = true;
            this.txtModules5.Size = new System.Drawing.Size(241, 39);
            this.txtModules5.TabIndex = 12;
            // 
            // txtModules6
            // 
            this.txtModules6.Location = new System.Drawing.Point(41, 104);
            this.txtModules6.Multiline = true;
            this.txtModules6.Name = "txtModules6";
            this.txtModules6.ReadOnly = true;
            this.txtModules6.Size = new System.Drawing.Size(241, 39);
            this.txtModules6.TabIndex = 14;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.AboutPage);
            this.TabControl.Controls.Add(this.ModulesPage);
            this.TabControl.Controls.Add(this.AssessmentsPage);
            this.TabControl.Controls.Add(this.NotesPage);
            this.TabControl.Controls.Add(this.Exit);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.ShowToolTips = true;
            this.TabControl.Size = new System.Drawing.Size(689, 331);
            this.TabControl.TabIndex = 2;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // AboutPage
            // 
            this.AboutPage.BackColor = System.Drawing.Color.White;
            this.AboutPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AboutPage.Controls.Add(this.lblAbout1);
            this.AboutPage.Controls.Add(this.lblAbout2);
            this.AboutPage.Location = new System.Drawing.Point(4, 22);
            this.AboutPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AboutPage.Name = "AboutPage";
            this.AboutPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AboutPage.Size = new System.Drawing.Size(681, 305);
            this.AboutPage.TabIndex = 8;
            this.AboutPage.Text = "About";
            // 
            // lblAbout1
            // 
            this.lblAbout1.AutoSize = true;
            this.lblAbout1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAbout1.Font = new System.Drawing.Font("Freestyle Script", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout1.Location = new System.Drawing.Point(267, 3);
            this.lblAbout1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbout1.Name = "lblAbout1";
            this.lblAbout1.Size = new System.Drawing.Size(107, 45);
            this.lblAbout1.TabIndex = 5;
            this.lblAbout1.Text = "ModNote";
            this.lblAbout1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbout2
            // 
            this.lblAbout2.AutoSize = true;
            this.lblAbout2.Location = new System.Drawing.Point(15, 47);
            this.lblAbout2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbout2.Name = "lblAbout2";
            this.lblAbout2.Size = new System.Drawing.Size(609, 169);
            this.lblAbout2.TabIndex = 1;
            this.lblAbout2.Text = resources.GetString("lblAbout2.Text");
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(4, 22);
            this.Exit.Name = "Exit";
            this.Exit.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Exit.Size = new System.Drawing.Size(681, 305);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 332);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModNote";
            this.Load += new System.EventHandler(this.Main_Load);
            this.NotesPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.AssessmentsPage.ResumeLayout(false);
            this.AssessmentsPage.PerformLayout();
            this.ModulesPage.ResumeLayout(false);
            this.ModulesPage.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.AboutPage.ResumeLayout(false);
            this.AboutPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabPage NotesPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton editToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem underlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton saveAsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripNotesLabel;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.TabPage AssessmentsPage;
        private System.Windows.Forms.RichTextBox txtAssessments3;
        private System.Windows.Forms.RichTextBox txtAssessments2;
        private System.Windows.Forms.Label lblAssessments3;
        private System.Windows.Forms.ComboBox CbAssessments1;
        private System.Windows.Forms.Label lblAssessments2;
        private System.Windows.Forms.Label lblAssessments1;
        private System.Windows.Forms.TabPage ModulesPage;
        private System.Windows.Forms.RichTextBox txtModules3;
        private System.Windows.Forms.TextBox txtModules2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.ToolStripButton DeleteToolStripButton;
        private System.Windows.Forms.ComboBox CbModules1;
        private System.Windows.Forms.Label lblModules4;
        private System.Windows.Forms.Label lblModules3;
        private System.Windows.Forms.Label lblModules2;
        private System.Windows.Forms.Label lblModules1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblModules8;
        private System.Windows.Forms.Label lblModules5;
        private System.Windows.Forms.Label lblModules7;
        private System.Windows.Forms.TextBox txtModules7;
        private System.Windows.Forms.Label lblModules6;
        private System.Windows.Forms.TextBox txtModules4;
        private System.Windows.Forms.TextBox txtModules5;
        private System.Windows.Forms.TextBox txtModules6;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage AboutPage;
        private System.Windows.Forms.Label lblAbout1;
        private System.Windows.Forms.Label lblAbout2;
        private System.Windows.Forms.TabPage Exit;
        private System.Windows.Forms.Label lblAssessments4;
        private System.Windows.Forms.ToolStripButton EditToolStripButton;
        private System.Windows.Forms.Label label1;
    }
}

