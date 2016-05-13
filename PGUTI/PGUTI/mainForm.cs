using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Excel;

namespace PGUTI
{
    public partial class mainForm : Form
    {
        private static string tableName = "";

        public mainForm()
        {
            InitializeComponent();
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            UpdateFacultyGridView();//Загружаем таблицу Faculty
        }

        public void UpdateFacultyGridView()//Метод зугрузки главной таблицы
        {
            DataSet ds = null;
            if (PPCaToolStripMenuItem.Checked)//Если выбран первый radiobutton тогда загружаем профессорско-преподовательский состав
            {
                //FacultyGridView1.DataSource = null;
                ds = Data.Teachers.getTeachers();//Получаем всю таблицу
                tableName = "«Руководящий состав»";
            }
            else if (DekansbToolStripMenuItem.Checked)//Если второй , то загружаем таблицу деканов
            {
                ds = Data.Teachers.getTeachersDekans();
                tableName = "«Деканы факультетов» ";
            }
            else if (ChairsToolStripMenuItem.Checked)//Если третий , то загружаем таблицу каферд
            {
                ds = Data.Teachers.getCair((CairsComboBox1.SelectedIndex + 1));//В зависимости от названия кафедры, заполняем таблицу, CairsComboBox1.SelectedIndex + 1 получаем название кафедры по номеру +1 т.к. начинаеться с нуля а в базе с единицы
                tableName = "«" + (CairsComboBox1.Text) + "»";
            }
            FacultyGridView1.DataSource = ds;//Заполняем таблицу
            FacultyGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            FacultyGridView1.Columns["id"].Visible = false;//Скрываем поле id

            //for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            //{
            //    FacultyGridView1.Columns.Add("",ds.Tables[0].Columns[i].ColumnName.ToString());
            //}
            //FacultyGridView1.Columns[0].Visible = false;
            //for (int i = 0; i <ds.Tables[0].Rows.Count; i++)
            //{
            //    FacultyGridView1.Rows.Add();
            //    for (int j = 1; j < ds.Tables[0].Columns.Count; j++)
            //    {
            //        FacultyGridView1[j,i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
            //    }
            //}
            SortingMode();//Запрещаем сортировку по столбцу
        }

        private void SortingMode()
        {
            foreach (DataGridViewColumn column in FacultyGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using для того чтобы объект формы сам уничтожился после закрытия
            using (EditForm addform = new EditForm(false))
            {
                addform.Closing += (sender_1, e_1) =>
                {
                    UpdateFacultyGridView();//обнавляем после закрытия
                };
                addform.ShowDialog();
            }
        }

        private void CairsDataSource()
        {
            CairsComboBox1.DataSource = Data.Teachers.getSecondNameCairs().Tables[0];//Выбираем таблицу под номером 0
            CairsComboBox1.DisplayMember = "second_name";//
            CairsComboBox1.Visible = true;
        }

        private void CairsComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFacultyGridView();
        }
        //Print
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bmp = new Bitmap(FacultyGridView1.Size.Width + 10, FacultyGridView1.Size.Height + 10);
            //FacultyGridView1.DrawToBitmap(bmp, FacultyGridView1.Bounds);
            //e.Graphics.DrawImage(bmp, 0, 0);
             bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
        if (more == true)
        e.HasMorePages = true;
        }//Print

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();

            ////PrintPreviewDialog dlg = new PrintPreviewDialog();
            ////dlg.Document = printDocument1;
            ////dlg.ShowDialog();


            //MyDataGridView = FacultyGridView1; // d-мой датагрид, который на форме
            //if (SetupThePrinting())
            //    printDocument1.Print();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();//Создание объекта Excel
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;
            ExcelApp.Cells[1, 1] = tableName;//Передаём имя таблицы
            for (int i = 1; i < FacultyGridView1.Columns.Count; i++)//Заполняем названия столбцов
            {
                ExcelApp.Cells[2, i] = FacultyGridView1.Columns[i].HeaderText;
            }

