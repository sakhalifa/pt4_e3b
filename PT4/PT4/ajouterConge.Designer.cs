
namespace PT4
{
    partial class ajouterConge
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDebut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxRegulier = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(66, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date début:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(66, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date fin:";
            // 
            // dateTimePickerDebut
            // 
            this.dateTimePickerDebut.CalendarForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dateTimePickerDebut.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaptionText;
            this.dateTimePickerDebut.Location = new System.Drawing.Point(69, 84);
            this.dateTimePickerDebut.Name = "dateTimePickerDebut";
            this.dateTimePickerDebut.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDebut.TabIndex = 3;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(69, 159);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFin.TabIndex = 4;
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.buttonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAnnuler.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAnnuler.Location = new System.Drawing.Point(69, 255);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 5;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = false;
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.BackColor = System.Drawing.Color.Transparent;
            this.buttonConfirmer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonConfirmer.Location = new System.Drawing.Point(194, 255);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmer.TabIndex = 6;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = false;
            this.buttonConfirmer.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(66, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Régulier ? ";
            // 
            // checkBoxRegulier
            // 
            this.checkBoxRegulier.AutoSize = true;
            this.checkBoxRegulier.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRegulier.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBoxRegulier.Location = new System.Drawing.Point(130, 198);
            this.checkBoxRegulier.Name = "checkBoxRegulier";
            this.checkBoxRegulier.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRegulier.TabIndex = 8;
            this.checkBoxRegulier.UseVisualStyleBackColor = false;
            // 
            // ajouterConge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PT4.Properties.Resources.parrot_g3fd41130a_1920;
            this.ClientSize = new System.Drawing.Size(347, 332);
            this.Controls.Add(this.checkBoxRegulier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConfirmer);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.dateTimePickerDebut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ajouterConge";
            this.Text = "ajouterConge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerDebut;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Button buttonConfirmer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxRegulier;
    }
}