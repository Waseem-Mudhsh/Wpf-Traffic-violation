using System;
using System.Windows;

public class ArabicNumberToTextConverter
{
    private static readonly string[] units = { "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة" };
    private static readonly string[] tens = { "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
    private static readonly string[] teens = { "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
    private static readonly string[] hundreds = { "", "مئة", "مئتان", "ثلاثمئة", "أربعمئة", "خمسمئة", "ستمئة", "سبعمئة", "ثمانمئة", "تسعمئة" };

    public static string ConvertToArabicText(int number)
    {
        string words = "";

        try
        {
            if (number == 0) return "صفر";


            // Handle thousands
            if (number >= 1000)
            {
                int thousandPart = number / 1000;
                number %= 1000;

                if (thousandPart == 1)
                    words += "ألف";
                else if (thousandPart == 2)
                    words += "ألفان";
                else if (thousandPart <= 10)
                    words += units[thousandPart] + " آلاف";
                else
                    words += ConvertToArabicText(thousandPart) + " ألف";

                if (number > 0) words += " و ";
            }

            // Handle hundreds
            if (number >= 100)
            {
                int hundredPart = number / 100;
                words += hundreds[hundredPart];
                number %= 100;

                if (number > 0) words += " و ";
            }

            // Handle tens
            if (number >= 20)
            {
                int tenPart = number / 10;
                words += units[tenPart];
                number %= 10;

                if (number > 0) words += " و ";
            }

            // Handle teens
            if (number >= 10)
            {
                words += teens[number - 10];
            }
            else if (number > 0)
            {
                // Handle units
                words += tens[number];
            }

        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);

        }
        finally
        {
        }
        return words;
    }
    public string getArabicText(int number)
    {
        return ConvertToArabicText(number);

    }

}
