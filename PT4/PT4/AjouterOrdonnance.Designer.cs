
namespace PT4
{
    partial class AjouterOrdonnance
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
            this.leftRightLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAnimal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.masterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.leftRightLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.masterLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftRightLayout
            // 
            this.leftRightLayout.ColumnCount = 2;
            this.leftRightLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftRightLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftRightLayout.Controls.Add(this.panel1, 0, 0);
            this.leftRightLayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.leftRightLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftRightLayout.Location = new System.Drawing.Point(3, 3);
            this.leftRightLayout.Name = "leftRightLayout";
            this.leftRightLayout.RowCount = 1;
            this.leftRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 415F));
            this.leftRightLayout.Size = new System.Drawing.Size(794, 415);
            this.leftRightLayout.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.labelAnimal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(131, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 45);
            this.panel1.TabIndex = 0;
            // 
            // labelAnimal
            // 
            this.labelAnimal.BackColor = System.Drawing.Color.Transparent;
            this.labelAnimal.Location = new System.Drawing.Point(7, 22);
            this.labelAnimal.Name = "labelAnimal";
            this.labelAnimal.Size = new System.Drawing.Size(127, 23);
            this.labelAnimal.TabIndex = 1;
            this.labelAnimal.Text = "label3";
            this.labelAnimal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Animal concerné";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(400, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 409);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Liste des soins";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Location = new System.Drawing.Point(0, 386);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(391, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(0, 13);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(391, 373);
            this.listBox1.TabIndex = 2;
            // 
            // masterLayout
            // 
            this.masterLayout.ColumnCount = 1;
            this.masterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.Controls.Add(this.leftRightLayout, 0, 0);
            this.masterLayout.Controls.Add(this.buttonConfirm, 0, 1);
            this.masterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterLayout.Location = new System.Drawing.Point(0, 0);
            this.masterLayout.Name = "masterLayout";
            this.masterLayout.RowCount = 2;
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.masterLayout.Size = new System.Drawing.Size(800, 450);
            this.masterLayout.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConfirm.Location = new System.Drawing.Point(362, 424);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // AjouterOrdonnance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.masterLayout);
            this.Name = "AjouterOrdonnance";
            this.Text = "AjouterOrdonnance";
            this.leftRightLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.masterLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel leftRightLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel masterLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelAnimal;
    }
}