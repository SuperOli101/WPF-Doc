using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dataflow
{
    class WorkingObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public WorkingObject(int id)
        {
            this._id = id;
            Thread.Sleep(100);
        }

        public void DoWork()
        {
            Thread.Sleep(500);
        }

        public override string ToString()
        {
            return ID.ToString();
        }

    }
}
