using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using static Data.Pods;

namespace Logic
{
    public abstract class GenereraLista
    {
        public class GenereradLista
        {
            static string xml;
            public GenereradLista()
            {

            }

            public static List<String> SkapaNyttXml(string url)
            {
                var xml = "";
                List<String> list = new List<String>();
                using (var client = new System.Net.WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    xml = client.DownloadString(url);
                }

                //Skapa en objektrepresentation.
                var dom = new System.Xml.XmlDocument();
                dom.LoadXml(xml);

                //Iterera igenom elementet item.
                foreach (System.Xml.XmlNode item
                   in dom.DocumentElement.SelectNodes("channel/item"))
                {
                    //Skriv ut dess titel.
                    list.Add(item.SelectSingleNode("title").InnerText);

                }
                return list;


            }

            public static List<string> listboxettmetoden(string url)
            {
                
                    new GenereradLista();
                    var ListItems = GenereradLista.SkapaNyttXml(url);
                    //listBox2.Items.Clear();
                    //new fillBoxes();
                    //var lista = fillBoxes.fyllComboBoxMedUrl();
                    List<string> urler = new List<string>();
                    for (int i = 0; i < ListItems.Count; i++)
                    {
                        urler.Add(ListItems.ElementAt(i));
                    }
               
                
                return urler;
            }

            public static string knappfyrametoden(string url, string selectedPod)
            {
                //GenereradLista.SkapaNyttXml(url)
                string desciption = "";
                using (var client = new System.Net.WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    xml = client.DownloadString(url);
                }
                var dom = new System.Xml.XmlDocument();
                dom.LoadXml(xml);
                foreach (System.Xml.XmlNode item
                   in dom.DocumentElement.SelectNodes("channel/item"))
                {
                    if (item.SelectSingleNode("title").InnerText == selectedPod)
                    {
                        desciption = (item.SelectSingleNode("description").InnerText);
                    }

                }

                return desciption;
            }

            public static void spelaUppPod(string url, string selectedPod)
            {
                var filePath = "";
                //var xmlen = listBox1.SelectedItem.ToString();
                //if (listBox1.SelectedItem.ToString() == null)
                //{
                //     xmlen = listBox1.SelectedItem.ToString();
                //}


                using (var client = new System.Net.WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    xml = client.DownloadString(url);
                }
                var dom = new System.Xml.XmlDocument();
                dom.LoadXml(xml);
                foreach (System.Xml.XmlNode item
                   in dom.DocumentElement.SelectNodes("channel/item"))
                {
                    if (item.SelectSingleNode("title").InnerText == selectedPod)
                    {

                        filePath = item.SelectSingleNode("enclosure/@url").InnerText;

                        Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " + filePath);
                    }

                }

            }
        }
    }
}