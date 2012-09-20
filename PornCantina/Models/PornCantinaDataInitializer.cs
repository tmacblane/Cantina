using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PornCantina.Models;
using System.IO;

namespace PornCantina.DAL
{
	public class PornCantinaDataInitializer : DropCreateDatabaseIfModelChanges<PornCantinaContext>
	{
	//    protected override void Seed(PornCantinaContext context)
	//    {
	//        var webSites = new List<WebSite>
	//        {
	//            // Bella Pass
	//            new WebSite { Id = Guid.NewGuid(), Name = "Bryci.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.Bryci.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "KatieBanks.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.KatieBanks.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "TaliaShepard.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.TaliaShepard.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "AvaDawn.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.AvaDawn.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "MonroeLee.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.MonroeLee.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "BellaCash.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.BellaCash.com" },
                
	//            // Solo Revenue
	//            new WebSite { Id = Guid.NewGuid(), Name = "AutumnRiley.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=942306&PA=2348773&HTML=http://www.autumnriley.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "NatashaBelle.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=942306&PA=2348773&HTML=http://www.natashabelle.com/tour/" },
            
	//            // ZellysCash
	//            // MelissaXoXo
	//            // BluEyedCass
	//            // Zellys.com

	//            // Pink Velvet Pass
	//            new WebSite { Id = Guid.NewGuid(), Name = "BellaXOXO.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://bellaxoxo.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "BrianaLeeExtreme.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brianaleeextreme.com" },
	//            new WebSite	{ Id = Guid.NewGuid(), Name = "BrianaLeeOnline.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brianaleeonline.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "Brittany-Avalon.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brittany-avalon.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "CherryZips.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://cherryzips.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "KendraRain.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://kendrarain.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "LynnPops.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://lynnpops.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "MeetMadden.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://meetmadden.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "NikkisPlaymates.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://nikkisplaymates.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "RadiantDesire.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://radiantdesire.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "Sockblocked.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://sockblocked.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "TaylorTrue.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://taylortrue.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "TiffanyAlexis.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://tiffanyalexis.com" },

	//            new WebSite { Id = Guid.NewGuid(), Name = "BrokeAndHot.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brokeandhot.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "PinkVelvetPass.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://pinkvelvetpass.com" },
	//            new WebSite { Id = Guid.NewGuid(), Name = "PeekForFree.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://peekforfree.com" }
	//        };

	//        webSites.ForEach(r => context.WebSites.Add(r));
	//        context.SaveChanges();

	//        var models = new List<Model>
	//        {
	//            new Model { Id = Guid.NewGuid(), Name = "Bryci", WebSiteId = webSites[0].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Katie Banks", WebSiteId = webSites[1].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Talia Shepard", WebSiteId = webSites[2].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Ava Dawn", WebSiteId = webSites[3].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Monroe Lee", WebSiteId = webSites[4].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Autumn Riley", WebSiteId = webSites[6].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Natasha Belle", WebSiteId = webSites[7].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Bella XOXO", WebSiteId = webSites[8].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Briana Lee Extreme", WebSiteId = webSites[9].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Briana Lee Online", WebSiteId = webSites[10].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Brittany Avalon", WebSiteId = webSites[11].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Cherry Zips", WebSiteId = webSites[12].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Kendra Rain", WebSiteId = webSites[13].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Lynn Pops", WebSiteId = webSites[14].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Meet Madden", WebSiteId = webSites[15].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Nikkis Sims", WebSiteId = webSites[16].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Radiant Desire", WebSiteId = webSites[17].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Sock Blocked", WebSiteId = webSites[18].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Taylor True", WebSiteId = webSites[19].Id },
	//            new Model { Id = Guid.NewGuid(), Name = "Tiffany Alexis", WebSiteId = webSites[20].Id },
	//        };

	//        models.ForEach(m => context.Models.Add(m));

	//        // Create Model Folder(s)
	//        foreach(var model in models)
	//        {
	//            string basePath = @"Content\Images";
	//            DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);
	//            dInfo.CreateSubdirectory(model.Name.Replace(" ", string.Empty));
	//        }

	//        context.SaveChanges();
	//    }
	}
}