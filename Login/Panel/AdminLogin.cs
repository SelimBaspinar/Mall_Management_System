using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        

        UserProvider islem = new UserProvider();

        EmpleyeeProvider employee = new EmpleyeeProvider();

        private void loginB_Click(object sender, EventArgs e)
        {
         
           
                if (islem.LoginUser(textBox1.Text, textBox2.Text, textBox1.Text))
                {
                DataView dv = employee.getEmployee().DefaultView;
                dv.RowFilter = "Username LIKE '" + textBox1.Text+ "%'"+ "OR Email LIKE '" + textBox1.Text + "%'" ;
                if (Convert.ToInt32(dv[0]["AdminPanel"]) == 1)
                {
                    adminPanel1 adminPanel = new adminPanel1();
                    adminPanel.Show();
                    this.Hide();
                }
                else
                {
                    PersonalPanel personalPanel = new PersonalPanel();
                    personalPanel.Show();
                    this.Hide();

                }
       
                }
                else {
                    MessageBox.Show("Username or Password is Incorrect", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
              
              
        }


        private void adduser_Click(object sender, EventArgs e)
        {
            Adduser adduser = new Adduser();
            adduser.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

       
        
    }
}
