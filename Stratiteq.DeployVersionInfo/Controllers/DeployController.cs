using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Http;
using Stratiteq.DeployVersionInfo.Models;

namespace Stratiteq.DeployVersionInfo.Controllers
{
    public class DeployController : ApiController
    {
        // GET: api/Deploy
        public IEnumerable<DeployVersion> Get()
        {
            var versionInfoFolder = @"\\strwebapp\c$\inetpub\BITSFolder\versioninfo";
            var list = new List<DeployVersion>();
            var filesInVersionFolder = Directory.GetFiles(versionInfoFolder);
            foreach (var filename in filesInVersionFolder)
            {
                var siteList = new List<DeployVersion>();
                using (var file = File.OpenRead(filename))
                {
                    var streamReader = new StreamReader(file);
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length == 0) continue;            
                        var lineItems = line.Split(',');                        
                        if (lineItems.Count() > 1)
                        {
                            var changedDateString = lineItems[0].Substring(0, lineItems[0].Length - 14);
                            changedDateString = changedDateString.Replace('T', ' ');
                            changedDateString = changedDateString.Replace('.', ':');
                            var changedOn = DateTime.Parse(changedDateString);
                            var siteName = filename.Split('\\').LastOrDefault();
                            siteName = siteName.Split('.').FirstOrDefault();                            
                            siteList.Add(new DeployVersion() { SiteName = siteName, UpdatedOn = changedOn, Version = new ApplicationVersion(lineItems[1]) });
                        }                        
                    }
                    if (siteList.Any())
                    {
                        list.Add(siteList.Last());
                    }
                }                    
            }

            return list;
        }        
    }


}
