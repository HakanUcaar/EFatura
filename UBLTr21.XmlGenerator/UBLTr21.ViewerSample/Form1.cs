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
using System.Xml;
using System.Xml.Xsl;
using UblTr;
using UBLTr21.XmlGenerator;

namespace UBLTr21.ViewerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "XML Dosyası |*.xml";
            if (file.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = file.FileName;
                string DosyaAdi = file.SafeFileName;
                LoadBrowser(DosyaYolu);
            }
        }

        private void LoadBrowser(string filepath)
        {
            try
            {
                string XML = File.ReadAllText(filepath);
                XslCompiledTransform xTrans = new XslCompiledTransform();

                InvoiceType oInvoice = UblTrDeSerialize.UBLDeserializeFromXml(XML);
                if (!oInvoice.AdditionalDocumentReference.FirstOrDefault().IsNull())
                {
                    StringReader ostRead = new StringReader(Encoding.UTF8.GetString(oInvoice.AdditionalDocumentReference.FirstOrDefault().Attachment.EmbeddedDocumentBinaryObject.Value));
                    XmlReader oRead = XmlReader.Create(ostRead);
                    xTrans.Load(oRead);
                }
                else
                {
                    if (textBox1.Text != string.Empty)
                    {
                        xTrans.Load(textBox1.Text);    
                    }                    
                }

                // Read the xml string.
                StringReader sr = new StringReader(XML);
                XmlReader xReader = XmlReader.Create(sr);

                // Transform the XML data
                StringWriter ms = new StringWriter();
                xTrans.Transform(xReader, null, ms);

                //ms.Position = 0;

                // Set to the document stream
                webBrowser1.Document.Write(ms.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }        
        }
        private void LoadBrowserFromXML(string XML)
        {
            try
            {
                XslCompiledTransform xTrans = new XslCompiledTransform();

                InvoiceType oInvoice = UblTrDeSerialize.UBLDeserializeFromXml(XML);
                if (!oInvoice.AdditionalDocumentReference.FirstOrDefault().IsNull())
                {
                    StringReader ostRead = new StringReader(Encoding.UTF8.GetString(oInvoice.AdditionalDocumentReference.FirstOrDefault().Attachment.EmbeddedDocumentBinaryObject.Value));
                    XmlReader oRead = XmlReader.Create(ostRead);
                    xTrans.Load(oRead);
                }
                else
                {
                    if (textBox1.Text != string.Empty)
                    {
                        xTrans.Load(textBox1.Text);
                    }
                }

                // Read the xml string.
                StringReader sr = new StringReader(XML);
                XmlReader xReader = XmlReader.Create(sr);

                // Transform the XML data
                StringWriter ms = new StringWriter();
                xTrans.Transform(xReader, null, ms);

                //ms.Position = 0;

                // Set to the document stream
                webBrowser1.Document.Write(ms.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "XSLT Dosyası |*.xslt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            LoadBrowserFromXML(XmlCreate());
        }

        private string XmlCreate()
        {
            InvoiceType res = new InvoiceType();
            res
            .With(io =>
            {
                #region Invoice
                io.UBLVersionID.Value = "2.1";
                io.CustomizationID.Value = "TR1.2";
                io.ProfileID.Value = "TEMELFATURA";
                io.InvoiceTypeCode.Value = "SATIS";
                io.ID.Value = "HKN0000000000001";
                io.UUID.Value = Guid.NewGuid().ToString();
                io.IssueDate.Value = DateTime.Now;
                io.IssueTime.Value = DateTime.Now;
                io.DocumentCurrencyCode.Value = "TRY";
                io.LineCountNumeric.Value = 1;

                io.Note = new List<NoteType>();
                NoteType oNewNote = new NoteType();
                oNewNote.Value = "Test Dip Not";
                io.Note.Add(oNewNote);

                //xslt base64 formatında gömme
                io.AdditionalDocumentReference = new List<DocumentReferenceType>();

                DocumentReferenceType oNewAdd = new DocumentReferenceType();
                oNewAdd.ID.Value = io.UUID.Value;
                oNewAdd.IssueDate.Value = DateTime.Now;
                oNewAdd.Attachment = new AttachmentType();
                oNewAdd.Attachment
                    .With(att =>
                    {
                        att.EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType();
                        att.EmbeddedDocumentBinaryObject.filename = io.UUID.Value + ".xslt";
                        att.EmbeddedDocumentBinaryObject.characterSetCode = "UTF-8";
                        att.EmbeddedDocumentBinaryObject.encodingCode = "Base64";
                        att.EmbeddedDocumentBinaryObject.mimeCode = "application/xml";
                        att.EmbeddedDocumentBinaryObject.Value = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(System.Windows.Forms.Application.StartupPath + "/general.xslt"));
                    });
                io.AdditionalDocumentReference.Add(oNewAdd);

                //irsaliye bilgilerini ekleme
                io.DespatchDocumentReference = new List<DocumentReferenceType>();
                DocumentReferenceType onewSip = new DocumentReferenceType();
                onewSip.ID.Value = "A859552";
                onewSip.IssueDate.Value = DateTime.Now;
                io.DespatchDocumentReference.Add(onewSip);

                //Sipariş bilgilerini ekleme
                io.OrderReference = new OrderReferenceType();
                io.OrderReference.ID.Value = "32123";
                io.OrderReference.IssueDate.Value = DateTime.Now;
                #endregion

                #region Signature
                //io.Signature = new List<SignatureType>();
                //SignatureType oSig = new SignatureType();
                //oSig
                //    .With(sg =>
                //    {
                //        sg.ID = new IDType();
                //        sg.ID.schemeID = "VKN_TCKN";
                //        sg.ID.Value = "1288331521";

                //        sg.SignatoryParty = new PartyType();
                //        sg.SignatoryParty
                //            .With(sp =>
                //            {
                //                sp.PartyIdentification = new List<PartyIdentificationType>();

                //                PartyIdentificationType oPartyIdent = new PartyIdentificationType();
                //                oPartyIdent.ID = new IDType();
                //                oPartyIdent.ID.schemeID = "VKN";
                //                oPartyIdent.ID.Value = oSirket.RegisterNumber;
                //                sp.PartyIdentification.Add(oPartyIdent);

                //                sp.PostalAddress = new AddressType();
                //                sp.PostalAddress
                //                    .With(pa =>
                //                    {
                //                        pa.StreetName = new StreetNameType();
                //                        pa.StreetName.Value = oSirket.Address;

                //                        //pa.BuildingNumber = new BuildingNumberType();
                //                        //pa.BuildingNumber.Value = "21";

                //                        pa.CitySubdivisionName = new CitySubdivisionNameType();
                //                        pa.CitySubdivisionName.Value = oSirket.District;

                //                        pa.CityName = new CityNameType();
                //                        pa.CityName.Value = oSirket.City;

                //                        //pa.PostalZone = new PostalZoneType();
                //                        //pa.PostalZone.Value = "34100";

                //                        pa.Country = new CountryType();
                //                        pa.Country.Name.Value = oSirket.Country;
                //                    });
                //            });

                //        sg.DigitalSignatureAttachment = new AttachmentType();
                //        sg.DigitalSignatureAttachment.ExternalReference = new ExternalReferenceType();
                //        sg.DigitalSignatureAttachment.ExternalReference.URI.Value = "#Signature";
                //    });

                //io.Signature.Add(oSig);
                #endregion

                #region AccountingSupplierParty
                io.AccountingSupplierParty = new SupplierPartyType();
                io.AccountingSupplierParty
                    .With(asp =>
                    {
                        asp.Party = new PartyType();
                        asp.Party
                            .With(pp =>
                            {
                                pp.WebsiteURI = new WebsiteURIType();
                                pp.WebsiteURI.Value = "www.hakanuçar.com.tr";
                                pp.PartyIdentification = new List<PartyIdentificationType>();
                                pp.PartyIdentification.Add(
                                                                new PartyIdentificationType
                                                                {
                                                                    ID = new IDType { schemeID = "VKN", Value = "1234567801" }
                                                                }
                                                            );
                                //Firma diğer bilgiler
                                pp.PartyIdentification.Add(
                                                                new PartyIdentificationType
                                                                {
                                                                    ID = new IDType { schemeID = "MERSISNO", Value = "4235234" }
                                                                }
                                                            );

                                pp.PartyName = new PartyNameType();
                                pp.PartyName.Name.Value = "Hakan UÇAR Bilgi İşlem";
                                pp.PostalAddress = new AddressType();
                                pp.PostalAddress
                                    .With(pa =>
                                    {
                                        pa.ID = new IDType();
                                        pa.ID.Value = "1234567801";

                                        pa.StreetName = new StreetNameType();
                                        pa.StreetName.Value = "KOZYATAĞI";

                                        //pa.BuildingNumber = new BuildingNumberType();
                                        //pa.BuildingNumber.Value = "21";

                                        pa.CitySubdivisionName = new CitySubdivisionNameType();
                                        pa.CitySubdivisionName.Value = "Beşiktaş";

                                        pa.CityName = new CityNameType();
                                        pa.CityName.Value = "İstanbul";

                                        //pa.PostalZone = new PostalZoneType();
                                        //pa.PostalZone.Value = "341000";

                                        pa.Country = new CountryType();
                                        pa.Country.Name.Value = "Türkiye";
                                    });

                                pp.PartyTaxScheme = new PartyTaxSchemeType();
                                pp.PartyTaxScheme.TaxScheme = new TaxSchemeType();
                                pp.PartyTaxScheme.TaxScheme.Name = new NameType1();
                                pp.PartyTaxScheme.TaxScheme.Name.Value = "KOZYATAĞI";

                                pp.Contact = new ContactType();
                                pp.Contact
                                    .With(co =>
                                    {
                                        co.Name = new NameType1();
                                        co.Name.Value = "Hakan UÇAR";

                                        co.Telephone = new TelephoneType();
                                        co.Telephone.Value = "0592 558 5588";

                                        co.Telefax = new TelefaxType();
                                        co.Telefax.Value = "0592 558 5588";

                                        co.ElectronicMail = new ElectronicMailType();
                                        co.ElectronicMail.Value = "hakanucaar@yandex.com";
                                    });
                            });
                    });
                #endregion

                #region AccountingCustomerParty
                io.AccountingCustomerParty = new CustomerPartyType();
                string Senaryo = "0";
                switch (Senaryo)
                {
                    //Temel Fatura
                    case "0":
                        {
                            #region customerinf
                            io.AccountingCustomerParty
                                .With(cus =>
                                {
                                    cus.Party = new PartyType();
                                    cus.Party
                                        .With(cusp =>
                                        {
                                            cusp.WebsiteURI = new WebsiteURIType();
                                            cusp.WebsiteURI.Value = "www.hakanuçar.com.tr";

                                            cusp.PartyIdentification = new List<PartyIdentificationType>();

                                            PartyIdentificationType pi = new PartyIdentificationType();
                                            pi.ID = new IDType();
                                            pi.ID.schemeID = "VKN";
                                            pi.ID.Value = "1234567801";
                                            cusp.PartyIdentification.Add(pi);

                                            cusp.PartyName = new PartyNameType();
                                            cusp.PartyName.Name.Value = "Hakan UÇAR bilgi İşlem";

                                            cusp.PostalAddress = new AddressType();
                                            cusp.PostalAddress
                                                .With(cupa =>
                                                {
                                                    cupa.ID = new IDType();
                                                    cupa.ID.Value = "1234567801";

                                                    cupa.StreetName = new StreetNameType();
                                                    cupa.StreetName.Value = "Kadıköy";

                                                    cupa.CityName = new CityNameType();
                                                    cupa.CityName.Value = "İstanbul";

                                                    cupa.CitySubdivisionName = new CitySubdivisionNameType();
                                                    cupa.CitySubdivisionName.Value = "Kadıköy";

                                                    cupa.Country = new CountryType();
                                                    cupa.Country.Name.Value = "Türkiye";

                                                    cupa.PostalZone = new PostalZoneType();
                                                    cupa.PostalZone.Value = "34000";
                                                });

                                            cusp.Contact = new ContactType();
                                            cusp.Contact
                                                .With(cuc =>
                                                {
                                                    cuc.Name = new NameType1();
                                                    cuc.Name.Value = "Hakan UÇAR";

                                                    cuc.Telephone = new TelephoneType();
                                                    cuc.Telephone.Value = "0555 55 55 55";

                                                    cuc.Telefax = new TelefaxType();
                                                    cuc.Telefax.Value = "0555 55 55 55";

                                                    cuc.ElectronicMail = new ElectronicMailType();
                                                    cuc.ElectronicMail.Value = "hakanucaar@yandex.com";
                                                });
                                        });
                                });
                            #endregion
                        }
                        break;
                    //Ticari Fatura
                    case "1":
                        {
                            #region customerinf
                            io.AccountingCustomerParty
                                .With(cus =>
                                {
                                    cus.Party = new PartyType();
                                    cus.Party
                                        .With(cusp =>
                                        {
                                            cusp.WebsiteURI = new WebsiteURIType();
                                            cusp.WebsiteURI.Value = "www.hakanuçar.com.tr";

                                            cusp.PartyIdentification = new List<PartyIdentificationType>();

                                            PartyIdentificationType pi = new PartyIdentificationType();
                                            pi.ID = new IDType();
                                            pi.ID.schemeID = "VKN";
                                            pi.ID.Value = "1234567801";
                                            cusp.PartyIdentification.Add(pi);

                                            cusp.PartyName = new PartyNameType();
                                            cusp.PartyName.Name.Value = "Hakan UÇAR bilgi İşlem";

                                            cusp.PostalAddress = new AddressType();
                                            cusp.PostalAddress
                                                .With(cupa =>
                                                {
                                                    cupa.ID = new IDType();
                                                    cupa.ID.Value = "1234567801";

                                                    cupa.StreetName = new StreetNameType();
                                                    cupa.StreetName.Value = "Kadıköy";

                                                    cupa.CityName = new CityNameType();
                                                    cupa.CityName.Value = "İstanbul";

                                                    cupa.CitySubdivisionName = new CitySubdivisionNameType();
                                                    cupa.CitySubdivisionName.Value = "Kadıköy";

                                                    cupa.Country = new CountryType();
                                                    cupa.Country.Name.Value = "Türkiye";

                                                    cupa.PostalZone = new PostalZoneType();
                                                    cupa.PostalZone.Value = "34000";
                                                });

                                            cusp.Contact = new ContactType();
                                            cusp.Contact
                                                .With(cuc =>
                                                {
                                                    cuc.Name = new NameType1();
                                                    cuc.Name.Value = "Hakan UÇAR";

                                                    cuc.Telephone = new TelephoneType();
                                                    cuc.Telephone.Value = "0555 55 55 55";

                                                    cuc.Telefax = new TelefaxType();
                                                    cuc.Telefax.Value = "0555 55 55 55";

                                                    cuc.ElectronicMail = new ElectronicMailType();
                                                    cuc.ElectronicMail.Value = "hakanucaar@yandex.com";
                                                });
                                        });
                                });
                            #endregion
                        }
                        break;
                    //İhracat
                    case "2":
                        {
                            #region ExportCustomerInfo
                            io.AccountingCustomerParty
                                .With(cus =>
                                {
                                    cus.Party = new PartyType();
                                    cus.Party
                                        .With(cusp =>
                                        {
                                            cusp.WebsiteURI = new WebsiteURIType();
                                            cusp.WebsiteURI.Value = "";

                                            cusp.PartyIdentification = new List<PartyIdentificationType>();

                                            PartyIdentificationType pi = new PartyIdentificationType();
                                            pi.ID = new IDType();
                                            pi.ID.schemeID = "VKN";
                                            pi.ID.Value = "1460415308";
                                            cusp.PartyIdentification.Add(pi);

                                            cusp.PartyName = new PartyNameType();
                                            cusp.PartyName.Name.Value = "Gümrük ve Ticaret Bakanlığı Gümrükler Genel Müdürlüğü- Bilgi İşlem Dairesi Başkanlığı";

                                            cusp.PostalAddress = new AddressType();
                                            cusp.PostalAddress
                                                .With(cupa =>
                                                {
                                                    //cupa.ID = new IDType();
                                                    //cupa.ID.Value = grd.DataTable.GetValue("Vergi No", grdRowIndex).ToString();

                                                    //cupa.StreetName = new StreetNameType();
                                                    //cupa.StreetName.Value = grd.DataTable.GetValue("Adres", grdRowIndex).ToString();

                                                    cupa.CityName = new CityNameType();
                                                    cupa.CityName.Value = "Ankara";

                                                    //cupa.CitySubdivisionName = new CitySubdivisionNameType();
                                                    //cupa.CitySubdivisionName.Value = grd.DataTable.GetValue("İlçe", grdRowIndex).ToString();

                                                    cupa.Country = new CountryType();
                                                    cupa.Country.Name.Value = "Türkiye";
                                                });


                                            cusp.PartyTaxScheme = new PartyTaxSchemeType();
                                            cusp.PartyTaxScheme.TaxScheme = new TaxSchemeType();
                                            cusp.PartyTaxScheme.TaxScheme.Name = new NameType1();
                                            cusp.PartyTaxScheme.TaxScheme.Name.Value = "Ulus";
                                        });
                                });
                            #endregion
                        }
                        break;
                    //Yolcu Beraber Fatura
                    case "3":
                        {
                            #region TaxFreeInfo
                            //oInvoice.TaxFreeInfo = new TaxFreeInfo();
                            //oInvoice.TaxFreeInfo
                            //    .With(txfi =>
                            //    {
                            //        txfi.TouristInfo = new TouristInfo(); //Turistin bilgilerinin girileceği alandır.
                            //        txfi.TouristInfo
                            //            .With(ti =>
                            //            {
                            //                ti.Name = ""; //Bu alan turistin ad bilgisi girilir.
                            //                ti.SurName = ""; //Bu alan turistin soyad bilgisi girilir.
                            //                ti.PassportNo = ""; //Bu alan turistin pasaport numarası bilgisi girilir.
                            //                ti.PassportDate = DateTime.Now; //Bu alan turistin pasaport tarihi bilgisi girilir.
                            //                ti.CountryCode = ""; //Bu alan turistin ülke kodu bilgisi girilir.(örn:TR)
                            //                ti.FinancialAccountInfo = new FinancialAccountInfo(); //Bu alana turistin banka hesap bilgileri girilir.
                            //                ti.FinancialAccountInfo
                            //                    .With(fa =>
                            //                    {
                            //                        fa.BankName = ""; //Bu alan Banka Adı bilgisi girilir.
                            //                        fa.BranchName = ""; //Bu alan Banka Şube Adı bilgisi girilir.
                            //                        fa.CurrencyCode = ""; //Bu alan Para Birimi bilgisi girilir.
                            //                        fa.ID = ""; //Bu alan Banka Hesap Numarası bilgisi girilir.
                            //                        fa.PaymentNote = ""; //Bu alan Ödeme Notu bilgisi girilir.
                            //                    });
                            //                ti.AddressInfo = new AddressInfo(); //Bu alan turistin adres bilgileri girilir.
                            //                ti.AddressInfo
                            //                    .With(ai =>
                            //                    {
                            //                        ai.Address = "";
                            //                        ai.City = "";
                            //                        ai.Country = "";
                            //                        ai.District = "";
                            //                        ai.Fax = "";
                            //                        ai.Mail = "";
                            //                        ai.Phone = "";
                            //                        ai.PostalCode = "";
                            //                        ai.WebSite = "";
                            //                    });
                            //            });

                            //        txfi.TaxRepresentativeInfo = new TaxRepresentativeInfo(); //Aracı kurum bilgilerinin girileceği alandır.
                            //        txfi.TaxRepresentativeInfo
                            //            .With(tri =>
                            //            {
                            //                tri.RegisterNumber = ""; //Bu alana Aracı Kurumun Vergi Kimlik Numarası girilir.
                            //                tri.Alias = ""; //Bu alana Aracı Kurumun Etiket bilgisi girilir.
                            //                tri.Address = new AddressInfo();//Bu alan turistin adres bilgileri girilir
                            //                tri.Address
                            //                    .With(ai =>
                            //                    {
                            //                        ai.Address = "";
                            //                        ai.City = "";
                            //                        ai.Country = "";
                            //                        ai.District = "";
                            //                        ai.Fax = "";
                            //                        ai.Mail = "";
                            //                        ai.Phone = "";
                            //                        ai.PostalCode = "";
                            //                        ai.WebSite = "";
                            //                    });
                            //            });
                            //    });
                            #endregion
                        }
                        break;
                    //EArşiv Fatura
                    case "4":
                        {
                            #region customerinf
                            //oInvoice.CustomerInfo = new PartyInfo();
                            //oInvoice.CustomerInfo.Address = grd.DataTable.GetValue("Adres", grdRowIndex).ToString();
                            //oInvoice.CustomerInfo.City = grd.DataTable.GetValue("İl", grdRowIndex).ToString();//"İstanbul";
                            //oInvoice.CustomerInfo.Country = grd.DataTable.GetValue("Ülke", grdRowIndex).ToString();//"Türkiye";
                            //oInvoice.CustomerInfo.District = grd.DataTable.GetValue("İlçe", grdRowIndex).ToString();//"Ataşehir";
                            //oInvoice.CustomerInfo.Fax = grd.DataTable.GetValue("Fax", grdRowIndex).ToString();//"216 688 51 99";
                            //oInvoice.CustomerInfo.Mail = grd.DataTable.GetValue("Email", grdRowIndex).ToString();//"info@nesbilgi.com.tr";
                            //oInvoice.CustomerInfo.Name = grd.DataTable.GetValue("Muhatap Adı", grdRowIndex).ToString();//"NES Bilgi Teknolojileri";
                            //oInvoice.CustomerInfo.Phone = grd.DataTable.GetValue("Telefon", grdRowIndex).ToString();// "216 688 51 00";
                            //oInvoice.CustomerInfo.RegisterNumber = grd.DataTable.GetValue("Vergi No", grdRowIndex).ToString();// "1234567801";
                            //oInvoice.CustomerInfo.TaxOffice = grd.DataTable.GetValue("Vergi Dairesi", grdRowIndex).ToString();// "KOZYATAĞI";
                            //oInvoice.CustomerInfo.WebSite = grd.DataTable.GetValue("Web Sitesi", grdRowIndex).ToString();// "https://nesbilgi.com.tr/";
                            //oInvoice.CustomerInfo.ReceiverAlias = grd.DataTable.GetValue("Alıcı Posta Etiketi", grdRowIndex).ToString();// "urn:mail:defaultpk@nesbilgi.com.tr";/                                
                            #endregion
                        }
                        break;
                    default:
                        break;
                }

                #endregion

                if (Senaryo == "2")
                {
                    #region BuyerCustomerParty
                    io.BuyerCustomerParty = new CustomerPartyType();
                    io.BuyerCustomerParty
                        .With(cus =>
                        {
                            cus.Party = new PartyType();
                            cus.Party
                                .With(cusp =>
                                {
                                    cusp.WebsiteURI = new WebsiteURIType();
                                    cusp.WebsiteURI.Value = "www.hakanucar.com.tr";

                                    cusp.PartyIdentification = new List<PartyIdentificationType>();

                                    PartyIdentificationType pi = new PartyIdentificationType();
                                    pi.ID = new IDType();
                                    pi.ID.schemeID = "VKN";
                                    pi.ID.Value = "1234567801";
                                    cusp.PartyIdentification.Add(pi);

                                    cusp.PartyName = new PartyNameType();
                                    cusp.PartyName.Name.Value = "Hakan UÇAR Bilişim";

                                    cusp.PostalAddress = new AddressType();
                                    cusp.PostalAddress
                                        .With(cupa =>
                                        {
                                            cupa.ID = new IDType();
                                            cupa.ID.Value = "1234567801";

                                            cupa.StreetName = new StreetNameType();
                                            cupa.StreetName.Value = "Meçhul bir yer";

                                            cupa.CityName = new CityNameType();
                                            cupa.CityName.Value = "İstanbul";

                                            cupa.CitySubdivisionName = new CitySubdivisionNameType();
                                            cupa.CitySubdivisionName.Value = "Beşiktaş";

                                            cupa.Country = new CountryType();
                                            cupa.Country.Name.Value = "Türkiye";

                                            cupa.PostalZone = new PostalZoneType();
                                            cupa.PostalZone.Value = "34000";
                                        });

                                    cusp.Contact = new ContactType();
                                    cusp.Contact
                                        .With(cuc =>
                                        {
                                            cuc.Name = new NameType1();
                                            cuc.Name.Value = "Hakan UÇAR";

                                            cuc.Telephone = new TelephoneType();
                                            cuc.Telephone.Value = "555 55 55 55";

                                            cuc.Telefax = new TelefaxType();
                                            cuc.Telefax.Value = "555 55 55 55";

                                            cuc.ElectronicMail = new ElectronicMailType();
                                            cuc.ElectronicMail.Value = "hakanucaar@yandex.com";
                                        });
                                });
                        });
                    #endregion
                }

                #region PaymentTerms
                //Ödeme Koşulu

                io.PaymentTerms = new PaymentTermsType();
                io.PaymentTerms.Note = new NoteType();
                io.PaymentTerms.Note.Value = "60 gün vadeli";
                #endregion

                #region TaxTotal
                //Vergiler
                io.TaxTotal = new List<TaxTotalType>();
                io.TaxTotal
                    .With(tt =>
                    {
                        TaxTotalType ott = new TaxTotalType();
                        ott.TaxAmount = new TaxAmountType();
                        ott.TaxAmount.currencyID = "TRY";
                        ott.TaxAmount.Value = 180;

                        ott.TaxSubtotal = new List<TaxSubtotalType>();

                        TaxSubtotalType oSubt = new TaxSubtotalType();
                        oSubt.TaxableAmount = new TaxableAmountType();
                        oSubt.TaxableAmount.currencyID = "TRY";
                        oSubt.TaxableAmount.Value = 1000;

                        oSubt.TaxAmount = new TaxAmountType();
                        oSubt.TaxAmount.currencyID = "TRY";
                        oSubt.TaxAmount.Value = 180;

                        oSubt.TaxCategory = new TaxCategoryType();
                        oSubt.TaxCategory.TaxScheme = new TaxSchemeType();
                        oSubt.TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType();
                        oSubt.TaxCategory.TaxScheme.TaxTypeCode.Value = "0015";

                        ott.TaxSubtotal.Add(oSubt);

                        tt.Add(ott);
                    });
                #endregion

                #region InvoiceLine
                io.InvoiceLine = new List<InvoiceLineType>();

                InvoiceLineType il = new InvoiceLineType();

                il
                    .With(iol =>
                    {
                        //Sıra No
                        iol.ID = new IDType();
                        iol.ID.Value = "1";

                        //Kalem Tanımı
                        iol.Item = new ItemType();
                        iol.Item.Name = new NameType1();
                        iol.Item.Name.Value = "HP X534 Yazıcı";

                        iol.Item.SellersItemIdentification = new ItemIdentificationType();
                        iol.Item.SellersItemIdentification.ID.Value = "KLM0012";

                        //Kalem Miktarı
                        iol.InvoicedQuantity = new InvoicedQuantityType();
                        iol.InvoicedQuantity.unitCode = "C62";
                        iol.InvoicedQuantity.Value = 1;

                        //Kalem Birim Fiyatı
                        iol.Price = new PriceType();
                        iol.Price.PriceAmount = new PriceAmountType();
                        iol.Price.PriceAmount.currencyID = "TRY";
                        iol.Price.PriceAmount.Value = 1000;

                        iol.Note = new List<NoteType>();
                        NoteType oKlmNote = new NoteType();
                        oNewNote.Value = "Test kalem notu";
                        iol.Note.Add(oKlmNote);

                        //iskonto
                        //iol.AllowanceCharge = new List<AllowanceChargeType>();
                        //iol.AllowanceCharge
                        //    .With(all =>
                        //    {
                        //        AllowanceChargeType allc = new AllowanceChargeType();
                        //        allc.ChargeIndicator = new ChargeIndicatorType();
                        //        allc.ChargeIndicator.Value = false;
                        //        allc.MultiplierFactorNumeric = new MultiplierFactorNumericType();
                        //        allc.MultiplierFactorNumeric.Value = 0.0M;
                        //        allc.Amount = new AmountType2();
                        //        allc.Amount.currencyID = "TRY";
                        //        allc.Amount.Value = 0M;
                        //        allc.BaseAmount = new BaseAmountType();
                        //        allc.BaseAmount.currencyID = "TRY";
                        //        allc.BaseAmount.Value = ((decimal)Services.ObjectToDouble(fech.Item("Quantity").Value)) *
                        //                                ((decimal)Services.ObjectToDouble(fech.Item("Price").Value));
                        //        all.Add(allc);
                        //    });

                        if (Senaryo == "2")
                        {
                            iol.Delivery = new List<DeliveryType>();
                            DeliveryType oDelivery = new DeliveryType();

                            oDelivery
                                .With(d =>
                                {
                                    DeliveryTermsType dtt = new DeliveryTermsType();
                                    dtt.ID.schemeID = "INCOTERMS";
                                    dtt.ID.Value = "Teslim şartı";
                                    d.DeliveryTerms.Add(dtt);

                                    d.DeliveryAddress
                                    .With(ai =>
                                    {
                                        ai.StreetName = new StreetNameType();
                                        ai.StreetName.Value = "Meçhul bir adres";

                                        ai.CitySubdivisionName = new CitySubdivisionNameType();
                                        ai.CitySubdivisionName.Value = "Beşiktaş";

                                        ai.CityName = new CityNameType();
                                        ai.CityName.Value = "İstanbul";

                                        ai.Country = new CountryType();
                                        ai.Country.Name.Value = "Türkiye";
                                    });

                                    d.Shipment
                                        .With(shp =>
                                        {
                                            shp.ID.Value = "Gümrük tarkip numarası";
                                            GoodsItemType oGItem = new GoodsItemType();
                                            oGItem.RequiredCustomsID.Value = "GTIP";
                                            shp.GoodsItem.Add(oGItem);

                                            ShipmentStageType oState = new ShipmentStageType();
                                            oState.TransportModeCode.Value = "Gönderim şekli";
                                            shp.ShipmentStage.Add(oState);

                                            TransportHandlingUnitType othlu = new TransportHandlingUnitType();
                                            PackageType op = new PackageType();
                                            op.ID.Value = "Kab numarası";
                                            op.Quantity.Value = 1;//paket adedi
                                            op.PackagingTypeCode.Value = "Kabın cinsi";
                                            othlu.ActualPackage.Add(op);
                                            shp.TransportHandlingUnit.Add(othlu);

                                            //di.PackageBrandName = fech.Item("U_PackageBrandName").Value.ToString() == "" ? grd.DataTable.GetValue("Kabın Markası", grdRowIndex).ToString() : fech.Item("U_PackageBrandName").Value.ToString(); //Bu alana Mal/Hizmetin bulunduğu Kabın Marka isim bilgisi girilir.
                                        });
                                });

                            iol.Delivery.Add(oDelivery);
                        }

                        //Vergi Toplam
                        iol.TaxTotal = new TaxTotalType();
                        iol.TaxTotal
                            .With(tx =>
                            {
                                tx.TaxAmount = new TaxAmountType();
                                tx.TaxAmount.currencyID = "TRY";
                                tx.TaxAmount.Value = 180;


                                //Vergiler
                                tx.TaxSubtotal = new List<TaxSubtotalType>();
                                tx.TaxSubtotal
                                    .With(txs =>
                                    {
                                        TaxSubtotalType sbt = new TaxSubtotalType();
                                        sbt.TaxableAmount = new TaxableAmountType();
                                        sbt.TaxableAmount.currencyID = "TRY";
                                        sbt.TaxableAmount.Value = 1000;
                                        sbt.TaxAmount = new TaxAmountType();
                                        sbt.TaxAmount.currencyID = "TRY";
                                        sbt.TaxAmount.Value = 180;
                                        sbt.Percent = new PercentType1();
                                        sbt.Percent.Value = 18;

                                        sbt.TaxCategory = new TaxCategoryType();
                                        sbt.TaxCategory.TaxScheme = new TaxSchemeType();
                                        sbt.TaxCategory.TaxScheme.Name = new NameType1();
                                        sbt.TaxCategory.TaxScheme.Name.Value = "KDV";
                                        sbt.TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType();
                                        sbt.TaxCategory.TaxScheme.TaxTypeCode.Value = "0015";

                                        txs.Add(sbt);
                                    });
                            });

                        //Kalem Mal Hizmet Tutarı
                        iol.LineExtensionAmount = new LineExtensionAmountType();
                        iol.LineExtensionAmount.currencyID = "TRY";
                        iol.LineExtensionAmount.Value = 1000;
                    });



                io.InvoiceLine.Add(il);

                #endregion

                #region LegalMonetaryTotal
                io.LegalMonetaryTotal = new MonetaryTotalType();

                //Mal Hizmet Toplam Tutar
                io.LegalMonetaryTotal.LineExtensionAmount = new LineExtensionAmountType();
                io.LegalMonetaryTotal.LineExtensionAmount.currencyID = "TRY";
                io.LegalMonetaryTotal.LineExtensionAmount.Value = 1000;

                //Vergiler Hariç Tutar
                io.LegalMonetaryTotal.TaxExclusiveAmount = new TaxExclusiveAmountType();
                io.LegalMonetaryTotal.TaxExclusiveAmount.currencyID = "TRY";
                io.LegalMonetaryTotal.TaxExclusiveAmount.Value = 1000;

                //Vergiler Dahil Tutar
                io.LegalMonetaryTotal.TaxInclusiveAmount = new TaxInclusiveAmountType();
                io.LegalMonetaryTotal.TaxInclusiveAmount.currencyID = "TRY";
                io.LegalMonetaryTotal.TaxInclusiveAmount.Value = 1180;


                //iskonto
                io.LegalMonetaryTotal.AllowanceTotalAmount = new AllowanceTotalAmountType();
                io.LegalMonetaryTotal.AllowanceTotalAmount.currencyID = "TRY";
                io.LegalMonetaryTotal.AllowanceTotalAmount.Value = 0M;

                //Ödenecek Tutar
                io.LegalMonetaryTotal.PayableAmount = new PayableAmountType();
                io.LegalMonetaryTotal.PayableAmount.currencyID = "TRY";
                io.LegalMonetaryTotal.PayableAmount.Value = 1180;

                #endregion
            });

            return UblTrSerialize.UblSerialize(res);
        }
    }
}
