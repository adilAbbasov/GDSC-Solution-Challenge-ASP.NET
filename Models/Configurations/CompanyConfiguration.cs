using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Models.Entity;
using System.Net;

namespace PhotoHome.Models.Configurations
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public int Index { get; set; } = 1;

		public void Configure(EntityTypeBuilder<Company> builder)
		{
			Uri url = new("https://www.humanrightscareers.com/issues/organizations-dedicated-to-fight-poverty/");

			WebClient client = new();
			string html = client.DownloadString(url);
			
			HtmlAgilityPack.HtmlDocument document = new();

			document.LoadHtml(html);
			var nodes = document.DocumentNode.SelectNodes("//p");

			List<string> abouts = new();

			foreach (var item in nodes)
			{
				abouts.Add(item.InnerText);
			}

			abouts.Add("At Orphans in Need, we believe that every child in the world deserves the right to a happy, safe and healthy life. \r\n\tWe focus on sustainable solutions to support the neediest around the world.\r\n\r\n\tOrphans in Need cares for more than 30,000 orphans and their families in 14 countries. \r\n\tThey are focused on providing sustainable solutions to help those most in need. \r\n\tOrphans in Need provide areas facing poverty with regular food parcels, access to education, medical attention, and safe and caring homes for orphans. \r\n\tThey want to create a world where a loving environment where everyone can be happier and healthier is the norm.");

			abouts.Add("\tStreet Child provides support of all kinds, from children’s education and counselling to business training and mentoring, for families in poverty-stricken regions across Asia, Africa, and the Middle East. \r\n\tTheir mission is to give every child a chance at a safe and happy life.\r\n\r\n\tThey are experts in education, economic empowerment and protection programming. \r\n\tTheir interventions are integrated to confront challenges, assuring safety as we afford access to schooling.\r\n\tBy coupling instantaneous change for children with an increase in the capacities of caregivers, communities and schools they support children to be safe, in school and learning in the long term.");


			builder.HasData(new Company { Id = ((Index++).ToString()).ToString(), Name = "Oxfam International", SiteUrl = "https://www.oxfam.org/", VideoUrl = "https://www.youtube.com/embed/3TlucE_-kRw", LogoUrl = "https://www.oxfamamerica.org/documents/536/OX_HL_C_RGB.png", About = abouts[Index - 1], Email = "info@oxfam.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "The Organization for Poverty Alleviation and Development", SiteUrl = "http://www.opadint.org/", VideoUrl = "https://www.youtube.com/embed/4XUd7xbOYYU", LogoUrl = "https://static.wixstatic.com/media/002cd6_937d4903f0fd45949fee3cc2e4f037eb~mv2.png/v1/crop/x_57,y_0,w_1701,h_783/fill/w_482,h_204,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/logo-2_edited.png", About = abouts[Index - 1], Email = "info@opad.eu", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Concern Worldwide", SiteUrl = "https://concernworldwide.org/", VideoUrl = "https://www.youtube.com/embed/oGqDyoTcDKk", LogoUrl = "https://getlogovector.com/wp-content/uploads/2020/04/concern-worldwide-logo-vector.png", About = abouts[Index - 1], Email = "info@concern.net", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "End Poverty Now", SiteUrl = "https://endpovertynowinc.org/", VideoUrl = "https://www.youtube.com/embed/N6UqjIwfz3k", LogoUrl = "https://endpovertynowinc.org/wp-content/uploads/2022/10/cropped-EPN_Logo_white.png", About = abouts[Index - 1], Email = "info@endpovertynowinc.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Global Citizen", SiteUrl = "https://www.globalcitizen.org/en/", VideoUrl = "https://www.youtube.com/embed/JhlQKgiJH00", LogoUrl = "https://static.globalcitizen.org/static/img/gc-logo-no-space.png", About = abouts[Index - 1], Email = "info@globalcitizen.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "World Relief", SiteUrl = "https://worldrelief.org/", VideoUrl = "https://www.youtube.com/embed/Z3-1SfRTwGc", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1b/World_Relief.jpg", About = abouts[Index - 1], Email = "info@worldrelief.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Care International", SiteUrl = "https://www.care-international.org/", VideoUrl = "https://www.youtube.com/embed/iiMQ8CVWRkY", LogoUrl = "https://landportal.org/sites/landportal.org/files/styles/220heightmax/public/care-social-image.jpg", About = abouts[Index - 1], Email = "info@care.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Institute for Research on Poverty", SiteUrl = "https://www.irp.wisc.edu/", VideoUrl = "https://www.youtube.com/embed/LuWcDAKld24", LogoUrl = "https://www.irp.wisc.edu/wp/wp-content/uploads/2018/04/IRP-2018b.png", About = abouts[Index - 1], Email = "irpweb@ssc.wisc.edu", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Innovations for Poverty Action", SiteUrl = "https://www.poverty-action.org/", VideoUrl = "https://www.youtube.com/embed/jmtMf6VJklI", LogoUrl = "https://poverty-action.org/sites/default/files/atoms/image/2020/12/17/IPA-Africa-RGB.jpg", About = abouts[Index - 1], Email = "info@poverty-action.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Muslim Hands", SiteUrl = "https://muslimhands.org.uk/", VideoUrl = "https://www.youtube.com/embed/17X67AojG84", LogoUrl = "https://www.backabuddy.co.za/misc/charity/65cecd293579b98e57c8230a1908cca9.jpg", About = abouts[Index - 1], Email = "mail@muslimhands.org.uk", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "BRAC", SiteUrl = "http://www.brac.net/", VideoUrl = "https://www.youtube.com/embed/7Sih7Og4-30", LogoUrl = "http://www.brac.net/images/brac-logo-big.png", About = abouts[Index - 1], Email = "info@brac.net", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "European Anti-Poverty Network", SiteUrl = "https://www.eapn.eu/", VideoUrl = "https://www.youtube.com/embed/rmSWZOFo8Uk", LogoUrl = "https://www.eapn.eu/wp-content/uploads/2015/10/logo-eapn-grand.jpg", About = abouts[Index - 1], Email = "info@eapn.eu", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "The Borgen Project", SiteUrl = "https://borgenproject.org/", VideoUrl = "https://www.youtube.com/embed/3Tj7r8IU_Kg", LogoUrl = "https://borgenproject.org/wp-content/uploads/1-copy.jpg", About = abouts[Index - 1], Email = "info@borgenproject.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Advocates for International Development", SiteUrl = "http://www.a4id.org/", VideoUrl = "https://www.youtube.com/embed/FfHwGF_RL9A", LogoUrl = "https://yt3.ggpht.com/ytc/AMLnZu-i4mcY3cgy3aXmtCOA5aIa2Eacuq-xsku5L8To4w=s900-c-k-c0x00ffffff-no-rj", About = abouts[Index - 1], Email = "info@a4id.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Green Shots Foundation", SiteUrl = "https://greenshootsfoundation.org/", VideoUrl = "https://www.youtube.com/embed/f9dWTTEED14", LogoUrl = "https://greenshootsfoundation.org/wp-content/uploads/2020/10/greenshoots-logo-10years.png", About = abouts[Index - 1], Email = "info@greenshootsfoundation.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "International Child Care", SiteUrl = "http://www.internationalchildcare.org/", VideoUrl = "https://www.youtube.com/embed/sDXYG277hm4", LogoUrl = "https://images.squarespace-cdn.com/content/v1/54d6624ae4b0249186209c53/1498321453884-3M69SNTGNDLPN4OC05HI/GCHiccLogo-CMYK-Enlarged.png", About = abouts[Index - 1], Email = "iccusa@internationalchildcare.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "ONE", SiteUrl = "https://www.one.org/", VideoUrl = "https://www.youtube.com/embed/rWoSsKiIcD0", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/8/82/ONE-Logo.png", About = abouts[Index - 1], Email = "info@one.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Engineers Without Borders International", SiteUrl = "http://ewb-international.com/", VideoUrl = "https://www.youtube.com/embed/0yztUcfSdws", LogoUrl = "https://ewb-ye.org/wp-content/uploads/2022/06/ewb-logo-new-1-2-2-copy2.png", About = abouts[Index - 1], Email = "info@ewb-international.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "World Vision", SiteUrl = "https://www.worldvision.org/", VideoUrl = "https://www.youtube.com/embed/nCVWcQnDX8I", LogoUrl = "https://logos-download.com/wp-content/uploads/2016/12/World_Vision_logo_logotype.png", About = abouts[Index - 1], Email = "info@worldvision.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "World Hope International", SiteUrl = "https://www.worldhope.org/", VideoUrl = "https://www.youtube.com/embed/8yVFTw3qAgU", LogoUrl = "https://www.pngitem.com/pimgs/m/366-3661876_world-hope-international-logo-hd-png-download.png", About = abouts[Index - 1], Email = "info@worldhope.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Village Enterprise", SiteUrl = "http://villageenterprise.org/", VideoUrl = "https://www.youtube.com/embed/jo8Zcw465SI", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d5/VE-Logo_Primary2400_RGB.png", About = abouts[Index - 1], Email = "info@villageenterprise.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Trickle Up", SiteUrl = "https://trickleup.org/", VideoUrl = "https://www.youtube.com/embed/4fMMQKYejPQ", LogoUrl = "https://trickleup.org/wp-content/uploads/2020/09/LogoIndigoOrangeLarge.png", About = abouts[Index - 1], Email = "info@trickleup.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "RESULTS", SiteUrl = "https://results.org/", VideoUrl = "https://www.youtube.com/embed/m7M1i1Kf3oY", LogoUrl = "https://cdn.resultscanada.ca/wp-content/uploads/Results-Logo-ID-1.png", About = abouts[Index - 1], Email = "info@results.org", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Orphans in Need", SiteUrl = "https://www.orphansinneed.org.uk/", VideoUrl = "https://www.youtube.com/embed/WMolKf7iap0", LogoUrl = " https://images.jg-cdn.com/image/e9987b3e-fa5a-4a55-a79f-01f4338a679d.jpg", About = abouts[Index - 1], Email = "info@orphansinneed.org.uk", Allow = true });
			builder.HasData(new Company { Id = (Index++).ToString(), Name = "Street Child", SiteUrl = "https://street-child.org/", VideoUrl = "https://www.youtube.com/embed/SZtYxanbZKE", LogoUrl = "https://images.squarespace-cdn.com/content/v1/5612639be4b0b2769222579e/1444046635914-WNI5KS1NUD9417IGSVRA/STREETCHILD+FB.jpg", About = abouts[Index - 1], Email = "info@street-child.org", Allow = true });
		}
	}
}
