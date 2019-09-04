using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrefoApp
{
    public class CrefoHttpClient : HttpClient
    {
        private string Url { get; set; }
        private string Parameters { get; set; }

        private CrefoSerializer serializer;

        public CrefoHttpClient()
        {
            serializer = new CrefoSerializer();
        }

        private void AddUrlParam(string parameterName, string parameterValue)
        {
            if (String.IsNullOrEmpty(Parameters))
            {
                Parameters += "?";
            }
            else
            {
                Parameters += "&";
            }

            Parameters += parameterName + "=" + parameterValue;

        }
        
        private string SendCrefoSystemRequest(string url)
        {
            HttpResponseMessage response = this.GetAsync(new Uri(url)).Result;

            string resultXml = response.Content.ReadAsStringAsync().Result;

            //WriteXMLMessageLog(resultXml);
            return resultXml;
        }

        private string BuildUrl(string zielURL, string csOrg, string csUsername, string csPassword, string csXML)
        {
            Url = zielURL;

            this.AddUrlParam("CsPassword", csPassword);

            this.AddUrlParam("CsXmlrequest", csXML);

            this.AddUrlParam("CsOrganization", csOrg);

            this.AddUrlParam("CsUsername", csUsername);

            if (!String.IsNullOrEmpty(Parameters))
            {
                Url += Parameters;
            }

            return Url;
        }

        public string GetCrefoPDF(string zielURL, string csOrg, string csUsername, string csPassword, Form1 oberflaeche)
        {
            string csXML = serializer.BuildCrefoPdf(oberflaeche);
            if (String.IsNullOrEmpty(csXML))
            {
                throw new Exception("Fehler beim Erstellen der XML");
            }

            return this.SendCrefoSystemRequest(this.BuildUrl(zielURL,
                                                             csOrg,
                                                             csUsername,
                                                             csPassword,
                                                             csXML));
        }

        public string GetKuendigungCrefo(string zielURL, string csOrg, string csUsername, string csPassword, Form1 oberflaeche)
        {
            string csXML = serializer.BuildCrefoKuendigenXml(oberflaeche);
            if (String.IsNullOrEmpty(csXML))
            {
                throw new Exception("Fehler beim Erstellen der XML");
            }

            return this.SendCrefoSystemRequest(this.BuildUrl(zielURL,
                                                             csOrg,
                                                             csUsername,
                                                             csPassword,
                                                             csXML));
        }

        public string GetCrefoSignal(string zielURL, string csOrg, string csUsername, string csPassword, Form1 oberflaeche)
        {
            string csXML = serializer.BuildCrefoSignalXml(oberflaeche);
            if (String.IsNullOrEmpty(csXML))
            {
                throw new Exception("Fehler beim Erstellen der XML");
            }

            return this.SendCrefoSystemRequest(this.BuildUrl(zielURL,
                                                             csOrg,
                                                             csUsername,
                                                             csPassword,
                                                             csXML));
        }

        public string GetCrefoIdent(string zielURL, string csOrg, string csUsername, string csPassword, Form1 oberflaeche)
        {
            string csXML = serializer.BuildCrefoIdentXml(oberflaeche);
            if (String.IsNullOrEmpty(csXML))
            {
                throw new Exception("Fehler beim Erstellen der XML");
            }

            return this.SendCrefoSystemRequest(this.BuildUrl(zielURL,
                                                             csOrg,
                                                             csUsername,
                                                             csPassword,
                                                             csXML));
        }

        public string GetCrefoExecuteWorkflow(string zielURL, string csOrg, string csUsername, string csPassword, Form1 oberflaeche)
        {
            string csXML = serializer.BuildCrefoXmlRequest(oberflaeche);
            if (String.IsNullOrEmpty(csXML))
            {
                throw new Exception("Fehler beim Erstellen der XML");
            }

            return this.SendCrefoSystemRequest(this.BuildUrl(zielURL,
                                                             csOrg,
                                                             csUsername,
                                                             csPassword,
                                                             csXML));
        }

    }
}
