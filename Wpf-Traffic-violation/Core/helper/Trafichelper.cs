using OfficeOpenXml;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Windows.Data;
using Wpf_Traffic_violation.MagrationDB;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Receipt = Wpf_Traffic_violation.Models.Receipt;

public class helper : IValueConverter
{
    public Wpf_Traffic_violation.MagrationDB.Violation CreateViolation(Wpf_Traffic_violation.Models.Violations_Model.Violation Violation)
    {
        byte[] img = null;
        //string dateFormat = "dd/MM/yyyy"; // Replace with the actual expected date format

        //string viol_Date = DateTime.ParseExact(
        //                        Violation.Violation_date,
        //                        dateFormat,
        //                        CultureInfo.InvariantCulture
        //                    ).ToShortDateString();

        var data = new Wpf_Traffic_violation.MagrationDB.Violation
        {
            Teaffic_man_id = 1,
            Violation_date = System.Convert.ToDateTime(Violation.Violation_date),
            vehicle_id = Violation.Plate_Num,
            Violation_photo1 = img,
            Violation_photo2 = img,
            Violation_type_id = Violation.Violation_type_id,
            Violation_penalty = Violation.Violation_penalty,
            VounchrNum = Violation.VounchrNum,
            Createdby = Violation.CreatedBy,
            CreatedOn = Violation.CreatedOn,
            Plate_id = Violation.Plate_id,
            Street_id = Violation.Street_id,
            Payment_status = 0,
            Provinceid = Violation.Provinceid,
            Notise = Violation.Notise,
            UpdatedBy = Violation.UpdateBy,
            UpdateOn = Violation.UpdateOn,
            Violation_id = Violation.Violation_id,
        };
        return data;



    }

    public Wpf_Traffic_violation.MagrationDB.Receipt CreateReceiptModel(Receipt current_Receipt, int count)
    {
        Wpf_Traffic_violation.MagrationDB.Receipt receipt = new Wpf_Traffic_violation.MagrationDB.Receipt();
        try
        {
            receipt = new Wpf_Traffic_violation.MagrationDB.Receipt
            {
                Receipt_amount = current_Receipt.Receipt_amount,
                Post_date = System.Convert.ToDateTime(current_Receipt.Receipt_date),
                Receipt_date = System.Convert.ToDateTime(current_Receipt.Receipt_date),
                Account_id = 1,
                user_id = current_Receipt.UserId,
                //Post_date = Convert.ToDateTime(current_Receipt.Post_date),
                Receipt_status = current_Receipt.Receipt_status,
                Receipt_statement = $"مقابل عدد + {count} مخالفات ",



            };
        }
        catch (Exception)
        {

        }

        return receipt;


    }
    public Wpf_Traffic_violation.MagrationDB.Receipt_detail CreateReceiptDetailModel(int receipt_id, string receipt_detail_statement, int violation_id, int receipt_detail_amount, string nameOfPaid, string resonOfPaid, int receipt_amountwithdiscont)
    {
        Wpf_Traffic_violation.MagrationDB.Receipt_detail receiptDetail = new Wpf_Traffic_violation.MagrationDB.Receipt_detail();
        try
        {
            if (string.IsNullOrEmpty(nameOfPaid))
            {
                nameOfPaid = "صاحب المركبه";

            }
            if (string.IsNullOrEmpty(resonOfPaid))
            {
                resonOfPaid = "مقابل دفع مخالفات مخالفة";
            }
            receiptDetail = new Wpf_Traffic_violation.MagrationDB.Receipt_detail
            {
                Receipt_id = receipt_id,
                Receipt_detail_statement = "مقابل مخالفة",
                ResonOfPaid = resonOfPaid,
                Violation_id = violation_id,
                Receipt_detail_amount = receipt_detail_amount,
                NameOfPaid = nameOfPaid,
                Receipt_amountwithdiscont = receipt_amountwithdiscont



            };


        }
        catch (Exception)
        {

        }
        return receiptDetail;
    }

    public ObservableCollection<Wpf_Traffic_violation.Models.Violations_Model.Violation> PreparePlateDetialForReport(ObservableCollection<Wpf_Traffic_violation.Models.Violations_Model.Violation> grid_Violation1, ObservableCollection<PlateDetails> grid_Plate, ObservableCollection<ViolationType> grid_ViolationType)
    {
        foreach (var item in grid_Violation1)
        {
            foreach (var type in grid_ViolationType)
            {
                if (item.Violation_type_id == type.Violation_type_id)
                {
                    foreach (var plate in grid_Plate)
                    {
                        if (plate.Province_id == item.Provinceid)
                        {
                            //TODO For this detaile about plate to show on the report  when we use this Attribute will change some Case
                            item.String_TrafficMan = plate.Province_id + "/" + item.Plate_Num + plate.PlateName;
                            break;
                        }

                    }
                    item.String_ViolationType = type.Violation_type_name;


                }


            }

        }
        return grid_Violation1;

    }

    public bool VildationExcleData(ExcelWorksheet worksheet, int row)
    {

        //int count=0;
        //for (int row = 2; row <= rowCount; row++) // Assuming the first row is the header
        //{
        if ((worksheet.Cells[row, 4].Text == null || worksheet.Cells[row, 4].Text == "")
          || (worksheet.Cells[row, 1].Text == null || worksheet.Cells[row, 1].Text == "")
          || (worksheet.Cells[row, 2].Text == null || worksheet.Cells[row, 2].Text == "")
          || (worksheet.Cells[row, 3].Text == null || worksheet.Cells[row, 3].Text == ""))
        {
            return false;
        }

        //count = row;

        //}
        return true;
    }

    public ObservableCollection<ViolationType> GetViollationcollecttion(DataRowCollection result)
    {
        var resoult = new ObservableCollection<ViolationType>();
        foreach (DataRow row in result)
        {

            ViolationType violationType = new ViolationType
            {
                Violation_type_id = (int)row[0],
                Violation_type_name = (string)row[1],
                Minimum_price = (int)row[2],
                Maximum_price = (int)row[3],
                Penalty = (int)row[4],
                Interception_status = System.Convert.ToBoolean(row[5])
            };

            resoult.Add(violationType);
        }
        return resoult;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
        return Binding.DoNothing;


    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    //public Wpf_Traffic_violation.MagrationDB.Violation PrepareReceipt(Violation Violation)
    //{
    //    byte[] img = null;

    //    var data = new Wpf_Traffic_violation.MagrationDB.Violation
    //    {
    //        Teaffic_man_id = 1,
    //        Violation_date = Convert.ToDateTime(Violation.Violation_date),
    //        vehicle_id = Violation.Plate_Num,
    //        Violation_photo1 = img,
    //        Violation_photo2 = img,
    //        Violation_type_id = Violation.Violation_type_id,
    //        Violation_penalty = Violation.Violation_penalty,
    //        VounchrNum = Violation.Violation_id,
    //        Createdby = Violation.CreatedBy,
    //        CreatedOn = Violation.CreatedOn,
    //        Plate_id = Violation.Plate_id,
    //        Street_id = Violation.Street_id,
    //        Payment_status = 0,
    //        Provinceid = Violation.Provinceid,
    //        Notise = Violation.Notise,
    //        UpdatedBy = Violation.UpdateBy,
    //        UpdateOn = Violation.UpdateOn,
    //    };
    //    return data;



    //}


}
