
namespace PT4
{
    partial class AfficherRdv
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
            this.masterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxAddLayout = new System.Windows.Forms.TableLayoutPanel();
            this.rendezVous = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clients = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterLayout.SuspendLayout();
            this.listBoxAddLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // masterLayout
            // 
            this.masterLayout.ColumnCount = 2;
            this.masterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.masterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.Controls.Add(this.listBoxAddLayout, 1, 0);
            this.masterLayout.Controls.Add(this.panel1, 0, 0);
            this.masterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterLayout.Location = new System.Drawing.Point(0, 0);
            this.masterLayout.Name = "masterLayout";
            this.masterLayout.RowCount = 1;
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.Size = new System.Drawing.Size(416, 373);
            this.masterLayout.TabIndex = 0;
            // 
            // listBoxAddLayout
            // 
            this.listBoxAddLayout.ColumnCount = 1;
            this.listBoxAddLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listBoxAddLayout.Controls.Add(this.rendezVous, 0, 0);
            this.listBoxAddLayout.Controls.Add(this.buttonAdd, 0, 1);
            this.listBoxAddLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAddLayout.Location = new System.Drawing.Point(141, 3);
            this.listBoxAddLayout.Name = "listBoxAddLayout";
            this.listBoxAddLayout.RowCount = 2;
            this.listBoxAddLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listBoxAddLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listBoxAddLayout.Size = new System.Drawing.Size(272, 367);
            this.listBoxAddLayout.TabIndex = 2;
            // 
            // rendezVous
            // 
            this.rendezVous.ContextMenuStrip = this.contextMenuStrip1;
            this.rendezVous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rendezVous.FormattingEnabled = true;
            this.rendezVous.HorizontalScrollbar = true;
            this.rendezVous.Location = new System.Drawing.Point(0, 0);
            this.rendezVous.Margin = new System.Windows.Forms.Padding(0);
            this.rendezVous.Name = "rendezVous";
            this.rendezVous.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.rendezVous.Size = new System.Drawing.Size(272, 344);
            this.rendezVous.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Location = new System.Drawing.Point(0, 344);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(272, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.clients);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 48);
            this.panel1.TabIndex = 0;
            // 
            // clients
            // 
            this.clients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clients.FormattingEnabled = true;
            this.clients.Location = new System.Drawing.Point(3, 16);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(121, 21);
            this.clients.TabIndex = 1;
            this.clients.SelectedIndexChanged += new System.EventHandler(this.clients_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // AfficherRdv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 373);
            this.Controls.Add(this.masterLayout);
            this.Name = "AfficherRdv";
            this.Text = "AfficherRdv";
            this.masterLayout.ResumeLayout(false);
            this.listBoxAddLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel masterLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox clients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox rendezVous;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel listBoxAddLayout;
        private System.Windows.Forms.Button buttonAdd;
    }
}