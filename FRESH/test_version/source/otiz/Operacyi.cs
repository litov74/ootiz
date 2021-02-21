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
    public partial class Operacyi : Form
    {
        vypuskDataSet DataSet;

        public Operacyi(vypuskDataSet DataSet)
        {
            InitializeComponent();
            this.DataSet = DataSet;
            bindingSource.DataSource = DataSet;
        }

        private void Operacyi_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dataGridView1.EndEdit();
            //bindingSource.EndEdit();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            bindingSource.AddNew();
            dataGridView1.BeginEdit(false);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            bool Realy = true;
            if (DataSet.Операции.Select("[ID Вида] = " +
                (bindingSource.Current as DataRowView).Row.ItemArray[0]).Length > 0)
            {
                Realy =
                    MessageBox.Show("Есть не удалённые операции данного вида.\nУдалить?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            if (Realy)
                bindingSource.RemoveCurrent();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DataSet.Операции.Select("[ID Вида] = " + e.Row.Cells[0].Value).Length > 0)
            {
                e.Cancel =
                    MessageBox.Show("Есть не удалённые операции данного вида.\nУдалить?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.No;
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dataGridView1.Rows[e.RowIndex].Cells[0].Value as int? < 0 & dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue as string != null)
                if (dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue as string != "")
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = (int)DataSet.Виды_операций.Select("", "[ID Операции] DESC")[0].ItemArray[0] + 1;*/
        }
    }
}
