﻿using System;
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
            //this.BackgroundImage = Properties.Resources.trafficjam;
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
        private void Secondo_Scenario_Load(object sender, EventArgs e)
        {

        }

        private void Alarm_Click(object sender, EventArgs e)
        {
            parentForm.playbackResourceAudio("10");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            parentForm.closeMessage();
        }
    }
}
