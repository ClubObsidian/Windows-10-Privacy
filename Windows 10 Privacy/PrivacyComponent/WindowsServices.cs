using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTenPrivacy.PrivacyComponent
{
    class WindowsServices : IPrivacyComponent
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void Remove()
        {
            stopDmwappushsvc();
            stopTrackingService();
            disableAutoLogger();
            disableTelemetry();
        }

        private void stopTrackingService()
        {
            logger.Info("Stopping Diagnostics Tracking Service if running");
            Process[] procs = Process.GetProcessesByName("Diagnostics Tracking Service");
            if (procs.Length > 0)
            {
                Process process = procs[0];
                if (process != null)
                {
                    process.Kill();
                }
            }
            logger.Info("Disabling tracking service");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\DiagTrack", "Start", 0);
        }

        private void disableAutoLogger()
        {
            logger.Info("Disabling AutoLogger");
            try
            {
                FileStream stream = File.Open("C:\\ProgramData\\Microsoft\\Diagnosis\\ETLLogs\\AutoLogger\\AutoLogger-Diagtrack-Listener.etl", FileMode.Open);
                stream.Close();
                System.Diagnostics.Process.Start("echo y | cacls C:\\ProgramData\\Microsoft\\Diagnosis\\ETLLogs\\AutoLogger\\AutoLogger - Diagtrack - Listener.etl / d SYSTEM");
            }
            catch (IOException ex)
            {
                logger.Error("Could not stop autologger: {0}", ex.ToString());
            }
        }

        private void disableTelemetry()
        {
            logger.Info("Disabling telemtry");
            try
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", "AllowTelemetry", 0);
            }
            catch (Exception ex)
            {
                logger.Error("Could not disable telemetry: {0}", ex.ToString());
            }
        }

        private void stopDmwappushsvc()
        {
            logger.Info("Stopping dmwappushsvc if running");
            Process[] procs = Process.GetProcessesByName("dmwappushsvc");
            if (procs.Length > 0)
            {
                Process process = procs[0];
                if (process != null)
                {
                    process.Kill();
                }
            }

            logger.Info("Disabling dmwappushsvc");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dmwappushsvc", "Start", 0);
        }
    }
}
