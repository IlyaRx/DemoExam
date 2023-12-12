using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class CreateOrderForm : Form
    {
        private List<string> _oredet = new List<string>()
        { "Имени", "Фамилии", "Никнейму", "Номеру"};
        private decimal? _roleID = null;
        public CreateOrderForm(decimal? roleID)
        {
            InitializeComponent();
            _roleID = roleID;
            comboBoxOrder.DataSource = _oredet;
            Сompletion();
        }

        private void Сompletion()
        {
            using (var db = new DB_DmExamEntities())
            {
                var roleIdC = db.Roles.First(name => name.RoleName == "Client").ID;
                var roleIdM = db.Roles.First(name => name.RoleName == "Master").ID;
                dataGridViewСlient.DataSource = db.Users.Where(name => name.ID_role == roleIdC)
                                                        .Select(c => new { c.FirstName, c.LastName, c.Nikname })
                                                        .ToArray();
                dataGridViewMaster.DataSource = db.Users.Where(name => name.ID_role == roleIdM)
                                                        .Select(c => new { c.FirstName, c.LastName, c.Nikname, c.Role.RoleName })
                                                        .ToArray();

                comboBoxType.DataSource = db.EquipmentTypes.Select(c => c.EqimentType).ToArray();
                comboBoxType.SelectedIndex = 0;
                comboBoxProblem.DataSource = db.ProblemTypes.Select(c => c.ProblemType1).ToArray();
                comboBoxProblem.SelectedIndex = 0;
            }
        }
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            using (var db = new DB_DmExamEntities())
            {
                var roleId = db.Roles.First(name => name.RoleName == "Client").ID;
                switch (comboBoxOrder.SelectedItem.ToString())
                {
                    case "Имени":
                        dataGridViewСlient.DataSource = db.Users.
                            Where(name => name.ID_role == roleId && name.FirstName.StartsWith(textBoxSearch.Text))
                            .OrderBy(c => c.FirstName)
                            .Select(c => new
                            {
                                c.FirstName,
                                c.LastName,
                                c.Nikname
                            }
                            )
                            .ToArray();
                        break;
                    case "Фамилии":
                        dataGridViewСlient.DataSource = db.Users.
                            Where(name => name.ID_role == roleId && name.LastName.StartsWith(textBoxSearch.Text))
                            .OrderBy(c => c.FirstName)
                            .Select(c => new
                            {
                                c.FirstName,
                                c.LastName,
                                c.Nikname
                            }
                            )
                            .ToArray();
                        break;
                    case "Никнейму":
                        dataGridViewСlient.DataSource = db.Users.
                            Where(name => name.ID_role == roleId && name.Nikname.StartsWith(textBoxSearch.Text))
                            .OrderBy(c => c.FirstName)
                            .Select(c => new
                            {
                                c.FirstName,
                                c.LastName,
                                c.Nikname
                            }
                            )
                            .ToArray();
                        break;
                    case "Номеру":
                        dataGridViewСlient.DataSource = db.Users.
                            Where(name => name.ID_role == roleId && name.Phone.StartsWith(textBoxSearch.Text))
                            .OrderBy(c => c.FirstName)
                            .Select(c => new
                            {
                                c.FirstName,
                                c.LastName,
                                c.Nikname
                            }
                            )
                            .ToArray();
                        break;
                }


            }
        }

        private void buttonRegСlient_Click(object sender, System.EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_roleID);
            registerForm.ShowDialog();
        }

        private void buttonObnova_Click(object sender, System.EventArgs e)
        {
            Сompletion();
        }

        private void buttonCreateOrdert_Click(object sender, System.EventArgs e)
        {
            try
            {

                string clientNicname = dataGridViewСlient.SelectedRows[0].Cells[2].Value.ToString();
                string masterNicname = dataGridViewMaster.SelectedRows[0].Cells[2].Value.ToString();
                using (var db = new DB_DmExamEntities())
                {
                    Order order = new Order
                    {
                        ID_Client = db.Users.First(c => c.Nikname == clientNicname).ID,
                        ID_TypeEquipment = db.EquipmentTypes.FirstOrDefault(et => et.EqimentType == comboBoxType.SelectedValue.ToString()).ID,
                        ID_TypeProblem = db.ProblemTypes.First(pt => pt.ProblemType1 == comboBoxProblem.SelectedValue.ToString()).ID,
                        ID_Technician = db.Technicians.First(th => th.ID_user == db.Users.FirstOrDefault(u => u.Nikname == masterNicname).ID).ID,
                        ID_Status = db.Statuses.First(s => s.StatusName == "Выполняеться").ID,
                        DateOrderOpen = DateTime.Today,
                        Comment = textBoxComment.Text,
                    };
                    db.Orders.Add(order); db.SaveChanges();
                    MessageBox.Show("Заявка создана");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка, попробуйте снова.\n" + ex.ToString());
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DB_DmExamEntities())
                {
                    int IDEquipmentTypes = db.EquipmentTypes.First(et => et.EqimentType == comboBoxType.SelectedValue.ToString()).ID;
                    var roleIdUserMaster = db.Roles.First(name => name.RoleName == "Master").ID;
                    dataGridViewMaster.DataSource = db.Technicians.Where(t => t.User.ID_role == roleIdUserMaster && (t.ID_TypeEquipment_1 == IDEquipmentTypes ||
                                                                                                                    t.ID_TypeEquipment_2 == IDEquipmentTypes ||
                                                                                                                    t.ID_TypeEquipment_3 == IDEquipmentTypes))
                                                           .Select(t => new { t.User.FirstName, t.User.LastName, t.User.Nikname })
                                                           .ToArray();

                }
            }
            catch { }
        }

    }
}
