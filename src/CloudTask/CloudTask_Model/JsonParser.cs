using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace CloudTask_Model
{
    public class JsonParser
    {
        private string m_fileToParse;

        public JsonParser(string filePath)
        {
            m_fileToParse = filePath;
        }

        public void SaveCaseToFile(ref Case currentCase)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Case));

                jsonSerializer.WriteObject(stream, currentCase);
                using (StreamWriter outPutFile = new StreamWriter( @"\CloudTask.ct", true))
                {
                    outPutFile.Write(stream);
                    outPutFile.Flush();
                    outPutFile.Close();
                }
            }
            catch(Exception ex)
            {
                //write to log
            }
        }

        public void LoadCaseFromFile(out Case currentCase)
        {
            try
            {
                using (StreamReader inPutFile = new StreamReader(@"\CloudTask.ct"))
                {
                    MemoryStream stream = new MemoryStream();
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Case));
                    inPutFile.ReadToEnd();

                    currentCase = jsonSerializer.ReadObject(inPutFile.ToString());
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
