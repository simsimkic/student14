using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.View
{
    class IDSequencer
    {
        private int _currId;
        private readonly string _prefix;
        
        public IDSequencer(string prefix)
        {
            this._prefix = prefix;
            this._currId = 0;
        }

        public string Next()
        {
            return this._prefix + (this._currId++).ToString();
        }

        public void Reset()
        {
            this._currId = 0;
        }
    }
}
