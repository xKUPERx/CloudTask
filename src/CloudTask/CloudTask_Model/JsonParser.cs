using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Log;


namespace CloudTask_Model
{
    public class JsonParser
    {
        
        #region Members

        private string m_fileToParse;

        #endregion Members

        #region Constructors

        public JsonParser(string filePath = "CloudTask.ct")
        {
            m_fileToParse = filePath;
        }

        #endregion Constructors

        #region Methods

        public void SaveCaseToFile(ref Case currentCase)
        {
            try
            {
                using (FileStream outPutFileStream = File.Create(m_fileToParse))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Case));
                    jsonSerializer.WriteObject(outPutFileStream, currentCase);
                    outPutFileStream.Flush();
                    outPutFileStream.Close();

                    Logger.WriteDebugMessage("DEBUG MODE RUSH!!!");
                }
            }
            catch(Exception ex)
            {
                Logger.WriteInfoMessage(String.Format("\nSave case to file error:\n\tFile name - {0};\n\tException - {1}", m_fileToParse, ex.ToString()));
            }
        }

        public void LoadCaseFromFile(out Case currentCase)
        {
            try
            {
                using (FileStream inPutFileStream = File.OpenRead(m_fileToParse))
                {                   
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Case));
                    currentCase = (Case)jsonSerializer.ReadObject(inPutFileStream);
                    inPutFileStream.Close();
                }
            }
            catch (Exception ex)
            {
                currentCase = null;
                Logger.WriteInfoMessage(String.Format("\nLoad case from file error:\n\tFile name - {0};\n\tException - {1}", m_fileToParse, ex.ToString()));
                //write to log
            }
        }

        #endregion Methods

    }


}
