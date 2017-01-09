namespace Do_you_love_me
{
    partial class Form1
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
            this.btnLo = new System.Windows.Forms.Button();
            this.btnNoLo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLo
            // 
            this.btnLo.Location = new System.Drawing.Point(142, 101);
            this.btnLo.Name = "btnLo";
            this.btnLo.Size = new System.Drawing.Size(42, 23);
            this.btnLo.TabIndex = 0;
            this.btnLo.Text = "喜欢";
            this.btnLo.UseVisualStyleBackColor = true;
            this.btnLo.Click += new System.EventHandler(this.btnLo_Click);
            // 
            // btnNoLo
            // 
            this.btnNoLo.Location = new System.Drawing.Point(263, 101);
            this.btnNoLo.Name = "btnNoLo";
            this.btnNoLo.Size = new System.Drawing.Size(51, 23);
            this.btnNoLo.TabIndex = 1;
            this.btnNoLo.Text = "不喜欢";
            this.btnNoLo.UseVisualStyleBackColor = true;
            this.btnNoLo.Click += new System.EventHandler(this.btnNoLo_Click);
            this.btnNoLo.MouseEnter += new System.EventHandler(this.btnNoLo_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 343);
            this.Controls.Add(this.btnNoLo);
            this.Controls.Add(this.btnLo);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "你喜欢发给你程序的人吗？";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLo;
        private System.Windows.Forms.Button btnNoLo;
    }
}

