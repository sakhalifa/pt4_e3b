namespace PT4
{
    partial class AfficherSalarie
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.masterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.allSalarie = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.masterLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // masterLayout
            // 
            this.masterLayout.ColumnCount = 1;
            this.masterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.Controls.Add(this.allSalarie, 0, 0);
            this.masterLayout.Controls.Add(this.buttonAdd, 0, 1);
            this.masterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterLayout.Location = new System.Drawing.Point(0, 0);
            this.masterLayout.Name = "masterLayout";
            this.masterLayout.RowCount = 2;
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.masterLayout.Size = new System.Drawing.Size(390, 391);
            this.masterLayout.TabIndex = 1;
            // 
            // allSalarie
            // 
            this.allSalarie.ContextMenuStrip = this.contextMenuStrip1;
            this.allSalarie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allSalarie.FormattingEnabled = true;
            this.allSalarie.Location = new System.Drawing.Point(0, 0);
            this.allSalarie.Margin = new System.Windows.Forms.Padding(0);
            this.allSalarie.Name = "allSalarie";
            this.allSalarie.Size = new System.Drawing.Size(390, 368);
            this.allSalarie.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Location = new System.Drawing.Point(0, 368);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(390, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // AfficherSalarie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 391);
            this.Controls.Add(this.masterLayout);
            this.Name = "AfficherSalarie";
            this.Text = "AfficherSalarie";
            this.contextMenuStrip1.ResumeLayout(false);
            this.masterLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel masterLayout;
        private System.Windows.Forms.ListBox allSalarie;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
    }
}