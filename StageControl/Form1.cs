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
   
    public partial class Form1 : Form

    {
        Stages stages = new Stages();

        public Form1()
        {
            InitializeComponent();
            stages.init();
        }

        //Home Button Position ------------------------------------------------------------
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Bewegungsbefehle
            stages.LinLi.Home(0);
            stages.LinRe.Home(0);
        }

        //Section1 Augenabstand ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Textbox1 Augenabstand ------------------------------------------------------------
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Geschwindigkeit einstellen
                stages.LinLi.SetVelocityParams(10, 10);
                stages.LinRe.SetVelocityParams(10, 10);

                //No Backlash
                stages.LinLi.SetBacklash(0);
                stages.LinRe.SetBacklash(0);

                //Inhalt der Textbox als int i
                double i = 0;
                if (!double.TryParse(textBox1.Text, out i))
                {
                    i = -1;
                }

                //Maximum des Augenabstandes
                if (i > 70)
                {
                    i = 70;
                    textBox1.Clear();
                    string imax = Convert.ToString(i);
                    textBox1.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (i < 50)
                {
                    i = 50;
                    textBox1.Clear();
                    string imin = Convert.ToString(i);
                    textBox1.AppendText(imin);
                }
                
                //Definitionen und Formeln
                double Augenabstand = i;
                double Augenpositiondouble = -5 * Augenabstand + 350;
                decimal Augenposition = Convert.ToDecimal(Augenpositiondouble);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Augenposition / 10, 0);
                stages.LinRe.MoveTo(Augenposition / 10, 0);
            }
        }

        //+0.1 Button Textbox1 ------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox1 als int i
            double i = 0;
            if (!double.TryParse(textBox1.Text, out i))
            {
                i = -1;
            }

            //Definitionen und Formeln
            double Augenabstand = i + 0.1;

            //Minimum des Augenabstandes
            if (Augenabstand < 50)
            {
                Augenabstand = 50;
                textBox1.Clear();
                string imin = Convert.ToString(Augenabstand);
                textBox1.AppendText(imin);
            }

            //Maximum des Augenabstandes
            if (Augenabstand > 70)
            {
                Augenabstand = 70;
                textBox1.Clear();
                string imax = Convert.ToString(Augenabstand);
                textBox1.AppendText(imax);
            }

            //Definitionen und Formeln
            textBox1.Clear();
            string AugenabstandString = Convert.ToString(Augenabstand);
            textBox1.AppendText(AugenabstandString);
            double Augenpositiondouble = -5 * Augenabstand + 350;
            decimal Augenposition = Convert.ToDecimal(Augenpositiondouble);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Augenposition / 10, 0);
            stages.LinRe.MoveTo(Augenposition / 10, 0);
        }

        //+1 Button Textbox1 ------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox1 als int i
            double i = 0;
            if (!double.TryParse(textBox1.Text, out i))
            {
                i = -1;
            }

            //Definitionen und Formeln
            double Augenabstand = i + 1;

            //Minimum des Augenabstandes
            if (Augenabstand < 50)
            {
                Augenabstand = 50;
                textBox1.Clear();
                string imin = Convert.ToString(Augenabstand);
                textBox1.AppendText(imin);
            }

            //Maximum des Augenabstandes
            if (Augenabstand > 70)
            {
                Augenabstand = 70;
                textBox1.Clear();
                string imax = Convert.ToString(Augenabstand);
                textBox1.AppendText(imax);
            }

            //Definitionen und Formeln
            textBox1.Clear();
            string AugenabstandString = Convert.ToString(Augenabstand);
            textBox1.AppendText(AugenabstandString);
            double Augenpositiondouble = -5 * Augenabstand + 350;
            decimal Augenposition = Convert.ToDecimal(Augenpositiondouble);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Augenposition / 10, 0);
            stages.LinRe.MoveTo(Augenposition / 10, 0);
        }

        //-0.1 Button Textbox1 ------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox1 als int i
            double i = 0;
            if (!double.TryParse(textBox1.Text, out i))
            {
                i = -1;
            }

            //Definitionen und Formeln
            double Augenabstand = i - 0.1;

            //Minimum des Augenabstandes
            if (Augenabstand < 50)
            {
                Augenabstand = 50;
                textBox1.Clear();
                string imin = Convert.ToString(Augenabstand);
                textBox1.AppendText(imin);
            }

            //Maximum des Augenabstandes
            if (Augenabstand > 70)
            {
                Augenabstand = 70;
                textBox1.Clear();
                string imax = Convert.ToString(Augenabstand);
                textBox1.AppendText(imax);
            }

            //Definitionen und Formeln
            textBox1.Clear();
            string AugenabstandString = Convert.ToString(Augenabstand);
            textBox1.AppendText(AugenabstandString);
            double Augenpositiondouble = -5 * Augenabstand + 350;
            decimal Augenposition = Convert.ToDecimal(Augenpositiondouble);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Augenposition / 10, 0);
            stages.LinRe.MoveTo(Augenposition / 10, 0);
        }

        //-1 Button Textbox1 ------------------------------------------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox1 als int i
            double i = 0;
            if (!double.TryParse(textBox1.Text, out i))
            {
                i = -1;
            }

            //Definitionen und Formeln
            double Augenabstand = i - 1;

            //Minimum des Augenabstandes
            if (Augenabstand < 50)
            {
                Augenabstand = 50;
                textBox1.Clear();
                string imin = Convert.ToString(Augenabstand);
                textBox1.AppendText(imin);
            }

            //Maximum des Augenabstandes
            if (Augenabstand > 70)
            {
                Augenabstand = 70;
                textBox1.Clear();
                string imax = Convert.ToString(Augenabstand);
                textBox1.AppendText(imax);
            }

            //Definitionen und Formeln
            textBox1.Clear();
            string AugenabstandString = Convert.ToString(Augenabstand);
            textBox1.AppendText(AugenabstandString);
            double Augenpositiondouble = -5 * Augenabstand + 350;
            decimal Augenposition = Convert.ToDecimal(Augenpositiondouble);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Augenposition / 10, 0);
            stages.LinRe.MoveTo(Augenposition / 10, 0);
        }

        //Section2 Vergenzwinkel ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Home Button Vergenzwinkel ------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            stages.RotLi.Home(0);
            stages.RotRe.Home(0);
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

                //Inhalt der Textbox1 als int i
                double i = 0;
                if (!double.TryParse(textBox1.Text, out i))
                {
                    i = -1;
                }

                //Maximum des Augenabstandes
                if (i > 70)
                {
                    i = 70;
                    textBox1.Clear();
                    string imax = Convert.ToString(i);
                    textBox1.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (i < 50)
                {
                    i = 50;
                    textBox1.Clear();
                    string imin = Convert.ToString(i);
                    textBox1.AppendText(imin);
                }

                //Definitionen und Formeln
                double Augenabstand = i;
                double Augenposition = -5 * Augenabstand + 350;
                double Vergenzwinkel = j;
                double Distanz = 100;
                double Augenabstand0 = 65;
                double Augenradius = 9.9;
                double VergenzwinkelRad = Vergenzwinkel * 2 * Math.PI / 360;
                double B = 10 * (Math.Sin(VergenzwinkelRad) * (Distanz - (Augenabstand0 - Augenabstand) / 2) / (Math.Sin(VergenzwinkelRad) + 1) + Math.Tan(VergenzwinkelRad) * Augenradius);

                if (Augenposition + B > 120)
                {
                    B = 120 - Augenposition;
                }

                decimal Positionsoffset = Convert.ToInt32(B);
                decimal Vergenzwinkeldecimal = Convert.ToDecimal(Vergenzwinkel);
                decimal Augenpositiondecimal = Convert.ToDecimal(Augenposition);
                string Positionsoffsetstring = Convert.ToString(Positionsoffset);
                string Augenpositionstring = Convert.ToString(Augenposition);
                string NewPosition = Convert.ToString((Augenpositiondecimal + Positionsoffset) / 10);

                //Bewegungsbefehle Rotation
                stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
                stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

                //Bewegungsbefehle Positionsoffset
                stages.LinLi.MoveTo((Augenpositiondecimal + Positionsoffset) / 10, 0);
                stages.LinRe.MoveTo((Augenpositiondecimal + Positionsoffset) / 10, 0);

                //In Textbox3 schreiben
                textBox3.Clear();
                textBox3.AppendText(NewPosition);
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

            //Inhalt der Textbox1 als int i
            double i = 0;
            if (!double.TryParse(textBox1.Text, out i))
            {
                i = -1;
            }

            //Maximum des Augenabstandes
            if (i > 70)
            {
                i = 70;
                textBox1.Clear();
                string imax = Convert.ToString(i);
                textBox1.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (i < 50)
            {
                i = 50;
                textBox1.Clear();
                string imin = Convert.ToString(i);
                textBox1.AppendText(imin);
            }

            //Definitionen und Formeln
            double Augenabstand = i;
            double Augenposition = -5 * Augenabstand + 350;
            double Vergenzwinkel = j + 1;
            double Distanz = 100;
            double Augenabstand0 = 65;
            double Augenradius = 9.9;
            double VergenzwinkelRad = Vergenzwinkel * 2 * Math.PI / 360;
            double B = 10 * (Math.Sin(VergenzwinkelRad) * (Distanz - (Augenabstand0 - Augenabstand) / 2) / (Math.Sin(VergenzwinkelRad) + 1) + Math.Tan(VergenzwinkelRad) * Augenradius);
            
            if (Augenposition + B > 120)
            {
                B = 120 - Augenposition;
            }

            decimal Positionsoffset = Convert.ToInt32(B);
            decimal Vergenzwinkeldecimal = Convert.ToDecimal(Vergenzwinkel);
            decimal Augenpositiondecimal = Convert.ToDecimal(Augenposition);
            string Positionsoffsetstring = Convert.ToString(Positionsoffset);
            string Augenpositionstring = Convert.ToString(Augenposition);
            string NewPosition = Convert.ToString((Augenpositiondecimal + Positionsoffset) / 10);
            string Vergenzwinkelstring = Convert.ToString(Vergenzwinkel);

            //Bewegungsbefehle Rotation
            stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
            stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

            //Bewegungsbefehle Positionsoffset
            stages.LinLi.MoveTo((Augenpositiondecimal + Positionsoffset) / 10, 0);
            stages.LinRe.MoveTo((Augenpositiondecimal + Positionsoffset) / 10, 0);

            //in Textbox2 schreiben
            textBox2.Clear();
            textBox2.AppendText(Vergenzwinkelstring);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox3.AppendText(NewPosition);
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

            //Inhalt der Textbox1 als int i
            double i = 0;
            if (!double.TryParse(textBox1.Text, out i))
            {
                i = -1;
            }

            //Maximum des Augenabstandes
            if (i > 70)
            {
                i = 70;
                textBox1.Clear();
                string imax = Convert.ToString(i);
                textBox1.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (i < 50)
            {
                i = 50;
                textBox1.Clear();
                string imin = Convert.ToString(i);
                textBox1.AppendText(imin);
            }

            //Definitionen und Formeln
            double Augenabstand = i;
            double Augenposition = -5 * Augenabstand + 350;
            double Vergenzwinkel = j - 1;
            double Distanz = 100;
            double Augenabstand0 = 65;
            double Augenradius = 9.9;
            double VergenzwinkelRad = Vergenzwinkel * 2 * Math.PI / 360;
            double B = 10 * (Math.Sin(VergenzwinkelRad) * (Distanz - (Augenabstand0 - Augenabstand) / 2) / (Math.Sin(VergenzwinkelRad) + 1) + Math.Tan(VergenzwinkelRad) * Augenradius);

            if (Augenposition + B > 120)
            {
                B = 120 - Augenposition;
            }

            decimal Positionsoffset = Convert.ToInt32(B);
            decimal Vergenzwinkeldecimal = Convert.ToDecimal(Vergenzwinkel);
            decimal Augenpositiondecimal = Convert.ToDecimal(Augenposition);
            string Positionsoffsetstring = Convert.ToString(Positionsoffset);
            string Augenpositionstring = Convert.ToString(Augenposition);
            string NewPosition = Convert.ToString((Augenpositiondecimal + Positionsoffset) / 10);
            string Vergenzwinkelstring = Convert.ToString(Vergenzwinkel);

            //Bewegungsbefehle Rotation
            stages.RotLi.MoveTo(Vergenzwinkeldecimal / 2, 0);
            stages.RotRe.MoveTo(360 - Vergenzwinkeldecimal / 2, 0);

            //Bewegungsbefehle Positionsoffset
            stages.LinLi.MoveTo((Augenpositiondecimal + Positionsoffset) / 10, 0);
            stages.LinRe.MoveTo((Augenpositiondecimal + Positionsoffset) / 10, 0);

            //in Textbox2 schreiben
            textBox2.Clear();
            textBox2.AppendText(Vergenzwinkelstring);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox3.AppendText(NewPosition);
        }

        //Section3 Stageposition ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Homebutton Stageposition ------------------------------------------------------------
        private void button13_Click(object sender, EventArgs e)
        {
            //Bewegungsbefehle
            stages.LinLi.Home(0);
            stages.LinRe.Home(0);
        }

        //Stageposition Textbox3 ------------------------------------------------------------
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Geschwindigkeit einstellen
                stages.LinLi.SetVelocityParams(10, 10);
                stages.LinRe.SetVelocityParams(10, 10);

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
                if (k > 12)
                {
                    k = 12;
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

            //Maximum des Augenabstandes
            if (k > 12)
            {
                k = 12;
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
            double kNew = k + 0.1;
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
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

            //Maximum des Augenabstandes
            if (k > 12)
            {
                k = 12;
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
            double kNew = k - 0.1;
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
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

            //Maximum des Augenabstandes
            if (k > 12)
            {
                k = 12;
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
            double kNew = k + 1;
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
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

            //Maximum des Augenabstandes
            if (k > 12)
            {
                k = 12;
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
            double kNew = k - 1;
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            textBox3.Clear();
            textBox3.AppendText(kNewString);
        }
    }
}
