using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        //Section1 Vergenzwinkel ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Home Button Vergenzwinkel ------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(40, 40);
            stages.LinRe.SetVelocityParams(40, 40);

            //No Backlash
            stages.LinLi.SetBacklash(0);
            stages.LinRe.SetBacklash(0);

            //Bring Stages in a save Position
            stages.LinLi.MoveTo(0, 8000);
            stages.LinRe.MoveTo(0, 8000);

            //Home Vergenzwinkel
            stages.RotLi.Home(0);
            stages.RotRe.Home(0);

            //in Textbox3 schreiben
            string Zerostring = Convert.ToString(0);
            textBox3.Clear();
            textBox3.AppendText(Zerostring);

            //in Textbox2 schreiben
            textBox2.Clear();
            textBox2.AppendText(Zerostring);
        }

        //Textbox2 Vergenzwinkel ------------------------------------------------------------
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {

                //Inhalt der Textbox2 als int j
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
                stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
                stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

                //in Textbox 5 Positionskorrektur schreiben
                decimal x = 10;
                string test = Convert.ToString(x);
                textBox5.Clear();
                textBox5.AppendText("+");
                textBox5.AppendText(test);
            }
        }

        //Vergenzwinkel +1 ------------------------------------------------------------
        private void button7_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox2 als int j
            double j = 0;
            if (!double.TryParse(textBox2.Text, out j))
            {
                j = -1;
            }
            
            //Definitionen und Formeln
            double Vergenzwinkel = j + 1;

            //Maximum des Vergenzwinkels
            if (Vergenzwinkel > 5)
            {
                Vergenzwinkel = 5;
                textBox2.Clear();
                string jmax = Convert.ToString(Vergenzwinkel);
                textBox2.AppendText(jmax);
            }

            //Minimum des Vergenzwinkels
            if (Vergenzwinkel < 0)
            {
                Vergenzwinkel = 0;
                textBox2.Clear();
                string jmax = Convert.ToString(Vergenzwinkel);
                textBox2.AppendText(jmax);
            }

            //Definitionen und Formeln
            decimal Vergenzwinkeldecimal = Convert.ToDecimal(Vergenzwinkel);
            string Vergenzwinkelstring = Convert.ToString(Vergenzwinkel);

            //Bewegungsbefehle Rotation
            stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
            stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

            //in Textbox2 schreiben
            textBox2.Clear();
            textBox2.AppendText(Vergenzwinkelstring);
        }

        //Vergenzwinkel -1 ------------------------------------------------------------
        private void button8_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox2 als int j
            double j = 0;
            if (!double.TryParse(textBox2.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            double Vergenzwinkel = j - 1;

            //Maximum des Vergenzwinkels
            if (Vergenzwinkel > 5)
            {
                Vergenzwinkel = 5;
                textBox2.Clear();
                string jmax = Convert.ToString(Vergenzwinkel);
                textBox2.AppendText(jmax);
            }

            //Minimum des Vergenzwinkels
            if (Vergenzwinkel < 0)
            {
                Vergenzwinkel = 0;
                textBox2.Clear();
                string jmax = Convert.ToString(Vergenzwinkel);
                textBox2.AppendText(jmax);
            }

            //Definitionen und Formeln
            decimal Vergenzwinkeldecimal = Convert.ToDecimal(Vergenzwinkel);
            string Vergenzwinkelstring = Convert.ToString(Vergenzwinkel);

            //Bewegungsbefehle Rotation
            stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
            stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

            //in Textbox2 schreiben
            textBox2.Clear();
            textBox2.AppendText(Vergenzwinkelstring);
        }

        //Section2 Stageposition ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Homebutton Stageposition ------------------------------------------------------------
        private void button13_Click(object sender, EventArgs e)
        {
            //Bewegungsbefehle
            stages.LinLi.Home(0);
            stages.LinRe.Home(0);

            //in Textbox3 schreiben
            decimal zero = 0;
            string stringzero = Convert.ToString(zero);
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
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
                //Geschwindigkeit einstellen
                stages.LinLi.SetVelocityParams(20, 20);
                stages.LinRe.SetVelocityParams(20, 20);

                //No Backlash
                stages.LinLi.SetBacklash(0);
                stages.LinRe.SetBacklash(0);

                //Inhalt der Textbox als int k
                double k = 0;
                if (!double.TryParse(textBox3.Text, out k))
                {
                    k = -1;
                }

                //Maximum des Augenabstandes
                if (k > 14)
                {
                    k = 14;
                    textBox3.Clear();
                    string imax = Convert.ToString(k);
                    textBox3.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (k < 0)
                {
                    k = 0;
                    textBox3.Clear();
                    string imin = Convert.ToString(k);
                    textBox3.AppendText(imin);
                }

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Stageposition, 0);
                stages.LinRe.MoveTo(Stageposition, 0);

                string stringk = Convert.ToString(k);
                textBox1.Clear();
                textBox4.Clear();
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

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(20, 20);
            stages.LinRe.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinLi.SetBacklash(0);
            stages.LinRe.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
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

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(20, 20);
            stages.LinRe.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinLi.SetBacklash(0);
            stages.LinRe.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
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

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(20, 20);
            stages.LinRe.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinLi.SetBacklash(0);
            stages.LinRe.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
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

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(20, 20);
            stages.LinRe.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinLi.SetBacklash(0);
            stages.LinRe.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
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
                //Geschwindigkeit einstellen
                stages.LinLi.SetVelocityParams(20, 20);

                //No Backlash
                stages.LinLi.SetBacklash(0);

                //Inhalt der Textbox als int k
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

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Stageposition, 0);
            }
        }

        //LinLi + 0.1
        private void button2_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
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

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinLi.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox1.Clear();
            textBox1.AppendText(kNewString);
        }

        //LinLi - 0.1
        private void button1_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
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

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Geschwindigkeit einstellen
            stages.LinLi.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinLi.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox1.Clear();
            textBox1.AppendText(kNewString);
        }

        //Textbox4 Position LinRe
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Geschwindigkeit einstellen
                stages.LinRe.SetVelocityParams(20, 20);

                //No Backlash
                stages.LinRe.SetBacklash(0);

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

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);

                //Bewegungsbefehle
                stages.LinRe.MoveTo(Stageposition, 0);
            }
        }

        //LinRe + 0.1
        private void button6_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
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

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Geschwindigkeit einstellen
            stages.LinRe.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinRe.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox4.Clear();
            textBox4.AppendText(kNewString);
        }

        //LinRe - 0.1
        private void button14_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als int k
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

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Geschwindigkeit einstellen
            stages.LinRe.SetVelocityParams(20, 20);

            //No Backlash
            stages.LinRe.SetBacklash(0);

            //Bewegungsbefehle
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox4.Clear();
            textBox4.AppendText(kNewString);
        }
    }
}
