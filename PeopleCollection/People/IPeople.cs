using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCollection.People
{
    public interface IPeople
    {
        string GetPasport();
        int GetQueue();
        void SetQueue(int i);
    }
}
