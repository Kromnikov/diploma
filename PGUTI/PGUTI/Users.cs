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
    public partial class Users : Form
    {
        private static DataSet ds;
        public Users()
        {
            InitializeComponent();
            loadGrid();
        }

        private void loadGrid()
        {
            ds = Data.Users1.getUsersTable();
            dataGridView1.DataSource = ds;//Заполняем таблицу
            dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            //UsersdataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
