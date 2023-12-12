using DemoExam.Forms.Client;
using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class ManagerForm : Form
    {
        decimal? _roleId = null;
        public ManagerForm(decimal? roleId, string userName)
        {
            InitializeComponent();
            _roleId = roleId;
            label1.Text = userName;
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonPerson_Click(object sender, EventArgs e)
        {
            UsersForm userForm = new UsersForm(_roleId);
            userForm.ShowDialog();
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm(_roleId);
            ordersForm.ShowDialog();
        }
    }
}
