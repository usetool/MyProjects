namespace 乐智知识库
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddLove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMyLove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenWorkFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.更改编码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gB2312ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSCIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCoding = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(253, 372);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddLove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiAddLove
            // 
            this.tsmiAddLove.Name = "tsmiAddLove";
            this.tsmiAddLove.Size = new System.Drawing.Size(100, 22);
            this.tsmiAddLove.Text = "收藏";
            this.tsmiAddLove.Click += new System.EventHandler(this.tsmiAddLove_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.tsmiHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMyLove,
            this.tsmiOpenWorkFile,
            this.tsmiSetting,
            this.更改编码ToolStripMenuItem,
            this.tsmiAbout});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.菜单ToolStripMenuItem.Text = "菜单(&M)";
            // 
            // tsmiMyLove
            // 
            this.tsmiMyLove.Name = "tsmiMyLove";
            this.tsmiMyLove.Size = new System.Drawing.Size(181, 22);
            this.tsmiMyLove.Text = "收藏(Ctrl+Shift+L)";
            this.tsmiMyLove.Click += new System.EventHandler(this.tsmiMyLove_Click);
            // 
            // tsmiOpenWorkFile
            // 
            this.tsmiOpenWorkFile.Name = "tsmiOpenWorkFile";
            this.tsmiOpenWorkFile.Size = new System.Drawing.Size(181, 22);
            this.tsmiOpenWorkFile.Text = "浏览(Ctrl+Shift+O)";
            this.tsmiOpenWorkFile.Click += new System.EventHandler(this.tsmiOpenWorkFile_Click);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(181, 22);
            this.tsmiSetting.Text = "设置(Ctrl+Shift+C)";
            this.tsmiSetting.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // 更改编码ToolStripMenuItem
            // 
            this.更改编码ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uTF8ToolStripMenuItem,
            this.gBKToolStripMenuItem,
            this.gB2312ToolStripMenuItem,
            this.uTF16ToolStripMenuItem,
            this.unicodeToolStripMenuItem,
            this.aSCIIToolStripMenuItem});
            this.更改编码ToolStripMenuItem.Name = "更改编码ToolStripMenuItem";
            this.更改编码ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.更改编码ToolStripMenuItem.Text = "更改编码";
            // 
            // uTF8ToolStripMenuItem
            // 
            this.uTF8ToolStripMenuItem.Name = "uTF8ToolStripMenuItem";
            this.uTF8ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.uTF8ToolStripMenuItem.Text = "UTF-8";
            this.uTF8ToolStripMenuItem.Click += new System.EventHandler(this.uTF8ToolStripMenuItem_Click);
            // 
            // gBKToolStripMenuItem
            // 
            this.gBKToolStripMenuItem.Name = "gBKToolStripMenuItem";
            this.gBKToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gBKToolStripMenuItem.Text = "GBK";
            this.gBKToolStripMenuItem.Click += new System.EventHandler(this.gBKToolStripMenuItem_Click);
            // 
            // gB2312ToolStripMenuItem
            // 
            this.gB2312ToolStripMenuItem.Name = "gB2312ToolStripMenuItem";
            this.gB2312ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gB2312ToolStripMenuItem.Text = "GB2312";
            this.gB2312ToolStripMenuItem.Click += new System.EventHandler(this.gB2312ToolStripMenuItem_Click);
            // 
            // uTF16ToolStripMenuItem
            // 
            this.uTF16ToolStripMenuItem.Name = "uTF16ToolStripMenuItem";
            this.uTF16ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.uTF16ToolStripMenuItem.Text = "UTF-16";
            this.uTF16ToolStripMenuItem.Click += new System.EventHandler(this.uTF16ToolStripMenuItem_Click);
            // 
            // unicodeToolStripMenuItem
            // 
            this.unicodeToolStripMenuItem.Name = "unicodeToolStripMenuItem";
            this.unicodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.unicodeToolStripMenuItem.Text = "Unicode";
            this.unicodeToolStripMenuItem.Click += new System.EventHandler(this.unicodeToolStripMenuItem_Click);
            // 
            // aSCIIToolStripMenuItem
            // 
            this.aSCIIToolStripMenuItem.Name = "aSCIIToolStripMenuItem";
            this.aSCIIToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aSCIIToolStripMenuItem.Text = "ASCII";
            this.aSCIIToolStripMenuItem.Click += new System.EventHandler(this.aSCIIToolStripMenuItem_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(181, 22);
            this.tsmiAbout.Text = "关于(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFind});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑ToolStripMenuItem.Text = "编辑(&E)";
            // 
            // tsmiFind
            // 
            this.tsmiFind.Name = "tsmiFind";
            this.tsmiFind.Size = new System.Drawing.Size(139, 22);
            this.tsmiFind.Text = "查找 Ctrl+F";
            this.tsmiFind.Click += new System.EventHandler(this.tsmiFind_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(61, 21);
            this.tsmiHelp.Text = "帮助(&H)";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // txtContent
            // 
            this.txtContent.AcceptsReturn = true;
            this.txtContent.AcceptsTab = true;
            this.txtContent.BackColor = System.Drawing.Color.LightGreen;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContent.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(502, 372);
            this.txtContent.TabIndex = 2;
            this.txtContent.Click += new System.EventHandler(this.txtContent_Click);
            this.txtContent.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCoding);
            this.panel1.Controls.Add(this.lblPrompt);
            this.panel1.Controls.Add(this.lblMode);
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Location = new System.Drawing.Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 25);
            this.panel1.TabIndex = 4;
            // 
            // lblCoding
            // 
            this.lblCoding.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCoding.BackColor = System.Drawing.Color.Transparent;
            this.lblCoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoding.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCoding.Location = new System.Drawing.Point(383, -2);
            this.lblCoding.Name = "lblCoding";
            this.lblCoding.Size = new System.Drawing.Size(122, 26);
            this.lblCoding.TabIndex = 3;
            this.lblCoding.Text = "编码：UTF-8";
            this.lblCoding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrompt
            // 
            this.lblPrompt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(107, 4);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(125, 12);
            this.lblPrompt.TabIndex = 2;
            this.lblPrompt.Text = "点击帮助查看使用技巧";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Transparent;
            this.lblMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMode.Location = new System.Drawing.Point(51, 4);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(29, 12);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "none";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(10, 4);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(35, 12);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "mode:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtContent);
            this.splitContainer1.Size = new System.Drawing.Size(759, 372);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(761, 425);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "乐智知识库-知识管理专家";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddLove;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiFind;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblname;
        public System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label lblCoding;
        private System.Windows.Forms.ToolStripMenuItem 更改编码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gBKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gB2312ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTF16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unicodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSCIIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenWorkFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMyLove;
    }
}

