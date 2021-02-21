using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OOTiZ
{
    public partial class Production : Form
    {
        vypuskDataSet DataSet;

        public Production(vypuskDataSet DataSet)
        {
            InitializeComponent();
            this.DataSet = DataSet;
            bindingSource.DataSource = DataSet;
            bindingSource.Sort = "Наименование детали";
        }

        public void ShowDialog(int ID)
        {
            bindingSource.Position = bindingSource.Find("ID Продукции", ID);
            base.ShowDialog();
        }

        private void Production_FormClosing(object sender, FormClosingEventArgs e)
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
            if (DataSet.Узлы.Select("[ID Детали] = " +
                (bindingSource.Current as DataRowView).Row.ItemArray[0]).Length > 0)
            {
                MessageBox.Show("По данной продукции есть не удалённые узлы.", "Внимание!");
            }
            else
            {
                if (MessageBox.Show("Удалить выбранную деталь? ", "Внимание",
                      MessageBoxButtons.YesNo) == DialogResult.Yes)
                    bindingSource.RemoveCurrent();
            }
        }
                   
       
        private void Double_Click(object sender, EventArgs e)
        {
            vypuskDataSet.ПродукцияRow Donor = (bindingSource.Current as DataRowView).Row as vypuskDataSet.ПродукцияRow;
            vypuskDataSet.ПродукцияRow NewProd = DataSet.Продукция.NewПродукцияRow();

            NewProd.ID_Продукции = (int)DataSet.Продукция.Select("", "[ID Продукции] DESC")[0].ItemArray[0] + 1;
            NewProd.Наименование_детали = Donor.Наименование_детали as string;                                /////////////////////////////////
            NewProd.Количество = 0;                                                                           //   Дублирование
            NewProd.Отметка = false;                                                                          //   выбранной детали
            DataSet.Продукция.AddПродукцияRow(NewProd);                                                       /////////////////////////////////   
            BindingSource table = new BindingSource(DataSet, "Узлы");                                           
            table.Filter = "[ID Узловой детали] = " + Donor.ID_Продукции;                                     
            foreach (DataRowView rowView in table)                                                            /////////////////////////////////
            {                                                                                                 //  
                vypuskDataSet.УзлыRow NewRow = DataSet.Узлы.NewУзлыRow();                                     //   Копирование
                NewRow.ID_Детали = (rowView.Row as vypuskDataSet.УзлыRow).ID_Детали;                          //   узлов
                NewRow.ПродукцияRowByПродукцияУзлы = NewProd;                                                 //   
                NewRow.Количество_деталей = (rowView.Row as vypuskDataSet.УзлыRow).Количество_деталей;        //
                DataSet.Узлы.AddУзлыRow(NewRow);                                                              //
            }                                                                                                 /////////////////////////////////
            table = new BindingSource(DataSet, "Операции");
            table.Filter = "[ID Продукции] = " + Donor.ID_Продукции;
            foreach (DataRowView rowView in table)                                                            /////////////////////////////////
            {                                                                                                 //
                vypuskDataSet.ОперацииRow NewRow = DataSet.Операции.NewОперацииRow();                         //  Копирование
                if (rowView.Row[1].GetType() != typeof(DBNull))                                               //  операций  
                    NewRow.Номер        =    (int)rowView.Row[1];                                              //    
                if (rowView.Row[2].GetType() != typeof(DBNull))                                               //
                    NewRow.ID_Вида      =    (int)rowView.Row[2];                                              //
                NewRow.ПродукцияRow = NewProd;                                                                //
                if (rowView.Row[4].GetType() != typeof(DBNull))                                               //
                    NewRow.ID_Цеха      =    (int)rowView.Row[4];                                              //
                if (rowView.Row[5].GetType() != typeof(DBNull))                                               //
                    NewRow.Норма        = (double)rowView.Row[5];                                              //
                if (rowView.Row[6].GetType() != typeof(DBNull))                                               //    
                    NewRow.Разряд       =         rowView.Row[6] as string;                                    //    
                if (rowView.Row[7].GetType() != typeof(DBNull))                                               //    
                    NewRow.Коэффициент  =         rowView.Row[7] as string;                                    //     
                if (rowView.Row[8].GetType() != typeof(DBNull))                                               //    
                    NewRow.Примечание   =         rowView.Row[8] as string;                                    //
                NewRow.Отметка = false;                                                                       //
                DataSet.Операции.AddОперацииRow(NewRow);                                                      /////////////////////////////////
            }                                                         
        }

        private void FindBox_TextChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = "[Наименование детали] LIKE '" + FindBox.Text + "%'";
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DataSet.Операции.Select("[ID Продукции] = "  + e.Row.Cells[0].Value).Length > 0 |
                DataSet.Узлы.Select("[ID Узловой детали] = " + e.Row.Cells[0].Value).Length > 0 |
                DataSet.Узлы.Select("[ID Детали] = "         + e.Row.Cells[0].Value).Length > 0)
            {
                e.Cancel =
                    MessageBox.Show("Есть связанные с продукцией узлы и операции.\nУдалить?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.No;
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value as int? < 0 & dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue as string != null)
                //if (dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue as string != "")
                {
                    //dataGridView1.Rows[e.RowIndex].Cells[0].Value = (int)DataSet.Продукция.Select("", "[ID Продукции] DESC")[0].ItemArray[0] + 1;
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = true;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = DateTime.Now;
                }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = DateTime.Now;
        }


    }
}
