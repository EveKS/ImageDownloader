namespace ImageDownloader
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbInfo = new System.Windows.Forms.Label();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.btnDovnload = new System.Windows.Forms.Button();
            this.btnTo = new System.Windows.Forms.Button();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInfo.Location = new System.Drawing.Point(-1, 89);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(243, 37);
            this.lbInfo.TabIndex = 17;
            this.lbInfo.Text = "Saved: 0 from 0";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Location = new System.Drawing.Point(6, 133);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(1047, 423);
            this.richTextBoxResult.TabIndex = 16;
            this.richTextBoxResult.Text = "\n";
            // 
            // btnDovnload
            // 
            this.btnDovnload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDovnload.Location = new System.Drawing.Point(851, 89);
            this.btnDovnload.Name = "btnDovnload";
            this.btnDovnload.Size = new System.Drawing.Size(202, 38);
            this.btnDovnload.TabIndex = 15;
            this.btnDovnload.Text = "Download";
            this.btnDovnload.UseVisualStyleBackColor = true;
            // 
            // btnTo
            // 
            this.btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTo.Location = new System.Drawing.Point(949, 12);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(104, 23);
            this.btnTo.TabIndex = 14;
            this.btnTo.Text = "Save to";
            this.btnTo.UseVisualStyleBackColor = true;
            // 
            // tbTo
            // 
            this.tbTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTo.Location = new System.Drawing.Point(549, 15);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(394, 20);
            this.tbTo.TabIndex = 12;
            // 
            // tbQuery
            // 
            this.tbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuery.Location = new System.Drawing.Point(253, 44);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(800, 35);
            this.tbQuery.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Enter the query string:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(907, 563);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "vikkes@yandex.ru © EveKS";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 585);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.btnDovnload);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.tbQuery);
            this.Name = "Main";
            this.Text = "Image downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Button btnDovnload;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

