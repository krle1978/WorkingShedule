using Bytescout.Spreadsheet.Constants;
using System;
using System.Windows.Forms;
using Cell = Bytescout.Spreadsheet.Cell;
using Color = System.Drawing.Color;

namespace WorkingShedule.Data
{
    internal class CalculatingHelp
    {


        public string DayInWeek(int col)
        {
            switch (col)
            {
                case 3: return "Monday";
                case 4: return "Tuesday";
                case 5: return "Wednesday";
                case 6: return "Thursday";
                case 7: return "Friday";
                case 8: return "Saturday";
                case 9: return "Sunday";
                default: return "Any Day";
            }
        }
        public string DayInWeekTxt(int col)
        {
            switch (col)
            {
                case 2:
                    return "Monday";
                case 3:
                    return "Tuesday";
                case 4:
                    return "Wensday";
                case 5:
                    return "Thursday";
                case 6:
                    return "Friday";
                case 7:
                    return "Sathurday";
                case 8:
                    return "Sonnday";
                default:
                    return "Any Day";
            }
        }

        internal string DayFromComboBoxTranslate(string day)
        {
            switch (day)
            {
                case "Montag": return "Monday";
                case "Dinstag": return "Tuesday";
                case "Mitwoch": return "Wednesday";
                case "Donerstag": return "Thursday";
                case "Freitag": return "Friday";
                case "Samstag": return "Saturday";
                case "Sontag": return "Sunday";
                default:
                    return "No day";

            }
        }

        internal string RestHoursCalc(Employee selected, TextBox tbDayHours, TextBox tbRestHours, ComboBox cbPosition)
        {
            tbDayHours.Text = WorkingHours(cbPosition.Text);

            int restMin = 0, workingHr = 0, workingMin = 0, initTime = selected.InitHours, restHours;

            foreach (dayPosition workerHr in selected.PositionsList)
            {
                workerHr.HoursInDay = workerHr.HoursInDayCalc();
                workingHr += int.Parse(workerHr.HoursInDay.Split(':')[0]);
                workingMin += int.Parse(workerHr.HoursInDay.Split(':')[1]);
                if (workingMin >= 60)
                {
                    workingHr++;
                    workingMin -= 60;
                }
            }

            restHours = initTime - workingHr;

            if (workingMin > 0)
            {
                restHours--;
                restMin = 60 - workingMin;
            }
            tbRestHours.Text = $"{restHours}:{restMin}";
            selected.RestHours = tbRestHours.Text;
            return $"{restHours}:{restMin}";
        }

        public static DateTime HoursTransformToDays(int hours)
        {
            TimeSpan result = TimeSpan.FromHours(hours);
            double day = result.Days, hour = result.Hours, min = result.Minutes;
            string time = $"{day}:{hour}:{min}";
            return DateTime.Parse(time);

        }

        internal string WorkingHours(string HoursShift)
        {
            string beginTime = string.Empty, endTime = string.Empty, workTime = string.Empty, workHour = string.Empty, workMin = string.Empty;

            if ((string?)HoursShift == "x" || HoursShift.ToString().Split(' ')[0] == "Urlaub")
            {
                return "0:0";
            }
            else if (HoursShift.ToString().Split(' ')[0] == "Schicht")
            {
                beginTime = HoursShift.ToString().Split(' ')[2];
                endTime = HoursShift.ToString().Split(' ')[4];
            }
            else if (HoursShift.ToString().Split(' ')[0] == "Bäcker" || HoursShift.ToString().Split(' ')[0] == "Imbis")
            {
                beginTime = HoursShift.ToString().Split(' ')[1];
                endTime = HoursShift.ToString().Split(' ')[3];

            }
            else
            {
                beginTime = HoursShift.ToString().Split('-')[0];
                endTime = HoursShift.ToString().Split('-')[1];
            }
            DateTime beginTime2 = DateTime.Parse(beginTime);
            DateTime endTime2 = DateTime.Parse(endTime);
            workTime = (endTime2 - beginTime2).ToString();
            workHour = workTime.Split(':')[0];
            workMin = workTime.Split(':')[1];

            return $"{workHour}:{workMin}";
        }

