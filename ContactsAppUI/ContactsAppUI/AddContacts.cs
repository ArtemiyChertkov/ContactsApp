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
    public partial class AddContacts : Form
    {
        private Contact _contactsplus = new Contact();

        private PhoneNumber _phone = new PhoneNumber();
        public AddContacts()
        {
            InitializeComponent();
            BirthTimePicker.MaxDate = DateTime.Now;
        }

        private void AddContacts_Load(object sender, EventArgs e)
        {
            if (Data._contactsplus != null)
            {
                SernametextBox.Text = Data._contactsplus.SecondName;
                NametextBox.Text = Data._contactsplus.Name;
                EmailtextBox.Text = Data._contactsplus.Email;
                VkidtextBox.Text = Data._contactsplus.IDVk;
                BirthTimePicker.Value = Data._contactsplus.Birth;
                PhonetextBox.Text = Convert.ToString(Data._contactsplus.Phone.Number);
            }
        }
        public class DataForm
        {
            public string TxtBox;
            public Contact _contactsplus;
        }
        private DataForm _data = new DataForm();
        public DataForm Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        private void Add()
        {
            bool flag;
            try
            {

                flag = true;
                _phone.Number = System.Int64.Parse(PhonetextBox.Text);
                _contactsplus.SecondName = SernametextBox.Text;
                _contactsplus.Name = NametextBox.Text;
                _contactsplus.Birth = BirthTimePicker.Value;
                _contactsplus.Phone = _phone;
                _contactsplus.Email = EmailtextBox.Text;
                _contactsplus.IDVk = VkidtextBox.Text;
                _data.TxtBox = _contactsplus.SecondName;
                _data._contactsplus = _contactsplus;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                flag = false;
            }

            if (flag == true)
            {
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }
        private void Cancel()
        {
            MainForm main = this.Owner as MainForm;
            var form1 = new MainForm();
            if (main != null)
            {
                Data = null;
            }
            this.Close();
        }

        private void SernametextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.SecondName = SernametextBox.Text;
                SernametextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SernametextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NametextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Name = NametextBox.Text;
                NametextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NametextBox.BackColor = Color.LightSalmon;
            }
        }

        private void PhonetextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhonetextBox.Text, out number);
                _contactsplus.Phone.Number = number;
                PhonetextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhonetextBox.BackColor = Color.LightSalmon;
            }
        }

        private void EmailtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Email = EmailtextBox.Text;
                EmailtextBox.BackColor = Color.White;

            }
            catch (Exception)
            {
                EmailtextBox.BackColor = Color.LightSalmon;
            }
        }

        private void VkidtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.IDVk = VkidtextBox.Text;
                VkidtextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                VkidtextBox.BackColor = Color.LightSalmon;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
