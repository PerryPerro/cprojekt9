using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WMPLib;
using System.Timers;
using static Logic.FillComboBoxes;
using static Logic.ChangeFeedsAndUrls;
using static Logic.GenereraLista;
using static Logic.addPods;
using System.Threading;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        public string xml = "";
        private List<string> pods = new List<string>();
        WMPLib.WindowsMediaPlayer Player;
        System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
        private Stream ms = new MemoryStream();
        fillBoxes fyll = new fillBoxes();
    public Form1()

        {
            

            //MessageBox.Show(fillBoxes.updatePods().ToString());
            if (!File.Exists(@"C:\lista.xml"))
            {
                addPods.serializePods();
            }

            if (!File.Exists(@"C:\uppspeladePods.xml"))
            {
                addPods.serializeuppSpeladePods();
            }

            InitializeComponent();
            addPods.deSerializePods();
            addPods.deSerializeUppspeladePods();
            //FillZeListWithCategory();
            //FillZeListWithUrl();
            new fillBoxes();

           

            comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
            comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());

        }

        public Dictionary<String, String> categorys = new Dictionary<String, String>();
        public List<KeyValuePair<String, String>> kategorier = new List<KeyValuePair<String, String>>();

        public List<string> Pods { get => Pods1; set => Pods1 = value; }
        public List<string> Pods1 { get => pods; set => pods = value; }
        public List<string> Pods2 { get => pods; set => pods = value; }
        string xmlen;

        private class Hejsan : addPods
        {

        }

    private void button1_Click(object sender, EventArgs e)
        {
            new GenereradLista();

            var ListItems = GenereradLista.SkapaNyttXml(textBox1.Text);
            addPods.addList(textBox1.Text, textBox3.Text, int.Parse(textBox4.Text));
            foreach(string item in ListItems) { 
                Pods.Add(item);
                listBox1.Text = item;
            }
            comboBox1.Text = textBox3.Text;
            addPods.serializePods();
        }
        private void visaLista()
        {
            //var valtItem = comboBox1.SelectedItem.ToString();
            //listBox2.Items.Add(categorys.ContainsKey(valtItem));
        }

        private void FillZeListWithUrl()
        {
            //new fillBoxes();
            //var lista = fillBoxes.fyllComboBoxMedUrl();
            //    for (int i = 0; i < lista.Count; i++)
            //{
            //    comboBox2.Items.Add(lista.ElementAt(i));
            //}
        }

        private void FillZeListWithCategory()
        {
            //new fillBoxes();
            //var lista = fillBoxes.fyllComboBoxMedKategori();
            //for (int i=0; i < lista.Count; i++)
            //{
            //    comboBox1.Items.Add(lista.ElementAt(i));
            //}
        }
        private void fillListWithObjects()
        {
            //listBox2.Items.Clear();
 
            //foreach (var item in kategorier)
            //{
            //    if (comboBox1.SelectedItem.ToString() == item.Key)
            //    {
            //        listBox2.Items.Add(item.Value);
            //    }
                
            //}
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //new GenereradLista();
            //var ListItems = GenereradLista.SkapaNyttXml(listBox1.SelectedItem.ToString());
            //listBox2.Items.Clear();
            //new fillBoxes();
            //var lista = fillBoxes.fyllComboBoxMedUrl();
            //for (int i = 0; i < ListItems.Count; i++)
            //{
            //    listBox2.Items.Add(ListItems.ElementAt(i));
            //}
            //xmlen = listBox1.SelectedItem.ToString();
            //listBox2.Items.Clear();
            //new GenereradLista();
            //listBox2.Items.AddRange(fillBoxes.uppdateralista(listBox1.SelectedItem.ToString()));
            //listBox2.Items.AddRange(GenereradLista.listboxettmetoden(listBox1.SelectedItem.ToString()).ToArray());
            fillBoxes.Methodintervall(fillBoxes.updatePodcasts(listBox1.SelectedItem.ToString()), listBox2, listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            
            listBox1.Items.Clear();
            listBox1.Items.AddRange(fillBoxes.fyllListboxMedFeeds(comboBox1.SelectedItem.ToString()).ToArray());


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ////fillListWithObjects();
            //// Create a timer
            //myTimer = new Timer();
            //// Tell the timer what to do when it elapses
            //myTimer.Elapsed += new ElapsedEventHandler(button3_Click);
            //// Set it to go off every five seconds
            //myTimer.Interval = 5000;
            //// And start it        
            //myTimer.Enabled = true;
            //access it here
            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromSeconds(5);

            //var timer = new System.Threading.Timer((button3_Click) =>
            //{
            //    MessageBox.Show(fillBoxes.update().ToString());
            //}, null, startTimeSpan, periodTimeSpan);

            //fillBoxes.timer();

            





        }

        private void button4_Click(object sender, EventArgs e)
        {

            // FIXA GENERATE LIST HÄR
            //using (var client = new System.Net.WebClient())
            //{
            //    client.Encoding = Encoding.UTF8;
            //    xml = client.DownloadString(textBox1.Text);
            //}
            //var dom = new System.Xml.XmlDocument();
            //dom.LoadXml(xml);
            //foreach (System.Xml.XmlNode item
            //   in dom.DocumentElement.SelectNodes("channel/item"))
            //{
            //    if (item.SelectSingleNode("title").InnerText == listBox2.SelectedItem.ToString())
            //    {
            //        MessageBox.Show(item.SelectSingleNode("description").InnerText);
            //    }

            MessageBox.Show(GenereradLista.knappfyrametoden(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString()));

            //}
     
        }
  

        private void button5_Click(object sender, EventArgs e)
        {
            // FIXA GENERATE LIST HÄR
            //var filePath = "";
            //var xmlen = listBox1.SelectedItem.ToString();
            //if (listBox1.SelectedItem.ToString() == null)
            //{
            //     xmlen = listBox1.SelectedItem.ToString();
            //}


            //using (var client = new System.Net.WebClient())
            //{
            //    client.Encoding = Encoding.UTF8;
            //    xml = client.DownloadString(xmlen);
            //}

            //dom.LoadXml(xml);
            //foreach (System.Xml.XmlNode item
            //   in dom.DocumentElement.SelectNodes("channel/item"))
            //{
            //    if (item.SelectSingleNode("title").InnerText == listBox2.SelectedItem.ToString())
            //    {

            //        filePath = item.SelectSingleNode("enclosure/@url").InnerText;

            //       Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " + filePath);
            //    }



            // }
            addPods.addList(listBox2.SelectedItem.ToString());
            xmlen = listBox1.SelectedItem.ToString();
            GenereradLista.spelaUppPod(xmlen, listBox2.SelectedItem.ToString());
            addPods.serializeuppSpeladePods();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fillBoxes.removeCategory(textBox6.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Changer();
            
            Changer.changeFeedUrl(comboBox2.SelectedItem.ToString(), textBox5.Text, textBox6.Text, textBox7.Text);
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            fillBoxes.removeFeed(comboBox2.SelectedItem.ToString());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text = fillBoxes.fyllLabel(listBox2.SelectedItem.ToString());
        }

        //private void Methodintervall(int intervall, ListBox list, ListBox list1)
        //{
        //    System.Timers.Timer TimerSet = new System.Timers.Timer();
        //    TimerSet.Interval = intervall;
        //    TimerSet.Elapsed += (sender, e) => OnTimedEvent(sender, e, list, list1);
        //    TimerSet.AutoReset = true;
        //    TimerSet.Enabled = true;
        //}

        //public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, ListBox list, ListBox list1)
        //{
        //    list.Invoke(new Action(() => list.Items.Clear()));
        //    Debug.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        //    list.Invoke(new Action(() => list.Items.AddRange(GenereradLista.listboxettmetoden(list1.SelectedItem.ToString()).ToArray())));

        //}

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        /////////&//////

        //private void Methodintervall()
        //{
        //    System.Timers.Timer TimerSet = new System.Timers.Timer();
        //    TimerSet.Interval = 5000;
        //    TimerSet.Elapsed += OnTimedEvent;
        //    TimerSet.AutoReset = true;
        //    TimerSet.Enabled = true;


        //}

        //public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    listBox2.Invoke(new Action(() => listBox2.Items.Clear()));
        //    Debug.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        //    listBox2.Invoke(new Action(() => listBox2.Items.AddRange(GenereradLista.listboxettmetoden(listBox1.SelectedItem.ToString()).ToArray())));

        //}
    }
}
