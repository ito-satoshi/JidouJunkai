namespace 自動徘徊
{
    partial class 取得間隔ヘルプ
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
            this.label1.Location = new System.Drawing.Point(55, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(774, 168);
            this.label1.TabIndex = 0;
            this.label1.Text = "ラジオボタンによって取得間隔を時間単位で取得させることや\r\n分単位で細かく設定するかの二つを選択することができます。\r\n時間単位を選択した場合、１時間から１２時間" +
    "間隔で設定が可能です\r\n分単位を選択した場合、時間帯のように開発者が決めた時間に縛られることなく、\r\n利用者が手動で好きな間隔を設定可能です。\r\n1時間３０分を" +
    "設定したい場合、９０分と入力すると設定できます。\r\n\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "閉じる";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 取得間隔ヘルプ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 321);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "取得間隔ヘルプ";
            this.Text = "取得間隔ヘルプ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}