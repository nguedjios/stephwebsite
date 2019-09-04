using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CrefoApp
{
    public class CrefoXmlSerializer
    {
        public string CrefoSerializer(CrefoSystemRequest request)
        {

            XmlSerializer xsSubmit = new XmlSerializer(typeof(CrefoSystemRequest));     // Konvertierung zu XML
            var xml = "";

            XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
            {
                // If set to true XmlWriter would close MemoryStream automatically and using would then do double dispose
                // Code analysis does not understand that. That's why there is a suppress message.
                CloseOutput = false,
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = false,
                Indent = true
            };


            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww, xmlWriterSettings))
                {
                    xsSubmit.Serialize(writer, request);
                    xml = sww.ToString(); // Your XML
                }

                WriteCrefoXmlMessageLog WriteXmlMessageLog = new WriteCrefoXmlMessageLog();
            }

            return xml;
        }
    }
}
