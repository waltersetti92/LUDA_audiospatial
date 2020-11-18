namespace Audiospatial
{
    partial class Main
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
            this.initial1 = new Audiospatial.Initial();
            this.activityUdaUC1 = new Audiospatial.ActivityUdaUC();
            this.SuspendLayout();
            // 
            // initial1
            // 
            this.initial1.BackColor = System.Drawing.Color.Transparent;
            this.initial1.Location = new System.Drawing.Point(-6, -1);
            this.initial1.Name = "initial1";
            this.initial1.parentForm = null;
            this.initial1.Size = new System.Drawing.Size(785, 328);
            this.initial1.TabIndex = 0;
            this.initial1.Load += new System.EventHandler(this.initial1_Load);
            // 
            // activityUdaUC1
            // 
            this.activityUdaUC1.Location = new System.Drawing.Point(8, 4);
            this.activityUdaUC1.Name = "activityUdaUC1";
            this.activityUdaUC1.parentForm = null;
            this.activityUdaUC1.Size = new System.Drawing.Size(609, 309);
            this.activityUdaUC1.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.activityUdaUC1);
            this.Controls.Add(this.initial1);
            this.Name = "Main";
            this.Text = "Postazione AudioSpaziale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Initial initial1;
        private ActivityUdaUC activityUdaUC1;
    }
}

