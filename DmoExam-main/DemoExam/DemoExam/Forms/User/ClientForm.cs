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

namespace DemoExam.Forms
{
    public partial class ClientForm : Form
    {
        public ClientForm(string userName, decimal? userId)
        {
            InitializeComponent();
            label1.Text = userName;
            using (var db = new DB_DmExamEntities())
            {
                dataGridViewOrderClient.DataSource = db.Orders.Where(o => o.ID_Client == userId).Select(o => new
                {
                    o.ID,
                    o.Status.StatusName,
                    o.Technician.User.FirstName,
                    o.Technician.User.LastName,
                    o.ProblemType.ProblemType1,
                    o.Comment
                }).ToArray();
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
