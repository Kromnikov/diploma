using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PGUTI.reference
{
    public partial class EditReferenceForm : Form
    {
        public EditReferenceForm()
        {
            InitializeComponent();
        }

        private string title;
        private int id;
        private DataSet ds;

        public EditReferenceForm(int id, string title)
        {
            InitializeComponent();
            this.title = title;
            this.id = id;
            //MessageBox.Show(title);
            if (title.Equals("Faculties"))
            {
                ds = Data.Reference.getFaculties(id);
            }
            else
                if (title.Equals("Cairs"))
                {
                    ds = Data.Reference.getCairs(id);
                }
                else
                    if (title.Equals("Degrees"))
                    {
                        ds = Data.Reference.getDegrees(id);
                    }
                    else
                        if (title.Equals("Titles"))
                        {
                            ds = Data.Reference.getTitles(id);
                        }
                        else
                            if (title.Equals("WorkingPositions"))
                            {
                                ds = Data.Reference.getWorkingPositions(id);
                            }
        }

        private void EditReferenceForm_Load(object sender, EventArgs e)
        {
            updateGrid();
            //string[] mass = line.Split(',');
            //int id = int.Parse(mass[0]);
            //for (int i = 0; i < mass.Length; i++)
            //{
            //    TextBox temp = new TextBox();
            //    temp.Text = mass[i];
            //    temp.Width = 90;
            //    temp.Location = new Point(10 + 100 * i, 20);
            //    this.Controls.Add(temp);
            //}
            //for (int i = 0; i < abc; i++)
            //{
            //    TextBox temp = new TextBox();
            //    temp.Text = "Пример"+i;
            //    temp.Width = 90;
            //    temp.Location = new Point(10 + 100*i, 20);
            //    this.Controls.Add(temp);
            //}
        }

        private void updateGrid()
        {
            dataGridView1.DataSource = ds;//Заполняем таблицу
            dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            dataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            //for (int i = 1; i < dataGridView1.Rows[0].Cells.Count; i++)
            //{
            //    dataGridView1.CurrentCell = dataGridView1.Rows[1].Cells[i];
            //    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[i];
            //}
            //if (title.Equals("Faculties"))
            //{
            //    ds = Data.Reference.editFaculties(id, dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString());
            //}
            //else
            //    if (title.Equals("Cairs"))
            //    {
            //        ds = Data.Reference.editCair(id, dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString());
            //    }
            //    else
            //        if (title.Equals("Degrees"))
            //        {
            //            ds = Data.Reference.editDegrees(id, dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString());
            //        }
            //        else
            //            if (title.Equals("Titles"))
            //            {
            //                ds = Data.Reference.editTitles(id, dataGridView1.CurrentRow.Cells[1].Value.ToString());
            //            }
            //            else
            //                if (title.Equals("WorkingPositions"))
            //                {
            //                    ds = Data.Reference.editWorkingPositions(id, dataGridView1.CurrentRow.Cells[1].Value.ToString());
            //                }
            this.Close();
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
