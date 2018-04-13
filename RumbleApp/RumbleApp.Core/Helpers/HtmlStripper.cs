using System;
using System.Text.RegularExpressions;

namespace JamnationApp.Core.Helpers
{
    public class HtmlStripper
    {
        public static string Clean(string html)
        {
            html = Regex.Replace(html, "\n\n", "{PARAGRAPHSPACING}"); // remove all \n
            html = Regex.Replace(html, "\n", " "); // remove all \n
            html = Regex.Replace(html, "\r", ""); // remove all \r
            html = Regex.Replace(html, "{PARAGRAPHSPACING}", "\r\n\r\n"); // remove all \n
            html = Regex.Replace(html, "&nbsp;", " "); // remove all \n
            html = html.TrimStart(' '); // remove first space
            html = Regex.Replace(html, "<p>", "\n");
            html = Regex.Replace(html, "</p>", "\n");
            html = Regex.Replace(html, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>",
                String.Empty);

            return html;
        }
    }
}
