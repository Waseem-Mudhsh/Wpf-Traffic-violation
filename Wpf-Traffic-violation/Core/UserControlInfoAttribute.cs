using System;

namespace Wpf_Traffic_violation.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UserControlInfoAttribute : Attribute
    {
        public string XamlFilePath { get; set; }
    }
}
