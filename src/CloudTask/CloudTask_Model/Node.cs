using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace CloudTask_Model
{
    [DataContract]
    public class Node
    {
        [DataMember]
        public string TaskName { get; set; }
        [DataMember]
        public string TaskText { get; set; }
        [DataMember]
        public bool IsDone{ get; set; }
        [DataMember]
        public System.DateTime StartDate{ get; set;}
        [DataMember]
        public System.DateTime FinishDate { get; set; }

        public Node()
        { }

        public Node(string taskName, string taskText, bool isDone, System.DateTime startDate, System.DateTime finishDate)
        {
            TaskName = taskName;
            TaskText = taskText;
            IsDone = isDone;
            StartDate = startDate;
            FinishDate = finishDate;
        }

    }
}
