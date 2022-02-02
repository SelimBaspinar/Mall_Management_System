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
    public partial class adminPanel1 : Form
    {
        public adminPanel1()
        {
            InitializeComponent();
        }
        string Id;
        string Name1;
        string Count;
        string shours;
        string ehours;
        string tsaleinc = "0";
        string tsaleb;
        string sCount;
        bool stat;
        bool customersstat;
        bool statisticstat;
        bool employeestat;
        int day;
        int d = 0;
        int a = 0;
        ProductProvider productProvider = new ProductProvider();
        CustomersProvider customers = new CustomersProvider();
        EmpleyeeProvider empleyee = new EmpleyeeProvider();

        public string Id1 { get => Id; set => Id = value; }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            RefreshEmployee.Hide();
            AddEmployee.Hide();
            RemoveEmployee.Hide();
            WorkingHour.Hide();
            customersAdd.Hide();
            comboBox1.Hide();
            button6.Hide();
            radioButton3.Hide();
            refreshbutton.Hide();
            removeCustomer.Hide();
            dataGridView4.Hide();
            timer3.Start();
            customersstat = false;
            statisticstat = false;
            employeestat = false;
            dataGridView1.DataSource = productProvider.getProduct();
            dataGridView2.DataSource = productProvider.getStat();
            dataGridView3.DataSource = customers.getCustomers();
            dataGridView4.DataSource = empleyee.getEmployee();
            comboBox1.SelectedIndex = 0;
            int i;
            int k;
            Count = "0";
            sCount = "0";
            day = DateTime.Now.Day;
            if (day == 28)
            {

                for (k = 0; k < dataGridView3.Rows.Count - 1; k++)
                {
                    if (dataGridView3.Rows[k].Cells[7].Value.ToString() == "1")
                    {
                        string sc = dataGridView3.Rows[k].Cells[6].Value.ToString();
                        string cıd = dataGridView3.Rows[k].Cells[0].Value.ToString();
                        string lsdate = dataGridView3.Rows[k].Cells[5].Value.ToString();
                        customers.updateScount(cıd, lsdate, sc, "0");
                    }
                }
                for (i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (dataGridView2.Rows[k].Cells[4].Value.ToString() == "1")
                    {
                        tsaleb = dataGridView2.Rows[i].Cells[2].ToString();
                        productProvider.updateStattsale(dataGridView2.Rows[i].Cells[0].Value.ToString(), "0");
                        productProvider.updateStatlsale(dataGridView2.Rows[i].Cells[0].Value.ToString(), tsaleb, "0");
                    }

                }
            }
            else if (day == 1)
            {
                for (k = 0; k < dataGridView3.Rows.Count - 1; k++)
                {
                    if (dataGridView3.Rows[k].Cells[7].Value.ToString() == "0" && dataGridView3.Rows[k].Cells[7].Value.ToString() == "")
                    {
                        string cıd = dataGridView3.Rows[k].Cells[0].Value.ToString();
                        string lsdate1 = dataGridView3.Rows[k].Cells[5].Value.ToString();

                        customers.updateScount(cıd, lsdate1, "0", "1");
                    }
                }
                for (i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (dataGridView2.Rows[k].Cells[4].Value.ToString() == "0")
                    {
                        tsaleb = dataGridView2.Rows[i].Cells[2].ToString();
                        productProvider.updateStattsale(dataGridView2.Rows[i].Cells[0].Value.ToString(), "0");
                        productProvider.updateStatlsale(dataGridView2.Rows[i].Cells[0].Value.ToString(), tsaleb, "1");
                    }

                }
            }

            dataGridView2.Hide();
            dataGridView3.Hide();

            try
            {
                Id1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                timer1.Start();
            }
            catch {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = productProvider.getStat();
            dataGridView1.DataSource = productProvider.getProduct();
            timer3.Start();
            timer2.Start();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string ctxt = comboBox1.SelectedItem.ToString();
            if (employeestat == true && customersstat == false && statisticstat == false)
            {
                if (radioButton1.Checked == true)
                {

                    DataView dv = empleyee.getEmployee().DefaultView;
                    dv.RowFilter = "Id LIKE '" + textBox1.Text + "%'";
                    dataGridView4.DataSource = dv;
                }
                else if (radioButton2.Checked == true)
                {
                    DataView dv = empleyee.getEmployee().DefaultView;
                    dv.RowFilter = "Name LIKE '" + textBox1.Text + "%'";
                    dataGridView4.DataSource = dv;
                }
                else
                {
                    DataView dv = empleyee.getEmployee().DefaultView;
                    dv.RowFilter = "Surname LIKE '" + textBox1.Text + "%'";
                    dataGridView4.DataSource = dv;
                }
            }
            else if (statisticstat == true && customersstat == false && employeestat == false)
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
            else if (customersstat == true && employeestat == false && statisticstat == false)
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
    



        private void button2_Click_1(object sender, EventArgs e)
        {
            string IdName = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
            dataGridView1.DataSource = productProvider.removeProduct(IdName);
            dataGridView2.DataSource = productProvider.removeStat(IdName);
            MessageBox.Show("The product has been deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void updateProduct_Click(object sender, EventArgs e)
        {
            Ürün_Güncelle ürün_Güncelle = new Ürün_Güncelle();
            ürün_Güncelle.ShowDialog();
        }



        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            Name1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Count = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            int index = dataGridView1.CurrentRow.Index;
            try
            {
                tsaleb = dataGridView2.Rows[index].Cells[2].Value.ToString();
                if (stat == false)
                {
                    if (Convert.ToInt32(tsaleinc) <= 0)
                    {
                        dataGridView1.DataSource = productProvider.updateProduct(Id1, Name1, Count);
                    }
                    else
                    {

                        tsaleb = (Convert.ToInt32(tsaleb) + Convert.ToInt32(tsaleinc)).ToString();
                        dataGridView1.DataSource = productProvider.updateProduct(Id1, Name1, Count);
                        dataGridView2.DataSource = productProvider.updateStattsale(Id1, tsaleb);
                    }
                }
                else
                {
                    if (Convert.ToInt32(Count) < Convert.ToInt32(sCount))
                    {
                        string rest = (Convert.ToInt32(sCount) - Convert.ToInt32(Count)).ToString();
                        tsaleb = (Convert.ToInt32(tsaleb) + Convert.ToInt32(rest)).ToString();
                        dataGridView1.DataSource = productProvider.updateProduct(Id1, Name1, Count);
                        dataGridView2.DataSource = productProvider.updateStattsale(Id1, tsaleb);
                        sCount = "0";
                        Count = "0";
                    }
                    else
                    {
                        dataGridView1.DataSource = productProvider.updateProduct(Id1, Name1, Count);
                        sCount = "0";
                        Count = "0";
                    }

                }
            }
            catch
            {
                dataGridView1.DataSource = productProvider.getProduct();
                timer3.Start();
            }
        }




        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {



        }

        private void inc_Click(object sender, EventArgs e)
        {
            stat = false;
            tsaleinc = "0";
            dataGridView1.SelectedRows[0].Cells[2].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value) + 1;


        }

        private void dec_Click(object sender, EventArgs e)
        {
            stat = false;
            tsaleinc = "+1";
            dataGridView1.SelectedRows[0].Cells[2].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value) - 1;

        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inc.Hide();
            dec.Hide();
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
            RefreshEmployee.Hide();
            AddEmployee.Hide();
            RemoveEmployee.Hide();
            WorkingHour.Hide();
            customersAdd.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Hide();
            removeCustomer.Hide();
            refreshbutton.Hide();
            updateProduct.Show();
            timer2.Stop();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Id1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch {
                Id1 = "0";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ı;
            string n;
            string c;

            int i;
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ı = dataGridView1.Rows[i].Cells[0].Value.ToString();
                n = dataGridView1.Rows[i].Cells[1].Value.ToString();
                c = dataGridView1.Rows[i].Cells[2].Value.ToString();
                productProvider.updateStat(ı, n);
                productProvider.updateProduct(ı, n, c);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            sCount = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            stat = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Count = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.ShowDialog();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inc.Show();
            dec.Show();
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Hide();
            comboBox1.Hide();
            statisticstat = false;
            customersstat = false;
            employeestat = false;
            dataGridView1.Show();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();
            RefreshEmployee.Hide();
            AddEmployee.Hide();
            RemoveEmployee.Hide();
            WorkingHour.Hide();
            customersAdd.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Hide();
            removeCustomer.Hide();
            refreshbutton.Hide();
            updateProduct.Show();
            timer2.Stop();
            timer1.Start();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inc.Hide();
            dec.Hide();
            radioButton3.Hide();
            timer1.Stop();
            timer2.Start();
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();
            dataGridView4.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            RefreshEmployee.Hide();
            AddEmployee.Hide();
            RemoveEmployee.Hide();
            WorkingHour.Hide();
            updateProduct.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            comboBox1.Show();
            customersAdd.Show();
            button6.Show();
            removeCustomer.Show();
            refreshbutton.Show();
            comboBox1.SelectedIndex = 0;
            customersstat = true;
            statisticstat = false;
            employeestat = false;
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

        private void timer2_Tick(object sender, EventArgs e)
        {

            try
            {
                if (d == dataGridView3.Rows.Count - 1)
                {
                    d = 0;
                    dataGridView3.DataSource = customers.getCustomers();
                    timer2.Stop();
                }
                String ıdc = dataGridView3.Rows[d].Cells[0].Value.ToString();
                string scount = dataGridView3.Rows[d].Cells[6].Value.ToString();

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
            catch 
            {
                timer2.Stop();
               
            }
            
        }

    

        private void removeCustomer_Click(object sender, EventArgs e)
        {
            string Cıd = dataGridView3.SelectedRows[0].Cells[0].Value + string.Empty;
            dataGridView3.DataSource = customers.removeCustomers(Cıd);
  
        }

   
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inc.Hide();
            dec.Hide();
            radioButton1.Show();
            radioButton2.Show();
            comboBox1.Hide();
            radioButton3.Show();
            statisticstat = false;
            customersstat = false;
            employeestat = true;
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Show();
            customersAdd.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            RefreshEmployee.Show();
            AddEmployee.Show();
            RemoveEmployee.Show();
            WorkingHour.Show();
            removeCustomer.Hide();
            refreshbutton.Hide();
            updateProduct.Hide();
            timer2.Stop();
            timer1.Stop();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Adduser add = new Adduser();
            add.ShowDialog();
        }

        private void RefreshEmployee_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = empleyee.getEmployee();
        }

        private void RemoveEmployee_Click(object sender, EventArgs e)
        {
            string Eıd = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            dataGridView4.DataSource = empleyee.removeEmployee(Eıd);


        }

        private void WorkingHour_Click(object sender, EventArgs e)
        {
            EditWorkingHours editWorking = new EditWorkingHours();
            editWorking.ShowDialog();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string eıd = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            shours = dataGridView4.CurrentRow.Cells[6].Value.ToString();
            ehours = dataGridView4.CurrentRow.Cells[7].Value.ToString();
            try
            {
                dataGridView4.DataSource = empleyee.updateEmployee(Id, shours, ehours);
            }
            catch {
                dataGridView4.DataSource = empleyee.getEmployee();
            }

        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string cıd = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            string shoppingcount = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            string lastdate = DateTime.Now.ToShortDateString();
            string Sstat = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            timer2.Start();
            try
            {
                dataGridView3.DataSource = customers.updateScount(cıd, lastdate, shoppingcount, Sstat);
            }
            catch
            {
                dataGridView3.DataSource = customers.getCustomers();
            }
         
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
                d = 0;
                a = 0;
                timer2.Start();
            timer3.Start();

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = productProvider.getStat();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (a == dataGridView1.Rows.Count - 1)
            {
                a = 0;
                timer3.Stop();
            }
            else
            {
                string c = dataGridView1.Rows[a].Cells[2].Value.ToString();
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

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

        private void adminPanel1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            timer3.Start();
        }
    }
    }


