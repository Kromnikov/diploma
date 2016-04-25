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
    public partial class EditUsers : Form
    {
        private static DataSet ds;
        private static bool insert;
        private static bool admin;

        public EditUsers()
        {
            InitializeComponent();
            UpdateTable();
        }
        private void UpdateTable()
        {
            ds = Data.Users1.getUsersTable();
            UsersdataGridView1.DataSource = ds;//Заполняем таблицу
            UsersdataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            //UsersdataGridView1.Columns["id"].Visible = false;//Скрываем поле id

            ds = Data.Users1.getAdminsTable();
            AdminsdataGridView2.DataSource = ds;
            AdminsdataGridView2.DataMember = ds.Tables[0].TableName;//Имя таблицы
            AdminsdataGridView2.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void cleanTextBox()
        {
            loginTextBox1.Text = "";
            passwordTextBox2.Text = "";
        }

        private void добавитьАдминистратораtoolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            admin = true;
            insert = true;
            editGroupBox1.Visible = true;
        }

        private void редактироватьАдминистратораtoolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            admin = true;
            insert = false;
            try
            {
                ds = Data.Users1.getAdminsLogAndPass(int.Parse(AdminsdataGridView2.CurrentRow.Cells[0].Value.ToString()));
                loginTextBox1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                passwordTextBox2.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            catch { MessageBox.Show("Выберите пользователя для редактирования"); return; }
            editGroupBox1.Visible = true;
        }

        private void удалитьАдминистратораtoolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить пользователя?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (Data.Users1.getIdAdmins() > 2)
                        Data.Users1.dellAdmins(int.Parse(AdminsdataGridView2.CurrentRow.Cells[0].Value.ToString()));
                    else
                    {
                        MessageBox.Show("Остался 1 администратор , его нельзя удалить!");
                    }
                else return;
            }
            catch { MessageBox.Show("Выберите пользователя для редактирования"); return; }
            UpdateTable();
        }

        private void добавитьПользователяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            admin = false;
            insert = true;
            editGroupBox1.Visible = true;
        }

        private void редактироватьПользователяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            admin = false;
            insert = false;
            try
            {
                ds = Data.Users1.getUsersLogAndPass(int.Parse(UsersdataGridView1.CurrentRow.Cells[0].Value.ToString()));
                loginTextBox1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                passwordTextBox2.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            catch { MessageBox.Show("Выберите пользователя для редактирования"); return; }
            editGroupBox1.Visible = true;
        }

        private void удалитьПользователяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить пользователя?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Data.Users1.dellUsers(int.Parse(UsersdataGridView1.CurrentRow.Cells[0].Value.ToString()));
                }
                else return;
            }
            catch { MessageBox.Show("Выберите пользователя для редактирования"); return; }
            UpdateTable();
        }

        private void CanselButton1_Click_1(object sender, EventArgs e)
        {

            editGroupBox1.Visible = false;
            cleanTextBox();
        }

        private void SaveButton1_Click_1(object sender, EventArgs e)
        {
            if (insert)
            {
                if (Data.Users1.extists(loginTextBox1.Text)) { MessageBox.Show("Логин уже существует"); return; }
                if (admin)
                {
                    Data.Users1.addAdmins(loginTextBox1.Text, passwordTextBox2.Text);
                }
                else
                {
                    Data.Users1.addUsers(loginTextBox1.Text, passwordTextBox2.Text);
                }
            }
            else
            {
                if (admin)
                {
                    Data.Users1.updateAdmins(int.Parse(AdminsdataGridView2.CurrentRow.Cells[0].Value.ToString()), loginTextBox1.Text, passwordTextBox2.Text);
                }
                else
                {
                    Data.Users1.updateUsers(int.Parse(UsersdataGridView1.CurrentRow.Cells[0].Value.ToString()), loginTextBox1.Text, passwordTextBox2.Text);
                }
            }
            UpdateTable();
            editGroupBox1.Visible = false;
            cleanTextBox();
        }

    }
}
