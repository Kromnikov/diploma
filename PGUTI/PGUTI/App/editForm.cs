using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGUTI
{
    public partial class EditForm : Form
    {
        private static int id;
        public DataSet person;//Объект сотрудника с его данными
        private bool edit = false;//Редактируем?
        private bool dekan = false;//Декан?

        public EditForm(bool edit,DataSet person,bool dekan)//Конструктор
        {//Присваеваем полям данного класса(this.*) входные данные конструктора bool edit,DataSet person,bool dekan
            this.edit = edit;
            this.person = person;
            this.dekan = dekan;
            InitializeComponent();
        }
        public EditForm(bool edit)
        {
            this.edit = edit;
            InitializeComponent();
        }
        #region plaseholders
        //private string copyText = "";
        public void TextGotFocus(object sender , EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            //if (tb.Text == "Телефон...")
           if (tb.Text.Contains("..."))
            {
                //copyText = tb.Text;
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        public void TelephoneLostFocus(object sender , EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                //tb.Text = copyText;
                tb.Text = "Телефон...";
                tb.ForeColor = Color.DimGray;
            }
            //MessageBox.Show(sender.ToString());
        }
        public void EducationaLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Учреждение...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void SpecialtyLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Специальность...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void SerialLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Серия...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void NumberLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Номер...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void PasportDataLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Кем выдан паспорт...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void SurnameDataLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Фамилия...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void NameLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Имя...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void MiddleNameLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Отчество...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void RegistrationLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Прописка...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void RateLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Ставка...";
                tb.ForeColor = Color.DimGray;
            }
        }
        public void TrainingDatesTextBoxLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Место проведения...";
                tb.ForeColor = Color.DimGray;
            }
        }
        #endregion
        private void editForm_Load(object sender, EventArgs e)
        {
            TelephoneTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            TelephoneTextBox.LostFocus += new EventHandler(this.TelephoneLostFocus);

            EducationalInstitutionTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            EducationalInstitutionTextBox.LostFocus += new EventHandler(this.EducationaLostFocus);

            SpecialtyDiplomTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            SpecialtyDiplomTextBox.LostFocus += new EventHandler(this.SpecialtyLostFocus);

            SerialTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            SerialTextBox.LostFocus += new EventHandler(this.SerialLostFocus);

            NumberTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            NumberTextBox.LostFocus += new EventHandler(this.NumberLostFocus);

            PasportDataTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            PasportDataTextBox.LostFocus += new EventHandler(this.PasportDataLostFocus);

            SurnameTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            SurnameTextBox.LostFocus += new EventHandler(this.SurnameDataLostFocus);

            NameTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            NameTextBox.LostFocus += new EventHandler(this.NameLostFocus);

            MiddleNameTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            MiddleNameTextBox.LostFocus += new EventHandler(this.MiddleNameLostFocus);

            RegistrationTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            RegistrationTextBox.LostFocus += new EventHandler(this.RegistrationLostFocus);

            Rate.GotFocus += new EventHandler(this.TextGotFocus);
            Rate.LostFocus += new EventHandler(this.RateLostFocus);

            TrainingDatesTextBox.GotFocus += new EventHandler(this.TextGotFocus);
            TrainingDatesTextBox.LostFocus += new EventHandler(this.TrainingDatesTextBoxLostFocus);

            //Заполняем все ComboBox'ы
            CairComboBox.DataSource = Data.Teachers.getSecondNameCairs().Tables[0];
            CairComboBox.DisplayMember = "second_name";

            JobTitleComboBox.DataSource = Data.Teachers.getJobTitles().Tables[0];
            JobTitleComboBox.DisplayMember = "name";

            ScientificDegreeComboBox.DataSource = Data.Teachers.getScientificDegrees().Tables[0];
            ScientificDegreeComboBox.DisplayMember = "name";

            AcademicTitleComboBox.DataSource = Data.Teachers.getAcademicTitle().Tables[0];
            AcademicTitleComboBox.DisplayMember = "second_name";

            FacultiesComboBox.DataSource = Data.Teachers.getDekanFaculties().Tables[0];
            FacultiesComboBox.DisplayMember = "second_name";

            //Выставляем значения по умолчанию
            GenderComboBox.SelectedItem = "Муж";

            TermWorksComboBox.SelectedItem = "Штатный сотрудник";

            AcceptedComboBox.SelectedItem = "Приняли";

            if (edit)//Если редактируем, тогда из объекта person(который мы предели в контсрукторе) выбираем все стандартные значения для каждого элемента на форме
            {

                string[] TermWorks = person.Tables[0].Rows[0].ItemArray[20].ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries); ;
                
                changeButton.Text = "Сохранить изменения";

                id = (int)person.Tables[0].Rows[0].ItemArray[0];

                if (!dekan)//Если сотрудник не я вляеться деканом, то заполняем у него дополнительные две строки
                {

                    CairComboBox.SelectedIndex = (int)person.Tables[0].Rows[0].ItemArray[1] - 1; //(Data.editForm.getCair(id) - 1);

                    JobTitleComboBox.SelectedIndex = (int)person.Tables[0].Rows[0].ItemArray[2] - 1;

                }
                else {
                    DekanСheckBox.Checked = true;
                    FacultiesComboBox.SelectedIndex = (int)person.Tables[0].Rows[0].ItemArray[25]-1;
                }

                ScientificDegreeComboBox.SelectedIndex = (int)person.Tables[0].Rows[0].ItemArray[16] - 1;

                if (person.Tables[0].Rows[0].ItemArray[17].ToString()!="")
                TitlesDateTimePicker.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[17];

                AcademicTitleComboBox.SelectedIndex = (int)person.Tables[0].Rows[0].ItemArray[18] - 1;

                if(person.Tables[0].Rows[0].ItemArray[19].ToString()!="")
                DegreesTimePicker2.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[19];

                EducationalInstitutionTextBox.Text = person.Tables[0].Rows[0].ItemArray[14].ToString();

                SpecialtyDiplomTextBox.Text = person.Tables[0].Rows[0].ItemArray[15].ToString();

                SerialTextBox.Text = person.Tables[0].Rows[0].ItemArray[8].ToString();

                NumberTextBox.Text = person.Tables[0].Rows[0].ItemArray[9].ToString();

                PasportDataTextBox.Text = person.Tables[0].Rows[0].ItemArray[10].ToString();

                PasportDateTimePicker.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[11];

                SurnameTextBox.Text = person.Tables[0].Rows[0].ItemArray[3].ToString();

                NameTextBox.Text = person.Tables[0].Rows[0].ItemArray[4].ToString();

                MiddleNameTextBox.Text = person.Tables[0].Rows[0].ItemArray[5].ToString();

                GenderComboBox.SelectedItem = person.Tables[0].Rows[0].ItemArray[6].ToString();//!тута както надо по другому

                birthdayTimePicker.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[7];

                RegistrationTextBox.Text = person.Tables[0].Rows[0].ItemArray[12].ToString();

                TelephoneTextBox.Text = person.Tables[0].Rows[0].ItemArray[13].ToString();

                TermWorksComboBox.Text = TermWorks[0];// person.Tables[0].Rows[0].ItemArray[20].ToString();

                CompetitiveSelectionStartDate.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[21];

                CompetitiveSelectionEndDate.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[22];

                Rate.Text = person.Tables[0].Rows[0].ItemArray[26].ToString();

                ExperienceDate.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[23];

                TotalExperienceDateTimePicker.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[24];

                if (person.Tables[0].Rows[0].ItemArray[27].ToString() != "")
                {
                    TrainingDatesTimePicker.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[27];
                }

                if (person.Tables[0].Rows[0].ItemArray[28].ToString() != "")
                    education_dateTimePicker1.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[28];

                if (person.Tables[0].Rows[0].ItemArray[33].ToString() != "")
                {
                    TrainingDatesTextBox.Text = person.Tables[0].Rows[0].ItemArray[33].ToString();
                }
                if (person.Tables[0].Rows[0].ItemArray[32].ToString() != "")
                {
                    TrainingDatesEndTimePicker.Value = (DateTime)person.Tables[0].Rows[0].ItemArray[32];
                }
            }

        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (Correct())//Проверяем корректность введённых данных
            {
                if (edit) updatePerson();//Метод редактирования
                else insertPerson();//Метод добавления в базу
                this.Close();//Закрываем форму
            }
            else { MessageBox.Show("Не все поля заполнены правильно"); }
        }

        private static string[] rates;string rate;//Переменные ставок
        private static string titlesDate = null;
        private static string degressDate = null;
        private static string education_date = null;
        private void insertPerson()
        {
            SplitAndCheck();//Метод для коррекции введённого значения ставки и даты
            if (DekanСheckBox.Checked)//Если добавляем декана
            {
                Data.Teachers.insertDecan(getValuesInsertPersonDekan());
            }
            else//Иначе
            {
                Data.Teachers.insertPerson(getValuesInsertPerson());
            }
            recordAdd(id);//Метод добавления в таблицу Records
        }
        private void updatePerson()
        {
            string result = "";
            SplitAndCheck();//Метод для коррекции введённого значения ставки и даты
            if (DekanСheckBox.Checked)
            {
                Data.Teachers.updateDecan(getValuesUpdatePersonDekan(), id);
            }
            else
                Data.Teachers.updatePerson(getValuesUpdatePerson(), id);
            //Data.Teachers.InsertTeachers(result.ToString());//Метод для вставки записей в таблицу Teachers
            if (AcceptedComboBox.SelectedIndex == 2)
            {
                recordDel();
                Data.Teachers.updateEndDate(Data.ReverseDateTime(ExperienceDate.Value.Date), id);
            }
            else
                recordAdd(id);//Метод добавления в таблицу Records
        }
        private void SplitAndCheck()//Метод для коррекции введённого значения ставки и даты
        {
            rates = Rate.Text.Split(new Char[] { '.', ',' });//Разбираем строку по разделителю ('.'или',')
            if (rates.Length > 1) rate = (rates[0] + "." + rates[1]);//если стоит разделитель, значит собираем строку с точкой для запроса в базу (с запятой запрос не будет работать, поэтому нужна точка)
            else rate = rates[0];//если без разделителя , тогда так и оставляем

            if (ScientificDegreeComboBox.Text == "")//Если нету ученой степени
                titlesDate = "null";//То и даты получения также нету
            else titlesDate = "'" + TitlesDateTimePicker.Value.Date.ToString() + "'";

            if (AcademicTitleComboBox.Text == "")
                degressDate = "null";
            else degressDate = "'" + DegreesTimePicker2.Value.Date.ToString() + "'";

            if (TrainingDatesTextBox.Text == "Место проведения...")
                TrainingDatesTextBox.Text = "";

            if ((EducationalInstitutionTextBox.Text.Equals("Учреждение...") || EducationalInstitutionTextBox.Text.Equals("")) & (SpecialtyDiplomTextBox.Text.Equals("Специальность...") || SpecialtyDiplomTextBox.Text.Equals("")))
            {
                EducationalInstitutionTextBox.Text = "null";
                SpecialtyDiplomTextBox.Text = "null";
                education_date = "null";
            }
            else
            {
                education_date = "'" + education_dateTimePicker1.Value.Date.ToString() + "'";
            }


            TrainingChecked();
        }
        //Метод редактирования 
        private string getValuesUpdatePerson()
        {
            return "Dekan_Faculties = null," 
                +"Cairs=" + (CairComboBox.SelectedIndex + 1)
                + ",Job_title=" + (JobTitleComboBox.SelectedIndex + 1)
                + ",surname='" + SurnameTextBox.Text
                + "',name='" + NameTextBox.Text
                + "',middlename='" + MiddleNameTextBox.Text
                + "',gender='" + GenderComboBox.Text
                + "',birthday='" + Data.ReverseDateTime(birthdayTimePicker.Value.Date)
                + "',passport_serial=" + SerialTextBox.Text
                + ",passport_number=" + NumberTextBox.Text
                + ",passport_gives='" + PasportDataTextBox.Text
                + "',passport_create='" + Data.ReverseDateTime(PasportDateTimePicker.Value.Date)
                + "',registration='" + RegistrationTextBox.Text
                + "',telephone='" + TelephoneTextBox.Text
                + "',educational_institution='" + EducationalInstitutionTextBox.Text
                + "',specialty_of_diplom='" + SpecialtyDiplomTextBox.Text
                + "',titles_id=" + (ScientificDegreeComboBox.SelectedIndex + 1)
                + ",titles_date=" + titlesDate
                + ",degrees_id=" + (AcademicTitleComboBox.SelectedIndex + 1)
                + ",degress_date=" + degressDate
                + ",terms_of_work='" + TermWorksComboBox.Text + "-" + Rate.Text + "-" + AcceptedComboBox.Text + "(" + ExperienceDate.Value.Day + "." + ExperienceDate.Value.Month + "." + ExperienceDate.Value.Year + ")"
                + "',competitive_selection_start_date='" + Data.ReverseDateTime(CompetitiveSelectionStartDate.Value.Date)
                + "',competitive_selection_end_date='" + Data.ReverseDateTime(CompetitiveSelectionEndDate.Value.Date)
                + "',rate=" + rate
                + ",experience_date='" + Data.ReverseDateTime(ExperienceDate.Value.Date)
                + "',Training_dates=" + TrainingDatesStart
                + ",total_experience_date='" + Data.ReverseDateTime(TotalExperienceDateTimePicker.Value.Date)
                + "',education_date=" + education_date
            + ",Training_dates_end=" + TrainingDatesEnd
            + ",Training_place='" + TrainingDatesTex+"'";
        }
        //Метод редактирования декана
        private string getValuesUpdatePersonDekan()
        {
            return "Cairs = null," + "Job_title = null,"
                +"surname='" + SurnameTextBox.Text
                + "',name='" + NameTextBox.Text
                + "',middlename='" + MiddleNameTextBox.Text
                + "',gender='" + GenderComboBox.Text
                + "',birthday='" + Data.ReverseDateTime(birthdayTimePicker.Value.Date)
                + "',passport_serial=" + SerialTextBox.Text
                + ",passport_number=" + NumberTextBox.Text
                + ",passport_gives='" + PasportDataTextBox.Text
                + "',passport_create='" + Data.ReverseDateTime(PasportDateTimePicker.Value.Date)
                + "',registration='" + RegistrationTextBox.Text
                + "',telephone='" + TelephoneTextBox.Text
                + "',educational_institution='" + EducationalInstitutionTextBox.Text
                + "',specialty_of_diplom='" + SpecialtyDiplomTextBox.Text
                + "',titles_id=" + (ScientificDegreeComboBox.SelectedIndex + 1)
                + ",titles_date=" + titlesDate
                + ",degrees_id=" + (AcademicTitleComboBox.SelectedIndex + 1)
                + ",degress_date=" + degressDate
                + ",terms_of_work='" + TermWorksComboBox.Text + "-" + Rate.Text + "-" + AcceptedComboBox.Text + "(" + ExperienceDate.Value.Day + "." + ExperienceDate.Value.Month + "." + ExperienceDate.Value.Year + ")"
                + "',competitive_selection_start_date='" + Data.ReverseDateTime(CompetitiveSelectionStartDate.Value.Date)
                + "',competitive_selection_end_date='" + Data.ReverseDateTime(CompetitiveSelectionEndDate.Value.Date)
                + "',rate=" + rate
                + ",experience_date='" + Data.ReverseDateTime(ExperienceDate.Value.Date)
                + "',Training_dates=" + TrainingDatesStart
                + ",total_experience_date='" + Data.ReverseDateTime(TotalExperienceDateTimePicker.Value.Date)
                + "',education_date=" + education_date
                + ",Dekan_Faculties=" + (FacultiesComboBox.SelectedIndex + 1)
            +",Training_dates_end=" + TrainingDatesEnd
            + ",Training_place='" + TrainingDatesTex + "'";
        }
        //Метод добавления декана
        private string getValuesInsertPersonDekan()
        {
            id = int.Parse(Data.Teachers.getCountRows())+1;
            string val = "(" + (id)
                + ",'" + SurnameTextBox.Text
                + "','" + NameTextBox.Text
                + "','" + MiddleNameTextBox.Text
                + "','" + GenderComboBox.Text
                + "','" + Data.ReverseDateTime(birthdayTimePicker.Value.Date)
                + "'," + SerialTextBox.Text
                + "," + NumberTextBox.Text
                + ",'" + PasportDataTextBox.Text
                + "','" + Data.ReverseDateTime(PasportDateTimePicker.Value.Date)
                + "','" + RegistrationTextBox.Text
                + "','" + TelephoneTextBox.Text
                + "','" + EducationalInstitutionTextBox.Text
                + "','" + SpecialtyDiplomTextBox.Text
                + "'," + (ScientificDegreeComboBox.SelectedIndex + 1)
                + "," + titlesDate
                + "," + (AcademicTitleComboBox.SelectedIndex + 1)
                + "," +degressDate
                + ",'" + TermWorksComboBox.Text + "-" + Rate.Text + "-" + AcceptedComboBox.Text + "(" + ExperienceDate.Value.Day + "." + ExperienceDate.Value.Month + "." + ExperienceDate.Value.Year + ")"
                + "','" + Data.ReverseDateTime(CompetitiveSelectionStartDate.Value.Date)
                + "','" + Data.ReverseDateTime(CompetitiveSelectionEndDate.Value.Date)
                + "'," + rate
                + ",'" + Data.ReverseDateTime(ExperienceDate.Value.Date)
                + "'," + TrainingDatesStart
                + ",'" + Data.ReverseDateTime(TotalExperienceDateTimePicker.Value.Date)
                + "'," + (FacultiesComboBox.SelectedIndex + 1) + "," +
                education_date + ",'" +
                1 + "','" +
                Data.ReverseDateTime(ExperienceDate.Value.Date) + "',"
                + TrainingDatesEnd + ",'"
                + TrainingDatesTex + "')";
            return val;

        }
        //Метод добавления
        private string getValuesInsertPerson()
        {
            id = int.Parse(Data.Teachers.getCountRows())+1;
            return "(" + (id)
                + "," + (CairComboBox.SelectedIndex + 1)
                + "," + (JobTitleComboBox.SelectedIndex + 1)
                + ",'" + SurnameTextBox.Text
                + "','" + NameTextBox.Text
                + "','" + MiddleNameTextBox.Text
                + "','" + GenderComboBox.Text
                + "','" + Data.ReverseDateTime(birthdayTimePicker.Value.Date)
                + "'," + SerialTextBox.Text
                + "," + NumberTextBox.Text
                + ",'" + PasportDataTextBox.Text
                + "','" + Data.ReverseDateTime(PasportDateTimePicker.Value.Date)
                + "','" + RegistrationTextBox.Text
                + "','" + TelephoneTextBox.Text
                + "','" + EducationalInstitutionTextBox.Text
                + "','" + SpecialtyDiplomTextBox.Text
                + "'," + (ScientificDegreeComboBox.SelectedIndex + 1)
                + "," + titlesDate
                + "," + (AcademicTitleComboBox.SelectedIndex + 1)
                + "," + degressDate
                + ",'" + TermWorksComboBox.Text + "-" + Rate.Text + "-" + AcceptedComboBox.Text + "(" + ExperienceDate.Value.Day + "." + ExperienceDate.Value.Month + "." + ExperienceDate.Value.Year + ")"
                + "','" + Data.ReverseDateTime(CompetitiveSelectionStartDate.Value.Date)
                + "','" + Data.ReverseDateTime(CompetitiveSelectionEndDate.Value.Date)
                + "'," + rate
                + ",'" + Data.ReverseDateTime(ExperienceDate.Value.Date) + "'," +
                TrainingDatesStart + ",'" +
                Data.ReverseDateTime(TotalExperienceDateTimePicker.Value.Date) + "'," +
                education_date + ",'" +
                1 + "','" +
                Data.ReverseDateTime(ExperienceDate.Value.Date) + "',"
                + TrainingDatesEnd+ ",'"
                +TrainingDatesTex+"')";
        }


        private static string TrainingDatesTex = null;
        private static string TrainingDatesStart = null;
        private static string TrainingDatesEnd = null;

        private bool Correct()//Метод проверки корректности введённых сначений
        {
            //EducationalInstitutionTextBox.Text == "Учреждение..." || SpecialtyDiplomTextBox.Text == "Специальность..." ||
            if (SerialTextBox.Text == "Серия..." || NumberTextBox.Text == "Номер..." || SurnameTextBox.Text == "Фамилия..." || NameTextBox.Text == "Имя..." || MiddleNameTextBox.Text == "Отчество..." || TelephoneTextBox.Text == "89271112233" || RegistrationTextBox.Text == "Прописка...")
                return false;
            if (EducationalInstitutionTextBox.Text == String.Empty || SpecialtyDiplomTextBox.Text == String.Empty || SerialTextBox.Text == String.Empty || NumberTextBox.Text == String.Empty || SurnameTextBox.Text == String.Empty || NameTextBox.Text == String.Empty || MiddleNameTextBox.Text == String.Empty || RegistrationTextBox.Text == String.Empty)
                return false;

                return true;
        }

        private void recordAdd(int id)//Метод добавления в таблицу Records
        {
            Data.Record.Add(id,false,ExperienceDate.Value.Date);//Метод добавления в таблицу Records
        }

        private void recordDel()
        {
            DialogResult result = MessageBox.Show("Удалить запись?", "удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//Подтверждение
            if (result == DialogResult.Yes)//Если подтвердили
            {
                Data.Record.Add(id,true, ExperienceDate.Value.Date);//Добавляем запись в таблицу Records
                Data.Teachers.disableRow(id);//Выбираем из выбранной строки первый столбец и передаём его значение в метод удаления записи
            }
        }

        private void DekanСheckBox_CheckedChanged(object sender, EventArgs e)//При нажатии на CheckBox 'декан'
        {
            if (DekanСheckBox.Checked)//Если выбран декан, скрываем должность и кафедру, показываем факультеты
            {
                JobTitleComboBox.Visible = false;
                CairComboBox.Visible = false;
                FacultiesComboBox.Visible = true;
            }
            else//тут всё наоборот
            {
                JobTitleComboBox.Visible = true;
                CairComboBox.Visible = true;
                FacultiesComboBox.Visible = false;
            }
        }

        private void EducationalInstitutionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void education_dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TrainingChecked();
        }

        private void TrainingChecked()
        {
            if (TrainingcheckBox1.Checked)
            {
                groupBox8.Enabled = true;
                TrainingDatesStart = "'"+Data.ReverseDateTime(TrainingDatesTimePicker.Value.Date)+"'";
                TrainingDatesEnd = "'" + Data.ReverseDateTime(TrainingDatesEndTimePicker.Value.Date)+"'";
                TrainingDatesTex = TrainingDatesTextBox.Text;
            }
            else
            {
                groupBox8.Enabled = false;
                TrainingDatesTex = null;
                TrainingDatesStart = "null";
                TrainingDatesEnd = "null";
            }
        }
    }
}
