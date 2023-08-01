using System.Globalization;
using WorkingShedule.Data;
using WorkingShedule.DataBase;

namespace WorkingShedule
{
    public partial class Form1 : Form
    {
        Employee selected = new Employee();
        string week = string.Empty;
        CalculatingHelp helpCalc = new CalculatingHelp();
        WorkingEngine workingEngine = new WorkingEngine();
        //SQLDataBaseWorkingShedule sheduleDB = new SQLDataBaseWorkingShedule();
        public Form1()
        {
            
            bool timer = helpCalc.ExpirianceDay();
            InitializeComponent();
            //if (timer)
            //{
            //    ExpiredLicense expLicence = new ExpiredLicense();
            //    expLicence.Show();
            //    btnAdd.Enabled = false;
            //    btnEdit.Enabled=false;
            //    btnShowTabelle.Enabled = false;
            //    cbDays.Enabled = false;
            //    cbPosition.Enabled = false;
            //    cbWorkHours.Enabled = false;
            //}
            //else
            //{
                workingEngine.ReadFromExcetInTabelle(selected, cbDays, lwTabelle);
                panelRight.Visible = true;
                btnShowTabelle.Enabled = false;
                if (rbOne.Checked) { 
                    cbName.DataSource = FileManager.LoadListFromFile(); 
                    //cbName.DataSource = sheduleDB.LoadListFromDB("FirstWeek"); 
                }
                else if (rbTwo.Checked) {
                    cbName.DataSource = FileManager.LoadListFromFile("shedule2");
                    //cbName.DataSource = sheduleDB.LoadListFromDB("SecoundtWeek");
                }
                else if (rbTree.Checked) {
                    cbName.DataSource = FileManager.LoadListFromFile("shedule3");
                    //cbName.DataSource = sheduleDB.LoadListFromDB("ThirdWeek");
                }
                else if (rbFour.Checked) {
                    cbName.DataSource = FileManager.LoadListFromFile("shedule3");
                    //cbName.DataSource = sheduleDB.LoadListFromDB("FourdWeek");
                }
                cbName.DisplayMember = "Name";
                cbName.ValueMember = "Name";
           //}
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            week = helpCalc.ChooseWeekDB(rbOne, rbTwo, rbTree, rbFour);
            workingEngine.AddingWorkShift(selected, cbPosition, cbName, tbDayHours, tbRestHours, cbDays, week);
            //List<Employee> listEmp = sheduleDB.LoadListFromDB(week);
            List<Employee> listEmp = FileManager.LoadListFromFile(week);
            workingEngine.ReadFromListInTabelle(listEmp, lwTabelle);
            panelRight.Visible = true;
            btnShowTabelle.Enabled = false;
           
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = cbName.SelectedItem as Employee;
            if (selected == null) { return; }
            cbWorkHours.Text = selected.InitHours.ToString();
            tbRestHours.Text = selected.RestHours.ToString();
            workingEngine.WorkerToEdit(selected);
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string week = helpCalc.ChooseWeek(rbOne, rbTwo, rbTree, rbFour);
            selected = cbName.SelectedItem as Employee;
            if (selected == null) { return; }
            workingEngine.WorkTimeCalculation(selected, cbPosition, cbName, tbDayHours, tbRestHours, cbDays, week); 
        }
        private void cbWorkHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            string week = helpCalc.ChooseWeek(rbOne, rbTwo, rbTree, rbFour);
            selected.InitHours = int.Parse(cbWorkHours.Text);

            if (cbPosition.Text != string.Empty && cbDays.Text != string.Empty)
            {
                selected.InitHours = int.Parse(cbWorkHours.Text);
                workingEngine.WorkTimeCalculation(selected, cbPosition, cbName, tbDayHours, tbRestHours, cbDays, week);
                string day = helpCalc.DayFromComboBoxTranslate(cbDays.Text);
                FileManager.WriteEmployeeInExcel(selected, day, week);
            }
            else return;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string week = helpCalc.ChooseWeek(rbOne, rbTwo, rbTree, rbFour);
            EditWorker editWorkerForm = new EditWorker();
            editWorkerForm.ShowDialog();
            //List<Employee> employees = sheduleDB.LoadListFromDB(week);
            List<Employee> employees = FileManager.LoadListFromFile(week);
            workingEngine.ReadFromListInTabelle(employees, lwTabelle);

