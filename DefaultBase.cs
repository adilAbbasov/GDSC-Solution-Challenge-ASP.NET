using System.Net;

namespace PhotoHome.Models.Configurations
{
    public class Default
    {
        public Dictionary<string, List<string>> GetDict()
        {
            Uri url = new("https://burst.shopify.com/");
            WebClient client = new();

            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            var nodes = document.DocumentNode.SelectNodes("//a[@class='photo-card__link-overlay']");
            string fullUrl = "https://burst.shopify.com/";

            Dictionary<string, List<string>> dictionary = new();
            List<string> list = new();

            foreach (var src in nodes)
            {
                int count = 0;
                string link = fullUrl + src.Attributes["href"].Value;

                Uri secondUrl = new(link);
                WebClient secondClient = new();

                string secondHtml = secondClient.DownloadString(secondUrl);
                HtmlAgilityPack.HtmlDocument secondDocument = new();
                secondDocument.LoadHtml(secondHtml);

                var option = secondDocument.DocumentNode.SelectNodes("//a[@class='photo-tile__image-wrapper']");

                foreach (var item in option)
                {
                    try
                    {
                        if (count == 10) 
                            break;

                        list.Add(item.Attributes["href"].Value);
                        count++;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            foreach (var item in list)
            {
                string link = fullUrl + item;

                Uri url_2 = new Uri(link);
                WebClient client_2 = new WebClient();

                string html_2 = client_2.DownloadString(url_2);
                HtmlAgilityPack.HtmlDocument dokuman_2 = new HtmlAgilityPack.HtmlDocument();
                dokuman_2.LoadHtml(html_2);

                var option = dokuman_2.DocumentNode.SelectNodes("//a[@class='nowrap']");
                List<string> tags = new List<string>();

                int index = 1;

                if (option == null)
                {
                    dictionary.Add(link, tags);
                    continue;
                }
                foreach (var im in option)
                {
                    try
                    {
                        if (im.InnerText == null) break;
                        tags.Add(im.InnerText);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Thread.Sleep(20);
                }

                dictionary.Add(link, tags);
                
                Console.WriteLine("----------------------------------");
                Console.WriteLine(index++);
            }

            return dictionary;
        }

        public List<string> GetTagNames()
        {
            List<string> lazim = new();

            lazim.Add("Architecture");

            lazim.Add("City");
            lazim.Add("Backgrounds");
            lazim.Add("Sale");
            lazim.Add("Store");
            lazim.Add("Market");
            lazim.Add("Local");
            lazim.Add("AroundtheWorld");
            lazim.Add("Asia");
            lazim.Add("LunarNewYear");
            lazim.Add("China");
            lazim.Add("Fashion");
            lazim.Add("Travel");
            lazim.Add("Trip");
            lazim.Add("Dancing");
            lazim.Add("Earth");
            lazim.Add("Diwali");
            lazim.Add("MobileBackgrounds");
            lazim.Add("CoolBackground");
            lazim.Add("India");
            lazim.Add("Rocks");
            lazim.Add("Outdoor");
            lazim.Add("Hiking");
            lazim.Add("Iceland");
            lazim.Add("Walk");
            lazim.Add("Hill");
            lazim.Add("Green");
            lazim.Add("Nature");
            lazim.Add("Adventure");
            lazim.Add("Landscape");
            lazim.Add("USA");
            lazim.Add("GrandCanyon");
            lazim.Add("Arizona");
            lazim.Add("America");
            lazim.Add("Mountain");
            lazim.Add("Spring");
            lazim.Add("Sunrise");
            lazim.Add("Morning");
            lazim.Add("Village");
            lazim.Add("Japan");
            lazim.Add("Path");
            lazim.Add("Men");
            lazim.Add("Friends");
            lazim.Add("People");
            lazim.Add("Water");
            lazim.Add("Lake");
            lazim.Add("Boat");
            lazim.Add("Ocean");
            lazim.Add("Home");
            lazim.Add("House");
            lazim.Add("Building");
            lazim.Add("Sea");
            lazim.Add("California");
            lazim.Add("GoodMorning");
            lazim.Add("Sun");
            lazim.Add("Walls");
            lazim.Add("Paris");
            lazim.Add("Light");
            lazim.Add("Window");
            lazim.Add("France");
            lazim.Add("Flowers");
            lazim.Add("Laptop");
            lazim.Add("Computer");
            lazim.Add("Keyboard");
            lazim.Add("Meetings");
            lazim.Add("Presentation");
            lazim.Add("Furniture");
            lazim.Add("Room");
            lazim.Add("Livingroom");
            lazim.Add("HomeOffice");
            lazim.Add("FlowerBackground");
            lazim.Add("Women");
            lazim.Add("Business");
            lazim.Add("Office");
            lazim.Add("Writing");
            lazim.Add("Camera");
            lazim.Add("Technology");
            lazim.Add("Desk");
            lazim.Add("Professional");
            lazim.Add("Calendar");
            lazim.Add("Youngadult");
            lazim.Add("Homedecor");
            lazim.Add("Work");
            lazim.Add("Entrepreneur");
            lazim.Add("Businesswoman");
            lazim.Add("Women&#39;sDay");
            lazim.Add("Books");
            lazim.Add("Design");
            lazim.Add("Minimalist");
            lazim.Add("White");
            lazim.Add("GraphicDesigner");
            lazim.Add("Creative");
            lazim.Add("Photographer");
            lazim.Add("Startup");
            lazim.Add("Ideas");
            lazim.Add("Education");
            lazim.Add("Reading");
            lazim.Add("Hands");
            lazim.Add("Couple");
            lazim.Add("Jewelry");
            lazim.Add("Love");
            lazim.Add("Bracelet");
            lazim.Add("Necklace");
            lazim.Add("Accessories");
            lazim.Add("Romantic");
            lazim.Add("MentalHealth");
            lazim.Add("Portraits");
            lazim.Add("Emotion");
            lazim.Add("Sad");
            lazim.Add("Motivation");
            lazim.Add("Success");
            lazim.Add("Inspirational");
            lazim.Add("Community");
            lazim.Add("Ribbons");
            lazim.Add("Relax");
            lazim.Add("Models");
            lazim.Add("LetterBoard");
            lazim.Add("BlackandWhite");
            lazim.Add("Help");
            lazim.Add("Black");
            lazim.Add("Fitness");
            lazim.Add("Yoga");
            lazim.Add("Children");
            lazim.Add("Sports");
            lazim.Add("Family");
            lazim.Add("Mom");
            lazim.Add("Gym");
            lazim.Add("Exercise");
            lazim.Add("Body-positivity");
            lazim.Add("Body");
            lazim.Add("Wellness");
            lazim.Add("MothersDay");
            lazim.Add("Workout");
            lazim.Add("Strength");
            lazim.Add("Leadership");
            lazim.Add("Life");
            lazim.Add("Teamwork");
            lazim.Add("Team");
            lazim.Add("Crossfit");
            lazim.Add("Run");
            lazim.Add("Athlete");
            lazim.Add("Soccer");
            lazim.Add("Field");
            lazim.Add("Suits");
            lazim.Add("Businessman");
            lazim.Add("UrbanLife");
            lazim.Add("Street");
            lazim.Add("Future");
            lazim.Add("Night");
            lazim.Add("School");
            lazim.Add("Science");
            lazim.Add("Lab");
            lazim.Add("Dogs");
            lazim.Add("Animals");
            lazim.Add("Pets");
            lazim.Add("Pets&amp;Animals");
            lazim.Add("Seasons");
            lazim.Add("Pillow");
            lazim.Add("Arts");
            lazim.Add("Environment");
            lazim.Add("Flatlay");
            lazim.Add("Thanksgiving");
            lazim.Add("Dessert");
            lazim.Add("HappyHolidays");
            lazim.Add("Pumpkin");
            lazim.Add("Vegetables");
            lazim.Add("Harvest");
            lazim.Add("ValentinesDay");
            lazim.Add("Trees");
            lazim.Add("Forest");
            lazim.Add("LoveBackground");
            lazim.Add("Leaves");
            lazim.Add("Drinks");
            lazim.Add("Pink");
            lazim.Add("Tea");
            lazim.Add("TeaCup");
            lazim.Add("Ice");
            lazim.Add("Table");
            lazim.Add("Wood");
            lazim.Add("CoffeeCup");
            lazim.Add("Music");
            lazim.Add("Restaurant");
            lazim.Add("Plants");
            lazim.Add("Tattoo");
            lazim.Add("PersononComputer");
            lazim.Add("SocialMedia");
            lazim.Add("Kitchen");
            lazim.Add("Breakfast");
            lazim.Add("Talking");
            lazim.Add("Conversation");
            lazim.Add("Bedroom");
            lazim.Add("Apartment");
            lazim.Add("bed");
            lazim.Add("Cats");
            lazim.Add("VideoCallBackgrounds");
            lazim.Add("Colourful");
            lazim.Add("Rainbow");
            lazim.Add("Baby");
            lazim.Add("Craft/DIY");
            lazim.Add("Cooking");
            lazim.Add("Hug");
            lazim.Add("iPhone");
            lazim.Add("Phones&amp;Cases");
            lazim.Add("ThoughtCatalog");
            lazim.Add("Hair");
            lazim.Add("Beauty");
            lazim.Add("Haircut");
            lazim.Add("Painting");
            lazim.Add("Canvas");
            lazim.Add("Rose");
            lazim.Add("Bouquet");
            lazim.Add("Red");
            lazim.Add("Makeup");
            lazim.Add("Cosmetics");
            lazim.Add("Watch");
            lazim.Add("JustAddWater");
            lazim.Add("Lipstick");
            lazim.Add("Fun");
            lazim.Add("Blue");
            lazim.Add("Lips");
            lazim.Add("HealthyLifestyle");
            lazim.Add("Toronto");
            lazim.Add("Skyline");
            lazim.Add("Health");
            lazim.Add("GoodVibes");
            lazim.Add("Cloud");
            lazim.Add("Basketball");
            lazim.Add("Winter");
            lazim.Add("Weather");
            lazim.Add("PinkBackground");
            lazim.Add("WeightLoss");
            lazim.Add("Pants");
            lazim.Add("ColorBackgrounds");
            lazim.Add("Park");
            lazim.Add("Profile");
            lazim.Add("Communication");
            lazim.Add("Marketing");
            lazim.Add("Ecommerce");
            lazim.Add("GraphicDesign");
            lazim.Add("Globe");
            lazim.Add("Drawing");
            lazim.Add("Graph");
            lazim.Add("Hootsuite");
            lazim.Add("Christmas");
            lazim.Add("Holidays");
            lazim.Add("Kids");
            lazim.Add("Boys");
            lazim.Add("Happy");
            lazim.Add("Father");
            lazim.Add("Newborn");
            lazim.Add("Feet");
            lazim.Add("Sleep");
            lazim.Add("Skincare");
            lazim.Add("Skin");
            lazim.Add("FeelGoodPhotos");
            lazim.Add("Cute");
            lazim.Add("Toys");
            lazim.Add("Playtime");
            lazim.Add("Student");
            lazim.Add("BacktoSchool");
            lazim.Add("Classroom");
            lazim.Add("Summer");
            lazim.Add("Girls");
            lazim.Add("Dress");
            lazim.Add("Gifts");
            lazim.Add("ChristmasTree");
            lazim.Add("Holiday");
            lazim.Add("Hat");
            lazim.Add("Wallpapers");
            lazim.Add("Textures");
            lazim.Add("Abstract");
            lazim.Add("Pattern");
            lazim.Add("Sky");
            lazim.Add("Space");
            lazim.Add("Stars");
            lazim.Add("Sunset");
            lazim.Add("Desert");
            lazim.Add("Wave");
            lazim.Add("SignLanguage");
            lazim.Add("Clothes");
            lazim.Add("Leather");
            lazim.Add("Shopify");
            lazim.Add("Glasses");
            lazim.Add("Shoes");
            lazim.Add("Floral");
            lazim.Add("Shipping");
            lazim.Add("Box");
            lazim.Add("Celebrate");
            lazim.Add("Vintage");
            lazim.Add("Alcohol");
            lazim.Add("Bike");
            lazim.Add("Bridges");
            lazim.Add("Wedding");
            lazim.Add("Bride");
            lazim.Add("Vacation");
            lazim.Add("SanFrancisco");
            lazim.Add("Gold");
            lazim.Add("Sound");
            lazim.Add("Headphones");
            lazim.Add("Online");
            lazim.Add("Pug");
            lazim.Add("Internet");
            lazim.Add("Tablets");
            lazim.Add("Data");
            lazim.Add("Diversity");
            lazim.Add("Beard");
            lazim.Add("Boho");
            lazim.Add("Hipster");
            lazim.Add("Tie");
            lazim.Add("Neon");
            lazim.Add("Shirt");
            lazim.Add("Barbershop");
            lazim.Add("Yellow");
            lazim.Add("YellowBackground");
            lazim.Add("Rain");
            lazim.Add("Reflection");
            lazim.Add("Blur-Background");
            lazim.Add("Energy");
            lazim.Add("Smoke");
            lazim.Add("Orange");
            lazim.Add("Silver");
            lazim.Add("Fruit");
            lazim.Add("BlackFridayCyberMonday");
            lazim.Add("Shopping");
            lazim.Add("Retail");
            lazim.Add("BFCM");
            lazim.Add("Trabalhodecasa");
            lazim.Add("Planning");
            lazim.Add("Camping");
            lazim.Add("Bag");
            lazim.Add("Backpack");
            lazim.Add("Farm");
            lazim.Add("Waterfalls");
            lazim.Add("Egg");
            lazim.Add("Shop");
            lazim.Add("Dinner");
            lazim.Add("Pizza");
            lazim.Add("Pasta");
            lazim.Add("Products");
            lazim.Add("Luxury");
            lazim.Add("Clock");
            lazim.Add("Time");
            lazim.Add("Numbers");
            lazim.Add("Digitaldownloads");
            lazim.Add("OnlineShopping");
            lazim.Add("Handbag");
            lazim.Add("T-Shirts");
            lazim.Add("Ring");
            lazim.Add("Marriage");
            lazim.Add("Arrow");
            lazim.Add("Mexico");
            lazim.Add("Spain");
            lazim.Add("Bird");
            lazim.Add("Australia");
            lazim.Add("Duck");
            lazim.Add("CuteAnimals");
            lazim.Add("Zoo");
            lazim.Add("Octopus");
            lazim.Add("Funny");
            lazim.Add("Puppy");
            lazim.Add("Eagle");
            lazim.Add("Grass");
            lazim.Add("Meditation");
            lazim.Add("Calm");
            lazim.Add("Rivers");
            lazim.Add("Stretch");
            return lazim;

        }
        public List<string> GetImages()
        {

            Uri url = new Uri("https://burst.shopify.com/");

            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            List<string> list = new List<string>();
            //HtmlAgilityPack.HtmlNodeCollection basliqlar = document.DocumentNode.SelectNodes("//section//a");
            int number = 0;
            //var nodes = document.DocumentNode.SelectNodes("//a//img[@class='ez-resource-thumb__img']");
            var nodes = dokuman.DocumentNode.SelectNodes("//a[@class='photo-card__link-overlay']");
            string tam_link = "https://burst.shopify.com/";
            //*[@id="app"]/div/div[3]/div[2]/div/div/div/div[2]/figure[1]/div/div/a/div/div[2]/img

            List<string> images = new List<string>();
            foreach (var src in nodes)
            {
                int count = 0;
                string link = tam_link + src.Attributes["href"].Value;


                Uri url_2 = new Uri(link);

                WebClient client_2 = new WebClient();
                string html_2 = client_2.DownloadString(url_2);
                HtmlAgilityPack.HtmlDocument dokuman_2 = new HtmlAgilityPack.HtmlDocument();
                dokuman_2.LoadHtml(html_2);
                var option = dokuman_2.DocumentNode.SelectNodes("//img");

                foreach (var im in option)
                {

                    if (count == 10) break;
                    images.Add(im.Attributes["src"].Value);
                    Console.WriteLine(im.Attributes["src"].Value);
                    count++;
                }




            }
            Console.WriteLine(images.Count);
            return images;

        }

        public List<string> GetDescription()
        {
            List<string> list = new List<string>();

            list.Add("            Chinese shop exterior glows with red lanterns at dusk                                                                                                                                                                                                                                              ");
            list.Add("With the low lying sun casting an orange haze through the fog, a woman in a red dress dances on the foggy banks of a river in India, through the fog we can see temples on the other side of the water                                                                                                         ");
            list.Add("The heat of the jungle kept off his brow by wearing a loose headwrap, a man pulls branches aside as he explores the lush jungle                                                                                                                                                                                ");
            list.Add("Hiker looking up, taking every detail of nature into consideration                                                                                                                                                                                                                                             ");
            list.Add("Curvy, water - worn rocks of the Grand Canyon                                                                                                                                                                                                                                                                  ");
            list.Add("A hiker with a blanket draped over their shoulders looks out over a bay surrounded by steep cliffs and mountain peaks                                                                                                                                                                                          ");
            list.Add("A man wanders the red archways of a traditional Japanese pathway                                                                                                                                                                                                                                               ");
            list.Add("A view of people on a long boat travelling across calm green waters                                                                                                                                                                                                                                            ");
            list.Add("This house in the sea is where you want to be while it soaks up the sea view in the morning sun                                                                                                                                                                                                                ");
            list.Add("The glassy walls of the Louvre Pyramid stand out in this image                                                                                                                                                                                                                                                 ");
            list.Add("A person sits on her living room couch and looks to be talking to there laptop screen                                                                                                                                                                                                                          ");
            list.Add("Top view of a person dressed in black is laying down on their stomach as they write in a notebook from a white duvet covered bed                                                                                                                                                                               ");
            list.Add("A woman works on her laptop while sitting on a comfy window seat                                                                                                                                                                                                                                               ");
            list.Add("A woman immersed in her laptop and PC gets to work in her home office bathed in natural light                                                                                                                                                                                                                  ");
            list.Add("A man&#39;s left-hand holds a tablet against his left leg, which is crossed over his right leg                                                                                                                                                                                                                 ");
            list.Add("Natural light pours into this minimal workspace, designed with blush pink and clean white surfaces                                                                                                                                                                                                             ");
            list.Add("A photographer sits in front of his computer in a brightly lit working space                                                                                                                                                                                                                                   ");
            list.Add("A woman smiles as she relaxes on a stylish gray sofa, working on her laptop                                                                                                                                                                                                                                    ");
            list.Add("Close up of laptop on desk                                                                                                                                                                                                                                                                                     ");
            list.Add("An employee reads a book at a coffee table in a modern office space                                                                                                                                                                                                                                            ");
            list.Add("Shot of womans wearing two bracelets holding the hand of a man wearing a blue plaid long sleeved shirt                                                                                                                                                                                                         ");
            list.Add("A man with short tousled hair sits in front of a black background                                                                                                                                                                                                                                              ");
            list.Add("Two feet peek into the frame below small floor tiles that spell out &quot; One Step Forward & quot;                                                                                                                                                                                                            ");
            list.Add("            A green support ribbon                                                                                                                                                                                                                                                                             ");
            list.Add("Two women sit together while one has their head on the other&#39;s shoulder                                                                                                                                                                                                                                    ");
            list.Add("A sign on grid paper from March 2018 advises to &quot; Do It For Yourself&quot;                                                                                                                                                                                                                                ");
            list.Add("            A woman hides her face in her hands - is that laughter or sadness ?                                                                                                                                                                                                                                ");
            list.Add("            This sign says it all, spreading positive vibes to everyone with a little minimalism                                                                                                                                                                                                               ");
            list.Add("            One person nervously clasps their hand, while their supportive friend reaches out, letting them know they are with them                                                                                                                                                                            ");
            list.Add("            Green pennant mounted on the wall, emblazoned with the phrase &quot; Leave Yesterday Behind & quot;                                                                                                                                                                                                ");
            list.Add("            A mother flexes her arm muscles in front of her son                                                                                                                                                                                                                                                ");
            list.Add("Young woman balances on her hands in a yoga position in front of a black wall                                                                                                                                                                                                                                  ");
            list.Add("A group of people are standing in a line in front of large office windows overlooking the city                                                                                                                                                                                                                 ");
            list.Add("A man doing a tire flip                                                                                                                                                                                                                                                                                        ");
            list.Add("A runner takes a big step and gets his stride as he runs around an outdoor track and field track                                                                                                                                                                                                               ");
            list.Add("A close up image of a pair of soccer cleats beside a ball on the green grass of a soccer field                                                                                                                                                                                                                 ");
            list.Add("A man in formal wear fixing his watch while sitting                                                                                                                                                                                                                                                            ");
            list.Add("The bright lights of a city at night seen out a window and reflected in the glass beside the photographer                                                                                                                                                                                                      ");
            list.Add("Three beakers contain wild science experiments                                                                                                                                                                                                                                                                 ");
            list.Add("A sad dog with a wrinkly face lying down on the floor                                                                                                                                                                                                                                                          ");
            list.Add("Close up of woman holding light grey coffee mug                                                                                                                                                                                                                                                                ");
            list.Add("Dog with a warm fall vest is out for a walk with his owner outdoors on a nature trail                                                                                                                                                                                                                          ");
            list.Add("A person going on an autumn hike through a field of dry corn                                                                                                                                                                                                                                                   ");
            list.Add("A slice of thanksgiving dessert                                                                                                                                                                                                                                                                                ");
            list.Add("A wooden crate filled with an assortment of squash and gourds this harvest season                                                                                                                                                                                                                              ");
            list.Add("Couple walks hand in hand down forest path                                                                                                                                                                                                                                                                     ");
            list.Add("A hiker takes the beaten path between the autumn trees and runs up the hill                                                                                                                                                                                                                                    ");
            list.Add("Hands are cupped to hold several acorns on this fall day                                                                                                                                                                                                                                                       ");
            list.Add("Woman holding white teacup full of pink herbal tea, standing in autumn leaves on the ground                                                                                                                                                                                                                    ");
            list.Add("A close up image showing signs up the winter season in the texture of a pine tree needles                                                                                                                                                                                                                      ");
            list.Add("A creamy white drink with ice sits in a clear stemless wine glass on a rich wooden table                                                                                                                                                                                                                       ");
            list.Add("Flatlay of a comfortable bed with three things on it(from left to right): a brown ukelele, a person wearing blue jeans and cozy grey socks sitting cross - legged holding with both hands a cup of hot coffee, and an open magazine with a feature of a stylish apartment interior                             ");
            list.Add("Women with short black hair holds a blue mug and looks to the left of the frame                                                                                                                                                                                                                                ");
            list.Add("A barista making pour over coffee from a copper kettle                                                                                                                                                                                                                                                         ");
            list.Add("A person sits with there legs crossed and cups a mug with both of their hands                                                                                                                                                                                                                                  ");
            list.Add("View of woman working on laptop at desk with notebook and coffee mug on desk                                                                                                                                                                                                                                   ");
            list.Add("A hand holds a coffee pot over a white cup ready to pour a morning coffee                                                                                                                                                                                                                                      ");
            list.Add("Woman in a sweater and collared shirt stands in the kitchen and holds a blue coffee mug                                                                                                                                                                                                                        ");
            list.Add("A man pours hot water from a black kettle into a pour over coffee maker                                                                                                                                                                                                                                        ");
            list.Add("A man smiles while looking at his partner over a cup of tea                                                                                                                                                                                                                                                    ");
            list.Add("A soft and welcoming bedroom styled with teak, plants and a copper light                                                                                                                                                                                                                                       ");
            list.Add("An orange cat lounges on a bean bag chair in a cozy living room, beside a plant                                                                                                                                                                                                                                ");
            list.Add("This mother and son playing with her son in the bedroom                                                                                                                                                                                                                                                        ");
            list.Add("A woman rests her bare feet by the window as she settles down with a good book                                                                                                                                                                                                                                 ");
            list.Add("A rainbow forms on sofa with soft teal pillows in a room full of windows and plants                                                                                                                                                                                                                            ");
            list.Add("A hand made mushroom baby mobile is hung in a nursery                                                                                                                                                                                                                                                          ");
            list.Add("Hands lathering soap and washing hands in the kitchen sink                                                                                                                                                                                                                                                     ");
            list.Add("A snuggly french bulldog curls up on couch blankets                                                                                                                                                                                                                                                            ");
            list.Add("View from above of a small dog curled up, sleeping and dreaming, on a bed beside a person at work using their laptop and smartphone                                                                                                                                                                            ");
            list.Add("A kitchen with a marble counter, red walls and an assortment of pots, pans, and other tools spread out and ready for cooking                                                                                                                                                                                   ");
            list.Add("A young woman with curly hair poses with her hands on her hips against a bold yellow background                                                                                                                                                                                                                ");
            list.Add("Painter working in an art studio surrounded by other pieces of finished art                                                                                                                                                                                                                                    ");
            list.Add("A woman with curly hair grasps a bouquet of red roses in her hand                                                                                                                                                                                                                                              ");
            list.Add("A flat lay featuring foundation and eyeshadow                                                                                                                                                                                                                                                                  ");
            list.Add("An assortment of makeup and beauty products lay on a black table                                                                                                                                                                                                                                               ");
            list.Add("An opened carrying case containing several makeup brushes and a watch laid out on a flat surface and surrounded by other jewelry pieces                                                                                                                                                                        ");
            list.Add("A set of makeup brushes neatly placed in a canvas case accented by greenery                                                                                                                                                                                                                                    ");
            list.Add("Bright lipsticks in red seen close up with drops of water                                                                                                                                                                                                                                                      ");
            list.Add("A pair of lips with bright pink lipstick poke out of ripped blue paper                                                                                                                                                                                                                                         ");
            list.Add("A fashionable woman looks down as she applies lipstick                                                                                                                                                                                                                                                         ");
            list.Add("Running outside with city view in the background                                                                                                                                                                                                                                                               ");
            list.Add("A man stands in the middle of an empty street, with a basketball under his arm                                                                                                                                                                                                                                 ");
            list.Add("Female athlete tying her running shoes before exercising outside                                                                                                                                                                                                                                               ");
            list.Add("A man performing a one - arm push - up                                                                                                                                                                                                                                                                         ");
            list.Add("Two people stand together, ready to play a game of one on one basketball                                                                                                                                                                                                                                       ");
            list.Add("A woman checking her fitness tracker close up                                                                                                                                                                                                                                                                  ");
            list.Add("Woman and yoga instructor holding her purple yoga mat in yoga attire                                                                                                                                                                                                                                           ");
            list.Add("A man kneeling on the ground                                                                                                                                                                                                                                                                                   ");
            list.Add("A person sitting on a basketball court while holding a ball                                                                                                                                                                                                                                                    ");
            list.Add("A woman does a Yoga bridge pose on a path between rows of trees                                                                                                                                                                                                                                                ");
            list.Add("Side profile of a smiling woman                                                                                                                                                                                                                                                                                ");
            list.Add("Tools of the modern professional in a flatlay on a countertop                                                                                                                                                                                                                                                  ");
            list.Add("A woman sits in front of a bright window while editing images on her laptop                                                                                                                                                                                                                                    ");
            list.Add("A laptop and coffee mug enter the frame from either side                                                                                                                                                                                                                                                       ");
            list.Add("A view of the tattooed arms of a man leaning against his worktable                                                                                                                                                                                                                                             ");
            list.Add("View of work space at night                                                                                                                                                                                                                                                                                    ");
            list.Add("Over the shoulder view of a designer making sketches using a pencil and small notebook                                                                                                                                                                                                                         ");
            list.Add("A DSLR camera, iPhone, memory card, and notebook laid out on a photographer &#39;s desk                                                                                                                                                                                                                        ");
            list.Add("A classic twist on the modern workplace                                                                                                                                                                                                                                                                        ");
            list.Add("A notebook with a blank page ready to have thoughts and ideas written or drawn on it                                                                                                                                                                                                                           ");
            list.Add("A brightly lit sign spells out the word &quot; love & quot; and a family is gathered below                                                                                                                                                                                                                     ");
            list.Add("Portrait of a smiling family sitting closely on a couch                                                                                                                                                                                                                                                        ");
            list.Add("The wrinkled, chubby feet of a newborn baby hang out of a crib                                                                                                                                                                                                                                                 ");
            list.Add("Close up of a baby asleep                                                                                                                                                                                                                                                                                      ");
            list.Add("Mother tenderly kisses forehead of her swaddled, sleeping baby                                                                                                                                                                                                                                                 ");
            list.Add("A family is gathered together in their home to spend some quality time together, to laugh and to learn!                                                                                                                                                                                                        ");
            list.Add("Two toddlers play together and share the colorful toys laid out before them                                                                                                                                                                                                                                    ");
            list.Add("A small girl in a bright and cheery summer dress takes time to pick some dandelions that are ready to seed                                                                                                                                                                                                     ");
            list.Add("A father and his children yucking it up, having lots of fun being together                                                                                                                                                                                                                                     ");
            list.Add("New baby relaxing in blankets while mom and dad look over him                                                                                                                                                                                                                                                  ");
            list.Add("A couple holds their young son by his hands in front of the fireplace wearing matching pajamas                                                                                                                                                                                                                 ");
            list.Add("A young boy helps his father put on a knitted Santa hat while his mother looks on in laughter, sitting in front of a fireplace                                                                                                                                                                                 ");
            list.Add("With the low lying sun casting an orange haze through the fog, a woman in a red dress dances on the foggy banks of a river in India, through the fog we can see temples on the other side of the water                                                                                                         ");
            list.Add("A young couple in matching pajamas sits at the base of the couch on Christmas morning                                                                                                                                                                                                                          ");
            list.Add("No Christmas morning is complete without a curious child sneaking into the living room to catch Santa delivering presents, barefoot and all                                                                                                                                                                    ");
            list.Add("An elaborately designed building interior with sculpted archways and walls in light teal                                                                                                                                                                                                                       ");
            list.Add("A young boy plays with his toy doll while sitting on his parents &#39; laps                                                                                                                                                                                                                                    ");
            list.Add("A couple and their son come together on Christmas morning to open presents                                                                                                                                                                                                                                     ");
            list.Add("An Indian family gathers around the Christmas tree to hang decorations wearing matching knitted Santa Hats                                                                                                                                                                                                     ");
            list.Add("A young couple helps their son pull tissue out from a gift bag on Christmas morning                                                                                                                                                                                                                            ");
            list.Add("Four wooden columns, surrounding a watery edge on a foggy day                                                                                                                                                                                                                                                  ");
            list.Add("Close up of a hexagon patterned textured wall                                                                                                                                                                                                                                                                  ");
            list.Add("A distant jet stream seen heading from a clouded bright blue sky to a dark star filled one over mountains                                                                                                                                                                                                      ");
            list.Add("Photographer resting on top a hill above all the clouds                                                                                                                                                                                                                                                        ");
            list.Add("Closer view of city landscape as the lights begin to come on and traffic is heavy in the streets                                                                                                                                                                                                               ");
            list.Add("Black and pink ink drop &#39;s swirl together, creating an abstract image                                                                                                                                                                                                                                      ");
            list.Add("A landscape ready to be viewed in more detail                                                                                                                                                                                                                                                                  ");
            list.Add("Sunbeams dance off the wavy walls of antelope canyon in Arizona                                                                                                                                                                                                                                                ");
            list.Add("An abstract background with smooth liquid texture                                                                                                                                                                                                                                                              ");
            list.Add("Crisp blue waves crash against the rocky shoreline                                                                                                                                                                                                                                                             ");
            list.Add("A rocket tattoo blasts colorfully towards the hands that are forming the sign language sign for &quot;I love you&quot;                                                                                                                                                                                         ");
            list.Add("Two hands spell the word &quot;us&quot; in sign language                                                                                                                                                                                                                                                       ");
            list.Add("A hand model adorned in tattoos demonstrates the letter &quot;B&quot; in American Sign Language                                                                                                                                                                                                                ");
            list.Add("A hand model adorned in tattoos demonstrates the letter &quot;Y&quot; in American Sign Language                                                                                                                                                                                                                ");
            list.Add("A hand model adorned in tattoos demonstrates the letter &quot;J&quot; in American Sign Language                                                                                                                                                                                                                ");
            list.Add("A hand model adorned in tattoos demonstrates the letter &quot;A&quot; in American Sign Language                                                                                                                                                                                                                ");
            list.Add("Three hands spell out the word &quot;new&quot; in sign language                                                                                                                                                                                                                                                ");
            list.Add("A female model holds her hand up in the American Sign Language sign for &quot;I love you&quot;  as a rocket tattoo burns across her forearm                                                                                                                                                                    ");
            list.Add("A hand model adorned in tattoos demonstrates the letter &quot;P&quot; in American Sign Language                                                                                                                                                                                                                ");
            list.Add("A hand model adorned in tattoos demonstrates the letter &quot;W&quot; in American Sign Language                                                                                                                                                                                                                ");
            list.Add("A young model stands facing the camera, a leather jacket draped over her shoulders, naturally lit from the sunlight outside                                                                                                                                                                                    ");
            list.Add("Long hair and summery floral fashion being work in a bright yellow room                                                                                                                                                                                                                                        ");
            list.Add("A woman wearing a rose colored satin dress and a warm fur coat                                                                                                                                                                                                                                                 ");
            list.Add("In a black room, this woman&#39;s headscarf almost melds into the dark background                                                                                                                                                                                                                              ");
            list.Add("A young woman with long curly hair stands in front of a tree that is blooming with red berries                                                                                                                                                                                                                 ");
            list.Add("A woman&#39;s feet wearing studded flats while standing on a ledge                                                                                                                                                                                                                                             ");
            list.Add("A model, dressed in neutral colors that blend with her surroundings, catches a single beam of light coming through a nearby window                                                                                                                                                                             ");
            list.Add("Woman in floral tank top and jeans stands in a brick archway                                                                                                                                                                                                                                                   ");
            list.Add("A woman standing against a bright pink background wears oversized glasses, different-sized hoop earrings, and a white fur coat while she stares at the camera and touches her bottom lip with her forefinger                                                                                                   ");
            list.Add("A woman wearing a floral dress and gold necklace with a turquoise pendant                                                                                                                                                                                                                                      ");
            list.Add("A black and white snap of ripples of sand, their arches outlined by light                                                                                                                                                                                                                                      ");
            list.Add("A black and white image of a fashion model posing while sitting in a chair                                                                                                                                                                                                                                     ");
            list.Add("Black and white view of a woman getting makeup applied to her shining lips                                                                                                                                                                                                                                     ");
            list.Add("Side view of a gift box wrapped with care seen in black and white                                                                                                                                                                                                                                              ");
            list.Add("A man in summer clothing sits alone at an empty diner counter which is well stocked with liquor behind the bar                                                                                                                                                                                                 ");
            list.Add("Model posing in black and white                                                                                                                                                                                                                                                                                ");
            list.Add("Cyclist biking over white bridge on a gloomy day                                                                                                                                                                                                                                                               ");
            list.Add("A black and white image shows a bride gazing across the horizon from a beach terrace                                                                                                                                                                                                                           ");
            list.Add("The fog rolls in over the Golden Gate bridge in San Francisco                                                                                                                                                                                                                                                  ");
            list.Add("A black and white photograph of a sleek and simple pair of wireless headphones for listening to your favorite music                                                                                                                                                                                            ");
            list.Add("Oh this? Just your average day at the office with this pug typing away on their laptop                                                                                                                                                                                                                         ");
            list.Add("Man working on MacBook air on desk                                                                                                                                                                                                                                                                             ");
            list.Add("View of woman working on laptop at desk with notebook and coffee mug on desk                                                                                                                                                                                                                                   ");
            list.Add("A hard at work flatlay of paper, paperclips, coffee, tablet and stylus                                                                                                                                                                                                                                         ");
            list.Add("Woman working on a computer with packing supplies on the desk                                                                                                                                                                                                                                                  ");
            list.Add("A meeting or stand-up at a tech startup includes teams like this gathering together to be productive!                                                                                                                                                                                                          ");
            list.Add("Ever heard the phrase &quot;working like a dog&quot;? Well, this pooch is taking it very seriously and putting in a standard 40 hour work week at their computer                                                                                                                                               ");
            list.Add("View from above of a notebook, packing materials, and computer on a work desk                                                                                                                                                                                                                                  ");
            list.Add("Man appearing to be frustrated while working on computer at desk                                                                                                                                                                                                                                               ");
            list.Add("Laptop on work desk at night with lamp on                                                                                                                                                                                                                                                                      ");
            list.Add("A man sitting on a stool in a white and light tan outfit adjusts the hood on his sweater                                                                                                                                                                                                                       ");
            list.Add("Man dressed in button down shirt and jeans leaning against a bicycle enjoying the sunshine                                                                                                                                                                                                                     ");
            list.Add("A young man with lots of style looking down adjusting his hat                                                                                                                                                                                                                                                  ");
            list.Add("Young stylish man sits down on the railing of a bridge                                                                                                                                                                                                                                                         ");
            list.Add("A bearded man in a suit holding onto a stair&#39;s railing                                                                                                                                                                                                                                                     ");
            list.Add("Model in sport coat &amp; hood wades through neon blur                                                                                                                                                                                                                                                         ");
            list.Add("A man places his hat on his head                                                                                                                                                                                                                                                                               ");
            list.Add("Man in turtleneck holds chin up in B &amp; W                                                                                                                                                                                                                                                                   ");
            list.Add("A man stands in front of a bright white wall                                                                                                                                                                                                                                                                   ");
            list.Add("A man in a long red tshirt and skinny black pants stands by a large, crumbling white building                                                                                                                                                                                                                  ");
            list.Add("White light shines through blue glass creating a beautiful abstract pattern                                                                                                                                                                                                                                    ");
            list.Add("Close up of a hexagon patterned textured wall                                                                                                                                                                                                                                                                  ");
            list.Add("A cloud of green, orange, and yellow ink swirls together                                                                                                                                                                                                                                                       ");
            list.Add("View of a partially lit, multiple-shades-of-brown brick wall                                                                                                                                                                                                                                                   ");
            list.Add("Bright yellow painted brick wall background                                                                                                                                                                                                                                                                    ");
            list.Add("Close up, top view of roasted coffee beans                                                                                                                                                                                                                                                                     ");
            list.Add("Rain coming down window, blurring the view                                                                                                                                                                                                                                                                     ");
            list.Add("Black diagonal and horizontal paint on a white concrete wall                                                                                                                                                                                                                                                   ");
            list.Add("Half black and half white painted brick wall                                                                                                                                                                                                                                                                   ");
            list.Add("Red, orange and green peppers at a vegetable market all piled up neatly and looking fresh for eating and cooking                                                                                                                                                                                               ");
            list.Add("Blue water and white cliffs with green moss and trees                                                                                                                                                                                                                                                          ");
            list.Add("A single tree with a winding trunk towers over the vast landscape soaking in the sunlight from above                                                                                                                                                                                                           ");
            list.Add("A view up to the sunlight shining through the top of the Antelope Canyon in Arizona                                                                                                                                                                                                                            ");
            list.Add("An elaborately designed building interior with sculpted archways and walls in light teal                                                                                                                                                                                                                       ");
            list.Add("The tide rolls into a beach below the rocky landscape, as the sun dips below the horizon the scene is cast in teal and orange                                                                                                                                                                                  ");
            list.Add("The Queensboro Bridge in New York stretches across the calm East River on an overcast day                                                                                                                                                                                                                      ");
            list.Add("A thunderous red-orange column of smoke in otherwise darkness                                                                                                                                                                                                                                                  ");
            list.Add("While a layer of pink ink has settled in the lower depths and across the top of the water, a cloud of blue explodes in, creating a mass of tiny aquamarine folds                                                                                                                                               ");
            list.Add("A drop of pink, silver and white curls, like ink in water                                                                                                                                                                                                                                                      ");
            list.Add("An overlay of crosswise slices of citrus fruit and two whole small oranges                                                                                                                                                                                                                                     ");
            list.Add("A photographer sits in front of his computer in a brightly lit working space                                                                                                                                                                                                                                   ");
            list.Add("A business owner sits at a table in his retail store, taking some time to work on his online store                                                                                                                                                                                                             ");
            list.Add("A pair of hands typing away on a laptop while working from home                                                                                                                                                                                                                                                ");
            list.Add("A notebook that encourages you to write down your business ideas                                                                                                                                                                                                                                               ");
            list.Add("A black leather bound notebook and a white mobile phone sat on a desk                                                                                                                                                                                                                                          ");
            list.Add("A white office desk with a laptop, smartphone and glasses surround it ready to get to work                                                                                                                                                                                                                     ");
            list.Add("Man relaxes on the couch while changing the world one pie chart at a time as sketched in his notebook                                                                                                                                                                                                          ");
            list.Add("A person holds a whiteboard that displays Support Local Businesses in the center                                                                                                                                                                                                                               ");
            list.Add("This colorful and open-plan working space is perfect for inspiration and coffee                                                                                                                                                                                                                                ");
            list.Add("A whiteboard displays Shop Local in the center, as greenery peeks in from the left side of the frame                                                                                                                                                                                                           ");
            list.Add("Two women laying in a tent with their backs to camera                                                                                                                                                                                                                                                          ");
            list.Add("A man stands on a rock pillar in the middle of an underground cave, a large ray of light casts down on him from an opening in the earth above                                                                                                                                                                  ");
            list.Add("Footsteps leave imprints in a sand dune as a person takes a journey across the horizon                                                                                                                                                                                                                         ");
            list.Add("A hiker with a blanket draped over their shoulders looks out over a bay surrounded by steep cliffs and mountain peaks                                                                                                                                                                                          ");
            list.Add("A badass camper stands in front of a tent ready to haul ass, shop trees and take nature on                                                                                                                                                                                                                     ");
            list.Add("Woman wearing white dress in prairie with a stormy sky                                                                                                                                                                                                                                                         ");
            list.Add("Sunbeams dance off the wavy walls of antelope canyon in Arizona                                                                                                                                                                                                                                                ");
            list.Add("A woman walks across a suspended hiking bridge in the forest                                                                                                                                                                                                                                                   ");
            list.Add("A woman stops to enjoy the view of the rushing water from a waterfall                                                                                                                                                                                                                                          ");
            list.Add("Climber rappelling down a mountain with helmet and gear in backpack                                                                                                                                                                                                                                            ");
            list.Add("A white ceramic bowl of fresh ripe red strawberries with green tops                                                                                                                                                                                                                                            ");
            list.Add("A ripe red strawberry repeats against a pink background creating a pink and red strawberry pattern                                                                                                                                                                                                             ");
            list.Add("The inside of a deli with cured meat hanging from the hooks and eggs and a menu on the counter                                                                                                                                                                                                                 ");
            list.Add("A flat lay of a large feast of food                                                                                                                                                                                                                                                                            ");
            list.Add("Close up of a bao bun that is filled with meat and topped with cilantro and crushed peanuts                                                                                                                                                                                                                    ");
            list.Add("The camera looks down to a wooden table with two bao buns in a round wooden basket                                                                                                                                                                                                                             ");
            list.Add("Hands slices a red pepper on a round wooden cutting board on a light blue countertop                                                                                                                                                                                                                           ");
            list.Add("Selection of Italian dishes with shellfish pasta, pizza and meatballs ready for the taking                                                                                                                                                                                                                     ");
            list.Add("A hand holds a zucchini that has been sliced in half by the knife in the other hand                                                                                                                                                                                                                            ");
            list.Add("Person sits in the corner of a sunlit restaurant and enjoys a meal                                                                                                                                                                                                                                             ");
            list.Add("Two hands gripping tightly on the handle of a dolly, with several cardboard boxes in tow                                                                                                                                                                                                                       ");
            list.Add("Woman in a white shirt and white shorts leans against a wall my a window                                                                                                                                                                                                                                       ");
            list.Add("A group of classic and modern stylish watches gather together to tell time                                                                                                                                                                                                                                     ");
            list.Add("A man wearing a blue button-up shirt holds a large cardboard box while standing in front of a red brick wall                                                                                                                                                                                                   ");
            list.Add("Looking over the shoulder of a person tapping on a blank iPad screen in front of a man wearing a blue shirt holding a small cardboard box                                                                                                                                                                      ");
            list.Add("Stacked set of three gold bangle bracelets                                                                                                                                                                                                                                                                     ");
            list.Add("A man instructs somebody about how to properly sign for a package                                                                                                                                                                                                                                              ");
            list.Add("Looking down from above at a photographer&#39;s desk                                                                                                                                                                                                                                                           ");
            list.Add("A black fashionable backpack with gold zippers and detail                                                                                                                                                                                                                                                      ");
            list.Add("A blank blue t-shirt on a hanger ready for printing possibilities                                                                                                                                                                                                                                              ");
            list.Add("Woman and man kissing behind hand showcasing engagement ring                                                                                                                                                                                                                                                   ");
            list.Add("A couple holding hands showcasing engagement ring resting on a rock                                                                                                                                                                                                                                            ");
            list.Add("Shot of womans wearing two bracelets holding the hand of a man wearing a blue plaid long sleeved shirt                                                                                                                                                                                                         ");
            list.Add("Man&#39;s hand wearing a bottle opener ring and fashionable watch                                                                                                                                                                                                                                              ");
            list.Add("An opened carrying case containing several makeup brushes and a watch laid out on a flat surface and surrounded by other jewelry pieces                                                                                                                                                                        ");
            list.Add("Shot of womans wearing two bracelets holding the hand of a man wearing a blue plaid long sleeved shirt                                                                                                                                                                                                         ");
            list.Add("Stacked set of three gold bangle bracelets                                                                                                                                                                                                                                                                     ");
            list.Add("Woman with long hair wearing bohemian bangle bracelets                                                                                                                                                                                                                                                         ");
            list.Add("Closeup of a classic white faced time piece in the sun                                                                                                                                                                                                                                                         ");
            list.Add("Close-up view of wrap anchor bracelet on mans wrist, holding camera                                                                                                                                                                                                                                            ");
            list.Add("A lamb stands proudly at the top of a hill looking over the landscape                                                                                                                                                                                                                                          ");
            list.Add("A small donkey is tied up on a dirt road with grass surrounding it                                                                                                                                                                                                                                             ");
            list.Add("Five soft, yellow baby ducklings huddle together for a quick duckling meeting to plan their duckling business for this duckling week                                                                                                                                                                           ");
            list.Add("A barnyard filled with hay and little piglets! Adorable baby pigs having fun on the farm!                                                                                                                                                                                                                      ");
            list.Add("A view of an octopus sticking out its tentacle                                                                                                                                                                                                                                                                 ");
            list.Add("A flock of tall wading birds stand in the water                                                                                                                                                                                                                                                                ");
            list.Add("A grass-green rat snake with flecks of black shot from above as it slithers across a black background                                                                                                                                                                                                          ");
            list.Add("Close up of a dog peeking through covers                                                                                                                                                                                                                                                                       ");
            list.Add("Stoic capture of a large bird of prey against green foliage                                                                                                                                                                                                                                                    ");
            list.Add("Closeup view of a cat&#39;s face                                                                                                                                                                                                                                                                               ");
            list.Add("Woman sits facing the water with a grassy hill behind her                                                                                                                                                                                                                                                      ");
            list.Add("Woman practices a yoga pose outdoors with one hand up in the air                                                                                                                                                                                                                                               ");
            list.Add("Person wearing a vibrant red fitness top faces away from the camera and holds one arm behind in a stretch                                                                                                                                                                                                      ");
            list.Add("Woman in a vibrant red sport top faces away from the camera and reaches her arms high up in a stretch                                                                                                                                                                                                          ");
            list.Add("Woman is sitting under a tree on a yoga mat facing away from the camera                                                                                                                                                                                                                                        ");
            list.Add("In green grass a woman lays on a pink yoga mat and uses her arms to lift the front of her body upwards                                                                                                                                                                                                         ");
            list.Add("Two hands hold up a pink yoga mat that has a black handle on it                                                                                                                                                                                                                                                ");
            list.Add("Person holds themselves up parallel to a blue yoga mat that is on a wooden floor with a water bottle beside them                                                                                                                                                                                               ");
            list.Add("Person faces away from the camera and sits on a grey yoga mat on a wooden floor                                                                                                                                                                                                                                ");
            list.Add("Woman sits on a blue yoga mat in a yoga pose looking down to her open laptop                                                                                                                                                                                                                                   ");
            return list;
        }



    }
}