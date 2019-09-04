using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrefoApp
{

    public class CrefoParser
    {
        public static string PdfPath { get; set; }

        public CrefoParser(string pdfPfad)
        {
            PdfPath = pdfPfad;
        }




        public void CrefoIdentXmlParse(string xml, Form1 oberflaeche)
        {

            XElement csr = XElement.Parse(xml);
            XNamespace ns = "https://onlineservice.creditreform.de/webservice/0600-0021";

            var errMessage =                                                // Message Anzeige auf der Oberfläche  
                from el in csr.Descendants("commandResult")
                select el;

            foreach (var item in errMessage)
            {
                oberflaeche.ErrorMessage = item.Element("commandResultMessage").Value;
            }


            var errCode =                                                   // Error code
                from el in csr.Descendants("commandReturnDataEntryFields")
                select el;

            foreach (var item in errCode)
            {
                oberflaeche.ErrorCode = item.Element("field").Value;
            }

            

            var body =
                from el in csr.Descendants(ns + "body")    // Zugriff auf den Namespace
                select new BodyElements
                {
                    Referencenumber = el.Element(ns + "referencenumber"),             // XElemente auswählen
                    Identificationnumber = el.Element(ns + "identificationnumber")
                };

            foreach (var item in body)
            {
                oberflaeche.ReferenceNumber = item.Referencenumber.Value;
                oberflaeche.IdentificationNumber = item.Identificationnumber.Value;
            }




            var reportData =
                from el in csr.Descendants(ns + "reportdata")
                select new ReportDataElements
                {
                    CompanyName = el.Element(ns + "companyidentification").Element(ns + "companyname"),
                    Street = el.Element(ns + "companyidentification").Element(ns + "street"),
                    HouseNumber = el.Element(ns + "companyidentification").Element(ns + "housenumber"),
                    Postcode = el.Element(ns + "companyidentification").Element(ns + "postcode"),
                    City = el.Element(ns + "companyidentification").Element(ns + "city"),
                    Country = el.Element(ns + "companyidentification").Element(ns + "country"),
                    RegisterType = el.Element(ns + "register").Element(ns + "registertype"),
                    RegisterId = el.Element(ns + "register").Element(ns + "registerid"),
                    Register = el.Element(ns + "register").Element(ns + "register"),
                };


            foreach (var item in reportData)
            {

                oberflaeche.Company = item.CompanyName.Value;
                oberflaeche.Street = item.Street.Value;
                oberflaeche.HouseNumber = item.HouseNumber.Value;
                oberflaeche.PostCode = item.Postcode.Value;
                oberflaeche.City = item.City.Value;
                oberflaeche.CountryName = item.Country.Element(ns + "designation").Value;
                oberflaeche.CountryCode = item.Country.Element(ns + "key").Value;
                oberflaeche.RegisterID = item.RegisterId.Value;
                oberflaeche.RegisterKey = item.RegisterType.Element(ns + "key").Value;
                oberflaeche.RegisterName = item.RegisterType.Element(ns + "designation").Value;
                oberflaeche.RegisterCode = item.RegisterType.Element(ns + "shortdesignation").Value;
                oberflaeche.RegisterCourt = item.Register.Element(ns + "court").Value;
                oberflaeche.RegisterCourtCode = item.Register.Element(ns + "shortdesignationcourt").Value;
                oberflaeche.RegisterCourtCity = item.Register.Element(ns + "city").Value;
                oberflaeche.RegisterCourtPostCode = item.Register.Element(ns + "postcode").Value;

            }

        }




        public void CrefoSignalXmlParse(string SignalXml, Form1 oberflaeche)
        {

            XElement csr = XElement.Parse(SignalXml);
            
            XNamespace ns = "urn:creditreform:agency:creditreform:universal";

            var PdfUui =                                                // Message Anzeige auf der Oberfläche  
                from el in csr.Descendants(ns + "reference")
                select new ReferenceElements
                {
                    ReferenceId = el.Element(ns + "reference")
                };

            foreach (var item in PdfUui)
            {
                oberflaeche.PdfUUID = item.ReferenceId.Value;
            }


            var taxData =
                from el in csr.Descendants(ns + "taxdata")
                select new TaxDataElements
                {
                    TaxNumber = el.Element(ns + "taxnumber"),
                    VatId = el.Element(ns + "vatid")
                };

            foreach (var item in taxData)
            {
               oberflaeche.TaxNumber = item.TaxNumber.Value;
               oberflaeche.VatID = item.VatId.Value;
            }


        }



        public void Kuendigen(string KuendigenXml, Form1 oberflaeche)
        {

            XElement csr = XElement.Parse(KuendigenXml);

            var error =                                                // Message Anzeige auf der Oberfläche  
                from el in csr.Descendants("reply")
                select el;

            foreach (var item in error)
            {
               oberflaeche.ErrorMessage = item.Element("hasErrors").Value;
            }


        }




        public void WritePdf(string PDFxml)         // create logFile in C:\Temp\logFile
        {
            string base64PDFString = "";
            XElement csr = XElement.Parse(PDFxml);

            var encodeData =                                                // Message Anzeige auf der Oberfläche  
                from el in csr.Descendants("commandReturnDataEntryFields")
                where el.Element("field").Attribute("fieldName").Value == "encodedPdfData"
                select el;
            // Achtung -> Es wird angenommen, dass hier nur max. ein Element zurückgegeben wird!
            foreach (var item in encodeData)
                base64PDFString = item.Element("field").Value;

            byte[] bytes = Convert.FromBase64String(base64PDFString);

            string _timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string _LogFile = PdfPath + "pdfFile1_" + _timestamp + ".pdf";

            try
            {
                if (!Directory.Exists(PdfPath))
                    System.IO.Directory.CreateDirectory(PdfPath);

                using (FileStream fs = new FileStream(_LogFile, FileMode.Append, FileAccess.Write))
                {
                    using (BinaryWriter w = new BinaryWriter(fs))
                    {
                        w.Write(bytes, 0, bytes.Length);
                        w.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
