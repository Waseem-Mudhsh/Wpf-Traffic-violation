
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity.Builder;
using Wpf_Traffic_violation.Core.helper;

namespace Wpf_Traffic_violation.Core.DataAccess
{
    public class CacheManager<T>  where T : class
    {
        private string _cacheName;
        Cach<T> cach;
        private Object cachobj;
        public CacheManager(string cacheName)
        {
            cach=new Cach<T>();
            _cacheName=cacheName;   
        }

        public void setkey( object obj)
        {
            cach.setKey(_cacheName, obj);
        }
       public void setCacheName(string namcach)
        {
            _cacheName = namcach;
        }
        public Object GetCach {
            get
            {
                return cach.GetKey(_cacheName);
            }
           
        }
        public void Remove()
        {
            
             cach.remove(_cacheName);
            

        }
        public Cach<T> ChachConfiguration
        {
            get
            {
                return cach;
            }
            set
            {
                if (_cacheName == null)
                {
                    _cacheName = value.ToString();
                }


            }
        }
      
        
    }
    public class Cach<T> where T : class
    {
        MemoryCache cache = MemoryCache.Default;
        
        public Object GetKey(string _cacheName )
        {
            return cache.Get(_cacheName);
             
        }

        public void setKey(string name,object obj)
        {
           
            if (obj != null)
            {
                cache.Add(name, obj, new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(30) });
            
            }
            else
            {
                return;
            }
        }
        public Object remove(string name)
        {
            if (name == null)
                   return false;
        
            cache.Remove(name);
            return true;
        }

    }
}
