using Bytescout.Spreadsheet;
using Bytescout.Spreadsheet.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Cell = Bytescout.Spreadsheet.Cell;

namespace WorkingShedule.Data
{
    internal class FileManager
    {
        static string fileExportPath = string.Empty;
        static string fileFullPath = string.Empty;
        static readonly string filePath = @"\Document\WorkingShedule.xlsx";
        static string fileTXTPath = @"\Document\WorkingShedule.txt";
        static CalculatingHelp helpCalc = new CalculatingHelp();

        public static string MakeFilePath()
        {
            string directory = @"/WorkingList/";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string day = DateTime.Now.Day.ToString(), month = DateTime.Now.Month.ToString(), year = DateTime.Now.Year.ToString();
            return $"{directory}/WL_{year}_{month}{day}.xlsx";
        }

        public static List<Employee> LoadListFromFile(string week = "shedule")
        {
            List<Employee> listEmployee = new List<Employee>();
            fileFullPath = string.Concat(Environment.CurrentDirectory + filePath);
            CalculatingHelp dayInWeek = new CalculatingHelp();
            try
            {
                using (Spreadsheet document = new Spreadsheet())
                {
                    document.LoadFromFile(fileFullPath);
                    Worksheet sheet = document.Worksheets.ByName(week);

                    for (int row = 1; row <= sheet.UsedRangeRowMax; row++)
                    {
                        List<dayPosition> listPositions = new List<dayPosition>();
                        string name = sheet.Cell(row, 0).ValueAsString;
                        for (int col = 2; col < sheet.UsedRangeColumnMax; col++)
                        {
                            string hoursShift = sheet.Cell(row, col).ValueAsString;
                            listPositions.Add(new dayPosition
                            {
                                DayinWeek = dayInWeek.DayInWeek(col),
                                shiftName = hoursShift,
                                HoursInDay = helpCalc.WorkingHours(hoursShift),
                            });
                        }
                        listEmployee.Add(new Employee
                        {
                            Name = name,
                            InitHours = sheet.Cell(row, 1).ValueAsInteger,
                            PositionsList = listPositions
                        });

                    }
                    helpCalc.RestHoursCalc(listEmployee);

                }

            }
            catch (Exception e)
            {
                listEmployee = new List<Employee>();
            }

            return listEmployee;
        }

        

