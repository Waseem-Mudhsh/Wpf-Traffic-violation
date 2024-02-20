using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.Core.helper
{
    public class Response<T>
    {
        private T _data;
        public string Statuse;
        public string Message;
        public int Code;
        private int _size;

        private T[] _items;

        public void SetData(T data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("data");
            }
            Data= data;


        }
        public T Data { get; set; }
  
      


    }
}
