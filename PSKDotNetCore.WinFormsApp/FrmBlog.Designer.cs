namespace PSKDotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title = new Label();
            txtTitle = new TextBox();
            author = new Label();
            txtAuthor = new TextBox();
            content = new Label();
            txtContent = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Location = new Point(150, 41);
            title.Name = "title";
            title.Size = new Size(45, 20);
            title.TabIndex = 0;
            title.Text = "Title :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(150, 64);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(299, 27);
            txtTitle.TabIndex = 1;
            // 
            // author
            // 
            author.AutoSize = true;
            author.Location = new Point(150, 100);
            author.Name = "author";
            author.Size = new Size(54, 20);
            author.TabIndex = 2;
            author.Text = "Author";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(150, 123);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(299, 27);
            txtAuthor.TabIndex = 3;
            // 
            // content
            // 
            content.AutoSize = true;
            content.Location = new Point(150, 153);
            content.Name = "content";
            content.Size = new Size(61, 20);
            content.TabIndex = 4;
            content.Text = "Content";
            // 
            // txtContent
            // 
            txtContent.Location = new Point(150, 176);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(299, 77);
            txtContent.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Highlight;
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(150, 259);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(250, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 192, 192);
            btnUpdate.ForeColor = SystemColors.Control;
            btnUpdate.Location = new Point(250, 259);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtContent);
            Controls.Add(content);
            Controls.Add(txtAuthor);
            Controls.Add(author);
            Controls.Add(txtTitle);
            Controls.Add(title);
            Name = "FrmBlog";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private TextBox txtTitle;
        private Label author;
        private TextBox txtAuthor;
        private Label content;
        private TextBox txtContent;
        private Button btnCancel;
        private Button btnSave;
        private Button btnUpdate;
    }
}
