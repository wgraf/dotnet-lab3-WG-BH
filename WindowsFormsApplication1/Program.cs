using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    public class HtmlSample
    {
        private readonly string _url;

        public HtmlSample(string url)
        {
            this._url = url;
        }

        /// <summary>
        /// Prosta metoda, która zwraca zawartość HTML podanej strony www
        /// </summary>
        /// 

        public string GetPageHtml()
        {
            using (var wc = new WebClient())
            {
                // Ustawiamy prawidłowe kodowanie dla tej strony
                wc.Encoding = Encoding.UTF8;
                // Dekodujemy HTML do czytelnych dla wszystkich znaków 
                var html = System.Net.WebUtility.HtmlDecode(wc.DownloadString(_url));

                return html;
            }
        }
        /// <summary>
        /// Równie prosta metoda, która wypisuje na konsole wartości atrybutów src oraz alt taga IMG
        /// znajdujących się na podanej stronie www
        /// </summary>
        public void PrintPageNodes()
        {
            string opis;

            // Tworzymy obiekt klasy HtmlDocument zdefiniowanej w namespace HtmlAgilityPack
            // Uwaga - w referencjach projektu musi się znajdować ta biblioteka
            // Przy użyciu nuget-a pojawi się tam automatycznie
            var doc = new HtmlAgilityPack.HtmlDocument();

            // Używamy naszej metody do pobrania zawartości strony
            var pageHtml = GetPageHtml();

            // Ładujemy zawartość strony html do struktury documentu (obiektu klasy HtmlDocument)
            doc.LoadHtml(pageHtml);

            // Metoda Descendants pozwala wybrać zestaw node'ów o określonej nazwie
            var nodes = doc.DocumentNode.Descendants("img");

            // Iterujemy po wszystkich znalezionych node'ach
            foreach (var node in nodes)
            {
                Console.WriteLine("---------");

                // Wyświetlamy nazwę node'a (powinno byc img")
                Console.WriteLine("Node name: " + node.Name);
               
                // Każdy node ma zestaw atrybutów - nas interesują atrybuty src oraz alt

                // Wyświetlamy wartość atrybuty src dla aktualnego węzła
                Console.WriteLine("Src value: " + node.GetAttributeValue("src", ""));
                

                // Wyświetlamy wartość atrybuty alt dla aktualnego węzła
                Console.WriteLine("Alt value: " + node.GetAttributeValue("alt", ""));

                opis = node.GetAttributeValue("alt", "");

               // MessageBox.Show(Form1.mtresc);

                bool contains = Regex.IsMatch(opis, Form1.mtresc);
                if(contains)
                {
                    MessageBox.Show("Zawiera!!!");
                }

                // Oczywiscie w aplikacji JTTT nie będziemy tego wyświetlać tylko będziemy analizować 
                // wartość atrybutów node'a jako string

                // Wszystkie powyższe operacje można napisać zdecydowanie prościej i składniej na przyklad za pomoca wyrazenia LINQ
                // Ten zapis jest tylko do celów ćwiczebnych 
            }

        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //MessageBox.Show(Form1.mtresc);

            //Form1.madres = "http://demotywatory.pl";

            var hs = new HtmlSample(Form1.madres);

            hs.PrintPageNodes();

            Console.Read();
        }
    }
}
