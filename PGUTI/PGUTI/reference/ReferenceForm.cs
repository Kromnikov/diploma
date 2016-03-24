using PGUTI.reference;
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
    public partial class ReferenceForm : Form
    {
        private static DataSet ds = null;

        public ReferenceForm()
        {
            InitializeComponent();
        }

        private void Reference_Load(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void updateGrid()
        {
            unBlockMenu();
            GridView1.Visible = true;
            if (facultiesToolStripMenuItem.Checked)
            {
                ds = Data.Reference.getFaculties();
            }

            if (chairsToolStripMenuItem.Checked)
            {
                ds = Data.Reference.getCairs();
            }

            if (postToolStripMenuItem.Checked)
            {
                ds = Data.Reference.getWorkingPositions();
            }

            if (degreeToolStripMenuItem.Checked)
            {
                ds = Data.Reference.getDegrees();
            }

            if (titleToolStripMenuItem.Checked)
            {
                ds = Data.Reference.getTitles();
            }



            GridView1.DataSource = ds;//Заполняем таблицу
            GridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            GridView1.Columns["id"].Visible = false;//Скрываем поле id
            GridView1.CurrentCell = GridView1.Rows[0].Cells[1];
            SortingMode();//Запрещаем сортировку по столбцу
        }
        private void SortingMode()
        {
            foreach (DataGridViewColumn column in GridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;
            foreach (var ltoolStripMenuItem in (from object
                                                    item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;

        }
        private void facultiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            updateGrid();
        }

        private void chairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            updateGrid();
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            updateGrid();
        }

        private void degreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            updateGrid();
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
            updateGrid();
        }

        private void dellButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + int.Parse(GridView1.CurrentRow.Cells[0].Value.ToString()));
            //GridView1.BeginEdit(true); 

            StringBuilder sb = new StringBuilder();

            sb.Append(GridView1.CurrentRow.Cells[0].Value.ToString());

            for (int i = 1; i < GridView1.CurrentRow.Cells.Count; i++)
            {
                sb.Append(", ");
                sb.Append(GridView1.CurrentRow.Cells[i].Value.ToString());
            }
            if (MessageBox.Show(sb.ToString(), "Удалить?", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                int id = int.Parse(GridView1.CurrentRow.Cells[0].Value.ToString());
                if (facultiesToolStripMenuItem.Checked)
                {
                    Data.Reference.dellFaculties(id);
                }
                else

                    if (chairsToolStripMenuItem.Checked)
                    {
                        Data.Reference.dellCairs(id);
                    }
                    else

                        if (postToolStripMenuItem.Checked)
                        {
                            Data.Reference.dellWorkingPositions(id);
                        }
                        else

                            if (degreeToolStripMenuItem.Checked)
                            {
                                Data.Reference.dellDegrees(id);
                            }
                            else

                                if (titleToolStripMenuItem.Checked)
                                {
                                    Data.Reference.dellTitles(id);
                                }
                updateGrid();
            }
        }

        private void blockMenu()
        {
            dellButton.Enabled = false;
            addButton.Enabled = false;
            editButton.Enabled = false;
        }
        private void unBlockMenu()
        {
            dellButton.Enabled = true;
            addButton.Enabled = true;
            editButton.Enabled = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();

            //sb.Append(GridView1.CurrentRow.Cells[0].Value.ToString());

            //for (int i = 1; i < GridView1.CurrentRow.Cells.Count; i++)
            //{
            //    sb.Append(",");
            //    sb.Append(GridView1.CurrentRow.Cells[i].Value.ToString());
            //}


            editForm();

           
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            blockMenu();
            saveButton.Text = "Добавить";
            textBox1.Text = "";
            textBox2.Text = "";
            if (facultiesToolStripMenuItem.Checked)
            {
                textBox1.Visible = true;
                label1.Visible = true;
                label1.Text = "Полное название";
                label2.Text = "Сокращённое название";
            }

            if (chairsToolStripMenuItem.Checked)
            {
                textBox1.Visible = true;
                label1.Visible = true;
                label1.Text = "Полное название";
                label2.Text = "Сокращённое название";
            }

            if (postToolStripMenuItem.Checked)
            {
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Text = "Должность";
            }

            if (degreeToolStripMenuItem.Checked)
            {
                textBox1.Visible = true;
                label1.Visible = true;
                label1.Text = "Полное название";
                label2.Text = "Сокращённое название";
            }

            if (titleToolStripMenuItem.Checked)
            {
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Text = "Звание";
            }

            //ds.Tables[0].Rows.Add();
            //GridView1.DataSource = ds;//Заполняем таблицу
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            editForm();
        }
        private void editForm()
        {
            //int id = 0;
            //if (GridView1.CurrentRow != null)
            //    if (int.TryParse(GridView1.CurrentRow.Cells[0].Value.ToString(), out id))
            //    {
            //        string tableName = ds.Tables[0].TableName;
            //        using (EditReferenceForm form = new EditReferenceForm(id, tableName))//using автоматически отчистить таблицу из памяти 
            //        {
            //            form.ShowDialog();
            //        }
            //        updateGrid();
            //    }
            if (GridView1.CurrentRow != null)
            {
                blockMenu();
                saveButton.Text = "Сохранить";
                GridView1.Visible = false;
                if (facultiesToolStripMenuItem.Checked)
                {
                    textBox1.Visible = true;
                    label1.Visible = true;
                    label1.Text = "Полное название";
                    label2.Text = "Сокращённое название";
                    textBox1.Text = GridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = GridView1.CurrentRow.Cells[2].Value.ToString();
                }

                if (chairsToolStripMenuItem.Checked)
                {
                    textBox1.Visible = true;
                    label1.Visible = true;
                    label1.Text = "Полное название";
                    label2.Text = "Сокращённое название";
                    textBox1.Text = GridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = GridView1.CurrentRow.Cells[2].Value.ToString();
                }

                if (postToolStripMenuItem.Checked)
                {
                    textBox1.Visible = false;
                    label1.Visible = false;
                    label2.Text = "Должность";
                    textBox2.Text = GridView1.CurrentRow.Cells[1].Value.ToString();
                }

                if (degreeToolStripMenuItem.Checked)
                {
                    textBox1.Visible = true;
                    label1.Visible = true;
                    label1.Text = "Полное название";
                    label2.Text = "Сокращённое название";
                    textBox1.Text = GridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = GridView1.CurrentRow.Cells[2].Value.ToString();
                }

                if (titleToolStripMenuItem.Checked)
                {
                    textBox1.Visible = false;
                    label1.Visible = false;
                    label2.Text = "Звание";
                    textBox2.Text = GridView1.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(GridView1.CurrentRow.Cells[0].Value.ToString());
            if (facultiesToolStripMenuItem.Checked)
            {
                if (saveButton.Text.Equals("Добавить"))
                {
                    Data.Reference.addFaculties(id, textBox1.Text, textBox2.Text);
                }
                else
                {
                    Data.Reference.editFaculties(id, textBox1.Text, textBox2.Text);
                }
            }else

            if (chairsToolStripMenuItem.Checked)
            {
                if (saveButton.Text.Equals("Добавить"))
                {
                    Data.Reference.addCair(id, textBox1.Text, textBox2.Text);
                }
                else
                {
                    Data.Reference.editCair(id, textBox1.Text, textBox2.Text);
                }
            }
            else

            if (postToolStripMenuItem.Checked)
            {
                if (saveButton.Text.Equals("Добавить"))
                {
                    Data.Reference.addWorkingPositions(id, textBox2.Text);
                }
                else
                {
                    Data.Reference.editWorkingPositions(id, textBox2.Text);
                }
            }
            else

            if (degreeToolStripMenuItem.Checked)
            {
                if (saveButton.Text.Equals("Добавить"))
                {
                    Data.Reference.addDegrees(id, textBox1.Text, textBox2.Text);
                }
                else
                {
                    Data.Reference.editDegrees(id, textBox1.Text, textBox2.Text);
                }
            }
            else

            if (titleToolStripMenuItem.Checked)
            {
                if (saveButton.Text.Equals("Добавить"))
                {
                    Data.Reference.addTitles(id, textBox2.Text);
                }
                else
                {
                    Data.Reference.editTitles(id,textBox2.Text);
                }
            }
            updateGrid();
        }

        private void canselButton_Click(object sender, EventArgs e)
        {
            updateGrid();
        }
    }
}
