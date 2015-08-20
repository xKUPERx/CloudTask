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
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Logger.WriteDebugMessage("Test");
            }
            catch (Exception ex)
            {
                string xx = ex.ToString();
            }
            //Case testCase = new Case("Test Case");
            //testCase.Categories.Add(new Category("First Category"));
            //testCase.Categories.Add(new Category("Second Category"));

            //System.DateTime toDay = System.DateTime.Today;
            //foreach (Category category in testCase.Categories)
            //{
            //    category.Nodes.Add(new Node("task 1", "Do some shit", false, toDay, toDay));
            //    category.Nodes.Add(new Node("task 2", "Do some shit", true, toDay, toDay));
            //}

            //testCase.Nodes.Add(new Node("task 3", "Do some shit", false, toDay, toDay)); 
            //testCase.Nodes.Add(new Node("task 4", "Do some shit", false, toDay, toDay));

            //JsonParser jsonparser = new JsonParser();
            //jsonparser.SaveCaseToFile(ref testCase);
            //Case newTestCase;
            //jsonparser.LoadCaseFromFile(out newTestCase);

        }
    }
}
