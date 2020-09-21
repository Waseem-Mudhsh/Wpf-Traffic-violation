using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Models.Violations_Model;

namespace Wpf_Traffic_violation.Models
{
    public class StatisticViolation_Model
    {
        public int GetStatisticViolation(string from,string to ,int typ)
        {
           // int total = 0;
           int count = 0;
           
            VoilationModel V = new VoilationModel();

            ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
            V.GetViolation(Violations);
            if (from == "" && to == "")
            {
                if (typ == 1)
                {
                    foreach (Violation a in Violations)
                    {
                        if (a.Payment_status == 1)
                        {
                            count += 1;
                            //total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }
                else if (typ == 2)
                {
                    foreach (Violation a in Violations)
                    {
                        if (a.Payment_status == 0)
                        {
                            count += 1;
                           // total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }
              
            }
            else
            {
                if (typ == 1)
                {
                    foreach (Violation a in Violations)
                    {
                        if (a.Payment_status == 1 && (DateTime.Parse(a.Violation_date)>= DateTime.Parse(from) && DateTime.Parse(a.Violation_date)<= DateTime.Parse(to)))
                        {
                            count += 1;
                           // total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }
                else if (typ == 2)
                {
                    foreach (Violation a in Violations)
                    {
                        if (a.Payment_status == 0 && (a.Violation_date == from || a.Violation_date == to))
                        {
                            count += 1;
                            //total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }

            }
            return count;

        }

        

    }
}
