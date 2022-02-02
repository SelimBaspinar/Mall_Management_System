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
    public partial class PersonalPanel : Form
    {
        public PersonalPanel()
        {
            InitializeComponent();
        }
        ProductProvider productProvider = new ProductProvider();
        CustomersProvider customers = new CustomersProvider();
        EmpleyeeProvider empleyee = new EmpleyeeProvider();
        DataGridViewCellStyle renk = new DataGridViewCellStyle();

        Login login = Application.OpenForms["Login"] as Login;
        bool statisticstat;
        bool customersstat;
        int d=0;
        int a = 0;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonalPanel_Load(object sender, EventArgs e)
        {
            timer2.Start();
            customersAdd.Hide();
            comboBox1.Hide();
            button6.Hide();
            radioButton3.Hide();
            refreshbutton.Hide();
            dataGridView4.Hide();
            customersstat = false;
            statisticstat = false;
            dataGridView1.DataSource = productProvider.getProduct();
            dataGridView2.DataSource = productProvider.getStat();
            dataGridView3.DataSource = customers.getCustomers();
            TextBox txt = login.Controls["textbox1"] as TextBox;
            dataGridView4.DataSource = empleyee.getEmployee(txt.Text);
            label2.Text = dataGridView4.Rows[0].Cells[3].Value.ToString()+"   "+ dataGridView4.Rows[0].Cells[6].Value.ToString()+"-"+ dataGridView4.Rows[0].Cells[7].Value.ToString();
            comboBox1.SelectedIndex = 0;
            customersAdd.Hide();
            comboBox1.Hide();
            button6.Hide();
            refreshbutton.Hide();
            customersstat = false;
            statisticstat = false;
            dataGridView1.DataSource = productProvider.getProduct();
            dataGridView2.DataSource = productProvider.getStat();
            dataGridView3.DataSource = customers.getCustomers();
            dataGridView2.Hide();
            dataGridView3.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string ctxt = comboBox1.SelectedItem.ToString();
           if (statisticstat == true && customersstat == false)
            {
                if (radioButton1.Checked == true)
                {

                    DataView dv = productProvider.getProduct().DefaultView;
                    dv.RowFilter = "Id LIKE '" + textBox1.Text + "%'";
                    dataGridView2.DataSource = dv;
                }
                else
                {
                    DataView dv = productProvider.getProduct().DefaultView;
                    dv.RowFilter = "Name LIKE '" + textBox1.Text + "%'";
                    dataGridView2.DataSource = dv;
                }
            }
            else if (customersstat == true && statisticstat == false)
            {
                if (ctxt == "Id")
                {
                    DataView dv = customers.getCustomers().DefaultView;
                    dv.RowFilter = "Id LIKE '" + textBox1.Text + "%'";
                    dataGridView3.DataSource = dv;
                }
                else if (ctxt == "Name")
                {
                    DataView dv = customers.getCustomers().DefaultView;
                    dv.RowFilter = "Name LIKE '" + textBox1.Text + "%'";
                    dataGridView3.DataSource = dv;
                }
                else if (ctxt == "Surname")
                {
                    DataView dv = customers.getCustomers().DefaultView;
                    dv.RowFilter = "Surname LIKE '" + textBox1.Text + "%'";
                    dataGridView3.DataSource = dv;
                }
                else
                {
                    DataView dv = customers.getCustomers().DefaultView;
                    dv.RowFilter = "Discount LIKE '" + textBox1.Text + "%'";
                    dataGridView3.DataSource = dv;
                }
            }
            else
            {
                if (radioButton1.Checked == true)
                {

                    DataView dv = productProvider.getProduct().DefaultView;
                    dv.RowFilter = "Id LIKE '" + textBox1.Text + "%'";
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    DataView dv = productProvider.getProduct().DefaultView;
                    dv.RowFilter = "Name LIKE '" + textBox1.Text + "%'";
                    dataGridView1.DataSource = dv;
                }
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton3.Hide();
            timer1.Start();
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();
            dataGridView4.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            comboBox1.Show();
            customersAdd.Show();
            button6.Show();
            refreshbutton.Show();
            comboBox1.SelectedIndex = 0;
            customersstat = true;
            statisticstat = false;
            timer2.Stop();

        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Hide();
            comboBox1.Hide();
            statisticstat = true;
            customersstat = false;
            dataGridView1.Hide();
            dataGridView2.Show();
            dataGridView3.Hide();
            dataGridView4.Hide();
            customersAdd.Hide();
            button6.Hide();
            refreshbutton.Hide();
            timer1.Stop();
            timer2.Stop();

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Hide();
            comboBox1.Hide();
            statisticstat = false;
            customersstat = false;
            dataGridView1.Show();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();
            customersAdd.Hide();
            button6.Hide();
            refreshbutton.Hide();
            timer2.Start();
            timer1.Stop();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String ıdc;
            string scount;
            if (d == dataGridView3.Rows.Count - 1)
            {
                d = 0;
                dataGridView3.DataSource = customers.getCustomers();
                timer1.Stop();
            }
            try
            {
               ıdc = dataGridView3.Rows[d].Cells[0].Value.ToString();
               scount = dataGridView3.Rows[d].Cells[6].Value.ToString();
            }
            catch {
                ıdc ="0";
                scount = "0";
            }
            if (Convert.ToInt32(scount) > 0)
            {
                if (Convert.ToInt32(scount) >= 5 && Convert.ToInt32(scount) < 10)
                    customers.updateDiscount(ıdc, "%5");
                else if (Convert.ToInt32(scount) >= 10 && Convert.ToInt32(scount) < 15)
                    customers.updateDiscount(ıdc, "%10");
                else if (Convert.ToInt32(scount) >= 15 && Convert.ToInt32(scount) < 20)
                    customers.updateDiscount(ıdc, "%15");
                else if (Convert.ToInt32(scount) >= 20 && Convert.ToInt32(scount) < 25)
                    customers.updateDiscount(ıdc, "%20");
                else if (Convert.ToInt32(scount) >= 25)
                    customers.updateDiscount(ıdc, "%25");
            }
            else
            {
                customers.updateDiscount(ıdc, "0");
                customers.getCustomers();
            }
            d++;
        }

        private void customersAdd_Click(object sender, EventArgs e)
        {
            AddCustomers add = new AddCustomers();
            add.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CustomersShopping shopping = new CustomersShopping();
            shopping.ShowDialog();
        }

     
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = customers.getCustomers();
        }

        private void RemoveEmployee_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string eıd = dataGridView4.Rows[0].Cells[0].Value.ToString();
            string Name = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            string Surname = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            string Username = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            string Password = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            string Email = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            dataGridView4.DataSource = empleyee.updateEmployee(eıd, Name, Surname,Username,Password,Email);
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string cıd = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            string shoppingcount = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            string lastdate = DateTime.Now.ToShortDateString();
            string Sstat = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            timer1.Start();


            dataGridView3.DataSource = customers.updateScount(cıd, lastdate, shoppingcount, Sstat);

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = productProvider.getStat();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            timer2.Start();
            dataGridView1.DataSource = productProvider.getProduct();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Hide();           
            radioButton2.Hide();
            comboBox1.Hide();
            radioButton3.Hide();
            statisticstat = false;
            customersstat = false;
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Show();
            customersAdd.Hide();
            refreshbutton.Hide();
            timer2.Stop();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (a == dataGridView1.Rows.Count - 1)
            {
                a = 0;
                timer2.Stop();
            }
            string c;
            try {
                 c = dataGridView1.Rows[a].Cells[2].Value.ToString();

            }
            catch {
                c = "";
            }

            DataGridViewCellStyle renk = new DataGridViewCellStyle();
            if (c != "")
            {
                if (Convert.ToInt32(c) <= 5)
                {
                    renk.ForeColor = Color.Red;
                    renk.SelectionBackColor = Color.Red;
                }
                else
                {
                    renk.ForeColor = Color.Black;
                    renk.SelectionBackColor = SystemColors.Highlight;

                }
                dataGridView1.Rows[a].DefaultCellStyle = renk;
                a++;
            }
        }

        private void PersonalPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            timer2.Start();
        }
    }
}
