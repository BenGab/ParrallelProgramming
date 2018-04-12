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
            const string keyword = "John von Neumann";
            XDocument xd = XDocument.Load(
                $"https://en.wikipedia.org/w/api.php?action=query&titles={keyword}&prop=links&&pllimit=max&format=xml");
            Console.WriteLine(xd.Descendants("pl").Count());

            foreach(var xelem in xd.Descendants("pl").Select(x => x.Attribute("title").Value))
            {
                Console.WriteLine(xelem);
            }
        }
    }
}
