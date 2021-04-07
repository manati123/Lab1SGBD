
namespace WinFormsApp1
{
    partial class Form1
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
            this.parentGridView = new System.Windows.Forms.DataGridView();
            this.childGridView = new System.Windows.Forms.DataGridView();
            this.updateBD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.parentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // parentGridView
            // 
            this.parentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parentGridView.Location = new System.Drawing.Point(32, 12);
            this.parentGridView.Name = "parentGridView";
            this.parentGridView.RowTemplate.Height = 25;
            this.parentGridView.Size = new System.Drawing.Size(673, 197);
            this.parentGridView.TabIndex = 0;
            // 
            // childGridView
            // 
            this.childGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childGridView.Location = new System.Drawing.Point(32, 233);
            this.childGridView.Name = "childGridView";
            this.childGridView.RowTemplate.Height = 25;
            this.childGridView.Size = new System.Drawing.Size(673, 189);
            this.childGridView.TabIndex = 1;
            // 
            // updateBD
            // 
            this.updateBD.Location = new System.Drawing.Point(746, 153);
            this.updateBD.Name = "updateBD";
            this.updateBD.Size = new System.Drawing.Size(173, 56);
            this.updateBD.TabIndex = 2;
            this.updateBD.Text = "UpdateDB";
            this.updateBD.UseVisualStyleBackColor = true;
            this.updateBD.Click += new System.EventHandler(this.updateBD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 450);
            this.Controls.Add(this.updateBD);
            this.Controls.Add(this.childGridView);
            this.Controls.Add(this.parentGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.parentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView parentGridView;
        private System.Windows.Forms.DataGridView childGridView;
        private System.Windows.Forms.Button updateBD;
    }
}

