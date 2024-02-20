using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Models.Configurations_Model;

namespace Wpf_Traffic_violation.Models
{
    public class StatisticCommunication_Model
    {
        CommunicationModel C = new CommunicationModel();
        public int GetStatisticCommunication(string from, string to, int typ)
        {
          //  int total = 0;
            int count = 0;

            

            ObservableCollection<Communication> Communications = new ObservableCollection<Communication>();
            //Communications= C.GetCommunication();
            if (from == "" && to == "")
            {
                if (typ == 1)
                {
                    foreach (Communication a in Communications)
                    {
                        if (a.Communication_status == 1)
                        {
                            count += 1;
                           // total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }
                else if (typ == 2)
                {
                    foreach (Communication a in Communications)
                    {
                        if (a.Communication_status == 2)
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
                    foreach (Communication a in Communications)
                    {
                        if (a.Communication_status == 1 && (DateTime.Parse(a.Communication_date) >= DateTime.Parse(from) && DateTime.Parse(a.Communication_date) <= DateTime.Parse(to)))
                        {
                            count += 1;
                           // total = total + a.Amount + a.Violation_penalty;

                        }

                    }
                }
                else if (typ == 2)
                {
                    foreach (Communication a in Communications)
                    {
                        if (a.Communication_status == 2 && (DateTime.Parse(a.Communication_date) >= DateTime.Parse(from) && DateTime.Parse(a.Communication_date) <= DateTime.Parse(to)))
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
