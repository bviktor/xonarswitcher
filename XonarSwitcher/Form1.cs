using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;


namespace XonarSwitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;

            ContextMenu context = new ContextMenu();
            context.MenuItems.Add(0, new MenuItem("Switch to Headphones", new System.EventHandler(switchToHeadphones)));
            context.MenuItems.Add(1, new MenuItem("Switch to Speakers", new System.EventHandler(switchToSpeakers)));
            context.MenuItems.Add(2, new MenuItem("Exit", new System.EventHandler(Exit_Click)));

            //mynotifyicon.Visible = true;
            //mynotifyicon.ShowBalloonTip(500);
            notifyIcon1.ContextMenu = context;
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //#2 speakers
            //"SpeakerConfig"=hex:04,00,00,00
            //#headphones
            //"SpeakerConfig"=hex:01,00,00,00
            RegistryKey RegKeyWrite = Registry.LocalMachine;

            RegKeyWrite = RegKeyWrite.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E96C-E325-11CE-BFC1-08002BE10318}\\0007\\Settings");
            if (radioButton1.Checked)
            {
                RegKeyWrite.SetValue("SpeakerConfig", new byte[] { 01, 00, 00, 00 }, RegistryValueKind.Binary);
            }
            else
            {
                RegKeyWrite.SetValue("SpeakerConfig", new byte[] { 04, 00, 00, 00 }, RegistryValueKind.Binary);
            }
            
            RegKeyWrite.Close();

            //devcon disable "PCI\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00"
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "devcon.exe";
            startInfo.Arguments = "disable \"PCI\\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
            System.Threading.Thread.Sleep(500);
            startInfo.Arguments = "enable \"PCI\\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00\"";
            Process.Start(startInfo);
            MessageBox.Show("Success!");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
        }

        private void switchToHeadphones(Object sender, System.EventArgs e)
        {
            RegistryKey RegKeyWrite = Registry.LocalMachine;

            RegKeyWrite = RegKeyWrite.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E96C-E325-11CE-BFC1-08002BE10318}\\0007\\Settings");
            RegKeyWrite.SetValue("SpeakerConfig", new byte[] { 01, 00, 00, 00 }, RegistryValueKind.Binary);
            RegKeyWrite.Close();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "devcon.exe";
            startInfo.Arguments = "disable \"PCI\\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
            System.Threading.Thread.Sleep(500);
            startInfo.Arguments = "enable \"PCI\\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00\"";
            Process.Start(startInfo);
            MessageBox.Show("Success!");
        }

        private void switchToSpeakers(Object sender, System.EventArgs e)
        {
            RegistryKey RegKeyWrite = Registry.LocalMachine;

            RegKeyWrite = RegKeyWrite.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E96C-E325-11CE-BFC1-08002BE10318}\\0007\\Settings");
            RegKeyWrite.SetValue("SpeakerConfig", new byte[] { 04, 00, 00, 00 }, RegistryValueKind.Binary);
            RegKeyWrite.Close();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "devcon.exe";
            startInfo.Arguments = "disable \"PCI\\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
            System.Threading.Thread.Sleep(500);
            startInfo.Arguments = "enable \"PCI\\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00\"";
            Process.Start(startInfo);
            MessageBox.Show("Success!");
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        this.notifyIcon1.Dispose(); //we dispose our tray icon here

        //    }
        //    base.Dispose(disposing);
        //}
    }
}
