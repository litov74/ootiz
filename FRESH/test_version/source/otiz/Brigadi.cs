using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOTiZ
{
    public partial class Brigadi : Form
    {
        vypuskDataSet DataSet;

        public Brigadi(vypuskDataSet DataSet)
        {
            InitializeComponent();
            this.DataSet = DataSet;
            бригадыBindingSource.DataSource = DataSet;
            бригадыBindingSource.Sort = "[ID Бригады]";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            бригадыBindingSource.AddNew();
            dataGridView1.BeginEdit(false);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            bool Realy = true;
            if (DataSet.Операции.Select("[ID Бригады] = " +
                (бригадыBindingSource.Current as DataRowView).Row.ItemArray[0]).Length > 0)
            {
                Realy =
                    MessageBox.Show("По данной бригаде есть не удалённые операции.\nУдалить?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            if (Realy)
                бригадыBindingSource.RemoveCurrent();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DataSet.Операции.Select("[ID Бригады] = " + e.Row.Cells[0].Value).Length > 0)
            {
                e.Cancel =
                    MessageBox.Show("По данной бригаде есть не удалённые операции.", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.No;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            бригадыBindingSource.AddNew();
            dataGridView1.BeginEdit(false);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            bool Realy = true;
            if (DataSet.Операции.Select("[ID Бригады] = " +
                (бригадыBindingSource.Current as DataRowView).Row.ItemArray[0]).Length > 0)
            {
                Realy =
                    MessageBox.Show("По данной бригаде есть не удалённые операции.\nУдалить?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            if (Realy)
                бригадыBindingSource.RemoveCurrent();
        }

        private void Brigadi_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dataGridView1.EndEdit();
            //бригадыBindingSource.EndEdit();
            //dataGridView1.AllowUserToAddRows = false;
            //int BaseCountBrigadi = (int)DataSet.Бригады.Select("", "[ID Бригады] DESC")[0].ItemArray[0];
            //foreach (vypuskDataSet.БригадыRow row in DataSet.Бригады.Select("[ID Бригады] < 0"))
            //{
            //    if (row.Наименование == null)
            //        row.Delete();
            //    else
            //        row.ID_Бригады = BaseCountBrigadi - row.ID_Бригады;
            //}
        }

        private void Brigadi_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "vypuskDataSet.Бригады". При необходимости она может быть перемещена или удалена.
            this.бригадыTableAdapter.Fill(this.vypuskDataSet.Бригады);

        }
    }
}
