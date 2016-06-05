using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PGUTI
{
    class Export
    {
        public static void print(DataGridView dataGridView1,string tableName)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();//Создание объекта Excel
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;
            ExcelApp.Cells[1, 1] = tableName;//Передаём имя таблицы
            ExcelApp.Cells[1, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)//Заполняем названия столбцов
            {
                ExcelApp.Cells[2, i] = dataGridView1.Columns[i].HeaderText;
                ExcelApp.Cells[2, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)//Заполняем таблицу
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    try
                    {
                        ExcelApp.Cells[j + 3, i] = (dataGridView1[i, j].Value).ToString();
                        ExcelApp.Cells[j + 3, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    }
                    catch { }
                }
            }
            ExcelApp.Visible = true;//Открываем Excel
        }

        public static void print(Dictionary<string, DataSet> listDataGrid, string title)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();//Создание объекта Excel
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;
            ExcelApp.Cells[1, 4] = title;//Передаём имя таблицы
            ExcelApp.Cells[1, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //ExcelApp.Cells[1, 4].Interior.Color = 36;

            int rowNumber = 0;
            DataSet dataset=null;
            for (int numEl = 0; numEl < listDataGrid.Count; numEl++)
            {
                dataset = listDataGrid.Values.ElementAt(numEl);
                ExcelApp.Cells[2 + rowNumber, 4] = listDataGrid.Keys.ElementAt(numEl);//Передаём имя таблицы
                ExcelApp.Cells[2 + rowNumber, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                for (int i = 1; i < dataset.Tables[0].Columns.Count; i++)//Заполняем названия столбцов
                {
                    ExcelApp.Cells[3 + rowNumber, i] = dataset.Tables[0].Columns[i].ColumnName;
                    ExcelApp.Cells[3 + rowNumber, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                }

                for (int i = 1; i < dataset.Tables[0].Columns.Count; i++)//Заполняем таблицу
                {
                    for (int j = 0; j < dataset.Tables[0].Rows.Count; j++)
                    {
                        ExcelApp.Cells[j + 4 + rowNumber, i] = (dataset.Tables[0].Rows[j].ItemArray[i]).ToString();
                        ExcelApp.Cells[j + 4 + rowNumber, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    }
                }
                rowNumber += 2 + dataset.Tables[0].Columns.Count;
            }
            //for (int i = 1; i < rowNumber-1; i++)
            //{
            //    for (int j = 0; j < dataset.Tables[0].Columns.Count; j++)
            //    {
            //        ExcelApp.Cells[i,j].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //    }
            //}
            ExcelApp.Visible = true;//Открываем Excel
        }
    }
}
