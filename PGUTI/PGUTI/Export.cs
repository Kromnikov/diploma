using System;
using System.Collections.Generic;
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
            for (int i = 1; i < dataGridView1.Columns.Count; i++)//Заполняем названия столбцов
            {
                ExcelApp.Cells[2, i] = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)//Заполняем таблицу
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    try
                    {
                        ExcelApp.Cells[j + 3, i] = (dataGridView1[i, j].Value).ToString();
                    }
                    catch { }
                }
            }
            ExcelApp.Visible = true;//Открываем Excel
        }
    }
}
