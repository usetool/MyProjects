namespace 乐智知识库
{
    partial class FrmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.cboFont = new System.Windows.Forms.ComboBox();
            this.cboBackGroundColor = new System.Windows.Forms.ComboBox();
            this.cboEncode = new System.Windows.Forms.ComboBox();
            this.cbx_openStart = new System.Windows.Forms.CheckBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cbo_font_color = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(75, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字体样式：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "编辑器背景色：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "文本编码：";
            // 
            // cboFont
            // 
            this.cboFont.FormattingEnabled = true;
            this.cboFont.Location = new System.Drawing.Point(146, 51);
            this.cboFont.Name = "cboFont";
            this.cboFont.Size = new System.Drawing.Size(159, 20);
            this.cboFont.TabIndex = 4;
            this.cboFont.DropDown += new System.EventHandler(this.cboFont_DropDown);
            // 
            // cboBackGroundColor
            // 
            this.cboBackGroundColor.FormattingEnabled = true;
            this.cboBackGroundColor.Location = new System.Drawing.Point(146, 134);
            this.cboBackGroundColor.Name = "cboBackGroundColor";
            this.cboBackGroundColor.Size = new System.Drawing.Size(159, 20);
            this.cboBackGroundColor.TabIndex = 5;
            this.cboBackGroundColor.DropDown += new System.EventHandler(this.cboBackGroundColor_DropDown);
            // 
            // cboEncode
            // 
            this.cboEncode.FormattingEnabled = true;
            this.cboEncode.Location = new System.Drawing.Point(146, 182);
            this.cboEncode.Name = "cboEncode";
            this.cboEncode.Size = new System.Drawing.Size(159, 20);
            this.cboEncode.TabIndex = 6;
            this.cboEncode.DropDown += new System.EventHandler(this.cboEncode_DropDown);
            // 
            // cbx_openStart
            // 
            this.cbx_openStart.AutoSize = true;
            this.cbx_openStart.Location = new System.Drawing.Point(336, 55);
            this.cbx_openStart.Name = "cbx_openStart";
            this.cbx_openStart.Size = new System.Drawing.Size(72, 16);
            this.cbx_openStart.TabIndex = 7;
            this.cbx_openStart.Text = "开机自启";
            this.cbx_openStart.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(204, 253);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存修改";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(394, 253);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 9;
            this.btn_reset.Text = "恢复默认";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // cbo_font_color
            // 
            this.cbo_font_color.FormattingEnabled = true;
            this.cbo_font_color.Location = new System.Drawing.Point(146, 93);
            this.cbo_font_color.Name = "cbo_font_color";
            this.cbo_font_color.Size = new System.Drawing.Size(159, 20);
            this.cbo_font_color.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "字体颜色：";
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 297);
            this.Controls.Add(this.cbo_font_color);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cbx_openStart);
            this.Controls.Add(this.cboEncode);
            this.Controls.Add(this.cboBackGroundColor);
            this.Controls.Add(this.cboFont);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSetting";
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ComboBox cboFont;
        private System.Windows.Forms.ComboBox cboBackGroundColor;
        private System.Windows.Forms.ComboBox cboEncode;
        private System.Windows.Forms.CheckBox cbx_openStart;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ComboBox cbo_font_color;
        private System.Windows.Forms.Label label2;
    }
}