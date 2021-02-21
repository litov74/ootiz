using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace OOTiZ
{
    public partial class MainForm : Form
    {
        bool CheckOpEdited = true;
        bool Locked = false;
        bool OpLocked = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "vypuskDataSet1.Проценты". При необходимости она может быть перемещена или удалена.
            this.процентыTableAdapter1.Fill(this.vypuskDataSet1.Проценты);
            RefreshTables();
        }

        private void RefreshTables()
        {
                коэффициентыTableAdapter.Fill(this.vypuskDataSet.Коэффициенты);
                разрядыTableAdapter.Fill(this.vypuskDataSet.Разряды);
                процентыTableAdapter.Fill(this.vypuskDataSet.Проценты);
                цехаTableAdapter.Fill(this.vypuskDataSet.Цеха);
                виды_операцийTableAdapter.Fill(this.vypuskDataSet.Виды_операций);
                продукцияTableAdapter.Fill(this.vypuskDataSet.Продукция);
                операцииTableAdapter.Fill(this.vypuskDataSet.Операции);
                узлыTableAdapter.Fill(this.vypuskDataSet.Узлы);
                
        }

        #region Кнопки главного меню

        private void тарифыРазрядыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new KoeffInput(vypuskDataSet)).ShowDialog();
            разрядыTableAdapter.Update(vypuskDataSet.Разряды);
            коэффициентыTableAdapter.Update(vypuskDataSet.Коэффициенты);
            процентыTableAdapter.Update(vypuskDataSet.Проценты);
            коэффициентыTableAdapter.Fill(this.vypuskDataSet.Коэффициенты);
            разрядыTableAdapter.Fill(this.vypuskDataSet.Разряды);
            процентыTableAdapter.Fill(this.vypuskDataSet.Проценты);
        }

        private void операцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Operacyi(vypuskDataSet)).ShowDialog();
            виды_операцийTableAdapter.Update(vypuskDataSet.Виды_операций);
            виды_операцийTableAdapter.Fill(this.vypuskDataSet.Виды_операций);
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? OldValue = null;
            if (ShowDetail.SelectedValue != null)
                OldValue = (int)ShowDetail.SelectedValue;
            ShowDetail.Focus();
            (new Production(vypuskDataSet)).ShowDialog();
            продукцияTableAdapter.Update(vypuskDataSet.Продукция);
            продукцияTableAdapter.Fill(this.vypuskDataSet.Продукция);
            LoadTree();
            ShowDetail.SelectedValue = OldValue;
        }

        private void цехаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Ceha(vypuskDataSet)).ShowDialog();
            цехаTableAdapter.Update(vypuskDataSet.Цеха);
            цехаTableAdapter.Fill(this.vypuskDataSet.Цеха);
        }

        private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
                (new Report(vypuskDataSet, (int)ShowDetail.SelectedValue)).ShowDialog();
                операцииTableAdapter.Update(vypuskDataSet.Операции);
                узлыTableAdapter.Update(vypuskDataSet.Узлы);
                операцииTableAdapter.Fill(this.vypuskDataSet.Операции);
                узлыTableAdapter.Fill(this.vypuskDataSet.Узлы);
         //       продукцияTableAdapter.Update(vypuskDataSet.Продукция);
           //     продукцияTableAdapter.Fill(this.vypuskDataSet.Продукция);
                бригадыTableAdapter.Update(vypuskDataSet.Бригады);
                бригадыTableAdapter.Fill(vypuskDataSet.Бригады);

        
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Таблица деталей

        private void ShowDetail_SelectionValueChanged(object sender, EventArgs e)//Загрузка деталей выбранной продукции
        {
            if (ShowDetail.SelectedValue != null)
            {
                SelectDetail((int)ShowDetail.SelectedValue);
                LoadTree();
                LoadRevTree();
                SelectDetailForOperation(ShowDetail.Text, (int)ShowDetail.SelectedValue);
            }
        }

        private void SelectDetail(int ID)
        {
            узлыBindingSource.Filter = "[ID узловой детали] = " + ID;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != DBNull.Value)
                SelectDetailForOperation(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue as string, 
                                    (int)dataGridView1.Rows[e.RowIndex].Cells[2].Value);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 & e.RowIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    LKMDet.Visible = true;
                    LKMDet.Top = MainForm.MousePosition.Y;
                    LKMDet.Left = MainForm.MousePosition.X;
                }
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = (int)ShowDetail.SelectedValue;
        }

        #region Функции левой панели инструментов и контекстного меню

        private void ShowDet_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case (0):
                    {
                        if (dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value.GetType() != typeof(DBNull))
                            ShowDetail.SelectedValue = (int)dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value;
                        break;
                    }
                case (1):
                    {
                        ShowDetail.SelectedValue = (treeView1.SelectedNode.Tag as int[])[1];
                        break;
                    }
                case (2):
                    {
                        ShowDetail.SelectedValue = (treeView2.SelectedNode.Tag as int[])[1];
                        break;
                    }
            }
        }

        private void OpenDet_Click(object sender, EventArgs e)
        {
            int? OldValue = null;
            if (ShowDetail.SelectedValue != null)
                OldValue = (int)ShowDetail.SelectedValue;
            ShowDetail.Focus();
            if (!ShowDetail.Focused)
                switch (tabControl1.SelectedIndex)
                {
                    case (0):
                        {
                            if (dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value.GetType() != typeof(DBNull))
                                (new Production(vypuskDataSet)).ShowDialog((int)dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value);
                            break;
                        }
                    case (1):
                        {
                            (new Production(vypuskDataSet)).ShowDialog((treeView1.SelectedNode.Tag as int[])[1]);
                            break;
                        }
                    case (2):
                        {
                            (new Production(vypuskDataSet)).ShowDialog((treeView2.SelectedNode.Tag as int[])[1]);
                            break;
                        }
                }
            else
            {
                (new Production(vypuskDataSet)).ShowDialog((int)ShowDetail.SelectedValue);
            }
            продукцияTableAdapter.Update(vypuskDataSet.Продукция);
            продукцияTableAdapter.Fill(this.vypuskDataSet.Продукция);
            LoadTree();
            ShowDetail.SelectedValue = OldValue;
        }

        private void AddDet_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case (0):
                    {
                        dataGridView1.EndEdit();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Selected = true;
                        dataGridView1.BeginEdit(true);
                        break;
                    }
                case (1):
                    {
                        TreeNode NewDetail = new TreeNode("Новая деталь");
                        NewDetail.Tag = new int[2];
                        (NewDetail.Tag as int[])[0] = 0;
                        treeView1.SelectedNode.Nodes.Add(NewDetail);
                        SelectDetailForEdit(NewDetail);
                        break;
                    }
            }
        }

        private void DeleteDet_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите провести удаление?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                switch (tabControl1.SelectedIndex)
                {
                    case (0):
                        {
                            if (узлыBindingSource.Count > 0)
                                узлыBindingSource.Remove(узлыBindingSource.Current);
                            break;
                        }
                    case (1):
                        {
                            if (узлыBindingSource1.Count > 0)
                                узлыBindingSource1.Remove(узлыBindingSource1.Current);
                            treeView1.SelectedNode.Remove();
                            break;
                        }
                }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            if (CheckOpEdited)
            {
                string Filter = "[ID Продукции] in (0";
                foreach (vypuskDataSet.ОперацииRow row in vypuskDataSet.Операции.Select("Отметка = false"))
                    Filter += " ,'" + row.ID_Продукции + "'";
                Filter += ')';
                продукцияBindingSource.Filter = Filter;
                CheckOpEdited = false;
            }
            else
            {
                продукцияBindingSource.RemoveFilter();
                CheckOpEdited = true;
            }
        }

        #endregion

        #endregion

        #region Дерево деталей

        private void BuildTree(TreeNodeCollection Tree, string Name, int UzID, int ProdID, int? Count) //Рекурсивная процедура построения дерева
        {
            try
            {
                TreeNode Node;                                                         //////////////////////////
                if (Count != null)                                                     //
                    Node = new TreeNode(Name + " [" + Count.ToString() + "]");         //
                else                                                                   //Загрузка текущей детали
                    Node = new TreeNode(Name);                                         //в дерево
                Node.Tag = new int[] { UzID,        //Упаковка параметров узла в Tag   //
                                       ProdID};     //                                 //
                Tree.Add(Node);                                                        //////////////////////////
                if (Node.Level < 10)
                {
                    foreach (DataRow row in vypuskDataSet.Узлы.Select("[ID Узловой детали] = " + ProdID.ToString()))
                    {
                        BuildTree(Node.Nodes,                   ///////////////////////////////
                                  vypuskDataSet.Продукция.Select("[ID Продукции] = " + 
                                        row.ItemArray[2].ToString())[0].ItemArray[1] as string,         // Добавление в текущую деталь 
                                  (int)row.ItemArray[0],           // её составляющих 
                                  (int)row.ItemArray[2],
                                  (int)row.ItemArray[3]);
                    }
                    Node.Expand();
                }
                else
                    Node.Text = "Слишком длинная ветвь...";     //Защита от рекурсивных веток (деталь содержит сама себя, дочерняя деталь содержит родительскую и т.д.)
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void LoadTree()
        {
            treeView1.Nodes.Clear();
            if (ShowDetail.SelectedValue != null)
                BuildTree(treeView1.Nodes, ShowDetail.Text, -1, (int)ShowDetail.SelectedValue, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*операцииTableAdapter.Update(vypuskDataSet.Операции);
            узлыTableAdapter.Update(vypuskDataSet.Узлы);
            операцииTableAdapter.Fill(this.vypuskDataSet.Операции);
            узлыTableAdapter.Fill(this.vypuskDataSet.Узлы);*/
            if (tabControl1.SelectedIndex == 1)
                LoadTree();
            if (tabControl1.SelectedIndex == 2)
            {
                LoadRevTree();
                AddDet.Enabled = false;
                DeleteDet.Enabled = false;
            }
            else
            {
                AddDet.Enabled = true;
                DeleteDet.Enabled = true;
            }
            ShowDetail.Focus();
            Operations.PerformClick();
        }

        private void SelectDetailForEdit(TreeNode Node)
        {
            if (Node.Level > 0)
            {
                CurrentDetail.Tag = Node; //В свойстве Tag таблицы CurrentDetail хранится текущий узел дерева, а в нём его параметры
                if ((Node.Tag as int[])[0] == 0)
                {
                    //узлыBindingSource1.RemoveFilter();
                    узлыBindingSource1.Filter = "[ID Узла] = null";
                    узлыBindingSource1.AddNew();
                    Locked = true;
                    CurrentDetail.Rows[CurrentDetail.Rows.Count - 1].Cells[1].Value = (treeView1.SelectedNode.Tag as int[])[1];
                    CurrentDetail.Rows[CurrentDetail.Rows.Count - 1].Cells[3].Value = 1;
                    (Node.Tag as int[])[CurrentDetail.Rows.Count - 1] = (int)(узлыBindingSource1.Current as DataRowView).Row.ItemArray[0];
                    CurrentDetail.Rows[CurrentDetail.Rows.Count - 1].Cells[2].Selected = true;
                    Locked = false;
                }
                treeView1.SelectedNode = Node;
                узлыBindingSource1.Filter = "[ID Узла] = " + (Node.Tag as int[])[0];
            }
            else
                узлыBindingSource1.Filter = "[ID Узла] = null";
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectDetailForOperation(treeView1.SelectedNode.Text, 
                                    (treeView1.SelectedNode.Tag as int[])[1]);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                LKMDet.Visible = true;
                LKMDet.Top = MainForm.MousePosition.Y;
                LKMDet.Left = MainForm.MousePosition.X;
            }
        }

        #region Перетаскивание в дереве treeView1
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((e.Item as TreeNode).Level > 0)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode Dragged = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                TreeNode Destination = ((TreeView)sender).GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
                SelectDetailForEdit(Dragged);
                CurrentDetail.Rows[0].Cells[1].Value = (Destination.Tag as int[])[1];
                Dragged.Remove();
                Destination.Nodes.Add(Dragged);
            }
        }
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectDetailForEdit(treeView1.SelectedNode);
        }

        private void CurrentDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 & !Locked)
            {
                узлыBindingSource1.EndEdit();
                LoadTree();
            }
        }

        #endregion

        #region Запрос по детали

        private void BuildRevTree(TreeNodeCollection Tree, string Name, int UzID, int ProdID) //Рекурсивная процедура построения дерева
        {
            try
            {
                TreeNode Node;                                                         //////////////////////////                                                              
                Node = new TreeNode(Name);                                             //Загрузка текущей детали
                Node.Tag = new int[] { UzID,        //Упаковка параметров узла в Tag   //в дерево
                                       ProdID};     //                                 //
                Tree.Add(Node);                                                        //////////////////////////
                if (Node.Level < 10)
                {
                    foreach (DataRow row in vypuskDataSet.Узлы.Select("[ID Детали] = " + ProdID))
                    {
                        BuildRevTree(Node.Nodes,                                               ///////////////////////////////
                                  vypuskDataSet.Продукция.Select("[ID Продукции] = " +         //
                                       row.ItemArray[1].ToString())[0].ItemArray[1] as string, // Добавление в текущую деталь 
                                  (int)row.ItemArray[0],                                       // её составляющих 
                                  (int)row.ItemArray[1]);                                      ///////////////////////////////
                    }
                    Node.Expand();
                }
                else
                    Node.Text = "Слишком длинная ветвь...";     //Защита от рекурсивных веток (деталь содержит сама себя, дочерняя деталь содержит родительскую и т.д.)
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void LoadRevTree()
        {
            treeView2.Nodes.Clear();
            if (ShowDetail.SelectedValue != null)
                BuildRevTree(treeView2.Nodes, ShowDetail.Text, -1, (int)ShowDetail.SelectedValue);
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView2.SelectedNode = e.Node;
                LKMRevDet.Visible = true;
                LKMRevDet.Top  = MainForm.MousePosition.Y;
                LKMRevDet.Left = MainForm.MousePosition.X;
            }
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectDetailForOperation(treeView2.SelectedNode.Text,
                                    (treeView2.SelectedNode.Tag as int[])[1]);
        }

        #region Перетаскивание в дереве treeView2
        private void treeView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((e.Item as TreeNode).Level > 0)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode Dragged = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                TreeNode Destination = ((TreeView)sender).GetNodeAt(treeView2.PointToClient(new Point(e.X, e.Y)));
                vypuskDataSet.Узлы.FindByID_Узла((Dragged.Tag as int[])[0]).ID_Детали = (Destination.Tag as int[])[1];
                Dragged.Remove();
                Destination.Nodes.Add(Dragged);
            }
        }
        #endregion

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectDetailForEdit(treeView2.SelectedNode);
        }

        #endregion

        #region Таблица операций

        private void SelectDetailForOperation(string Name, int ProdID)
        {
            NameCurrentDetail.Text = Name;
            NameCurrentDetail.Tag = ProdID;
            OpLocked = true;
            операцииBindingSource.Filter = "[ID продукции] = " + ProdID;
            OpLocked = false;
        }

        private void Operations_Click(object sender, EventArgs e)
        {
            int ID = -1;
            string detailName = "";
            if (!ShowDetail.Focused)
                switch (tabControl1.SelectedIndex)
                {
                    case (0):
                        {
                            ID = (int)dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value;
                            detailName = dataGridView1.SelectedCells[0].OwningRow.Cells[2].FormattedValue as string;
                            break;
                        }
                    case(1):
                        {
                            ID = (treeView1.SelectedNode.Tag as int[])[1];
                            detailName = treeView1.SelectedNode.Text;
                            break;
                        }
                    case (2):
                        {
                            ID = (treeView2.SelectedNode.Tag as int[])[1];
                            detailName = treeView2.SelectedNode.Text;
                            break;
                        }
                }
            else
            {
                ID = (int)ShowDetail.SelectedValue;
                detailName = ShowDetail.Text;
            }
            SelectDetailForOperation(detailName, ID);
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //if ((int)NameCurrentDetail.Tag =)
            //    int a = 5;
            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[1].Value = (int)NameCurrentDetail.Tag;
            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[3].Value = 
                (vypuskDataSet.Виды_операций.Select("", "[ID Операции]")[0] as vypuskDataSet.Виды_операцийRow).ID_Операции;
            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[4].Value =
                (vypuskDataSet.Цеха.Select("", "[ID Цеха]")[0] as vypuskDataSet.ЦехаRow).ID_Цеха;
            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[7].Value = "1";
            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[8].Value = "а";

      /*      dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[9].Value =
              (vypuskDataSet.Бригады.Select("", "[Наименование]")[0] as vypuskDataSet.БригадыRow).Наименование;
      */
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!OpLocked)
                    (vypuskDataSet.Продукция.Select("[ID Продукции] = " + ((int)NameCurrentDetail.Tag).ToString())[0] as vypuskDataSet.ПродукцияRow).Дата_изменения = DateTime.Now;
            }
            if (e.ColumnIndex == 5 & e.RowIndex >= 0)
                dataGridView2.Rows[e.RowIndex].Cells[6].Value = (double)dataGridView2.Rows[e.RowIndex].Cells[5].Value * 60;
            if (e.ColumnIndex == 6 & e.RowIndex >= 0)
                if (dataGridView2.Rows[e.RowIndex].Cells[6].Value.GetType() == typeof(string))
                    dataGridView2.Rows[e.RowIndex].Cells[5].Value =
                        Math.Round(double.Parse(dataGridView2.Rows[e.RowIndex].Cells[6].Value as string) / 60, 6);
                else
                    dataGridView2.Rows[e.RowIndex].Cells[5].Value =
                        Math.Round((double)dataGridView2.Rows[e.RowIndex].Cells[6].Value / 60, 6);
            if (e.ColumnIndex == 10 & e.RowIndex >= 0)
                CheckOpEdited = true;
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
                if (row.Cells[5].Value != null)
                if (row.Cells[5].Value.GetType() != typeof(DBNull))
                    row.Cells[6].Value = (double)row.Cells[5].Value * 60;
        }

        private void UncheckAll_Click(object sender, EventArgs e)
        {
            foreach(vypuskDataSet.ОперацииRow row in vypuskDataSet.Операции)
                row.Отметка = false;
            CheckOpEdited = true;
        }

        private void Min_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns[6].Visible = !dataGridView2.Columns[6].Visible;
        }

        #region Функции левой панели инструментов и контекстного меню

        private void AddOp_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[3].Selected = true;
            dataGridView2.BeginEdit(true);
        }

        private void DeleteOp_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите провести удаление?", "Внимание",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                операцииBindingSource.Remove(операцииBindingSource.Current);
        }

        #endregion

        private void DoubleOp_Click(object sender, EventArgs e)
        {
            DataRow row = (операцииBindingSource.Current as DataRowView).Row;
            vypuskDataSet.ОперацииRow newRow = (операцииBindingSource.AddNew() as DataRowView).Row as vypuskDataSet.ОперацииRow;

            if (row.ItemArray[1].GetType() != typeof(DBNull))
                newRow.Номер        =    (int)row.ItemArray[1];

            if (row.ItemArray[2].GetType() != typeof(DBNull))
                newRow.ID_Вида      =    (int)row.ItemArray[2];

            if (row.ItemArray[3].GetType() != typeof(DBNull))
                newRow.ID_Продукции =    (int)row.ItemArray[3];

            if (row.ItemArray[4].GetType() != typeof(DBNull))
                newRow.ID_Цеха      =    (int)row.ItemArray[4];

            if (row.ItemArray[5].GetType() != typeof(DBNull))
                newRow.Норма        = (double)row.ItemArray[5];

            if (row.ItemArray[6].GetType() != typeof(DBNull))
                newRow.Разряд       =         row.ItemArray[6] as string;

            if (row.ItemArray[7].GetType() != typeof(DBNull))
                newRow.Коэффициент  =        row.ItemArray[7] as string;

            if (row.ItemArray[8].GetType() != typeof(DBNull))
                newRow.Примечание   =         row.ItemArray[8] as string;

            if (row.ItemArray[9].GetType() != typeof(DBNull))
                newRow.Отметка      =   (bool)row.ItemArray[9];

            if (row.ItemArray[10].GetType() != typeof(DBNull))
                newRow.Премия = (double)row.ItemArray[10];
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            операцииTableAdapter.Update(vypuskDataSet.Операции);
            узлыTableAdapter.Update(vypuskDataSet.Узлы);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                (vypuskDataSet.Продукция.Select("[ID Продукции] = " + ((int)ShowDetail.SelectedValue).ToString())[0] as vypuskDataSet.ПродукцияRow).Дата_изменения = DateTime.Now;
            if (e.ColumnIndex == 2 & e.RowIndex >= 0)
                if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.Equals(dataGridView1.Rows[e.RowIndex].Cells[1].Value))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = DBNull.Value;
                    MessageBox.Show("Деталь не может включать себя.", "Внимание!");
                }
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "help.chm";
                SysInfo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void СохранитьtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            операцииTableAdapter.Update(vypuskDataSet.Операции);
            узлыTableAdapter.Update(vypuskDataSet.Узлы);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void узлыBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void операцииBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void бригадыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Brigadi(vypuskDataSet)).ShowDialog();
            бригадыTableAdapter.Update(vypuskDataSet.Бригады);
            бригадыTableAdapter.Fill(this.vypuskDataSet.Бригады);
        }

        private void ShowDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}