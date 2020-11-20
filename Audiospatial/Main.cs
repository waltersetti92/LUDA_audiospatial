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
        private const string background_image_trafficjam = "traffic3.jpg";
        private const string background_image_plane = "plan2.jpg";
        private const string activities_json = "activities.json";
        private readonly ActivityMathSpatialAudio activity;
        private readonly Activities activitiesList;
        private UserControl currUC = null;
        private UserControl currUC1 = null;
        public SoundPlayer player = null;
        public static readonly int N_SPEAKERS = 3;
        public static readonly bool IS_DEBUG = false;
        public int onactivity;
        public int messaggio;
        public int participants;
        public int iDifficulty = 0;
        public int scenario;
        ResumeFromMessage message_callback = null;
        public Speakers speakers = null;
        public Main()
        {
            onactivity = 1;
            messaggio = 1;
            scenario = 1;
            participants = 0;
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
            terzo_Scenario1.parentForm = this;
            initial1.Visible = false;
            activityUdaUC1.Visible = false;
            primo_Scenario1.Visible = false;
            debugInfo1.Visible = false;
            answerUC1.Visible = false;
            activity_Stanza1.Visible = false;
            messageUC1.Visible = false;
            secondo_Scenario1.Visible = false;
            terzo_Scenario1.Visible = false;
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
        public void scenes()
        {
            if (currUC != null) currUC.Visible = false;
            if (onactivity == 2)
            {
                secondo_Scenario1.Show();
                currUC1 = secondo_Scenario1;
            }
            else if (onactivity == 3)
            {
                terzo_Scenario1.Show();
                currUC1 = terzo_Scenario1;
            }

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
            terzo_Scenario1.setPos(size.Width, size.Height);
        }
        public void onStartActivity(int level, int type, int num_participants, string group)
        {
            if (onactivity==1)
            {
                activityUdaUC1.Visible = false;
                primo_Scenario1.Visible = true;
            }
           else if (onactivity == 2)
            {
                messageUC1.Visible = false;
                secondo_Scenario1.Visible = true;
            }
            else if (onactivity == 3)
            {
                messageUC1.Visible = false;
                terzo_Scenario1.Visible = true;
            }

            iDifficulty = level;
            participants = num_participants;

           if (Main.IS_DEBUG == true) debugInfo1.Visible = true;
           else debugInfo1.Visible = false;

            currUC = activity_Stanza1;
            onactivity++;

            activity.init(level, type, num_participants, group);
        }
        public void closeMessage()
        {
            if (onactivity == 2)
            {
                BackgroundImageLayout = ImageLayout.Stretch;
                BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image_stanza);
                primo_Scenario1.Visible = false;
            }
            else if (onactivity == 3)
            {
                BackgroundImageLayout = ImageLayout.Stretch;
                BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image_trafficjam);
                secondo_Scenario1.Visible = false;
            }
            else if (onactivity == 4)
            {
                BackgroundImageLayout = ImageLayout.Stretch;
                BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image_plane);
                terzo_Scenario1.Visible = false;
            }
            currUC.Visible = true;
            message_callback?.Invoke();
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
            if (onactivity == 2)
            {
                messageUC1.setMessage("Complimenti !!! Avete svegliato Hinrik! Ora corriamo all'aeroporto!", "continua");                
            }
            else if (onactivity == 3)
            {
                messageUC1.setMessage("Complimenti !!! Siete arrivati all'aeroporto! Saliamo sull'aereo e partiamo!", "continua");
            }
            message_callback = scenes;
        }
        public void showMessage(string msg, string bt_text, ResumeFromMessage clb = null)
        {
            currUC.Visible = false;
            message_callback = clb;
            if (messaggio == 1)
                primo_Scenario1.setMessage_ps(bt_text);
            else if (messaggio==2)
                secondo_Scenario1.setMessage_ps(bt_text);
            else if (messaggio == 3)
                terzo_Scenario1.setMessage_ps(bt_text);
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
