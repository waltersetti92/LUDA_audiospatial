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
    public partial class Secondo_Scenario : UserControl
    {
        public Main parentForm { get; set; }
        public Secondo_Scenario()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.traffic2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        public void setPos(int w, int h)
        {

            int offset = 0;
            Location = new Point(offset, offset);
            Width = w - 1 * offset;
            Height = h - 1 * offset;

        }

        private void Secondo_Scenario_Load(object sender, EventArgs e)
        {

        }

        private void Alarm_Click(object sender, EventArgs e)
        {
            parentForm.playbackResourceAudio("10");
        }
    }
}
