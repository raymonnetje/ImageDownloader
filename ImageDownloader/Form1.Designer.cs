namespace ImageDownloader
{
    partial class Form1
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.imageTable = new System.Windows.Forms.DataGridView();
            this.imageTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageTable)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(239, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyUp);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(257, 11);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 21);
            this.search.TabIndex = 1;
            this.search.Text = "Zoek";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // imageTable
            // 
            this.imageTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.imageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imageTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imageTitle,
            this.imageLink,
            this.imagePath});
            this.imageTable.Location = new System.Drawing.Point(12, 39);
            this.imageTable.Name = "imageTable";
            this.imageTable.Size = new System.Drawing.Size(777, 383);
            this.imageTable.TabIndex = 2;
            // 
            // imageTitle
            // 
            this.imageTitle.HeaderText = "Title";
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.ReadOnly = true;
            // 
            // imageLink
            // 
            this.imageLink.HeaderText = "Link";
            this.imageLink.Name = "imageLink";
            this.imageLink.ReadOnly = true;
            // 
            // imagePath
            // 
            this.imagePath.HeaderText = "Path";
            this.imagePath.Name = "imagePath";
            this.imagePath.ReadOnly = true;
            // 
            // queryComboBox
            // 
            this.queryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.queryComboBox.FormattingEnabled = true;
            this.queryComboBox.Location = new System.Drawing.Point(565, 12);
            this.queryComboBox.Name = "queryComboBox";
            this.queryComboBox.Size = new System.Drawing.Size(224, 21);
            this.queryComboBox.TabIndex = 3;
            this.queryComboBox.SelectedValueChanged += new System.EventHandler(this.queryComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Query history:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryComboBox);
            this.Controls.Add(this.imageTable);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView imageTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagePath;
        private System.Windows.Forms.ComboBox queryComboBox;
        private System.Windows.Forms.Label label1;
    }
}

