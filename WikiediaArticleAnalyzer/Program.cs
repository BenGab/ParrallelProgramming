using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WikiediaArticleAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWrite();
            Console.ReadLine();
        }

        static void TestWrite()
        {
            string cont = string.Empty;
            const string keyword = "John von Neumann";
            do
            {
                XDocument xd = XDocument.Load(
                    $"https://en.wikipedia.org/w/api.php?action=query&titles={keyword}&prop=links&&pllimit=max&format=xml" + cont);
                Console.WriteLine(xd.Descendants("pl").Count());
                if(xd.Descendants("continue").Count() > 0)
                {
                    cont = $"&plcontinue={xd.Descendants("continue").Single().Attribute("plcontinue").Value}";
                }
                else
                {
                    cont = string.Empty;
                }

                foreach (var xelem in xd.Descendants("pl").Select(x => x.Attribute("title").Value))
                {
                    Console.WriteLine(xelem);
                }
            } while (!string.IsNullOrEmpty(cont));
        }
    }
}
