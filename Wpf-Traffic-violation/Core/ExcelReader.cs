using OfficeOpenXml;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using Wpf_Traffic_violation.MagrationDB;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Enum;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Services;
using Violation = Wpf_Traffic_violation.Models.Violations_Model.Violation;

public class ExcelReader
{
    TrafficViolationEntitiesUat objcontext;

    //TrafficViolationEntitiesUat objcontext;
    ViolationServices _violationServices;
    //ViolationTypeModel violationTypeModel;

    helper _helper;
    public ExcelReader()
    {
        //objcontext = new TrafficViolationEntitiesUat();
        _violationServices = new ViolationServices();
        _helper = new helper();
        objcontext = new TrafficViolationEntitiesUat();

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

                // Start a transaction
                using (var transaction = objcontext.Database.BeginTransaction())
                {
                    OperationEnum operationEnum = OperationEnum.insertOperation;


                    try
                    {
                        for (int row = 2; row <= rowCount; row++)
                        {
                            // Validate data
                            bool isValid = _helper.VildationExcleData(worksheet, row);

                            if (!isValid)
                            {
                                MessageBox.Show(
                                    $"هناك بيانات فارغة يجب إدخالها في الصف رقم {row}",
                                    "تنبيه",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning
                                );
                                transaction.Rollback(); // Rollback if validation fails
                                return false;
                            }
                            string Ourpattern = @"(\D+)(\d+)";
                            //string pattern = @"\((?<SecurityNumber>\d+)\)";
                            //string patterns = @"\(\?<SecurityNumber>\d+\)";
                            var match = Regex.Match(worksheet.Cells[row, 3].Text, Ourpattern);
                            var Text = match.Groups[1].Value;
                            string[] plateName = Text.Split('/');
                            string provic = match.Groups[2].Value;
                            byte img = 0;
                            // Extract and validate individual fields

                            var violatiotype = violationTypeModel.GetViolationTypeByName(worksheet.Cells[row, 4].Text);
                            var plateType = plateOfType_Model.GetPlateByName(worksheet.Cells[row, 3].Text.Split('/')[0]);
                            var street = street_Model.GetStreetByName(worksheet.Cells[row, 5].Text);

                            if (violatiotype.Violation_type_id == 0 || plateType.Plate_type_id == 0 || street.Street_id == 0)
                            {
                                MessageBox.Show(
                                    $"قد يكون هناك بيانات غير مهيئة في النظام في الصف رقم {row}. يرجى مراجعة البيانات.",
                                    "تنبيه",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning
                                );
                                transaction.Rollback(); // Rollback all previous inserts
                                return false;
                            }

                            // Prepare the data for insertion
                            var violationData = new Violation
                            {
                                Teaffic_man_id = 1,
                                CreatedOn = DateTime.Now.ToString(),
                                Plate_Num = worksheet.Cells[row, 2].Text,
                                Violation_photo1 = 0,
                                Violation_photo2 = 0,
                                Violation_type_id = violatiotype.Violation_type_id,
                                VounchrNum = Convert.ToInt32(worksheet.Cells[row, 1].Text),
                                CreatedBy = 1,
                                Violation_date = string.IsNullOrWhiteSpace(worksheet.Cells[row, 6].Text)
                                                 ? DateTime.Now.ToString()
                                                 : worksheet.Cells[row, 6].Text,
                                Plate_id = plateType.Plate_type_id,
                                Street_id = street.Street_id,
                                Violation_penalty = violatiotype.Maximum_price,
                                Payment_status = 0,
                                Provinceid = Convert.ToInt32(provic),
                                Notise = worksheet.Cells[row, 7].Text,
                                UpdateBy = 0,
                                UpdateOn = null,
                            };

                            // Insert the data into the database
                            bool result = ViolationModel.ExcutOperarionViolation(violationData, (int)operationEnum, objcontext);

                            if (!result)
                            {
                                MessageBox.Show(
                                    $"حدث خطأ أثناء محاولة إدخال البيانات في الصف رقم {row}.",
                                    "خطأ",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error
                                );
                                transaction.Rollback(); // Rollback all previous inserts
                                return false;
                            }
                        }

                        // Commit transaction if all rows are successfully processed
                        transaction.Commit();
                        MessageBox.Show("تم إدخال جميع البيانات بنجاح!", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an exception
                        transaction.Rollback();
                        MessageBox.Show($"حدث خطأ أثناء التنفيذ: {ex.Message}", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
        }



        return true;
    }
}
