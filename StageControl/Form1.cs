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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String param = e.ToString();
            stages.device_A.MoveTo(10, 1000);
        }

    }
}
