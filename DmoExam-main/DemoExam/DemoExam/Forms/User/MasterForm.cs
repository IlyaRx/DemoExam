using DemoExam.ModelEF;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DemoExam.Forms
{
    public partial class MasterForm : Form
    {
        public MasterForm(decimal? userID)
        {
            InitializeComponent();
            using (var db = new DB_DmExamEntities())
            {
                dataGridViewOrder.DataSource = db.Orders.Where(o => o.ID_Technician == db.Technicians.FirstOrDefault(t => t.ID_user == userID).ID)
                .Select(o => new
                {
                    o.ID,
                    o.Status.StatusName,
                    o.User.FirstName,
                    o.User.LastName,
                    o.ProblemType.ProblemType1,
                    o.Comment
                }).ToArray();

            }
        }

        private void buttonEquipStatus_Click(object sender, EventArgs e)
        {
            EqipStatusForm eqipStatusForm = new EqipStatusForm((int)dataGridViewOrder.SelectedRows[0].Cells[1].Value);
            eqipStatusForm.ShowDialog();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            using(var db = new DB_DmExamEntities())
            {
                decimal? orderid = (int)dataGridViewOrder.SelectedRows[0].Cells[1].Value;
                if (orderid is null)
                    return;
                Order order = db.Orders.First(o => o.ID == orderid);
                order.ID_Status = db.Statuses.First(s => s.StatusName == "Завершён").ID;
                db.SaveChanges();

            }
        }

        private void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
