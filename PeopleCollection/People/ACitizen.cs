using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCollection.People
{
    public abstract class ACitizen: IPeople
    {
        private string passport;

        public ACitizen()
        {

        }
        public ACitizen(string Passport)
        {
            this.passport = Passport;
        }
        public virtual string GetPasport()
        {
            return passport;
        }
        private int _queue;
        public virtual int GetQueue()
        {
            return _queue;
        }
        public virtual void SetQueue(int i)
        {
            _queue = i;
        }


    }
}
