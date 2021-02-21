using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace OOTiZ
{
    public partial class Report : Form
    {

        private class Operation
        {
            public string Name;
            public double Norma;
            public double Rascenka;
            public string Razryad;
            public string Koeff;
            public double Premia;
            public string Primech;
            public bool Check;
            public int ID;
            public int Number;
            public double zarp;


            public Operation
                (int ID,
                 int? Number,
                 string Name,
                 double? Norma,
                 string Razryad,
                 string Koeff,
                double? Premia,
                double? zarp,
                 string Primech,
                 bool? Check,
               

                 vypuskDataSet DataSet)
            {
                this.ID = ID;
                if (Number != null)
                    this.Number = Number.Value;
                else
                    this.Number = 0;
                this.Name = Name;
                if (Norma != null)
                    this.Norma = Norma.Value;
                else
                    this.Norma = 0;
                if (Premia != null)
                    this.Premia = Premia.Value;
                else
                    this.Premia = 0;
                this.Razryad = Razryad;
                this.Koeff = Koeff;
                this.Primech = Primech;
                if (Check != null)
                    this.Check = Check.Value;
                else
                    Check = false;
                object razr = (double)DataSet.Разряды.Select     ("Кратко = '" + Razryad + "'")[0].ItemArray[2];
                if (razr.GetType() != typeof(double) & razr.GetType() != typeof(int)) razr = 1.0;
                object koef = (double)DataSet.Коэффициенты.Select("Кратко = '" + Koeff   + "'")[0].ItemArray[2];
                if (koef.GetType() != typeof(double) & koef.GetType() != typeof(int)) koef = 1.0;
                this.Rascenka = Math.Round(Math.Round(this.Norma * (double)razr, 6) * (double)koef, 6);
                //!!
                this.zarp = Math.Round(Math.Round(this.Rascenka * 10, 6)); //this.zarp = Math.Round(Math.Round(this.Rascenka * (double)Premia, 6));
                //!!
            }               
        }

        private class Detail
        {

            public struct Uzel
            {  
                public Detail detail;
                public int Count;

                public double Norma    { get { return detail.Norma * Count;    } }
                public double Rascenka { get { return detail.Rascenka * Count; } }

             



                public Uzel(Detail detail, int Count)
                {
                    this.detail = detail;
                    this.Count = Count;
                }
            }

            public class Ceh
            {
                public int ID;
                public string Name;
                public List<Operation> operations;
                public double Norma;
                public double OpNorma;
                public double Rascenka;
                public double OpRascenka;

                public Ceh(int ID, string Name)
                {
                    this.ID = ID;
                    this.Name = Name;
                    this.operations = new List<Operation>();
                }
            }

            public int ID;
            public string Name;
            public int Count;
            public int CalcCount;
            public bool Check;
            public bool CalcCheck;
            public List<Ceh> Ceha;
            public List<Uzel> details;
            public double Norma;
            public double NormaOp;
            public double Rascenka;
            public double RascenkaOp;
            public int OperationCount;

            public Detail(int ID, string Name, int? Count, bool? Check)
            {
                this.ID = ID;
                this.Name = Name;
                if (Count != null)
                    this.Count = Count.Value;
                else
                    this.Count = 0;
                if (Check != null)
                    this.Check = Check.Value;
                else
                    this.Check = false;
                OperationCount = 0;
            }

            public void Load(vypuskDataSet DataSet, Detail[] details)
            {
                if (this.Ceha == null & this.details == null)
                {
                    Ceha = new List<Ceh>();
                    foreach (DataRow Row in DataSet.Цеха.Rows)
                        if (Row.ItemArray[1].GetType() == typeof(string))
                            Ceha.Add(new Ceh((int)Row.ItemArray[0], Row.ItemArray[1] as string));
                        else
                            Ceha.Add(new Ceh((int)Row.ItemArray[0], ""));
                    this.details = new List<Uzel>();
                    foreach (Ceh ceh in this.Ceha)
                        ceh.operations = new List<Operation>();
                    foreach (DataRow Row in DataSet.Узлы.Select("[ID Узловой детали] = " + ID.ToString()))
                    {
                        if ((int)Row.ItemArray[2] != this.ID) if (Row.ItemArray[2].GetType() == typeof(int) & Row.ItemArray[3].GetType() == typeof(int))
                            {
                                this.details.Add(new Uzel(details[(int)Row.ItemArray[2]], (int)Row.ItemArray[3]));
                                this.details[this.details.Count - 1].detail.Load(DataSet, details);
                                for (int i = 0; i < this.details[this.details.Count - 1].detail.Ceha.Count; i++)
                                {
                                    this.Ceha[i].Norma += this.details[this.details.Count - 1].detail.Ceha[i].Norma * this.details[this.details.Count - 1].Count;
                                    this.Ceha[i].Rascenka += this.details[this.details.Count - 1].detail.Ceha[i].Rascenka * this.details[this.details.Count - 1].Count;
                                }
                            }
                    }
                    foreach (DataRow Row in DataSet.Операции.Select("[ID Продукции] = " + ID.ToString(), "[ID Цеха], [Номер]"))
                    {
                        if (Row.ItemArray[2].GetType() == typeof(int))
                        {
                            Ceh ceh = this.Ceha.Find(x => x.ID == (int)Row.ItemArray[4]);
                            ceh.operations.Add(new Operation((int)Row.ItemArray[0],              //ID Операции
                                                                  Row.ItemArray[1] as int?,      //Номер
           DataSet.Виды_операций.Select("[ID Операции] = " + (int)Row.ItemArray[2])[0].ItemArray[1] as string,    //Наименование операции
                                                                  Row.ItemArray[5] as double?,    //Норма
                                                                  Row.ItemArray[6] as string,    //Разряд   
                                                                  Row.ItemArray[7] as string,    //Коэффициент  
                                                                  Row.ItemArray[8] as double?,    //premiya
                                                                  Row.ItemArray[9] as double?,    //zarplata
                                                                  Row.ItemArray[10] as string,    //Примечание
                                                                  Row.ItemArray[11] as bool?,     //Отметка
                                                                  
                                                                  DataSet));
                            NormaOp += ceh.operations[ceh.operations.Count - 1].Norma;
                            ceh.Norma += ceh.operations[ceh.operations.Count - 1].Norma;
                            ceh.OpNorma += ceh.operations[ceh.operations.Count - 1].Norma;
                            RascenkaOp += ceh.operations[ceh.operations.Count - 1].Rascenka;
                            ceh.Rascenka += ceh.operations[ceh.operations.Count - 1].Rascenka;
                            ceh.OpRascenka += ceh.operations[ceh.operations.Count - 1].Rascenka;
                            OperationCount++;
                        }
                    }
                    foreach (Ceh ceh in this.Ceha)
                    {
                        if (ceh != null)
                        {
                            Norma += ceh.Norma;
                            Rascenka += ceh.Rascenka;
                        }
                    }
                }
            }

            public void CalcForReport(int Count)
            {
                CalcCheck = true;
                CalcCount += Count;
                foreach (Uzel uzel in details)
                    if (uzel.detail.ID != this.ID)
                        uzel.detail.CalcForReport(Count * uzel.Count);
            }
        }

        double proc;
        Detail[] detailsFastAcces;
        List<Detail> detailsSorted;
        vypuskDataSet DataSet;
        int Selection;

        public Report(vypuskDataSet DataSet, int Selection)
        {
            InitializeComponent();
            this.DataSet = DataSet;
            this.Selection = Selection;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "vypuskDataSet.Продукция". При необходимости она может быть перемещена или удалена.
            this.продукцияTableAdapter.Fill(this.vypuskDataSet.Продукция);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "vypuskDataSet.Продукция". При необходимости она может быть перемещена или удалена.
            this.продукцияTableAdapter.Fill(this.vypuskDataSet.Продукция);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "vypuskDataSet.Бригады". При необходимости она может быть перемещена или удалена.
            this.бригадыTableAdapter.Fill(this.vypuskDataSet.Бригады);
            bindingSource1.DataSource = DataSet;
            bindingSource1.Sort = "Наименование детали";
            detailsFastAcces = new Detail[(int)DataSet.Продукция.Select("", "[ID Продукции] DESC")[0].ItemArray[0] + 1];
            detailsSorted = new List<Detail>();
            object p = DataSet.Проценты.Select("Кратко = '%п'")[0].ItemArray[2];
            if (p.GetType() != typeof(double) & p.GetType() != typeof(int)) p = 0.00;
            object d = DataSet.Проценты.Select("Кратко = '%д'")[0].ItemArray[2];
            if (d.GetType() != typeof(double) & d.GetType() != typeof(int)) d = 0.00;
            proc = Math.Round((((double)p + 100) / 100 * ((double)d + 100) / 100), 4);
            foreach (DataRow row in DataSet.Продукция.Rows) 
            {
                detailsFastAcces[(int)row.ItemArray[0]] = new Detail((int)row.ItemArray[0],
                                                                          row.ItemArray[1] as string,
                                                                          row.ItemArray[2] as int?,
                                                                          row.ItemArray[3] as bool?);
                detailsSorted.Add(detailsFastAcces[(int)row.ItemArray[0]]);
            }
            //string[] HelpList = new string[detailsSorted.Count];
            /*for (int i = 0; i < detailsSorted.Count; i++)
                HelpList[i] = detailsSorted[i].Name;*/
            //FindBox.AutoCompleteCustomSource.AddRange(HelpList);
            foreach (Detail detail in detailsFastAcces)
                if (detail != null)
                    detail.Load(DataSet, detailsFastAcces);
            dataGridView1.Focus();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                    detailsFastAcces[(int)dataGridView1.Rows[e.RowIndex].Cells[0].Value].Count =
                        (int)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                if (e.ColumnIndex == 3)
                    detailsFastAcces[(int)dataGridView1.Rows[e.RowIndex].Cells[0].Value].Check =
                        (bool)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            }
        }

        private void CheckAll_Click(object sender, EventArgs e)
        {
            foreach (vypuskDataSet.ПродукцияRow row in DataSet.Продукция)
            {
                row.Отметка = true;
                detailsFastAcces[row.ID_Продукции].Check = true;
            }
        }

        private void UncheckAll_Click(object sender, EventArgs e)
        {
            foreach (vypuskDataSet.ПродукцияRow row in DataSet.Продукция)
            {
                row.Отметка = false;
                detailsFastAcces[row.ID_Продукции].Check = false;
            }
        }

        private void CheckInverse_Click(object sender, EventArgs e)
        {
            foreach (vypuskDataSet.ПродукцияRow row in DataSet.Продукция)
            {
                row.Отметка = !row.Отметка;
                detailsFastAcces[row.ID_Продукции].Check = 
                    !detailsFastAcces[row.ID_Продукции].Check;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            foreach (vypuskDataSet.ПродукцияRow row in DataSet.Продукция)
            {
                row.Количество = 0;
                detailsFastAcces[row.ID_Продукции].Count = 0;
            }
        }

        private void CheckSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.SelectedRows)
            {
                Row.Cells[3].Value = true;
                detailsFastAcces[(int)Row.Cells[0].Value].Check = true;
            }
        }

        private void UncheckSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.SelectedRows)
            {
                Row.Cells[3].Value = false;
                detailsFastAcces[(int)Row.Cells[0].Value].Check = false;
            }
        }

        private void CheckInverseSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.SelectedRows)
            {
                Row.Cells[3].Value = !(bool)Row.Cells[3].Value;
                detailsFastAcces[(int)Row.Cells[0].Value].Check = 
                    !detailsFastAcces[(int)Row.Cells[0].Value].Check;
            }
        }

        private void ResetSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.SelectedRows)
            {
                Row.Cells[2].Value = 0;
                detailsFastAcces[(int)Row.Cells[0].Value].Count = 0;
            }
        }

        private void Full_CheckedChanged(object sender, EventArgs e)
        {
            Vid_Full.Visible = radioButton3.Checked & Full.Checked;
        }

        private void GenerateReport1(Detail detail, int level, int Count, List<object[]> list)
        {
            string levelTabs = "";
            for (int i = 0; i < level; i++)
                levelTabs += "    | ";
            list.Add(new object[15 + DataSet.Цеха.Count]);                                        ////////////////////
            if (level == 0)
            {
                list[list.Count - 1][1] = detail.Name;
                list[list.Count - 1][0] = 'u';
            }
            else
            {
                list[list.Count - 1][1] = levelTabs.Remove(levelTabs.Length - 2) + '-' + detail.Name;
                list[list.Count - 1][4] = Count;
            }
            if (level == 0 | Full.Checked)
                foreach (Detail.Ceh ceh in detail.Ceha)
                {
                    foreach (Operation operation in ceh.operations)
                    {
                        list.Add(new object[15 + DataSet.Цеха.Count]);
                        list[list.Count - 1][0]                       = null;
                        list[list.Count - 1][1]                       = "    | " + levelTabs;
                        list[list.Count - 1][2]                       = operation.Number;                           
                        list[list.Count - 1][3]                       = /*levelTabsOperations + */"    " + operation.Name;
                        list[list.Count - 1][4]                       = null;
                        list[list.Count - 1][5]                       = operation.Razryad;
                        list[list.Count - 1][6]                       = operation.Koeff;
                        list[list.Count - 1][7]                       = operation.Norma;
                        list[list.Count - 1][8]                       = operation.Rascenka;
                        list[list.Count - 1][9]                       = null;
                        list[list.Count - 1][10]                      = Math.Round((double)(operation.Norma * Count), 6);
                        list[list.Count - 1][11]                      = Math.Round((double)(operation.Rascenka * Count), 6);
                        list[list.Count - 1][12] = null;
                        list[list.Count - 1][13]                      = ceh.Name;
                        list[list.Count - 1][14 + DataSet.Цеха.Count] = operation.Primech;
                    }
                }
            //if (level == 0 | Full.Checked)
            if (detail.OperationCount > 0 & (level == 0 | Full.Checked))
            {
                list.Add(new object[13 + DataSet.Цеха.Count]);
                list[list.Count - 1][1] = "    | " + levelTabs;
                list[list.Count - 1][3] = /*levelTabsOperations + */"Итого по операциям: ";
                list[list.Count - 1][7] = detail.NormaOp;
                list[list.Count - 1][8] = detail.RascenkaOp;
                list[list.Count - 1][9] = Math.Round((double)(detail.NormaOp * Count), 6);
                list[list.Count - 1][10] = Math.Round((double)(detail.RascenkaOp * Count), 6);
                for (int i = 0; i < DataSet.Цеха.Count; i++)
                    list[list.Count - 1][12 + i] = Math.Round((double)(detail.Ceha[i].OpNorma * Count), 6);
                /*foreach (Detail.Ceh ceh in detail.Ceha)
                {
                    if (ceh.OpNorma > 0)
                    {
                        //list.Add(new object[11 + DataSet.Цеха.Count]);
                        //list[list.Count - 1][1] = "    | " + levelTabs;
                        //list[list.Count - 1][3] = "  Итого по " + ceh.Name + ": ";
                        list[list.Count - 1][8] = /*Math.Round((double)(ceh.OpNorma * Count/*), 6);
                        list[list.Count - 1][9] = /*Math.Round((double)(ceh.OpRascenka * Count/*), 6);
                    }
                }*/
            }
            if (level < 20 & (level == 0 | Full.Checked))
                foreach (Detail.Uzel podUzel in detail.details)
                {
                    GenerateReport1(podUzel.detail, level + 1, podUzel.Count * Count, list);
                    //list[list.Count - 1][4] = podUzel.Count;
                }
            if ((detail.details.Count > 0 | detail.OperationCount > 0) & (level == 0 | Full.Checked))
            {
                list.Add(new object[13 + DataSet.Цеха.Count]);
                if (level == 0)
                {
                    list[list.Count - 1][0] = 'u';
                    list[list.Count - 1][1] = "Итого по " + detail.Name + ":";
                }
                else
                    list[list.Count - 1][1] = levelTabs + "Итого по " + detail.Name + ":";
            }
            list[list.Count - 1][7] = detail.Norma;
            list[list.Count - 1][8] = detail.Rascenka;
            list[list.Count - 1][9] = Math.Round((double)(detail.Norma * Count), 6);
            list[list.Count - 1][10] = Math.Round((double)(detail.Rascenka * Count), 6);
            for (int i = 0; i < DataSet.Цеха.Count; i++)
                list[list.Count - 1][12 + i] = Math.Round((double)(detail.Ceha[i].Norma * Count), 6);
            if (level == 0)
                list.Add(new object[1]);
        }
        
        private void GenerateReport2(Detail detail, int level, int Count, List<object[]> list)
        {
            string levelTabs = "";
            for (int i = 0; i < level; i++)
                if (i == level - 1)
                    levelTabs += "    -";
                else
                    levelTabs += "    | ";
            if (level == 0 & Full.Checked)
                list.Add(new object[] { levelTabs + detail.Name, null, null, null, 'b' });
            else
                list.Add(new object[] { levelTabs + detail.Name, null, null, null, null });
            if (Full.Checked & level < 20)
                foreach (Detail.Uzel podUzel in detail.details)
                {
                    GenerateReport2(podUzel.detail, level + 1, podUzel.Count * Count, list);
                    list[list.Count - 1][3] = podUzel.Count;
                }
            if (detail.details.Count > 0 & Full.Checked)
                if (level == 0 & Full.Checked)
                    list.Add(new object[] { levelTabs + "Итого по: " + detail.Name, null, null, null, 'b' });
                else
                    list.Add(new object[] { levelTabs + "Итого по: " + detail.Name, null, null, null, null });
            list[list.Count - 1][1] = Math.Round((double)(detail.Norma * Count), 6);
            list[list.Count - 1][2] = Math.Round((double)(detail.Rascenka * Count * proc), 9);
            if (level == 0 & Full.Checked)
                    list.Add(new object[5]);
        }

        private void GenerateReport3(Detail detail, int level, int Сount, List<object[]> list)
        {
            string levelTabs = "";
            for (int i = 0; i < level; i++)
                if (i == level - 1)
                    levelTabs += "    -";
                else
                    levelTabs += "    | ";
            list.Add(new object[6]);
            list[list.Count - 1][2] = Сount;
            list[list.Count - 1][0] = levelTabs + detail.Name;
            if (level == 0 & Full.Checked)
                list[list.Count - 1][5] = 'b';
            if (Full.Checked & level < 20)
                foreach (Detail.Uzel podUzel in detail.details)
                {
                    GenerateReport3(podUzel.detail, level + 1, podUzel.Count * Сount, list);
                    list[list.Count - 1][4] = podUzel.Count;
                }
            if (detail.details.Count > 0 & Full.Checked)
            {
                list.Add(new object[6]);
                if (level == 0 & Full.Checked)
                    list[list.Count - 1][5] = 'b';
                list[list.Count - 1][0] = levelTabs + "Итого по " + detail.Name + ":";
            }
            list[list.Count - 1][1] = detail.Norma;
            list[list.Count - 1][3] = detail.Norma * Сount;
            if (level == 0 & detail.details.Count > 0 & Full.Checked)
                list.Add(new object[6]);
        }


