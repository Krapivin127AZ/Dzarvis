using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;




namespace Dzarvis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static Label l;

        public static void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.8) l.Text = e.Result.Text;
            
        }

        public void Form1_Shown(object sender, EventArgs e)
        {
            
            l = label;

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-Ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Sre_SpeechRecognized);


            Choices Command = new Choices();
            Command.Add(new string[] { "Привет" });


            GrammarBuilder gb = new GrammarBuilder();
            //gb.Culture = ci;
            gb.Append(Command);


            if(label.Text == "Привет")
            {
                //Тут будет аудио
            }


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Multiple);
        }


    }

}
