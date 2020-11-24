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
    public partial class Primo_Scenario : UserControl
    {
        public Main parentForm { get; set; }
        public Primo_Scenario()
        {
            InitializeComponent();
            //this.BackgroundImage = Properties.Resources.bed2;
            // this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        public void setPos(int w, int h)
        {

            int offset = 0;
            Location = new Point(offset, offset);
            Width = w - 1 * offset;
            Height = h - 1 * offset;

        }
        public void setMessage_ps(string bt_text)
        {
            Visible = true;
            if (bt_text.Length > 0)
            {
   
                Start.Visible = true;
                Start.Select();
            }
            else
            {
                Start.Text = "";
                Start.Visible = false;
            }
        }
        private void Alarm_Click(object sender, EventArgs e)
        {

        }

        private void Primo_Scenario_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
           parentForm.closeMessage();
        }

        private void Alarm_Click_1(object sender, EventArgs e)
        {
            parentForm.playbackResourceAudio("Alarm_sound");
        }
    }
}
