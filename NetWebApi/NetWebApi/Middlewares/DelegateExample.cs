using System.Text;

namespace NetWebApi.Middlewares
{
    public class DelegateExample
    {
        public delegate string FormatTextDelegate(string text);

        public string Format(string text, FormatTextDelegate format)
        {
            return format(text);
        }

        public static string FirstLetterUpperCase(string text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string word in text.Split(' '))
            {
                builder.Append(word.Substring(0, 1).ToUpper() 
                    + word.Substring(1).ToLower()
                    + " ");
            }
            return builder.ToString();
        }

        public static string SecondLetterUpperCase(string text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string word in text.Split(' '))
            {
                builder.Append(word.Substring(0, 1).ToLower() 
                    + word.Substring(1, 1).ToUpper() 
                    + word.Substring(2).ToLower()
                    + " ");
            }
            return builder.ToString();
        }
    }
}