        internal string HoursInDayCalc(string hoursShift)
        {
            string beginTime = hoursShift.ToString().Split('-')[0];
            string endTime = hoursShift.ToString().Split('-')[1];

            DateTime beginTime2 = DateTime.Parse(beginTime);
            DateTime endTime2 = DateTime.Parse(endTime);
            return (endTime2 - beginTime2).ToString();

        }

        internal string ShiftPositionToWrite(string positionsNamne)
        {
            string beginTime = string.Empty, endTime = string.Empty;

            if ((string?)positionsNamne == "x")
            {
                return "x";
            }
            else if (positionsNamne.ToString().Split(' ')[0] == "Schicht")
            {
                beginTime = positionsNamne.ToString().Split(' ')[2];
                endTime = positionsNamne.ToString().Split(' ')[4];
            }
            else if (positionsNamne.ToString().Split(' ')[0] == "Bäcker" || positionsNamne.ToString().Split(' ')[0] == "Imbis" || positionsNamne.ToString().Split(' ')[0] == "Urlaub")
            {
                beginTime = positionsNamne.ToString().Split(' ')[1];
                endTime = positionsNamne.ToString().Split(' ')[3];
            }
            else
            {
                beginTime = positionsNamne.ToString().Split('-')[0];
                endTime = positionsNamne.ToString().Split('-')[1];
            }
            return $"{beginTime} - {endTime}";
        }

        internal void RestHoursCalc(List<Employee> listEmployee)
        {
            for (int i = 0; i < listEmployee.Count; i++)
            {
                int workingHr = 0, workingMin = 0, restHours = 0, initTime = 0, restMin = 0;
                foreach (dayPosition workerHr in listEmployee[i].PositionsList)
                {
                    workingHr += int.Parse(workerHr.HoursInDay.Split(':')[0]);
                    workingMin += int.Parse(workerHr.HoursInDay.Split(':')[1]);
                    if (workingMin >= 60)
                    {
                        workingHr++;
                        workingMin -= 60;
                    }

                }
                restHours = listEmployee[i].InitHours - workingHr;
                if (workingMin > 0)
                {
                    restHours--;
                    restMin = 60 - workingMin;
                }

                listEmployee[i].RestHours = $"{restHours}:{restMin}";

            }
            FileManager.WriteRestHoursInEXCELDoc(listEmployee);

        }
        internal void RestHoursCalc(Employee employee)
        {

            int workingHr = 0, workingMin = 0, restHours = 0, initTime = 0, restMin = 0;
            foreach (dayPosition workerHr in employee.PositionsList)
            {
                workingHr += int.Parse(workerHr.HoursInDay.Split(':')[0]);
                workingMin += int.Parse(workerHr.HoursInDay.Split(':')[1]);
                if (workingMin >= 60)
                {
                    workingHr++;
                    workingMin -= 60;
                }

            }
            restHours = employee.InitHours - workingHr;
            if (workingMin > 0)
            {
                restHours--;
                restMin = 60 - workingMin;
            }

            employee.RestHours = $"{restHours}:{restMin}";

        }
        internal bool ExpirianceDay()
        {
            int expDay = 20, expMnt = 12, expYr = 2022, actDay = DateTime.Now.Day, actMnt = DateTime.Now.Month, actYr = DateTime.Now.Year;
            if (actDay >= expDay && actMnt >= expMnt && actYr >= expYr)
            {
                return true;
            }
            else return false;
        }

        internal Color ColorItem(string? shiftName)
        {
            string ShiftBegin = shiftName.ToString().Split('-')[0];

            if (ShiftBegin == "x")
            {
                return Color.Beige;
            }
            else if (ShiftBegin == "Urlaub")
            {
                return Color.Azure;
            }
            else
            {
                int beginHr = int.Parse(ShiftBegin.ToString().Split(':')[0]);
                switch (beginHr)
                {
                    case 02: return Color.SandyBrown;
                    case 03: return Color.Wheat;
                    case 05: return Color.DarkGray;
                    case 11: return Color.LightBlue;
                    case 14: return Color.GreenYellow;
                    case 15: return Color.BlueViolet;
                    default:
                        return Color.White;
                }

            }



        }

