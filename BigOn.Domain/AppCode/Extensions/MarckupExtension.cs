using System.Text.RegularExpressions;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
       static public string ToPlainText(this string text)
       {
         text=Regex.Replace(text, "<[^>]*>", "");
            return text;
            
       }

        static public string ToEllipise(this string text, int len)
        {
            if (!string.IsNullOrWhiteSpace(text) && text.Length > len)
            {
                text = text.Substring(0, len);  
            }
         
            return text;

        }

    }
}
