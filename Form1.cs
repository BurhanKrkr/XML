using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XML_DOSYA_İŞLEMLERİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnToXml.Click += btnToXml_Click;
            btnReadXML.Click += btnReadXML_Click;
        }

        private void btnToXml_Click(object sender, EventArgs e)
        {
            foreach(Control c in groupBox1.Controls)
            {
                if(c is TextBox)
                {
                    if(c.Text == "")
                    {
                        return;
                    }
                }
            }
            //XmlDocument xdoc = new XmlDocument();
            //XmlNode root = xdoc.CreateElement("Kullanicilar");
            //xdoc.AppendChild(root);

            

            //for (int i = 0; i < 3; i++)
            //{
            //    XmlNode Kullanici = xdoc.CreateElement("Kullanici");
            //    XmlAttribute ID = xdoc.CreateAttribute("ID");
            //    XmlNode Ad = xdoc.CreateElement("Ad");
            //    XmlNode Soyad = xdoc.CreateElement("Soyad");
            //    XmlNode DTarih = xdoc.CreateElement("DTarih");
            //    XmlNode Meslek = xdoc.CreateElement("Meslek");


            //    ID.Value = i.ToString();
            //    Ad.InnerText = textBox1.Text;
            //    Soyad.InnerText = textBox2.Text;
            //    DTarih.InnerText = textBox3.Text;
            //    Meslek.InnerText = textBox4.Text;

            //    Kullanici.Attributes.Append(ID);
            //    Kullanici.AppendChild(Ad);
            //    Kullanici.AppendChild(Soyad);
            //    Kullanici.AppendChild(DTarih);
            //    Kullanici.AppendChild(Meslek);
            //    root.AppendChild(Kullanici);
            //}


            using(SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "XML Dosyası|*.xml";
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    //xdoc.Save(sf.FileName);

                    using(XmlWriter xw = XmlWriter.Create(sf.FileName))
                    {
                        xw.WriteStartDocument();
                        xw.WriteStartElement("Kullanicilar");
                        for (int i = 0; i < 3; i++)
                        {
                            xw.WriteStartElement("Kullanici");
                            xw.WriteAttributeString("ID",i.ToString());
                            xw.WriteElementString("Ad", textBox1.Text);
                            xw.WriteElementString("Soyad", textBox2.Text);
                            xw.WriteElementString("DTarih", textBox3.Text);
                            xw.WriteElementString("Meslek", textBox4.Text);
                            xw.WriteEndElement();
                        }
                        xw.WriteEndElement();
                        xw.WriteEndDocument();
                    }









                    MessageBox.Show($"{sf.FileName} dosyası oluşturuldu.");
                }
            }
        }

        private void btnReadXML_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "XML Dosyaları|*.xml";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(of.FileName);
                    //XmlNodeList list = xdoc.SelectNodes("//Kullanicilar/Kullanici");
                    //foreach (XmlNode x in list)
                    //{
                    //    textBox5.Text = x["Ad"].InnerText;
                    //    textBox6.Text = x["Soyad"].InnerText;
                    //    textBox7.Text = x["DTarih"].InnerText;
                    //    textBox8.Text = x["Meslek"].InnerText;
                    //}

                    XmlNode x = xdoc.SelectSingleNode("//Kullanicilar/Kullanici");
                    textBox5.Text = x["Ad"].InnerText;
                    textBox6.Text = x["Soyad"].InnerText;
                    textBox7.Text = x["DTarih"].InnerText;
                    textBox8.Text = x["Meslek"].InnerText;
                }
            }
        }

       
    }
}
