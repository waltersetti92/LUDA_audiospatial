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
    public partial class ActivityUdaUC : UserControl
    {
        public Main parentForm { get; set; }
        public ActivityUdaUC()
        {
            InitializeComponent();
            cmbDifficulty.Items.Add(new ComboBoxItem("Facile", 0));
            cmbDifficulty.Items.Add(new ComboBoxItem("Medio", 1));
            cmbDifficulty.Items.Add(new ComboBoxItem("Difficile", 2));
            cmbDifficulty.SelectedIndex = 0;

            cmbParticipants.Items.Add(1);
            cmbParticipants.Items.Add(2);
            cmbParticipants.Items.Add(3);
            cmbParticipants.Items.Add(4);
            cmbParticipants.Items.Add(5);
            cmbParticipants.Items.Add(6);
            cmbParticipants.Items.Add(7);
            cmbParticipants.Items.Add(8);
            cmbParticipants.Items.Add(9);
            cmbParticipants.Items.Add(10);
            cmbParticipants.SelectedIndex = 4;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void setPos(int w, int h)
        {
            Location = new Point(w / 2 - Width / 2, h / 2 - Height / 2);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Visible = false;
            parentForm.home();
        }
    }
    class ComboBoxItem
    {
        public string Name;
        public int Value;
        public ComboBoxItem(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
