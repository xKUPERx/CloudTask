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
    class Program
    {
        static void Main(string[] args)
        {
            System.DateTime toDay = System.DateTime.Today;
            Node testNode = new Node("task", "Do some shit", false, toDay, toDay);
            Category categoryNode = new Category();
            categoryNode.Nodes.Add(testNode);
            categoryNode.Nodes.Add(testNode);
            categoryNode.Nodes.Add(testNode);

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Category));

            ser.WriteObject(stream1, categoryNode);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());

            stream1.Position = 0;
            Category categoryNode2 = (Category)ser.ReadObject(stream1);
            
            stream1.Position = 0;
            Node testNode2 = (Node)ser.ReadObject(stream1);


        }
    }
}
