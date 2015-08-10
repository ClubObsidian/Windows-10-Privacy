using Microsoft.Win32;
using NLog;
using System;
using System.Diagnostics;
using System.IO;

namespace WindowsTenPrivacy.PrivacyComponent
{
    class OneDrive : IPrivacyComponent
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        private void KillProcesses()
        {
            Process[] procs = Process.GetProcessesByName("OneDrive");
            foreach (var proc in procs)
            {
                if (proc != null)
                {
                    proc.Kill();
                }
            }
        }

        private void DeleteRegistryKeys()
        {
            RegistryKey reg;
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "OneDrive", "");

            if (Environment.Is64BitOperatingSystem)
            {
                reg = Registry.ClassesRoot.OpenSubKey("Wow6432Node\\CLSID", true);
                if (reg != null)
                {
                    reg.DeleteSubKeyTree("{018D5C66-4533-4307-9B53-224DE2ED1FE6}");
                }
                return;
            }

            reg = Registry.ClassesRoot.OpenSubKey("CLSID", true);
            if (reg != null)
            {
                reg.DeleteSubKeyTree("{018D5C66-4533-4307-9B53-224DE2ED1FE6}");
            }
        }

        public string DeleteFolder()
        {
            string oneDrivePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Local", "Microsoft", "OneDrive"
            );
            Directory.Delete(oneDrivePath);
            return oneDrivePath;
        }

        public void Remove()
        {
            try
            {
                logger.Info("Killing any running OneDrive processes...");
                KillProcesses();
                logger.Info("Successfully killed running OneDrive processes");
            }
            catch(Exception ex)
            {
                logger.Error("Could not kill running OneDrive processes: {0}", ex.ToString());
            }

            try
            {
                logger.Info("Removing OneDrive keys from registry...");
                DeleteRegistryKeys();
                logger.Info("Successfully removed OneDrive keys from registry");
            }
            catch (Exception ex)
            {
                logger.Error("Could not remove OneDrive keys from registry: {0}", ex.ToString());
            }

            try
            {
                logger.Info("Deleting OneDrive folder completely...");
                string oneDrivePath = DeleteFolder();
                logger.Info("Successfully deleted OneDrive folder '{0}'", oneDrivePath);
            }
            catch (Exception ex)
            {
                logger.Error("Could not delete OneDrive folder: {0}", ex.ToString());
            }
        }
    }
}