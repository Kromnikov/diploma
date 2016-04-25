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
            ds = Data.Users.users();
            dataGridView1.DataSource = ds;//Заполняем таблицу
            dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            //UsersdataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dell();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            edit();
        }
        private void dell()
        {
            DialogResult result = MessageBox.Show("Удалить запись?", "удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//Подтверждение
            if (result == DialogResult.Yes)//Если подтвердили
            {
                Data.Users.dell(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                loadGrid();
            }

        }

        private void edit()
        {
            try
            {
                addButton.Visible =false ;
                saveButton.Visible = true;
                loginTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                passwordTextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                roleComboBox.SelectedIndex = roleComboBox.FindStringExact(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                enterGroupBox1.Visible = true;
            }
            catch (Exception err) { MessageBox.Show("Выберите сотрудника", "Сотрудник не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void add()
        {
            addButton.Visible = true;
            saveButton.Visible = false;
            loginTextBox1.Clear();
            passwordTextBox2.Clear();
            roleComboBox.SelectedIndex = roleComboBox.FindStringExact(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            enterGroupBox1.Visible = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            loadGrid();
            enterGroupBox1.Visible = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                Data.Users.update(dataGridView1.CurrentRow.Cells[0].Value.ToString(), loginTextBox1.Text, passwordTextBox2.Text, roleComboBox.SelectedItem.ToString());
                loadGrid();
                enterGroupBox1.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Data.Users.insert(loginTextBox1.Text, passwordTextBox2.Text, roleComboBox.SelectedItem.ToString()))
                {
                    loadGrid();
                    enterGroupBox1.Visible = false;
                }
                else
                {
                    MessageBox.Show("Такое имя пользователя уже существует");
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
