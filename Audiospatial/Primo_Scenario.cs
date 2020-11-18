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
            this.BackgroundImage = Properties.Resources.bed4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void Alarm_Click(object sender, EventArgs e)
        {

        }

        private void Primo_Scenario_Load(object sender, EventArgs e)
        {

        }
    }
}
