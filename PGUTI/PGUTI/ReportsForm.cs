﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace PGUTI
{
    public partial class ReportsForm : Form
    {
        private static DataSet ds = null;
        private static string dsNum="0";
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
            //dataset.Tables.Add(new DataTable());//
            //dataset.Tables[0].Columns.Add("Фамилия");
            //dataset.Tables[0].Columns.Add( "Имя");
            //dataset.Tables[0].Columns.Add( "Отчество");
            //dataset.Tables[0].Columns.Add( "Должность");
            //dataset.Tables[0].Columns.Add( "Кафедра");
            //dataset.Tables[0].Columns.Add( "Ученое звание");
            //dataset.Tables[0].Columns.Add( "Ученая степень");
            //dataset.Tables[0].Columns.Add( "Ставка");
            //dataset.Tables[0].Columns.Add( "Дата рождения");
            //dataset.Tables[0].Columns.Add( StartMonthCalendar1.SelectionStart.Date.ToString("dd.MM.yyyy"));

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
            dataGridView1.Columns.Add("", StartMonthCalendar1.SelectionStart.Date.ToString("dd.MM.yyyy"));
            sortingMode();
        }



        private void orderByRate(string num)
        {
            ds = null;//Создадим объект DataSet
            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            
            dsNum = num;
            switch (num)//Выбор запроса
            {
                case "0.0.1":
                    basicData();
                    return;
                case "0.0.2":
                    internalData();
                    return;
                case "0.0.3":
                    externalData();
                    return;
                case "0.1.0":
                    degreesData();
                    return;
                case "0.1.1":
                    experienceData();
                    return;
                case "0.1.2":
                    ageData();
                    return;
                case "0.2.0":
                    showDissertations();
                    return;
                //case "0.2.1":
                //    showRecord();
                //    return;
                case "0.2.2":
                    training();
                    return;
                case "0.2.3":
                    ageChair();
                    return;


                    //штат
                case "1.1.1":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getProfessorsDoc(StartMonthCalendar1.SelectionStart.Date);
                    //dataset = ds.Copy();
                    //MessageBox.Show(ds.Tables[0].Columns.Count.ToString());
                    break;
                case "1.1.2":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getProfessorsCand(StartMonthCalendar1.SelectionStart.Date); break;
                case "1.1.3":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getProfessors(StartMonthCalendar1.SelectionStart.Date);break;
                case "1.2.1":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getDocentsCandAndOrDocent(StartMonthCalendar1.SelectionStart.Date); break;
                case "1.2.2":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getDocentsNull(StartMonthCalendar1.SelectionStart.Date); break;
                case "1.3":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getSenior(StartMonthCalendar1.SelectionStart.Date); break;
                case "1.4":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.BasicStructure.getAssist(StartMonthCalendar1.SelectionStart.Date); break;
                //Внутр
                case "2.1.1":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getProfessorsDoc(StartMonthCalendar1.SelectionStart.Date); break;
                case "2.1.2":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getProfessorsCand(StartMonthCalendar1.SelectionStart.Date); break;
                case "2.1.3":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getProfessors(StartMonthCalendar1.SelectionStart.Date); break;
                case "2.2.1":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getDocentsCandAndOrDocent(StartMonthCalendar1.SelectionStart.Date); break;
                case "2.2.2":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getDocentsNull(StartMonthCalendar1.SelectionStart.Date); break;
                case "2.3":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getSenior(StartMonthCalendar1.SelectionStart.Date); break;
                case "2.4":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.InternalStructure.getAssist(StartMonthCalendar1.SelectionStart.Date); break;
                //Внешние
                case "3.1.1":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getProfessorsDoc(StartMonthCalendar1.SelectionStart.Date); break;
                case "3.1.2":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getProfessorsCand(StartMonthCalendar1.SelectionStart.Date); break;
                case "3.1.3":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getProfessors(StartMonthCalendar1.SelectionStart.Date); break;
                case "3.2.1":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getDocentsCandAndOrDocent(StartMonthCalendar1.SelectionStart.Date); break;
                case "3.2.2":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getDocentsNull(StartMonthCalendar1.SelectionStart.Date); break;
                case "3.3":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getSenior(StartMonthCalendar1.SelectionStart.Date); break;
                case "3.4":
                    //initOrderByRate();//Визуализация таблицы
                    ds = Data.ExternalStructure.getAssist(StartMonthCalendar1.SelectionStart.Date); break;
            }//Получаем таблицу из базы
            additionalCopy();
        }//Дополнительные таблицы , сортировка по ставкам
        
        private void setTableName(string num)
        {
            ds = null;//Создадим объект DataSet
            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)

            dsNum = num;
            switch (num)//Выбор запроса
            {
                case "0.0.1":
                    tableName = "Распределение численности основного персонала по уровню образования (без внешних совместителей): " + getDateString();
                    return;
                case "0.0.2":
                    tableName = "Распределение численности внутренние совместителей по уровню образования: " + getDateString();
                    return;
                case "0.0.3":
                    tableName = "Распределение численности внешних совместителей по уровню образования: " + getDateString();
                    return;
                case "0.1.0":
                    tableName = "Сведения об ученых степенях профессорско-преподавательского состава и научных работников с " + getDateStringDiss() + " по " + getDateString();
                    return;
                case "0.1.1":
                    tableName = "Распределение персонала по стажу работы (Основного персонала, Штатных совместителей, Внешних совместителей): " + getDateString();
                    return;
                case "0.1.2":
                    tableName = "Распределение персонала по полу и возрасту (Основного персонала, Штатных совместителей, Внешних совместителей): " + getDateString();
                    return;
                case "0.2.0":
                    tableName = "Защита диссертаций c " + getDateStringDiss() + " по " + getDateString();
                    return;
                case "0.2.1":
                    tableName = "Учёт сотрудников: " + getDateString();
                    return;
                case "0.2.2":
                    tableName = "Повышение квалификации с " + getDateStringDiss() + " по " + getDateString();
                    return;
                case "0.2.3":
                    tableName = "Распределение по возрасту: "+ getDateString();
                    return;


                //штат
                case "1.1.1":
                    tableName = "Численность ППС с ученой степенью доктора наук(Штатные сотрудники): " + getDateString();
                    break;
                case "1.1.2":
                    tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Штатные сотрудники): " + getDateString();
                    break;
                case "1.1.3":
                    tableName = "Численность ППС на должности профессора(Штатные сотрудники): " + getDateString();
                    break;
                case "1.2.1":
                    tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Штатные сотрудники): " + getDateString();
                    break;
                case "1.2.2":
                    tableName = "Численность ППС доцентов (без ученой степени и/или звания)(Штатные сотрудники): " + getDateString();
                    break;
                case "1.3":
                    tableName = "Численность ППС старших преподавателей (Штатные сотрудники): " + getDateString();
                    break;
                case "1.4":
                    tableName = "Численность ППС преподавателей и ассистентов(Штатные сотрудники): " + getDateString();
                    break;
                //Внутр
                case "2.1.1":
                    tableName = "Численность ППС с ученой степенью доктора наук (Внутренние совместители): " + getDateString();
                    break;
                case "2.1.2":
                    tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Внутренние совместители): " + getDateString();
                    break;
                case "2.1.3":
                    tableName = "Численность ППС на должности профессора(Внутренние совместители): " + getDateString();
                    break;
                case "2.2.1":
                    tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Внутренние совместители): " + getDateString();
                    break;
                case "2.2.2":
                    tableName = "Численность ППС доцентов (без ученой степени и/или звания)(Внутренние совместители): " + getDateString();
                    break;
                case "2.3":
                    tableName = "Численность ППС старших преподавателей (Внутренние совместители): " + getDateString();
                    break;
                case "2.4":
                    tableName = "Численность ППС преподавателей и ассистентов(Внутренние совместители): " + getDateString();
                    break;
                //Внешние
                case "3.1.1":
                    tableName = "Численность ППС с ученой степенью доктора наук(Внешние совместители): " + getDateString();
                    break;
                case "3.1.2":
                    tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Внешние совместители): " + getDateString();
                    break;
                case "3.1.3":
                    tableName = "Численность ППС на должности профессора(Внешние совместители): " + getDateString();
                    break;
                case "3.2.1":
                    tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Внешние совместители): " + getDateString();
                    break;
                case "3.2.2":
                    tableName = "Численность ППС доцентов (без ученой степени и/или звания(Внешние совместители): " + getDateString();
                    break;
                case "3.3":
                    tableName = "Численность ППС старших преподавателей (Внешние совместители): " + getDateString();
                    break;
                case "3.4":
                    tableName = "Численность ППС преподавателей и ассистентов(Внешние совместители): " + getDateString();
                    break;
            }//Получаем таблицу из базы
            //additional();
        }

        private static DataSet dataset = new DataSet();

        private void additionalCopy()
        {
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {

                    DataRow dr = ds.Tables[0].NewRow();
                    dataset = ds.Clone();

                    double previusRate = (double)ds.Tables[0].Rows[0].ItemArray[7], nextRate = 0;//Начальное значение ставки и текущее
                    int rownum = 0, countTitle = 0, sumcountTitle = 0, degree = 0, sumdegree = 0;//Номер строки,количество званий, их сумма, количество степеней, их сумма
                    double rate = 0, sumrate = 0;//Ставка, сумма ставок
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        nextRate = (double)ds.Tables[0].Rows[i].ItemArray[7];//Присваеваем текущее значение ставки
                        if (previusRate == nextRate)//Сравниваем с предедущим
                        {//и если они совпадают по заполняем дальше таблицу
                            dr = dataset.Tables[0].NewRow();

                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Заполняем колонки в строке
                            {
                                dr[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                            }

                            //rate += double.Parse(ds.Tables[0].Rows[i + rownum].ItemArray[7].ToString());//Получаем ставку
                            rate += double.Parse(dr[7].ToString());//Получаем ставку
                            sumrate += double.Parse(dr[7].ToString());//Суммируем ставку
                            if (dr[5].ToString() != "")
                            {
                                degree++; sumdegree++;//Суммируем степень и сумму степеней
                            }
                            if (dr[6].ToString() != "")
                            {
                                countTitle++; sumcountTitle++;//Суммируем звание и сумму званий
                            }

                            dataset.Tables[0].Rows.Add(dr);
                        }
                        else
                        {
                            dr = dataset.Tables[0].NewRow();
                            rownum++;
                            //Заполняем суммы
                            dr[4] = "Всего";
                            dr[5] = degree;
                            dr[6] = countTitle;
                            dr[7] = rate;

                            degree = 0;//анулируем степень
                            countTitle = 0;//Звание
                            rate = 0;//и ставку
                            previusRate = nextRate;//меняем предыдущую на текущую ставки
                            i--;
                            dataset.Tables[0].Rows.Add(dr);
                        }
                    }
                    //Заполняем предпоследнюю строку , т.к. вышли из цыкла , а заполнить её тоже нужно
                    dr = dataset.Tables[0].NewRow();

                    dr[4] = "Всего";
                    dr[5] = degree;
                    dr[6] = countTitle;
                    dr[7] = rate;
                    dataset.Tables[0].Rows.Add(dr);
                    //Заполняем последнюю строку
                    dr = dataset.Tables[0].NewRow();
                    dr[4] = "Итого";
                    dr[5] = sumdegree;
                    dr[6] = sumcountTitle;
                    dr[7] = sumrate;

                    dataset.Tables[0].Rows.Add(dr);


                    dataGridView1.DataSource = dataset;//Заполняем таблицу
                    dataGridView1.DataMember = dataset.Tables[0].TableName;//Имя таблицы
                }
            }
            //dataGridView1.DataMember = dataset.Tables[0].TableName;//Имя таблицы
        }

        private void showDissertations()
        {
            ds = Data.Dissertation.Show(DissMonthCalendar1.SelectionStart.Date,StartMonthCalendar1.SelectionStart.Date);//В зависимости от названия кафедры, заполняем таблицу, CairsComboBox1.SelectedIndex + 1 получаем название кафедры по номеру +1 т.к. начинаеться с нуля а в базе с единицы
            
            dataGridView1.DataSource = null;
            for (int i = 2; i < ds.Tables[0].Columns.Count; i++)
            {
                dataGridView1.Columns.Add("", ds.Tables[0].Columns[i].ColumnName);
            }


            int prevId = -1;
            string prevTitle = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (prevId != (int)ds.Tables[0].Rows[i].ItemArray[0])
                {
                    dataGridView1.Rows.Add();
                    prevId = (int)ds.Tables[0].Rows[i].ItemArray[0];
                    prevTitle = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    for (int j = 2; j < ds.Tables[0].Columns.Count; j++)
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j - 2].Value = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    }
                }
                else
                {
                    if (prevTitle != ds.Tables[0].Rows[i].ItemArray[7].ToString())
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 2; j < ds.Tables[0].Columns.Count; j++)
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j - 2].Value = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        }
                    }
                    prevTitle = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                }
            }

        }

        private void training()
        {
            ds = Data.Training.Show(DissMonthCalendar1.SelectionStart.Date, StartMonthCalendar1.SelectionStart.Date);//В зависимости от названия кафедры, заполняем таблицу, CairsComboBox1.SelectedIndex + 1 получаем название кафедры по номеру +1 т.к. начинаеться с нуля а в базе с единицы
            //dataGridView1.DataSource = ds;//Заполняем таблицу
            //dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
            //dataGridView1.Columns["id"].Visible = false;//Скрываем поле id


            dataGridView1.DataSource = null;
            for (int i = 2; i < ds.Tables[0].Columns.Count; i++)
            {
                dataGridView1.Columns.Add("", ds.Tables[0].Columns[i].ColumnName);
            }


            int prevId = -1;
            string prevTitle = "",prevStart="",prevEnd="";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (prevId != (int)ds.Tables[0].Rows[i].ItemArray[0])
                {
                    dataGridView1.Rows.Add();
                    prevId = (int)ds.Tables[0].Rows[i].ItemArray[0];
                    prevTitle = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    for (int j = 2; j < ds.Tables[0].Columns.Count; j++)
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j - 2].Value = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    }
                }
                else
                {
                    if ((prevTitle != ds.Tables[0].Rows[i].ItemArray[7].ToString()) | (prevStart != ds.Tables[0].Rows[i].ItemArray[8].ToString()) | (prevEnd != ds.Tables[0].Rows[i].ItemArray[9].ToString()))
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 2; j < ds.Tables[0].Columns.Count; j++)
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j - 2].Value = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        }
                    }
                    prevTitle = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    prevStart = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                    prevEnd = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                }
            }
        }




        private void ageChair()
        {
            dataset = Data.Chair.Show(StartMonthCalendar1.SelectionStart.Date, "Штатный сотрудник");
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Columns.Add("", dataset.Tables[0].Rows[i].ItemArray[1].ToString());
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "Ср. возраст штатных сотрудников";
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows[0].Cells[i + 1].Value = dataset.Tables[0].Rows[i].ItemArray[2].ToString();
            }


            dataset = Data.Chair.Show(StartMonthCalendar1.SelectionStart.Date, "Штатные совместители"); 
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "Ср. возраст штатных совместителей";
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows[1].Cells[i + 1].Value = dataset.Tables[0].Rows[i].ItemArray[2].ToString();
            }


            dataset = Data.Chair.Show(StartMonthCalendar1.SelectionStart.Date, "Сторонние (внешние) совместители"); 
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "Ср. возраст сторонних (внешних) совместителей";
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows[2].Cells[i + 1].Value = dataset.Tables[0].Rows[i].ItemArray[2].ToString();
            }
        }

        //private void showRecord()
        //{
        //    ds = Data.RecordOld.Show(StartMonthCalendar1.SelectionStart.Date);//В зависимости от названия кафедры, заполняем таблицу, CairsComboBox1.SelectedIndex + 1 получаем название кафедры по номеру +1 т.к. начинаеться с нуля а в базе с единицы
        //    dataGridView1.DataSource = ds;//Заполняем таблицу
        //    dataGridView1.DataMember = ds.Tables[0].TableName;//Имя таблицы
        //    dataGridView1.Columns["id"].Visible = false;//Скрываем поле id
        //}

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
            ds = Data.AgeStructure.getAge(StartMonthCalendar1.SelectionStart.Date);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.AgeStructure.getAgeFemale(StartMonthCalendar1.SelectionStart.Date);

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
            ds = Data.ExperienceStructure.getTotalExperience(StartMonthCalendar1.SelectionStart.Date);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count - 7; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.ExperienceStructure.getExperience(StartMonthCalendar1.SelectionStart.Date);

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
            ds = Data.DegreesStructure.getRate(StartMonthCalendar1.SelectionStart.Date);

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
            ds = Data.BasicStructure.getDegreesAndTitle(StartMonthCalendar1.SelectionStart.Date);//Получаем объект DataSet для заполнения таблички

            for (int i = 0; i < 7; i++)//Заполняем первую часть таблички, заполняем каждую строку
            {
                for (int j = 1; j < 9; j++)//Заполняем каждый столбец в данной строчке
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();//ds.Tables[0].Rows[i].ItemArray[j-1] Достаём из объекта DataSet таблицу 0 , в ней строку i , а в этой строке стобец j-1 т.к. мы начинаем заполнение со второго столбца а нам нужен первый
                }
            }
            ds = Data.BasicStructure.getQualification(StartMonthCalendar1.SelectionStart.Date);//Заполняем столбец с квалификациями
            for (int i = 0; i < 7; i++)
            {
                dataGridView1[9, i].Value = ds.Tables[0].Rows[i].ItemArray[0];//Начинаем от 9
            }
            ds = Data.BasicStructure.getRate(StartMonthCalendar1.SelectionStart.Date);//Заполняем ставки
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
            ds = Data.InternalStructure.getDegreesAndTitle(StartMonthCalendar1.SelectionStart.Date);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.InternalStructure.getQualification(StartMonthCalendar1.SelectionStart.Date);
            for (int i = 0; i < 7; i++)
            {
                dataGridView1[9, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
            }
            ds = Data.InternalStructure.getRate(StartMonthCalendar1.SelectionStart.Date);
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
            ds = Data.ExternalStructure.getDegreesAndTitle(StartMonthCalendar1.SelectionStart.Date);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    dataGridView1[j, i].Value = ds.Tables[0].Rows[i].ItemArray[j - 1].ToString();
                }
            }
            ds = Data.ExternalStructure.getQualification(StartMonthCalendar1.SelectionStart.Date);
            for (int i = 0; i < 7; i++)
            {
                dataGridView1[9, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
            }
            ds = Data.ExternalStructure.getRate(StartMonthCalendar1.SelectionStart.Date);
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
                //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                //orderByRate("0.0.1");
                //tableName = "Распределение численности основного персонала по уровню образования (без внешних совместителей): " + getDateString();
                dsNum = "0.0.1";
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
                //tableName = "Распределение численности внутренние совместителей по уровню образования: " + getDateString();
                dsNum = "0.0.2";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                internalData();
            }
            catch { this.Close(); }
        }

        private void сторонниевнешниеСовместителиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Распределение численности внешних совместителей по уровню образования: " + getDateString();
                dsNum = "0.0.3";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                externalData();
            }
            catch { this.Close(); }
        }

        private void сведенияОбУченыхСтепеняхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Сведения об ученых степенях профессорско-преподавательского состава и научных работников с " + getDateString() +" по "+getDateStringDiss();
                dsNum = "0.1.0";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                degreesData();
            }
            catch { this.Close(); }
        }

        private void распределениеПерсоналаПоСтажуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Распределение персонала по стажу работы (Основного персонала, Штатных совместителей, Внешних совместителей): " + getDateString();
                dsNum = "0.1.1";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                experienceData();
            }
            catch { this.Close(); }
        }

        private void распределениеПерсоналаПоПолуИВозрастуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Распределение персонала по полу и возрасту (Основного персонала, Штатных совместителей, Внешних совместителей): " + getDateString();
                dsNum = "0.1.2";
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
            //try
            //{
                //tableName = "Численность ППС с ученой степенью доктора наук(Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.1.1");
            //}
            //catch { this.Close(); }
        }

        private void кандидатыНаукПрофессораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                //tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.1.2");
            //}
            //catch { this.Close(); }
        }

        private void профессорыToolStripMenuItem_Click(object sender, EventArgs e)//TODO Профессора
        {
            //try
            //{
                //tableName = "Численность ППС на должности профессора(Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.1.3");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
        }

        private void кандидатыНаукИилиДоцентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.2.1");
            }
            catch { this.Close(); }
        }

        private void доцентыбезУченойСтепениИилиЗванияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС доцентов (без ученой степени и/или звания)(Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.2.2");
            }
            catch { this.Close(); }
        }

        private void старшиеПреподователиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС старших преподавателей (Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.3");
            }
            catch { this.Close(); }
        }

        private void преподавателиИАссистентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС преподавателей и ассистентов(Штатные сотрудники): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("1.4");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью доктора наук (Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.1.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.1.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС на должности профессора(Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.1.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.2.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС доцентов (без ученой степени и/или звания)(Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.2.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС старших преподавателей (Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС преподавателей и ассистентов(Внутренние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("2.4");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью доктора наук(Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.1.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью кандидата наук и ученым званием профессора (Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.1.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС на должности профессора(Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.1.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС с ученой степенью кандидата наук и/или званием доцента(Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.2.1");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС доцентов (без ученой степени и/или звания(Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.2.2");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС старших преподавателей (Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.3");
            }
            catch { this.Close(); }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Численность ППС преподавателей и ассистентов(Внешние совместители): " + getDateString();
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                orderByRate("3.4");
            }
            catch { this.Close(); }
        }

        private void диссертацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                //tableName = "Защита диссертаций c " + getDateString() + " по " + getDateStringDiss();
                dsNum = "0.2.0";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                showDissertations();
            //}
            //catch { this.Close(); }
        }

        private void учетСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //tableName = "Учёт сотрудников с " + getDateString();
            //    dsNum = "0.2.1";
            //    dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            //    showRecord();
            //}
            //catch { this.Close(); }

            using (RecordStaff editform = new RecordStaff())
            {
                editform.Closing += (sender_1, e_1) =>//Передаём объект события
                {
                    dataGridView1.Columns.Clear();
                };
                editform.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dsNum == "0.2.1")
            //    {
            //        bool dekan = false;
            //        //using для того чтобы объект формы сам уничтожился после закрытия
            //        //В конструкторе передаём true(bool переменная котороя означает кнопку редактирования) и строку запроса из базы (select * from faculty) 
            //        using (EditForm editform = new EditForm(true, Data.EditForm.getRecordTeachers(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())), dekan))
            //        {
            //            editform.Closing += (sender_1, e_1) =>//Передаём объект события
            //            {
            //                //UpdateFacultyGridView();//обнавляем после закрытия
            //            };
            //            editform.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception err) { MessageBox.Show("Выберите сотрудника", "Сотрудник не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private string getDateString()
        {
            return StartMonthCalendar1.SelectionStart.Date.Day + "-" + StartMonthCalendar1.SelectionStart.Date.Month + "-" + StartMonthCalendar1.SelectionStart.Date.Year ;
        }
        private string getDateStringDiss()
        {
            return DissMonthCalendar1.SelectionStart.Date.Day + "-" + DissMonthCalendar1.SelectionStart.Date.Month + "-" + DissMonthCalendar1.SelectionStart.Date.Year;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //dateGroupBox1.Visible = false;//Скрываем выбор дат
            StartMonthCalendar1.Visible = false;
            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            //orderByRate(dsNum);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (StartMonthCalendar1.Visible)
            {
                StartMonthCalendar1.Visible = false;
                DissMonthCalendar1.Visible = false;
                dataGridView1.Refresh();
            }
            else
            {
                StartMonthCalendar1.Visible = true;
                dataGridView1.Refresh();
                if (dsNum.Equals("0.2.0")  || dsNum.Equals("0.2.2"))
                {
                    DissMonthCalendar1.Visible = true;
                }
            }
        }
        private void EndMonthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate(dsNum);
        }

        private void StartMonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate(dsNum);
            setTableName(dsNum);
        }
        private void DissMonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate(dsNum);
            setTableName(dsNum);
        }

        private void DateOfSampling_DateChanged(object sender, DateRangeEventArgs e)
        {
            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate(dsNum);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            StartMonthCalendar1.Visible = false;
            DissMonthCalendar1.Visible = false;
            dataGridView1.Refresh();
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            StartMonthCalendar1.Visible = false;
            DissMonthCalendar1.Visible = false;
            dataGridView1.Refresh();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (StartMonthCalendar1.Visible)
            {
                Color color = Color.FromArgb(100, Color.Gray);
                SolidBrush br = new SolidBrush(color);
                e.Graphics.FillRectangle(br, e.ClipRectangle);
            }
        }


        private void текущийОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export.print(dataGridView1, tableName);
            setTableName(dsNum);
        }

        private void повышениеКвалификацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //tableName = "Повышение квалификации" + getDateString() + " с " + getDateStringDiss();
                dsNum = "0.2.2";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                training();
            }
            catch { this.Close(); }
        }



        private void среднийВозрастToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                dsNum = "0.2.3";
                dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
                ageChair();
            //}
            //catch { this.Close(); }
        }

        private void дополнительныеТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void выборПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1.2.1 1.2.2   1.3    1.4
            //dataGridView1.Visible = false;
            Dictionary<string, DataSet> listDataGrid = new Dictionary<string, DataSet>();
            orderByRate("1.1.1");
            setTableName("1.1.1");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("1.1.2");
            setTableName("1.1.2");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("1.1.3");
            setTableName("1.1.3");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("1.2.1");
            setTableName("1.2.1");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("1.2.2");
            setTableName("1.2.2");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("1.3");
            setTableName("1.3");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("1.4");
            setTableName("1.4");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            //dataGridView1.Visible = true;
            try
            {
                Export.print(listDataGrid, "Штатные сотрудники");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Отчёт пустой");
            }
            dataset.Clear();


            #region
            //using (ReportExcel addform = new ReportExcel())
            //{
            //    addform.Closing += (sender_1, e_1) =>
            //    {
            //        //UpdateFacultyGridView();//обнавляем после закрытия
            //    };
            //    addform.ShowDialog();
            //}


            //var columns = ds.Tables
            //         .Cast<DataTable>()
            //         .SelectMany(t => t.Columns
            //                         .Cast<DataColumn>()
            //                         .Select(c => c.ColumnName));
            #endregion
        }

        private void сторонниеСовместителиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Visible = false;
            Dictionary<string, DataSet> listDataGrid = new Dictionary<string, DataSet>();
            orderByRate("2.1.1");
            setTableName("2.1.1");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("2.1.2");
            setTableName("2.1.2");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("2.1.3");
            setTableName("2.1.3");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("2.2.1");
            setTableName("2.2.1");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("2.2.2");
            setTableName("2.2.2");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("2.3");
            setTableName("2.3");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("2.4");
            setTableName("2.4");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            //dataGridView1.Visible = true;
            try
            {
                Export.print(listDataGrid, "Сторонние совместители");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Отчёт пустой");
            }
            dataset.Clear();
        }

        private void внешниеСовместителиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Visible = false;
            Dictionary<string, DataSet> listDataGrid = new Dictionary<string, DataSet>();
            orderByRate("3.1.1");
            setTableName("3.1.1");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("3.1.2");
            setTableName("3.1.2");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("3.1.3");
            setTableName("3.1.3");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("3.2.1");
            setTableName("3.2.1");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("3.2.2");
            setTableName("3.2.2");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("3.3");
            setTableName("3.3");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            orderByRate("3.4");
            setTableName("3.4");
            listDataGrid.Add(tableName, dataset.Copy());
            dataset.Clear();

            //dataGridView1.Columns.Clear();//Удаляем все столбцы из таблицы(отчищаем)
            //dataGridView1.Visible = true;
            try
            {
                Export.print(listDataGrid, "Внешние совместители ");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Отчёт пустой");
            }
            dataset.Clear();
        }



    }
}
