using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PGUTI.reports;
using System.Drawing.Printing;

namespace PGUTI
{
    public partial class ReportsForm : Form
    {
        private static DataSet ds = null;
        private static string tableName = "";//Название таблиц при выводе в Excel

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
        }
        private void initOrderByRate()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("", "Фамилия");
            dataGridView1.Columns.Add("", "Имя");
            dataGridView1.Columns.Add("", "Отчество");
            dataGridView1.Columns.Add("", "Должность");
            dataGridView1.Columns.Add("", "Кафедра");
            dataGridView1.Columns.Add("", "Ученое звание");
            dataGridView1.Columns.Add("", "Ученая степень");
            dataGridView1.Columns.Add("", "Ставка");
            dataGridView1.Columns.Add("", "Дата рождения");
            dataGridView1.Columns.Add("", StartMonthCalendar1.SelectionStart.Date.ToString("dd.MM.yyyy")+" / "+EndMonthCalendar2.SelectionStart.Date.ToString("dd.MM.yyyy"));
            sortingMode();
        }
        private void orderByRate(string num)
        {
            ds = null;//Создадим объект DataSet
            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            initOrderByRate();//Визуализация таблицы
            switch (num)//Выбор запроса
            {
                    //штат
                case "1.1.1":
                    ds = Data.BasicStructure.getProfessorsDoc(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "1.1.2":
                    ds = Data.BasicStructure.getProfessorsCand(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "1.1.3":
                    ds = Data.BasicStructure.getProfessors(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date);break;
                case "1.2.1":
                    ds = Data.BasicStructure.getDocentsCandAndOrDocent(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "1.2.2":
                    ds = Data.BasicStructure.getDocentsNull(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "1.3":
                    ds = Data.BasicStructure.getSenior(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "1.4":
                    ds = Data.BasicStructure.getAssist(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                //Внутр
                case "2.1.1":
                    ds = Data.InternalStructure.getProfessorsDoc(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "2.1.2":
                    ds = Data.InternalStructure.getProfessorsCand(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "2.1.3":
                    ds = Data.InternalStructure.getProfessors(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "2.2.1":
                    ds = Data.InternalStructure.getDocentsCandAndOrDocent(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "2.2.2":
                    ds = Data.InternalStructure.getDocentsNull(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "2.3":
                    ds = Data.InternalStructure.getSenior(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "2.4":
                    ds = Data.InternalStructure.getAssist(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                //Внешние
                case "3.1.1":
                    ds = Data.ExternalStructure.getProfessorsDoc(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "3.1.2":
                    ds = Data.ExternalStructure.getProfessorsCand(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "3.1.3":
                    ds = Data.ExternalStructure.getProfessors(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "3.2.1":
                    ds = Data.ExternalStructure.getDocentsCandAndOrDocent(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "3.2.2":
                    ds = Data.ExternalStructure.getDocentsNull(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "3.3":
                    ds = Data.ExternalStructure.getSenior(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
                case "3.4":
                    ds = Data.ExternalStructure.getAssist(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date); break;
            }//Получаем таблицу из базы
            if (ds.Tables[0].Rows.Count != 0)
            {
                double previusRate = (double)ds.Tables[0].Rows[0].ItemArray[7], nextRate = 0;//Начальное значение ставки и текущее
                int rownum = 0, countTitle = 0, sumcountTitle = 0, degree = 0, sumdegree = 0;//Номер строки,количество званий, их сумма, количество степеней, их сумма
                double rate = 0, sumrate = 0;//Ставка, сумма ставок
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    nextRate = (double)ds.Tables[0].Rows[i].ItemArray[7];//Присваеваем текущее значение ставки
                    if (previusRate == nextRate)//Сравниваем с предедущим
                    {//и если они совпадают по заполняем дальше таблицу
                        dataGridView1.Rows.Add();//Добавляем строку
                        for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)//Запослняем колонки в строке
                        {
                            dataGridView1[j, i + rownum].Value = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        }
                        rate += double.Parse(dataGridView1[7, i + rownum].Value.ToString());//Получаем ставку
                        sumrate += rate;//Суммируем ставку
                        if (dataGridView1[5, i + rownum].Value != "")
                        {
                            degree++; sumdegree++;//Суммируем степень и сумму степеней
                        }
                        if (dataGridView1[6, i + rownum].Value != "")
                        {
                            countTitle++; sumcountTitle++;//Суммируем звание и сумму званий
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Add();
                        rownum++;
                        //Заполняем суммы
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = "Всего";
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = degree;
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = countTitle;
                        dataGridView1[7, dataGridView1.Rows.Count - 1].Value = rate;
                        degree = 0;//анулируем степень
                        countTitle = 0;//Звание
                        rate = 0;//и ставку
                        previusRate = nextRate;//меняем предыдущую на текущую ставки
                        i--;
                    }
                }
                //Заполняем предпоследнюю строку , т.к. вышли из цыкла , а заполнить её тоже нужно
                dataGridView1.Rows.Add();
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = "Всего";
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = degree;
                dataGridView1[6, dataGridView1.Rows.Count - 1].Value = countTitle;
                dataGridView1[7, dataGridView1.Rows.Count - 1].Value = rate;
                //Заполняем последнюю строку
                dataGridView1.Rows.Add();
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = "Итого";
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = sumdegree;
                dataGridView1[6, dataGridView1.Rows.Count - 1].Value = sumcountTitle;
                dataGridView1[7, dataGridView1.Rows.Count - 1].Value = sumrate;
            }
        }//Дополнительные таблицы , сортировка по ставкам

        private void showDissertations()
        {
            ds = Data.Dissertation.Show(StartMonthCalendar1.SelectionStart.Date, EndMonthCalendar2.SelectionStart.Date);//В зависимости от названия кафедры, заполняем таблицу, CairsComboBox1.SelectedIndex + 1 получаем название кафедры по номеру +1 т.к. начинаеться с нуля а в базе с единицы
            dataGridView1.DataSource = ds;//Заполняем таблицу
            dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            dataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void showRecord()
        {
            ds = Data.Record.Show(StartMonthCalendar1.SelectionStart.Date,EndMonthCalendar2.SelectionStart.Date);//В зависимости от названия кафедры, заполняем таблицу, CairsComboBox1.SelectedIndex + 1 получаем название кафедры по номеру +1 т.к. начинаеться с нуля а в базе с единицы
            dataGridView1.DataSource = ds;//Заполняем таблицу
            dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            dataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        }

        private void initAge()
        {
            dataGridView1.DataSource = null;//Отчищаем данные и datagridview
            dataGridView1.Columns.Add("empty", "");

            dataGridView1.Columns.Add("Всего", "Возраст всего");
            dataGridView1.Columns.Add("", "Менее 25 (женщин)");
            dataGridView1.Columns.Add("", "25-29 (женщин)");
            dataGridView1.Columns.Add("", "30-34 (женщин)");
            dataGridView1.Columns.Add("", "35-39 (женщин)");
            dataGridView1.Columns.Add("", "40-44 (женщин)");
            dataGridView1.Columns.Add("", "45-49 (женщин)");
            dataGridView1.Columns.Add("", "50-54 (женщин)");
            dataGridView1.Columns.Add("", "55-59 (женщин)");
            dataGridView1.Columns.Add("", "60-64 (женщин)");
            dataGridView1.Columns.Add("", "65 и более (женщин)");

            dataGridView1.Rows.Add(7);

            dataGridView1[0, 0].Value = "Профессорско – преподавательский состав \n- всего";
            dataGridView1[0, 1].Value = "Деканы факультетов";
            dataGridView1[0, 2].Value = "Заведующие кафедрами";
            dataGridView1[0, 3].Value = "Профессора";
            dataGridView1[0, 4].Value = "Доценты";
            dataGridView1[0, 5].Value = "Старшие преподаватели";
            dataGridView1[0, 6].Value = "Преподаватели, ассистенты";

            sortingMode();
        }//Отрисовка таблицы
        private void ageData()
        {
            initAge();
            ds = Data.AgeStructure.getAge();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.AgeStructure.getAgeFemale();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 2; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value += "("+ds.Tables[0].Rows[i].ItemArray[j - 1].ToString()+")";
                }
            }
        }//Распределение по возрасту

        private void initExperience()
        {
            dataGridView1.DataSource = null;//Отчищаем данные и datagridview
            dataGridView1.Columns.Add("empty", "");

            dataGridView1.Columns.Add("Всего", "Численность работников,\n имеющих общий стаж работы, всего");//Численность работников,имеющих общий стаж работы, всего
            dataGridView1.Columns.Add("", "до 3");
            dataGridView1.Columns.Add("", "от 3 до 5");
            dataGridView1.Columns.Add("", "от 5 до 10");
            dataGridView1.Columns.Add("", "от 10 до 15");
            dataGridView1.Columns.Add("", "от 15 до 20");
            dataGridView1.Columns.Add("", "20 и более");
            dataGridView1.Columns.Add("", "имеют педагогический стаж работы,всего");
            dataGridView1.Columns.Add("", "до 3");
            dataGridView1.Columns.Add("", "от 3 до 5");
            dataGridView1.Columns.Add("", "от 5 до 10");
            dataGridView1.Columns.Add("", "от 10 до 15");
            dataGridView1.Columns.Add("", "от 15 до 20");
            dataGridView1.Columns.Add("", "20 и более");

            dataGridView1.Rows.Add(7);

            dataGridView1[0, 0].Value = "Профессорско – преподавательский состав\n - всего";
            dataGridView1[0, 1].Value = "Деканы факультетов";
            dataGridView1[0, 2].Value = "Заведующие кафедрами";
            dataGridView1[0, 3].Value = "Профессора";
            dataGridView1[0, 4].Value = "Доценты";
            dataGridView1[0, 5].Value = "Старшие преподаватели";
            dataGridView1[0, 6].Value = "Преподаватели, ассистенты";
            sortingMode();
        }//Отрисовка таблицы
        private void experienceData()
        {
            initExperience();
            ds = Data.ExperienceStructure.getTotalExperience();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count - 7; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.ExperienceStructure.getExperience();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = dataGridView1.Columns.Count - 7; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 8].ToString();
                }
            }
        }//Распределение по стажу

        private void initDegrees()
        {
            dataGridView1.DataSource = null;//Отчищаем данные и datagridview
            dataGridView1.Columns.Add("empty", "");

            dataGridView1.Columns.Add("Всего", "Всего");
            dataGridView1.Columns.Add("0,1", "0,1 ставки");
            dataGridView1.Columns.Add("0,2", "0,2 ставки");
            dataGridView1.Columns.Add("0,3", "0,3 ставки");
            dataGridView1.Columns.Add("0,4", "0,4 ставки");
            dataGridView1.Columns.Add("0,5", "0,5 ставки");
            dataGridView1.Columns.Add("0,6", "0,6 ставки");
            dataGridView1.Columns.Add("0,7", "0,7 ставки");
            dataGridView1.Columns.Add("0,8", "0,8 ставки");
            dataGridView1.Columns.Add("0,9", "0,9 ставки");
            dataGridView1.Columns.Add("1", "1 ставку");

            dataGridView1.Rows.Add(9);

            dataGridView1[0, 0].Value = "Численность работников \nпрофессорско-преподавательского состава – всего\n(без учета внешних и внутренних совместителей)";
            dataGridView1[0, 1].Value = "Из них: доктора наук";
            dataGridView1[0, 2].Value = "Кандидаты наук";

            dataGridView1[0, 3].Value = "Численность работников \nпрофессорско-преподавательского состава – всего\n(Внешние совместители)  ";
            dataGridView1[0, 4].Value = "Из них: доктора наук";
            dataGridView1[0, 5].Value = "Кандидаты наук";
            
            dataGridView1[0, 6].Value = "Численность работников \nпрофессорско-преподавательского состава – всего\n(Внутренние совместители) ";
            dataGridView1[0, 7].Value = "Из них: доктора наук";
            dataGridView1[0, 8].Value = "Кандидаты наук";
            sortingMode();
        }//Отрисовка таблицы
        private void degreesData()
        {
            initDegrees();
            ds = Data.DegreesStructure.getRate();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j-1].ToString();
                }
            }
        }//Распределение по званиям

        private void initBasic()
        {
            dataGridView1.DataSource = null;//Отчищаем данные и datagridview
            dataGridView1.Columns.Add("empty", "");
            dataGridView1.Columns.Add("Всего", "Всего");
            dataGridView1.Columns.Add("Ученые степени", "Ученые степени");
            dataGridView1.Columns.Add("Кандидаты наук", "Кандидата наук");
            dataGridView1.Columns.Add("Доктора наук", "Доктора наук");

            dataGridView1.Columns.Add("Ученые звания", "Ученые звания");
            dataGridView1.Columns.Add("Профессора", "Профессора");
            dataGridView1.Columns.Add("Доцента", "Доцента");

            dataGridView1.Columns.Add("Женщ", "Женщ.");
            dataGridView1.Columns.Add("повышение квалификации за предыдущий учебный год", "повышение квалификации за пред. год");


            dataGridView1.Columns.Add("0,1", "0,1 ставки");
            dataGridView1.Columns.Add("0,2", "0,2 ставки");
            dataGridView1.Columns.Add("0,3", "0,3 ставки");
            dataGridView1.Columns.Add("0,4", "0,4 ставки");
            dataGridView1.Columns.Add("0,5", "0,5 ставки");
            dataGridView1.Columns.Add("0,6", "0,6 ставки");
            dataGridView1.Columns.Add("0,7", "0,7 ставки");
            dataGridView1.Columns.Add("0,8", "0,8 ставки");
            dataGridView1.Columns.Add("0,9", "0,9 ставки");
            dataGridView1.Columns.Add("1", "1 ставку");

            dataGridView1.Rows.Add(7);

            dataGridView1[0, 0].Value = "Профессорско – преподавательский состав\n - всего";
            dataGridView1[0, 1].Value = "Деканы факультетов";
            dataGridView1[0, 2].Value = "Заведующие кафедрами";
            dataGridView1[0, 3].Value = "Профессора";
            dataGridView1[0, 4].Value = "Доценты";
            dataGridView1[0, 5].Value = "Старшие преподаватели";
            dataGridView1[0, 6].Value = "Преподаватели, ассистенты";

            sortingMode();
        }//Отрисовка таблицы
        private void basicData()
        {
            initBasic();//Рисуем табличку
            ds = Data.BasicStructure.getDegreesAndTitle();//Получаем объект DataSet для заполнения таблички

            for (int i = 0; i < 7; i++)//Заполняем первую часть таблички, заполняем каждую строку
            {
                for (int j = 1; j < 9; j++)//Заполняем каждый столбец в данной строчке
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();//ds.Tables[0].Rows[i].ItemArray[j-1] Достаём из объекта DataSet таблицу 0 , в ней строку i , а в этой строке стобец j-1 т.к. мы начинаем заполнение со второго столбца а нам нужен первый
                }
            }
            ds = Data.BasicStructure.getQualification();//Заполняем столбец с квалификациями
            for (int i = 0; i < 7; i++)
            {
                dataGridView1[9, i].Value = ds.Tables[0].Rows[i].ItemArray[0];//Начинаем от 9
            }
            ds = Data.BasicStructure.getRate();//Заполняем ставки
            for (int i = 0; i < 7; i++)
            {
                for (int j = 10; j < 20; j++)//Начинаем от 10
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 9].ToString();
                }
            }
        }//Штатные 
        private void internalData()
        {
            initBasic();
            ds = Data.InternalStructure.getDegreesAndTitle();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.InternalStructure.getQualification();
            for (int i = 0; i < 7; i++)
            {
                dataGridView1[9, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
            }
            ds = Data.InternalStructure.getRate();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 10; j < 20; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 9].ToString();
                }
            }
        }//Внутр. совместители
        private void externalData()
        {
            initBasic();
            ds = Data.ExternalStructure.getDegreesAndTitle();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.ExternalStructure.getQualification();
            for (int i = 0; i < 7; i++)
            {
                dataGridView1[9, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
            }
            ds = Data.ExternalStructure.getRate();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 10; j < 20; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 9].ToString();
                }
            }
        }//Внеш. совместители

        private void sortingMode()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void штатныйСотрудникToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Распределение численности основного персонала по уровню образования (без внешних совместителей)";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                basicData();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
                this.Close();
            }
        }

        private void штатныеСовместителиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Распределение численности внутренние совместителей по уровню образования ";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                internalData();
            }
            catch { this.Close(); }
        }

        private void сторонниевнешниеСовместителиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Распределение численности внешних совместителей по уровню образования";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                externalData();
            }
            catch { this.Close(); }
        }

        private void сведенияОбУченыхСтепеняхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Сведения об ученых степенях профессорско-преподавательского состава и научных работников";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                degreesData();
            }
            catch { this.Close(); }
        }

        private void распределениеПерсоналаПоСтажуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Распределение персонала по стажу работы (Основного персонала, Штатных совместителей, Внешних совместителей)";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                experienceData();
            }
            catch { this.Close(); }
        }

        private void распределениеПерсоналаПоПолуИВозрастуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Распределение персонала по полу и возрасту (Основного персонала, Штатных совместителей, Внешних совместителей)";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                ageData();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
        }

        private void профессораToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void численностьДокторовНаукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью доктора наук(Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.1.1");
            }
            catch { this.Close(); }
        }

        private void кандидатыНаукПрофессораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.1.2");
            }
            catch { this.Close(); }
        }

        private void профессорыToolStripMenuItem_Click(object sender, EventArgs e)//TODO Профессора
        {
            try
            {
                tableName = "Численность ППС на должности профессора(Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.1.3");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
        }

        private void кандидатыНаукИилиДоцентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.2.1");
            }
            catch { this.Close(); }
        }

        private void доцентыбезУченойСтепениИилиЗванияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС доцентов (без ученой степени и/или звания)(Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.2.2");
            }
            catch { this.Close(); }
        }

        private void старшиеПреподователиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС старших преподавателей (Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.3");
            }
            catch { this.Close(); }
        }

        private void преподавателиИАссистентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС преподавателей и ассистентов(Штатные сотрудники)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.4");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью доктора наук (Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.1.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.1.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС на должности профессора(Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.1.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.2.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС доцентов (без ученой степени и/или звания)(Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.2.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС старших преподавателей (Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС преподавателей и ассистентов(Внутренние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.4");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью доктора наук(Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.1.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.1.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС на должности профессора(Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.1.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.2.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС доцентов (без ученой степени и/или звания(Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.2.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС старших преподавателей (Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Численность ППС преподавателей и ассистентов(Внешние совместители)  с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.4");
            }
            catch { this.Close(); }
        }

        private void диссертацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Защита диссертаций с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                showDissertations();
            }
            catch { this.Close(); }
        }

        private void учетСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableName = "Учёт сотрудников с " + StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year + "   по  " + EndMonthCalendar2.SelectionStart.Date.Day + "-" + EndMonthCalendar2.SelectionStart.Date.Month + "-" + EndMonthCalendar2.SelectionStart.Date.Year;
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                showRecord();
            }
            catch { this.Close(); }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyDataGridView = dataGridView1; 
            //if (SetupThePrinting())
            //    printDocument1.Print();
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();//Создание объекта Excel
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;
            ExcelApp.Cells[1,1] = tableName;//Передаём имя таблицы
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

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
                MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, printDocument1, true, true, "Отчет", new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, printDocument1, false, true, "Отчет", new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateGroupBox1.Visible = false;//Скрываем выбор дат
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateGroupBox1.Visible = true;//Показываем выбор дат
        }        


    }
}
