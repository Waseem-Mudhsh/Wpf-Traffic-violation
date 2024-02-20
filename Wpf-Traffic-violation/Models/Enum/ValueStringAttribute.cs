using System;

namespace Wpf_Traffic_violation.Models.Enum
{
    internal class ValueStringAttribute : Attribute
    {
        private string v;

        public ValueStringAttribute(string v)
        {
            this.v = v;
        }
    }
}