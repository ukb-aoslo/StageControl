using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.GenericMotorCLI;
using Thorlabs.MotionControl.GenericMotorCLI.ControlParameters;
using Thorlabs.MotionControl.GenericMotorCLI.AdvancedMotor;
using Thorlabs.MotionControl.GenericMotorCLI.KCubeMotor;
using Thorlabs.MotionControl.GenericMotorCLI.Settings;
using Thorlabs.MotionControl.KCube.DCServoCLI;


namespace StageControl
{
    static class Program
    {
        public class Stages
        {

            static String KDC101_left = "27253437";
            static String KDC101_right = "27253406";
            static String KBD101_left = "28250835";
            static String KBD101_right = "28250713";

            public void init()
            {

                KCubeDCServo device_A = KCubeDCServo.CreateKCubeDCServo(KDC101_left);

                if (device_A == null)

                {
                    MessageBox.Show("Device A is not a KDC101");
                }

                KCubeDCServo device_B = KCubeDCServo.CreateKCubeDCServo(KDC101_right);

                if (device_B == null)
                {
                    MessageBox.Show("Device B is not a KDC101");
                }

                // Open a connection to the device.

                try
                {
                    device_A.Connect(KDC101_left);
                }

                catch (Exception)
                {
                    // Connection failed
                    MessageBox.Show("Failed to open device A");
                }

                try
                {
                    device_B.Connect(KDC101_right);
                }

                catch (Exception)
                {
                    // Connection failed
                    MessageBox.Show("Failed to open device B");
                }


            }

        }


        public static Stages stages = new Stages();
        stages.init();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                // build device list
                DeviceManagerCLI.BuildDeviceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception raised by BuildDeviceList {0}", ex.ToString());
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());

            //decimal value = device_A.GetMoveAbsolutePosition();

            //guitdevice_A.SetMoveAbsolutePosition(40);


        }
    }
}
