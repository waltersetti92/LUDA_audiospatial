using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using Newtonsoft.Json;
using System.Threading;


namespace Audiospatial
{
    public delegate void ResumeFromMessage();
    public partial class Main : Form
    {
        public static readonly string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        
        public static readonly string resourcesPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources";
        public static readonly string resultsDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\results";
        private const string background_image = "Buco_Nero.jpg";
        private const string activities_json = "activities.json";
        //private readonly ActivityMathSpatialAudio activity;
        //private readonly Activities activitiesList;
        private UserControl currUC = null;
        public SoundPlayer player = null;
        public static readonly int N_SPEAKERS = 3;
        public static readonly bool IS_DEBUG = false;
        private int iDifficulty = 0;
        ResumeFromMessage message_callback = null;
        public Speakers speakers = null;
        public Main()
        {
            speakers = new Speakers();
            Business_Logic BL = new Business_Logic(this);
            InitializeComponent();       //commit1         
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image);
            initial1.parentForm = this;
            activityUdaUC1.parentForm = this;

           
            initial1.Visible = false;
            activityUdaUC1.Visible = false;
            home();
        }
        public void Status_Changed(string k)
        {
            this.BeginInvoke((Action)delegate ()
            {
                int status = int.Parse(k);
                if (status == 1)
                {
                    onStart();
                }
                if (status == 2)
                {
                    home();
                }

            });
        }
        public void home()
        {
            if (currUC != null) currUC.Visible = false;
            initial1.Show();
            currUC = initial1;
        }
        public void onStart()
        {
            initial1.Visible = false;
            activityUdaUC1.Visible = true;
            currUC = activityUdaUC1;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Size size = this.Size;
            initial1.setPos(size.Width, size.Height);
            activityUdaUC1.setPos(size.Width, size.Height);

        }

        private void initial1_Load(object sender, EventArgs e)
        {

        }
    }
}
