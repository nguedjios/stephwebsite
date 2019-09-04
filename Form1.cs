using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace CrefoApp
{
    public partial class Form1 : Form
    {
        CrefoHttpClient client;
        // Der Serializer ist für die Umsetzung der Objekte in XML
        CrefoSerializer serializer;
        // Der Parser wertet die eingegangene XML aus und erstellt Objekte
        CrefoParser parser;

        public Form1()
        {
            InitializeComponent();
            this.tabErgebnis.SelectTab(0);

            client = new CrefoHttpClient();
            serializer = new CrefoSerializer();
            parser = new CrefoParser(this.txtLogPfad.Text);
            CrefoLogger._LogPath = this.txtLogPfad.Text;
        }

        public string PdfUUID { get { return this.txtUuid.Text; } set { this.txtUuid.Text = value; } }
        public string CsUsername{ get { return this.txtCsUsername.Text; }}
        public string CsPassword { get { return this.txtCsPassword.Text; } }
        public string CsSystemID { get { return this.txtSystemID.Text; } }
        public string ExecWFExtIdentifier { get { return this.txtExtIdentifier1.Text; }  }
        public string ExecWFSearchTyp { get { return this.txtField.Text; } }
        public string ExecWFSysname  { get { return this.txtSystemName.Text; } }
        public string ExecWFName { get { return this.txtName1.Text; } }
        public string ExecWFStreet { get { return this.txtStreetName.Text; } }
        public string ExecWFCity { get { return this.txtCity.Text; } }
        public string ExecWFHouseNr { get { return this.txtHouseNumber.Text; } }
        public string ExecWFPostalCode { get { return this.txtPostalCode.Text; } }
        public string ExecWFIsoCode2 { get { return this.txtCountryISOCode2.Text; } }
        public string ExecWFTmpSaveOnly { get { return this.txtTmpSaveOnly.Text; } }
        public string CustomerReference { get { return this.txtCustomerReference.Text; } }
        public string SignalCustomerReference { get { return this.txtCustomerReference2.Text; } }
        public string ExtendedMonitoring { get { return this.txtExtended.Text; } }
        public string SignalReferenceNumber { get { return this.txtReferenceNumber2.Text; } }
        public string SignalCrefoNummer { get { return this.txtCrefoNr.Text; } }
        public string IdentCompName { get { return this.txtCompanyName.Text; } }
        public string IdentStreet { get { return this.txtStreet.Text; } }
        public string IdentHouseNr { get { return this.txtHouseNum.Text; } }
        public string IdentHouseNrAffix { get { return this.txtHouseNumAffix.Text; } }
        public string IdentPostCode { get { return this.txtPostCode.Text; } }
        public string IdentCity { get { return this.txtCity2.Text; } }
        public string IdentCountry { get { return this.txtCountry.Text; } }
        public string IdentLegalForm { get { return this.txtLegalform.Text; } }
        public string IdentDialingCode { get { return this.txtDialingcode.Text; } }
        public string IdentPhoneNr { get { return this.txtPhoneNumber.Text; } }
        public string IdentWeb { get { return this.txtWeb.Text; } }
        public string IdentRegisterType { get { return this.txtRegistertype.Text; } }
        public string IdentRegisterID { get { return this.txtRegisterId.Text; } }    
        public string TaxNumber { get { return this.txtTaxNumber.Text; } set { this.txtTaxNumber.Text = value; } }
        public string VatID { get { return this.txtVatId.Text; } set { this.txtVatId.Text = value; } }
        public string ErrorMessage { get { return this.txtErrorMessage.Text; } set { this.txtErrorMessage.Text = value; } }
        public string ErrorCode { get { return this.txtErrorCode.Text; } set { this.txtErrorCode.Text = value; } }
        public string ReferenceNumber { get { return this.txtReferenceNumber.Text; } set { this.txtReferenceNumber.Text = value; } }
        public string IdentificationNumber { get { return this.txtidentificationnumber.Text; } set { this.txtidentificationnumber.Text = value; } }
        public string Company { get { return this.txtcompany.Text; } set { this.txtcompany.Text = value; } }
        public string Street { get { return this.txtStreet2.Text; } set { this.txtStreet2.Text = value; } }
        public string HouseNumber { get { return this.txthouse.Text; } set { this.txthouse.Text = value; } }
        public string PostCode { get { return this.txtpost.Text; } set { this.txtpost.Text = value; } }
        public string City { get { return this.txtcity3.Text; } set { this.txtcity3.Text = value; } }
        public string CountryName { get { return this.txtCountryname.Text; } set { this.txtCountryname.Text = value; } }
        public string CountryCode { get { return this.txtcountry2.Text; } set { this.txtcountry2.Text = value; } }
        public string RegisterID { get { return this.txtregisterId2.Text; } set { this.txtregisterId2.Text = value; } }
        public string RegisterKey { get { return this.txtregisterKey.Text; } set { this.txtregisterKey.Text = value; } }
        public string RegisterName { get { return this.txtregisterName.Text; } set { this.txtregisterName.Text = value; } }
        public string RegisterCode { get { return this.txtregisterCode.Text; } set { this.txtregisterCode.Text = value; } }
        public string RegisterCourt { get { return this.txtregisterCourt.Text; } set { this.txtregisterCourt.Text = value; } }
        public string RegisterCourtCode { get { return this.txtregisterCourtCode.Text; } set { this.txtregisterCourtCode.Text = value; } }
        public string RegisterCourtCity { get { return this.txtregisterCourtCity.Text; } set { this.txtregisterCourtCity.Text = value; } }
        public string RegisterCourtPostCode { get { return this.txtregisterCourtPost.Text; } set { this.txtregisterCourtPost.Text = value; } }




        private void txtLogPfad_TextChanged(object sender, EventArgs e)
        {
            CrefoLogger._LogPath = this.txtLogPfad.Text;
        }

        private void checkHttpParameter()
        {
            if (String.IsNullOrEmpty(this.txtCsPassword.Text))
            {
                throw new Exception("Es wurde keine CsPassword angegeben!!!");
            }        
            if (String.IsNullOrEmpty(this.txtCsOrg.Text))
            {
                throw new Exception("Es wurde keine CsOrganization angegeben!!!");
            }
            if (String.IsNullOrEmpty(this.txtUserName.Text))
            {
                throw new Exception("Es wurde keine CsUsername angegeben!!!");
            }
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if (this.tabErgebnis.SelectedTab.Name.Equals("tabExWorkflow"))
            {
                try
                {
                    this.checkHttpParameter();
                    
                    CrefoSystemRequest temp1;

                    string response = client.GetCrefoExecuteWorkflow(this.txtWorkflow.Text,
                                                           this.txtCsOrg.Text,
                                                           this.txtUserName.Text,
                                                           this.txtCsPassword.Text,
                                                           this);

                    using (TextReader textReader = new StringReader(response))
                    {
                        using (XmlTextReader reader = new XmlTextReader(textReader))
                        {
                            reader.Namespaces = false;            // namespaces ignorieren beim lesen
                            XmlSerializer serializer = new XmlSerializer(typeof(CrefoSystemRequest));
                            temp1 = (CrefoSystemRequest)serializer.Deserialize(reader);    // Deserialize the response 
                        }
                    }

                    CrefoSystemRequestExecuteWorkflow temp2 = (CrefoSystemRequestExecuteWorkflow)temp1.Item;
                    Type_ExecuteWorkflowReply temp3 = (Type_ExecuteWorkflowReply)temp2.Item;
                    Type_AgencyInformation temp4 = temp3.agencies[0];
                    this.dataGridView1.DataSource = temp4.agencyHitlist.agencyHit;

                }


                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    this.txtResponse2.Text = ex.Message;
                }

            }

        }


        /////////////////////////////////////////////


        private void btn_ExCrefIdent_Click(object sender, EventArgs e)
        {

            if (this.tabErgebnis.SelectedTab.Name.Equals("tabCrefoIdent"))
            {
                try
                {
                    this.checkHttpParameter();

                    if (String.IsNullOrEmpty(this.txtCompanyName.Text))
                    {
                        throw new Exception("Es wurde keine CompanyName angegeben!!!");
                    }

                    if (String.IsNullOrEmpty(this.txtPostCode.Text))
                    {
                        throw new Exception("Es wurde keine PostCode angegeben!!!");
                    }

                    if (String.IsNullOrEmpty(this.txtCountry.Text))
                    {
                        throw new Exception("Es wurde keine Country angegeben!!!");
                    }

                    string response = client.GetCrefoIdent(this.txtCmdEx.Text,
                                                                this.txtCsOrg.Text,
                                                                this.txtUserName.Text,
                                                                this.txtCsPassword.Text,
                                                                this);

                    parser.CrefoIdentXmlParse(response, this);
                }

                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }

        }


        
        private void btn_CrefoSignal_Click(object sender, EventArgs e)
        {

            if (this.tabErgebnis.SelectedTab.Name.Equals("tabCrefoSignal"))
            {
                try
                {
                    this.checkHttpParameter();

                    if (String.IsNullOrEmpty(this.txtCrefoNr.Text))
                    {
                        throw new Exception("Es wurde keine CrefoNr angegeben!!!");
                    }
                     
                    string response = client.GetCrefoSignal(this.txtWorkflow.Text,
                                                                this.txtCsOrg.Text,
                                                                this.txtUserName.Text,
                                                                this.txtCsPassword.Text,
                                                                this);
                   
                    parser.CrefoSignalXmlParse(response, this);


                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
     


        private void btn_Kuendigen_Click(object sender, EventArgs e)
        {

            if (this.tabErgebnis.SelectedTab.Name.Equals("tabCrefoSignal"))
            {
                try
                {
                    this.checkHttpParameter();

                    if (String.IsNullOrEmpty(this.txtReferenceNumber2.Text))
                    {
                        throw new Exception("Es wurde keine ReferenceNumber angegeben!!!");
                    }
                    
                    string response = client.GetKuendigungCrefo(this.txtMonitoringKuend.Text,
                                                                this.txtCsOrg.Text,
                                                                this.txtUserName.Text,
                                                                this.txtCsPassword.Text,
                                                                this);
                    parser.Kuendigen(response, this);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
      

        /////////////////////////////////////////////


        private void btn_pdfAbruf_Click(object sender, EventArgs e)
        {

            if (this.tabErgebnis.SelectedTab.Name.Equals("tabPdfAbruf"))
            {
                try
                {
                    this.checkHttpParameter();

                    if (String.IsNullOrEmpty(this.txtUuid.Text))
                    {
                        throw new Exception("Es wurde keine Uuid angegeben!!!");
                    }
                                        
                    string response = client.GetCrefoPDF(this.txtCmdEx.Text,
                                                         this.txtCsOrg.Text,
                                                         this.txtUserName.Text,
                                                         this.txtCsPassword.Text,
                                                         this);
                    parser.WritePdf(response);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
