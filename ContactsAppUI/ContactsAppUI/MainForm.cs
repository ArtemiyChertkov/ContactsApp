using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\ContactApp.txt";
        private Project _project = new Project();
        public MainForm()
        {
            InitializeComponent();
            BirthTimePicker.MaxDate = DateTime.Now;
            if (ProjectManager.LoadFromFile(_path) != null)
            {
                _project = ProjectManager.LoadFromFile(_path);
            }
            ShowListBox();
        }
        public void ShowListBox()
        {
            foreach (Contact t in _project._contactslistone)
            {
                ContactslistBox.Items.Add(t.SecondName);
            }
        }
        public List<Contact> _contactslistone = new List<Contact>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Add()
        {
            {
                var form2 = new AddContacts();
                var UpdatedDate = form2.Data;
                var i = form2.ShowDialog();
                if (i == DialogResult.OK)
                {
                    _project._contactslistone.Add(UpdatedDate._contactsplus);
                    ContactslistBox.Items.Add(UpdatedDate.TxtBox);
                }

                ProjectManager.SaveToFile(_project, _path);

            }
        }
        private void Edit()
        {
            {
                AddContacts form2 = new AddContacts();
                if (ContactslistBox.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    form2.Data._contactsplus = _project._contactslistone[ContactslistBox.SelectedIndex];
                    form2.Data.TxtBox = _project._contactslistone[ContactslistBox.SelectedIndex].SecondName;
                    form2.ShowDialog();
                    var UpdatedDate = form2.Data;
                    _project._contactslistone.RemoveAt(ContactslistBox.SelectedIndex);
                    ContactslistBox.Items.RemoveAt(ContactslistBox.SelectedIndex);
                    _project._contactslistone.Add(UpdatedDate._contactsplus);
                    ContactslistBox.Items.Add(UpdatedDate.TxtBox);
                    NametextBox.Text = UpdatedDate._contactsplus.Name;
                    SernametextBox.Text = UpdatedDate._contactsplus.SecondName;
                    EmailtextBox.Text = UpdatedDate._contactsplus.Email;
                    vkidtextBox.Text = UpdatedDate._contactsplus.IDVk;
                    BirthTimePicker.Value = UpdatedDate._contactsplus.Birth;
                    PhonetextBox.Text = Convert.ToString(UpdatedDate._contactsplus.Phone.Number);
                  
                }
                ProjectManager.SaveToFile(_project, _path);

            }
        }
        private void Remove()
        {
            {
                var selectedIndex = ContactslistBox.SelectedIndex;
                if (selectedIndex == -1)
                {
                    return;
                }
                else
                {
                    var i = MessageBox.Show("Удалить этот контакт?", "Подтверждение", MessageBoxButtons.OKCancel);
                    if (i == DialogResult.OK)
                    {
                        _project._contactslistone.RemoveAt(ContactslistBox.SelectedIndex);
                        ContactslistBox.Items.RemoveAt(ContactslistBox.SelectedIndex);
                        NametextBox.Clear();
                        SernametextBox.Clear();
                        EmailtextBox.Clear();
                        PhonetextBox.Clear();
                        vkidtextBox.Clear();
                        BirthTimePicker.Value = BirthTimePicker.MaxDate;
                    }
                    ProjectManager.SaveToFile(_project, _path);
                }
            }
        }

        private void ContactslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (ContactslistBox.SelectedIndex >= 0)
                {
                    Contact _contactsplus;
                    _contactsplus = _project._contactslistone[ContactslistBox.SelectedIndex];
                    NametextBox.Text = _contactsplus.Name;
                    SernametextBox.Text = _contactsplus.SecondName;
                    EmailtextBox.Text = _contactsplus.Email;
                    vkidtextBox.Text = _contactsplus.IDVk;
                    BirthTimePicker.Value = _contactsplus.Birth;
                    PhonetextBox.Text = Convert.ToString(_contactsplus.Phone.Number);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }
    }
}
