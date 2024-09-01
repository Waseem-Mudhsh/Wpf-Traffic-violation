
using OfficeOpenXml;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Enum;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Services;
using Violation = Wpf_Traffic_violation.Models.Violations_Model.Violation;

public class ExcelReader
{
    //TrafficViolationEntitiesUat objcontext;
    ViolationServices _violationServices;
    //ViolationTypeModel violationTypeModel;

    helper _helper;
    public ExcelReader()
    {
        //objcontext = new TrafficViolationEntitiesUat();
        _violationServices = new ViolationServices();
        _helper = new helper();
    }
    public bool ReadExcelFile(string filePath)
    {
        Street_Model street_Model = new Street_Model(); ;
        ViolationTypeModel violationTypeModel = new ViolationTypeModel();
        VoilationModel ViolationModel = new VoilationModel();
        PlateOfType_Model plateOfType_Model = new PlateOfType_Model();

        FileInfo fileInfo = new FileInfo(filePath);
        try
        {
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first worksheet

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
                int row = 0;
                //bool ExcleVioladition = _helper.VildationExcleData(worksheet,rowCount);


                for (row = 2; row <= rowCount; row++) // Assuming the first row is the header
                {
                    bool ExcleVioladition = _helper.VildationExcleData(worksheet, row);

                    if (ExcleVioladition)
                    {
                        OperationEnum operationEnum = OperationEnum.insertOperation;
                        string Ourpattern = @"(\D+)(\d+)";
                        //string pattern = @"\((?<SecurityNumber>\d+)\)";
                        //string patterns = @"\(\?<SecurityNumber>\d+\)";
                        var match = Regex.Match(worksheet.Cells[row, 3].Text, Ourpattern);
                        var Text = match.Groups[1].Value;
                        string[] plateName = Text.Split('/');
                        string provic = match.Groups[2].Value;
                        byte img = 0;
                        var violatiotype = violationTypeModel.GetViolationTypeByName(worksheet.Cells[row, 4].Text);
                        var platypeid = plateOfType_Model.GetPlateByName(plateName[0]).Plate_type_id;
                        var streetid = street_Model.GetStreetByName(worksheet.Cells[row, 5].Text);
                        if (violatiotype.Violation_type_id == 0 || platypeid == 0 || streetid.Street_id == 0)
                        {
                            MessageBox.Show("قد يكون هناك بيانات غير مهيئه في النظام " + row + "يرجى مراجعة البايانات في الصف ");
                            return false;
                        }
                        var Violationdata = new Violation
                        {
                            Teaffic_man_id = 1,
                            CreatedOn = Convert.ToString(DateTime.Now),
                            Plate_Num = worksheet.Cells[row, 2].Text,
                            Violation_photo1 = img,
                            Violation_photo2 = img,
                            Violation_type_id = violatiotype.Violation_type_id,
                            VounchrNum = Convert.ToInt32(worksheet.Cells[row, 1].Text),
                            CreatedBy = 1,
                            Violation_date = (worksheet.Cells[row, 6].Text == null || worksheet.Cells[row, 6].Text == "") ? Convert.ToString(DateTime.Now) : worksheet.Cells[row, 6].Text,
                            Plate_id = platypeid,
                            Street_id = streetid.Street_id,
                            Violation_penalty = violatiotype.Maximum_price,
                            Payment_status = 0,
                            Provinceid = Convert.ToInt32(provic),
                            Notise = worksheet.Cells[row, 7].Text,
                            UpdateBy = 0,
                            UpdateOn = null,
                        };

                        var result = ViolationModel.ExcutOperarionViolation(Violationdata, (int)operationEnum);
                        if (!result)
                        {
                            return false;

                        }
                    }

                    else
                    {
                        MessageBox.Show(+row + "هناك بيانات فارغة يجب ادخالها في الصف رقم");

                    }
                }

            }


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }



        return true;
    }
}
