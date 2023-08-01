using Bytescout.Spreadsheet;
using Bytescout.Spreadsheet.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WorkingShedule.Data;
using WorkingShedule.DataBase;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Color = System.Drawing.Color;

namespace WorkingShedule.Data
{
    internal class WorkingEngine
    {
        static SQLDataBaseWorkingShedule SheduleSQLDB = new SQLDataBaseWorkingShedule();
        CalculatingHelp helpCalc = new CalculatingHelp();
        static Employee editedWorker = new Employee();
        //List<Employee> lstEmployee = SheduleSQLDB.LoadListFromDB("FirstWeek");
        List<Employee> lstEmployee = FileManager.LoadListFromFile();


        internal static Employee EditedWorker()
        {
            return editedWorker;
        }

        public List<Employee> LoadList()
        {
            List<Employee> list = FileManager.LoadListFromFile();

            return list;
        }

        internal void AddingWorkShift(Employee selected, ComboBox cbPosition, ComboBox cbName, TextBox tbDayHours, TextBox tbRestHours, ComboBox cbDays, string week)
        {
            string daySelected = helpCalc.DayFromComboBoxTranslate(cbDays.Text);
            for (int i = 0; i < selected.PositionsList.Count; i++)
            {
                if (daySelected == selected.PositionsList[i].DayinWeek)
                {
                    selected.PositionsList[i].shiftName = cbPosition.Text;
                    selected.PositionsList[i].HoursInDay = selected.PositionsList[i].HoursInDayCalc();
                }
            }
            //SheduleSQLDB.WriteEmployeeInBD(selected, daySelected, week);
            FileManager.WriteEmployeeInExcel(selected, daySelected, week);

        }

        internal void ReadFromExcetInTabelle(Employee selectedEmpl, ComboBox cbDays, ListView lwTabelle)
        {
            for (int i = 0; i < lstEmployee.Count; i++)
            {
                if (selectedEmpl.Name == lstEmployee[i].Name)
                {
                    lstEmployee[i] = selectedEmpl;
                }
            }

            lwTabelle.Items.Clear();
            lwTabelle.Columns.Clear();
            ColumnHeader hdName = new ColumnHeader();
            ColumnHeader hdInitHr = new ColumnHeader(),
                hdMonday = new ColumnHeader(),
                hdTuesday = new ColumnHeader(),
                hdWednesday = new ColumnHeader(),
                hdThursday = new ColumnHeader(),
                hdFriday = new ColumnHeader(),
                hdSaturay = new ColumnHeader(),
                hdSonday = new ColumnHeader(),
                hdRestHours = new ColumnHeader();
            hdInitHr.Text = "Stnd";
            hdName.Text = "Name";
            hdMonday.Text = "Montag";
            hdTuesday.Text = "Dinstag";
            hdWednesday.Text = "Mitwoch";
            hdThursday.Text = "Donerstag";
            hdFriday.Text = "Freitag";
            hdSaturay.Text = "Samstag";
            hdSonday.Text = "Sontag";
            hdRestHours.Text = "Rest. Stunde";

            hdName.Width = 100;
            hdMonday.Width = 120;
            hdTuesday.Width =    120;
            hdWednesday.Width =  120;
            hdThursday.Width =   120;
            hdFriday.Width =     120;
            hdSaturay.Width =    120;
            hdSonday.Width = 120;
            hdRestHours.Width = 90;

            lwTabelle.Columns.AddRange(new ColumnHeader[]{hdName, hdInitHr, hdMonday ,hdTuesday,hdWednesday, hdThursday, hdFriday, hdSaturay, hdSonday, hdRestHours});

            Color myColor;
            int row = 0, restCol;
            foreach (Employee employee in lstEmployee)
            {
                restCol = 2;
                ListViewItem worker = new ListViewItem(employee.Name, row);
                worker.UseItemStyleForSubItems = false;
                worker.SubItems.Add(employee.InitHours.ToString());
                for (int i = 0; i < employee.PositionsList.Count; i++)
                {
                    string shiftPosition = helpCalc.ShiftPositionToWrite(employee.PositionsList[i].shiftName.ToString());
                    worker.SubItems.Add(shiftPosition);
                    myColor = helpCalc.ColorItem(shiftPosition);
                    worker.SubItems[i+2].BackColor = myColor;
                    restCol++;
                }
                if (employee.RestHours!=null)
                {
                    worker.SubItems.Add(employee.RestHours.ToString());
                    myColor = helpCalc.ColorRestItem(employee.RestHours);
                    worker.SubItems[restCol].BackColor = myColor;
                }
                lwTabelle.Items.Add(worker);
                row++;
            }
            
        }

