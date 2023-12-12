using DemoExam.Forms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Except()
        {
            MessageBox.Show("не верный пароль, повторите попытку снова");
        }

        private decimal? _userId = null;
        private string _userName = null;
        private string _roleName = "no avtorized";
        private decimal? _roleId = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            try
            {
                using (var db = new DB_DmExamEntities())
                {
                    var userData = db.Users.FirstOrDefault(user => user.Login == login);
                    if (userData == null || userData.Password != password)
                    {
                        Except();
                        return;
                    }
                    if (userData != null) 
                    {
                        _userName = userData.FirstName;
                        _userId = userData.ID;
                        _roleId = userData.ID_role;
                    }

                    var roleId = userData.ID_role;

                    _roleName = db.Roles.First(role => role.ID == roleId).RoleName;
                }
                MessageBox.Show("Вы вошли как " + _roleName);
                LoadMainForm();
            }catch (Exception ex)
            {
                MessageBox.Show("неверный логин или пароль, повторте попытку снова.");
            }
        }

        private void LoadMainForm() {
            switch (_roleName)
            {
                case "Client":
                    ClientForm clientForm = new ClientForm(_userName, _userId);
                    this.Hide();
                    clientForm.Show();
                    break;
                case "Admin":
                    AdminForm adminForm = new AdminForm(_userName, _roleId);
                    this.Hide();
                    adminForm.Show();
                    break;
                case "Manager":
                    ManagerForm managerForm = new ManagerForm(_roleId, _userName);
                    this.Hide();
                    managerForm.Show();
                    break;
                case "Master":
                    MasterForm masterForm = new MasterForm(_userId);
                    this.Hide();
                    masterForm.Show();
                    break;
            }
        }
    }
}
