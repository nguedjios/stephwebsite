using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CrefoApp
{
    public class CrefoSerializer
    {

        XmlQualifiedName qualifiedName = new XmlQualifiedName("string");

        public CrefoSerializer()
        {

        }

        private string SerializeCrefoRequest(CrefoSystemRequest request)
        {

            XmlSerializer xsSubmit = new XmlSerializer(typeof(CrefoSystemRequest));     // Konvertierung zu XML
            var PdfAbrufXml = "";

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
                    PdfAbrufXml = sww.ToString(); // Your XML
                }
            }

            CrefoLogger.WriteXMLMessageLog(PdfAbrufXml);

            return PdfAbrufXml;
        }

        public Type_CustomFieldListField[] GetCustomFields(Form1 oberflaeche)
        {
            
            List<Type_CustomFieldListField> customFields = new List<Type_CustomFieldListField>();

            Type_CustomFieldListField li = new Type_CustomFieldListField
            {
                fieldName = "legitimateinterest",
                type = qualifiedName,
                Value = "LEIN-100"
            };
            Type_CustomFieldListField rl = new Type_CustomFieldListField
            {
                fieldName = "reportlanguage",
                type = qualifiedName,
                Value = "de"
            };
            Type_CustomFieldListField pt = new Type_CustomFieldListField
            {
                fieldName = "producttype",
                type = qualifiedName,
                Value = "PRTY-100"
            };
            Type_CustomFieldListField cr = new Type_CustomFieldListField
            {
                fieldName = "customerreference",
                type = qualifiedName,
                Value = oberflaeche.CustomerReference
            };

            Type_CustomFieldListField cn = new Type_CustomFieldListField
            {
                fieldName = "companyname",
                type = qualifiedName,
                Value = oberflaeche.IdentCompName
            };
            Type_CustomFieldListField street = new Type_CustomFieldListField
            {
                fieldName = "street",
                type = qualifiedName,
                Value = oberflaeche.IdentStreet
            };
            Type_CustomFieldListField hn = new Type_CustomFieldListField
            {
                fieldName = "housenumber",
                type = qualifiedName,
                Value = oberflaeche.IdentHouseNr
            };
            Type_CustomFieldListField hna = new Type_CustomFieldListField
            {
                fieldName = "housenumberaffix",
                type = qualifiedName,
                Value = oberflaeche.IdentHouseNrAffix
            };
            Type_CustomFieldListField pc = new Type_CustomFieldListField
            {
                fieldName = "postcode",
                type = qualifiedName,
                Value = oberflaeche.IdentPostCode
            };
            Type_CustomFieldListField city = new Type_CustomFieldListField
            {
                fieldName = "city",
                type = qualifiedName,
                Value = oberflaeche.IdentCity
            };
            Type_CustomFieldListField county = new Type_CustomFieldListField
            {
                fieldName = "country",
                type = qualifiedName,
                Value = oberflaeche.IdentCountry
            };
            Type_CustomFieldListField lf = new Type_CustomFieldListField
            {
                fieldName = "legalform",
                type = qualifiedName,
                Value = oberflaeche.IdentLegalForm
            };
            Type_CustomFieldListField dc = new Type_CustomFieldListField
            {
                fieldName = "dialingcode",
                type = qualifiedName,
                Value = oberflaeche.IdentDialingCode
            };
            Type_CustomFieldListField phonenumber = new Type_CustomFieldListField
            {
                fieldName = "phonenumber",
                type = qualifiedName,
                Value = oberflaeche.IdentPhoneNr
            };
            Type_CustomFieldListField web = new Type_CustomFieldListField
            {
                fieldName = "website",
                type = qualifiedName,
                Value = oberflaeche.IdentWeb
            };
            Type_CustomFieldListField registertype = new Type_CustomFieldListField
            {
                fieldName = "registertype",
                type = qualifiedName,
                Value = oberflaeche.IdentRegisterType
            };
            Type_CustomFieldListField regid = new Type_CustomFieldListField
            {
                fieldName = "registerid",
                type = qualifiedName,
                Value = oberflaeche.IdentRegisterID
            };

            customFields.Add(li);
            customFields.Add(rl);
            customFields.Add(pt);

            if (!String.IsNullOrEmpty(cr.Value))
            {
                customFields.Add(cr);
            }
            if (!String.IsNullOrEmpty(cn.Value))
            {
                customFields.Add(cn);
            }
            if (!String.IsNullOrEmpty(street.Value))
            {
                customFields.Add(street);
            }
            if (!String.IsNullOrEmpty(hn.Value))
            {
                customFields.Add(hn);
            }
            if (!String.IsNullOrEmpty(hna.Value))
            {
                customFields.Add(hna);
            }
            if (!String.IsNullOrEmpty(pc.Value))
            {
                customFields.Add(pc);
            }
            if (!String.IsNullOrEmpty(city.Value))
            {
                customFields.Add(city);
            }
            if (!String.IsNullOrEmpty(county.Value))
            {
                customFields.Add(county);
            }
            if (!String.IsNullOrEmpty(lf.Value))
            {
                customFields.Add(lf);
            }
            if (!String.IsNullOrEmpty(dc.Value))
            {
                customFields.Add(dc);
            }
            if (!String.IsNullOrEmpty(phonenumber.Value))
            {
                customFields.Add(phonenumber);
            }
            if (!String.IsNullOrEmpty(web.Value))
            {
                customFields.Add(web);
            }
            if (!String.IsNullOrEmpty(registertype.Value))
            {
                customFields.Add(registertype);
            }
            if (!String.IsNullOrEmpty(regid.Value))
            {
                customFields.Add(regid);
            }

            return customFields.ToArray();
        }

        private Type_Authorisation BuildAuthorization(Form1 oberflaeche)
        {
            return new Type_Authorisation
            {
                userName = oberflaeche.CsUsername,
                password = oberflaeche.CsPassword,
                systemId = oberflaeche.CsSystemID
            };
        }

        public string BuildCrefoPdf(Form1 oberflaeche)
        {
            Type_CustomFieldListField[] customFields = GetCustomFields(oberflaeche);

            CrefoSystemRequest request = new CrefoSystemRequest
            {
                Item = new CrefoSystemRequestExecuteCommand
                {
                    Item = new Type_ExecuteCommandRequest
                    {
                        commandSelection = new Type_ExecuteCommandRequestCommandSelection
                        {
                            commandName = "cto-pdf-retrieve"
                            //commandName = "cto-xml-retrieve"
                        },
                        contextSelection = new Type_ExecuteCommandRequestContextSelection
                        {
                            commandFields = new Type_CustomFieldListField[]
                            {
                                new Type_CustomFieldListField
                                {
                                    fieldName ="pdfDocumentUUID",
                                    //fieldName = "xmlDocumentId",
                                    type = qualifiedName,
                                    Value = oberflaeche.PdfUUID
                                }
                            }
                        }
                    }
                }
            };
            return SerializeCrefoRequest(request);
        }

        public string BuildCrefoIdentXml(Form1 oberflaeche)
        {
            Type_CustomFieldListField[] customFields = GetCustomFields(oberflaeche);

            CrefoSystemRequest request = new CrefoSystemRequest
            {
                Item = new CrefoSystemRequestExecuteCommand
                {
                    Item = new Type_ExecuteCommandRequest
                    {
                        commandSelection = new Type_ExecuteCommandRequestCommandSelection
                        {
                            commandName = "identificationreport_chain"
                        },
                        contextSelection = new Type_ExecuteCommandRequestContextSelection
                        {
                            commandFields = customFields
                        }
                    }
                }
            };

            return SerializeCrefoRequest(request);
        }

        public string BuildCrefoXmlRequest(Form1 oberflaeche)
        {

            Type_BusinessContactReference referenceBC = new Type_BusinessContactReference
            {
                externIdentifier1 = oberflaeche.ExecWFExtIdentifier,
                systemName = oberflaeche.ExecWFSysname
            };

            Type_AddressReference referenceAdr = new Type_AddressReference
            {
                externIdentifier1 = oberflaeche.ExecWFExtIdentifier,
                systemName = oberflaeche.ExecWFSysname
            };

            CrefoSystemRequest request = new CrefoSystemRequest
            {

                authorisation = BuildAuthorization(oberflaeche),
                Item = new CrefoSystemRequestExecuteWorkflow
                {
                    Item = new Type_ExecuteWorkflowRequest
                    {
                        persistantData = new Type_WorkflowData
                        {
                            businessContact = new Type_ComplexBusinessContactWithAddionalData
                            {
                                name1 = oberflaeche.ExecWFName,
                                tmpSaveOnly = oberflaeche.ExecWFTmpSaveOnly,
                                mainAddress = new Type_Address
                                {
                                    streetName = oberflaeche.ExecWFStreet,
                                    city = oberflaeche.ExecWFCity,
                                    houseNumber = oberflaeche.ExecWFHouseNr,
                                    postalCode = oberflaeche.ExecWFPostalCode,
                                    Item = oberflaeche,
                                    reference = referenceAdr,
                                },
                                reference = referenceBC,
                            }
                        },
                        workflowSelection = new Type_ExecuteWorkflowRequestWorkflowSelection
                        {
                            workflowName = oberflaeche.ExecWFExtIdentifier,
                        },
                        workflowFields = new Type_CustomFieldListField[]
                        {
                           new Type_CustomFieldListField
                           {
                               Value = oberflaeche.ExecWFSearchTyp,
                                fieldName = "CTO.SearchType",
                                type = qualifiedName,
                           }
                        }
                    }
                }
            };

            return SerializeCrefoRequest(request);
        }

        public string BuildCrefoSignalXml(Form1 oberflaeche)
        {
            Type_CustomFieldListField[] customFields = GetCustomFields(oberflaeche);

            CrefoSystemRequest request = new CrefoSystemRequest
            {
                authorisation = BuildAuthorization(oberflaeche),

                Item = new CrefoSystemRequestExecuteWorkflow
                {
                    Item = new Type_ExecuteWorkflowRequest
                    {
                        workflowSelection = new Type_ExecuteWorkflowRequestWorkflowSelection
                        {
                            workflowName = "iff_CrefoCtoRetrieve"
                        },
                        persistantData = new Type_WorkflowData
                        {
                            businessContact = new Type_ComplexBusinessContactWithAddionalData
                            {
                                reference = new Type_BusinessContactReference
                                {
                                    externIdentifier1 = oberflaeche.SignalReferenceNumber,
                                    systemName = "CrefoSystem"
                                },

                                legalForm = new Type_BusinessContactLegalForm
                                {
                                    countryCodeISO2 = "DE"
                                },
                                businessContactType = Type_BusinessContactBusinessContactType.business,
                                creditreformNr = oberflaeche.SignalCrefoNummer,
                                tmpSaveOnly = "true",
                                mainAddress = new Type_Address
                                {
                                    reference = new Type_AddressReference
                                    {
                                        externIdentifier1 = oberflaeche.SignalReferenceNumber,
                                        systemName = "CrefoSystem"
                                    },
                                    Item = "DE"
                                }
                            }
                        },
                        workflowFields = new Type_CustomFieldListField[] {
                            new Type_CustomFieldListField{
                                fieldName ="CTO.ReportLanguage",
                                type = qualifiedName,
                                Value =  "de"
                            },
                            new Type_CustomFieldListField{
                                fieldName ="CTO.LegitimateInterest",
                                type = qualifiedName,
                                Value =  "LEIN-100" //"LEIN-101" -> aus Doku
                            },
                            new Type_CustomFieldListField{
                                fieldName ="CTO.ProductType",
                                type = qualifiedName,
                                Value =  "PRTY-1102"
                            },
                            new Type_CustomFieldListField{
                                fieldName ="CTO.CustomerReference",
                                type = qualifiedName,
                                Value = oberflaeche.SignalCustomerReference
                            },
                            new Type_CustomFieldListField{
                                fieldName ="CTO.ExtendedMonitoring",
                                type = qualifiedName,
                                Value =  "true"
                            },new Type_CustomFieldListField{
                                fieldName ="CTO.EndOfExtendedMonitoring",
                                type = qualifiedName,
                                Value = oberflaeche.ExtendedMonitoring
                            },
                            new Type_CustomFieldListField{
                                fieldName ="CTO.ExtendedMonitoringPlus",
                                type = qualifiedName,
                                Value =  "false"
                            },

                        }
                    }
                }
            };

            return SerializeCrefoRequest(request);
        }

        public string BuildCrefoKuendigenXml(Form1 oberflaeche)
        {
            
            CrefoSystemRequest request = new CrefoSystemRequest
            {
                Item = new CrefoSystemRequestCreditreformCancelStandardMonitoring
                {
                    Item = new Type_CancelStandardMonitoringRequest
                    {
                        Item = oberflaeche.SignalCustomerReference
                    }
                }
            };

            return SerializeCrefoRequest(request);
        }
    }
}
