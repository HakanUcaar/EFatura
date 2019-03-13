using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBLTr21.XmlGenerator;

namespace UBLTr21.SchematronSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "XML Dosyası |*.xml";
            if (file.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = file.FileName;
                string DosyaAdi = file.SafeFileName;
                string Hata = UblTrDeSerialize.JavaValidate(File.ReadAllText(DosyaYolu));
                if (Hata.IsNotNull())
                {
                    richTextBox1.Text = Hata;
                }
            }
        }
    }
}
