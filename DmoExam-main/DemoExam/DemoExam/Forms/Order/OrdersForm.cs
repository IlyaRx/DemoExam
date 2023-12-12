using DemoExam.ModelEF;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class OrdersForm : Form
    {
        private decimal? _roleId = null;
        public OrdersForm(decimal? roleId)
        {
            InitializeComponent();
            _roleId = roleId;
            using (var db = new DB_DmExamEntities())
            {
                if ("Manager" == db.Roles.First(r => r.ID == roleId).RoleName)
                {
                    buttonDeleteOrder.Visible = false;
                    buttonEditOrder.Visible = false;
                }
                if ("Admin" == db.Roles.First(r => r.ID == roleId).RoleName)
                    buttonEqipStatus.Visible = false;
            }
            PrintDataGrit();
        }
        private void PrintDataGrit()
        {
            using (var db = new DB_DmExamEntities())
            {
                dataGridViewOrders.DataSource = db.Orders.Select(o => new
                {
                    o.ID,
                    ClientName = o.User.FirstName,
                    ClentLastname = o.User.LastName,
                    o.EquipmentType.EqimentType,
                    o.ProblemType.ProblemType1,
                    o.Technician.User.FirstName,
                    o.Technician.User.LastName,
                    o.Status.StatusName,
                    o.DateOrderOpen
                }).ToArray();
            }
        }
        private void buttonAddOrders_Click(object sender, EventArgs e)
        {
            CreateOrderForm createOrderForm = new CreateOrderForm(_roleId);
            createOrderForm.ShowDialog();
            PrintDataGrit();
        }

        private void buttonEditOrder_Click(object sender, EventArgs e)
        {
            Order order;
            int orderID = (int)dataGridViewOrders.SelectedRows[0].Cells[0].Value;
            using (var db = new DB_DmExamEntities())
            {
                order = db.Orders.First(o => o.ID == orderID);
                EditOrderForm editOrderForm = new EditOrderForm(order, _roleId);
                editOrderForm.ShowDialog();
            }
            PrintDataGrit();
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы точно хотите удалить?",
                "Сообщение",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;
            int deleteOrderId = (int)dataGridViewOrders.SelectedRows[0].Cells[0].Value;
            using (var db = new DB_DmExamEntities())
            {
                var deleteOrder = db.Orders.First(o => o.ID == deleteOrderId);
                db.Orders.Remove(deleteOrder);
                db.SaveChanges();
            }
            PrintDataGrit();
        }

        private void buttonEqipStatus_Click(object sender, EventArgs e)
        {
            int orderID = (int)dataGridViewOrders.SelectedRows[0].Cells[0].Value;
            new EqipStatusForm(orderID).ShowDialog();

            PrintDataGrit();
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
