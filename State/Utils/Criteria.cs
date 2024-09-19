using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Utils
{
    public class Criteria
    {
        private String key {  get; set; }
        private String operation { get; set; }
        private Object value { get; set; }

        public String Key { get { return key; } set { key = value; } }
        public String Operation { get { return operation; } set { operation = value; } }
        public Object Value { get { return value; } set { this.value = value; } }

    }
}
