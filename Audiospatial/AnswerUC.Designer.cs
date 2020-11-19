namespace Audiospatial
{
    partial class AnswerUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btAnswer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(14, 61);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(135, 52);
            this.txtResult.TabIndex = 9;
            // 
            // btAnswer
            // 
            this.btAnswer.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnswer.Location = new System.Drawing.Point(165, 61);
            this.btAnswer.Name = "btAnswer";
            this.btAnswer.Size = new System.Drawing.Size(273, 52);
            this.btAnswer.TabIndex = 10;
            this.btAnswer.Text = "RISPONDI";
            this.btAnswer.UseVisualStyleBackColor = true;
            this.btAnswer.Click += new System.EventHandler(this.btAnswer_Click);
            // 
            // AnswerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btAnswer);
            this.Controls.Add(this.txtResult);
            this.Name = "AnswerUC";
            this.Size = new System.Drawing.Size(451, 140);
            this.Load += new System.EventHandler(this.AnswerUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btAnswer;
    }
}
