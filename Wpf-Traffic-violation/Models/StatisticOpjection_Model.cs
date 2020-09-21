using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.Models
{
    public class StatisticOpjection_Model
    {
        public int GetStatisticOpjection(string from, string to, int typ)
        {
            //  int total = 0;
            int count = 0;

            OpjectionModel O = new OpjectionModel();

            ObservableCollection<Opjection> Opjections = new ObservableCollection<Opjection>();
            O.GetOpjection(Opjections);
            if (from == "" && to == "")
            {
                if (typ == 1)
                {
                    foreach (Opjection a in Opjections)
                    {
                        if (a.Status == 1)
                        {
                            count += 1;
                            // total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }
                else if (typ == 2)
                {
                    foreach (Opjection a in Opjections)
                    {
                        if (a.Status == 2)
                        {
                            count += 1;
                            //   total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }

            }
            else
            {
                if (typ == 1)
                {
                    foreach (Opjection a in Opjections)
                    {
                        if (a.Status == 1 && (DateTime.Parse(a.Interception_date) >= DateTime.Parse(from) && DateTime.Parse(a.Interception_date) <= DateTime.Parse(to)))
                        {
                            count += 1;
                            // total = total + a.Amount + a.Violation_penalty;

                        }
                       

                    }
                }
                else if (typ == 2)
                {
                    foreach (Opjection a in Opjections)
                    {
                        if (a.Status == 2 && (DateTime.Parse(a.Interception_date) >= DateTime.Parse(from) && DateTime.Parse(a.Interception_date) <= DateTime.Parse(to)))
                        {
                           
                            count += 1;
                            // total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }

            }
            return count;

        }
    }
}
