
namespace PT4
{
    partial class InterfaceJournalAction
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.User = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Action = new System.Windows.Forms.Label();
            this.Rights = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.User, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Date, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Action, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Rights, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(38, 46);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(700, 500);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(700, 300);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // User
            // 
            this.User.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(61, 23);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(53, 13);
            this.User.TabIndex = 0;
            this.User.Text = "Utilisateur";
            this.User.Paint += new System.Windows.Forms.PaintEventHandler(this.Utilisateur_Paint);
            // 
            // Date
            // 
            this.Date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(247, 23);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(30, 13);
            this.Date.TabIndex = 1;
            this.Date.Text = "Date";
            this.Date.Paint += new System.Windows.Forms.PaintEventHandler(this.Date_Paint);
            // 
            // Action
            // 
            this.Action.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Action.AutoSize = true;
            this.Action.Location = new System.Drawing.Point(419, 23);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(37, 13);
            this.Action.TabIndex = 2;
            this.Action.Text = "Action";
            this.Action.Paint += new System.Windows.Forms.PaintEventHandler(this.Action_Paint);
            // 
            // Rights
            // 
            this.Rights.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Rights.AutoSize = true;
            this.Rights.Location = new System.Drawing.Point(595, 23);
            this.Rights.Name = "Rights";
            this.Rights.Size = new System.Drawing.Size(34, 13);
            this.Rights.TabIndex = 3;
            this.Rights.Text = "Droits";
            this.Rights.Paint += new System.Windows.Forms.PaintEventHandler(this.Rights_Paint);
            // 
            // InterfaceJournalAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InterfaceJournalAction";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Action;
        private System.Windows.Forms.Label Rights;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

