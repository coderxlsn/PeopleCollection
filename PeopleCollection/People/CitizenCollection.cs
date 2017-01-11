using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCollection.People
{
    public class CitizenCollection : IList<IPeople>
    {
        private IPeople[] _element;
        private int _count;
        private int _queue_pensioner;
        private int _queue;
        public CitizenCollection(int size)
        {
            _element = new IPeople[size];
            _count = 0;
            _queue_pensioner = 0;
            _queue = 0;
        }
        public void Add(IPeople element)
        {
            if(_count < _element.Length && Contains(element) == false)
            {
                int q = 0;
                if(element is Pensioner)
                {
                    q = _queue_pensioner;
                    _queue_pensioner++;
                }else
                {
                    q = _queue +_queue_pensioner;
                    _queue++;
                }
                q++;
                element.SetQueue(q);
                _element[_count] = element;
                _count++;
            }
        }
        public bool Contains(IPeople el)
        {
            foreach(IPeople element in _element)
            {
                if(el.GetPasport() == element.GetPasport())
                {
                    return true;
                }
            }
            return false;
        }
        public void Clear()
        {
            _count = 0;
        }
        public int IndexOf(IPeople el)
        {
            for(var i = 0; i < _count; i++)
            {
                if(_element[i] == el)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Insert(int index, IPeople value)
        {
            if ((_count + 1 <= _element.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _element[i] = _element[i - 1];
                }
                _element[index] = value;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(IPeople value)
        {
            if(IndexOf(value) > -1)
            {
                RemoveAt(IndexOf(value));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _element[i] = _element[i + 1];
                }
                _count--;
            }
        }

        public IPeople this[int index]
        {
            get
            {
                return _element[index];
            }
            set
            {
                _element[index] = value;
            }
        }

        // ICollection Members

        public void CopyTo(IPeople[] array, int index)
        {
            int j = index;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_element[i], j);
                j++;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        // Return the current instance since the underlying store is not
        // publicly available.
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        // IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            // Refer to the IEnumerator documentation for an example of
            // implementing an enumerator.
            //throw new Exception("The method or operation is not implemented.");
            //return (IEnumerator<IPeople>)_element.GetEnumerator();
            return GetEnumerator();
        }
        IEnumerator<IPeople> IEnumerable<IPeople>.GetEnumerator()
        {
            return (IEnumerator<IPeople>)_element.GetEnumerator();
        }
    }
}
