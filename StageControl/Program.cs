using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.GenericMotorCLI;
using Thorlabs.MotionControl.GenericMotorCLI.ControlParameters;
using Thorlabs.MotionControl.GenericMotorCLI.AdvancedMotor;
using Thorlabs.MotionControl.GenericMotorCLI.KCubeMotor;
using Thorlabs.MotionControl.GenericMotorCLI.Settings;
using Thorlabs.MotionControl.KCube.DCServoCLI;


namespace StageControl
{

    class Stages
    {

        static String KDC101_left = "27253437";
        static String KDC101_right = "27253406";
        static String KBD101_left = "28250835";
        static String KBD101_right = "28250713";

        public KCubeDCServo LinLi;
        public KCubeDCServo LinRe;

        public MotorConfiguration motorConfiguration_A;


        public void init() {
            LinLi = KCubeDCServo.CreateKCubeDCServo(KDC101_left);

            if (LinLi == null)

            {
                MessageBox.Show("Device A is not a KDC101");
            }

            LinRe = KCubeDCServo.CreateKCubeDCServo(KDC101_right);

            if (LinRe == null)
            {
                MessageBox.Show("Device B is not a KDC101");
            }

            // Open a connection to the device.

            try
            {
                LinLi.Connect(KDC101_left);
            }

            catch (Exception)
            {
                // Connection failed
                MessageBox.Show("Failed to open device A");
            
            }

            try
            {
                LinRe.Connect(KDC101_right);
            }

            catch (Exception)
            {
                // Connection failed
                MessageBox.Show("Failed to open device B");
           
            }

            // Wait for the device settings to initialize - timeout 5000ms
            LinLi.WaitForSettingsInitialized(5000);
            LinRe.WaitForSettingsInitialized(5000);

            // Initialize the DeviceUnitConverter object required for real world
            // unit parameters.
            LinLi.LoadMotorConfiguration(KDC101_left, DeviceConfiguration.DeviceSettingsUseOptionType.UseFileSettings);
            LinRe.LoadMotorConfiguration(KDC101_right, DeviceConfiguration.DeviceSettingsUseOptionType.UseFileSettings);

            // Start the device polling
            // The polling loop requests regular status requests to the motor to ensure the program keeps track of the device. 
            LinLi.StartPolling(250);
            LinRe.StartPolling(250);
            // Needs a delay so that the current enabled state can be obtained
            Thread.Sleep(500);
            // Enable the channel otherwise any move is ignored 
            LinLi.EnableDevice();
            LinRe.EnableDevice();
            // Needs a delay to give time for the device to be enabled
            Thread.Sleep(500);
         

        }



    }



    static class Program
{

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

        //decimal value = LinLi.GetMoveAbsolutePosition();

        //guitLinLi.SetMoveAbsolutePosition(40);


    }
}
}
