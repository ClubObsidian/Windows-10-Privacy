using Microsoft.Win32;
using NLog;
using NLog.Windows.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;
using WindowsTenPrivacy.PrivacyComponent;

namespace WindowsTenPrivacy
{
    public partial class frmMain : Form
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RichTextBoxTarget target = new RichTextBoxTarget();
            target.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";
            target.ControlName = "rchtxtLogMessages";
            target.FormName = "frmMain";
            target.UseDefaultRowColoringRules = true;

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Trace);
        }

        private void btnGetPrivacy_Click(object sender, EventArgs e)
        {
            foreach (CheckBox c in grpPrivacyOptions.Controls.OfType<CheckBox>())
            {
                logger.Info("Component {0} value: {1}", c.Text, c.Checked.ToString());
                if (c.Checked && c.Tag != null)
                {
                    Type componentType = Type.GetType("WindowsTenPrivacy.PrivacyComponent." + c.Tag.ToString());
                    IPrivacyComponent priv = (IPrivacyComponent)Activator.CreateInstance(componentType);
                    priv.Remove();
                }
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110 - 1301, USA.", "About Windows 10 Privacy");
        }
    }
}
