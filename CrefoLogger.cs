using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrefoApp
{
    public static class CrefoLogger
    {
        public static string _LogPath { get; set; }

        public static void WriteXMLMessageLog(string xmlmessage)         // create logFile in C:\Temp\logFile
        {
            string _day = DateTime.Now.ToString("yyyyMMdd");
            string _LogFile = _LogPath + "logFile_" + _day + ".log";

            try
            {
                if (!Directory.Exists(@"C:\Temp\"))
                    System.IO.Directory.CreateDirectory(@"C:\Temp\");

                using (FileStream fs = new FileStream(_LogFile, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter w = new StreamWriter(fs))
                    {
                        w.WriteLine("+++++++ Begin XmlMessage: " + _day + " +++++++ ");
                        w.Write(xmlmessage);
                        w.WriteLine("\n" + "+++++++ End XmlMessage: " + _day + " +++++++ " + "\n");
                        w.Flush();
                        w.Close();
                    }

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
