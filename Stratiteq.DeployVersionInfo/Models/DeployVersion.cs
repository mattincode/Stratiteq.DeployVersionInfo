using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace Stratiteq.DeployVersionInfo.Models
{
    public class DeployVersion
    {
        public string SiteName { get; set; }

        public DateTime UpdatedOn { get; set; }

        public ApplicationVersion Version { get; set; }

        public List<DeployVersion> Versions { get; set; }

        public string ToolTip
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (Versions != null && Versions.Count > 0)
                {
                    
                    foreach (var version in Versions)
                    {
                        sb.AppendLine(string.Format("{0} \t {1}\t{2} {3}", version.SiteName, version.UpdatedOn, version.Version.Version, version.Version.BuildTimeText));
                    }                    
                }
                return sb.ToString();
            }
        }
    }

    public class ApplicationVersion
    {
        private string _version = string.Empty;

        public string BuildTimeText { get { return GetBuildTime().ToString(CultureInfo.CurrentCulture); } }

        public DateTime BuildTime { get { return GetBuildTime(); } }

        public ApplicationVersion(string version)
        {
            _version = version;
        }

        public string Version
        {
            get
            {
                String version = GetVersion();                
                var substring = version.Split('.');
                return string.Format("v{0}.{1}", substring[0], substring[1]);
            }
        }

        public string Build
        {
            get
            {
                String version = GetVersion();                
                return version.Split('.')[2];
            }
        }

        public string Revision
        {
            get
            {
                String version = GetVersion();                
                return version.Split('.')[3];
            }
        }

        private DateTime GetBuildTime()
        {
            DateTime buildTime = DateTime.MinValue;
            int buildNumber = 0;
            int revisionNo = 0;
            if (int.TryParse(Build, out buildNumber) && int.TryParse(Revision, out revisionNo))
            {
                buildTime = new DateTime(2000, 1, 1).AddDays(buildNumber).AddSeconds(revisionNo * 2).AddHours(1);
            }
            return buildTime;
        }

        private string GetVersion()
        {
            return _version;
        }

    }
}