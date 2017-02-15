namespace 自動徘徊
{
    partial class 検索ヘルプ
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
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 192);
            this.label1.TabIndex = 0;
            this.label1.Text = "今までに取得した記事の中から「単語」を元に検索をかけ、\r\n「単語」が含まれている記事のみ表示します。\t\r\n「日付」検索では、選択された日付の記事のみ\r\n表示させる" +
    "ことが可能です。\t\r\n「既読」の記事だけを表示したい場合は\r\n「既読」のチェックボックスにチェックを入れ、\t\r\n「未読」の記事だけを表示したい場合は\r\n「未読」" +
    "のチェックボックスにチェックを入れることで可能です\t\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "閉じる";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 検索ヘルプ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 357);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "検索ヘルプ";
            this.Text = "検索ヘルプ";
            this.Load += new System.EventHandler(this.検索ヘルプ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}