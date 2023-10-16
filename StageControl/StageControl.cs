using System;
using System.Threading;
using System.Windows.Forms;

using Thorlabs.MotionControl.GenericMotorCLI;

namespace StageControl
{

    public partial class StageControl : Form
    {
        Stages stages = new Stages();
        ManualResetEvent waitEvent = new ManualResetEvent(false);
        decimal LinksAngleZero = 0;
        decimal RechtsAngleZero = 0;

        public StageControl()
        {
            InitializeComponent();
            
            //in Textboxen schreiben
            string Zerostring = Convert.ToString(0);
            string sixnine = Convert.ToString(69);
            StagePosBeideTextBox.Clear();
            StagePosBeideTextBox.AppendText(Zerostring);
            VergenzwinkelTextBox.Clear();
            VergenzwinkelTextBox.AppendText(Zerostring);
            StagePosLinksTextBox.Clear();
            StagePosLinksTextBox.AppendText(Zerostring);
            StagePosRechtsTextBox.Clear();
            StagePosRechtsTextBox.AppendText(Zerostring);
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(sixnine);
            PosKorrekturTextBox.Clear();
            PosKorrekturTextBox.AppendText(Zerostring);
        }

        //Section1 Vergenzwinkel ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Home Button Vergenzwinkel ------------------------------------------------------------
        private void VergenzwinkelButton_Click(object sender, EventArgs e)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle
                || stages.RotLi.State != MotorStates.Idle
                || stages.RotRe.State != MotorStates.Idle)
                return;

            //Bring Stages in a save Position
            stages.LinLi.MoveTo(0, 0);
            stages.LinRe.MoveTo(0, 8000);

