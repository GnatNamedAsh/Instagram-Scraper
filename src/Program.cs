using System.IO;
using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HtmlAgilityPack;

namespace Instagram_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            String repeating_chars = new String('=', 25);


            Console.WriteLine(String.Format("{0,0}{1,0}{2,0}", repeating_chars, "Instagram Scraper", repeating_chars));
            Console.WriteLine("This program should be able to scrape any photo from a PUBLIC Instagram profile.");


            Console.Write("Enter in the username: ");
            String user = Console.ReadLine();

            download(get_json(user), user);
        }

        static object get_json(string name) {
            string url = "https://instagram.com/";
            Console.WriteLine("The current url is {0}");

            Console.WriteLine("Your new url is {0} without encoding", url + name);
            name = WebUtility.UrlEncode(name);
            Console.WriteLine("Your encoded url is {0}", url + name);
            url += name + "/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            // HtmlDocument doc = await Task.Factory.StartNew(()=>web.Load(url));
            // var first_hit = doc.DocumentNode.SelectSingleNode("//a[@class='result-link']");
            // Console.WriteLine(first_hit.GetAttributeValue("href", ""));

            string json_variable = doc.DocumentNode.SelectSingleNode("//script[contains(text(), '_sharedData')]").InnerText;
            // Console.WriteLine(json_variable);
        
            string json_piece = json_variable.Remove(json_variable.IndexOf(';')).Substring(json_variable.IndexOf("{"));
            // Console.WriteLine(json_piece);

            return JsonConvert.DeserializeObject(json_piece); 
            
        }

        static void download(object json, string name) {

            
            Console.WriteLine("All files are placed into your local Picture's library.");
            Directory.CreateDirectory("~/Pictures/name");

            Console.WriteLine("Please enter the name of the folder: ");
            string fname = Console.ReadLine();

            WebClient client = new WebClient();

        }

        static void getNextPage(string query_hash, string id, string after) {

        }
    }
}
