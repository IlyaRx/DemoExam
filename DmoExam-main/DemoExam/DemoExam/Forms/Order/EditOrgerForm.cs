using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class EditOrderForm : Form
    {
        private List<string> _oredet = new List<string>()
        { "Имени", "Фамилии", "Никнейму", "Номеру"};
        private decimal? _roleID = null;
        private Order _order;
        public EditOrderForm(Order order, decimal? roleID)
        {
            InitializeComponent();
            _order = order;
            _roleID = roleID;
            comboBoxOrder.DataSource = _oredet;
            using (var db = new DB_DmExamEntities())
            {
                comboBoxType.DataSource = db.EquipmentTypes.Select(c => c.EqimentType).ToArray();
                comboBoxType.SelectedIndex = comboBoxType.Items.IndexOf(order.EquipmentType.EqimentType);
                comboBoxProblem.DataSource = db.ProblemTypes.Select(c => c.ProblemType1).ToArray();
                comboBoxProblem.SelectedIndex = comboBoxProblem.Items.IndexOf(order.ProblemType.ProblemType1);
                comboBoxStatus.DataSource = db.Statuses.Select(s => s.StatusName).ToArray();
                comboBoxStatus.SelectedIndex = comboBoxStatus.Items.IndexOf(order.Status.StatusName);
                dataGridViewСlient.DataSource = db.Users.Where(name => name.ID == order.ID_Client)
                                                        .Select(c => new { c.FirstName, c.LastName, c.Nikname })
                                                        .ToArray();
                dataGridViewMaster.DataSource = db.Users.Where(name => name.ID == order.Technician.ID_user)
                                                        .Select(c => new { c.FirstName, c.LastName, c.Nikname })
                                                        .ToArray();
                textBoxComment.Text = order.Comment;
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

        private void buttonCreateOrdert_Click(object sender, System.EventArgs e)
        {
            try
            {

                string clientNicname = dataGridViewСlient.SelectedRows[0].Cells[2].Value.ToString();
                string masterNicname = dataGridViewMaster.SelectedRows[0].Cells[2].Value.ToString();
                string v1 = comboBoxType.SelectedValue.ToString();
                using (var db = new DB_DmExamEntities())
                {
                    var orderEdit = db.Orders.Where(o => o.ID == _order.ID).FirstOrDefault();

                    orderEdit.ID_Client = db.Users.First(c => c.Nikname == clientNicname).ID;
                    orderEdit.ID_TypeEquipment = db.EquipmentTypes.FirstOrDefault(et => et.EqimentType == comboBoxType.SelectedValue.ToString()).ID;
                    orderEdit.ID_TypeProblem = db.ProblemTypes.First(pt => pt.ProblemType1 == comboBoxProblem.SelectedValue.ToString()).ID;
                    orderEdit.ID_Technician = db.Technicians.First(th => th.ID_user == db.Users.FirstOrDefault(u => u.Nikname == masterNicname).ID).ID;
                    orderEdit.ID_Status = db.Statuses.First(s => s.StatusName == comboBoxStatus.SelectedValue.ToString()).ID;
                    orderEdit.Comment = textBoxComment.Text;

                    db.SaveChanges();
                }
                MessageBox.Show("Заявка сохранина");
                this.Close();
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

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            using (var db = new DB_DmExamEntities())
            {
                var roleIdC = db.Roles.First(name => name.RoleName == "Client").ID;
                dataGridViewСlient.DataSource = db.Users.Where(name => name.ID_role == roleIdC)
                                                        .Select(c => new { c.FirstName, c.LastName, c.Nikname })
                                                        .ToArray();
            }
        }

        private void buttonEditMaster_Click(object sender, EventArgs e)
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
