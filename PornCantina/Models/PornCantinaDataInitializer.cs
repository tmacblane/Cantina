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
		protected override void Seed(PornCantinaContext context)
		{
			var webSites = new List<WebSite>
            {
                // Bella Pass
                new WebSite { Id = Guid.NewGuid(), Name = "Bryci.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.Bryci.com", RSSFeed = "http://www.bellacash.com/xrss/bryci/all/2348773/feed.rss" },
                new WebSite { Id = Guid.NewGuid(), Name = "KatieBanks.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.KatieBanks.com", RSSFeed = "http://www.bellacash.com/xrss/katiebanks/all/2348773/feed.rss" },
                new WebSite { Id = Guid.NewGuid(), Name = "TaliaShepard.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.TaliaShepard.com", RSSFeed = "http://www.bellacash.com/xrss/taliashepard/all/2348773/feed.rss" },
                new WebSite { Id = Guid.NewGuid(), Name = "AvaDawn.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.AvaDawn.com", RSSFeed = "http://www.bellacash.com/xrss/avadawn/all/2348773/feed.rss" },
                new WebSite { Id = Guid.NewGuid(), Name = "MonroeLee.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.MonroeLee.com", RSSFeed = "http://www.bellacash.com/xrss/monroelee/all/2348773/feed.rss" },
                new WebSite { Id = Guid.NewGuid(), Name = "BellaCash.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=911444&PA=2348773&HTML=http://www.BellaCash.com", RSSFeed = null },
                
                // Solo Revenue
                new WebSite { Id = Guid.NewGuid(), Name = "AutumnRiley.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=942306&PA=2348773&HTML=http://www.autumnriley.com", RSSFeed = null },
                new WebSite { Id = Guid.NewGuid(), Name = "NatashaBelle.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=942306&PA=2348773&HTML=http://www.natashabelle.com/tour/", RSSFeed = null },
            
                // ZellysCash
                // MelissaXoXo
                // BluEyedCass
                // Zellys.com

				// Pink Velvet Pass
				new WebSite { Id = Guid.NewGuid(), Name = "BellaXOXO.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://bellaxoxo.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "BrianaLeeExtreme.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brianaleeextreme.com", RSSFeed = null },
				new WebSite	{ Id = Guid.NewGuid(), Name = "BrianaLeeOnline.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brianaleeonline.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "Brittany-Avalon.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brittany-avalon.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "CherryZips.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://cherryzips.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "KendraRain.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://kendrarain.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "LynnPops.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://lynnpops.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "MeetMadden.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://meetmadden.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "NikkisPlaymates.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://nikkisplaymates.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "RadiantDesire.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://radiantdesire.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "Sockblocked.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://sockblocked.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "TaylorTrue.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://taylortrue.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "TiffanyAlexis.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://tiffanyalexis.com", RSSFeed = null },

				new WebSite { Id = Guid.NewGuid(), Name = "BrokeAndHot.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://brokeandhot.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "PinkVelvetPass.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://pinkvelvetpass.com", RSSFeed = null },
				new WebSite { Id = Guid.NewGuid(), Name = "PeekForFree.com", ReferralLink = "http://refer.ccbill.com/cgi-bin/clicks.cgi?CA=933914&PA=2348773&HTML=http://peekforfree.com", RSSFeed = null }
            };

			webSites.ForEach(r => context.WebSites.Add(r));
			context.SaveChanges();

			var models = new List<Model>
            {
                new Model { Id = Guid.NewGuid(), Name = "Bryci", WebSiteId = webSites[0].Id },
                new Model { Id = Guid.NewGuid(), Name = "Katie Banks", WebSiteId = webSites[1].Id },
                new Model { Id = Guid.NewGuid(), Name = "Talia Shepard", WebSiteId = webSites[2].Id },
                new Model { Id = Guid.NewGuid(), Name = "Ava Dawn", WebSiteId = webSites[3].Id },
                new Model { Id = Guid.NewGuid(), Name = "Monroe Lee", WebSiteId = webSites[4].Id },
                new Model { Id = Guid.NewGuid(), Name = "Autumn Riley", WebSiteId = webSites[6].Id },
                new Model { Id = Guid.NewGuid(), Name = "Natasha Belle", WebSiteId = webSites[7].Id },
				new Model { Id = Guid.NewGuid(), Name = "Bella XOXO", WebSiteId = webSites[8].Id },
				new Model { Id = Guid.NewGuid(), Name = "Briana Lee Extreme", WebSiteId = webSites[9].Id },
				new Model { Id = Guid.NewGuid(), Name = "Briana Lee Online", WebSiteId = webSites[10].Id },
				new Model { Id = Guid.NewGuid(), Name = "Brittany Avalon", WebSiteId = webSites[11].Id },
				new Model { Id = Guid.NewGuid(), Name = "Cherry Zips", WebSiteId = webSites[12].Id },
				new Model { Id = Guid.NewGuid(), Name = "Kendra Rain", WebSiteId = webSites[13].Id },
				new Model { Id = Guid.NewGuid(), Name = "Lynn Pops", WebSiteId = webSites[14].Id },
				new Model { Id = Guid.NewGuid(), Name = "Meet Madden", WebSiteId = webSites[15].Id },
				new Model { Id = Guid.NewGuid(), Name = "Nikkis Sims", WebSiteId = webSites[16].Id },
				new Model { Id = Guid.NewGuid(), Name = "Radiant Desire", WebSiteId = webSites[17].Id },
				new Model { Id = Guid.NewGuid(), Name = "Sock Blocked", WebSiteId = webSites[18].Id },
				new Model { Id = Guid.NewGuid(), Name = "Taylor True", WebSiteId = webSites[19].Id },
				new Model { Id = Guid.NewGuid(), Name = "Tiffany Alexis", WebSiteId = webSites[20].Id },
            };

			models.ForEach(m => context.Models.Add(m));

			// Create Model Folder(s)
			foreach(var model in models)
			{
				string basePath = @"Content\Images";
				DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);
				dInfo.CreateSubdirectory(model.Name.Replace(" ", string.Empty));
			}

			context.SaveChanges();

			//#region Autumn Riley Galleries

			//var autumnRileyGalleries = new List<Gallery>
			//{
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Naked With Pigtails", Folder = "68_nakedwithpigtails", DatePublished = DateTime.Parse("07/11/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Black & Pink Apron", Folder = "67_blackpinkapron", DatePublished = DateTime.Parse("06/15/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Computer Chair", Folder  = "66_computerchair", DatePublished = DateTime.Parse("05/15/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Beautiful Tits", Folder  = "65_beautifultits", DatePublished = DateTime.Parse("05/03/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink Underwear", Folder  = "64_pinkunderwear", DatePublished = DateTime.Parse("04/28/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Black & Blue Bra", Folder  = "63_bluebra", DatePublished = DateTime.Parse("04/03/120122"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Top Shower", Folder  = "62_bluetopshower", DatePublished = DateTime.Parse("03/25/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Purple Dress Part II", Folder  = "61_purpledress", DatePublished = DateTime.Parse("03/10/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink Toy and Colorful Socks", Folder  = "60_toyandsocks", DatePublished = DateTime.Parse("03/03/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Polkadots & Pigtails", Folder  = "59_polkadotsandpigtails", DatePublished = DateTime.Parse("02/11/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Ducati", Folder  = "58_ducati", DatePublished = DateTime.Parse("01/30/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Red Jersey", Folder  = "57_redjersey", DatePublished = DateTime.Parse("01/14/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "White Pullups", Folder  = "56_whitepullups", DatePublished = DateTime.Parse("01/04/2012"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Shirt", Folder  = "55_blueshirt", DatePublished = DateTime.Parse("12/23/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Lollipop", Folder  = "54_colorfulsocks", DatePublished = DateTime.Parse("12/14/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Bike Mechanic", Folder  = "53_bikemechanic", DatePublished = DateTime.Parse("12/12/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "White Panties", Folder  = "52_whitepanties", DatePublished = DateTime.Parse("12/07/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink Underwear & Glasses", Folder  = "51_pinkunderwearkitchen", DatePublished = DateTime.Parse("11/22/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink Nighty", Folder  = "50_pinknighty", DatePublished = DateTime.Parse("11/07/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Purple Bra in Kitchen", Folder  = "49_purplekitchen", DatePublished = DateTime.Parse("11/01/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Red Yamaha", Folder  = "48_redyamaha", DatePublished = DateTime.Parse("10/20/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "White Blanket", Folder  = "47_whiteblanket", DatePublished = DateTime.Parse("10/20/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Soccer Jersey", Folder  = "46_blueandyellow", DatePublished = DateTime.Parse("10/14/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Red Sox", Folder  = "45_redsox", DatePublished = DateTime.Parse("10/07/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Bubble Bath (Part II)", Folder  = "44_bathtubpart2", DatePublished = DateTime.Parse("10/02/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Purple Dress", Folder  = "43_purpledress", DatePublished = DateTime.Parse("09/26/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Black & Pink", Folder  = "42_blackpink", DatePublished = DateTime.Parse("09/18/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink Bra Kitchen", Folder  = "41_pinkbra", DatePublished = DateTime.Parse("09/14/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Tight Black Shirt", Folder  = "40_blackshirt", DatePublished = DateTime.Parse("09/07/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Lingerie", Folder  = "39_bluelingerie", DatePublished = DateTime.Parse("09/03/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Bubble Bath", Folder  = "38_bathtub", DatePublished = DateTime.Parse("08/29/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "White Couch", Folder  = "37_whitecouch", DatePublished = DateTime.Parse("08/25/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pool Table", Folder  = "36_pooltable", DatePublished = DateTime.Parse("08/19/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Jeans n Black Shirt", Folder  = "35_jeansblackshirt", DatePublished = DateTime.Parse("08/09/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Short Hair", Folder  = "34_redbed", DatePublished = DateTime.Parse("07/31/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Tank Top Bed", Folder  = "33_bluetanktopbed", DatePublished = DateTime.Parse("07/23/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Outfit on Chair", Folder  = "32_blueinchair", DatePublished = DateTime.Parse("07/15/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Booty Shorts n' Glasses", Folder  = "31_greyshortsglasses", DatePublished = DateTime.Parse("07/10/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink n' Blue", Folder  = "30_pinknblue", DatePublished = DateTime.Parse("07/01/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Red Wall", Folder  = "29_redwall", DatePublished = DateTime.Parse("06/24/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Naked in Kitchen", Folder  = "28_kitchen", DatePublished = DateTime.Parse("06/18/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Candid Bathroom Pix", Folder  = "27_candidbathroom", DatePublished = DateTime.Parse("07/10/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Tank Top", Folder  = "26_bluetanktop", DatePublished = DateTime.Parse("06/02/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Underwear", Folder  = "25_blueunderwear", DatePublished = DateTime.Parse("05/26/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Colorful Socks", Folder  = "24_colorful", DatePublished = DateTime.Parse("05/25/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Bathroom", Folder  = "23_bathroom", DatePublished = DateTime.Parse("05/16/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Red Wall n' Glasses", Folder  = "22_redwallglasses", DatePublished = DateTime.Parse("05/11/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Old Tub", Folder  = "21_oldtub", DatePublished = DateTime.Parse("05/06/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue & White Bed", Folder  = "20_blueandwhite", DatePublished = DateTime.Parse("05/01/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Living Room Couch - Part II", Folder  = "19_livingroomcouch", DatePublished = DateTime.Parse("04/25/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Living Room Couch", Folder  = "18_livingroomcouch", DatePublished = DateTime.Parse("04/25/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Boat", Folder  = "17_boat", DatePublished = DateTime.Parse("04/13/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Top Railing", Folder  = "16_toprailing", DatePublished = DateTime.Parse("04/07/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Kitchen In Pink", Folder  = "15_kitcheninpink", DatePublished = DateTime.Parse("04/06/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "White and Pink Outfit", Folder  = "14_whitepink", DatePublished = DateTime.Parse("03/25/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Brown Corset", Folder  = "13_browncorset", DatePublished = DateTime.Parse("03/18/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Cute In Blue", Folder  = "12_cuteinblue", DatePublished = DateTime.Parse("03/18/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Polkadots", Folder  = "11_polkadots", DatePublished = DateTime.Parse("03/18/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Sexy Glasses", Folder  = "10_glasses", DatePublished = DateTime.Parse("03/11/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Cute Toque", Folder  = "09_toque", DatePublished = DateTime.Parse("03/06/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Poker Table", Folder  = "08_pokertable", DatePublished = DateTime.Parse("02/27/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Shower", Folder  = "07_shower", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Red Wall Black Bookcase", Folder  = "06_redblackbookcase", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Bra n Panties", Folder  = "05_blueoutfitbed", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Pink Jacuzzi", Folder  = "04_pinkjacuzzi", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Blue Underwear Bed", Folder  = "03_blueunderwearbed", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Autumn & Friend Fire", Folder  = "02_autumnandfriend", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[5].Id, Title = "Autumn & Friend Bed", Folder  = "01_autumnandfriend", DatePublished = DateTime.Parse("02/21/2011"), IsActive = false, Rating = 0 }
			//};

			//autumnRileyGalleries.ForEach(g => context.Galleries.Add(g));

			//// Create Gallery Folder(s)
			//foreach (var gallery in autumnRileyGalleries)
			//{
			//    string basePath = string.Format(@"Content\Images\{0}", models[5].Name.Replace(" ", string.Empty));
			//    DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);
			//    dInfo.CreateSubdirectory(gallery.Folder);
			//}

			//context.SaveChanges();

			//#endregion

			//#region Natasha Belle Galleries

			//var natashaBelleGalleries = new List<Gallery>
			//{
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Striped Tanktop", Folder = "38_stripedtanktop", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Pink T-Shirt", Folder = "37_pinktshirt", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Lingerie On Floor", Folder = "36_lingeriefloor", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Red Couch", Folder = "35_redcouch", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Green White Bed", Folder = "34_greenwhitebed", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Kitchen Plaid", Folder = "33_kitchenplaid", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Orange Poolside", Folder = "32_orangepoolside", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "White Jacket Blue Bra", Folder = "31_whitejacketbluebra", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "White Lingerie", Folder = "30_whitelingerie", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Magazine", Folder = "29_magazine", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Knee High Socks", Folder = "28_kneehighsocks", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Green Pool", Folder = "27_greenpool", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Coffee Table Strip", Folder = "26_coffeetable", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Kitchen Chair Strip", Folder = "25_kitchenchair", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Plaid Underwear", Folder = "24_plaidunderwear", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Fuschia Dress", Folder = "23_fuschiadress", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Kitchen Strip", Folder = "22_kitchenstrip", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Hot Tub Strip", Folder = "21_hottub", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Chair Strip", Folder = "20_chair", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Pink & Yellow", Folder = "19_pinkandyellow", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Blue Couch", Folder = "18_bluecouch", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "White Jacket Red Bra", Folder = "17_whitejacketredbra", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Striped Booty Shorts", Folder = "16_stripedbootyshorts", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "On Floor in Panties", Folder = "15_onfloorinpanties", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Schoolgirl", Folder = "14_schoolgirl", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Pool Floatie", Folder = "13_poolfloatie", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Pool at Night", Folder = "12_nightpool", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Pink Shirt", Folder = "11_pinkshirt", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Laptop", Folder = "10_laptop", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Pink Bra", Folder = "09_pinkbra", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Red Dress", Folder = "08_reddress", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Naked on Floor", Folder = "07_nakedonfloor", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "I Love Pink", Folder = "06_ilovepink", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Black & Blue", Folder = "05_blackandblue", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Sexy in Orange", Folder = "04_sexyinorange", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Poolside", Folder = "03_poolsidestrip", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Candid Bedroom Pix", Folder = "02_candidbedroom", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 },
			//    new Gallery { Id = Guid.NewGuid(), ModelId = models[6].Id, Title = "Blue & White", Folder = "01_blueandwhite", DatePublished = DateTime.Parse(""), IsActive = false, Rating = 0 }
			//};

			//natashaBelleGalleries.ForEach(g => context.Galleries.Add(g));

			//// Create Gallery Folder(s)
			//foreach (var gallery in natashaBelleGalleries)
			//{
			//    string basePath = string.Format(@"Content\Images\{0}", models[6].Name.Replace(" ", string.Empty));
			//    DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);
			//    dInfo.CreateSubdirectory(gallery.Folder);
			//}

			//context.SaveChanges();

			//#endregion
		}
	}
}