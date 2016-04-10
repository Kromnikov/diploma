using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace PGUTI.TEST
{
    class TESTData
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Pguti.Connection"].ConnectionString;//Строка подключения к базе , из файла конфигурации

        private static DataSet ds = new DataSet();//Объект запроса


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
        

    }
}
