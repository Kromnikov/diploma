using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PGUTI
{
    public partial class RecordStaff : Form
    {
        private static string tableName = "";
        public RecordStaff()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            DataSet ds = null;
            ds = Data.RecordTeachers.Show();
            tableName = "Учёт сотрудников";
            dataGridView1.DataSource = ds;//Заполняем таблицу
            dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            dataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить запись?", "удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//Подтверждение
            if (result == DialogResult.Yes)//Если подтвердили
            {
                Data.RecordTeachers.dell(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                init();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            edit();
        }


        private static int idRecord = 0;
        private void edit()
        {
            idRecord = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            try
            {
                bool dekan = false;
                //using для того чтобы объект формы сам уничтожился после закрытия
                //В конструкторе передаём true(bool переменная котороя означает кнопку редактирования) и строку запроса из базы (select * from faculty) 
                using (EditForm editform = new EditForm(true, Data.EditForm.getRecordTeachers(idRecord), dekan))
                {
                    editform.Closing += (sender_1, e_1) =>//Передаём объект события
                    {
                        Data.RecordTeachers.dell(idRecord);
                        init();
                    };
                    editform.ShowDialog();
                }
            }
            catch (Exception err) { MessageBox.Show("Выберите сотрудника", "Сотрудник не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export.print(dataGridView1, tableName);
        }
    }
}
