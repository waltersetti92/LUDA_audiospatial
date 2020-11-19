namespace Audiospatial
{
    partial class debugInfo
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
            this.labCurrNumber = new System.Windows.Forms.Label();
            this.labDebugOperation = new System.Windows.Forms.Label();
            this.labDebugNewNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labDebugResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labCurrNumber
            // 
            this.labCurrNumber.AutoSize = true;
            this.labCurrNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCurrNumber.Location = new System.Drawing.Point(3, 0);
            this.labCurrNumber.Name = "labCurrNumber";
            this.labCurrNumber.Size = new System.Drawing.Size(55, 39);
            this.labCurrNumber.TabIndex = 14;
            this.labCurrNumber.Text = "00";
            // 
            // labDebugOperation
            // 
            this.labDebugOperation.AutoSize = true;
            this.labDebugOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDebugOperation.Location = new System.Drawing.Point(52, 0);
            this.labDebugOperation.Name = "labDebugOperation";
            this.labDebugOperation.Size = new System.Drawing.Size(55, 39);
            this.labDebugOperation.TabIndex = 15;
            this.labDebugOperation.Text = "00";
            // 
            // labDebugNewNumber
            // 
            this.labDebugNewNumber.AutoSize = true;
            this.labDebugNewNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDebugNewNumber.Location = new System.Drawing.Point(101, 1);
            this.labDebugNewNumber.Name = "labDebugNewNumber";
            this.labDebugNewNumber.Size = new System.Drawing.Size(55, 39);
            this.labDebugNewNumber.TabIndex = 16;
            this.labDebugNewNumber.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 39);
            this.label1.TabIndex = 17;
            this.label1.Text = "=";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labDebugResult
            // 
            this.labDebugResult.AutoSize = true;
            this.labDebugResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDebugResult.Location = new System.Drawing.Point(195, 0);
            this.labDebugResult.Name = "labDebugResult";
            this.labDebugResult.Size = new System.Drawing.Size(55, 39);
            this.labDebugResult.TabIndex = 18;
            this.labDebugResult.Text = "00";
            // 
            // debugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labDebugResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labDebugNewNumber);
            this.Controls.Add(this.labDebugOperation);
            this.Controls.Add(this.labCurrNumber);
            this.Name = "debugInfo";
            this.Size = new System.Drawing.Size(260, 40);
            this.Load += new System.EventHandler(this.debugInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labCurrNumber;
        private System.Windows.Forms.Label labDebugOperation;
        private System.Windows.Forms.Label labDebugNewNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labDebugResult;
    }
}
