
namespace PT4
{
    partial class RechercheStock
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.criteriaCombo = new System.Windows.Forms.ComboBox();
            this.addRow = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.Controls.Add(this.criteriaCombo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addRow, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.minusButton, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // criteriaCombo
            // 
            this.criteriaCombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.criteriaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaCombo.FormattingEnabled = true;
            this.criteriaCombo.Items.AddRange(new object[] {
            "Nom",
            "Prix d\'achat",
            "Prix de vente",
            "Quantité",
            "Description",
            "Medicament",
            "Vendable"});
            this.criteriaCombo.Location = new System.Drawing.Point(135, 15);
            this.criteriaCombo.Name = "criteriaCombo";
            this.criteriaCombo.Size = new System.Drawing.Size(161, 21);
            this.criteriaCombo.TabIndex = 0;
            this.criteriaCombo.SelectedIndexChanged += new System.EventHandler(this.critere_SelectedIndexChanged);
            // 
            // addRow
            // 
            this.addRow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addRow.Location = new System.Drawing.Point(3, 66);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(65, 23);
            this.addRow.TabIndex = 1;
            this.addRow.Text = "+";
            this.addRow.UseVisualStyleBackColor = true;
            this.addRow.Click += new System.EventHandler(this.addRow_click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonConfirm, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConfirm.Location = new System.Drawing.Point(184, 424);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(432, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // minusButton
            // 
            this.minusButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.minusButton.Location = new System.Drawing.Point(724, 14);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(65, 23);
            this.minusButton.TabIndex = 2;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.remove_Click);
            // 
            // RechercheStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Name = "RechercheStock";
            this.Text = "RechercheStock";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonConfirm;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox criteriaCombo;
        private System.Windows.Forms.Button minusButton;
    }
}