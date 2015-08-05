using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

/*
    Inspired by the program here: https://github.com/10se1ucgo/DisableWinTracking
    I decided to simplify the process and make it in C# because I have a strong disdain for python
    Credit for finding all the registery keys and ips to block goes to the author of the code linked above
*/


namespace Windows_10_Privacy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.disableAutoLogger();
            this.disableTelemetry();
            this.blockHosts();
            this.stopDmwappushsvc();
            this.stopTrackingService();
            MessageBox.Show("Done");
        }

        private void disableAutoLogger()
        {
            this.logInfo("Disabling autologger");
            try
            {
                FileStream stream = File.Open("C:\\ProgramData\\Microsoft\\Diagnosis\\ETLLogs\\AutoLogger\\AutoLogger-Diagtrack-Listener.etl", FileMode.Open);
                stream.Close();
                System.Diagnostics.Process.Start("CMD.exe", "echo y | cacls C:\\ProgramData\\Microsoft\\Diagnosis\\ETLLogs\\AutoLogger\\AutoLogger - Diagtrack - Listener.etl / d SYSTEM");
            }
            catch(IOException ex)
            {
                this.logInfo("Autologger not found skipping");
            }
        }

        private void disableTelemetry()
        {
            this.logInfo("Disabling telemtry");
            try {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", "AllowTelemetry", 0);
            }
            catch(Exception ex)
            {
                this.logInfo("Could not disable telemetry");
            }
        }

        private void blockHosts()
        {
            this.logInfo("Blocking hosts in host file");
            string line = Environment.NewLine;
            string hosts = "0.0.0.0 vortex.data.microsoft.com" + line + "0.0.0.0 vortex-win.data.microsoft.com"  + line +  
                "0.0.0.0 telecommand.telemetry.microsoft.com"  + line +  "0.0.0.0 telecommand.telemetry.microsoft.com.nsatc.net"  + line +  
                "0.0.0.0 oca.telemetry.microsoft.com"  + line +  "0.0.0.0 oca.telemetry.microsoft.com.nsatc.net"  + line +  
                "0.0.0.0 sqm.telemetry.microsoft.com"  + line +  "0.0.0.0 sqm.telemetry.microsoft.com.nsatc.net"  + line +  
                "0.0.0.0 watson.telemetry.microsoft.com"  + line +  "0.0.0.0 watson.telemetry.microsoft.com.nsatc.net"  + line +  
                "0.0.0.0 redir.metaservices.microsoft.com"  + line +  "0.0.0.0 choice.microsoft.com"  + line +  
                "0.0.0.0 choice.microsoft.com.nsatc.net"  + line +  "0.0.0.0 df.telemetry.microsoft.com"  + line +  
                "0.0.0.0 reports.wes.df.telemetry.microsoft.com"  + line +  "0.0.0.0 wes.df.telemetry.microsoft.com"  + line +  
                "0.0.0.0 services.wes.df.telemetry.microsoft.com"  + line +  "0.0.0.0 sqm.df.telemetry.microsoft.com"  + line +  
                "0.0.0.0 telemetry.microsoft.com"  + line +  "0.0.0.0 watson.ppe.telemetry.microsoft.com"  + line +  
                "0.0.0.0 telemetry.appex.bing.net"  + line +  "0.0.0.0 telemetry.urs.microsoft.com"  + line +  
                "0.0.0.0 telemetry.appex.bing.net:443"  + line +  "0.0.0.0 settings-sandbox.data.microsoft.com"  + line +  
                "0.0.0.0 vortex-sandbox.data.microsoft.com"  + line +  "0.0.0.0 survey.watson.microsoft.com"  + line +  
                "0.0.0.0 watson.live.com"  + line +  "0.0.0.0 watson.microsoft.com"  + line +  "0.0.0.0 statsfe2.ws.microsoft.com"  + line +  
                "0.0.0.0 corpext.msitadfs.glbdns2.microsoft.com"  + line +  "0.0.0.0 compatexchange.cloudapp.net"  + line +  
                "0.0.0.0 cs1.wpc.v0cdn.net"  + line +  "0.0.0.0 a-0001.a-msedge.net"  + line +  
                "0.0.0.0 statsfe2.update.microsoft.com.akadns.net"  + line +  "0.0.0.0 sls.update.microsoft.com.akadns.net"  + line +  
                "0.0.0.0 fe2.update.microsoft.com.akadns.net"  + line +  "0.0.0.0 65.55.108.23 "  + line +  "0.0.0.0 65.39.117.230"  + line +  
                "0.0.0.0 23.218.212.69 "  + line +  "0.0.0.0 134.170.30.202"  + line +  "0.0.0.0 137.116.81.24"  + line +  
                "0.0.0.0 diagnostics.support.microsoft.com"  + line +  "0.0.0.0 corp.sts.microsoft.com"  + line +  
                "0.0.0.0 statsfe1.ws.microsoft.com"  + line +  "0.0.0.0 pre.footprintpredict.com"  + line +  "0.0.0.0 204.79.197.200"  + line +  
                "0.0.0.0 23.218.212.69"  + line +  "0.0.0.0 i1.services.social.microsoft.com"  + line +  
                "0.0.0.0 i1.services.social.microsoft.com.nsatc.net"  + line +  "0.0.0.0 feedback.windows.com"  + line +  
                "0.0.0.0 feedback.microsoft-hohm.com"  + line +  "0.0.0.0 feedback.search.microsoft.com";
            try {
                StreamWriter writer = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts"));
                writer.Write(hosts);
                writer.Close();
            }
            catch(IOException e)
            {
                this.logInfo("Could not block hosts");
            }
        }

        private void stopDmwappushsvc()
        {
            this.logInfo("Stopping dmwappushsvc if running");
            Process[] procs = Process.GetProcessesByName("dmwappushsvc");
            if (procs.Length > 0)
            {
                Process process = procs[0];
                if (process != null)
                {
                    process.Kill();
                }
            }
            this.logInfo("Disabling dmwappushsvc");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dmwappushsvc", "Start", 0);
        }

        private void stopTrackingService()
        {
            this.logInfo("Stopping Diagnostics Tracking Service if running");
            Process[] procs = Process.GetProcessesByName("Diagnostics Tracking Service");
            if (procs.Length > 0)
            {
                Process process = procs[0];
                if (process != null)
                {
                    process.Kill();
                }
            }
            this.logInfo("Disabling tracking service");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\DiagTrack", "Start", 0);
        }


        private void logInfo(string info)
        {
            this.richTextBox1.AppendText("[" + System.DateTime.UtcNow.ToString() + "] " + info + "\n");
        }
    }
}
