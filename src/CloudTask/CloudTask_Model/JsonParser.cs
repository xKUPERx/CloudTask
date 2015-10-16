using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Log;

using Newtonsoft.Json;

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

        public bool SaveCaseToFile(Case currentCase)
        {
            try
            {
                using (StreamWriter outPutFileStream = new StreamWriter(m_fileToParse))                
                {
                    string jsonTypeNameAuto = JsonConvert.SerializeObject(currentCase, Formatting.Indented, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
                    outPutFileStream.WriteLine(jsonTypeNameAuto);                   
                }
                return true;
            }
            catch(Exception ex)
            {
                Logger.WriteInfoMessage(String.Format("\nSave case to file error:\n\tFile name - {0};\n\tException - {1}", m_fileToParse, ex.ToString()));
                return false;
            }
        }

        public bool LoadCaseFromFile(out Case currentCase)
        {
            try
            {
                using (StreamReader inPutFileStream = new StreamReader(m_fileToParse))
                {                   
                   string result = inPutFileStream.ReadToEnd();
                   currentCase = (Case)JsonConvert.DeserializeObject(result, typeof(Case), new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
                }
                if (currentCase != null && currentCase.Nodes != null)
                {
                    RestoreParentLink(currentCase);
                }
                return true;
            }
            catch (Exception ex)
            {
                currentCase = null;
                Logger.WriteInfoMessage(String.Format("\nLoad case from file error:\n\tFile name - {0};\n\tException - {1}", m_fileToParse, ex.ToString()));
                return false;
            }
        }

        private void RestoreParentLink(INode parent)
        {
            foreach (INode child in parent.Nodes)
            {
                child.Parent = parent;
                if (child.Nodes != null)
                {
                    RestoreParentLink(child);
                }
            }         
        }

        #endregion Methods

    }


}