        internal static void WriteChangedEmployeeInExcel(Employee selectedEmpl, List<Employee> listEmployee, string week = "shedule")
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                int colRest = 0;
                document.LoadFromFile(fileFullPath);
                Bytescout.Spreadsheet.Worksheet sheet = document.Worksheets.ByName(week);
                for (int row = 0; row < listEmployee.Count; row++)
                {
                    if (listEmployee[row].Name == selectedEmpl.Name)
                    {
                        for (int col = 0; col < selectedEmpl.PositionsList.Count; col++)
                        {
                            string position = helpCalc.ShiftPositionToWrite(selectedEmpl.PositionsList[col].shiftName.ToString());
                            sheet.Cell(row+1, col+2).ValueAsString = position;
                            listEmployee[row].PositionsList[col].HoursInDay = selectedEmpl.PositionsList[col].HoursInDayCalc();
                            colRest = col + 3;
                        }
                        listEmployee[row].RestHours = selectedEmpl.RestHours;
                        sheet.Cell(row+1, colRest).ValueAsString = selectedEmpl.RestHours;
                    }
                }
                document.SaveAsXLSX(fileFullPath);
            }

        }

        internal static void WriteEditedEmployeeInExcel(Employee emp, string oldName, string week = "shedule")
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                int rowWrite = 0;
                document.LoadFromFile(fileFullPath);
                Worksheet sheet = document.Worksheets.ByName(week);
                for (int row = 1; row <= sheet.UsedRangeRowMax; row++)
                {
                    string nameSheet = sheet.Cell(row, 0).ValueAsString;
                    if (nameSheet == oldName)
                    {
                        rowWrite = row;
                    }
                }

                sheet.Cell(rowWrite, 0).ValueAsString = emp.Name;
                sheet.Cell(rowWrite, 1).ValueAsString = emp.InitHours.ToString();

                document.SaveAsXLSX(fileFullPath);
            }
        }

        internal static void WriteNewEmployeeInExcel(Employee emp, string week = "shedule")
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                document.LoadFromFile(fileFullPath);
                Bytescout.Spreadsheet.Worksheet sheet = document.Worksheets.ByName(week);
                int rowWrite = sheet.UsedRangeRowMax + 1;

                sheet.Cell(rowWrite, 0).ValueAsString = emp.Name;
                sheet.Cell(rowWrite, 1).ValueAsString = emp.InitHours.ToString();
                for (int col = 2; col <= 8; col++)
                {
                    sheet.Cell(rowWrite, col).ValueAsString = emp.PositionsList[col - 2].shiftName;
                }
                sheet.Cell(rowWrite, 9).ValueAsString = emp.RestHours;
                document.SaveAsXLSX(fileFullPath);
            }
        }

        internal static void WriteEmployeeInExcel(Employee selected, string daySelected, string week = "shedule")
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                int rowWrite = 1;
                document.LoadFromFile(fileFullPath);
               Worksheet sheet = document.Worksheets.ByName(week);
                for (int row = 1; row <= sheet.UsedRangeRowMax; row++)
                {
                    string nameSheet = sheet.Cell(row, 0).ValueAsString;
                    if (nameSheet == selected.Name)
                    {
                        rowWrite = row;
                    }
                }
                if (selected.RestHours != null)
                {
                    sheet.Cell(rowWrite, 9).ValueAsString = selected.RestHours.ToString();
                    sheet.Cell(rowWrite, 1).ValueAsString = selected.InitHours.ToString();
                }

                switch (daySelected)
                {
                    case "Monday":
                        sheet.Cell(rowWrite, 2).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[0].shiftName);
                        break;
                    case "Tuesday":
                        sheet.Cell(rowWrite, 3).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[1].shiftName);
                        break;
                    case "Wednesday":
                        sheet.Cell(rowWrite, 4).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[2].shiftName);
                        break;
                    case "Thursday":
                        sheet.Cell(rowWrite, 5).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[3].shiftName);
                        break;
                    case "Friday":
                        sheet.Cell(rowWrite, 6).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[4].shiftName);
                        break;
                    case "Saturday":
                        sheet.Cell(rowWrite, 7).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[5].shiftName);
                        break;
                    case "Sunday":
                        sheet.Cell(rowWrite, 8).ValueAsString = helpCalc.ShiftPositionToWrite(selected.PositionsList[6].shiftName);
                        break;
                    default:
                        break;
                }
                document.SaveAsXLSX(fileFullPath);
            }
        }

        internal static string GenerateFile()
        {
            fileExportPath = MakeFilePath();
            if (File.Exists(fileExportPath))
            {
                File.Delete(fileExportPath);

            }
            FileStream fs = new FileStream(fileExportPath, FileMode.Create);
            fs.Close();
            using (Spreadsheet document = new Spreadsheet())
            {
                document.LoadFromFile(fileExportPath);

                Bytescout.Spreadsheet.Worksheet sheet = document.Worksheets.Add(DateTime.Now.Month.ToString());
                document.Worksheets.Delete("Untitled1");
                document.SaveAsXLSX(fileExportPath);
            }
            return fileExportPath;
        }
        internal static string GetPathText()
        {
            FileInfo fi = new FileInfo(fileExportPath);
            return fi.FullName;
        }


        internal static void WriteRestHoursInEXCELDoc(List<Employee> listEmployee)
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                int rowWrite = 1;
                document.LoadFromFile(fileFullPath);
                Bytescout.Spreadsheet.Worksheet sheet = document.Worksheets.ByName("shedule");
                foreach (Employee worker in listEmployee)
                {
                    sheet.Cell(rowWrite,9).ValueAsString = worker.RestHours.ToString();
                    rowWrite++;
                }
            }
        }
        internal static void WriteRestHoursInTXT(List<Employee> listEmployee)
        {
            using (StreamWriter document = new StreamWriter(fileTXTPath))
            {
                int rowWrite = 0;
                foreach (Employee worker in listEmployee)
                {
                    string Shift = $"|{worker.PositionsList[rowWrite]}";
                    document.WriteLine($"{worker.Name}|{worker.InitHours}|{worker.PositionsList[rowWrite]}");
                    rowWrite++;
                }
            }
        }

        internal static void DeleteWorkerInEXCEL(TextBox tbName, string week = "shedule")
        {
            List<Employee> listEmployee = LoadListFromFile(week);
            using (Spreadsheet document = new Spreadsheet())
            {
                int rowDelete = 0;
                document.LoadFromFile(fileFullPath);
                Worksheet sheet = document.Worksheets.ByName(week);
                for (int row = 1; row <= sheet.UsedRangeRowMax; row++)
                {
                    string nameSheet = sheet.Cell(row, 0).ValueAsString;
                    if (nameSheet == tbName.Text)
                    {
                        rowDelete = row;
                    }
                }
                sheet.Rows.Delete(rowDelete,sheet.UsedRangeRowMax);
                for (int rowWr = rowDelete; rowWr < listEmployee.Count; rowWr++)
                {
                    sheet.Cell(rowWr, 0).ValueAsString= listEmployee[rowWr].Name;
                    sheet.Cell(rowWr, 1).ValueAsString= listEmployee[rowWr].InitHours.ToString();
                    for (int col = 2; col <= 8; col++)
                    {
                        sheet.Cell(rowWr, col).ValueAsString = listEmployee[rowWr].PositionsList[col - 2].shiftName;
                    }
                    sheet.Cell(rowWr, 9).ValueAsString = listEmployee[rowWr].RestHours;
                }
                document.SaveAsXLSX(fileFullPath);
            }
        }

        internal static void WriteWorkHoursInEXCEL(Employee selected, string week= "shedule")
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                int rowWrite = 1;
                document.LoadFromFile(fileFullPath);
                Bytescout.Spreadsheet.Worksheet sheet = document.Worksheets.ByName(week);
                for (int row = 1; row <= sheet.UsedRangeRowMax; row++)
                {
                    string nameSheet = sheet.Cell(row, 0).ValueAsString;
                    if (nameSheet == selected.Name)
                    {
                        rowWrite = row;
                    }
                }

                sheet.Cell(rowWrite, 2).ValueAsString = selected.InitHours.ToString();
                helpCalc.RestHoursCalc(selected);
                sheet.Cell(rowWrite, 9).ValueAsString = selected.RestHours.ToString();
                
            }
        }

        internal static void OpenEXCELGenerierdFile(List<Employee> firstWeek, List<Employee> secondWeek, List<Employee> tirdWeek, List<Employee> fourdWeek, string filePath)
        {
            using (Spreadsheet document = new Spreadsheet())
            {
                int coll = 2;
                document.LoadFromFile(filePath);
                Worksheet sheet = document.Worksheets.ByName(DateTime.Now.Month.ToString());
                document.Worksheets.Delete("Untitled1");

                List<string> DaysInWeek = helpCalc.DaysInWeek();

                sheet.Cell(0, 1).ValueAsString = "Stunde";
                sheet.Cell(0, 2).ValueAsString = "Montag";
                sheet.Cell(0, 3).ValueAsString = "Dinstag";
                sheet.Cell(0, 4).ValueAsString = "Mitwoch";
                sheet.Cell(0, 5).ValueAsString = "Donnerstag";
                sheet.Cell(0, 6).ValueAsString = "Freitag";
                sheet.Cell(0, 7).ValueAsString = "Samstag";
                sheet.Cell(0, 8).ValueAsString = "Sontag";
                sheet.Cell(0, 9).ValueAsString = "Rest";
                for (int coli = 1; coli <= 9; coli++)
                {
                    Cell currentCell = sheet.Cell(0, coli);
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                }
                for (int col = 0; col < 9; col++)
                {
                    sheet.Columns[col].AutoFit();

                }
                for (int i = 0; i < 7; i++)
                {
                    Cell currentCell = sheet.Cell(1, coll);
                    currentCell.ValueAsString= DaysInWeek[i];
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                    coll++;
                }
                coll = 2;
                for (int row = 0; row < firstWeek.Count; row++)
                {
                    sheet.Cell(row + 2, 0).ValueAsString = firstWeek[row].Name;
                    Cell currentCell = sheet.Cell(row + 2, 0);
                    helpCalc.CellStyleName(currentCell);

                    sheet.Cell(row + 2, 1).ValueAsString = firstWeek[row].InitHours.ToString();
                    Cell initCellStyle = sheet.Cell(row + 2, 1);
                    helpCalc.CellStyleInit(initCellStyle);

                    for (int col = 0; col < firstWeek[row].PositionsList.Count; col++)
                    {
                        sheet.Cell(row + 2, col + 2).ValueAsString = helpCalc.ShiftPositionToWrite(firstWeek[row].PositionsList[col].shiftName.ToString());
                        Cell positionCell = sheet.Cell(row + 2, col + 2);
                        helpCalc.CellStylePosition(positionCell);

                    }
                    sheet.Cell(row + 2, 9).ValueAsString = firstWeek[row].RestHours.ToString();
                    Cell restCellStyle = sheet.Cell(row + 2, 9);
                    helpCalc.CellStyleRest(restCellStyle);

                }

                int row2 = firstWeek.Count + 4;
                sheet.Cell(row2, 1).ValueAsString = "Stunde";
                sheet.Cell(row2, 2).ValueAsString = "Montag";
                sheet.Cell(row2, 3).ValueAsString = "Dinstag";
                sheet.Cell(row2, 4).ValueAsString = "Mitwoch";
                sheet.Cell(row2, 5).ValueAsString = "Donnerstag";
                sheet.Cell(row2, 6).ValueAsString = "Freitag";
                sheet.Cell(row2, 7).ValueAsString = "Samstag";
                sheet.Cell(row2, 8).ValueAsString = "Sontag";
                sheet.Cell(row2, 9).ValueAsString = "Rest";

                for (int coli = 1; coli <= 9; coli++)
                {
                    Cell currentCell = sheet.Cell(row2, coli);
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                }
                for (int col = 0; col < 9; col++)
                {
                    sheet.Columns[col].AutoFit();

                }
                for (int i = 7; i < 14; i++)
                {
                   Cell currentCell = sheet.Cell(row2 + 1, coll);
                    currentCell.ValueAsString= DaysInWeek[i];
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                    coll++;
                }
                coll = 2;
                for (int row = 0; row < secondWeek.Count; row++)
                {
                    sheet.Cell(row2 + row + 2, 0).ValueAsString = secondWeek[row].Name;
                    Cell currentCell = sheet.Cell(row2 + row + 2, 0);
                    helpCalc.CellStyleName(currentCell);

                    sheet.Cell(row2 + row + 2, 1).ValueAsString = secondWeek[row].InitHours.ToString();
                    Cell initCellStyle = sheet.Cell(row2 + row + 2, 1);
                    helpCalc.CellStyleInit(initCellStyle);

                    for (int col = 0; col < secondWeek[row].PositionsList.Count; col++)
                    {
                        sheet.Cell(row2 + row + 2, col + 2).ValueAsString = helpCalc.ShiftPositionToWrite(secondWeek[row].PositionsList[col].shiftName.ToString());
                        Cell positionCell = sheet.Cell(row2 + row + 2, col + 2);
                        helpCalc.CellStylePosition(positionCell);

                    }
                    sheet.Cell(row2 + row + 2, 9).ValueAsString = secondWeek[row].RestHours.ToString();
                    Cell restCellStyle = sheet.Cell(row2 + row + 2, 9);
                    helpCalc.CellStyleRest(restCellStyle);
                }
                int row3 = row2 + secondWeek.Count + 4;
                sheet.Cell(row3, 1).ValueAsString = "Stunde";
                sheet.Cell(row3, 2).ValueAsString = "Montag";
                sheet.Cell(row3, 3).ValueAsString = "Dinstag";
                sheet.Cell(row3, 4).ValueAsString = "Mitwoch";
                sheet.Cell(row3, 5).ValueAsString = "Donnerstag";
                sheet.Cell(row3, 6).ValueAsString = "Freitag";
                sheet.Cell(row3, 7).ValueAsString = "Samstag";
                sheet.Cell(row3, 8).ValueAsString = "Sontag";
                sheet.Cell(row3, 9).ValueAsString = "Rest";

                for (int coli = 1; coli <= 9; coli++)
                {
                    Cell currentCell = sheet.Cell(row3, coli);
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                }
                for (int col = 0; col < 9; col++)
                {
                    sheet.Columns[col].AutoFit();

                }
                for (int i = 14; i < 21; i++)
                {
                    Cell currentCell = sheet.Cell(row3 + 1, coll);
                    currentCell.ValueAsString = DaysInWeek[i];
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                    coll++;
                }
                coll = 2;
                for (int row = 0; row < tirdWeek.Count; row++)
                {
                    sheet.Cell(row3 + row + 2, 0).ValueAsString = tirdWeek[row].Name;
                    Cell currentCell = sheet.Cell(row3 + row + 2, 0);
                    helpCalc.CellStyleName(currentCell);

                    sheet.Cell(row3 + row + 2, 1).ValueAsString = tirdWeek[row].InitHours.ToString();
                    Cell initCellStyle = sheet.Cell(row3 + row + 2, 1);
                    helpCalc.CellStyleInit(initCellStyle);

                    for (int col = 0; col < tirdWeek[row].PositionsList.Count; col++)
                    {
                        sheet.Cell(row3 + row + 2, col + 2).ValueAsString = helpCalc.ShiftPositionToWrite(tirdWeek[row].PositionsList[col].shiftName.ToString());
                        Cell positionCell = sheet.Cell(row3+ row + 2, col + 2);
                        helpCalc.CellStylePosition(positionCell);

                    }
                    sheet.Cell(row3+ row + 2, 9).ValueAsString = tirdWeek[row].RestHours.ToString();
                    Cell restCellStyle = sheet.Cell(row3 + row + 2, 9);
                    helpCalc.CellStyleRest(restCellStyle);
                }

                int row4 = row3 + tirdWeek.Count + 4;
                sheet.Cell(row4, 1).ValueAsString = "Stunde";
                sheet.Cell(row4, 2).ValueAsString = "Montag";
                sheet.Cell(row4, 3).ValueAsString = "Dinstag";
                sheet.Cell(row4, 4).ValueAsString = "Mitwoch";
                sheet.Cell(row4, 5).ValueAsString = "Donnerstag";
                sheet.Cell(row4, 6).ValueAsString = "Freitag";
                sheet.Cell(row4, 7).ValueAsString = "Samstag";
                sheet.Cell(row4, 8).ValueAsString = "Sontag";
                sheet.Cell(row4, 9).ValueAsString = "Rest";

                for (int coli = 1; coli <= 9; coli++)
                {
                    Cell currentCell = sheet.Cell(row4, coli);
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                }
                for (int col = 0; col < 9; col++)
                {
                    sheet.Columns[col].AutoFit();

                }
                for (int i = 21; i < 28; i++)
                {
                    Cell currentCell = sheet.Cell(row4 + 1, coll);
                    currentCell.ValueAsString = DaysInWeek[i];
                    helpCalc.CellStyleHeaderDatumDay(currentCell);
                    coll++;
                }
                coll = 2;
                for (int row = 0; row < fourdWeek.Count; row++)
                {
                    sheet.Cell(row4 + row + 2, 0).ValueAsString = fourdWeek[row].Name;
                    Cell currentCell = sheet.Cell(row4 + row + 2, 0);
                    helpCalc.CellStyleName(currentCell);

                    sheet.Cell(row4 + row + 2, 1).ValueAsString = fourdWeek[row].InitHours.ToString();
                    Cell initCellStyle = sheet.Cell(row4 + row + 2, 1);
                    helpCalc.CellStyleInit(initCellStyle);

                    for (int col = 0; col < fourdWeek[row].PositionsList.Count; col++)
                    {
                        sheet.Cell(row4 + row + 2, col + 2).ValueAsString = helpCalc.ShiftPositionToWrite(fourdWeek[row].PositionsList[col].shiftName.ToString());
                        Cell positionCell = sheet.Cell(row4 + row + 2, col + 2);
                        helpCalc.CellStylePosition(positionCell);

                    }
                    sheet.Cell(row4 + row + 2, 9).ValueAsString = fourdWeek[row].RestHours.ToString();
                    Cell restCellStyle = sheet.Cell(row4 + row + 2, 9);
                    helpCalc.CellStyleRest(restCellStyle);
                }

                document.Worksheets.Delete("Spreadsheet SDK");
                document.SaveAsXLSX(filePath);
            }
        }
    }             
}
                             