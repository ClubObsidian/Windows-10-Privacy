using NLog;
using System;
using System.IO;
using System.Text;

namespace WindowsTenPrivacy.PrivacyComponent
{
    class EtcHosts : IPrivacyComponent
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        private readonly string[] disallowedHosts = new string[]
        {
            "a-0001.a-msedge.net",
            "choice.microsoft.com",
            "choice.microsoft.com.nsatc.net",
            "compatexchange.cloudapp.net",
            "corp.sts.microsoft.com",
            "corpext.msitadfs.glbdns2.microsoft.com",
            "cs1.wpc.v0cdn.net",
            "df.telemetry.microsoft.com",
            "diagnostics.support.microsoft.com",
            "fe2.update.microsoft.com.akadns.net",
            "feedback.microsoft-hohm.com",
            "feedback.search.microsoft.com",
            "feedback.windows.com",
            "i1.services.social.microsoft.com",
            "i1.services.social.microsoft.com.nsatc.net",
            "oca.telemetry.microsoft.com",
            "oca.telemetry.microsoft.com.nsatc.net",
            "pre.footprintpredict.com",
            "redir.metaservices.microsoft.com",
            "reports.wes.df.telemetry.microsoft.com",
            "services.wes.df.telemetry.microsoft.com",
            "settings-sandbox.data.microsoft.com",
            "sls.update.microsoft.com.akadns.net",
            "sqm.df.telemetry.microsoft.com",
            "sqm.telemetry.microsoft.com",
            "sqm.telemetry.microsoft.com.nsatc.net",
            "statsfe1.ws.microsoft.com",
            "statsfe2.update.microsoft.com.akadns.net",
            "statsfe2.ws.microsoft.com",
            "survey.watson.microsoft.com",
            "telecommand.telemetry.microsoft.com",
            "telecommand.telemetry.microsoft.com.nsatc.net",
            "telemetry.appex.bing.net",
            "telemetry.microsoft.com",
            "telemetry.urs.microsoft.com",
            "vortex-sandbox.data.microsoft.com",
            "vortex-win.data.microsoft.com",
            "watson.live.com",
            "watson.microsoft.com",
            "watson.ppe.telemetry.microsoft.com",
            "watson.telemetry.microsoft.com",
            "watson.telemetry.microsoft.com.nsatc.net",
            "wes.df.telemetry.microsoft.com",
            "vortex.data.microsoft.com"
        };

        private string beginMark = "# ----- BEGIN WINDOWS 10 PRIVACY -----";
        private string endMark = "# ----- END WINDOWS 10 PRIVACY -----";
        private string etcHostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");

        // TODO: This method
        public bool AlreadyBlocked()
        {
            return File.ReadAllText(etcHostsPath).Contains(beginMark);
        }

        public void AppendEntriesToHostFile()
        {
            logger.Info("Blocking hosts in host file...");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine(beginMark);
            foreach (var host in disallowedHosts)
            {
                sb.AppendFormat("0.0.0.0        {0}{1}", host, Environment.NewLine);
            }
            sb.AppendLine(endMark);

            try
            {
                StreamWriter writer = File.AppendText(etcHostsPath);
                writer.Write(sb.ToString());
                writer.Close();
            }
            catch (Exception ex)
            {
                logger.Error("Could not block hosts: {0}", ex.ToString());
            }
        }

        public void Remove()
        {
            if (AlreadyBlocked())
            {
                logger.Info("/etc/hosts file already contains all Windows 10 Privacy entries, skipping.");
                return;
            }

            AppendEntriesToHostFile();
        }
    }
}