        internal Color ColorRestItem(string restHours)
        {
            int value = int.Parse(restHours.Split(':')[0]);
            if (value < 0)
            {
                return Color.Red;
            }
            else if (value == 0)
            {
                return Color.Yellow;
            }
            else if (value < 8)
            {
                return Color.GreenYellow;
            }
            else return Color.Green;
        }

        internal List<string> DaysInWeek(string quartal = "shedule")
        {
            List<DateTime> dayOfWeeksCollection = new List<DateTime>();
            List<string> mondays = new List<string>();
            List<string> tuesdays = new List<string>();
            List<string> wednesdays = new List<string>();
            List<string> thursdays = new List<string>();
            List<string> fridays = new List<string>();
            List<string> saturdays = new List<string>();
            List<string> sundays = new List<string>();

            for (int day = 0; day <= 30; day++)
            {
                dayOfWeeksCollection.Add(DateTime.Now.AddDays(day));
            }
            for (int i = 0; i < dayOfWeeksCollection.Count; i++)
            {
                if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Monday" && mondays.Count < 4)
                    mondays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
                
                else if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Tuesday" && tuesdays.Count < 4)
                    tuesdays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
                
                else if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Wednesday" && wednesdays.Count < 4)
                    wednesdays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
                
                else if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Thursday" && thursdays.Count < 4)
                    thursdays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
                
                else if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Friday" && fridays.Count < 4)
                    fridays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
                
                else if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Saturday" && saturdays.Count < 4)
                    saturdays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
                
                else if (dayOfWeeksCollection[i].DayOfWeek.ToString() == "Sunday" && sundays.Count < 4)
                    sundays.Add($"{dayOfWeeksCollection[i].Day}.{dayOfWeeksCollection[i].Month}.{dayOfWeeksCollection[i].Year}.");
            }

            //int week = FirstDayInWeek(quartal);
            List<string> weekDays = new List<string>
            {
                mondays[0],
                tuesdays[0],
                wednesdays[0],
                thursdays[0],
                fridays[0],
                saturdays[0],
                sundays[0],
                mondays[1],
                tuesdays[1],
                wednesdays[1],
                thursdays[1],
                fridays[1],
                saturdays[1],
                sundays[1],
                mondays[2],
                tuesdays[2],
                wednesdays[2],
                thursdays[2],
                fridays[2],
                saturdays[2],
                sundays[2], 
                mondays[3],
                tuesdays[3],
                wednesdays[3],
                thursdays[3],
                fridays[3],
                saturdays[3],
                sundays[3]
            };
            return weekDays;
        }

        

