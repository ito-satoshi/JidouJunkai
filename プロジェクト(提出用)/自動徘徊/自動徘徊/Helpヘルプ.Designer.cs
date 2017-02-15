namespace 自動徘徊
{
    partial class Helpヘルプ
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(104, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 168);
            this.label1.TabIndex = 0;
            this.label1.Text = "1マスに5ケタのプロダクトキーを入力します。\r\nプロダクトキーを入力することでこのアプリをさらに使いやすく\r\nできます。\t\r\nプロダクトキーは本製品「常駐型ネット" +
    "自動徘徊アプリ」の\r\nパッケージ内に付属されています。\t\r\n\r\n\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "閉じる";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Helpヘルプ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Helpヘルプ";
            this.Text = "制限解除ヘルプ";
            this.Load += new System.EventHandler(this.Helpヘルプ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}