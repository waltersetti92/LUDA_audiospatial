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
    public partial class MessageUC : UserControl
    {
        public Main parentForm { get; set; }
        public ActivityUdaUC parentForm1 { get; set; }
        public int index;
        public MessageUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
        }
        public int setMessage(string msg, string bt_text, int i)
        {
            Visible = true;
            label.Text = msg;

            label.Location = new Point(Width / 2 - label.Width / 2, Height / 2 - label.Height / 2);

            if (bt_text.Length > 0)
            {
                btClose.Text = bt_text;
                btClose.Visible = true;
                btClose.Select();
            }
            else
            {
                btClose.Text = "";
                btClose.Visible = false;
            }
            index = i;
            return index;
        }
        public void setPos(int w, int h)
        {
            Width = w;
            Height = h;
            Location = new Point(0, 0);
            btClose.Location = new Point(Width / 2 - btClose.Width / 2, Height / 2 + btClose.Height);
        }
        private void label_Click(object sender, EventArgs e)
        {

        }
        private void onKeyPress(object sender, KeyPressEventArgs e)
        {

            parentForm.closeMessage();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            parentForm.messaggio = 2;
            parentForm.onStartActivity1(0, 0, 1, "1");
         // parentForm.closeMessage1();

        }

        private void MessageUC_Load(object sender, EventArgs e)
        {

        }
    }
}
