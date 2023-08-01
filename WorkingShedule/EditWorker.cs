using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkingShedule.Data;

namespace WorkingShedule
{
    public partial class EditWorker : Form
    {
        
        WorkingEngine workingEngine = new WorkingEngine();
        Employee selectedEmployee = WorkingEngine.EditedWorker();
        public EditWorker()
        {
            InitializeComponent();
            workingEngine.LoadEmployee(selectedEmployee,tbName, numWorkHours);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //workingEngine.ChangeWorkerGeneralie(tbName, numWorkHours);
            this.Close();
        }

        private void btnNewWorker_Click(object sender, EventArgs e)
        {
            //workingEngine.NewWorkerAdd(tbName, numWorkHours);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            workingEngine.DeleteWorker(tbName);
            this.Close();
        }
    }
}