            //Home Vergenzwinkel
            // croatch so the mirrors will not fluctuate
            stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(0, 0));
            stages.RotRe.MoveTo(90, p => stages.RotRe.MoveTo(0, 0));

            //in Textboxen schreiben
            string Zerostring = Convert.ToString(0);
            string sixnine = Convert.ToString(69);
            PosKorrekturTextBox.Text = Zerostring;
            StagePosBeideTextBox.Clear();
            StagePosBeideTextBox.AppendText(Zerostring);
            VergenzwinkelTextBox.Clear();
            VergenzwinkelTextBox.AppendText(Zerostring);
            StagePosLinksTextBox.Clear();
            StagePosLinksTextBox.AppendText(Zerostring);
            StagePosRechtsTextBox.Clear();
            StagePosRechtsTextBox.AppendText(Zerostring);
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(sixnine);
        }

        //Textbox2 Vergenzwinkel ------------------------------------------------------------
        private void VergenzwinkelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                VergenzwinkelSetup(sender);
            }
        }

        //Vergenzwinkel +1 ------------------------------------------------------------
        private void VergenzwinkelUpButton_Click(object sender, EventArgs e)
        {
            VergenzwinkelSetup(sender);
        }

        //Vergenzwinkel -1 ------------------------------------------------------------
        private void VergenzwinkelDownButton_Click(object sender, EventArgs e)
        {
            VergenzwinkelSetup(sender);
        }

        private void VergenzwinkelSetup(object sender)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle
                || stages.RotLi.State != MotorStates.Idle
                || stages.RotRe.State != MotorStates.Idle)
                return;

            //Inhalt der Textbox2 Vergenzwinkel als double j
            double j = 0;
            if (!double.TryParse(VergenzwinkelTextBox.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            double V = j;

            if (sender == VergenzwinkelDownButton)
                V -= 1;
            else if (sender == VergenzwinkelUpButton)
                V += 1;

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
            string Vstring = Convert.ToString(V);
            decimal Vdecimal = Convert.ToDecimal(V) / 2;

            //Bewegungsbefehle Rotation
            stages.RotLi.SetVelocityParams(100, 1000);
            stages.RotRe.SetVelocityParams(100, 1000);
            // stages.RotLi.MoveTo(Vdecimal, 0);
            // stages.RotLi.MoveTo(360 - Vdecimal, 0);

            if (Vdecimal + LinksAngleZero < 0)
            {
                stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(360 + Vdecimal + LinksAngleZero, 0));
            }
            else
            {
                stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(Vdecimal + LinksAngleZero, 0));
            }

            if (Vdecimal + RechtsAngleZero < 0)
            {
                stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(360 + Vdecimal + RechtsAngleZero, 0));
            }
            else
            {
                stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(Vdecimal + RechtsAngleZero, 0));
            }

            //stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(Vdecimal, 0));
            //stages.RotRe.MoveTo(90, p => stages.RotRe.MoveTo(360 - Vdecimal, 0));

            //Inhalt der Textbox3 Stageposition als double k
            double k = 0;
            if (!double.TryParse(StagePosBeideTextBox.Text, out k))
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
            if (!double.TryParse(PosKorrekturTextBox.Text, out d))
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
            PosKorrekturTextBox.Clear();
            PosKorrekturTextBox.AppendText(Positionsoffsetstring);
            StagePosBeideTextBox.Clear();
            StagePosBeideTextBox.AppendText(P1string);
            StagePosLinksTextBox.Clear();
            StagePosLinksTextBox.AppendText(P1string);
            StagePosRechtsTextBox.Clear();
            StagePosRechtsTextBox.AppendText(P1string);
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(A1string);
            VergenzwinkelTextBox.Clear();
            VergenzwinkelTextBox.AppendText(Vstring);
        }

        //Section2 Stageposition ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Homebutton Stageposition ------------------------------------------------------------
        private void StagePosHomeButton_Click(object sender, EventArgs e)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle)
                return;

            //Bewegungsbefehle
            stages.LinLi.MoveTo(0, 0);
            stages.LinRe.MoveTo(0, 0);

            //in Textboxen schreiben
            decimal zero = 0;
            decimal sixnine = 69;
            string stringzero = Convert.ToString(zero);
            string stringsixnine = Convert.ToString(sixnine);
            StagePosBeideTextBox.Clear();
            StagePosLinksTextBox.Clear();
            StagePosRechtsTextBox.Clear();
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(stringsixnine);
            StagePosBeideTextBox.AppendText(stringzero);
            StagePosLinksTextBox.AppendText(stringzero);
            StagePosRechtsTextBox.AppendText(stringzero);
        }

        private void MoveBeideStagePos(double kNew)
        {
            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string kNewString = Convert.ToString(kNew);
            double Augenabstand = 2 * (34.5 - kNew);
            string stringA = Convert.ToString(Augenabstand);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textbox3 schreiben
            StagePosBeideTextBox.Clear();
            StagePosLinksTextBox.Clear();
            StagePosRechtsTextBox.Clear();
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(stringA);
            StagePosLinksTextBox.AppendText(kNewString);
            StagePosRechtsTextBox.AppendText(kNewString);
            StagePosBeideTextBox.AppendText(kNewString);
        }

        private void SetupBeideStagePos(object sender)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle)
                return;

            //Inhalt der Textbox als int k
            double k = 0;
            if (!double.TryParse(StagePosBeideTextBox.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k;

            if (sender == StagePosUp01Button)
                kNew += 0.1;
            else if (sender == StagePosDown01Button)
                kNew -= 0.1;
            else if (sender == StagePosUp1Button)
                kNew += 1;
            else if (sender == StagePosDown1Button)
                kNew -= 1;

            //Maximum der Stageposition
            if (kNew > 14)
            {
                kNew = 14;
                StagePosBeideTextBox.Clear();
                string imax = Convert.ToString(kNew);
                StagePosBeideTextBox.AppendText(imax);
            }

            //Minimum der Stageposition
            if (kNew < -1)
            {
                kNew = -1;
                StagePosBeideTextBox.Clear();
                string imin = Convert.ToString(kNew);
                StagePosBeideTextBox.AppendText(imin);
            }

            MoveBeideStagePos(kNew);
        }

        //Stageposition Textbox3 ------------------------------------------------------------
        private void StagePosBeideTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                SetupBeideStagePos(sender);
            }
        }

        //Stageposition +0.1 Textbox3 ------------------------------------------------------------
        private void StagePosUp01Button_Click(object sender, EventArgs e)
        {
            SetupBeideStagePos(sender);
        }

        //Stageposition -0.1 Textbox3 ------------------------------------------------------------
        private void StagePosDown01Button_Click(object sender, EventArgs e)
        {
            SetupBeideStagePos(sender);
        }

        //Stageposition +1 Textbox3 ------------------------------------------------------------
        private void StagePosUp1Button_Click(object sender, EventArgs e)
        {
            SetupBeideStagePos(sender);
        }

        //Stageposition -1 Textbox3 ------------------------------------------------------------
        private void StagePosDown1Button_Click(object sender, EventArgs e)
        {
            SetupBeideStagePos(sender);
        }

        //Section3 einzelne Stagepositionen ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void SetupLinksStagePos(object sender)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle)
                return;

            //Inhalt der Textbox1 (links) als double k
            double k = 0;
            if (!double.TryParse(StagePosLinksTextBox.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k;
            if (sender == StagePosLinksDownButton)
                kNew -= 0.1;
            else if (sender == StagePosLinksUpButton)
                kNew += 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                StagePosLinksTextBox.Clear();
                string imax = Convert.ToString(kNew);
                StagePosLinksTextBox.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < -1)
            {
                kNew = -1;
                StagePosLinksTextBox.Clear();
                string imin = Convert.ToString(kNew);
                StagePosLinksTextBox.AppendText(imin);
            }

            //Inhalt der Textbox4 (rechts) als double j
            double j = 0;
            if (!double.TryParse(StagePosRechtsTextBox.Text, out j))
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
            StagePosLinksTextBox.Clear();
            StagePosLinksTextBox.AppendText(kNewString);
            StagePosBeideTextBox.Clear();
            StagePosBeideTextBox.AppendText(stringcenter);
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(stringA);
        }

        //Textbox1 Position LinLi -----------------------------------------------------------------
        private void StagePosLinksTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                SetupLinksStagePos(sender);
            }
        }

        //LinLi + 0.1
        private void StagePosLinksUpButton_Click(object sender, EventArgs e)
        {
            SetupLinksStagePos(sender);
        }

        //LinLi - 0.1
        private void StagePosLinksDownButton_Click(object sender, EventArgs e)
        {
            SetupLinksStagePos(sender);
        }

        private void SetupRechtsStagePos(object sender)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle)
                return;
            //Inhalt der Textbox4 (rechts) als double k
            double k = 0;
            if (!double.TryParse(StagePosRechtsTextBox.Text, out k))
            {
                k = -1;
            }

            //Definitionen und Formeln
            double kNew = k;

            if (sender == StagePosRechtsDownButton)
                kNew -= 0.1;
            else if (sender == StagePosRechtsUpButton)
                kNew += 0.1;

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                StagePosRechtsTextBox.Clear();
                string imax = Convert.ToString(kNew);
                StagePosRechtsTextBox.AppendText(imax);
            }

            //Minimum des Augenabstandes
            if (kNew < -1)
            {
                kNew = -1;
                StagePosRechtsTextBox.Clear();
                string imin = Convert.ToString(kNew);
                StagePosRechtsTextBox.AppendText(imin);
            }

            //Inhalt der Textbox1 (links) als double j
            double j = 0;
            if (!double.TryParse(StagePosLinksTextBox.Text, out j))
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
            StagePosRechtsTextBox.Clear();
            StagePosRechtsTextBox.AppendText(kNewString);
            StagePosBeideTextBox.Clear();
            StagePosBeideTextBox.AppendText(stringcenter);
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(stringA);
        }

        //Textbox4 Position LinRe
        private void StagePosRechtsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                SetupRechtsStagePos(sender);
            }
        }

        //LinRe + 0.1
        private void StagePosRechtsUpButton_Click(object sender, EventArgs e)
        {
            SetupRechtsStagePos(sender);
        }

        //LinRe - 0.1
        private void StagePosRechtsDownButton_Click(object sender, EventArgs e)
        {
            SetupRechtsStagePos(sender);
        }

        //Section4 Augenabstand ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Textbox6 Augenabstand auslesen und umrechnen -----------------------------------------------------------------
        private void AugenabstandTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                if (stages.LinLi.State != MotorStates.Idle
                    || stages.LinRe.State != MotorStates.Idle
                    || stages.RotLi.State != MotorStates.Idle
                    || stages.RotRe.State != MotorStates.Idle)
                    return;

                //Inhalt der Textbox6 als double A
                double A = 65;
                if (!double.TryParse(AugenabstandTextBox.Text, out A))
                {
                    A = -1;
                }

                //Umrechnung Augenabstand A zu Stageposition k
                double k = -0.5 * A + 34.5;

                //Maximum des Augenabstandes
                if (k > 14)
                {
                    k = 14;
                    AugenabstandTextBox.Clear();
                    string imax = Convert.ToString(2*(34.5-k));
                    AugenabstandTextBox.AppendText(imax);
                }

                //Minimum des Augenabstandes
                if (k < -1)
                {
                    k = -1;
                    AugenabstandTextBox.Clear();
                    string imin = Convert.ToString(2 * (34.5 - k));
                    AugenabstandTextBox.AppendText(imin);
                }

                //Definitionen und Formeln
                decimal Stageposition = Convert.ToDecimal(k);

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Stageposition, 0);
                stages.LinRe.MoveTo(Stageposition, 0);

                string stringk = Convert.ToString(k);
                StagePosLinksTextBox.Clear();
                StagePosBeideTextBox.Clear();
                StagePosRechtsTextBox.Clear();
                StagePosLinksTextBox.AppendText(stringk);
                StagePosBeideTextBox.AppendText(stringk);
                StagePosRechtsTextBox.AppendText(stringk);
            }
        }

        //Augenabstand +0.1
        private void AugenabstandUpButton_Click(object sender, EventArgs e)
        {
            AugenabstandSetup(sender);
        }

        private void AugenabstandDownButton_Click(object sender, EventArgs e)
        {
            AugenabstandSetup(sender);
        }

        private void AugenabstandSetup(object sender)
        {
            if (stages.LinLi.State != MotorStates.Idle
                || stages.LinRe.State != MotorStates.Idle
                || stages.RotLi.State != MotorStates.Idle
                || stages.RotRe.State != MotorStates.Idle)
                return;

            //Inhalt der Textbox als double A
            double A = 0;
            if (!double.TryParse(AugenabstandTextBox.Text, out A))
            {
                A = -1;
            }

            //Definitionen und Formeln
            double ANew = A;
            if (sender == AugenabstandDownButton)
                ANew -= 0.1;
            else if (sender == AugenabstandUpButton)
                ANew += 0.1;

            double kNew = -0.5 * ANew + 34.5;
            AugenabstandTextBox.Clear();
            AugenabstandTextBox.AppendText(Convert.ToString(ANew));

            //Maximum des Augenabstandes
            if (kNew > 14)
            {
                kNew = 14;
                AugenabstandTextBox.Clear();
                string kmax = Convert.ToString(2 * (34.5 - kNew));
                AugenabstandTextBox.AppendText(kmax);
            }

            //Minimum des Augenabstandes
            if (kNew < -1)
            {
                kNew = -1;
                AugenabstandTextBox.Clear();
                string kmin = Convert.ToString(2 * (34.5 - kNew));
                AugenabstandTextBox.AppendText(kmin);
            }

            //Definitionen und Formeln
            decimal Stageposition = Convert.ToDecimal(kNew);
            string ANewString = Convert.ToString(ANew);

            //Bewegungsbefehle
            stages.LinLi.MoveTo(Stageposition, 0);
            stages.LinRe.MoveTo(Stageposition, 0);

            //In Textboxen schreiben
            StagePosBeideTextBox.Clear();
            StagePosLinksTextBox.Clear();
            StagePosRechtsTextBox.Clear();
            StagePosLinksTextBox.AppendText(Convert.ToString(Math.Round(kNew, 3)));
            StagePosRechtsTextBox.AppendText(Convert.ToString(Math.Round(kNew, 3)));
            StagePosBeideTextBox.AppendText(Convert.ToString(Math.Round(kNew, 3)));
        }

        private void StageControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            waitEvent.Close();
            stages.Disconnect();
        }

        private void UpdateUI()
        {
            this.Enabled = true;
        }

        private void StageControl_Shown(object sender, EventArgs e)
        {
            stages.Init();
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
            stages.RotLi.Home(p => stages.RotLi.MoveTo(90, pp => stages.RotLi.MoveTo(0, 0)));
            stages.RotRe.Home(p => stages.RotRe.MoveTo(90, pp => stages.RotRe.MoveTo(0, 0)));

            Thread.Sleep(5000);

            UpdateUI();
        }

        // Links Angle
        //-------------------------
        private void LinksAngleIncreaseButton_Click(object sender, EventArgs e)
        {
            SetupLinksAngle(sender);
        }

        private void LinksAngleDecreaseButton_Click(object sender, EventArgs e)
        {
            SetupLinksAngle(sender);
        }

        private void LinksAngleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                SetupLinksAngle(sender);
            }
        }

        private void SetupLinksAngle(object sender)
        {
            if (stages.RotLi.State != MotorStates.Idle)
                return;


            //Inhalt der Textbox als double j
            double j = 0;
            if (!double.TryParse(LinksAngleTextBox.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            double V = j;

            if (sender == LinksAngleDecreaseButton)
                V -= 1;
            else if (sender == LinksAngleIncreaseButton)
                V += 1;

            //Maximum des Vergenzwinkels
            if (V > 45)
            {
                V = 45;
            }

            //Minimum des Vergenzwinkels
            if (V < -45)
            {
                V = -45;
            }

            //Definitionen und Formeln
            decimal Vdecimal = Convert.ToDecimal(V);
            string Vstring = Convert.ToString(V);

            //Bewegungsbefehle Rotation
            stages.RotLi.SetVelocityParams(100, 1000);

            if (Vdecimal < 0)
            {
                stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(360 + Vdecimal, 0));
            }
            else
            {
                stages.RotLi.MoveTo(90, p => stages.RotLi.MoveTo(Vdecimal, 0));
            }

            LinksAngleZero = Vdecimal;
            LinksAngleTextBox.Text = Vstring;
        }

        // Rechts Angle
        //-------------------------
        private void RechtsAngleIncreaseButton_Click(object sender, EventArgs e)
        {
            SetupRechtsAngle(sender);
        }

        private void RechtsAngleDecreaseButton_Click(object sender, EventArgs e)
        {
            SetupRechtsAngle(sender);
        }

        private void RechtsAngleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                SetupRechtsAngle(sender);
            }
        }

        private void SetupRechtsAngle(object sender)
        {
            if (stages.RotRe.State != MotorStates.Idle)
                return;


            //Inhalt der Textbox als double j
            double j = 0;
            if (!double.TryParse(RechtsAngleTextBox.Text, out j))
            {
                j = -1;
            }

            //Definitionen und Formeln
            double V = j;

            if (sender == RechtsAngleDecreaseButton)
                V -= 1;
            else if (sender == RechtsAngleIncreaseButton)
                V += 1;

            //Maximum des Vergenzwinkels
            if (V > 45)
            {
                V = 45;
            }

            //Minimum des Vergenzwinkels
            if (V < -45)
            {
                V = -45;
            }

            //Definitionen und Formeln
            decimal Vdecimal = Convert.ToDecimal(V);
            string Vstring = Convert.ToString(V);

            //Bewegungsbefehle Rotation
            stages.RotRe.SetVelocityParams(100, 1000);

            if (Vdecimal < 0)
            {
                stages.RotRe.MoveTo(90, p => stages.RotRe.MoveTo(-Vdecimal, 0));
            }
            else
            {
                stages.RotRe.MoveTo(90, p => stages.RotRe.MoveTo(360 - Vdecimal, 0));
            }

            RechtsAngleZero = Vdecimal;
            RechtsAngleTextBox.Text = Vstring;
        }
    }
}
