
namespace PT4
{
    partial class MenuAcceuil
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
            this.News = new System.Windows.Forms.Label();
            this.PlanningJournée = new System.Windows.Forms.Label();
            this.Notes = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // News
            // 
            this.News.AutoSize = true;
            this.News.BackColor = System.Drawing.Color.Transparent;
            this.News.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.News.ForeColor = System.Drawing.Color.White;
            this.News.Location = new System.Drawing.Point(23, 61);
            this.News.Name = "News";
            this.News.Size = new System.Drawing.Size(46, 17);
            this.News.TabIndex = 0;
            this.News.Text = "News:";
            // 
            // PlanningJournée
            // 
            this.PlanningJournée.AutoSize = true;
            this.PlanningJournée.BackColor = System.Drawing.Color.Transparent;
            this.PlanningJournée.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlanningJournée.ForeColor = System.Drawing.Color.White;
            this.PlanningJournée.Location = new System.Drawing.Point(559, 96);
            this.PlanningJournée.Name = "PlanningJournée";
            this.PlanningJournée.Size = new System.Drawing.Size(154, 17);
            this.PlanningJournée.TabIndex = 1;
            this.PlanningJournée.Text = "Planning de la journée:";
            // 
            // Notes
            // 
            this.Notes.AutoSize = true;
            this.Notes.BackColor = System.Drawing.Color.Transparent;
            this.Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notes.ForeColor = System.Drawing.Color.White;
            this.Notes.Location = new System.Drawing.Point(20, 260);
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(49, 17);
            this.Notes.TabIndex = 2;
            this.Notes.Text = "Notes:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(522, 149);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // MenuAcceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PT4.Properties.Resources.parrot_g3fd41130a_1920;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.PlanningJournée);
            this.Controls.Add(this.News);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MenuAcceuil";
            this.Text = ".";
            this.Controls.SetChildIndex(this.News, 0);
            this.Controls.SetChildIndex(this.PlanningJournée, 0);
            this.Controls.SetChildIndex(this.Notes, 0);
            this.Controls.SetChildIndex(this.monthCalendar1, 0);
            this.Controls.SetChildIndex(this.buttonHamburger, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label News;
        private System.Windows.Forms.Label PlanningJournée;
        private System.Windows.Forms.Label Notes;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}