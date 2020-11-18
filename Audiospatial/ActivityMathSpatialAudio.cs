using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;


namespace Audiospatial
{
    class ActivityMathSpatialAudio
    {
        private readonly Main form;
        private readonly Speakers speakers;
        private readonly debugInfo debug;
        private readonly Activities available_activities;
        private SingleActivity currActivity;
        private SingleActivity[] chosenActivities;

        private int iDifficultyLevel = 0;
        private int iType = 0;
        private int iParticipants = 5;
        private string group = "";

        private ActivityResult results;
        private static readonly string[] speaker_labels = new string[] { "02", "03", "04" };     // west, north, east

        private static readonly string[] operations_symbols = new string[] { "dog", "cat", "lion", "chewbacca" };
        private static readonly string[] operations_labels = new string[] { "+", "-", "x", "/" };
        private readonly List<string> currOperationsLabels = new List<string>(); // displayed labels of the operations
        private readonly List<string> currOperationsSymbols = new List<string>(); // displayed symbols of the operations

        private static System.Windows.Forms.Timer aTimer;
        private const string TAG_SOUND = "sound";   // identifier of the type of active timer
        private const string TAG_TIMER = "timer";

        public static int N_TYPE_SPATIAL = 0;

        private const int N_OP_PLUS = 0;
        private const int N_OP_SUBTRACT = 1;
        private const int N_OP_MULT = 2;
        private const int N_OP_DIVISION = 3;

        private const int sound_interval = 1500;
        private const int timer_interval = 1000;


        private readonly static int[] answerTime = new int[3] { 5, 5, 5 };

        private int currParticipant = -1;   // index of the current participant [0 -> activity's NOP]
        private int currOp = -1;   // index of the current operation [0 -> activity's NOP]
        private int totOps = -1;   // tot number of operation for each participant

        private int currSpeaker = 0;    // speaker used by current operation [0,1,2]
        private int currOperator = 0;    // which operator is applied in the currSpeaker/currOp [0,1,2,3]
        private int currOperand = 0;    // which number reproduce [1->X]

        private int currResult = 0;    // results of the current operation
        private string currResultFile = "";   // fullpath of the current results file

        private int currSound = 0;    // num of sound reproduced [1->currOperand]

        private int elapsedTime = 0;
        

    }
    public class SingleActivity
    {
        public int id { get; set; }
        public int difficulty { get; set; }
        public int start_number { get; set; }

        public int[] speaker { get; set; }      // [NOP] : define which speaker must play
                                                // following the speaker_labels      = new string[] { "02", "03", "04"};
                                                //                                          => 0: west, 1: north, 2: east

        public int[] operands { get; set; }     // [NOP] : define which numbers must be manipulated
        public int[] operations { get; set; }   // [3] : define which operation stand in each of the three speaker ( +,-,*,/)
                                                // used to fill:  foreach (int op in currActivity.operations) currOperationsLabels.Add(operations_labels[op]);
    }

    class Activities
    {
        public List<List<SingleActivity>> items { get; set; }
    }
    class ActivityResult
    {
        public int difficulty { get; set; }
        public int type { get; set; }
        public int participant_id { get; set; }
        public string group { get; set; }
        public DateTime date { get; set; }
        public int activity_id { get; set; }
        public bool[] results { get; set; }

        public string getFileName()
        {
            return "results_" + date.ToString("yyyyMMdd_HHmmss") + "_" + type.ToString() + "_" + group + "_" + participant_id.ToString() + "_" + difficulty.ToString() + "_" + activity_id.ToString() + ".json";
        }

    }
}
