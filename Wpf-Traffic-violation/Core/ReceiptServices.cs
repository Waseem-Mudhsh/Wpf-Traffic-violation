using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.MagrationDB;

namespace Wpf_Traffic_violation.Services
{
   public class ReceiptServices
    {

        TrafficViolationEntitiesUat objcontext;
        public ReceiptServices()
        {
            objcontext = new TrafficViolationEntitiesUat();

        }
        public Wpf_Traffic_violation.MagrationDB.Receipt CreateNewRecipt(Receipt receipt)
        {
            var resoult = new Wpf_Traffic_violation.MagrationDB.Receipt();
            try
            {
                resoult= objcontext.Receipts.Add(receipt);
              var Iscommit=  objcontext.SaveChanges();
                if (Iscommit > 0)
                {
                    return resoult;
                }
            }
            catch (Exception e)
            {

            }
            return resoult;


        }

        public Wpf_Traffic_violation.MagrationDB.Receipt_detail CreateReciptDetail(Receipt_detail prpareModel)
        {
            var result = new Wpf_Traffic_violation.MagrationDB.Receipt_detail();
            try
            {

                result = objcontext.Receipt_detail.Add(prpareModel);
              var commit=  objcontext.SaveChanges();
                 if (commit > 0)
                {
                    var updateRecipt = objcontext.Receipts.Find(prpareModel.Receipt_id);
                    updateRecipt.Receipt_status = true;
                    objcontext.SaveChanges();
                }   
                //resoult = true;

            }catch(Exception e)
            {
            }

            return result;
        }
    }
}