        public static DateTime StartOfWeek(DayOfWeek startOfWeek)
        {
            DateTime dt = DateTime.Now;
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        internal string DayInWeekForPosition(int i)
        {
            switch (i)
            {
                case 0: return "Monday";
                case 1: return "Tuesday";
                case 2: return "Wensday";
                case 3: return "Thursday";
                case 4: return "Friday";
                case 5: return "Sathurday";
                case 6: return "Sonnday";
                default:
                    return "No day";
            };
        }

        internal string ChooseWeek(RadioButton rbOne, RadioButton rbTwo, RadioButton rbTree, RadioButton rbFour)
        {
            if (rbOne.Checked == true)
            {
                return "shedule";
            }
            else if (rbTwo.Checked == true)
            {
                return "shedule2";
            }
            else if (rbTree.Checked == true)
            {
                return "shedule3";
            }
            else if (rbFour.Checked == true)
            {
                return "shedule4";
            }
            else
            {
                return "";
            }
        }

        internal string ChooseWeekDB(RadioButton rbOne, RadioButton rbTwo, RadioButton rbTree, RadioButton rbFour)
        {
            if (rbOne.Checked == true)
            {
                return "FirstWeek";
            }
            else if (rbTwo.Checked == true)
            {
                return "SecoundWeek";
            }
            else if (rbTree.Checked == true)
            {
                return "ThirdWeek";
            }
            else if (rbFour.Checked == true)
            {
                return "FourdWeek";
            }
            else
            {
                return "";
            }
        }

        internal void CellStyleName(Cell currentCell)
        {

            currentCell.AlignmentVertical = AlignmentVertical.Centered;
            currentCell.BottomBorderColor = Color.Black;
            currentCell.LeftBorderColor = Color.Black;
            currentCell.RightBorderColor = Color.Black;
            currentCell.TopBorderColor = Color.Black;

            currentCell.LeftBorderStyle = LineStyle.Medium;
            currentCell.RightBorderStyle = LineStyle.Medium;
            currentCell.TopBorderStyle = LineStyle.Medium;
            currentCell.BottomBorderStyle = LineStyle.Medium;

            currentCell.AlignmentHorizontal = AlignmentHorizontal.Left;

        }

        internal void CellStyleInit(Cell initCellStyle)
        {
            initCellStyle.AlignmentVertical = AlignmentVertical.Centered;
            initCellStyle.AlignmentHorizontal = AlignmentHorizontal.Centered;
            initCellStyle.BottomBorderColor = Color.Black;
            initCellStyle.BottomBorderStyle = LineStyle.Medium;
            initCellStyle.LeftBorderColor = Color.Black;
            initCellStyle.LeftBorderStyle = LineStyle.Medium;
            initCellStyle.RightBorderColor = Color.Black;
            initCellStyle.RightBorderStyle = LineStyle.Medium;
            initCellStyle.TopBorderColor = Color.Black;
            initCellStyle.TopBorderStyle = LineStyle.Medium;
        }

        internal void CellStylePosition(Cell positionCell)
        {
            positionCell.BottomBorderColor = Color.Black;
            positionCell.LeftBorderColor = Color.Black;
            positionCell.RightBorderColor = Color.Black;
            positionCell.TopBorderColor = Color.Black;

            positionCell.LeftBorderStyle = LineStyle.Medium;
            positionCell.RightBorderStyle = LineStyle.Medium;
            positionCell.TopBorderStyle = LineStyle.Medium;
            positionCell.BottomBorderStyle = LineStyle.Medium;

            positionCell.AlignmentVertical = AlignmentVertical.Centered;
            positionCell.AlignmentHorizontal = AlignmentHorizontal.Centered;
        }

        internal void CellStyleRest(Cell restCellStyle)
        {
            restCellStyle.BottomBorderColor = Color.Black;
            restCellStyle.LeftBorderColor = Color.Black;
            restCellStyle.RightBorderColor = Color.Black;
            restCellStyle.TopBorderColor = Color.Black;

            restCellStyle.LeftBorderStyle = LineStyle.Thick;
            restCellStyle.RightBorderStyle = LineStyle.Thick;
            restCellStyle.TopBorderStyle = LineStyle.Thick;
            restCellStyle.BottomBorderStyle = LineStyle.Thick;

            restCellStyle.AlignmentVertical = AlignmentVertical.Centered;
            restCellStyle.AlignmentHorizontal = AlignmentHorizontal.Right;
        }

        internal void CellStyleHeaderDatumDay(Cell currentCell)
        {
            currentCell.BottomBorderColor = Color.Black;
            currentCell.LeftBorderColor = Color.Black;
            currentCell.RightBorderColor = Color.Black;
            currentCell.TopBorderColor = Color.Black;
            
            currentCell.LeftBorderStyle = LineStyle.Thick;
            currentCell.RightBorderStyle = LineStyle.Thick;
            currentCell.TopBorderStyle = LineStyle.Double;
            currentCell.BottomBorderStyle = LineStyle.Thick;
            
            currentCell.AlignmentVertical = AlignmentVertical.Centered;
            currentCell.AlignmentHorizontal = AlignmentHorizontal.Centered;
        }

        internal int DayInWeekToInt(string daySelected)
        {
            switch (daySelected)
            {
                case "Monday": return 0;
                case "Tuesday": return 1;
                case "Wednesday": return 2;
                case "Thursday": return 3;
                case "Friday": return 4;
                case "Saturday": return 5;
                case "Sunday": return 6;
                default:
                    return 7;

            }
        }
        internal int UnuseUniquedID(List<Employee> EmployeeList)
        {
            int l = EmployeeList.Count;
            int[] IDs = new int[l];
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                IDs[i] = EmployeeList[i].Id;
            }
            for (int j = 1; j <= l; j++)
            {
                if (!IDs.Contains(j))
                {
                    return j;
                }
            }
            return l + 1;
        }
    }
}
