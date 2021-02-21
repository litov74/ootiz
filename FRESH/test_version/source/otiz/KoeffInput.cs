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
    public partial class KoeffInput : Form
    {
        vypuskDataSet DataSet;
        //private bool Edited = false;

        public KoeffInput(vypuskDataSet DataSet)
        {
            InitializeComponent();
            this.DataSet = DataSet;
            коэффициентыBindingSource.DataSource = DataSet;
            процентыBindingSource.DataSource = DataSet;
            разрядыBindingSource.DataSource = DataSet;
        }

        private void KoeffInput_Load(object sender, EventArgs e)
        {
            /*this.процентыTableAdapter.Fill(this.vypuskDataSet.Проценты);
            this.разрядыTableAdapter.Fill(this.vypuskDataSet.Разряды);
            this.коэффициентыTableAdapter.Fill(this.vypuskDataSet.Коэффициенты);*/
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //коэффициентыTableAdapter.Update(vypuskDataSet);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //разрядыTableAdapter.Update(vypuskDataSet);
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //процентыTableAdapter.Update(vypuskDataSet);
        }

        private void KoeffInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            //коэффициентыBindingSource.EndEdit();
            //процентыBindingSource.    EndEdit();
            //разрядыBindingSource.     EndEdit();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DataSet.Операции.Select("Коэффициент = " + e.Row.Cells[0].Value as string).Length > 0)
                e.Cancel =
                       MessageBox.Show("Есть не удалённые операции данного коэффициента.\nУдалить?", "Внимание",
                       MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DataSet.Операции.Select("Разряд = " + e.Row.Cells[0].Value as string).Length > 0)
                e.Cancel =
                       MessageBox.Show("Есть не удалённые операции данного разряда.\nУдалить?", "Внимание",
                       MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && 
                dataGridView1.Rows[e.RowIndex].Cells[0].Value != null &&
                dataGridView1.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
                if (DataSet.Операции.Select("Коэффициент = '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value as string + "'").Length > 0)
                {
                    MessageBox.Show("Есть не удалённые операции данного коэффициента.", "Внимание",
                    MessageBoxButtons.OK);
                    e.Cancel = true;
                }
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 &&
                dataGridView2.Rows[e.RowIndex].Cells[0].Value != null &&
                dataGridView2.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
                if (DataSet.Операции.Select("Разряд = " + dataGridView2.Rows[e.RowIndex].Cells[0].Value as string).Length > 0)
                {
                    MessageBox.Show("Есть не удалённые операции данного разряда.", "Внимание",
                    MessageBoxButtons.OK);
                    e.Cancel = true;
                }
        }
    }
}
