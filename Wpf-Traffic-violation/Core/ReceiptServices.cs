using System;
using System.Linq;
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
            var result = new Wpf_Traffic_violation.MagrationDB.Receipt();
            try
            {
                // Retrieve the last ID
                int lastId = objcontext.Receipts
                                       .OrderByDescending(r => r.Receipt_id) // Assuming 'Id' is the primary key column
                                       .Select(r => r.Receipt_id)
                                       .FirstOrDefault();

                // Assign a new ID
                receipt.Receipt_id = lastId + 1;

                // Add the new receipt
                result = objcontext.Receipts.Add(receipt);

                // Commit changes to the database
                var isCommit = objcontext.SaveChanges();
                if (isCommit > 0)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (logging, re-throwing, etc.)
                Console.WriteLine($"Error: {ex.Message}");
            }
            return result;
        }


        public Wpf_Traffic_violation.MagrationDB.Receipt_detail CreateReciptDetail(Receipt_detail prpareModel)
        {
            var result = new Wpf_Traffic_violation.MagrationDB.Receipt_detail();
            try
            {

                result = objcontext.Receipt_detail.Add(prpareModel);
                var commit = objcontext.SaveChanges();
                if (commit > 0)
                {
                    var updateRecipt = objcontext.Receipts.Find(prpareModel.Receipt_id);
                    updateRecipt.Receipt_status = true;
                    objcontext.SaveChanges();
                }
                //resoult = true;

            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
