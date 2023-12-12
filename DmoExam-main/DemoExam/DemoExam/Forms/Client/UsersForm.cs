using DemoExam.ModelEF;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms.Client
{
    public partial class UsersForm : Form
    {
        decimal? _roleID = null;
        public UsersForm(decimal? roleID)
        {
            InitializeComponent();
            _roleID = roleID;
            using (var db = new DB_DmExamEntities())
            {
                if (roleID == db.Roles.First(c => c.RoleName == "Manager").ID)
                {
                    dataGridViewUser.DataSource = db.Users.Where(u => u.Role.RoleName == "Client").Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Role.RoleName,
                        u.Phone,
                        u.Mail,
                    }).ToArray();
                }
                else
                {
                    dataGridViewUser.DataSource = db.Users.Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Role.RoleName,
                        u.Phone,
                        u.Mail,
                    }).ToArray();
                }
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_roleID);
            registerForm.ShowDialog();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            string firstname = dataGridViewUser.SelectedRows[0].Cells[0].Value.ToString();
            string lastName = dataGridViewUser.SelectedRows[0].Cells[1].Value.ToString();
            using(var db = new DB_DmExamEntities())
            {
                EditUserForm editUserForm = new EditUserForm(_roleID, db.Users.First(u => u.FirstName == firstname && u.LastName == lastName));
                editUserForm.ShowDialog();
            }
        }
    }
}