        internal void ReadFromListInTabelle(List<Employee> employees, ListView lwTabelle)
        {
            lstEmployee = employees;
            lwTabelle.Items.Clear();
            lwTabelle.Columns.Clear();
            ColumnHeader hdName = new ColumnHeader();
            ColumnHeader hdInitHr = new ColumnHeader(),
                hdMonday = new ColumnHeader(),
                hdTuesday = new ColumnHeader(),
                hdWednesday = new ColumnHeader(),
                hdThursday = new ColumnHeader(),
                hdFriday = new ColumnHeader(),
                hdSaturay = new ColumnHeader(),
                hdSonday = new ColumnHeader(),
                hdRestHours = new ColumnHeader();
            hdInitHr.Text = "Stnd";
            hdName.Text = "Name";
            hdMonday.Text = "Montag";
            hdTuesday.Text = "Dinstag";
            hdWednesday.Text = "Mitwoch";
            hdThursday.Text = "Donerstag";
            hdFriday.Text = "Freitag";
            hdSaturay.Text = "Samstag";
            hdSonday.Text = "Sontag";
            hdRestHours.Text = "Rest. Stunde";

            hdName.Width = 100;
            hdMonday.Width = 120;
            hdTuesday.Width = 120;
            hdWednesday.Width = 120;
            hdThursday.Width = 120;
            hdFriday.Width = 120;
            hdSaturay.Width = 120;
            hdSonday.Width = 120;
            hdRestHours.Width = 90;

            lwTabelle.Columns.AddRange(new ColumnHeader[] { hdName, hdInitHr, hdMonday, hdTuesday, hdWednesday, hdThursday, hdFriday, hdSaturay, hdSonday, hdRestHours });

            Color myColor;
            int row = 0, restCol;
            foreach (Employee employee in employees)
            {
                restCol = 2;
                ListViewItem worker = new ListViewItem(employee.Name, row);
                worker.UseItemStyleForSubItems = false;
                worker.SubItems.Add(employee.InitHours.ToString());
                for (int i = 0; i < employee.PositionsList.Count; i++)
                {
                    string shiftPosition = helpCalc.ShiftPositionToWrite(employee.PositionsList[i].shiftName.ToString());
                    worker.SubItems.Add(shiftPosition);
                    myColor = helpCalc.ColorItem(shiftPosition);
                    worker.SubItems[i + 2].BackColor = myColor;
                    restCol++;
                }
                if (employee.RestHours != null)
                {
                    worker.SubItems.Add(employee.RestHours.ToString());
                    myColor = helpCalc.ColorRestItem(employee.RestHours);
                    worker.SubItems[restCol].BackColor = myColor;
                }
                lwTabelle.Items.Add(worker);
                row++;
            }
        }

        internal void WorkerToEdit(Employee selected)
        {
            editedWorker = selected;
        }

        internal void WorkTimeCalculation(Employee selected, ComboBox cbPosition, ComboBox cbName, TextBox tbDayHours, TextBox tbRestHours, ComboBox cbDays, string week)
        {

            foreach (dayPosition days in selected.PositionsList)
            {
                if (days.DayinWeek == helpCalc.DayFromComboBoxTranslate(cbDays.Text))
                {
                    days.shiftName = cbPosition.Text;
                }
            }
            selected.RestHours = helpCalc.RestHoursCalc(selected, tbDayHours, tbRestHours, cbPosition);
            
        }

        internal void LoadEmployee(Employee selectedEmployee, TextBox tbName, NumericUpDown numWorkHours)
        {
            tbName.Text = selectedEmployee.Name;
            numWorkHours.Value = selectedEmployee.InitHours;
        }

        internal void ChangeWorkerGeneralie(TextBox tbName, NumericUpDown numWorkHours)
        {
            string name = editedWorker.Name;
            editedWorker.Name = tbName.Text;
            editedWorker.InitHours=(int)numWorkHours.Value;
            //SheduleSQLDB.WriteEditedEmployeeInExcel(editedWorker, name);
            FileManager.WriteEditedEmployeeInExcel(editedWorker, name);
            FileManager.WriteEditedEmployeeInExcel(editedWorker, name, "shedule2");
            FileManager.WriteEditedEmployeeInExcel(editedWorker, name, "shedule3");
            FileManager.WriteEditedEmployeeInExcel(editedWorker, name, "shedule4");

            foreach (Employee lstWorker in lstEmployee)
            {
                if (lstWorker.Name == name)
                {
                    lstWorker.Name = editedWorker.Name;
                    lstWorker.InitHours=(int)numWorkHours.Value;
                }
            }
        }

