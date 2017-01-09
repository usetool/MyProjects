namespace 天天管家
{
    partial class FrmSetRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetRun));
            this.label1 = new System.Windows.Forms.Label();
            this.btnIsRun = new System.Windows.Forms.Button();
            this.btnNoRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "是否允许开机自启：";
            // 
            // btnIsRun
            // 
            this.btnIsRun.Location = new System.Drawing.Point(216, 22);
            this.btnIsRun.Name = "btnIsRun";
            this.btnIsRun.Size = new System.Drawing.Size(75, 23);
            this.btnIsRun.TabIndex = 1;
            this.btnIsRun.Text = "允许";
            this.btnIsRun.UseVisualStyleBackColor = true;
            this.btnIsRun.Click += new System.EventHandler(this.btnIsRun_Click);
            // 
            // btnNoRun
            // 
            this.btnNoRun.Location = new System.Drawing.Point(306, 22);
            this.btnNoRun.Name = "btnNoRun";
            this.btnNoRun.Size = new System.Drawing.Size(75, 23);
            this.btnNoRun.TabIndex = 2;
            this.btnNoRun.Text = "禁止";
            this.btnNoRun.UseVisualStyleBackColor = true;
            this.btnNoRun.Click += new System.EventHandler(this.btnNoRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "提示：设置前请运行此软件时右键以管理员身份运行，否则无法设置开机自启！\r\n";
            // 
            // FrmSetRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 95);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNoRun);
            this.Controls.Add(this.btnIsRun);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSetRun";
            this.Text = "开机自启";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIsRun;
        private System.Windows.Forms.Button btnNoRun;
        private System.Windows.Forms.Label label2;
    }
}