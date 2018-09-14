using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericMethods
{
    public class TestClass
    {
        public object this[string propertyName]
        {
            get
            {
                return this.GetType().GetProperty(propertyName).GetValue(this);
            }
            set
            {
                var prop=this.GetType().GetProperty(propertyName);
                if (prop != null && prop.CanWrite)
                    prop.SetValue(this, value);
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
