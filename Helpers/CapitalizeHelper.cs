using static System.Net.Mime.MediaTypeNames;

namespace PhotoHome.Helpers
{
	public class CapitalizeHelper
    {
        public static string CapitalizeText(string text)
        {
            int i = 0;
            string result = "";

            text = text.ToLower();
            var texts = text.Split(' ');

            foreach (var item in texts)
            {
                if (item == "")
                    continue;

                var firstLetter = item.Substring(0, 1);
                var remainLetters = item.Substring(1);

                firstLetter = firstLetter.ToUpper();
                result += firstLetter + remainLetters;

                if (++i != texts.Count())
                    result += " ";
            }

            return result;
         

        }
    }
}
