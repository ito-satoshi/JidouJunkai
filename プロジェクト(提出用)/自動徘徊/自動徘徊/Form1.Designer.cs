namespace 自動徘徊
{
    partial class main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOpenDlg1 = new System.Windows.Forms.Button();
            this.cmdOpenDlg2 = new System.Windows.Forms.Button();
            this.cmdOpenDlg3 = new System.Windows.Forms.Button();
            this.cmdOpenDlg4 = new System.Windows.Forms.Button();
            this.cmdOpenDlg5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOpenDlg1
            // 
            this.cmdOpenDlg1.Location = new System.Drawing.Point(39, 38);
            this.cmdOpenDlg1.Name = "cmdOpenDlg1";
            this.cmdOpenDlg1.Size = new System.Drawing.Size(190, 62);
            this.cmdOpenDlg1.TabIndex = 0;
            this.cmdOpenDlg1.Text = "URL変更・登録";
            this.cmdOpenDlg1.UseVisualStyleBackColor = true;
            // 
            // cmdOpenDlg2
            // 
            this.cmdOpenDlg2.Location = new System.Drawing.Point(263, 38);
            this.cmdOpenDlg2.Name = "cmdOpenDlg2";
            this.cmdOpenDlg2.Size = new System.Drawing.Size(199, 62);
            this.cmdOpenDlg2.TabIndex = 1;
            this.cmdOpenDlg2.Tag = "";
            this.cmdOpenDlg2.Text = "サービスの再起動";
            this.cmdOpenDlg2.UseVisualStyleBackColor = true;
            // 
            // cmdOpenDlg3
            // 
            this.cmdOpenDlg3.Location = new System.Drawing.Point(505, 38);
            this.cmdOpenDlg3.Name = "cmdOpenDlg3";
            this.cmdOpenDlg3.Size = new System.Drawing.Size(207, 62);
            this.cmdOpenDlg3.TabIndex = 2;
            this.cmdOpenDlg3.Text = "ヘルプ";
            this.cmdOpenDlg3.UseVisualStyleBackColor = true;
            // 
            // cmdOpenDlg4
            // 
            this.cmdOpenDlg4.Location = new System.Drawing.Point(740, 38);
            this.cmdOpenDlg4.Name = "cmdOpenDlg4";
            this.cmdOpenDlg4.Size = new System.Drawing.Size(209, 62);
            this.cmdOpenDlg4.TabIndex = 3;
            this.cmdOpenDlg4.Text = "制限解除";
            this.cmdOpenDlg4.UseVisualStyleBackColor = true;
            // 
            // cmdOpenDlg5
            // 
            this.cmdOpenDlg5.Location = new System.Drawing.Point(980, 38);
            this.cmdOpenDlg5.Name = "cmdOpenDlg5";
            this.cmdOpenDlg5.Size = new System.Drawing.Size(189, 62);
            this.cmdOpenDlg5.TabIndex = 4;
            this.cmdOpenDlg5.Text = "記事の取得間隔";
            this.cmdOpenDlg5.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 808);
            this.Controls.Add(this.cmdOpenDlg5);
            this.Controls.Add(this.cmdOpenDlg4);
            this.Controls.Add(this.cmdOpenDlg3);
            this.Controls.Add(this.cmdOpenDlg2);
            this.Controls.Add(this.cmdOpenDlg1);
            this.Name = "main";
            this.Text = "自動徘徊";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOpenDlg1;
        private System.Windows.Forms.Button cmdOpenDlg2;
        private System.Windows.Forms.Button cmdOpenDlg3;
        private System.Windows.Forms.Button cmdOpenDlg4;
        private System.Windows.Forms.Button cmdOpenDlg5;
    }
}