        internal void NewWorkerAdd(TextBox tbName, NumericUpDown numWorkHours, string week)
        {
            Employee newEmpl = new Employee();
            newEmpl.Name = tbName.Text;
            newEmpl.InitHours= (int)numWorkHours.Value;
            //List<Employee> lstEmployeeDB = SheduleSQLDB.LoadListFromDB(week);
            List<Employee> lstEmployeeDB = FileManager.LoadListFromFile(week);
            bool newWorker = false;
            foreach (Employee listEmpl in lstEmployeeDB)
            {
                if (newEmpl.Name.ToLower() == listEmpl.Name.ToLower())
                {
                    MessageBox.Show($"Name: {listEmpl.Name}\nStunde: {listEmpl.InitHours}", "Es gibt Ein Arbeiter !!!");
                    break;
                }
                else newWorker = true;
            }
            if (newWorker)
                {
                List<dayPosition> listPositions = new List<dayPosition>(7);
                string shiftName = "x";
                for (int i = 0; i < 7; i++)
                {
                    listPositions.Add(new dayPosition
                    {
                        DayinWeek = helpCalc.DayInWeekForPosition(i),
                        shiftName = shiftName,
                        HoursInDay = helpCalc.WorkingHours(shiftName),
                    });
                    
                }
                newEmpl.Id= helpCalc.UnuseUniquedID(lstEmployeeDB);
                newEmpl.PositionsList=listPositions;
                newEmpl.RestHours = numWorkHours.Value.ToString();
                lstEmployeeDB.Add(newEmpl);
                //SheduleSQLDB.AddNewEmployeeDB(newEmpl);
                FileManager.WriteNewEmployeeInExcel(newEmpl);
                FileManager.WriteNewEmployeeInExcel(newEmpl, "shedule2");
                FileManager.WriteNewEmployeeInExcel(newEmpl, "shedule3");
                FileManager.WriteNewEmployeeInExcel(newEmpl, "shedule4");
               
            }
        }

        internal void OpenEXCELGenerierdFile()
        {
            //List<Employee> firstWeek = SheduleSQLDB.LoadListFromDB("FirstWeek");
            //List<Employee> secondWeek = SheduleSQLDB.LoadListFromDB("SecoundWeek");
            //List<Employee> tirdWeek = SheduleSQLDB.LoadListFromDB("ThirdWeek");
            //List<Employee> fourdWeek = SheduleSQLDB.LoadListFromDB("FourdWeek");
            List<Employee> firstWeek = FileManager.LoadListFromFile();
            List<Employee> secondWeek = FileManager.LoadListFromFile("shedule2");
            List<Employee> tirdWeek = FileManager.LoadListFromFile("shedule3");
            List<Employee> fourdWeek = FileManager.LoadListFromFile("shedule4");

            string filePath = FileManager.GenerateFile();
            FileManager.OpenEXCELGenerierdFile(firstWeek, secondWeek, tirdWeek, fourdWeek, filePath);
           
            string lblTextPath = GetlblText("Ihre Datei befindet sich unter dem Pfad:");
            string path = FileManager.GetPathText();
            DialogWindow dialog = new DialogWindow(lblTextPath,path);
            dialog.Show();
        }

        internal void DeleteWorker(TextBox tbName)
        {
            int index = 0;
            for (int i = 0; i < lstEmployee.Count; i++)
            {
                if (tbName.Text == lstEmployee[i].Name)
                {
                    index = i;
                }
            }
            lstEmployee.RemoveAt(index);
            //SheduleSQLDB.DeleteWorkerInEXCEL(index);
            FileManager.DeleteWorkerInEXCEL(tbName);
            FileManager.DeleteWorkerInEXCEL(tbName, "shedule2");
            FileManager.DeleteWorkerInEXCEL(tbName, "shedule3");
            FileManager.DeleteWorkerInEXCEL(tbName, "shedule4");
        }

        internal void WorkerInTabPage(TabControl tCEmployee, Employee employee)
        {
            TabPage emplTab = new TabPage();
            emplTab.Name = "emplTab";
            emplTab.Text = "Employee";
            emplTab.BackColor = System.Drawing.Color.GreenYellow;
            emplTab.Width = 403;
            emplTab.Height = 197;

            ListView lwEmployee = new ListView();
            ColumnHeader name = new ColumnHeader();
            ColumnHeader initHr = new ColumnHeader();
            ColumnHeader restHr = new ColumnHeader();
            name.Text = "Name";
            initHr.Text = "Arb.Std.";
            restHr.Text = "Rset Std.";
            lwEmployee.Columns.AddRange(new ColumnHeader[] { name, initHr, restHr});

            ListViewItem empl = new ListViewItem(employee.Name,0);
            empl.SubItems.Add(employee.InitHours.ToString());
            empl.SubItems.Add(employee.RestHours.ToString());
            lwEmployee.Items.Add(empl);
            emplTab.Controls.Add(lwEmployee);
            tCEmployee.TabPages.Add(emplTab);
        }

        internal string GetlblText(string lblText)
        {
            return lblText;
        }

        
    }
}
