using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;

using System.Linq;
using System.Windows;
using Wpf_Traffic_violation.MagrationDB;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Services
{
    public class ViolationServices
    {



        public SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

        TrafficViolationEntitiesUat objcontext;
        Sphelper sphelper;
        SP_Query sP_ViolationType;
        public ViolationServices()
        {
            sphelper = new Sphelper();
            sP_ViolationType = new SP_Query();
            objcontext = new TrafficViolationEntitiesUat();

        }
        public ObservableCollection<Models.Violations_Model.Violation> GetAllViolation()
        {
            ObservableCollection<Models.Violations_Model.Violation> violations = new ObservableCollection<Models.Violations_Model.Violation>();
            try
            {

                var result = from objvio in objcontext.Violations select objvio;



                foreach (var row in result)
                {
                    var Violationtype = new Violation_type();

                    var Violationtypename = objcontext.Violation_type.Find(row.Violation_type_id);
                    Violationtype.Violation_type_name = Violationtypename.Violation_type_name;
                    Violationtype.Maximum_price = Violationtypename.Maximum_price;
                    var streetname = objcontext.Streets.Find(row.Street_id).Street_name.ToString();
                    var PlateName = objcontext.PlateDetailes.Find(row.Plate_id).PlateName.ToString();
                    var violationModel = new Models.Violations_Model.Violation
                    {
                        Violation_id = (int)row.VounchrNum,
                        Violation_date = Convert.ToString(row.Violation_date),
                        String_ViolationType = Violationtype.Violation_type_name,
                        Plate_Type = PlateName,
                        Amount = Violationtype.Maximum_price,
                        String_Street = streetname,
                        Payment_status = (int)row.Payment_status,
                        Plate_Num = row.vehicle_id


                    };

                    violations.Add(violationModel);


                }
            }
            catch (Exception)
            {

            }
            return violations;
        }
        public ObservableCollection<Models.Violations_Model.Violation> GetAllViolationReport(string typrviolation, DateTime fromd, DateTime tod)
        {

            ObservableCollection<Models.Violations_Model.Violation> violations = new ObservableCollection<Models.Violations_Model.Violation>();

            try
            {
                int countOfViolationstrue = 0;
                int countOfViolationfalse = 0;
                int sumOfViolationPenaltytru = 0;
                int sumOfViolationPenaltyfalse = 0;

                var result = (from objvio in objcontext.Violations
                              where objvio.Violation_date >= fromd && objvio.Violation_date <= tod
                              select
                              new
                              {
                                  objvio.Violation_id,
                                  objvio.Violation_date,
                                  objvio.Violation_penalty,
                                  objvio.Payment_status
                              });

                foreach (var row in result)
                {
                    if (row.Payment_status == 1)
                    {
                        countOfViolationstrue += 1;
                        sumOfViolationPenaltytru += (int)row.Violation_penalty;
                    }
                    else
                    {
                        countOfViolationfalse += 1;
                        sumOfViolationPenaltyfalse += (int)row.Violation_penalty;
                    }

                }
                var paidViolation = new Models.Violations_Model.Violation
                {
                    Violation_id = countOfViolationstrue,
                    //Violation_date = Convert.ToString(row.Violation_date),
                    Violation_penalty = sumOfViolationPenaltytru,
                    Payment_status = 1,
                };
                var upaidViolation = new Models.Violations_Model.Violation
                {
                    Violation_id = countOfViolationfalse,
                    //Violation_date = Convert.ToString(row.Violation_date),
                    Violation_penalty = sumOfViolationPenaltyfalse,
                    Payment_status = 0,
                };

                violations.Add(paidViolation);
                violations.Add(upaidViolation);
            }
            catch (Exception)
            {

            }
            return violations;
        }

        public ObservableCollection<Models.Violations_Model.Violation> GetViolationByplatNum(string platNum)
        {

            ObservableCollection<Models.Violations_Model.Violation> violations = new ObservableCollection<Models.Violations_Model.Violation>();
            var result = from obj in objcontext.Violations where obj.vehicle_id == platNum && obj.Payment_status == 0 select obj;



            foreach (var row in result)
            {
                if (row.Payment_status == 0)
                {
                    var violationModel = new Models.Violations_Model.Violation
                    {

                        Violation_date = Convert.ToString(row.Violation_date),
                        Plate_id = row.Plate_id,
                        Street_id = row.Street_id,
                        Teaffic_man_id = row.Teaffic_man_id,
                        Violation_type_id = row.Violation_type_id,
                        Notise = row.Notise,
                        Violation_penalty = (int)row.Violation_penalty,
                        Payment_status = (int)row.Payment_status,
                        CreatedOn = row.CreatedOn,
                        CreatedBy = (int)row.Createdby,
                        UpdateOn = row.UpdateOn,
                        UpdateBy = (int)row.UpdatedBy,
                        Violation_id = (int)row.Violation_id,
                        Provinceid = Convert.ToInt32(row.Provinceid),
                        Plate_Num = row.vehicle_id,


                    };
                    violations.Add(violationModel);
                }
            }
            return violations;


        }
        public ObservableCollection<Models.Violations_Model.Violation> GetViolation(string violation_id, int provicid = 0, int plattypid = 0)
        {

            ObservableCollection<Models.Violations_Model.Violation> violations = new ObservableCollection<Models.Violations_Model.Violation>();
            try
            {
                var result = from obj in objcontext.Violations
                             where obj.vehicle_id == violation_id && obj.Payment_status == 0
                               && obj.Plate_id == plattypid && obj.Provinceid == provicid
                             select obj;



                foreach (var row in result)
                {
                    var violationModel = new Models.Violations_Model.Violation
                    {

                        Violation_date = Convert.ToString(row.Violation_date),
                        Plate_id = row.Plate_id,
                        Street_id = row.Street_id,
                        Teaffic_man_id = row.Teaffic_man_id,
                        Violation_type_id = row.Violation_type_id,
                        Notise = row.Notise,
                        Violation_penalty = (int)row.Violation_penalty,
                        Payment_status = (int)row.Payment_status,
                        CreatedOn = row.CreatedOn,
                        CreatedBy = (int)row.Createdby,
                        UpdateOn = row.UpdateOn,
                        UpdateBy = (int)row.UpdatedBy,
                        Violation_id = (int)row.Violation_id,
                        Provinceid = Convert.ToInt32(row.Provinceid),
                        Plate_Num = row.vehicle_id,
                        VounchrNum = (int)row.VounchrNum,



                    };

                    violations.Add(violationModel);
                }

            }
            catch (Exception)
            {

            }

            return violations;


        }

        //internal object GetProvince(string text)
        //{
        //    string pattern = @"\((?<SecurityNumber>\d+)\)";
        //    var match = Regex.Match(text, pattern);
        //    string provic = match.Groups["SecurityNumber"].Value;
        //    var getprovinceDate = objcontext.Provinces.ToList();
        //    return object;

        //}

        public Violation_type GetViolationByName(string name)
        {
            int prices = 3000;
            var getviolationDate = objcontext.Violation_type.ToList();
            foreach (var i in getviolationDate)
            {
                if (i.Violation_type_name.Trim() == name.Trim())
                {
                    return i;
                }



            }
            var violationmodel = new Violation_type
            {
                Violation_type_name = name.Trim(),
                Maximum_price = prices,
                Minimum_price = prices,
                Penalty = 1,
                Interception_status = 1


            };
            var newtype = objcontext.Violation_type.Add(violationmodel);
            var commit = objcontext.SaveChanges();
            if (commit > 0)
            {
                return newtype;
            }
            return null;
        }

        internal ObservableCollection<ViolationType> GetViolationTypes()
        {

            //sphelper.IsExsist(sP_ViolationType.SP_GetViolationTye);
            ObservableCollection<ViolationType> violationTypes = new ObservableCollection<ViolationType>();
            //try
            //{
            //    var result = from violTypes in objcontext.Violation_type select violTypes;

            //    foreach(var row in result)
            //    {
            //        ViolationType violationType = new ViolationType
            //        {
            //            Violation_type_id = row.Violation_type_id,
            //            Violation_type_name = row.Violation_type_name,
            //            Minimum_price = row.Minimum_price,
            //            Maximum_price = row.Maximum_price,
            //            Penalty = (int)row.Penalty,
            //            Interception_status = Convert.ToBoolean(row.Interception_status)
            //        };
            //        violationTypes.Add(violationType);
            //    }
            //}
            //catch (Exception e)
            //{

            //}
            return violationTypes;
        }

        public bool updateVilation(int violationID)
        {
            bool result = false;
            try
            {
                var entityToUpdate = objcontext.Violations.Find(violationID);
                if (entityToUpdate != null)
                {
                    entityToUpdate.Payment_status = 1;
                    var commit = objcontext.SaveChanges();
                    if (commit > 0)
                    {
                        result = true;
                    }

                }

            }
            catch (Exception)
            {

            }
            return result;
        }

        public ObservableCollection<PlateDetails> GetPlate()
        {
            ObservableCollection<PlateDetails> plates = new ObservableCollection<PlateDetails>();

            try
            {
                var result = from detl in objcontext.PlateDetailes
                             join prov in objcontext.Provinces on detl.Province_id equals prov.Province_id
                             select new
                             {
                                 detl.ID,
                                 detl.Province_id,
                                 prov.Province_name,
                                 detl.PlateName,
                                 detl.Status
                             };
                foreach (var row in result)
                {
                    PlateDetails plateDetails = new PlateDetails
                    {
                        Plate_id = row.ID,
                        Province_id = row.Province_id,
                        Province_name = row.Province_name,
                        PlateName = row.PlateName,
                        Status = (int)row.Status,
                    };
                    plates.Add(plateDetails);
                }
                //objcontext.PlateDetailes.FirstOrDefault();
            }
            catch (Exception)
            {

            }


            return plates;
        }

        internal bool Delete(MagrationDB.Violation violation)
        {
            try
            {
                using (var obj = objcontext)
                {
                    var entityToDelete = obj.Violations.Find(violation.Violation_id);
                    if (entityToDelete != null)
                    {
                        obj.Entry(entityToDelete).State = EntityState.Deleted;
                        obj.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }


            }
            catch
            {

            }
            return true;
        }

        public bool Edite(MagrationDB.Violation violation)
        {
            var isEdit = false;
            try
            {
                using (var obj = new TrafficViolationEntitiesUat())
                {
                    var entityToUpdate = obj.Violations.Find(violation.Violation_id);
                    //var entityToUpdate = obj.Violations.FirstOrDefault(v => v.Violation_id == violation.Violation_id);
                    if (entityToUpdate != null)
                    {
                        try
                        {
                            obj.Entry(entityToUpdate).CurrentValues.SetValues(violation);
                            var result = obj.SaveChanges();
                            if (result > 0)
                            {
                                isEdit = true;
                            }
                            else
                            {
                                isEdit = false;

                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);

                        }

                    }
                    else { isEdit = false; }
                }
                return isEdit;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="violation"></param>
        /// <returns></returns>
        public bool Insert(MagrationDB.Violation violation)
        {
            try
            {
                objcontext.Violations.Add(violation);
                var result = objcontext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

            }
            catch (Exception)
            {

            }
            return false;
        }
        public bool Insertbulk(MagrationDB.Violation violation, int rowCount, int count)
        {

            try
            {

                objcontext.Violations.Add(violation);
                count++;
                if (count == 384)
                {

                }
                if (count == rowCount)
                {
                    var result = objcontext.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }

                }
                return true;


            }
            catch (Exception)
            {

            }
            return false;
        }

        public ObservableCollection<ReceiptReportModel> GetAllViolationByReceiptDetailes(string typrviolation, DateTime from_date, DateTime to_date)
        {

            ObservableCollection<ReceiptReportModel> receiptReportModel = new ObservableCollection<ReceiptReportModel>();
            try
            {
                if (typrviolation == "unPaid")
                {
                    var resoult = from violaton in objcontext.Violations
                                  join recpdrtail in objcontext.Receipt_detail on violaton.Violation_id equals recpdrtail.Violation_id
                                  join recpts in objcontext.Receipts on recpdrtail.Receipt_id equals recpts.Receipt_id
                                  join violtionType in objcontext.Violation_type on violaton.Violation_type_id equals violtionType.Violation_type_id
                                  where violaton.Payment_status == 1 && violaton.Violation_date >= from_date && violaton.Violation_date <= to_date


                                  select new
                                  {
                                      recpts.Receipt_id,
                                      violaton.vehicle_id,
                                      violaton.Violation_penalty,
                                      violaton.Payment_status,
                                      violtionType.Violation_type_name,
                                      recpdrtail.NameOfPaid,
                                      recpdrtail.ResonOfPaid
                                  };

                    foreach (var row in resoult)
                    {
                        var model = new ReceiptReportModel
                        {
                            ReceiptId = row.Receipt_id,
                            ReasonOfPaid = row.ResonOfPaid,
                            NameOfPaid = row.NameOfPaid,
                            ViolationPenalty = (int)row.Violation_penalty,
                            ViolationTypeName = row.Violation_type_name


                        };
                        receiptReportModel.Add(model);

                    }
                }
                else if (typrviolation == "IsPaid")
                {
                    var resoult = from violaton in objcontext.Violations
                                  join recpdrtail in objcontext.Receipt_detail on violaton.Violation_id equals recpdrtail.Violation_id
                                  join recpts in objcontext.Receipts on recpdrtail.Receipt_id equals recpts.Receipt_id
                                  join violtionType in objcontext.Violation_type on violaton.Violation_type_id equals violtionType.Violation_type_id
                                  where violaton.Payment_status == 0 && violaton.Violation_date >= from_date && violaton.Violation_date <= to_date


                                  select new
                                  {
                                      recpts.Receipt_id,
                                      violaton.vehicle_id,
                                      violaton.Violation_penalty,
                                      violaton.Payment_status,
                                      violtionType.Violation_type_name,
                                      recpdrtail.NameOfPaid,
                                      recpdrtail.ResonOfPaid
                                  };
                    foreach (var row in resoult)
                    {
                        var model = new ReceiptReportModel
                        {
                            ReceiptId = row.Receipt_id,
                            ReasonOfPaid = row.ResonOfPaid,
                            NameOfPaid = row.NameOfPaid,
                            ViolationPenalty = (int)row.Violation_penalty,
                            ViolationTypeName = row.Violation_type_name


                        };
                        receiptReportModel.Add(model);

                    }
                }
                else
                {
                    var resoult = (from violaton in objcontext.Violations
                                   join recpdrtail in objcontext.Receipt_detail on violaton.Violation_id equals recpdrtail.Violation_id
                                   join recpts in objcontext.Receipts on recpdrtail.Receipt_id equals recpts.Receipt_id
                                   join violtionType in objcontext.Violation_type on violaton.Violation_type_id equals violtionType.Violation_type_id
                                   join platedetl in objcontext.PlateDetailes on violaton.Plate_id equals platedetl.ID
                                   where recpts.Post_date >= from_date && recpts.Post_date <= to_date && violaton.Payment_status == 1

                                   select
                                 new
                                 {
                                     recpts.Receipt_id,
                                     vehicle_id = platedetl.Province_id + "/" + violaton.vehicle_id + platedetl.PlateName,
                                     violaton.Violation_penalty,
                                     violaton.Payment_status,
                                     violaton.Violation_type_id,
                                     recpdrtail.NameOfPaid,
                                     recpts.Receipt_statement
                                 }).GroupBy(x => new
                                 {

                                     x.Receipt_id,
                                     x.vehicle_id,
                                     x.Violation_penalty,
                                     x.Payment_status,
                                     x.Violation_type_id,
                                     x.NameOfPaid,
                                     x.Receipt_statement
                                 }).Select(group => new
                                 {
                                     data = group.Key,
                                     Count = group.Count()
                                 }).GroupBy(x => x.data.Receipt_id).Select(group => group.FirstOrDefault());


                    foreach (var row in resoult)
                    {
                        var model = new ReceiptReportModel
                        {

                            ReceiptId = row.data.Receipt_id,
                            ReasonOfPaid = row.data.Receipt_statement,
                            NameOfPaid = row.data.NameOfPaid,
                            ViolationPenalty = (int)row.data.Violation_penalty,
                            ViolationTypeName = Convert.ToString(row.Count),
                            VehicleId = row.data.vehicle_id


                        };
                        receiptReportModel.Add(model);

                    }

                }
            }
            catch (Exception)
            {
                return null;

            }
            return receiptReportModel;
        }

        public PlateDetaile GetPateByName(string v)
        {


            var result = objcontext.PlateDetailes.ToList();
            foreach (var i in result)
            {
                if (i.PlateName == v.Trim())
                {
                    return i;
                }
            }
            return null;

        }

        public MagrationDB.Street GetStreet(string street)
        {

            var ListStreet = objcontext.Streets.ToList();
            foreach (var i in ListStreet)
            {
                if (i.Street_name == street.Trim())
                {
                    return i;
                }
            }
            var modelSTreet = new MagrationDB.Street
            {
                Street_name = street.Trim(),
                Directerate_id = 2
            };
            var result = objcontext.Streets.Add(modelSTreet);
            var commit = objcontext.SaveChanges();
            if (commit <= 0)
            {
                return null;
            }
            return result;
        }
        private bool _disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    objcontext?.Dispose();
                }
                _disposed = true;
            }

            Dispose(disposing);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
