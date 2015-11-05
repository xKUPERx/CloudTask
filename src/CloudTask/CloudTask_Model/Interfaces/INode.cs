using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections;

namespace CloudTask_Model
{
    #region INodeCollection
    [CollectionDataContract]
    public class INodeCollection : CollectionBase
    {
        public INodeCollection() { }
        public INodeCollection(INode node) { this.Add(node); }
        public INodeCollection(IEnumerable value) { this.AddRange(value); }
        private object m_lockObject = new object();

        public INode this[int index]
        {
            get
            {
                return ((INode)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(INode value)
        {
            return (List.Add(value));
        }

        public void AddRange(IEnumerable value)
        {
            foreach (INode node in value)
            {
                List.Add(node);
            }
        }

        public void AddRangeToBegin(IEnumerable value)
        {
            int counter = 0;
            foreach (INode node in value)
            {
                List.Insert(counter, node);
                counter += 1;
            }
        }

        public int IndexOf(INode value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, INode value)
        {
            List.Insert(index, value);
        }

        public void Remove(INode value)
        {
            List.Remove(value);
        }

        public bool Contains(INode value)
        {
            return (List.Contains(value));
        }

        public void Sort(bool containersFirst)
        {
            lock (m_lockObject)
            {
                ArrayList nodes = new ArrayList();

                ArrayList keep = new ArrayList(List);
                foreach (INode node in keep)
                {
                    if (node.IsContainer != containersFirst)
                    {  
                        nodes.Add(node);
                        List.Remove(node);
                    }
                }

                foreach (INode node in nodes)
                {
                    List.Add(node);
                }
            }
        }

        public void Sort(IComparer comparer)
        {
            lock (m_lockObject)
            {
                ArrayList nodes = new ArrayList(List);
                nodes.Sort(comparer);
                List.Clear();
                foreach (INode node in nodes)
                {
                    List.Add(node);
                }
            }
        }

        public INodeCollection Clone()
        {
            INodeCollection newCol = new INodeCollection();
            newCol.AddRange(this);
            return newCol;
        }
    }

    #endregion INodeCollection

    public interface INode
    {
        string ID { get;}

        INode Parent { get; set; }

        string NodeName { get; set; }

        int StateImageIndex { get; set; }

        INodeCollection Nodes { get; }

        bool IsContainer { get; }

    }
}