//новый отчет на деятельность каждой бригады 
        private void GenerateReport999(Detail detail, int level, int Сount, List<object[]> list)
        {
         


            string levelTabs = "";
            for (int i = 0; i < level; i++)
                if (i == level - 1)
                    levelTabs += "    -";
                else
                    levelTabs += "    | ";
            
            list.Add(new object[12]);
           
            list[list.Count - 1][2] = Сount;   
            list[list.Count - 1][0] = levelTabs + detail.Name;       
          

         /*   if (level == 0 )
                list[list.Count - 1][5] = 'b'; */ 
         
            if (level < 20)
                foreach (Detail.Uzel podUzel in detail.details)
                {
                    GenerateReport999(podUzel.detail, level + 1, podUzel.Count * Сount, list);
                list[list.Count - 1][4] = podUzel.Count;
                }
           
            /*  */    
       
              if (detail.details.Count > 0 )
            {
                list.Add(new object[12]);
                if (level == 0 )
            /*      */   list[list.Count - 1][5] = 'b';         
                  list[list.Count - 1][0] = levelTabs + " Итого ";  
            } 
          
           
            list[list.Count - 1][1] = detail.Norma;

            list[list.Count - 1][3] = detail.Norma * Сount; 


            list[list.Count - 1][5] = detail.Rascenka;




            if (level == 0 & detail.details.Count > 0 )
                list.Add(new object[12]);


            
        }



       


        //Отчет по бригадам
        private void GenerateReport_Brigadi(Detail detail, int level, int Count, List<object[]> list)
        {
            string levelTabs = "";
            list.Add(new object[15 + DataSet.Цеха.Count]);                                        ////////////////////
            if (level == 0)
            {
                list[list.Count - 1][1] = detail.Name;
                list[list.Count - 1][0] = 'u';
            }
            else
            {
                list[list.Count - 1][1] = levelTabs.Remove(levelTabs.Length - 2) + '-' + detail.Name;
                list[list.Count - 1][4] = Count;
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            Excel.Application ExcelFile = new Excel.Application();
            ExcelFile.SheetsInNewWorkbook = 1;
            ExcelFile.Workbooks.Add();
            Excel.Worksheet report = ExcelFile.Worksheets[1];
            #region Узел в сборке
            if (radioButton1.Checked)
            {
                progressBar1.Maximum = detailsSorted.Count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                List<object[]> list = new List<object[]>();
                for (int i = 0; i < detailsSorted.Count; i++)
                {
                    progressBar1.Value = i;
                    if (detailsSorted[i].Check)
                        GenerateReport1(detailsSorted[i], 0, 1, list);
                }
                object[,] Table = new object[list.Count, 12 + DataSet.Цеха.Count];
                for (int i = 0; i < list.Count; i++)
                    for (int j = 0; j < 12 + DataSet.Цеха.Count; j++)
                        if (j < list[i].Length - 1)
                            Table[i, j] = list[i][j + 1];
                for (int i = 0; i < list.Count; i++)
                    if (list[i][0] as char? == 'u')
                        report.Cells[i + 3, 1].Font.Underline = true;
                report.Range[report.Cells[4, 1], report.Cells[list.Count + 3, 12 + DataSet.Цеха.Count]].Value = Table;
                report.Range[report.Cells[4, 4], report.Cells[list.Count + 3, 5]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                report.Range[report.Cells[4, 7], report.Cells[list.Count + 3, 8]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                report.Range[report.Cells[4, 1], report.Cells[list.Count + 3, 1]].Font.Bold = true;
                report.Range[report.Cells[4, 3], report.Cells[list.Count + 3, 3]].Font.Italic = true;

                if (!Full.Checked)
                    report.Cells[1, 1] = "Узел в сборке";
                else
                    report.Cells[1, 1] = "Узел в сборке развёрнутый";

                report.Cells[2, 1] = "Дата:";
                report.Cells[2, 2] = DateTime.Today.ToShortDateString();

                report.Columns[1].ColumnWidth = 10;
                report.Cells[3, 1] = "Продукция";

                report.Columns[2].ColumnWidth = 7;
                report.Cells[3, 2] = "№ Операции";

                report.Columns[3].ColumnWidth = 30;
                report.Cells[3, 3] = "Вид операции";

                report.Columns[4].ColumnWidth = 4;
                report.Cells[3, 4] = "Кол-во в узле";

                report.Columns[5].ColumnWidth = 3;
                report.Cells[3, 5] = "Разряд";

                report.Columns[6].ColumnWidth = 3;
                report.Cells[3, 6] = "Коэффициент";

                report.Columns[7].ColumnWidth = 10;
                report.Columns[7].NumberFormat = "0,000000";
                report.Cells[3, 7] = "Норма времени, час";

                report.Columns[8].ColumnWidth = 10;
                //report.Columns[8].NumberFormat = "0,0000";
                report.Cells[3, 8] = "Расценок, руб";
                report.Columns[8] = "0";


                report.Columns[9].ColumnWidth = 10;
                report.Columns[9].NumberFormat = "0,000000";
                report.Cells[3, 9] = "З/п на ед. с прем., руб";
                   
                report.Columns[10].ColumnWidth = 10;
                report.Columns[10].NumberFormat = "0,000000";
                report.Cells[3, 10] = "Норма времени * количество, час";

                report.Columns[11].ColumnWidth = 10;
                report.Columns[11].NumberFormat = "0,0000";
                report.Cells[3, 11] = "Расценок * количество, час";

                report.Columns[12].ColumnWidth = 10;
                report.Columns[12].NumberFormat = "0,000000 ";
                report.Cells[3, 12] = "З/п с премией, руб";

                report.Columns[13].ColumnWidth = 4;
                report.Cells[3, 13] = "Цех";

                for (int i = 0; i < DataSet.Цеха.Count; i++)
                {
                    report.Cells[3, i + 14] = "t " + DataSet.Цеха[i].Цех;
                    report.Columns[i + 14].ColumnWidth = 10;
                    report.Columns[i + 14].NumberFormat = "0,000000";
                }

                report.Columns[DataSet.Цеха.Count + 14].ColumnWidth = 10;
                report.Cells[3, DataSet.Цеха.Count + 14] = "Примечание";

                report.Range[report.Cells[3, 1], report.Cells[3, 12 + DataSet.Цеха.Count]].Borders.weight = 3;
                report.Range[report.Cells[3, 1], report.Cells[3, 12 + DataSet.Цеха.Count]].VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                report.Range[report.Cells[3, 1], report.Cells[3, 12 + DataSet.Цеха.Count]].Font.Bold = true;
                report.Range[report.Cells[3, 1], report.Cells[3, 12 + DataSet.Цеха.Count]].WrapText = true;

                progressBar1.Visible = false;
            }
            #endregion
            #region Отчет по бригадам
            if (radioButton8.Checked)
            {
             
                             
                string znachBRIGADI;
                znachBRIGADI = comboBox1.Text;

                string idbrgd = comboBox3.Text;
                Int32 idBrigadi = Int32.Parse(idbrgd);

              


             //   операцииBindingSource.Filter = "[ID Бригады]  =  'idBrigadi'  "; пробовала такое, но оно не работает 



                progressBar1.Maximum = detailsSorted.Count;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;
                    List<object[]> list = new List<object[]>();



                    for (int i = 0; i < detailsSorted.Count; i++)
                    {
                        progressBar1.Value = i;
                        if (detailsSorted[i].Count > 0)
                            GenerateReport999(detailsSorted[i], 0, detailsSorted[i].Count, list);
                    }



                    object[,] Table = new object[list.Count, 12];
                    bool ContainsPodUzel = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = 0; j < 6; j++)
                            Table[i, j] = list[i][j];
                        if (Table[i, 5] != null)
                            ContainsPodUzel = true;
                    }

                    for (int i = 0; i < list.Count; i++)

                    {
                        if (list[i][5] as char? == 'b')
                        {
                            report.Cells[i + 12, 1].Font.Bold = true;
                            report.Cells[i + 12, 1].Font.Underline = true;
                        }
                    }


                    report.Range[report.Cells[8, 1], report.Cells[list.Count + 3, 8]].Value = Table;


                    report.Cells[1, 1] = "Отчет по бригаде   " + znachBRIGADI;

                    report.Cells[2, 1] = "Дата: ";
                    report.Cells[2, 2] = DateTime.Today.ToShortDateString();


                    report.Range["H3:J3"].Merge();
                    report.Range["H3:J3"].Borders.Weight = 2;
                    report.Cells[3, 8] = DateTime.Now.AddMonths(-1).ToString("MMMM yyyy");
                    report.Cells[3, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    report.Columns[1].ColumnWidth = 45;
                    report.Cells[4, 1] = "Наименование продукции";
                    report.Cells[4, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    report.Columns[2].ColumnWidth = 15;
                    report.Columns[2].NumberFormat = "0,000000";
                    report.Cells[4, 2] = "Норма времени,час";
                    report.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    report.Columns[3].ColumnWidth = 12;
                    report.Cells[4, 3] = "Количество";
                    report.Cells[4, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    report.Columns[4].ColumnWidth = 12;
                    report.Columns[4].NumberFormat = "0,000000";
                    report.Cells[4, 4] = "Время на выпуск, час";
                    report.Cells[4, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    report.Columns[6].ColumnWidth = 15;
                    report.Columns[6].NumberFormat = "0,0000";
                    report.Cells[4, 6] = "Расценка";
                    report.Cells[4, 6].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;


                    report.Columns[7].ColumnWidth = 15;
                    report.Columns[7].NumberFormat = "0,0000";
                    report.Cells[4, 7].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    report.Cells[4, 7] = "План";


                    report.Cells[4, 11].Borders.Weight = 2;
                    report.Columns[11].ColumnWidth = 15;
                    report.Columns[11].NumberFormat = "0,0000";
                    report.Cells[4, 11].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    report.Cells[4, 11] = "Труд.";


                    report.Cells[4, 12].Borders.Weight = 2;
                    report.Columns[12].ColumnWidth = 15;
                    report.Columns[12].NumberFormat = "0,0000";
                    report.Cells[4, 12].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    report.Cells[4, 12] = "Ф.з./пл.";




                    if (ContainsPodUzel)
                    {
                        report.Columns[5].ColumnWidth = 10;
                        report.Cells[4, 5] = "Кол-во в узле";
                        report.Range[report.Cells[4, 1], report.Cells[4, 7]].Borders.weight = 2;
                    }
                    else
                        report.Range[report.Cells[4, 1], report.Cells[4, 6]].Borders.weight = 2;
                    report.Range[report.Cells[4, 1], report.Cells[4, 12]].WrapText = true;
                    report.Range[report.Cells[4, 1], report.Cells[4, 12]].Font.Bold = true;


                    //     Итогииииииииииииии

                    report.Cells[list.Count + 5, 10] = "Итого";

                    report.Cells[list.Count + 5, 11].Formula = $"=SUM(K5:K{list.Count + 3})";
                    report.Cells[list.Count + 6, 11] = "прем. 37 %";

                    report.Cells[list.Count + 5, 12].Formula = $"=SUM(L5:L{list.Count + 3})";
                    report.Cells[list.Count + 6, 12].Formula = $"=SUM(L5:L{list.Count + 3})/100*37";
                    report.Cells[list.Count + 7, 12].Formula = $"=SUM(L{list.Count + 5}:L{list.Count + 6})";


                   
                  
                       int normavirobatki;
                       string znachNV;
                       znachNV = comboBox2.Text;
                       normavirobatki = int.Parse(znachNV);
                       report.Cells[list.Count + 5, 2] = normavirobatki;      
               

                    report.Cells[list.Count + 5, 1] = "норма выр. %";


                    report.Cells[list.Count + 6, 2].Formula = $"=B{list.Count + 5}*B{list.Count + 11}/100";
                    report.Cells[list.Count + 6, 1] = "норма выр./ч.";

                    report.Cells[list.Count + 7, 3].Formula = $"=K{list.Count + 5}/B{list.Count + 6}";
                    report.Cells[list.Count + 7, 2] = "численность";

                    report.Cells[list.Count + 8, 3].Formula = $"=(SUM(L{list.Count + 5}:L{list.Count + 6})/C{list.Count + 7})";
                    report.Cells[list.Count + 8, 2] = "ср. з/та";

                    report.Cells[list.Count + 9, 2].Formula = $"=B{list.Count + 5}";
                    report.Cells[list.Count + 9, 1] = "норма выр. %";

                    report.Cells[list.Count + 10, 2].Formula = $"=B{list.Count + 6}";
                    report.Cells[list.Count + 10, 1] = "факт. слож. норм. в";

                    report.Cells[list.Count + 11, 1] = "часы";




                    progressBar1.Visible = false;


              
            }
            #endregion
            #region Зарплата на единицу продукции
            if (radioButton2.Checked)
            {
                progressBar1.Maximum = detailsSorted.Count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                List<object[]> list = new List<object[]>();
                for (int i = 0; i < detailsSorted.Count; i++)
                {
                    progressBar1.Value = i;
                    if (detailsSorted[i].Check)
                        GenerateReport2(detailsSorted[i], 0, 1, list);
                }
                object[,] Table = new object[list.Count, 4];
                bool ContainsPodUzel = false;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                        Table[i, j] = list[i][j];
                    if (Table[i, 3] != null)
                        ContainsPodUzel = true;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i][4] as char? == 'b')
                    {
                        report.Cells[i + 4, 1].Font.Bold = true;
                        report.Cells[i + 4, 1].Font.Underline = true;
                    }
                }
                report.Range[report.Cells[4, 1], report.Cells[list.Count + 3, 4]].Value = Table;

                report.Columns[1].ColumnWidth = 45;
                report.Cells[1, 1] = "Трудоёмкость и заработная плата на изделие";
                if (Full.Checked)
                    report.Cells[1, 2] = "развёрнутый";
                report.Cells[2, 1] = "Тарифная ставка";
                report.Cells[2, 2] = "Дата: ";
                report.Cells[2, 3] = DateTime.Today.ToShortDateString();
                report.Cells[3, 1] = "Наименование продукции";

                report.Columns[2].ColumnWidth = 10;
                report.Columns[2].NumberFormat = "0,000000";
                report.Cells[3, 2] = "Трудоёмкость на единицу изделия, н/ч";

                report.Columns[3].ColumnWidth = 10;
                report.Columns[3].NumberFormat = "0,0000";
                report.Cells[3, 3] = "Заработная плата на единицу, руб";

                if (ContainsPodUzel)
                {
                    report.Columns[4].ColumnWidth = 4;
                    report.Cells[3, 4] = "Количество в узле";
                    report.Range[report.Cells[3, 1], report.Cells[3, 4]].Borders.weight = 2;
                }
                else
                    report.Range[report.Cells[3, 1], report.Cells[3, 3]].Borders.weight = 2;
                report.Range[report.Cells[3, 1], report.Cells[3, 4]].Font.Bold = true;
                report.Range[report.Cells[3, 1], report.Cells[3, 4]].WrapText = true;

                report.Cells[list.Count + 5, 1] = " Инженер по нормированию труда                    " + Properties.Settings.Default.Ingener;

                progressBar1.Visible = false;
            }
            #endregion
            #region Нормы на плановай выпуск
            if (radioButton3.Checked)
            {
                progressBar1.Maximum = detailsSorted.Count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                List<object[]> list = new List<object[]>();
                if (!Full.Checked | radioButton6.Checked)
                {
                    for (int i = 0; i < detailsSorted.Count; i++)
                    {
                        progressBar1.Value = i;
                        if (detailsSorted[i].Count > 0)
                            GenerateReport3(detailsSorted[i], 0, detailsSorted[i].Count, list);
                    }
                }
                if (Full.Checked & radioButton7.Checked)
                {
                    for (int i = 0; i < detailsSorted.Count; i++)
                    {
                        progressBar1.Value = i;
                        detailsSorted[i].CalcCheck = false;
                        detailsSorted[i].CalcCount = 0;
                    }
                    for (int i = 0; i < detailsSorted.Count; i++)
                    {
                        progressBar1.Value = i;
                        if (detailsSorted[i].Count > 0)
                            detailsSorted[i].CalcForReport(detailsSorted[i].Count);
                    }
                    for (int i = 0; i < detailsSorted.Count; i++)
                    {
                        progressBar1.Value = i;
                        if (detailsSorted[i].CalcCheck)
                        {
                            list.Add(new object[6]);
                            list[list.Count - 1][0] = detailsSorted[i].Name;
                            list[list.Count - 1][1] = detailsSorted[i].Norma;
                            list[list.Count - 1][2] = detailsSorted[i].CalcCount;
                            list[list.Count - 1][3] = detailsSorted[i].Norma * detailsSorted[i].CalcCount;
                            list[list.Count - 1][4] = detailsSorted[i].CalcCount;
                        }
                    }
                }
                object[,] Table = new object[list.Count, 5];
                bool ContainsPodUzel = false;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                        Table[i, j] = list[i][j];
                    if (Table[i, 4] != null)
                        ContainsPodUzel = true;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i][5] as char? == 'b')
                    {
                        report.Cells[i + 4, 1].Font.Bold = true;
                        report.Cells[i + 4, 1].Font.Underline = true;
                    }
                }
                report.Range[report.Cells[4, 1], report.Cells[list.Count + 3, 5]].Value = Table;

                if (!Full.Checked)
                    report.Cells[1, 1] = "Нормы на плановый выпуск";
                else
                    if (radioButton6.Checked)
                        report.Cells[1, 1] = "Нормы на плановый выпуск развёрнутый по составу сборки";
                    if (radioButton7.Checked)
                        report.Cells[1, 1] = "Нормы на плановый выпуск суммированый";

                report.Cells[2, 1] = "Дата: ";
                report.Cells[2, 2] = DateTime.Today.ToShortDateString();

                report.Columns[1].ColumnWidth = 45;
                report.Cells[3, 1] = "Наименование продукции";

                report.Columns[2].ColumnWidth = 10;
                report.Columns[2].NumberFormat = "0,000000";
                report.Cells[3, 2] = "Норма времени,час";

                report.Columns[3].ColumnWidth = 6;
                report.Cells[3, 3] = "Количество";

                report.Columns[4].ColumnWidth = 12;
                report.Columns[4].NumberFormat = "0,000000";
                report.Cells[3, 4] = "Время на выпуск, час";

                if (ContainsPodUzel)
                {
                    report.Columns[5].ColumnWidth = 10;
                    report.Cells[3, 5] = "Кол-во в узле";
                    report.Range[report.Cells[3, 1], report.Cells[3, 5]].Borders.weight = 2;
                }
                else
                    report.Range[report.Cells[3, 1], report.Cells[3, 4]].Borders.weight = 2;
                report.Range[report.Cells[3, 1], report.Cells[3, 5]].WrapText = true;
                report.Range[report.Cells[3, 1], report.Cells[3, 5]].Font.Bold = true;

                progressBar1.Visible = false;
            }
            #endregion
            #region Отчёт по подразделениям
            if (radioButton4.Checked)
            {
                progressBar1.Maximum = detailsSorted.Count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                List<object[]> list = new List<object[]>();
                object[] result = new object[DataSet.Цеха.Count + 4];
                result[0] = "Итого:";
                for (int i = 2; i < DataSet.Цеха.Count + 4; i++)
                    result[i] = 0.0;
                foreach (Detail detail in detailsSorted)
                {
                    progressBar1.Value++;
                    if (detail.Count > 0)
                    {
                        list.Add(new object[detail.Ceha.Count + 4]);
                        list[list.Count - 1][0] = detail.Name;
                        list[list.Count - 1][1] = detail.Count;
                        list[list.Count - 1][2] = detail.Norma;
                        result[2] = detail.Norma + (double)result[2];
                        list[list.Count - 1][3] = detail.Norma * detail.Count;
                        result[3] = detail.Norma * detail.Count + (double)result[3];
                        //list[list.Count - 1][3] = 0.0;
                        for (int i = 0; i < detail.Ceha.Count; i++)
                        {
                            if (detail.Ceha[i].Norma != 0)
                            {
                                list[list.Count - 1][i + 4] = detail.Ceha[i].Norma * detail.Count;
                                //list[list.Count - 1][1] = detail.Ceha[i].Norma + (double)list[list.Count - 1][1];
                                result[i + 4] = detail.Ceha[i].Norma * detail.Count + (double)result[i + 4];
                                //result[1] = detail.Ceha[i].Norma + (double)result[1];
                            }
                        }
                    }
                }
                object[,] Table = new object[list.Count + 1, DataSet.Цеха.Count + 4];
                for (int i = 0; i < list.Count; i++)
                    for (int j = 0; j < DataSet.Цеха.Count + 4; j++)
                        Table[i, j] = list[i][j];
                for (int j = 0; j < DataSet.Цеха.Count + 4; j++)
                    Table[list.Count, j] = result[j];
                report.Range[report.Cells[5, 1], report.Cells[list.Count + 5, DataSet.Цеха.Count + 4]].Value = Table;
                report.Range[report.Cells[3, 1], report.Cells[list.Count + 5, DataSet.Цеха.Count + 4]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                report.Cells[list.Count + 5, 1].Font.Underline = true;
;
                report.Cells[1, 1] = "Отчёт по подразделениям";
                report.Cells[2, 1] = "Дата: ";
                report.Cells[2, 2] = DateTime.Today.ToShortDateString();

                report.Columns[1].ColumnWidth = 45;
                report.Cells[3, 1] = "Наименование продукции";
                report.Columns[2].ColumnWidth = 5;
                report.Cells[3, 2] = "Количество";
                report.Columns[3].ColumnWidth = 10;
                report.Cells[3, 3] = "Трудоёмкость на ед., час";

                report.Cells[3, 4] = "Трудоёмкость на выпуск продукции, час";

                report.Columns[4].ColumnWidth = 10;
                report.Columns[4].NumberFormat = "0,000000";
                report.Cells[4, 4] = "Всего по обществу";
                for (int i = 0; i < DataSet.Цеха.Count; i++)
                {
                    report.Cells[4, i + 5] = DataSet.Цеха[i].Цех;
                    report.Columns[i + 5].ColumnWidth = 10;
                    report.Columns[i + 5].NumberFormat = "0,000000";
                }

                report.Cells[list.Count + 5, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                report.Range[report.Cells[3, 1], report.Cells[4, DataSet.Цеха.Count + 4]].Font.Bold = true;
                report.Range[report.Cells[3, 1], report.Cells[4, DataSet.Цеха.Count + 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                report.Range[report.Cells[3, 1], report.Cells[4, DataSet.Цеха.Count + 4]].VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                report.Range[report.Cells[3, 1], report.Cells[4, DataSet.Цеха.Count + 4]].WrapText = true;
                report.Range[report.Cells[3, 1], report.Cells[4, 1]].Merge();
                report.Range[report.Cells[3, 2], report.Cells[4, 2]].Merge();
                report.Range[report.Cells[3, 3], report.Cells[4, 3]].Merge();         
                report.Range[report.Cells[3, 4], report.Cells[3, DataSet.Цеха.Count + 4]].Merge();

                progressBar1.Visible = false;
            }
            #endregion
            #region Неотмеченные операции
            if (radioButton5.Checked)
            {
                progressBar1.Maximum = detailsSorted.Count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                List<object[]> list = new List<object[]>();
                for (int i = 0; i < detailsSorted.Count; i++)
                {
                    if (DataSet.Операции.Select("[ID Продукции] = " + detailsSorted[i].ID + " AND [Отметка] = false").Length > 0)
                    {
                        progressBar1.Value = i;
                        list.Add(new object[]{ detailsSorted[i].ID, 
                                               detailsSorted[i].Name, null, null, null });
                        //list[list.Count - 1][0] = detailsSorted[i].Name;
                        foreach (Detail.Ceh ceh in detailsSorted[i].Ceha)
                        {
                            foreach (Operation operation in ceh.operations)
                                if (!operation.Check)
                                {

                                    list.Add(new object[] { null, null,
                                                        operation.Number, 
                                                        operation.Name,
                                                        ceh.Name });
                                }
                        }
                        list.Add(new object[5]);
                    }
                }
                object[,] Table = new object[list.Count, 5];
                for (int i = 0; i < list.Count; i++)
                    for (int j = 0; j < 5; j++)
                        Table[i, j] = list[i][j];
                report.Range[report.Cells[2, 1], report.Cells[list.Count + 1, 5]].Value = Table;
                report.Range[report.Cells[2, 2], report.Cells[list.Count + 1, 2]].Font.Bold = true;

                report.Columns[1].ColumnWidth = 5;
                report.Cells[1, 1] = "ID Продукции";

                report.Columns[2].ColumnWidth = 5;
                report.Cells[1, 2] = "Наименование продукции";

                report.Columns[3].ColumnWidth = 3;
                report.Cells[1, 3] = "№ Операции";

                report.Columns[4].ColumnWidth = 30;
                report.Cells[1, 4] = "Вид операции";

                report.Columns[5].ColumnWidth = 10;
                report.Cells[1, 5] = "Цех";

                report.Range[report.Cells[1, 1], report.Cells[1, 5]].Borders.weight = 3;
                report.Range[report.Cells[1, 1], report.Cells[1, 5]].VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                report.Range[report.Cells[1, 1], report.Cells[1, 5]].Font.Bold = true;
                report.Range[report.Cells[1, 1], report.Cells[1, 5]].WrapText = true;

                progressBar1.Visible = false;
            }
            #endregion
            ExcelFile.Visible = true;
        }

        private void FindBox_TextChanged(object sender, EventArgs e)
        {
            if (FindBox.Text != "")
                bindingSource1.Filter = "[Наименование детали] LIKE '" + FindBox.Text + "%'";
            else
                bindingSource1.RemoveFilter();
        }

        private void ShowCalc()
        {
            if (dataGridView1.CurrentCellAddress.X == 2 & dataGridView1.CurrentCellAddress.Y >= 0 & dataGridView1.Focused)
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCellAddress.X, dataGridView1.CurrentCellAddress.Y, false);
                rect = dataGridView1.RectangleToScreen(rect);
                (new Calculator(dataGridView1.CurrentCell, rect)).Show();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //ShowCalc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowCalc();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Full.Enabled = !(radioButton4.Checked | radioButton5.Checked);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Full.Enabled = !(radioButton4.Checked | radioButton5.Checked);
        }

        private void FindBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == '\t')
            {
                dataGridView1.Focus();
            }*/
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' & dataGridView1.CurrentCellAddress.X == 2)
            {
                e.Handled = true;
                ShowCalc();
            }
            /*if (e.KeyChar == '\t')
                FindBox.Focus();*/
        }

        private void FindBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                dataGridView1.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                FindBox.Focus();
        }

        private void textBox1_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Vid_Full_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.продукцияTableAdapter.Update(this.vypuskDataSet.Продукция);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
