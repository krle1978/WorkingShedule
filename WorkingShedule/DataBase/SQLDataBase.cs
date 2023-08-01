using Bytescout.Spreadsheet;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingShedule.Data;

namespace WorkingShedule.DataBase
{
    internal class SQLDataBaseWorkingShedule
    {
        static SqlConnection connection = new SqlConnection(@"data source=using System.Data.SqlClient; Server=LAPTOP-DIT9PNDS\SQL2022;  Database=WorkingShedule;Trusted_Connection=true");
        static CalculatingHelp helpCalc = new CalculatingHelp();
        internal List<Employee> LoadListFromDB(string TabeleName)
        {
            connection.Open();
            List<Employee> lstProducts = new List<Employee>();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM {TabeleName}", connection);
            CalculatingHelp dayInWeek = new CalculatingHelp();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<dayPosition> listPositions = new List<dayPosition>();
                    string name = reader[1].ToString(), restHours = reader[10].ToString();
                     int WeekHours = int.Parse(reader[2].ToString()), id = int.Parse(reader[0].ToString());
                    for (int col = 3; col < 10; col++)
                    {
                        string hoursShift = reader[col].ToString();
                        listPositions.Add(new dayPosition
                        {
                            DayinWeek = dayInWeek.DayInWeek(col),
                            shiftName = hoursShift,
                            HoursInDay = helpCalc.WorkingHours(hoursShift),
                        });
                    }
                    lstProducts.Add(new Employee
                    {
                        Name = name,
                        InitHours = WeekHours,
                        PositionsList = listPositions,
                        RestHours = restHours,
                        Id = id

                    });
                }
                connection.Close();
            }
            return lstProducts;
        }

        internal static CalculatingHelp GetHelpCalc()
        {
            return helpCalc;
        }

        internal void WriteEmployeeInBD(Employee selected, string daySelected, string TabeleName)
        {
            connection.Open();
            int dayweekNumbwer = helpCalc.DayInWeekToInt(daySelected);
            string UpdateSelected = $"UPDATE {TabeleName} SET {daySelected} = '{helpCalc.ShiftPositionToWrite(selected.PositionsList[dayweekNumbwer].shiftName)}' WHERE EmplName = '{selected.Name}'";
            string UpdateRestHoursSelected = $"UPDATE {TabeleName} SET RestWeekHours = '{selected.RestHours}' WHERE Id = '{selected.Id}'";
            string UpdateInitHoursSelected = $"UPDATE {TabeleName} SET WorkingWeekHours = '{selected.InitHours}' WHERE Id = '{selected.Id}'";

            using (SqlCommand cmdUpdate = new SqlCommand(UpdateSelected, connection))
            {
                cmdUpdate.CommandText = UpdateSelected;
                if (cmdUpdate.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY");
            }

            if (selected.RestHours != null)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRestHoursSelected, connection))
                {
                    cmdUpdate.CommandText = UpdateRestHoursSelected;
                    if (cmdUpdate.ExecuteNonQuery() == 1)
                        MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                }

                using (SqlCommand cmdUpdate = new SqlCommand(UpdateInitHoursSelected, connection))
                {
                    cmdUpdate.CommandText = UpdateInitHoursSelected;
                    if (cmdUpdate.ExecuteNonQuery() == 1)
                        MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                }
            }
            connection.Close();
        }

        internal void AddNewEmployeeDB(Employee newEmpl)
        {
            connection.Open();
            string INSERTNewEmployee1Week = $"INSERT INTO FirstWeek VALUES ({newEmpl.Id},'{newEmpl.Name}',{newEmpl.InitHours},'{newEmpl.PositionsList[0].shiftName}','{newEmpl.PositionsList[1].shiftName}','{newEmpl.PositionsList[2].shiftName}','{newEmpl.PositionsList[3].shiftName}','{newEmpl.PositionsList[4].shiftName}','{newEmpl.PositionsList[5].shiftName}','{newEmpl.PositionsList[6].shiftName}', '{newEmpl.RestHours}')";
            string INSERTNewEmployee2Week = $"INSERT INTO SecoundWeek VALUES ({newEmpl.Id},'{newEmpl.Name}',{newEmpl.InitHours},'{newEmpl.PositionsList[0].shiftName}','{newEmpl.PositionsList[1].shiftName}','{newEmpl.PositionsList[2].shiftName}','{newEmpl.PositionsList[3].shiftName}','{newEmpl.PositionsList[4].shiftName}','{newEmpl.PositionsList[5].shiftName}','{newEmpl.PositionsList[6].shiftName}', '{newEmpl.RestHours}')";
            string INSERTNewEmployee3Week = $"INSERT INTO ThirdWeek VALUES ({newEmpl.Id},'{newEmpl.Name}',{newEmpl.InitHours},'{newEmpl.PositionsList[0].shiftName}','{newEmpl.PositionsList[1].shiftName}','{newEmpl.PositionsList[2].shiftName}','{newEmpl.PositionsList[3].shiftName}','{newEmpl.PositionsList[4].shiftName}','{newEmpl.PositionsList[5].shiftName}','{newEmpl.PositionsList[6].shiftName}','{newEmpl.RestHours}')";
            string INSERTNewEmployee4Week = $"INSERT INTO FourdWeek VALUES ({newEmpl.Id},'{newEmpl.Name}',{newEmpl.InitHours},'{newEmpl.PositionsList[0].shiftName}','{newEmpl.PositionsList[1].shiftName}','{newEmpl.PositionsList[2].shiftName}','{newEmpl.PositionsList[3].shiftName}','{newEmpl.PositionsList[4].shiftName}','{newEmpl.PositionsList[5].shiftName}','{newEmpl.PositionsList[6].shiftName}','{newEmpl.RestHours}')";
            using (SqlCommand cmdUpdate = new SqlCommand(INSERTNewEmployee1Week, connection))
            {
                cmdUpdate.CommandText = INSERTNewEmployee1Week;
                if (cmdUpdate.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                else MessageBox.Show("DATA not INSERTED SUCCESSFULLY");
            }
            using (SqlCommand cmdUpdate = new SqlCommand(INSERTNewEmployee2Week, connection))
            {
                cmdUpdate.CommandText = INSERTNewEmployee2Week;
                if (cmdUpdate.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                else MessageBox.Show("DATA not INSERTED SUCCESSFULLY");
            }
            using (SqlCommand cmdUpdate = new SqlCommand(INSERTNewEmployee3Week, connection))
            {
                cmdUpdate.CommandText = INSERTNewEmployee3Week;
                if (cmdUpdate.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                else MessageBox.Show("DATA not INSERTED SUCCESSFULLY");
                cmdUpdate.CommandText = INSERTNewEmployee4Week;
            }
            using (SqlCommand cmdUpdate = new SqlCommand(INSERTNewEmployee4Week, connection))
            {
                if (cmdUpdate.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY");
                else MessageBox.Show("DATA not INSERTED SUCCESSFULLY");
            }
            connection.Close();
        }

        internal void WriteEditedEmployeeInExcel(Employee editedWorker, string name)
        {
            string UPDATETable1 = $@"UPDATE FirstWeek SET EmplName = '{editedWorker.Name}', WorkingWeekHours = {editedWorker.InitHours}, RestWeekHours = '{editedWorker.RestHours}' WHERE Id = '{editedWorker.Id}'";
            string UPDATETable2 = $@"UPDATE SecoundWeek SET EmplName = '{editedWorker.Name}', WorkingWeekHours = {editedWorker.InitHours}, RestWeekHours = '{editedWorker.RestHours}' WHERE Id = '{editedWorker.Id}'";
            string UPDATETable3 = $@"UPDATE ThirdWeek SET EmplName = '{editedWorker.Name}', WorkingWeekHours = {editedWorker.InitHours}, RestWeekHours = '{editedWorker.RestHours}' WHERE Id = '{editedWorker.Id}'";
            string UPDATETable4 = $@"UPDATE FourdWeek SET EmplName = '{editedWorker.Name}', WorkingWeekHours = {editedWorker.InitHours}, RestWeekHours = '{editedWorker.RestHours}' WHERE Id = '{editedWorker.Id}'";
            string UPDATEMULTIPLE = $@"UPDATE FirstWeek,SecoundWeek,ThirdWeek,ThirdWeek 
                                        SET EmplName = '{editedWorker.Name}' WHERE Id = '{editedWorker.Id}'";
            connection.Open();
            using (SqlCommand command = new SqlCommand(UPDATETable1, connection))
            {
                command.CommandText = UPDATETable1;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            using (SqlCommand command = new SqlCommand(UPDATETable2, connection))
            {
                command.CommandText = UPDATETable2;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            using (SqlCommand command = new SqlCommand(UPDATETable3, connection))
            {
                command.CommandText = UPDATETable3;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            using (SqlCommand command = new SqlCommand(UPDATETable4, connection))
            {
                command.CommandText = UPDATETable4;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            connection.Close();

        }

        internal void DeleteWorkerInEXCEL(int index)
        {
            string DELETEEmployee1 = $@"DELETE FROM FirstWeek WHERE Id = {index}";
            string DELETEEmployee2 = $@"DELETE FROM FirstWeek WHERE Id = {index}";
            string DELETEEmployee3 = $@"DELETE FROM FirstWeek WHERE Id = {index}";
            string DELETEEmployee4 = $@"DELETE FROM FirstWeek WHERE Id = {index}";
            connection.Open();
            using (SqlCommand command = new SqlCommand(DELETEEmployee1, connection))
            {
                command.CommandText = DELETEEmployee1;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            using (SqlCommand command = new SqlCommand(DELETEEmployee2, connection))
            {
                command.CommandText = DELETEEmployee2;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            using (SqlCommand command = new SqlCommand(DELETEEmployee3, connection))
            {
                command.CommandText = DELETEEmployee3;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            using (SqlCommand command = new SqlCommand(DELETEEmployee4, connection))
            {
                command.CommandText = DELETEEmployee4;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("DATA AFFECTED SUCCESSFULLY");
                else MessageBox.Show("DATA not AFFECTED SUCCESSFULLY");
            }
            connection.Close();
        }
    }
}
