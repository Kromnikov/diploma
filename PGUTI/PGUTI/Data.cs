﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace PGUTI
{
    public static class Data
    {

        private static string between(DateTime startDate, DateTime endDate)
        {
            return String.Format(" (((start_date < '{1}' and start_date > '{0}' ) and (end_date is null)) or  ((start_date between '{0}' and '{1}') or (end_date between '{0}' and '{1}'))) ", ReverseDateTime(startDate), ReverseDateTime(endDate));
        }

        private static string connectionString = ConfigurationManager.ConnectionStrings["Pguti.Connection"].ConnectionString;//Строка подключения к базе , из файла конфигурации
        
        private static DataSet ds = new DataSet();//Объект запроса
        
        //private static Hashtable ht = new Hashtable();

        public static string ReverseDateTime(DateTime date)
        {
            return date.ToString("yyyy.MM.dd hh:mm:ss");
        }

        private static string[] getPreviusDate()//Получаем предыдущий учебный год
        {//сайчас 2015 год,для примера
            string[] date = new string[2];
            date[0] = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month < 9)//Если месяц меньше 9, тогда нынешний учебный год это 2014-2015 , а предыдущий соотвественно 2013-2014
            {
                date[0] = "'" + (DateTime.Now.Year - 2).ToString() + ".9.1'";
                date[1] = "'" + (DateTime.Now.Year - 1).ToString() + ".8.31'";
            }
            else//Если это не так, тогда текущий учебный год 2015-2016 а предыдущий 2014-2015
            {
                date[0] = "'" + (DateTime.Now.Year - 1).ToString() + ".9.1'";
                date[1] = "'" + (DateTime.Now.Year).ToString() + ".8.31'";
            }
            return date;
        }
        
        public static class EditForm
        {
            public static DataSet getTeachers(int id)//Главная таблица
            {
                string result = "select * from dbo.Teachers where id = " +id;
                return ds = NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
        }



        //Справочники
        public static class Reference
        {
            //Faculties
            public static DataSet getFaculties()
            {
                string result = "SELECT  id,name as 'Полное название',second_name as 'Сокращённое название'  FROM [PGUTI_faculty].[dbo].[Faculties]";
                return NDataAccess.DataAccess.GetDataSet(@result, "Faculties", connectionString);
            }
            public static DataSet getFaculties(int id)
            {
                string result = "SELECT  id,name as 'Полное название',second_name as 'Сокращённое название'   FROM [PGUTI_faculty].[dbo].[Faculties] where id=" + id;
                return NDataAccess.DataAccess.GetDataSet(@result, "Faculties", connectionString);
            }
            public static void editFaculties(int id, string name, string secondName)
            {
                string result = "UPDATE [PGUTI_faculty].[dbo].[Faculties] SET name='" + name + "' , second_name='"+secondName+"' where id=" + id;
                //return NDataAccess.DataAccess.GetDataSet(@result, "Faculties", connectionString);
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void addFaculties(int id, string name, string secondName)
            {
                string result = "INSERT INTO [PGUTI_faculty].[dbo].[Faculties] (id,name,second_name) VALUES ((select max(id)+1 from [PGUTI_faculty].[dbo].[Faculties]),'" + name + "','" + secondName + "') ";
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void dellFaculties(int id)
            {
                string result = "DELETE FROM [dbo].[Faculties] where id=" + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }


            //Cairs
            public static DataSet getCairs()
            {
                string result = "SELECT id,name as 'Полное название',second_name as 'Сокращённое название'  FROM [PGUTI_faculty].[dbo].[Cairs]";
                return NDataAccess.DataAccess.GetDataSet(@result, "Cairs", connectionString);
            }
            public static DataSet getCairs(int id)
            {
                string result = "SELECT  id,name as 'Полное название',second_name as 'Сокращённое название'   FROM [PGUTI_faculty].[dbo].[Cairs] where id=" + id;
                return NDataAccess.DataAccess.GetDataSet(@result, "Cairs", connectionString);
            }
            public static void editCair(int id, string name, string secondName)
            {
                string result = "UPDATE [PGUTI_faculty].[dbo].[Cairs] SET name='" + name + "' , second_name='" + secondName + "' where id=" + id;
                //return NDataAccess.DataAccess.GetDataSet(@result, "Cairs", connectionString);
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void addCair(int id, string name, string secondName)
            {
                string result = "INSERT INTO [PGUTI_faculty].[dbo].[Cairs] (id,name,second_name) VALUES ((select max(id)+1 from [PGUTI_faculty].[dbo].[Cairs]),'" + name + "','" + secondName + "') ";
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void dellCairs(int id)
            {
                string result = "DELETE FROM [dbo].[Cairs] where id=" + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }

            //Degrees
            public static DataSet getDegrees()
            {
                string result = "SELECT  id,name as 'Полное название',second_name as 'Сокращённое название'   FROM [PGUTI_faculty].[dbo].[Degrees]";
                return NDataAccess.DataAccess.GetDataSet(@result, "Degrees", connectionString);
            }
            public static DataSet getDegrees(int id)
            {
                string result = "SELECT  id,name as 'Полное название',second_name as 'Сокращённое название'   FROM [PGUTI_faculty].[dbo].[Degrees] where id=" + id;
                return NDataAccess.DataAccess.GetDataSet(@result, "Degrees", connectionString);
            }
            public static void editDegrees(int id, string name, string secondName)
            {
                string result = "UPDATE [PGUTI_faculty].[dbo].[Degrees] SET name='" + name + "' , second_name='" + secondName + "' where id=" + id;
                //return NDataAccess.DataAccess.GetDataSet(@result, "Degrees", connectionString);
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void addDegrees(int id, string name, string secondName)
            {
                string result = "INSERT INTO [PGUTI_faculty].[dbo].[Degrees] (id,name,second_name) VALUES ((select max(id)+1 from [PGUTI_faculty].[dbo].[Degrees]),'" + name + "','" + secondName + "') ";
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void dellDegrees(int id)
            {
                string result = "DELETE FROM [dbo].[Degrees] where id=" + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }


            //Titles
            public static DataSet getTitles()
            {
                string result = "SELECT  id,name as 'Звание'  FROM [PGUTI_faculty].[dbo].[Titles]";
                return NDataAccess.DataAccess.GetDataSet(@result, "Titles", connectionString);
            }
            public static DataSet getTitles(int id)
            {
                string result = "SELECT  id,name as 'Звание'   FROM [PGUTI_faculty].[dbo].[Titles] where id=" + id;
                return NDataAccess.DataAccess.GetDataSet(@result, "Titles", connectionString);
            }
            public static void editTitles(int id, string name)
            {
                string result = "UPDATE [PGUTI_faculty].[dbo].[Titles] SET name='" + name + "' where id=" + id;
                //return NDataAccess.DataAccess.GetDataSet(@result, "Titles", connectionString);
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void addTitles(int id, string name)
            {
                string result = "INSERT INTO [PGUTI_faculty].[dbo].[Titles] (id,name) VALUES ((select max(id)+1 from [PGUTI_faculty].[dbo].[Titles]),'" + name + "') ";
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void dellTitles(int id)
            {
                string result = "DELETE FROM [dbo].[Titles] where id=" + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }


            //WorkingPositions
            public static DataSet getWorkingPositions()
            {
                string result = "SELECT  id,name as 'Должность'   FROM [PGUTI_faculty].[dbo].[Working_positions]";
                return NDataAccess.DataAccess.GetDataSet(@result, "WorkingPositions", connectionString);
            }
            public static DataSet getWorkingPositions(int id)
            {
                string result = "SELECT  id,name as 'Должность'   FROM [PGUTI_faculty].[dbo].[Working_positions] where id=" + id;
                return NDataAccess.DataAccess.GetDataSet(@result, "WorkingPositions", connectionString);
            }
            public static void editWorkingPositions(int id, string name)
            {
                string result = "UPDATE [PGUTI_faculty].[dbo].[Working_positions] SET name='" + name + "' where id=" + id;
                //return NDataAccess.DataAccess.GetDataSet(@result, "Working_positions", connectionString);
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void addWorkingPositions(int id, string name)
            {
                string result = "INSERT INTO [PGUTI_faculty].[dbo].[Working_positions] (id,name) VALUES ((select max(id)+1 from [PGUTI_faculty].[dbo].[Working_positions]),'" + name + "') ";
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void dellWorkingPositions(int id)
            {
                string result = "DELETE FROM [dbo].[Working_positions] where id="+id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }

            //public static void Add(string result)
            //{
            //    NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            //}
        }


        //ШТАТ
        public static class BasicStructure
        {
            public static void getGroupBy(string dekan, string by)
            {
                string[] a = null;
                string result = "select COUNT(*)  from dbo.Teachers where Dekan_Faculties " + dekan + " group by " + by;
                //return ds = NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
                ds = NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
                //a = (string[])ds.Tables[0].Rows[0].ItemArray[0];
                string b = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    b = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
            }
            public static DataSet getDegreesAndTitle(DateTime startDate, DateTime endDate)
            {
                string result = "SELECT    COUNT(*) as Всего ,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where terms_of_work like '%Штатный сотрудник%'  and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" ) as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"  union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 2    and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"    union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"   union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title =4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+")as Женщины FROM Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getRate(DateTime startDate, DateTime endDate)
            {
                string result = "SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+") as '1' FROM    Teachers union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '1' FROM    Teachers where Dekan_Faculties is not null union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 1) as '1' FROM    Teachers where Job_title = 1 union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 2) as '1' FROM    Teachers where Job_title = 2  union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 3) as '1' FROM    Teachers where Job_title = 3             union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  Job_title = 4) as '1' FROM    Teachers where Job_title = 4 union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '1' FROM  Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getQualification(DateTime startDate, DateTime endDate)
            {
                string[] date = getPreviusDate();
                string result = "SELECT COUNT(Training_dates) as Всего FROM    Teachers where terms_of_work like '%Штатный сотрудник%' and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) FROM Teachers where Dekan_Faculties is not null and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"  and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where Job_title = 1 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM    Teachers where Job_title = 2    and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM    Teachers where Job_title = 3 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where Job_title = 4 and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатный сотрудник%' and "+between(startDate, endDate)+" and (Training_dates between " + date[0] + " and " + date[1] + ")";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }

            //Профф
            public static DataSet getProfessors(DateTime startDate, DateTime endDate)//TODO надо развернуть дату, везде =(   startDate.ToString("ddMMyyy");
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатный сотрудник%' and f.Job_title =2 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getProfessorsDoc(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатный сотрудник%' and f.Job_title =2 and f.degrees_id>10 and f.degrees_id<16 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getProfessorsCand(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id  where f.terms_of_work like '%Штатный сотрудник%' and f.Job_title =2 and f.degrees_id>4 and f.degrees_id<11 and f.titles_id=1  and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Доценты
            public static DataSet getDocentsCandAndOrDocent(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатный сотрудник%' and f.Job_title =3 and ((f.degrees_id>4 and f.degrees_id<11) or (f.titles_id=2) or(f.degrees_id>4 and f.degrees_id<11 and f.titles_id=2) ) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getDocentsNull(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатный сотрудник%' and f.Job_title =3 and ((f.degrees_id=16) or (f.titles_id=3) or(f.degrees_id=16 and f.titles_id=3) ) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Старшие преп
            public static DataSet getSenior(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатный сотрудник%' and f.Job_title =4 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Ассистенты
            public static DataSet getAssist(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатный сотрудник%' and (f.Job_title =5 or f.Job_title=6) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
        }
        //Внутр
        public static class InternalStructure
        {
            public static DataSet getDegreesAndTitle(DateTime startDate, DateTime endDate)
            {
                string result = "SELECT    COUNT(*) as Всего ,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where terms_of_work like '%Штатные совместители %'  and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" ) as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"  union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 2    and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"    union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"   union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title =4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+")as Женщины FROM Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+""; 
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getRate(DateTime startDate, DateTime endDate)
            {
                string result = "SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+") as '1' FROM    Teachers union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '1' FROM    Teachers where Dekan_Faculties is not null union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 1) as '1' FROM    Teachers where Job_title = 1 union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 2) as '1' FROM    Teachers where Job_title = 2  union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 3) as '1' FROM    Teachers where Job_title = 3             union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  Job_title = 4) as '1' FROM    Teachers where Job_title = 4 union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '1' FROM  Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+""; 
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }///////////////////INT
            public static DataSet getQualification(DateTime startDate, DateTime endDate)
            {
                string[] date = getPreviusDate();
                string result = "SELECT COUNT(Training_dates) as Всего FROM    Teachers where terms_of_work like '%Штатные совместители %' and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) FROM Teachers where Dekan_Faculties is not null and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"  and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where Job_title = 1 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM    Teachers where Job_title = 2    and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+" and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM    Teachers where Job_title = 3 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where Job_title = 4 and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Штатные совместители %' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ")"; 
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }

            //Профф
            public static DataSet getProfessors(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатные совместители %' and f.Job_title =2 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getProfessorsDoc(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатные совместители %' and f.Job_title =2 and f.degrees_id>10 and f.degrees_id<16 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getProfessorsCand(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id  where f.terms_of_work like '%Штатные совместители %' and f.Job_title =2 and f.degrees_id>4 and f.degrees_id<11 and f.titles_id=1  and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Доценты
            public static DataSet getDocentsCandAndOrDocent(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатные совместители %' and f.Job_title =3 and ((f.degrees_id>4 and f.degrees_id<11) or (f.titles_id=2) or(f.degrees_id>4 and f.degrees_id<11 and f.titles_id=2) ) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getDocentsNull(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатные совместители %' and f.Job_title =3 and ((f.degrees_id=16) or (f.titles_id=3) or(f.degrees_id=16 and f.titles_id=3) ) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Старшие преп
            public static DataSet getSenior(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатные совместители %' and f.Job_title =4 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Ассистенты
            public static DataSet getAssist(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Штатные совместители %' and (f.Job_title =5 or f.Job_title=6) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
        }//         %Штатные совместители %
        //Внеш
        public static class ExternalStructure
        {
            public static DataSet getDegreesAndTitle(DateTime startDate, DateTime endDate)
            {
                string result = "SELECT    COUNT(*) as Всего ,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where terms_of_work like '%Сторонние (внешние) совместители%'  and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" ) as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"  union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 2    and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"    union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"   union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and Job_title =4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM    Teachers where Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" union all SELECT    COUNT(*) as Всего,    (select Count(*) from dbo.Teachers where degrees_id > 4  and degrees_id < 16 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_степени,    (select Count(*) from dbo.Teachers where degrees_id between 4 and 10 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Кандидаты_наук,    (select Count(*) from dbo.Teachers where degrees_id > 10  and degrees_id < 16 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доктора_наук,    (select Count(*) from dbo.Teachers where titles_id > 0 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Ученые_звания,    (select Count(*) from dbo.Teachers where titles_id =1 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Профессора,    (select Count(*) from dbo.Teachers where titles_id = 2 and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as Доценты,    (select COUNT(*) from dbo.Teachers where gender like 'Жен' and (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+")as Женщины FROM Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+""; 
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getRate(DateTime startDate, DateTime endDate)
            {
                string result = "SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+") as '1' FROM    Teachers union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Dekan_Faculties is not null) as '1' FROM    Teachers where Dekan_Faculties is not null union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 1) as '1' FROM    Teachers where Job_title = 1 union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 2) as '1' FROM    Teachers where Job_title = 2  union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 3) as '1' FROM    Teachers where Job_title = 3             union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  Job_title = 4) as '1' FROM    Teachers where Job_title = 4 union all SELECT    count(*),    (select Count(*) from dbo.Teachers where rate = 0.1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,1',    (select Count(*) from dbo.Teachers where rate = 0.2 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,2',    (select Count(*) from dbo.Teachers where rate = 0.3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,3',    (select Count(*) from dbo.Teachers where rate = 0.4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,4',    (select Count(*) from dbo.Teachers where rate = 0.5 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,5',    (select Count(*) from dbo.Teachers where rate = 0.6 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,6',    (select Count(*) from dbo.Teachers where rate = 0.7 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,7',    (select Count(*) from dbo.Teachers where rate = 0.8 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,8',    (select Count(*) from dbo.Teachers where rate = 0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '0,9',    (select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and  (Job_title = 5 or Job_title = 6)) as '1' FROM  Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+""; 
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }////EXT
            public static DataSet getQualification(DateTime startDate, DateTime endDate)
            {
                string[] date = getPreviusDate();
                string result = "SELECT COUNT(Training_dates) as Всего FROM    Teachers where terms_of_work like '%Сторонние (внешние) совместители%' and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) FROM Teachers where Dekan_Faculties is not null and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"  and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where Job_title = 1 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM    Teachers where Job_title = 2    and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+" and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM    Teachers where Job_title = 3 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where Job_title = 4 and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ") union all SELECT COUNT(Training_dates) as Всего FROM Teachers where (Job_title = 5 or Job_title = 6) and terms_of_work like '%Сторонние (внешние) совместители%' and "+between(startDate, endDate)+"and (Training_dates between " + date[0] + " and " + date[1] + ")"; 
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }


            //Профф
            public static DataSet getProfessors(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Сторонние (внешние) совместители%' and f.Job_title =2 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getProfessorsDoc(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Сторонние (внешние) совместители%' and f.Job_title =2 and f.degrees_id>10 and f.degrees_id<16 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getProfessorsCand(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id  where f.terms_of_work like '%Сторонние (внешние) совместители%' and f.Job_title =2 and f.degrees_id>4 and f.degrees_id<11 and f.titles_id=1  and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Доценты
            public static DataSet getDocentsCandAndOrDocent(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Сторонние (внешние) совместители%' and f.Job_title =3 and ((f.degrees_id>4 and f.degrees_id<11) or (f.titles_id=2) or(f.degrees_id>4 and f.degrees_id<11 and f.titles_id=2) ) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getDocentsNull(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Сторонние (внешние) совместители%' and f.Job_title =3 and ((f.degrees_id=16) or (f.titles_id=3) or(f.degrees_id=16 and f.titles_id=3) ) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Старшие преп
            public static DataSet getSenior(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Сторонние (внешние) совместители%' and f.Job_title =4 and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //Ассистенты
            public static DataSet getAssist(DateTime startDate, DateTime endDate)
            {
                string result = "select f.surname,f.name,f.middlename,w.name,c.second_name,s.name,a.second_name,f.rate,convert(VARCHAR(10),f.birthday,105) from dbo.Teachers as f left join dbo.Cairs as c on c.id=f.Cairs left join dbo.Working_positions as w on w.id=f.Job_title left join dbo.Degrees as a on a.id = f.degrees_id left join dbo.Titles as s on s.id = f.titles_id where f.terms_of_work like '%Сторонние (внешние) совместители%' and (f.Job_title =5 or f.Job_title=6) and "+between(startDate, endDate)+" order by rate";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
        }//           %Сторонние (внешние) совместители%

        public static class Dissertation
        {
            public static DataSet Show(DateTime startDate, DateTime endDate)
            {
                string result = "select f.id,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,c.second_name as 'Кафедра',d.name as 'ученое звание',titles_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',f.degress_date as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.' from Teachers as f left join  Working_positions as w on w.id=f.Job_title   left join Titles as d on d.id=f.titles_id  left join Degrees as a on a.id=f.degrees_id  left join Cairs as c on c.id = f.Cairs where " + between(startDate, endDate) + " ";//where DATEDIFF(MONTH,degress_date,'" + date + "')=0 ";//and f.Dekan_Faculties is null
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
        }//Диссетрации

        public static class Record
        {
            public static void Add(string result)
            {
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void Add(int id, bool del, DateTime experienceDate)
            {
                Object[] array = GetDataTeachers(id).Tables[0].Rows[0].ItemArray;//Объект строки запроса
                string[] cairsandjob = new string[2], date = new string[2];//массивы для даты, названия кафедры и должности
                if (array[6].ToString() == "3") date[0] = "null";//Если нету ученой степени то даты её получения тоже нету
                else date[0] = "'" + array[7].ToString() + "'";
                if (array[8].ToString() == "16") date[1] = "null";//Если нету ученого звания то даты его получения тоже нету
                else date[1] = "'" + array[9].ToString() + "'";
                string result = "";
                if (del)//Удаляяем?
                {//да
                    string[] termworks = array[10].ToString().Split('-');//разбиваем строку для получения из неё данных и изменения самой строки
                    if (array[13].ToString() == "")//Если не декан
                        result = "INSERT INTO dbo.Records (id,Cairs,Job_title,surname,name,middlename,titles_id,titles_date,degrees_id,degress_date,terms_of_work,date)" +
                        "VALUES(" + (int.Parse(Count()) + 1) + "," + (int)array[1] + "," + (int)array[2] + ",'" + array[3] + "','" + array[4] + "','" + array[5] + "'," + (int)array[6] + "," + date[0] + "," + (int)array[8] + "," + date[1] + ",'" + termworks[0] + "-" + termworks[1] + "-Уволился-(" + experienceDate + ")','" + experienceDate + "')";
                    else result = "INSERT INTO dbo.Records (id,surname,name,middlename,titles_id,titles_date,degrees_id,degress_date,terms_of_work,date)" +
                    "VALUES(" + (int.Parse(Count()) + 1) + ",'" + array[3] + "','" + array[4] + "','" + array[5] + "'," + (int)array[6] + "," + date[0] + "," + (int)array[8] + "," + date[1] + ",'" + termworks[0] + "-" + termworks[1] + "-Уволился-(" + experienceDate + ")','" + experienceDate + "')";
                }
                else
                {//нет
                    if (array[13].ToString() == "")//Если не декан
                        result = "INSERT INTO dbo.Records (id,Cairs,Job_title,surname,name,middlename,titles_id,titles_date,degrees_id,degress_date,terms_of_work,date)" +
                        "VALUES(" + (int.Parse(Count()) + 1) + "," + (int)array[1] + "," + (int)array[2] + ",'" + array[3] + "','" + array[4] + "','" + array[5] + "'," + (int)array[6] + "," + date[0] + "," + (int)array[8] + "," + date[1] + ",'" + array[10] + "','" + experienceDate + "')";
                    else result = "INSERT INTO dbo.Records (id,surname,name,middlename,titles_id,titles_date,degrees_id,degress_date,terms_of_work,date)" +
                    "VALUES(" + (int.Parse(Count()) + 1) + ",'" + array[3] + "','" + array[4] + "','" + array[5] + "'," + (int)array[6] + "," + date[0] + "," + (int)array[8] + "," + date[1] + ",'" + array[10] + "','" + experienceDate + "')";
                }
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static string Count()
            {
                ds = NDataAccess.DataAccess.GetDataSet(@"select max(id) as count from dbo.Records", "Table1", connectionString);
                string result = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                if (result == "") result = "0";
                return (result);
            }
            public static DataSet Show(DateTime startDate, DateTime endDate)
            {
                //string result = "select f.id,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,c.second_name as 'Кафедра',d.name as 'ученое звание',titles_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',titles_date as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.' from Teachers as f left join  Working_positions as w on w.id=f.Job_title left join Titles as d on d.id=f.titles_id left join Degrees as a on a.id=f.degrees_id left join Cairs as c on c.id = f.Cairs    join Record as r on f.id = r.Teachers_id      where DATEDIFF(MONTH,r.date,'" + date + "')=0 ";
                string result = "select f.id,c.second_name as 'Кафедра',w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,d.name as 'ученое звание',titles_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',f.degress_date as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.' from Records as f  left join  Working_positions as w on w.id=f.Job_title left join Titles as d on d.id=f.titles_id left join Degrees as a on a.id=f.degrees_id left join Cairs as c on c.id = f.Cairs  where date >  '" + ReverseDateTime(startDate) + "'";//where DATEDIFF(MONTH,date,GETDATE())=0 ";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet GetDataTeachers(int id)
            {
                string result = "select id,Cairs,Job_title,surname,name,middlename,titles_id,titles_date,degrees_id,degress_date,terms_of_work,rate,experience_date,Dekan_Faculties,education_date from Teachers where id = " + id ;
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
        }

        public static class DegreesStructure
        {
            private static string SplitAndCheck(double value)//Метод для коррекции введённого значения ставки и даты
            {
                string[] rates;
                string result = ""; ;
                rates = value.ToString().Split(new Char[] { '.', ',' });//Разбираем строку по разделителю ('.'или',')
                if (rates.Length > 1)
                {
                    result = (rates[0] + "." + rates[1]);//если стоит разделитель, значит собираем строку с точкой для запроса в базу (с запятой запрос не будет работать, поэтому нужна точка)
                }
                else
                {
                    result = rates[0];//если без разделителя , тогда так и оставляем
                }
                return result;
            }

            private static string queryWithTitles(DateTime startDate, DateTime endDate, string emploe)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                double a = 0;
                for (int i = 1; i < 10; i++)
                {
                    a += 0.1;
                    sb.Append(String.Format(",(select Count(*) from dbo.Teachers where rate = "+SplitAndCheck(a)+" and terms_of_work like '{0}' and {1} ) as '" + a.ToString("0.0") + "' ", emploe, between(startDate, endDate)));
                }
                sb.Append(String.Format(",(select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '{0}' and {1} ) as '1' ",emploe, between(startDate, endDate)));
                sb.Append(String.Format(" from dbo.Teachers where terms_of_work like '{0}' and {1}", emploe, between(startDate, endDate)));

                return sb.ToString();
            }
            private static string queryWithTitles(DateTime startDate, DateTime endDate, string emploe,string title)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                double a = 0;
                for (int i = 1; i < 10; i++)
                {
                    a += 0.1;
                    sb.Append(String.Format(",(select Count(*) from dbo.Teachers where rate = " + SplitAndCheck(a) + " and terms_of_work like '{0}' and {1} and {2} ) as '" + a.ToString("0.0") + "' ", emploe, title, between(startDate, endDate)));
                }
                sb.Append(String.Format(",(select Count(*) from dbo.Teachers where rate >0.9 and terms_of_work like '{0}' and {1} and {2} ) as '1' ", emploe,title, between(startDate, endDate)));
                sb.Append(String.Format(" from dbo.Teachers where terms_of_work like '{0}' and {1} and {2}", emploe,title, between(startDate, endDate)));

                return sb.ToString();
            }

            public static DataSet getRate(DateTime startDate, DateTime endDate)
            {
                StringBuilder sb = new StringBuilder();

                string emploe = "%Штатный сотрудник%";
                sb.Append(queryWithTitles(startDate, endDate, emploe));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, emploe, "(degrees_id between 10 and 16)"));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, emploe, "(degrees_id between 4 and 11)"));
                sb.Append(" union all ");

                emploe = "%Сторонние (внешние) совместители%";
                sb.Append(queryWithTitles(startDate, endDate, emploe));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, emploe, "(degrees_id between 10 and 16)"));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, emploe, "(degrees_id between 4 and 11)"));
                sb.Append(" union all ");

                emploe = "%Штатные совместители%";
                sb.Append(queryWithTitles(startDate, endDate, emploe));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, emploe, "(degrees_id between 10 and 16)"));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, emploe, "(degrees_id between 4 and 11)"));

                return NDataAccess.DataAccess.GetDataSet(sb.ToString(), "Table1", connectionString);

            }
        }//Сведения об ученых степенях профессорско-преподавательского состава и научных работников

        public static class ExperienceStructure
        {
            private static string getExperience(string a,string date)
            {
                return " DATEDIFF(YY," + date + ",CAST(Getdate() AS Date)) " + a + " ";
            }
            private static string getExperience(int a, int b,string date)
            {
                return " DATEDIFF(YY," + date + ",CAST(Getdate() AS Date))>" + (a - 1) + " and DATEDIFF(YY," + date + ",CAST(Getdate() AS Date))< " + b + " ";
            }
            private static string queryWithTitles(DateTime startDate, DateTime endDate,string date)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '3'", between(startDate, endDate), getExperience(" < 3", date)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '3-5'", between(startDate, endDate), getExperience(3, 5, date)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '5-10'", between(startDate, endDate), getExperience(5, 10, date)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '10-15'", between(startDate, endDate), getExperience(10, 15, date)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '15-20'", between(startDate, endDate), getExperience(15, 20, date)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '20+'", between(startDate, endDate), getExperience(" > 19", date)));
                sb.Append(String.Format(" from dbo.Teachers where {0} ", between(startDate, endDate)));

                return sb.ToString();
            }
            private static string queryWithTitles(DateTime startDate, DateTime endDate, string title,string date)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}  and {2}) as '3'", between(startDate, endDate), getExperience(" < 3", date), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}  and {2}) as '3-5'", between(startDate, endDate), getExperience(3, 5, date), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}  and {2}) as '5-10'", between(startDate, endDate), getExperience(5, 10, date), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}  and {2}) as '10-15'", between(startDate, endDate), getExperience(10, 15, date), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}  and {2}) as '15-20'", between(startDate, endDate), getExperience(15, 20, date), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}  and {2}) as '20+'", between(startDate, endDate), getExperience(" > 19", date), title));
                sb.Append(String.Format(" from dbo.Teachers where {0} and {1}", between(startDate, endDate), title));

                return sb.ToString();
            }

            public static DataSet getExperience(DateTime startDate, DateTime endDate)
            {
                //string result = "SELECT COUNT(*) as Всего,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3) as '3' 
                //,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5) as '3-5'
                //,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10) as '5-10'
                //,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15) as '10-15'
                //,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20) as '15-20'
                //,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19) as '20+' FROM Teachers 
                //union all SELECT COUNT(*) as Всего,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3 and Dekan_Faculties is not null) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5 and Dekan_Faculties is not null) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10 and Dekan_Faculties is not null),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15 and Dekan_Faculties is not null),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20 and Dekan_Faculties is not null),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19 and Dekan_Faculties is not null) FROM Teachers where Dekan_Faculties is not null  union all SELECT COUNT(*) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 1 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 1 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 1 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 1 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 1 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 1 ) FROM Teachers where Job_title = 1 union all SELECT COUNT(*),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 2 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 2 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 2 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 2 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 2 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 2 ) FROM Teachers where Job_title = 2 union all SELECT COUNT(*),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 3 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 3) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 3 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 3 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 3 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 3 ) FROM Teachers where Job_title = 3 union all SELECT COUNT(*) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 4 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 4) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 4 ), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 4 ), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 4 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 4 ) FROM  Teachers where Job_title = 4 union all SELECT COUNT(*),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 3 and (Job_title = 5 or Job_title = 6 )) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 5 and (Job_title = 5 or Job_title = 6 )) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 10 and (Job_title = 5 or Job_title = 6 ) ), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 15 and (Job_title = 5 or Job_title = 6 )), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))< 20 and (Job_title = 5 or Job_title = 6 ) ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,experience_date,CAST(Getdate() AS Date))> 19 and (Job_title = 5 or Job_title = 6 ) ) FROM Teachers where (Job_title = 5 or Job_title = 6 )";       
                //return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
                
                StringBuilder sb = new StringBuilder();
                sb.Append(queryWithTitles(startDate, endDate, "experience_date"));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, " Dekan_Faculties is not null ", "experience_date"));
                for (int i = 1; i < 5; i++)
                {
                    sb.Append(" union all ");
                    sb.Append(queryWithTitles(startDate, endDate, "Job_title = " + i, "experience_date"));
                }
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, "(Job_title = 5 or Job_title = 6)", "experience_date"));

                return NDataAccess.DataAccess.GetDataSet(@sb.ToString(), "Table1", connectionString);
            }
            public static DataSet getTotalExperience(DateTime startDate, DateTime endDate)
            {
                //string result = "SELECT COUNT(*) as Всего,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3) as '3' ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5) as '3-5',(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10) as '5-10',(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15) as '10-15',(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20) as '15-20',(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19) as '20+' FROM Teachers union all SELECT COUNT(*) as Всего,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3 and Dekan_Faculties is not null) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5 and Dekan_Faculties is not null) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10 and Dekan_Faculties is not null),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15 and Dekan_Faculties is not null),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20 and Dekan_Faculties is not null),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19 and Dekan_Faculties is not null) FROM Teachers where Dekan_Faculties is not null  union all SELECT COUNT(*) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 1 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 1 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 1 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 1 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 1 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 1 ) FROM Teachers where Job_title = 1 union all SELECT COUNT(*),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 2 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 2 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 2 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 2 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 2 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 2 ) FROM Teachers where Job_title = 2 union all SELECT COUNT(*),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 3 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 3) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 3 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 3 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 3 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 3 ) FROM Teachers where Job_title = 3 union all SELECT COUNT(*) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3 and Job_title = 4 ) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5 and Job_title = 4) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10 and Job_title = 4 ), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15 and Job_title = 4 ), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20 and Job_title = 4 ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19 and Job_title = 4 ) FROM  Teachers where Job_title = 4 union all SELECT COUNT(*),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 3 and (Job_title = 5 or Job_title = 6 )) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>2 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 5 and (Job_title = 5 or Job_title = 6 )) ,(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>4 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 10 and (Job_title = 5 or Job_title = 6 ) ), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>9 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 15 and (Job_title = 5 or Job_title = 6 )), (select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))>14 and DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))< 20 and (Job_title = 5 or Job_title = 6 ) ),(select COUNT(*) from dbo.Teachers where DATEDIFF(YY,total_experience_date,CAST(Getdate() AS Date))> 19 and (Job_title = 5 or Job_title = 6 ) ) FROM Teachers where (Job_title = 5 or Job_title = 6 )";
                //return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);

                StringBuilder sb = new StringBuilder();
                sb.Append(queryWithTitles(startDate, endDate, "total_experience_date"));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, " Dekan_Faculties is not null ", "total_experience_date"));
                for (int i = 1; i < 5; i++)
                {
                    sb.Append(" union all ");
                    sb.Append(queryWithTitles(startDate, endDate, "Job_title = " + i, "total_experience_date"));
                }
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, "(Job_title = 5 or Job_title = 6)", "total_experience_date"));
                return NDataAccess.DataAccess.GetDataSet(@sb.ToString(), "Table1", connectionString);
            }
        }//Распределение персонала по стажу работы 

        public static class AgeStructure
        {
            private static string birthdayFirst(int YY)
            {
                return " DATEDIFF(YY,birthday,CAST(Getdate() AS Date))< "+YY;
            }

            private static string birthdayBetween(int YY)
            {
                return String.Format(" DATEDIFF(YY,birthday,CAST(Getdate() AS Date))>{0} and DATEDIFF(YY,birthday,CAST(Getdate() AS Date))< {1}", YY - 1, YY + 5);
            }
            private static string birthdayBetweenLast(int YY)
            {
                return String.Format(" DATEDIFF(YY,birthday,CAST(Getdate() AS Date))>{0}", YY - 1);
            }

            private static string allTitles(DateTime startDate, DateTime endDate)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 25'", birthdayFirst(25), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 25-29'", birthdayBetween(25), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 30-34'", birthdayBetween(30), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 35-39'", birthdayBetween(35), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 40-44'", birthdayBetween(40), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 45-49'", birthdayBetween(45), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 50-54'", birthdayBetween(50), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 55-59'", birthdayBetween(55), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as 'менее 60-64'", birthdayBetween(60), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1}) as '65 и более'", birthdayBetweenLast(65), between(startDate, endDate)));
                sb.Append(String.Format(" from dbo.Teachers where {0}", between(startDate, endDate)));

                return sb.ToString();
            }

            private static string allTitlesWoomen(DateTime startDate, DateTime endDate)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 25'", birthdayFirst(25), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 25-29'", birthdayBetween(25), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 30-34'", birthdayBetween(30), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 35-39'", birthdayBetween(35), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 40-44'", birthdayBetween(40), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 45-49'", birthdayBetween(45), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 50-54'", birthdayBetween(50), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 55-59'", birthdayBetween(55), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as 'менее 60-64'", birthdayBetween(60), between(startDate, endDate)));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and  gender like 'Жен') as '65 и более'", birthdayBetweenLast(65), between(startDate, endDate)));
                sb.Append(String.Format(" from dbo.Teachers where {0}", between(startDate, endDate)));

                return sb.ToString();
            }

            private static string queryWithTitles(DateTime startDate, DateTime endDate,string title)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT COUNT(*) as Всего");
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 25'", birthdayFirst(25), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 25-29'", birthdayBetween(25), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 30-34'", birthdayBetween(30), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 35-39'", birthdayBetween(35), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 40-44'", birthdayBetween(40), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 45-49'", birthdayBetween(45), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 50-54'", birthdayBetween(50), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 55-59'", birthdayBetween(55), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as 'менее 60-64'", birthdayBetween(60), between(startDate, endDate), title));
                sb.Append(String.Format(",(select COUNT(*) from dbo.Teachers where {0} and {1} and {2}) as '65 и более'", birthdayBetweenLast(65), between(startDate, endDate), title));
                sb.Append(String.Format(" from dbo.Teachers where {0} and {1}", between(startDate, endDate), title));

                return sb.ToString();
            }


            public static DataSet getAge(DateTime startDate, DateTime endDate)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(allTitles(startDate, endDate));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, " Dekan_Faculties is not null "));
                for (int i = 1; i < 5; i++)
                {
                    sb.Append(" union all ");
                    sb.Append(queryWithTitles(startDate, endDate, "Job_title = " + i));
                }
                sb.Append(" union all ");
                sb.Append(queryWithTitles( startDate, endDate, "(Job_title = 5 or Job_title = 6)"));
                
                return NDataAccess.DataAccess.GetDataSet(@sb.ToString(), "Table1", connectionString);
            }
            public static DataSet getAgeFemale(DateTime startDate, DateTime endDate)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(allTitlesWoomen(startDate, endDate));
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, " (Dekan_Faculties is not null) and  (gender like 'Жен') "));
                for (int i = 1; i < 5; i++)
                {
                    sb.Append(" union all ");
                    sb.Append(queryWithTitles(startDate, endDate, "(gender like 'Жен') and Job_title = " + i));
                }
                sb.Append(" union all ");
                sb.Append(queryWithTitles(startDate, endDate, " (gender like 'Жен') and (Job_title = 5 or Job_title = 6)"));
                return NDataAccess.DataAccess.GetDataSet(sb.ToString(), "Table1", connectionString);
            }
        }//Распределение персонала по полу и возрасту 
        








        public static class Teachers
        {
            public static DataSet getCair(int cair)
            {
                //string result = "select f.id,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,birthday as 'Дата рождения',telephone as Телефон,d.name as 'ученое звание',titles_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',degress_date as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.' from Teachers as f , Working_positions as w,Titles as d,Degrees as a  where f.Job_title = w.id and f.titles_id=d.id and f.degrees_id = a.id and Cairs =" + cair;
                string result = "select f.id,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,convert(VARCHAR(10),birthday,105) as 'Дата рождения',d.name as 'ученое звание',convert(VARCHAR(10),titles_date,105) as 'Дата получения ученого звания',a.second_name as 'ученая степень',convert(VARCHAR(10),degress_date,105) as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.' from Teachers as f  left join  Working_positions as w on w.id=f.Job_title  left join  Titles as d on d.id = f.titles_id  left join  Degrees as a on a.id = f.degrees_id  where Cairs =" + cair + " and f.enable > 0";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getTeachers()//Главная таблица
            {
                //string result = "select f.id,c.name as Кафедра,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,gender as Пол,birthday as 'Дата рождения',passport_serial as 'Серия паспорта',passport_number as 'Номер паспорта',passport_gives as 'Кем выдан',passport_create as 'Когда выдан',registration as 'Прописка',telephone as Телефон,educational_institution as 'Образовательное учреждение',specialty_of_diplom as 'Специальность по диплому',d.name as 'ученое звание',degress_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',titles_date as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.',competitive_selection_start_date as 'Начало кон. отб',competitive_selection_end_date as 'Окончание кон. отб.',Training_dates as 'Повышения квалификации',rate as 'Ставка',total_experience_date as 'Стаж',experience_date as 'Дата, педагогический стаж' from Teachers as f , cairs as c, Working_positions as w,Titles as d,Degrees as a where f.cairs = c.id and f.Job_title = w.id and f.titles_id=d.id and f.degrees_id = a.id";
                string result = "select f.id,c.name as Кафедра,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,gender as Пол,convert(VARCHAR(10),birthday,105) as 'Дата рождения',passport_serial as 'Серия паспорта',passport_number as 'Номер паспорта',passport_gives as 'Кем выдан',convert(VARCHAR(10),passport_create,105) as 'Когда выдан',registration as 'Прописка',telephone as Телефон,educational_institution as 'Образовательное учреждение',specialty_of_diplom as 'Специальность по диплому', d.name as 'ученое звание',convert(VARCHAR(10),titles_date,105) as 'Дата получения ученого звания',a.second_name as 'ученая степень',convert(VARCHAR(10),degress_date,105) as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.',convert(VARCHAR(10),competitive_selection_start_date,105) as 'Начало кон. отб',convert(VARCHAR(10),competitive_selection_end_date,105) as 'Окончание кон. отб.',convert(VARCHAR(10),Training_dates,105) as 'Повышения квалификации',rate as 'Ставка',convert(VARCHAR(10),total_experience_date,105) as 'Стаж',convert(VARCHAR(10),experience_date,105) as 'Дата, педагогический стаж' ,convert(VARCHAR(10),education_date,105) as 'Дата трудоустройства' from Teachers as f left join cairs as c on c.id=f.Cairs left join  Working_positions as w on w.id=f.Job_title left join Titles as d on d.id=f.titles_id left join Degrees as a on a.id = f.degrees_id where f.Cairs is not null and f.enable > 0";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            public static DataSet getTeachersDekans()//Главная таблица
            {
                //string result = "select f.id,dek.second_name as Факультет,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,gender as Пол,birthday as 'Дата рождения',passport_serial as 'Серия паспорта',passport_number as 'Номер паспорта',passport_gives as 'Кем выдан',passport_create as 'Когда выдан',registration as 'Прописка',telephone as Телефон,educational_institution as 'Образовательное учреждение',specialty_of_diplom as 'Специальность по диплому',d.name as 'ученое звание',degress_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',convert(VARCHAR(10),titles_date,105) as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.',competitive_selection_start_date as 'Начало кон. отб',competitive_selection_end_date as 'Окончание кон. отб.',Training_dates as 'Повышения квалификации',rate as 'Ставка',total_experience_date as 'Стаж',experience_date as 'Дата, педагогический стаж' from Teachers as f , Faculties as dek,Titles as d,Degrees as a where f.Dekan_Faculties = dek.id  and f.titles_id=d.id and f.degrees_id = a.id";
                string result = "select f.id,dek.second_name as Факультет,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,gender as Пол,convert(VARCHAR(10),birthday,105) as 'Дата рождения',passport_serial as 'Серия паспорта',passport_number as 'Номер паспорта',passport_gives as 'Кем выдан',convert(VARCHAR(10),passport_create,105) as 'Когда выдан',registration as 'Прописка',telephone as Телефон,educational_institution as 'Образовательное учреждение',specialty_of_diplom as 'Специальность по диплому',d.name as 'ученое звание',convert(VARCHAR(10),titles_date,105) as 'Дата получения ученого звания',a.second_name as 'ученая степень',convert(VARCHAR(10),degress_date,105) as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.',convert(VARCHAR(10),competitive_selection_start_date,105) as 'Начало кон. отб',convert(VARCHAR(10),competitive_selection_end_date,105) as 'Окончание кон. отб.',convert(VARCHAR(10),Training_dates,105) as 'Повышения квалификации',rate as 'Ставка',convert(VARCHAR(10),total_experience_date,105) as 'Стаж',convert(VARCHAR(10),experience_date,105) as 'Дата, педагогический стаж' from Teachers as f  left join dbo.Faculties as dek on dek.id = f.Dekan_Faculties left join Titles as d on d.id=f.titles_id left join Degrees as a on a.id = f.degrees_id where f.Cairs is null and f.enable > 0";
                return NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            }
            //public static DataSet getTeachersEdit()//Главная таблица
            //{
            //    string result = "select f.id,c.name as Кафедра,w.name as Должность,f.surname as Фамилия,f.name as Имя,f.middlename as Отчество,gender as Пол,birthday as 'Дата рождения',passport_serial as 'Серия паспорта',passport_number as 'Номер паспорта',passport_gives as 'Кем выдан',passport_create as 'Когда выдан',registration as 'Прописка',telephone as Телефон,educational_institution as 'Образовательное учреждение',specialty_of_diplom as 'Специальность по диплому',d.name as 'ученое звание',degress_date as 'Дата получения ученого звания',a.second_name as 'ученая степень',titles_date as 'Дата получения ученой степени',terms_of_work as 'Условия привлечения к труд. деят.',competitive_selection_start_date as 'Начало кон. отб',competitive_selection_end_date as 'Окончание кон. отб.',Training_dates as 'Повышения квалификации',rate as 'Ставка',total_experience_date as 'Стаж',experience_date as 'Дата, педагогический стаж',Dekan_Faculties as 'Декан' from Teachers as f , cairs as c, Working_positions as w,Titles as d,Degrees as a,Faculties as dek where f.cairs = c.id and f.Job_title = w.id and f.titles_id=d.id and f.degrees_id = a.id and f.Dekan_Faculties=dec.id";
            //    return  NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
            //}
            public static DataSet getSecondNameCairs()//Сокращенные кафедры
            {
                return  NDataAccess.DataAccess.GetDataSet(@"select second_name from dbo.Cairs", "Table1", connectionString);
            }
            public static DataSet getJobTitles()//Должность
            {
                return  NDataAccess.DataAccess.GetDataSet(@"select name from dbo.Working_positions", "Table1", connectionString);

            }
            public static DataSet getScientificDegrees()//Ученые степени
            {
                return  NDataAccess.DataAccess.GetDataSet(@"select name from dbo.Titles", "Table1", connectionString);

            }
            public static DataSet getAcademicTitle()//Ученые звания
            {
                return  NDataAccess.DataAccess.GetDataSet(@"select second_name from dbo.Degrees", "Table1", connectionString);

            }
            public static string getCountRows()//Количество строк в таблице
            {
                ds = NDataAccess.DataAccess.GetDataSet(@"select max(id) as count from dbo.Teachers", "Table1", connectionString);
                string result = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                if(result=="")result= "0";
                return (result);
            }
            public static void insertPerson(string values)//Добавление преподователя
            {
                string head = "id,Cairs,Job_title,surname,name,middlename,gender,birthday,passport_serial,passport_number,passport_gives,passport_create,registration,telephone,educational_institution,specialty_of_diplom,titles_id,titles_date,degrees_id,degress_date,terms_of_work,competitive_selection_start_date,competitive_selection_end_date,rate,experience_date,Training_dates,total_experience_date,education_date,enable,start_date";
                string result = "INSERT INTO dbo.Teachers (" + head + ") values " + values;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void updatePerson(string values, int id)//Добавление преподователя
            {
                string result = "UPDATE dbo.Teachers SET " + values + " where id = " + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void updateEndDate(string endDate, int id)//Добавление преподователя
            {
                string result = "UPDATE dbo.Teachers SET end_date='" + endDate + "' where id = " + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void insertDecan(string values)//Добавление преподователя
            {
                string head = "id,surname,name,middlename,gender,birthday,passport_serial,passport_number,passport_gives,passport_create,registration,telephone,educational_institution,specialty_of_diplom,titles_id,titles_date,degrees_id,degress_date,terms_of_work,competitive_selection_start_date,competitive_selection_end_date,rate,experience_date,Training_dates,total_experience_date,Dekan_Faculties,education_date,enable,start_date";
                string result = "INSERT INTO dbo.Teachers (" + head + ") values " + values;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void updateDecan(string values,int id)//Добавление преподователя
            {
                string result = "UPDATE dbo.Teachers SET " + values + " where id = " + id;
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }

            public static void InsertTeachers(string result)//Добавление преподователя
            {
                NDataAccess.DataAccess.ExecuteNonQuery2(result, connectionString);
            }
            public static void InsertTest(string insert)
            {
                NDataAccess.DataAccess.ExecuteNonQuery2(insert, connectionString);
            }
            public static int getCairs(string cair)//Получаем id для главной таблицы
            {
                string result = "select id from dbo.Cairs where second_name = '" + cair + "'";
                ds = NDataAccess.DataAccess.GetDataSet(@result, "Table1", connectionString);
                return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            public static void disableRow(int id)//Удалим преподавателя(строку)
            {
                NDataAccess.DataAccess.ExecuteNonQuery2("UPDATE dbo.Teachers SET enable = 0 where id = " + id, connectionString);
            }
            public static void dellRow(int id)//Удалим преподавателя(строку)
            {
                NDataAccess.DataAccess.ExecuteNonQuery2("delete from dbo.Teachers where id = "+id, connectionString);
            }
            public static DataSet getDekanFaculties()
            {
                return  NDataAccess.DataAccess.GetDataSet(@"select second_name from dbo.Faculties", "Table1", connectionString);
            }
        }//Класс работы с главной таблицей
    }
}
