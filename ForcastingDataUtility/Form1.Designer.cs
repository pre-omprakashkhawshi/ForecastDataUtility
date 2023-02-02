
namespace ForcastingDataUtility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.SelectEnvironment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectCategory = new System.Windows.Forms.ComboBox();
            this.ProjectIdsText = new System.Windows.Forms.TextBox();
            this.ProjectIdsLabel = new System.Windows.Forms.Label();
            this.AccountIdLabel = new System.Windows.Forms.Label();
            this.AccountIdText = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Result = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Environment";
            // 
            // SelectEnvironment
            // 
            this.SelectEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectEnvironment.FormattingEnabled = true;
            this.SelectEnvironment.Location = new System.Drawing.Point(96, 16);
            this.SelectEnvironment.Name = "SelectEnvironment";
            this.SelectEnvironment.Size = new System.Drawing.Size(213, 24);
            this.SelectEnvironment.TabIndex = 1;
            this.SelectEnvironment.SelectedIndexChanged += new System.EventHandler(this.SelectEnvironment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Category";
            // 
            // SelectCategory
            // 
            this.SelectCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectCategory.FormattingEnabled = true;
            this.SelectCategory.Location = new System.Drawing.Point(442, 13);
            this.SelectCategory.Name = "SelectCategory";
            this.SelectCategory.Size = new System.Drawing.Size(213, 24);
            this.SelectCategory.TabIndex = 3;
            this.SelectCategory.SelectedIndexChanged += new System.EventHandler(this.SelectCategory_SelectedIndexChanged);
            // 
            // ProjectIdsText
            // 
            this.ProjectIdsText.Location = new System.Drawing.Point(747, 16);
            this.ProjectIdsText.Name = "ProjectIdsText";
            this.ProjectIdsText.Size = new System.Drawing.Size(134, 22);
            this.ProjectIdsText.TabIndex = 4;
            // 
            // ProjectIdsLabel
            // 
            this.ProjectIdsLabel.AutoSize = true;
            this.ProjectIdsLabel.Location = new System.Drawing.Point(661, 19);
            this.ProjectIdsLabel.Name = "ProjectIdsLabel";
            this.ProjectIdsLabel.Size = new System.Drawing.Size(74, 17);
            this.ProjectIdsLabel.TabIndex = 5;
            this.ProjectIdsLabel.Text = "Project Ids";
            // 
            // AccountIdLabel
            // 
            this.AccountIdLabel.AutoSize = true;
            this.AccountIdLabel.Location = new System.Drawing.Point(661, 20);
            this.AccountIdLabel.Name = "AccountIdLabel";
            this.AccountIdLabel.Size = new System.Drawing.Size(74, 17);
            this.AccountIdLabel.TabIndex = 6;
            this.AccountIdLabel.Text = "Account Id";
            // 
            // AccountIdText
            // 
            this.AccountIdText.Location = new System.Drawing.Point(747, 15);
            this.AccountIdText.Name = "AccountIdText";
            this.AccountIdText.Size = new System.Drawing.Size(134, 22);
            this.AccountIdText.TabIndex = 7;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(896, 12);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 24);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Result});
            this.dataGridView1.Location = new System.Drawing.Point(269, 99);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(508, 270);
            this.dataGridView1.TabIndex = 10;
            // 
            // Result
            // 
            this.Result.FillWeight = 1500F;
            this.Result.HeaderText = "Result";
            this.Result.LinkColor = System.Drawing.Color.Black;
            this.Result.MinimumWidth = 10;
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.ToolTipText = "Result";
            this.Result.Width = 327;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1037, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.AccountIdText);
            this.Controls.Add(this.AccountIdLabel);
            this.Controls.Add(this.ProjectIdsLabel);
            this.Controls.Add(this.ProjectIdsText);
            this.Controls.Add(this.SelectCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectEnvironment);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forcasting Data Utility";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectEnvironment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SelectCategory;
        private System.Windows.Forms.TextBox ProjectIdsText;
        private System.Windows.Forms.Label ProjectIdsLabel;
        private System.Windows.Forms.Label AccountIdLabel;
        private System.Windows.Forms.TextBox AccountIdText;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewLinkColumn Result;
    }
}

