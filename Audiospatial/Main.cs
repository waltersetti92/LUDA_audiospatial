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
        private const string background_image_stanza = "bed4.jpg";
        private const string activities_json = "activities.json";
        private readonly ActivityMathSpatialAudio activity;
        private readonly Activities activitiesList;
        private UserControl currUC = null;
        private UserControl currUC1 = null;
        public SoundPlayer player = null;
        public static readonly int N_SPEAKERS = 3;
        public static readonly bool IS_DEBUG = false;
        public int counter_form;

        private int iDifficulty = 0;
        ResumeFromMessage message_callback = null;
        public Speakers speakers = null;
        public Main()
        {
            counter_form = 1;
            speakers = new Speakers();
            Business_Logic BL = new Business_Logic(this);
            InitializeComponent();       //commit1                  
            initial1.parentForm = this;
            activityUdaUC1.parentForm = this;
            primo_Scenario1.parentForm = this;
            debugInfo1.parentForm = this;
            answerUC1.parentForm = this;
            activity_Stanza1.parentForm = this;
            secondo_Scenario1.parentForm = this;
            messageUC1.parentForm = this;
            initial1.Visible = false;
            activityUdaUC1.Visible = false;
            primo_Scenario1.Visible = false;
            debugInfo1.Visible = false;
            answerUC1.Visible = false;
            activity_Stanza1.Visible = false;
            messageUC1.Visible = false;
            secondo_Scenario1.Visible = false;
            home();
           BackgroundImageLayout = ImageLayout.Stretch;
           BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image);

            activitiesList = readActivitiesList();
            activity = new ActivityMathSpatialAudio(activitiesList, this, speakers, activity_Stanza1, debugInfo1);
        }
        private Activities readActivitiesList()
        {
            /*var jsonString = @"{""items"":[[{""difficulty"":2, ""id"":1, ""operands"":[1,2,3,4], ""operations"":[0,1,2]}, {""difficulty"":0, ""id"":2, ""operands"":[1,2,3,4], ""operations"":[0,1,2]}]]}";*/
            using (StreamReader file = File.OpenText(resourcesPath + "\\" + activities_json))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (Activities)serializer.Deserialize(file, typeof(Activities));
            }
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
        public void traffic()
        {
            if (currUC != null) currUC.Visible = false;
            secondo_Scenario1.Show();
            currUC1 = secondo_Scenario1;
            counter_form++;
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
            primo_Scenario1.setPos(size.Width, size.Height);
            answerUC1.setPos(size.Width, size.Height);
            activity_Stanza1.setPos(size.Width, size.Height);
            messageUC1.setPos(size.Width, size.Height);
            secondo_Scenario1.setPos(size.Width, size.Height);
        }
        public void onStartActivity(int level, int type, int num_participants, string group)
        {
            activityUdaUC1.Visible = false;
            primo_Scenario1.Visible = true;

            iDifficulty = level;

           if (Main.IS_DEBUG == true) debugInfo1.Visible = true;
           else debugInfo1.Visible = false;

            currUC = activity_Stanza1;
            currUC1 = secondo_Scenario1;

            activity.init(level, type, num_participants, group);
        }
        public void closeMessage()
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image_stanza);
            primo_Scenario1.Visible = false;
            //currUC.Visible = true;
             secondo_Scenario1.Visible = true;
            message_callback?.Invoke();
        }
        public void closeMessage1()
        {
            messageUC1.Visible = false;
            secondo_Scenario1.Visible = true;
            message_callback?.Invoke();
            counter_form++;
        }
        public void onAnswer(string result)
        {
            answerUC1.Visible = false;
            if (activity.isCorrect(Int32.Parse(result))) playbackResourceAudio("success");
            else playbackResourceAudio("failure");

            Thread.Sleep(2000);
            activity.nextOperand();
            currUC = activity_Stanza1;
        }
        public void onEndActivities()
        {
            currUC.Visible = false;
            messageUC1.setMessage("Complimenti !!! Avete svegliato Hinrik! Ora corriamo all'aeroporto", "continua",counter_form);
            message_callback = traffic;
        }
        public void showMessage(string msg, string bt_text, ResumeFromMessage clb = null)
        {
            currUC.Visible = false;
            message_callback = clb;
            primo_Scenario1.setMessage_ps(bt_text);
        }
        public void onCountDownEnd()
        {
            activity_Stanza1.Visible = false;
            debugInfo1.Visible = false;

            answerUC1.show(iDifficulty);
            answerUC1.Visible = true;
            currUC = answerUC1;
        }
        public void playbackResourceAudio(string audioname)
        {

            string s = resourcesPath + "\\" + audioname + ".wav";
            player = new SoundPlayer(s);
            player.Play();
        }

        private void initial1_Load(object sender, EventArgs e)
        {

        }
    }
}
