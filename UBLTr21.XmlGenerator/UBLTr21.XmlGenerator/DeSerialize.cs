using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using UblTr;
using System.Xml.XPath;
using System.Diagnostics;

namespace UBLTr21.XmlGenerator
{
    public static class UblTrDeSerialize
    {
        public static InvoiceType UBLDeserialize(string oXmlFilePath)
        {
            // Please change the paths if you have a local copy of the UBL zip package (remote download is slow)
            //string xsdFilename = @"UBL-Invoice-2.1.xsd";
            string xsdFilename = @"/maindoc/UBL-Invoice-2.1.xsd";
            string xmlFilename = oXmlFilePath;
            InvoiceType invoice = null;

            using (FileStream fs = File.OpenRead(xmlFilename))
            {
                // Validation
                XDocument xmlInvoice = XDocument.Load(fs);
                if (!ValidateUblDocument(xmlInvoice, xsdFilename))
                {
                    Console.WriteLine("Invalid document. Unable to continue");
                }

                // Load xml into an UBL Larsen invoice instance
                XmlSerializer xs = new XmlSerializer(typeof(InvoiceType));
                fs.Position = 0;
                invoice = (InvoiceType)xs.Deserialize(fs);
            }

            //Show some values from the invoice
            if (invoice != null)
            {
                //Console.WriteLine("Invoice id: {0}", invoice.ID.Value);
                //Console.WriteLine("Issue date: {0}", invoice.IssueDate.Value.ToShortDateString());
                //Console.WriteLine("  Due Date: {0}", invoice.PaymentMeans[0].PaymentDueDate.Value.ToShortDateString());
                //Console.WriteLine("Amount due: {0} ({1})", invoice.LegalMonetaryTotal.PayableAmount.Value, invoice.LegalMonetaryTotal.PayableAmount.currencyID);
            }

            return invoice.IsNull() ? null : invoice;
        }
        public static InvoiceType UBLDeserializeFromXml(string oXML)
        {
            // Please change the paths if you have a local copy of the UBL zip package (remote download is slow)
            //string xsdFilename = @"UBL-Invoice-2.1.xsd";
            string StartPath = Environment.CurrentDirectory;
            string xsdFilename = StartPath + @"/maindoc/UBL-Invoice-2.1.xsd";
            InvoiceType invoice = null;

            // Validation
            XDocument xmlInvoice = XDocument.Parse(oXML);
            //if (!ValidateUblDocument(xmlInvoice, xsdFilename))
            //{
            //    Console.WriteLine("Invalid document. Unable to continue");
            //}

            // Load xml into an UBL Larsen invoice instance


            TextReader oRead = new StringReader(oXML);
            using (XmlReader reader = XmlReader.Create(oRead))
            {

                Type typeToSerialize = typeof(InvoiceType);
                XmlSerializer xs = new XmlSerializer(typeToSerialize);
                invoice = (InvoiceType)xs.Deserialize(reader);
            }                

            //Show some values from the invoice
            if (invoice != null)
            {
                //Console.WriteLine("Invoice id: {0}", invoice.ID.Value);
                //Console.WriteLine("Issue date: {0}", invoice.IssueDate.Value.ToShortDateString());
                //Console.WriteLine("  Due Date: {0}", invoice.PaymentMeans[0].PaymentDueDate.Value.ToShortDateString());
                //Console.WriteLine("Amount due: {0} ({1})", invoice.LegalMonetaryTotal.PayableAmount.Value, invoice.LegalMonetaryTotal.PayableAmount.currencyID);
            }

            return invoice.IsNull() ? null : invoice;
        }
        private static bool ValidateUblDocument(XDocument ublDocument, string xsdFilename)
        {
            bool res = true;
            XmlSchemaSet ublDocSchemaSet = new XmlSchemaSet();

            ValidationEventHandler valHandler = (s, e) =>
            {
                Console.WriteLine("{0}: {1}", e.Severity.ToString(), e.Message);
                if (e.Severity == XmlSeverityType.Error) res = false;
            };
            //File.OpenText(xsdFilename)
            using (XmlTextReader tr = new XmlTextReader(xsdFilename))
            {
                ublDocSchemaSet.Add(XmlSchema.Read(tr, valHandler));
            }
            System.Xml.Schema.Extensions.Validate(ublDocument, ublDocSchemaSet, valHandler);
            return res;
        }
        public static bool ValidateUbl(string oXML)
        {
            try
            {
                string StartPath = Environment.CurrentDirectory;
                string xsdFilename = StartPath + @"/schematron/UBL-TR_Main_Schematron.xml";

                XDocument xmlInvoice = XDocument.Parse(oXML);
                return ValidateUblDocument(xmlInvoice, xsdFilename);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool ValidateUbl2(string oXML)
        {
            try
            {
                Boolean res = false;
                string StartPath = Environment.CurrentDirectory;
                string xsdFilename = StartPath + @"/schematron/UBL-TR_Main_Schematron.xml";
                
                TextReader tr = File.OpenText(xsdFilename);


                ValidationEventHandler valHandler = (s, e) =>
                {
                    Console.WriteLine("{0}: {1}", e.Severity.ToString(), e.Message);
                    if (e.Severity == XmlSeverityType.Error) res = false;
                };

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(XmlSchema.Read(tr, valHandler));
                settings.ValidationType = ValidationType.Auto;

                XmlReader reader = XmlReader.Create(oXML, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static StringBuilder hatalar;
        public static bool ValidateUbl3(string oXML)
        {
            bool Result = true;
            try
            {
                string StartPath = Environment.CurrentDirectory;
                string xsdFile = StartPath + @"/schematron/UBL-TR_Main_Schematron.xml";

                hatalar = new StringBuilder();

                XmlReaderSettings xrs = new XmlReaderSettings();
                xrs.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(ValidationEventHandler2);
                xrs.Schemas.Add(null, XmlReader.Create(xsdFile));
                xrs.ValidationType = ValidationType.Schema;
                XmlReader reader = XmlReader.Create(new StringReader(oXML), xrs);
                while (reader.Read())
                { }
                if (hatalar.ToString() == "")
                {
                    //hata yok
                }                    
                else
                {
                    Result = false;
                    //hatalar.ToString()
                }                    
            }
            catch (Exception e)
            {
                Result = false;
            }
            return Result;
        }
        static void ValidationEventHandler2(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == System.Xml.Schema.XmlSeverityType.Error)
                hatalar.Append(e.Message + "<br><br>");
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }

        static string output = "";
        public static string JavaValidate( string xml)
        {
            string Result = "";
            string starttup = Environment.CurrentDirectory;
            string shema = starttup + @"\schematron\code\UBL-TR_Main_Schematron.xml";
            string jar = starttup + "/NTG_UBLTR_Schematron.jar";
            File.WriteAllText(starttup+@"\tmpFatura.xml",xml);
            string args = "java -jar \"" + jar + "\" \"" + shema + "\" \"" + starttup+@"\tmpFatura.xml"+"\"";

            Process oProc = new Process();
            oProc.StartInfo.FileName = "cmd.exe";
            oProc.StartInfo.CreateNoWindow = true;
            oProc.StartInfo.RedirectStandardError = true;
            oProc.StartInfo.RedirectStandardInput = true;
            oProc.StartInfo.RedirectStandardOutput = true;
            oProc.StartInfo.UseShellExecute = false;
            oProc.Start();

            oProc.OutputDataReceived += p_OutputDataReceived;
                        
            oProc.StandardInput.WriteLine(args);
            oProc.StandardInput.Flush();
            oProc.StandardInput.Close();           
            oProc.WaitForExit();

            Result = oProc.StandardOutput.ReadToEnd();
            Result = Result.Replace("Microsoft Windows [Version 10.0.10586]", "");
            Result = Result.Replace("(c) 2015 Microsoft Corporation. Tm haklar sakldr.","");
            Result = Result.Replace(args, "");
            Result = Result.Replace(starttup, "");
            Result = Result.Replace(">","");
            Result = Result.Trim();
            return Result;
        }

        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            output += e.Data + Environment.NewLine;
        }
    }
}