            for (int i = 1; i < FacultyGridView1.ColumnCount; i++)//Заполняем таблицу
            {
                for (int j = 0; j < FacultyGridView1.RowCount; j++)
                {
                    ExcelApp.Cells[j + 3, i] = (FacultyGridView1[i, j].Value).ToString();
                }
            }
            ExcelApp.Visible = true;
        }//Print
         DataGridView MyDataGridView = new DataGridView();
        DataGridViewPrinter MyDataGridViewPrinter;
        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;
            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;
            printDocument1.DocumentName = "Customers Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, printDocument1, true, true, "Отчет", new System.Drawing.Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, printDocument1, false, true, "Отчет", new System.Drawing.Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
            return true;
        }        //Print
        //Print end
        private void таблицыОтчётаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Форма отчётов
            using (ReportsForm form = new ReportsForm())//using автоматически отчистить таблицу из памяти 
            {
                form.ShowDialog();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool dekan = false;
                if (DekansbToolStripMenuItem.Checked) dekan = true;//Если выбран декан , то будем менять декана
                //using для того чтобы объект формы сам уничтожился после закрытия
                //В конструкторе передаём true(bool переменная котороя означает кнопку редактирования) и строку запроса из базы (select * from faculty) 
                using (EditForm editform = new EditForm(true, Data.EditForm.getTeachers(int.Parse(FacultyGridView1.CurrentRow.Cells[0].Value.ToString())), dekan))
                {
                    editform.Closing += (sender_1, e_1) =>//Передаём объект события
                    {
                        UpdateFacultyGridView();//обнавляем после закрытия
                    };
                    editform.ShowDialog();
                }
            }
            catch (Exception err) { MessageBox.Show("Выберите сотрудника", "Сотрудник не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        //private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int id = int.Parse(FacultyGridView1.CurrentRow.Cells[0].Value.ToString());//Номер сотрудника в базе
        //        DialogResult result = MessageBox.Show("Удалить запись?", "удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//Подтверждение
        //        if (result == DialogResult.Yes)//Если подтвердили
        //        {
        //            Data.Record.Add(id, true);//Добавляем запись в таблицу Records
        //            Data.Teachers.dellRow(id);//Выбираем из выбранной строки первый столбец и передаём его значение в метод удаления записи
        //            UpdateFacultyGridView();
        //        }
        //    }
        //    catch (Exception err) { MessageBox.Show("Выберите сотрудника", "Сотрудник не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        //}

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PPCaToolStripMenuItem.Checked = true;
            DekansbToolStripMenuItem.Checked = false;
            ChairsToolStripMenuItem.Checked = false;
            CairsComboBox1.Visible = false;
            UpdateFacultyGridView();//Обновляем таблицу
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DekansbToolStripMenuItem.Checked = true;
            ChairsToolStripMenuItem.Checked = false;
            PPCaToolStripMenuItem.Checked = false;
            CairsComboBox1.Visible = false;
            UpdateFacultyGridView();//Обновляем таблицу
        }

        private void кафедрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DekansbToolStripMenuItem.Checked = false;
            ChairsToolStripMenuItem.Checked = true;
            PPCaToolStripMenuItem.Checked = false;
            CairsComboBox1.Visible = true ;
            CairsDataSource();//Получаем список кафедр
            UpdateFacultyGridView();//Обновляем таблицу
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReferenceForm form = new ReferenceForm())//using автоматически отчистить таблицу из памяти 
            {
                form.ShowDialog();
            }
        }

        private void FacultyGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FacultyGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool dekan = false;
                if (DekansbToolStripMenuItem.Checked) dekan = true;//Если выбран декан , то будем менять декана
                //using для того чтобы объект формы сам уничтожился после закрытия
                //В конструкторе передаём true(bool переменная котороя означает кнопку редактирования) и строку запроса из базы (select * from faculty) 
                using (EditForm editform = new EditForm(true, Data.EditForm.getTeachers(int.Parse(FacultyGridView1.CurrentRow.Cells[0].Value.ToString())), dekan))
                {
                    editform.Closing += (sender_1, e_1) =>//Передаём объект события
                    {
                        UpdateFacultyGridView();//обнавляем после закрытия
                    };
                    editform.ShowDialog();
                }
            }
            catch (Exception err) { MessageBox.Show("Выберите сотрудника", "Сотрудник не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }





        //private bool isUser()
        //{
        //    return (Data.Users.hasUser(loginTextBox1.Text, passwordTextBox2.Text));
        //}
        //private bool isAdmin()
        //{
        //    if (Data.Users.hasAdmin(loginTextBox1.Text, passwordTextBox2.Text))
        //    {
        //        редактироватьПользователейToolStripMenuItem.Visible = true;
        //        return true;
        //    }
        //    else return false;

        //}

        private void редактироватьПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Users form = new Users())
            {
                form.ShowDialog();
            }
        }

        private void cleanTextBox()
        {
            loginTextBox1.Text = "";
            passwordTextBox2.Text = "";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanTextBox();
            enterGroupBox1.Visible = true;
            редактироватьПользователейToolStripMenuItem.Visible = false;
        }
        
        


        private void enterButton1_Click(object sender, EventArgs e)
        {
            auth();
        }

        private void passwordTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //passwordTextBox2.KeyUp += new KeyEventHandler(tb_KeyDown);
        }

        private void loginTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //loginTextBox1.KeyUp += new KeyEventHandler(tb_KeyDown);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, true, true);
                auth();
            }
        }
        private void auth()
        {
            string role = Data.Users.role(loginTextBox1.Text, passwordTextBox2.Text);
            if (role.Equals("USER"))
            {
                enterGroupBox1.Visible = false;
            }
            else
            {
                if (role.Equals("ADMIN"))
                {
                    enterGroupBox1.Visible = false;
                    редактироватьПользователейToolStripMenuItem.Visible = true;
                }
                else MessageBox.Show("Неверный логин/пароль");
            }
        }

        private void loginTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, true, true);
                auth();
            }
            else
            { }
        }

        private void passwordTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, true, true);
                auth();
            }
            else
            { }
        }

    }
}
