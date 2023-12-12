using DemoExam.ModelEF;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms.Client
{
    public partial class EditUserForm : Form
    {
        private decimal? _roleID = null;
        private User _user = null;
        private List<string> _roleManager = new List<string> { "Client" };
        private List<string> _roleAdmin = new List<string> { "Client", "Admin", "Manager", "Master" };
        public EditUserForm(decimal? roleID, User user)
        {
            _roleID = roleID;
            _user = user;
            InitializeComponent();
            using (var db = new DB_DmExamEntities())
            {

                if (roleID == db.Roles.First(c => c.RoleName == "Manager").ID)
                {
                    comboBoxRole.DataSource = _roleManager;
                    tabControl1.TabPages.Remove(tabPage2);

                }
                else
                {
                    comboBoxRole.DataSource = _roleAdmin;
                    if (user.Role.RoleName != "Master") tabControl1.TabPages.Remove(tabPage2);
                }
                textBoxLogin.Text = user.Login;
                textBoxPassword.Text = user.Password;
                textBoxLastName.Text = user.LastName;
                textBoxFirstName.Text = user.FirstName;
                textBoxNikName.Text = user.Nikname;
                textBoxMail.Text = user.Mail;
                textBoxPhone.Text = user.Phone;
                if (roleID == db.Roles.First(c => c.RoleName == "Manager").ID && user.Role.RoleName != "Master")
                    return;
                comboBoxRole.SelectedIndex = comboBoxRole.Items.IndexOf(user.Role.RoleName);
                comboBoxMaster.DataSource = db.Users.Where(u => u.ID == user.ID).Select(t => t.FirstName).ToArray();
                comboBoxType1.DataSource = db.EquipmentTypes.Select(eq => eq.EqimentType).ToArray();
                comboBoxType1.SelectedIndex = comboBoxType1.Items.IndexOf(db.Technicians.First(t => t.ID_user == user.ID).EquipmentType.EqimentType);
                comboBoxType2.DataSource = db.EquipmentTypes.Select(eq => eq.EqimentType).ToArray();
                comboBoxType2.SelectedIndex = comboBoxType2.Items.IndexOf(db.Technicians.First(t => t.ID_user == user.ID).EquipmentType1.EqimentType);
                comboBoxType3.DataSource = db.EquipmentTypes.Select(eq => eq.EqimentType).ToArray();
                comboBoxType3.SelectedIndex = comboBoxType3.Items.IndexOf(db.Technicians.First(t => t.ID_user == user.ID).EquipmentType2.EqimentType);
            }

        }

        private void buttonSaveUser_Click(object sender, System.EventArgs e)
        {
            using (var db = new DB_DmExamEntities())
            {
                var userEdit = db.Users.FirstOrDefault(u => u.ID == _user.ID);
                userEdit.Login = textBoxLogin.Text;
                userEdit.Password = textBoxPassword.Text;
                userEdit.FirstName = textBoxFirstName.Text;
                userEdit.LastName = textBoxLastName.Text;
                userEdit.Nikname = textBoxNikName.Text;
                userEdit.Mail = textBoxMail.Text;
                userEdit.Phone = textBoxPhone.Text;
                userEdit.ID_role = db.Roles.First(c => c.RoleName == comboBoxRole.Text).ID;
                db.SaveChanges();

            }

            MessageBox.Show("Пользователь сохранён");
            this.Close();
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            using (var db = new DB_DmExamEntities())
            {
                var TechnicEdit = db.Technicians.FirstOrDefault(t => t.ID_user == _user.ID);
                TechnicEdit.ID_user = db.Users.First(u => u.FirstName == comboBoxMaster.Text).ID;
                TechnicEdit.ID_TypeEquipment_1 = db.EquipmentTypes.First(eq => eq.EqimentType == comboBoxType1.Text).ID;
                TechnicEdit.ID_TypeEquipment_2 = db.EquipmentTypes.First(eq => eq.EqimentType == comboBoxType2.Text).ID;
                TechnicEdit.ID_TypeEquipment_3 = db.EquipmentTypes.First(eq => eq.EqimentType == comboBoxType3.Text).ID;
                TechnicEdit.OtherSkills = textBoxOtherSkills.Text;
                TechnicEdit.ProfileLink = null;
                db.SaveChanges();
            }
            MessageBox.Show("Исполнитель сохранён");
            this.Close();
        }
    }
}
