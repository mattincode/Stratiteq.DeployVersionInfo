using System;
using System.Collections.Generic;
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
                            string pattern = "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'";

                            //DateTimeOffset changedOn = DateTimeOffset.ParseExact(lineItems[0], pattern, CultureInfo.InvariantCulture);
                            var siteName = filename.Split('\\').LastOrDefault();
                            siteName = siteName.Split('.').FirstOrDefault();
                            var changedOn = new DateTimeOffset(DateTime.Now);
                            siteList.Add(new DeployVersion() { SiteName = siteName, UpdatedOn = changedOn.LocalDateTime, Version = new ApplicationVersion(lineItems[1]) });
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
