using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace StageControl
{
   
    public partial class StageControl : Form

    {
        Stages stages = new Stages();

        public StageControl()
        {
            InitializeComponent();
            stages.init();
            stages.LinRe.Home(0);
            stages.LinLi.Home(0);

            //Wait for stages to get some distance
            Thread.Sleep(20000);

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(40, 40);
            stages.LinRe.SetVelocityParams(40, 40);

            //No Backlash
            stages.LinLi.SetBacklash(0);
            stages.LinRe.SetBacklash(0);

            //Home Vergenzwinkel
            stages.RotLi.SetVelocityParams(100, 100);
            stages.RotRe.SetVelocityParams(100, 100);
            stages.RotLi.Home(0);
            stages.RotRe.Home(0);

            //in Textboxen schreiben
            string Zerostring = Convert.ToString(0);
            string sixnine = Convert.ToString(69);
            textBox3.Clear();
            textBox3.AppendText(Zerostring);
            textBox2.Clear();
            textBox2.AppendText(Zerostring);
            textBox1.Clear();
            textBox1.AppendText(Zerostring);
            textBox4.Clear();
            textBox4.AppendText(Zerostring);
            textBox6.Clear();
            textBox6.AppendText(sixnine);
            textBox5.Clear();
            textBox5.AppendText(Zerostring);
        }

        //Section1 Vergenzwinkel ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Home Button Vergenzwinkel ------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {

            //Bring Stages in a save Position
            stages.LinLi.MoveTo(0, 0);
            stages.LinRe.MoveTo(0, 8000);

            //Home Vergenzwinkel
            stages.RotLi.Home(0);
            stages.RotRe.Home(0);

            //in Textboxen schreiben
            string Zerostring = Convert.ToString(0);
            string sixnine = Convert.ToString(69);
            textBox3.Clear();
            textBox3.AppendText(Zerostring);
            textBox2.Clear();
            textBox2.AppendText(Zerostring);
            textBox1.Clear();
            textBox1.AppendText(Zerostring);
            textBox4.Clear();
            textBox4.AppendText(Zerostring);
            textBox6.Clear();
            textBox6.AppendText(sixnine);
        }

        //Textbox2 Vergenzwinkel ------------------------------------------------------------
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {

                //Inhalt der Textbox2 Vergenzwinkel als double j
                double j = 0;
                if (!double.TryParse(textBox2.Text, out j))
                {
                    j = -1;
                }

                //Maximum des Vergenzwinkels
                if (j > 5)
                {
                    j = 5;
                    textBox2.Clear();
                    string jmax = Convert.ToString(j);
                    textBox2.AppendText(jmax);
                }

                //Minimum des Vergenzwinkels
                if (j < 0)
                {
                    j = 0;
                    textBox2.Clear();
                    string jmax = Convert.ToString(j);
                    textBox2.AppendText(jmax);
                }

                //Definitionen und Formeln
                double Vergenzwinkel = j;
                decimal Vergenzwinkeldecimal = Convert.ToDecimal(Vergenzwinkel);

                //Bewegungsbefehle Rotation
                stages.RotLi.SetVelocityParams(1, 40);
                stages.RotRe.SetVelocityParams(1, 40);
                stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
                stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

                //Inhalt der Textbox3 Stageposition als double k
                double k = 0;
                if (!double.TryParse(textBox3.Text, out k))
                {
                    k = -1;
                }

                //Definitionen und Formeln
                double Distanz = 150;
                double Augenradius = 9.9;
                double AbstSpiegelLinse = 45;
                double VergenzwinkelRad = Vergenzwinkel * 2 * Math.PI / 360;
                double B = Math.Sin(VergenzwinkelRad) * (Distanz - k - AbstSpiegelLinse + Augenradius);
                decimal Positionsoffset = Convert.ToDecimal(Math.Round(B,2));
                string Positionsoffsetstring = Convert.ToString(Positionsoffset);

                //vorherige Positionskorrektur aus Textbox5 auslesen
                double d = 0;
                if (!double.TryParse(textBox5.Text, out d))
                {
                    d = -1;
                }

                //Unkorrigierte Position
                double P0 = k - d;

                //Neue Korrigierte Position
                decimal P1 = Convert.ToDecimal(P0) + Positionsoffset;

                //Maximum der Stageposition
                if (P1 > 14)
                {
                    P1 = 14;
                }

                //Minimum der Stageposition
                if (P1 < 0)
                {
                    P1 = 0;
                }

                //Bewegungsbefehle für lineare Stages
                stages.LinLi.MoveTo(P1, 0);
                stages.LinRe.MoveTo(P1, 0);

                //in Textboxen schreiben
                string P1string = Convert.ToString(P1);
                string A1string = Convert.ToString(2 * (34.5 - Convert.ToDouble(P1)));
                textBox5.Clear();
                textBox5.AppendText(Positionsoffsetstring);
                textBox3.Clear();
                textBox3.AppendText(P1string);
                textBox1.Clear();
                textBox1.AppendText(P1string);
                textBox4.Clear();
                textBox4.AppendText(P1string);
                textBox6.Clear();
                textBox6.AppendText(A1string);
            }
        }

        //Vergenzwinkel +1 ------------------------------------------------------------
        private void button7_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox2 Vergenzwinkel als double j
            double j = 0;
            if (!double.TryParse(textBox2.Text, out j))
            {
                j = -1;
            }
            
            //Definitionen und Formeln
            double V = j + 1;

            //Maximum des Vergenzwinkels
            if (V > 5)
            {
                V = 5;
            }

            //Minimum des Vergenzwinkels
            if (V < 0)
            {
                V = 0;
            }

            //Definitionen und Formeln
            decimal Vdecimal = Convert.ToDecimal(V);
            string Vstring = Convert.ToString(V);

            //Bewegungsbefehle Rotation
            stages.RotLi.SetVelocityParams(1, 40);
            stages.RotRe.SetVelocityParams(1, 40);
            stages.RotLi.MoveTo(Vdecimal / 2, 0);
            stages.RotRe.MoveTo(360 - Vdecimal / 2, 0);

            //Inhalt der Textbox3 Stageposition als double k
            double k = 0;
            if (!double.TryParse(textBox3.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double Distanz = 150;
            double Augenradius = 9.9;
            double AbstSpiegelLinse = 45;
            double VergenzwinkelRad = V * 2 * Math.PI / 360;
            double B = Math.Sin(VergenzwinkelRad) * (Distanz - k - AbstSpiegelLinse + Augenradius);
            decimal Positionsoffset = Convert.ToDecimal(Math.Round(B, 2));
            string Positionsoffsetstring = Convert.ToString(Positionsoffset);

            //vorherige Positionskorrektur aus Textbox5 auslesen
            double d = 0;
            if (!double.TryParse(textBox5.Text, out d))
            {
                d = -1;
            }

            //Unkorrigierte Position
            double P0 = k - d;

            //Neue Korrigierte Position
            decimal P1 = Convert.ToDecimal(P0) + Positionsoffset;

            //Maximum der Stageposition
            if (P1 > 14)
            {
                P1 = 14;
            }

            //Minimum der Stageposition
            if (P1 < 0)
            {
                P1 = 0;
            }

            //Bewegungsbefehle für lineare Stages
            stages.LinLi.MoveTo(P1, 0);
            stages.LinRe.MoveTo(P1, 0);

            //in Textboxen schreiben
            string P1string = Convert.ToString(P1);
            string A1string = Convert.ToString(2 * (34.5 - Convert.ToDouble(P1)));
            textBox5.Clear();
            textBox5.AppendText(Positionsoffsetstring);
            textBox3.Clear();
            textBox3.AppendText(P1string);
            textBox1.Clear();
            textBox1.AppendText(P1string);
            textBox4.Clear();
            textBox4.AppendText(P1string);
            textBox6.Clear();
            textBox6.AppendText(A1string);
            textBox2.Clear();
            textBox2.AppendText(Vstring);
        }

        //Vergenzwinkel -1 ------------------------------------------------------------
        private void button8_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox2 Vergenzwinkel als double j
            double j = 0;
            if (!double.TryParse(textBox2.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            double V = j - 1;

            //Maximum des Vergenzwinkels
            if (V > 5)
            {
                V = 5;
            }

            //Minimum des Vergenzwinkels
            if (V < 0)
            {
                V = 0;
            }

            //Definitionen und Formeln
            decimal Vdecimal = Convert.ToDecimal(V);
            string Vstring = Convert.ToString(V);

            //Bewegungsbefehle Rotation
            stages.RotLi.SetVelocityParams(1, 40);
            stages.RotRe.SetVelocityParams(1, 40);
            stages.RotLi.MoveTo(Vdecimal / 2, 0);
            stages.RotRe.MoveTo(360 - Vdecimal / 2, 0);

            //Inhalt der Textbox3 Stageposition als double k
            double k = 0;
            if (!double.TryParse(textBox3.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double Distanz = 150;
            double Augenradius = 9.9;
            double AbstSpiegelLinse = 45;
            double VergenzwinkelRad = V * 2 * Math.PI / 360;
            double B = Math.Sin(VergenzwinkelRad) * (Distanz - k - AbstSpiegelLinse + Augenradius);
            decimal Positionsoffset = Convert.ToDecimal(Math.Round(B, 2));
            string Positionsoffsetstring = Convert.ToString(Positionsoffset);

            //vorherige Positionskorrektur aus Textbox5 auslesen
            double d = 0;
            if (!double.TryParse(textBox5.Text, out d))
            {
                d = -1;
            }

            //Unkorrigierte Position
            double P0 = k - d;

            //Neue Korrigierte Position
            decimal P1 = Convert.ToDecimal(P0) + Positionsoffset;

            //Maximum der Stageposition
            if (P1 > 14)
            {
                P1 = 14;
            }

            //Minimum der Stageposition
            if (P1 < 0)
            {
                P1 = 0;
            }

            //Bewegungsbefehle für lineare Stages
            stages.LinLi.MoveTo(P1, 0);
            stages.LinRe.MoveTo(P1, 0);

            //in Textboxen schreiben
            string P1string = Convert.ToString(P1);
            string A1string = Convert.ToString(2 * (34.5 - Convert.ToDouble(P1)));
            textBox5.Clear();
            textBox5.AppendText(Positionsoffsetstring);
            textBox3.Clear();
            textBox3.AppendText(P1string);
            textBox1.Clear();
            textBox1.AppendText(P1string);
            textBox4.Clear();
            textBox4.AppendText(P1string);
            textBox6.Clear();
            textBox6.AppendText(A1string);
            textBox2.Clear();
            textBox2.AppendText(Vstring);
        }

        //Section2 Stageposition ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Homebutton Stageposition ------------------------------------------------------------
        private void button13_Click(object sender, EventArgs e)
        {
            //Bewegungsbefehle
            stages.LinLi.MoveTo(0, 0);
            stages.LinRe.MoveTo(0, 0);

            //in Textboxen schreiben
            decimal zero = 0;
            decimal sixnine = 69;
            string stringzero = Convert.ToString(zero);
            string stringsixnine = Convert.ToString(sixnine);
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox6.AppendText(stringsixnine);
            textBox3.AppendText(stringzero);
            textBox1.AppendText(stringzero);
            textBox4.AppendText(stringzero);
        }

        //Stageposition Textbox3 ------------------------------------------------------------
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Inhalt der Textbox als int k
                double k = 0;
                if (!double.TryParse(textBox3.Text, out k))
                {
                    k = -1;
                }

                //Maximum der Stageposition
                if (k > 14)
                {
                    k = 14;
                    textBox3.Clear();
                    string imax = Convert.ToString(k);
                    textBox3.AppendText(imax);
                }

                //Minimum der Stageposition
                if (k < 0)
                {
                    k = 0;
                    textBox3.Clear();
                    string imin = Convert.ToString(k);
                    textBox3.AppendText(imin);
                }

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);
                double Augenabstand = 2 * (34.5 - k);
                string stringA = Convert.ToString(Augenabstand);
                string stringk = Convert.ToString(k);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Stageposition, 0);
                stages.LinRe.MoveTo(Stageposition, 0);

                //in Textboxen schreiben
                textBox1.Clear();
                textBox4.Clear();
                textBox6.Clear();
                textBox6.AppendText(stringA);
                textBox1.AppendText(stringk);
                textBox4.AppendText(stringk);
            }
        }
                
        //Stageposition +0.1 Textbox3 ------------------------------------------------------------
        private void button9_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
            double k = 0;
            if (!double.TryParse(textBox3.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k + 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox3.Clear();
                string imax = Convert.ToString(kNew);
                textBox3.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox3.Clear();
                string imin = Convert.ToString(kNew);
                textBox3.AppendText(imin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = 2 * (34.5 - kNew);
            string stringA = Convert.ToString(Augenabstand);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox6.AppendText(stringA);
            textBox1.AppendText(kNewString);
            textBox4.AppendText(kNewString);
            textBox3.AppendText(kNewString);
        }

        //Stageposition -0.1 Textbox3 ------------------------------------------------------------
        private void button10_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
            double k = 0;
            if (!double.TryParse(textBox3.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k - 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox3.Clear();
                string imax = Convert.ToString(kNew);
                textBox3.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox3.Clear();
                string imin = Convert.ToString(kNew);
                textBox3.AppendText(imin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = 2 * (34.5 - kNew);
            string stringA = Convert.ToString(Augenabstand);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox6.AppendText(stringA);
            textBox1.AppendText(kNewString);
            textBox4.AppendText(kNewString);
            textBox3.AppendText(kNewString);
        }

        //Stageposition +1 Textbox3 ------------------------------------------------------------
        private void button12_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
            double k = 0;
            if (!double.TryParse(textBox3.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k + 1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox3.Clear();
                string imax = Convert.ToString(kNew);
                textBox3.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox3.Clear();
                string imin = Convert.ToString(kNew);
                textBox3.AppendText(imin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = 2 * (34.5 - kNew);
            string stringA = Convert.ToString(Augenabstand);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox6.AppendText(stringA);
            textBox1.AppendText(kNewString);
            textBox4.AppendText(kNewString);
            textBox3.AppendText(kNewString);
        }

        //Stageposition -1 Textbox3 ------------------------------------------------------------
        private void button11_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
            double k = 0;
            if (!double.TryParse(textBox3.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k - 1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox3.Clear();
                string imax = Convert.ToString(kNew);
                textBox3.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox3.Clear();
                string imin = Convert.ToString(kNew);
                textBox3.AppendText(imin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = 2 * (34.5 - kNew);
            string stringA = Convert.ToString(Augenabstand);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox6.AppendText(stringA);
            textBox1.AppendText(kNewString);
            textBox4.AppendText(kNewString);
            textBox3.AppendText(kNewString);
        }

        //Section3 einzelne Stagepositionen ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Textbox1 Position LinLi -----------------------------------------------------------------
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Inhalt der Textbox1 (links) als double k
                double k = 0;
                if (!double.TryParse(textBox1.Text, out k))
                {
                    k = -1;
                }

                //Maximum des Augenabstandes
                if (k > 14)
                {
                    k = 14;
                    textBox1.Clear();
                    string imax = Convert.ToString(k);
                    textBox1.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (k < 0)
                {
                    k = 0;
                    textBox1.Clear();
                    string imin = Convert.ToString(k);
                    textBox1.AppendText(imin);
                }

                //Inhalt der Textbox4 (rechts) als double j
                double j = 0;
                if (!double.TryParse(textBox4.Text, out j))
                {
                    j = -1;
                }

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);
                double Augenabstand = (2 * (34.5 - k) + 2 * (34.5 - j)) / 2;
                string stringA = Convert.ToString(Augenabstand);
                string stringcenter = Convert.ToString((k + j) / 2);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Stageposition, 0);

                //in Textbox6 Augenabstand schreiben
                textBox6.Clear();
                textBox6.AppendText(stringA);
                textBox3.Clear();
                textBox3.AppendText(stringcenter);
            }
        }

        //LinLi + 0.1
        private void button2_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox1 (links) als double k
            double k = 0;
            if (!double.TryParse(textBox1.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k + 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox1.Clear();
                string imax = Convert.ToString(kNew);
                textBox1.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox1.Clear();
                string imin = Convert.ToString(kNew);
                textBox1.AppendText(imin);
            }

            //Inhalt der Textbox4 (rechts) als double j
            double j = 0;
            if (!double.TryParse(textBox4.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = (2 * (34.5 - kNew) + 2 * (34.5 - j)) / 2;
            string stringA = Convert.ToString(Augenabstand);
            string stringcenter = Convert.ToString((kNew + j) / 2);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox1.Clear();
            textBox1.AppendText(kNewString);
            textBox3.Clear();
            textBox3.AppendText(stringcenter);
            textBox6.Clear();
            textBox6.AppendText(stringA);
        }

        //LinLi - 0.1
        private void button1_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox1 (links) als double k
            double k = 0;
            if (!double.TryParse(textBox1.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k - 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox1.Clear();
                string imax = Convert.ToString(kNew);
                textBox1.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox1.Clear();
                string imin = Convert.ToString(kNew);
                textBox1.AppendText(imin);
            }

            //Inhalt der Textbox4 (rechts) als double j
            double j = 0;
            if (!double.TryParse(textBox4.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = (2 * (34.5 - kNew) + 2 * (34.5 - j)) / 2;
            string stringA = Convert.ToString(Augenabstand);
            string stringcenter = Convert.ToString((kNew + j) / 2);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox1.Clear();
            textBox1.AppendText(kNewString);
            textBox3.Clear();
            textBox3.AppendText(stringcenter);
            textBox6.Clear();
            textBox6.AppendText(stringA);
        }

        //Textbox4 Position LinRe
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Inhalt der Textbox als int k
                double k = 0;
                if (!double.TryParse(textBox4.Text, out k))
                {
                    k = -1;
                }

                //Maximum des Augenabstandes
                if (k > 14)
                {
                    k = 14;
                    textBox4.Clear();
                    string imax = Convert.ToString(k);
                    textBox4.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (k < 0)
                {
                    k = 0;
                    textBox4.Clear();
                    string imin = Convert.ToString(k);
                    textBox4.AppendText(imin);
                }

                //Inhalt der Textbox1 (links) als double j
                double j = 0;
                if (!double.TryParse(textBox1.Text, out j))
                {
                    j = -1;
                }

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);
                double Augenabstand = (2 * (34.5 - k) + 2 * (34.5 - j)) / 2;
                string stringA = Convert.ToString(Augenabstand);
                string stringcenter = Convert.ToString((k + j) / 2);

                //Bewegungsbefehle
                stages.LinRe.MoveTo(Stageposition, 0);

                //in Textbox6 Augenabstand schreiben
                textBox6.Clear();
                textBox6.AppendText(stringA);
                textBox3.Clear();
                textBox3.AppendText(stringcenter);
            }
        }

        //LinRe + 0.1
        private void button6_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox4 (rechts) als double k
            double k = 0;
            if (!double.TryParse(textBox4.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k + 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox4.Clear();
                string imax = Convert.ToString(kNew);
                textBox4.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox4.Clear();
                string imin = Convert.ToString(kNew);
                textBox4.AppendText(imin);
            }

            //Inhalt der Textbox1 (links) als double j
            double j = 0;
            if (!double.TryParse(textBox1.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = (2 * (34.5 - kNew) + 2 * (34.5 - j)) / 2;
            string stringA = Convert.ToString(Augenabstand);
            string stringcenter = Convert.ToString((kNew + j) / 2);

            //Bewegungsbefehle
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox4.Clear();
            textBox4.AppendText(kNewString);
            textBox3.Clear();
            textBox3.AppendText(stringcenter);
            textBox6.Clear();
            textBox6.AppendText(stringA);
        }

        //LinRe - 0.1
        private void button14_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox4 (rechts) als double k
            double k = 0;
            if (!double.TryParse(textBox4.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k - 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox4.Clear();
                string imax = Convert.ToString(kNew);
                textBox4.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox4.Clear();
                string imin = Convert.ToString(kNew);
                textBox4.AppendText(imin);
            }

            //Inhalt der Textbox1 (links) als double j
            double j = 0;
            if (!double.TryParse(textBox1.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = (2 * (34.5 - kNew) + 2 * (34.5 - j)) / 2;
            string stringA = Convert.ToString(Augenabstand);
            string stringcenter = Convert.ToString((kNew + j) / 2);

            //Bewegungsbefehle
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox4.Clear();
            textBox4.AppendText(kNewString);
            textBox3.Clear();
            textBox3.AppendText(stringcenter);
            textBox6.Clear();
            textBox6.AppendText(stringA);
        }

        //Section4 Augenabstand ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Textbox6 Augenabstand auslesen und umrechnen -----------------------------------------------------------------
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {

                //Inhalt der Textbox6 als double A
                double A = 65;
                if (!double.TryParse(textBox6.Text, out A))
                {
                    A = -1;
                }

                //Umrechnung Augenabstand A zu Stageposition k
                double k = -0.5 * A + 34.5;

                //Maximum des Augenabstandes
                if (k > 14)
                {
                    k = 14;
                    textBox6.Clear();
                    string imax = Convert.ToString(2*(34.5-k));
                    textBox6.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (k < 0)
                {
                    k = 0;
                    textBox6.Clear();
                    string imin = Convert.ToString(2 * (34.5 - k));
                    textBox6.AppendText(imin);
                }

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Stageposition, 0);
                stages.LinRe.MoveTo(Stageposition, 0);

                string stringk = Convert.ToString(k);
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox1.AppendText(stringk);
                textBox3.AppendText(stringk);
                textBox4.AppendText(stringk);
            }
        }

        //Augenabstand +0.1
        private void button15_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als double A
            double A = 0;
            if (!double.TryParse(textBox6.Text, out A))
            {
                A = -1;
            }

            //Definitionen und Formeln
            double ANew = A + 0.1;
            double kNew = -0.5 * ANew + 34.5;
            textBox6.Clear();
            textBox6.AppendText(Convert.ToString(ANew));

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox6.Clear();
                string kmax = Convert.ToString(2 * (34.5 - kNew));
                textBox6.AppendText(kmax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox6.Clear();
                string kmin = Convert.ToString(2 * (34.5 - kNew));
                textBox6.AppendText(kmin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string ANewString = Convert.ToString(ANew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textboxen schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox1.AppendText(Convert.ToString(Math.Round(kNew, 3)));
            textBox4.AppendText(Convert.ToString(Math.Round(kNew, 3)));
            textBox3.AppendText(Convert.ToString(Math.Round(kNew, 3)));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als double A
            double A = 0;
            if (!double.TryParse(textBox6.Text, out A))
            {
                A = -1;
            }

            //Definitionen und Formeln
            double ANew = A - 0.1;
            double kNew = -0.5 * ANew + 34.5;
            textBox6.Clear();
            textBox6.AppendText(Convert.ToString(ANew));

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                textBox6.Clear();
                string kmax = Convert.ToString(2 * (34.5 - kNew));
                textBox6.AppendText(kmax);
            }

            //Minimum des Augenabstandes
            if (kNew < 0)
            {
                kNew = 0;
                textBox6.Clear();
                string kmin = Convert.ToString(2 * (34.5 - kNew));
                textBox6.AppendText(kmin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string ANewString = Convert.ToString(ANew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textboxen schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox1.AppendText(Convert.ToString(Math.Round(kNew, 3)));
            textBox4.AppendText(Convert.ToString(Math.Round(kNew, 3)));
            textBox3.AppendText(Convert.ToString(Math.Round(kNew, 3)));
        }
    }
}
