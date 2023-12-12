using DemoExam.ModelEF;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class EqipStatusForm : Form
    {
        private int? _orderid = null;
        public EqipStatusForm(int orderID)
        {
            InitializeComponent();
            _orderid = orderID;
            comboBoxStatus.DataSource = new DB_DmExamEntities().Statuses.Select(s => s.StatusName).ToArray();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Изменить статус?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            using (var db = new DB_DmExamEntities())
            {
                if (_orderid == null)
                    return;
                Order order = db.Orders.First(o => o.ID == _orderid);
                order.ID_Status = db.Statuses.First(s => s.StatusName == comboBoxStatus.SelectedValue.ToString()).ID;
                db.SaveChanges();
            }
            MessageBox.Show("Статус изменён.");
            this.Close();
        }
    }
}
