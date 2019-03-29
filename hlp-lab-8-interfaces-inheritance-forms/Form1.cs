using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hlp_lab_8_interfaces_inheritance_forms
{
    public partial class Form1 : Form
    {
        private BindingList<Vehicle> binding;

        private List<Vehicle> list;

        public Form1()
        {
            list = new List<Vehicle>();
            list.Add(new Car("Лада", 2012, 98000));
            list.Add(new Car("Renault", 2011, 320000));
            list.Add(new Car("Citroen", 2018, 276000));
            list.Add(new Truck("MAЗ", 2017, 765000));
            list.Add(new Truck("Белаз", 2013, 2520000));

            binding = new BindingList<Vehicle>(list);

            InitializeComponent();

            dataGridView1.DataSource = binding;
            DataGridViewCellStyle fixedStyle = new DataGridViewCellStyle();
            fixedStyle.Format = "F2";
            dataGridView1.Columns[3].DefaultCellStyle = fixedStyle;
        }

        private void AddNewVehicle_Click(object sender, EventArgs e)
        {
            Vehicle item = null;
            try
            {
                if (comboBox1.SelectedItem.Equals("Car"))
                {
                    item = new Car(textBox1.Text, int.Parse(textBox2.Text), double.Parse(textBox3.Text));
                } else if (comboBox1.SelectedItem.Equals("Truck")) {                
                    item = new Truck(textBox1.Text, int.Parse(textBox2.Text), double.Parse(textBox3.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Vehicle vehicle in list)
            {
                if (vehicle.Equals(item))
                {
                    return;
                }
            }


            if (null != item)
            {
                list.Add(item);
                binding.ResetBindings();
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if ("" == textBox4.Text)
            {
                return;
            }

            try {
                int index = int.Parse(textBox4.Text);
                dataGridView1.Rows.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clone_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                Vehicle selected = list[item.Index];
                list.Add((Vehicle)selected.Clone());
            }
            binding.ResetBindings();
        }

        private void SortByYear_Click(object sender, EventArgs e)
        {
            list.Sort(new YearComparer());
            binding.ResetBindings();
        }

        private void SortByCost_Click(object sender, EventArgs e)
        {
            list.Sort();
            binding.ResetBindings();
        }

    }
}
