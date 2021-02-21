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
    public partial class Ceha : Form
    {
        vypuskDataSet DataSet;

        public Ceha(vypuskDataSet DataSet)
        {
            InitializeComponent();
            this.DataSet = DataSet;
            bindingSource.DataSource = DataSet;
            bindingSource.Sort = "[ID Цеха]";
        }

        private void Operacyi_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dataGridView1.EndEdit();
            //bindingSource.EndEdit();
            //dataGridView1.AllowUserToAddRows = false;
            /*int BaseCountCeha = (int)DataSet.Цеха.Select("", "[ID Цеха] DESC")[0].ItemArray[0];
            foreach (vypuskDataSet.ЦехаRow row in DataSet.Цеха.Select("[ID Цеха] < 0"))
            {
                if (row.Цех == null)
                    row.Delete();
                else
                    row.ID_Цеха = BaseCountCeha - row.ID_Цеха;
            }*/
        }

        private void Add_Click(object sender, EventArgs e)
        {
            bindingSource.AddNew();
            dataGridView1.BeginEdit(false);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            bool Realy = true;
            if (DataSet.Операции.Select("[ID Цеха] = " + 
                (bindingSource.Current as DataRowView).Row.ItemArray[0]).Length > 0)
            {
                Realy =
                    MessageBox.Show("По данному цеху есть не удалённые операции.\nУдалить?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            if (Realy)
                bindingSource.RemoveCurrent();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DataSet.Операции.Select("[ID Цеха] = " + e.Row.Cells[0].Value).Length > 0)
            {
                e.Cancel =
                    MessageBox.Show("По данному цеху есть не удалённые операции.", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.No;
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dataGridView1.Rows[e.RowIndex].Cells[0].Value as int? < 0 & dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue as string != null)
                if (dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue as string != "")
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = (int)DataSet.Цеха.Select("", "[ID Цеха] DESC")[0].ItemArray[0] + 1;*/
        }
    }
}
