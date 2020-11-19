using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audiospatial
{
    public partial class AnswerUC : UserControl
    {
        public Main parentForm { get; set; }
        private int iDifficulty = 0;
        public AnswerUC()
        {
            InitializeComponent();
        }
        public void setPos(int w, int h)
        {
            Location = new Point(w / 2 - Width / 2, h / 2 - Height / 2);
        }
        internal void show(int diff = 0)
        {
            iDifficulty = diff;
            Visible = true;
            txtResult.Text = "";
            txtResult.Select();
        }
        private void txtResult_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (txtResult.Text.Length > 0)
                    parentForm.onAnswer(txtResult.Text);
            }
        }

        private string representNumber(int number)
        {
            if (number == -1) return "";

          return number.ToString();
        }


        private void AnswerUC_Load(object sender, EventArgs e)
        {

        }

        private void btAnswer_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
                parentForm.onAnswer(txtResult.Text);
        }
    }
}
