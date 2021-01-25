using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UblTr;
using System.Xml.Serialization;

namespace UBLTr21.XmlGenerator
{
    public static class UblTrSerialize
    {
        public static string UblSerialize(InvoiceType oInvoice)
        {
            try
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;
                setting.IndentChars = "\t";
                setting.Encoding = Encoding.UTF8;

                //Eğer xml dosyaya yazılacaksa
                string xmlFilename = @"Deneme.xml";
                using (XmlWriter writer = XmlWriter.Create(xmlFilename, setting))
                {
                    writer.WriteProcessingInstruction(
                        "xml-stylesheet", "type='text/xsl' href='general.xslt'");
                    Type typeToSerialize = typeof(InvoiceType);
                    XmlSerializer xs = new XmlSerializer(typeToSerialize);
                    xs.Serialize(writer, oInvoice);
                }

                //Eğer sadece xml oluşturulacaksa
                StringBuilder oRead = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(oRead, setting))
                {
                    writer.WriteProcessingInstruction(
                        "xml-stylesheet", "type='text/xsl' href='general.xslt'");
                    Type typeToSerialize = typeof(InvoiceType);
                    XmlSerializer xs = new XmlSerializer(typeToSerialize);
                    xs.Serialize(writer, oInvoice);
                }
                return oRead.ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

    }
}
