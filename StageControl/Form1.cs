﻿using System;
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
        
        //Home Button Position
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Bewegungsbefehle
            stages.LinLi.Home(0);
            stages.LinRe.Home(0);
        }

        //Textbox Augenabstand
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {
                //Geschwindigkeit einstellen
                stages.LinLi.SetVelocityParams(400, 400);
                stages.LinRe.SetVelocityParams(400, 400);

                //No Backlash
                stages.LinLi.SetBacklash(0);
                stages.LinRe.SetBacklash(0);

                //Inhalt der Textbox als int i
                int i = 0;
                if (!Int32.TryParse(textBox1.Text, out i))
                {
                    i = -1;
                }

                //Definitionen und Formeln
                int Augenabstand = i;
                int Augenposition = (300 - Augenabstand) / 2;

                //Bewegungsbefehle
                stages.LinLi.MoveTo(Augenposition, 0);
                stages.LinRe.MoveTo(Augenposition, 0);
            }
        }

        //Home Button Winkel
        private void button3_Click(object sender, EventArgs e)
        {
            stages.RotLi.Home(0);
            stages.RotRe.Home(0);
        }

        //Textbox Vergenzwinkel
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bestätigen der Eingabe mit Enter
            if (e.KeyChar == (char)13)
            {

                //Inhalt der Textbox als int i
                int i = 0;
                if (!Int32.TryParse(textBox2.Text, out i))
                {
                    i = -1;
                }

                //Definitionen und Formeln
                int Vergenzwinkel = i;
                
                //Bewegungsbefehle
                stages.RotLi.MoveTo(Vergenzwinkel, 0);
                stages.RotRe.MoveTo(360 - Vergenzwinkel, 0);
            }
        }
    }
}
