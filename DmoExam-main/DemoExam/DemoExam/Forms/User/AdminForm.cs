using DemoExam.Forms;
using DemoExam.Forms.Client;
using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExam
{
    public partial class AdminForm : Form
    {
        decimal? _roleID;
        public AdminForm(string userName, decimal? roleID)
        {
            InitializeComponent();
            label1.Text = userName;
            _roleID = roleID;
        }

        private void buttonPerson_Click(object sender, EventArgs e)
        {
            UsersForm userForm = new UsersForm(_roleID);
            userForm.ShowDialog();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm(_roleID);
            ordersForm.ShowDialog();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
