using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class RegisterForm : Form
    {
        private List<string> _roleManager = new List<string> { "Client" };
        private List<string> _roleAdmin = new List<string> { "Client", "Admin", "Manager", "Master" };
        public RegisterForm(decimal? roleID)
        {
            InitializeComponent();
            using (var db = new DB_DmExamEntities())
            {
                if (roleID == db.Roles.First(c => c.RoleName == "Manager").ID)
                { 
                    comboBoxRole.DataSource = _roleManager;
                    tabControl1.TabPages.Remove(tabPage2);
                }
                else comboBoxRole.DataSource = _roleAdmin;

                comboBoxMaster.DataSource = db.Users.Where(u => u.Role.RoleName == "Master").Select(t => t.FirstName).ToArray();
                comboBoxType1.DataSource = db.EquipmentTypes.Select(eq => eq.EqimentType).ToArray();
                comboBoxType2.DataSource = db.EquipmentTypes.Select(eq => eq.EqimentType).ToArray();
                comboBoxType3.DataSource = db.EquipmentTypes.Select(eq => eq.EqimentType).ToArray();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (var db = new DB_DmExamEntities())
                {
                    if (db.Users.FirstOrDefault(u => u.Nikname == textBoxNikName.Text) != null)
                    {
                        MessageBox.Show("Такой никнейм уже существует");
                        return;
                    }
                    if(textBoxFirstName.Text == "" || 
                        textBoxLastName.Text == "" || 
                        textBoxLogin.Text == "" || 
                        textBoxMail.Text == "" || 
                        textBoxNikName.Text == "" || 
                        textBoxPassword.Text == "" || 
                        textBoxPhone.Text == "")
                    {
                        textBoxFirstName.Text = "";
                        textBoxLastName.Text = "";
                        textBoxLogin.Text = "";
                        textBoxMail.Text = "";
                        textBoxNikName.Text = "";
                        textBoxPassword.Text = "";
                        textBoxPhone.Text = "";
                        MessageBox.Show("Заполните поля!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    User user = new User
                    {
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        FirstName = textBoxFirstName.Text,
                        LastName = textBoxLastName.Text,
                        Nikname = textBoxNikName.Text,
                        Mail = textBoxMail.Text,
                        Phone = textBoxPhone.Text,
                        RegisterDate = DateTime.Today,
                        ID_role = db.Roles.First(c => c.RoleName == comboBoxRole.Text).ID
                    };

                    db.Users.Add(user); db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка, попробуйте снова.\n" + ex.ToString());
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var db = new DB_DmExamEntities())
            {
                var technic = new Technician
                {
                    ID_user = db.Users.First(u => u.FirstName == comboBoxMaster.Text).ID,
                    ID_TypeEquipment_1 = db.EquipmentTypes.First(eq => eq.EqimentType == comboBoxType1.Text).ID,
                    ID_TypeEquipment_2 = db.EquipmentTypes.First(eq => eq.EqimentType == comboBoxType2.Text).ID,
                    ID_TypeEquipment_3 = db.EquipmentTypes.First(eq => eq.EqimentType == comboBoxType3.Text).ID,
                    OtherSkills = textBoxOtherSkills.Text,
                    ProfileLink = null
                };
                db.Technicians.Add(technic); db.SaveChanges();
            }
            this.Close();
        }
    }
}