            cbName.DataSource = employees;
            cbName.DisplayMember = "Name";
            panelRight.Visible = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            workingEngine.ReadFromExcetInTabelle(selected, cbDays, lwTabelle);
            panelRight.Visible = true;
            btnShowTabelle.Enabled = false;
        }

        private void btnOpenEXCEL_Click(object sender, EventArgs e)
        {
            workingEngine.OpenEXCELGenerierdFile();
        }

        private void btnCloseTabelle_Click(object sender, EventArgs e)
        {
            panelRight.Visible = false;
            btnShowTabelle.Enabled = true;
        }

        private void rbOne_CheckedChanged(object sender, EventArgs e)
        {
            //List<Employee> listEmp = sheduleDB.LoadListFromDB("FirstWeek");
            List<Employee> listEmp = FileManager.LoadListFromFile("FirstWeek");
            cbName.DataSource = listEmp;
            cbName.DisplayMember = "Name";
            workingEngine.ReadFromListInTabelle(listEmp, lwTabelle);
        }

        private void rbTwo_CheckedChanged(object sender, EventArgs e)
        {
            //List<Employee> listEmp = sheduleDB.LoadListFromDB("SecoundWeek");
            List<Employee> listEmp = FileManager.LoadListFromFile("SecoundWeek");
            cbName.DataSource = listEmp;
            cbName.DisplayMember = "Name";
            workingEngine.ReadFromListInTabelle(listEmp, lwTabelle);
        }
        private void rbTree_CheckedChanged_1(object sender, EventArgs e)
        {
            //List<Employee> listEmp = sheduleDB.LoadListFromDB("ThirdWeek");
            List<Employee> listEmp = FileManager.LoadListFromFile("ThirdWeek");
            cbName.DataSource = listEmp;
            cbName.DisplayMember = "Name";
            workingEngine.ReadFromListInTabelle(listEmp, lwTabelle);
        }

        private void rbFour_CheckedChanged_1(object sender, EventArgs e)
        {
            //List<Employee> listEmp = sheduleDB.LoadListFromDB("FourdWeek");
            List<Employee> listEmp = FileManager.LoadListFromFile("FourdWeek");
            cbName.DataSource = listEmp;
            cbName.DisplayMember = "Name";
            workingEngine.ReadFromListInTabelle(listEmp, lwTabelle);
        }
        
        private void TCEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            TCEmployee.TabPages.Add("Employee");

        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            workingEngine.LoadEmployee(selected, tbName, numWorkHours);
            pnlOptions.Visible = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            workingEngine.ChangeWorkerGeneralie(tbName, numWorkHours);
            string week = helpCalc.ChooseWeek(rbOne, rbTwo, rbTree, rbFour);

            //List<Employee> employees = sheduleDB.LoadListFromDB(week);
            List<Employee> employees = FileManager.LoadListFromFile(week);
            workingEngine.ReadFromListInTabelle(employees, lwTabelle);
            cbName.DataSource = employees;
            cbName.DisplayMember = "Name";
        }

        private void btnNewWorker_Click(object sender, EventArgs e)
        {
            string week = helpCalc.ChooseWeekDB(rbOne,rbTwo,rbTree,rbFour);
            workingEngine.NewWorkerAdd(tbName, numWorkHours, week);

            //List<Employee> employees = sheduleDB.LoadListFromDB(week);
            List<Employee> employees = FileManager.LoadListFromFile(week);
            workingEngine.ReadFromListInTabelle(employees, lwTabelle);
            cbName.DataSource = employees;
            cbName.DisplayMember = "Name";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string week = helpCalc.ChooseWeek(rbOne, rbTwo, rbTree, rbFour);
            workingEngine.DeleteWorker(tbName);
            //List<Employee> employees = sheduleDB.LoadListFromDB(week);
            List<Employee> employees = FileManager.LoadListFromFile(week);
            workingEngine.ReadFromListInTabelle(employees, lwTabelle);
            cbName.DataSource = employees;
            cbName.DisplayMember = "Name";
        }

       
    }
}