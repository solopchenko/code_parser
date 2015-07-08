using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home_finance.Database;

namespace Home_finance
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }
        //Загрузчик формы
        private void Main_form_Load(object sender, EventArgs e)
        {
            //Отображение имени и логина пользователя, вошедшего в систему
            CurrentUser_label.Text = "Ваш логин: " + CurrentUser.GetLogin();

            //Отображение вкладки управления пользователями для администратора
            if (CurrentUser.GetLogin() == "admin")
            {
                string sqlQuery = "SELECT Id, Name FROM [Users]";
                Functions.FillComboBoxWithAll(sqlQuery, Name_comboBox, "Id", "Name");
                Name_comboBox.Enabled = true;
            }
            else
            {
                string sqlQuery = string.Format("SELECT Id, Name FROM [Users] AS usr WHERE usr.Login = N'{0}'", CurrentUser.GetLogin());
                Functions.FillComboBox(sqlQuery, Name_comboBox, "Id", "Name");
                Name_comboBox.Enabled = false;
            }

            //Отображение доходов пользователя, вошедшего в систему
            LoadIncomes();
        }

        //Отображение доходов пользователя, вошедшего в систему
        private void LoadIncomes()
        {
            Add_btn.Enabled = true;
            Save_changes_btn.Enabled = true;
            Delete_btn.Enabled = true;
            Export_btn.Enabled = true;
            Print_btn.Enabled = true;

            SqlServer sql = new SqlServer();

            if (CurrentUser.GetLogin() == "admin")
            {
                //Вывод информации обо всех пользователях
                if (Name_comboBox.SelectedIndex.ToString() == "0")
                {
                    string sqlQuery = "SELECT inc.Id AS 'Номер', usr.Name AS 'Имя', inc.Date AS 'Дата', " +
                                 "cat.Name AS 'Категория', inc.Value AS 'Сумма', inc.Description AS 'Описание' " +
                                 "FROM [Users] AS usr INNER JOIN [Incomes] AS inc ON usr.Id = inc.User_id " +
                                 " INNER JOIN [Categories] AS cat ON cat.Id = inc.Category_id";
                    Incomes_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Вывод статистики по доходам
                    Stat1_label.Text = "Доходы за выбанный период: статистика недоступна.";
                    Stat2_label.Text = "Доходы за месяц: статистика недоступна.";
                    Stat3_label.Text = "Доходы за неделю: статистика недоступна.";
                    From_dateTimePicker.Enabled = false;
                    To_dateTimePicker.Enabled = false;
                    Save_changes_btn.Enabled = false;
                    //Вывод статистики по планированию
                    Message_richTextBox.Text = string.Empty;
                }
                //Вывод информациии о выбраном пользователе в Name_comboBox
                else
                {
                    string sqlQuery = string.Format("SELECT inc.Id AS 'Номер', usr.Name AS 'Имя', inc.Date AS 'Дата', " +
                                 "cat.Name AS 'Категория', inc.Value AS 'Сумма', inc.Description AS 'Описание' " +
                                 "FROM [Users] AS usr INNER JOIN [Incomes] AS inc ON usr.Id = inc.User_id " +
                                 " INNER JOIN [Categories] AS cat ON cat.Id = inc.Category_id WHERE usr.Id = '{0}'", Name_comboBox.SelectedValue);
                    Incomes_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Вывод статистики по доходам
                    Stat1_label.Text = "Доходы за выбранный период: " + StatIncomes(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                    Stat2_label.Text = "Доходы за месяц: " + StatIncomes(DateTime.Now.Date.AddMonths(-1).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                    Stat3_label.Text = "Доходы за неделю: " + StatIncomes(DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                    From_dateTimePicker.Enabled = true;
                    To_dateTimePicker.Enabled = true;
                    Save_changes_btn.Enabled = true;
                    //Вывод статистики по планированию
                    StatPlaning();
                }
            }
            //Вывод информации о текущем пользователе
            else
            {
                string sqlQuery = string.Format("SELECT inc.Id AS 'Номер', usr.Name AS 'Имя', inc.Date AS 'Дата', " +
                                    "cat.Name AS 'Категория', inc.Value AS 'Сумма', inc.Description AS 'Описание' " +
                                    "FROM [Users] AS usr INNER JOIN [Incomes] AS inc ON usr.Id = inc.User_id "
                                    + " INNER JOIN [Categories] AS cat ON cat.Id = inc.Category_id WHERE usr.Login = '{0}'", CurrentUser.GetLogin());
                Incomes_dgv.DataSource = sql.ExcuteData(sqlQuery);
                //Скрытие имени пользователя для неадминистратора
                Incomes_dgv.Columns[1].Visible = false;
                //Вывод статистики по доходам
                Stat1_label.Text = "Доходы за выбранный период: " + StatIncomes(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                Stat2_label.Text = "Доходы за месяц: " + StatIncomes(DateTime.Now.Date.AddMonths(-1).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                Stat3_label.Text = "Доходы за неделю: " + StatIncomes(DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                From_dateTimePicker.Enabled = true;
                To_dateTimePicker.Enabled = true;
                Save_changes_btn.Enabled = true;
                //Вывод статистики по планированию
                StatPlaning();
            }
            Incomes_dgv.Columns[0].Visible = false;

            //Нельзя редактировать имя пользователя
            Incomes_dgv.Columns[1].ReadOnly = true;

            //Формат столбца с суммой (2 знака после запятой)
            DataGridViewCellStyle dec = new DataGridViewCellStyle();
            dec.Format = "N2";
            Incomes_dgv.Columns["Сумма"].DefaultCellStyle = dec;
        }
        //Статистика по доходам
        private string StatIncomes(string StartDate, string EndDate)
        {
            SqlServer sql = new SqlServer();
            decimal sum = 0;

            string sqlQuery = string.Format("SELECT inc.Value AS 'Сумма' " +
                            "FROM [Incomes] AS inc WHERE (inc.User_id = '{0}') AND (inc.Date >= '{1}') AND (inc.Date <= '{2}')",
                            Name_comboBox.SelectedValue, StartDate, EndDate);

            //Расчет суммы доходов
            DataTable dtbl = sql.ExcuteData(sqlQuery);
            for (int r = 0; r <= dtbl.Rows.Count - 1; r++)
            {
                for (int c = 0; c <= dtbl.Columns.Count - 1; c++)
                {
                    sum = sum + Convert.ToDecimal(dtbl.Rows[r][c]);
                }
            }
            return Convert.ToString(sum);
        }
        //Редактирование доходов
        private void EditIncomes()
        {
            SqlServer sql = new SqlServer();
            string upd_inc_id = string.Empty;
            int upd_inc_index = -1;
            try
            {
                //Id дохода выбранной строки
                upd_inc_id = Incomes_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                //Номер выбранной строки
                upd_inc_index = Incomes_dgv.CurrentRow.Index;
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать данные!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Номер ячейки
            int cell = 2;

            //Поиск категории у пользователя
            string sqlQuery = string.Format("SELECT cat.Id FROM [Categories] AS cat WHERE cat.Name = N'{0}' AND cat.User_id = {1}", Incomes_dgv.Rows[upd_inc_index].Cells[cell + 1].Value.ToString(), Name_comboBox.SelectedValue);
            var cat_id = sql.ExcuteData(sqlQuery);
            //Если категория найдена у текущего пользователя, обновляем строку в БД
            if (cat_id.Rows.Count != 0)
            {
                DateTime Date = Convert.ToDateTime(Incomes_dgv.Rows[upd_inc_index].Cells[cell].Value.ToString());
                string Value = Incomes_dgv.Rows[upd_inc_index].Cells[cell + 2].Value.ToString().Replace(",", ".");
                sqlQuery = string.Format("UPDATE [Incomes] SET Date = N'{0}', Category_id = '{1}', Value = '{2}', Description = N'{3}' " +
                                    "WHERE Id = '{4}'", Date.ToString("yyyy-MM-dd"), cat_id.Rows[0][0], Value, Incomes_dgv.Rows[upd_inc_index].Cells[cell + 3].Value.ToString(), upd_inc_id);
                sql.ExcuteDataNonQuery(sqlQuery);
                MessageBox.Show("Строка " + (upd_inc_index + 1).ToString() + " обновлена!", "Строка обновлена", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //Иначе показываем MessageBox с ошибкой
            else
            {
                MessageBox.Show("У выбранного пользователя " + "категория " + Incomes_dgv.Rows[upd_inc_index].Cells[cell + 1].Value.ToString() + " не найдена!" + Environment.NewLine + "Строка " + (upd_inc_index + 1).ToString() + " не обновлена!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        //Отображение расходов
        private void LoadCosts()
        {
            Add_btn.Enabled = true;
            Save_changes_btn.Enabled = true;
            Delete_btn.Enabled = true;
            Export_btn.Enabled = true;
            Print_btn.Enabled = true;

            SqlServer sql = new SqlServer();

            if (CurrentUser.GetLogin() == "admin")
            {
                //Вывод информации обо всех пользователях
                if (Name_comboBox.SelectedIndex.ToString() == "0")
                {
                    string sqlQuery = "SELECT cst.Id AS 'Номер', usr.Name AS 'Имя', cst.Date AS 'Дата', " +
                                 "cat.Name AS 'Категория', cst.Value AS 'Сумма', cst.Description AS 'Описание' " +
                                 "FROM [Users] AS usr INNER JOIN [Costs] AS cst ON usr.Id = cst.User_id " +
                                 " INNER JOIN [Categories] AS cat ON cat.id = cst.Category_id";
                    Costs_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Вывод статистики по расходам
                    Stat1_label.Text = "Расходы за выбранный период: статистика недоступна.";
                    Stat2_label.Text = "Расходы за месяц: статистика недоступна.";
                    Stat3_label.Text = "Расходы за неделю: статистика недоступна.";
                    //Настройка выбора периода статистики
                    From_dateTimePicker.Enabled = false;
                    To_dateTimePicker.Enabled = false;
                    Save_changes_btn.Enabled = false;
                    //Вывод статистики по планированию
                    Message_richTextBox.Text = string.Empty;
                }
                //Вывод информациии о выбраном пользователе в Name_comboBox
                else
                {
                    string sqlQuery = string.Format("SELECT cst.Id AS 'Номер', usr.Name AS 'Имя', cst.Date AS 'Дата', " +
                                 "cat.Name AS 'Категория', cst.Value AS 'Сумма', cst.Description AS 'Описание' " +
                                 "FROM [Users] AS usr INNER JOIN [Costs] AS cst ON usr.Id = cst.User_id " +
                                 " INNER JOIN [Categories] AS cat ON cat.id = cst.Category_id WHERE usr.Id = '{0}'", Name_comboBox.SelectedValue);
                    Costs_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Вывод статистики по расходам
                    Stat1_label.Text = "Расходы за выбранный период: " + StatCosts(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                    Stat2_label.Text = "Расходы за месяц: " + StatCosts(DateTime.Now.Date.AddMonths(-1).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                    Stat3_label.Text = "Расходы за неделю: " + StatCosts(DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                    //Настройка выбора периода статистики
                    From_dateTimePicker.Enabled = true;
                    To_dateTimePicker.Enabled = true;
                    Save_changes_btn.Enabled = true;
                    //Вывод статистики по планированию
                    StatPlaning();
                }
            }
            //Вывод информации о текущем пользователе
            else
            {
                string sqlQuery = string.Format("SELECT cst.Id AS 'Номер', usr.Name AS 'Имя', cst.Date AS 'Дата', " +
                                    "cat.Name AS 'Категория', cst.Value AS 'Сумма', cst.Description AS 'Описание' " +
                                    "FROM [Users] AS usr INNER JOIN [Costs] AS cst ON usr.Id = cst.User_id "
                                    + " INNER JOIN [Categories] AS cat ON cat.id = cst.Category_id WHERE usr.Login = '{0}'", CurrentUser.GetLogin());
                Costs_dgv.DataSource = sql.ExcuteData(sqlQuery);
                //Скрытие имени пользователя для неадминистратора
                Costs_dgv.Columns[1].Visible = false;
                //Вывод статистики по расходам
                Stat1_label.Text = "Расходы за выбранный период: " + StatCosts(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                Stat2_label.Text = "Расходы за месяц: " + StatCosts(DateTime.Now.Date.AddMonths(-1).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                Stat3_label.Text = "Расходы за неделю: " + StatCosts(DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd")) + " рублей.";
                //Настройка выбора периода статистики
                From_dateTimePicker.Enabled = true;
                To_dateTimePicker.Enabled = true;
                Save_changes_btn.Enabled = true;
                //Вывод статистики по планированию
                StatPlaning();
            }

            Costs_dgv.Columns[0].Visible = false;
            //Нельзя редактировать имя пользователя
            Costs_dgv.Columns[1].ReadOnly = true;

            //Формат столбца с суммой (2 знака после запятой)
            DataGridViewCellStyle dec = new DataGridViewCellStyle();
            dec.Format = "N2";
            Costs_dgv.Columns["Сумма"].DefaultCellStyle = dec;
        }
        //Статистика по расходам
        private string StatCosts(string StartDate, string EndDate)
        {
            SqlServer sql = new SqlServer();
            decimal sum = 0;

            string sqlQuery = string.Format("SELECT cst.Value AS 'Сумма' " +
                            "FROM [Costs] AS cst WHERE (cst.User_id = '{0}') AND (cst.Date >= '{1}') AND (cst.Date <= '{2}')",
                            Name_comboBox.SelectedValue, StartDate, EndDate);

            //Расчет суммы доходов
            DataTable dtbl = sql.ExcuteData(sqlQuery);
            for (int r = 0; r <= dtbl.Rows.Count - 1; r++)
            {
                for (int c = 0; c <= dtbl.Columns.Count - 1; c++)
                {
                    sum = sum + Convert.ToDecimal(dtbl.Rows[r][c]);
                }
            }
            return Convert.ToString(sum);
        }
        //Редактирование расходов
        private void EditCosts()
        {
            SqlServer sql = new SqlServer();
            string upd_cst_id = string.Empty;
            int upd_cst_index = -1;
            try
            {
                //Id расхода выбранной строки
                upd_cst_id = Costs_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                //Номер выбранной строки
                upd_cst_index = Costs_dgv.CurrentRow.Index;
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать данные!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Номер ячейки
            int cell = 2;

            //Поиск категории у пользователя
            string sqlQuery = string.Format("SELECT cat.Id FROM [Categories] AS cat WHERE cat.Name = N'{0}' AND cat.User_id = {1}", Costs_dgv.Rows[upd_cst_index].Cells[cell + 1].Value.ToString(), Name_comboBox.SelectedValue);
            var cat_id = sql.ExcuteData(sqlQuery);
            //Если категория найдена у текущего пользователя, обновляем строку в БД
            if (cat_id.Rows.Count != 0)
            {
                DateTime Date = Convert.ToDateTime(Costs_dgv.Rows[upd_cst_index].Cells[cell].Value.ToString());
                string Value = Costs_dgv.Rows[upd_cst_index].Cells[cell + 2].Value.ToString().Replace(",", ".");
                sqlQuery = string.Format("UPDATE [Costs] SET Date = N'{0}', Category_id = '{1}', Value = '{2}', Description = N'{3}' " +
                                    "WHERE Id = '{4}'", Date.ToString("yyyy-MM-dd"), cat_id.Rows[0][0], Value, Costs_dgv.Rows[upd_cst_index].Cells[cell + 3].Value.ToString(), upd_cst_id);
                sql.ExcuteDataNonQuery(sqlQuery);
                MessageBox.Show("Строка " + (upd_cst_index + 1).ToString() + " обновлена!", "Строка обновлена", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //Иначе показываем MessageBox с ошибкой
            else
            {
                MessageBox.Show("У выбранного пользователя " + "категория " + Costs_dgv.Rows[upd_cst_index].Cells[cell + 1].Value.ToString() + " не найдена!" + Environment.NewLine + "Строка " + (upd_cst_index + 1).ToString() + " не обновлена!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        //Отображение долгов
        private void LoadDebts()
        {
            Add_btn.Enabled = true;
            Save_changes_btn.Enabled = true;
            Delete_btn.Enabled = true;
            Export_btn.Enabled = true;
            Print_btn.Enabled = true;

            SqlServer sql = new SqlServer();

            if (CurrentUser.GetLogin() == "admin")
            {
                //Вывод информации обо всех пользователях
                if (Name_comboBox.SelectedIndex.ToString() == "0")
                {
                    string sqlQuery = "SELECT dbt.Id AS 'Номер', usr.Name AS 'Имя', dbt.Date AS 'Дата', " +
                                 " dbt.Value AS 'Сумма', dbt.Description AS 'Описание'," +
                                 " dbt.Return_value AS 'Сумма возврата', dbt.Return_date AS 'Дата возврата' " +
                                 "FROM [Users] AS usr INNER JOIN [Debts] AS dbt ON usr.Id = dbt.User_id";
                    Debts_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Вывод статистики по длогам
                    Stat1_label.Text = "Долги за выбранный период: статистика недоступна.";
                    Stat2_label.Text = "Долги за месяц: статистика недоступна.";
                    Stat3_label.Text = "Долги за неделю: статистика недоступна.";
                    From_dateTimePicker.Enabled = false;
                    To_dateTimePicker.Enabled = false;
                    Save_changes_btn.Enabled = false;
                    //Вывод статистики по планированию
                    Message_richTextBox.Text = string.Empty;
                }
                //Вывод информациии о выбраном пользователе в Name_comboBox
                else
                {
                    string sqlQuery = string.Format("SELECT dbt.Id AS 'Номер', usr.Name AS 'Имя', dbt.Date AS 'Дата', " +
                                      " dbt.Value AS 'Сумма', dbt.Description AS 'Описание'," +
                                      " dbt.Return_value AS 'Сумма возврата', dbt.Return_date AS 'Дата возврата' " +
                                      "FROM [Users] AS usr INNER JOIN [Debts] AS dbt ON usr.Id = dbt.User_id " +
                                      "WHERE usr.Id = '{0}'", Name_comboBox.SelectedValue);
                    Debts_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Вывод статистики по долгам
                    Stat1_label.Text = "Долги за выбранный период: статистика недоступна.";
                    Stat2_label.Text = "Долги за месяц: статистика недоступна.";
                    Stat3_label.Text = "Долги за неделю: статистика недоступна.";
                    From_dateTimePicker.Enabled = true;
                    To_dateTimePicker.Enabled = true;
                    Save_changes_btn.Enabled = true;
                    //Вывод статистики по планированию
                    StatPlaning();
                }
            }
            //Вывод информации о текущем пользователе
            else
            {
                string sqlQuery = string.Format("SELECT dbt.Id AS 'Номер', usr.Name AS 'Имя', dbt.Date AS 'Дата', " +
                                  " dbt.Value AS 'Сумма', dbt.Description AS 'Описание'," +
                                  " dbt.Return_value AS 'Сумма возврата', dbt.Return_date AS 'Дата возврата' " +
                                  "FROM [Users] AS usr INNER JOIN [Debts] AS dbt ON usr.Id = dbt.User_id " +
                                  "WHERE usr.Login = '{0}'", CurrentUser.GetLogin());
                Debts_dgv.DataSource = sql.ExcuteData(sqlQuery);
                //Скрытие имени пользователя для неадминистратора
                Debts_dgv.Columns[1].Visible = false;
                //Вывод статистики по долгам
                Stat1_label.Text = "Долги за выбранный период: статистика недоступна.";
                Stat2_label.Text = "Долги за месяц: статистика недоступна.";
                Stat3_label.Text = "Долги за неделю: статистика недоступна.";
                From_dateTimePicker.Enabled = true;
                To_dateTimePicker.Enabled = true;
                Save_changes_btn.Enabled = true;
                //Вывод статистики по планированию
                StatPlaning();
            }
            //Нельзя редактировать имя пользователя
            Debts_dgv.Columns[1].ReadOnly = true;
            Debts_dgv.Columns[0].Visible = false;
            //Формат столбца с суммой (2 знака после запятой)
            DataGridViewCellStyle dec = new DataGridViewCellStyle();
            dec.Format = "N2";
            Debts_dgv.Columns["Сумма"].DefaultCellStyle = dec;
            Debts_dgv.Columns["Сумма возврата"].DefaultCellStyle = dec;
        }
        //Редактирование долгов
        private void EditDebts()
        {
            SqlServer sql = new SqlServer();
            string upd_dbt_id = string.Empty;
            int upd_dbt_index = -1;
            try
            {
                //Id расхода выбранной строки
                upd_dbt_id = Debts_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                //Номер выбранной строки
                upd_dbt_index = Debts_dgv.CurrentRow.Index;
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать данные!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Номер ячейки
            int cell = 2;

            DateTime Date = Convert.ToDateTime(Debts_dgv.Rows[upd_dbt_index].Cells[cell].Value.ToString());
            // DateTime Return_date = Convert.ToDateTime(Debts_dgv.Rows[upd_dbt_index].Cells[cell + 4].Value.ToString());
            string Value = Debts_dgv.Rows[upd_dbt_index].Cells[cell + 1].Value.ToString().Replace(",", ".");
            string Return_value = Debts_dgv.Rows[upd_dbt_index].Cells[cell + 3].Value.ToString().Replace(",", ".");

            string sqlQuery = string.Empty;

            //Если удалили дату возврата долга
            //Почему-то пишет дату 01-01-1900
            if (Debts_dgv.Rows[upd_dbt_index].Cells[cell + 4].Value.ToString() == string.Empty)
            {
                DateTime? Return_date = null;
                sqlQuery = string.Format("UPDATE [Debts] SET Date = '{0}', Value = '{1}', Description = N'{2}', Return_value = '{3}', Return_date = '{4}' " +
                    "WHERE Id = '{5}'", Date.ToString("yyyy-MM-dd"), Value, Debts_dgv.Rows[upd_dbt_index].Cells[cell + 2].Value.ToString(), Return_value, Return_date, upd_dbt_id);
            }
            else
            {
                DateTime Return_date = Convert.ToDateTime(Debts_dgv.Rows[upd_dbt_index].Cells[cell + 4].Value.ToString());
                sqlQuery = string.Format("UPDATE [Debts] SET Date = '{0}', Value = '{1}', Description = N'{2}', Return_value = '{3}', Return_date = '{4}' " +
                    "WHERE Id = '{5}'", Date.ToString("yyyy-MM-dd"), Value, Debts_dgv.Rows[upd_dbt_index].Cells[cell + 2].Value.ToString(), Return_value, Return_date.ToString("yyyy-MM-dd"), upd_dbt_id);
            }
            sql.ExcuteDataNonQuery(sqlQuery);
            MessageBox.Show("Строка " + (upd_dbt_index + 1).ToString() + " обновлена!", "Строка обновлена", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Отображение планирования
        private void LoadPlaning()
        {
            Add_btn.Enabled = true;
            Save_changes_btn.Enabled = true;
            Delete_btn.Enabled = true;
            Export_btn.Enabled = true;
            Print_btn.Enabled = true;

            SqlServer sql = new SqlServer();

            if (CurrentUser.GetLogin() == "admin")
            {
                //Вывод информации обо всех пользователях
                if (Name_comboBox.SelectedIndex.ToString() == "0")
                {
                    string sqlQuery = "SELECT pln.Id AS 'Номер', usr.Name AS 'Имя', cat.Name AS 'Наименование категории', " +
                                      "pln.Month AS 'Месяц', pln.Year AS 'Год', pln.Value AS 'Сумма' " +
                                      "FROM [Planings] AS pln INNER JOIN [Users] AS usr ON pln.User_id = usr.Id " +
                                      "INNER JOIN [Categories] AS cat ON pln.Category_id = cat.Id";
                    Planing_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Акстивность кнопки "Сохранить изменения"
                    Save_changes_btn.Enabled = false;
                    //Вывод статистики по планированию
                    Message_richTextBox.Text = string.Empty;
                }
                //Вывод информациии о выбраном пользователе в Name_comboBox
                else
                {
                    string sqlQuery = string.Format("SELECT pln.Id AS 'Номер', usr.Name AS 'Имя', cat.Name AS 'Наименование категории', " +
                                      "pln.Month AS 'Месяц', pln.Year AS 'Год', pln.Value AS 'Сумма' " +
                                      "FROM [Planings] AS pln INNER JOIN [Users] AS usr ON pln.User_id = usr.Id " +
                                      "INNER JOIN [Categories] AS cat ON pln.Category_id = cat.Id WHERE usr.Id = '{0}'", Name_comboBox.SelectedValue);
                    Planing_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Акстивность кнопки "Сохранить изменения"
                    Save_changes_btn.Enabled = true;
                    //Вывод статистики по планированию
                    StatPlaning();
                }
            }
            //Вывод информации о текущем пользователе
            else
            {
                string sqlQuery = string.Format("SELECT pln.Id AS 'Номер', usr.Name AS 'Имя', cat.Name AS 'Наименование категории', " +
                                      "pln.Month AS 'Месяц', pln.Year AS 'Год', pln.Value AS 'Сумма' " +
                                      "FROM [Planings] AS pln INNER JOIN [Users] AS usr ON pln.User_id = usr.Id " +
                                      "INNER JOIN [Categories] AS cat ON pln.Category_id = cat.Id WHERE usr.Login = '{0}'", CurrentUser.GetLogin());
                Planing_dgv.DataSource = sql.ExcuteData(sqlQuery);
                //Скрытие имени пользователя для неадминистратора
                Planing_dgv.Columns[1].Visible = false;
                //Акстивность кнопки "Сохранить изменения"
                Save_changes_btn.Enabled = true;
                //Вывод статистики по планированию
                StatPlaning();
            }
            Planing_dgv.Columns[0].Visible = false;
            //Нельзя редактировать имя пользователя
            Planing_dgv.Columns[1].ReadOnly = true;

            //Статистика
            Stat1_label.Text = "Статистика за выбранный период: недоступно.";
            Stat2_label.Text = "Статистика за месяц: недоступно.";
            Stat3_label.Text = "Статистика за неделю: недоступно.";
            From_dateTimePicker.Enabled = false;
            To_dateTimePicker.Enabled = false;

            //Формат столбца с суммой (2 знака после запятой)
            DataGridViewCellStyle dec = new DataGridViewCellStyle();
            dec.Format = "N2";
            Planing_dgv.Columns["Сумма"].DefaultCellStyle = dec;
        }
        //Статистика по планированию
        private void StatPlaning()
        {
            SqlServer sql = new SqlServer();
            string sqlQuery = string.Format("SELECT cat.Id, cat.Name, pln.Value " +
                          "FROM Planings AS pln INNER JOIN Categories AS cat ON cat.Id = pln.Category_id " +
                          "WHERE pln.User_id = '{0}' AND pln.Month = '{1}' AND pln.Year = '{2}' GROUP BY cat.Id, cat.Name, pln.Value, pln.Month, pln.Year ORDER BY cat.Id",
                          Name_comboBox.SelectedValue, DateTime.Now.Date.Month, DateTime.Now.Date.Year);
            DataTable PlnCst = sql.ExcuteData(sqlQuery);

            sqlQuery = string.Format("SELECT cat.Id, cat.Name, SUM(cst.Value) FROM Costs AS cst INNER JOIN Categories AS cat ON cat.Id = cst.Category_id " +
                                     "WHERE cst.Date >= '{0}' AND cst.Date <= '{1}' AND cst.User_id = '{2}' GROUP BY cat.Id, cat.Name ORDER BY cat.Id",
                                     DateTime.Now.AddDays(-DateTime.Now.Day).Date.ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd"), Name_comboBox.SelectedValue);
            DataTable RealCst = sql.ExcuteData(sqlQuery);

            Message_richTextBox.Text = string.Empty;

            for (int r = 0; r <= PlnCst.Rows.Count - 1; r++)
            {
                for (int c = 0; c <= RealCst.Rows.Count - 1; c++)
                {
                    if (Convert.ToInt32(RealCst.Rows[c][0]) == Convert.ToInt32(PlnCst.Rows[r][0]))
                    {
                        if (Convert.ToDecimal(RealCst.Rows[c][2]) > Convert.ToDecimal(PlnCst.Rows[r][2]))
                            Message_richTextBox.Text += "Расходы в категории \"" + Convert.ToString(PlnCst.Rows[r][1]) + "\" превышены на " + Convert.ToString(Convert.ToDecimal(RealCst.Rows[r][2]) - Convert.ToDecimal(PlnCst.Rows[r][2])) + " рублей." + Environment.NewLine + Environment.NewLine;
                    }
                }
            }
        }
        //Редактирование планирования
        private void EditPlaning()
        {
            SqlServer sql = new SqlServer();
            string upd_pln_id = string.Empty;
            int upd_pln_index = -1;
            try
            {
                //Id дохода выбранной строки
                upd_pln_id = Planing_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                //Номер выбранной строки
                upd_pln_index = Planing_dgv.CurrentRow.Index;
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать данные!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Номер ячейки
            int cell = 2;

            //Поиск категории у пользователя
            string sqlQuery = string.Format("SELECT cat.Id FROM [Categories] AS cat WHERE cat.Name = N'{0}' AND cat.User_id = {1}", Planing_dgv.Rows[upd_pln_index].Cells[cell].Value.ToString(), Name_comboBox.SelectedValue);
            var cat_id = sql.ExcuteData(sqlQuery);
            //Если категория найдена у текущего пользователя
            if (cat_id.Rows.Count != 0)
            {
                string Month = Planing_dgv.Rows[upd_pln_index].Cells[cell + 1].Value.ToString();
                string Year = Planing_dgv.Rows[upd_pln_index].Cells[cell + 2].Value.ToString();
                string Value = Planing_dgv.Rows[upd_pln_index].Cells[cell + 3].Value.ToString().Replace(",", ".");

                //Поиск уже существующего планирования у пользователя
                sqlQuery = string.Format("SELECT * FROM [Planings] WHERE Category_id = '{0}' AND Month = '{1}' AND Year = '{2}' AND User_id = '{3}'",
                                    cat_id.Rows[0][0], Month, Year, Name_comboBox.SelectedValue);
                var plan = sql.ExcuteData(sqlQuery);
                //Если планирование уже задано, выводим сообщение об ошибке
                if (plan.Rows.Count != 0)
                {
                    MessageBox.Show("У выбранного пользователя такое планирование уже задано!" + Environment.NewLine + "Строка " + (upd_pln_index + 1).ToString() + " не обновлена!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Иначе обновляем строку в БД
                else
                {
                    sqlQuery = string.Format("UPDATE [Planings] SET Category_id = '{0}', Month = '{1}', Year = '{2}', Value = '{3}' " +
                                        "WHERE Id = '{4}'", cat_id.Rows[0][0], Month, Year, Value, Planing_dgv.Rows[upd_pln_index].Cells[0].Value.ToString());
                    sql.ExcuteDataNonQuery(sqlQuery);
                    MessageBox.Show("Строка " + (upd_pln_index + 1).ToString() + " обновлена!", "Строка обновлена", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            //Иначе показываем MessageBox с ошибкой
            else
            {
                MessageBox.Show("У выбранного пользователя " + "категория " + Planing_dgv.Rows[upd_pln_index].Cells[cell].Value.ToString() + " не найдена!" + Environment.NewLine + "Строка " + (upd_pln_index + 1).ToString() + " не обновлена!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        //Отображение категорий
        private void LoadCategories()
        {
            Add_btn.Enabled = true;
            Save_changes_btn.Enabled = true;
            Delete_btn.Enabled = true;
            Export_btn.Enabled = true;
            Print_btn.Enabled = true;

            SqlServer sql = new SqlServer();

            if (CurrentUser.GetLogin() == "admin")
            {
                //Вывод информации обо всех пользователях
                if (Name_comboBox.SelectedIndex.ToString() == "0")
                {
                    string sqlQuery = "SELECT cat.Id AS 'Номер', usr.Name AS 'Имя пользователя', cat.Name AS 'Наименование категории' " +
                                      "FROM [Categories] AS cat INNER JOIN [Users] AS usr ON cat.User_id = usr.Id";
                    Categories_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Акстивность кнопки "Сохранить изменения"
                    Save_changes_btn.Enabled = false;
                    //Вывод статистики по планированию
                    Message_richTextBox.Text = string.Empty;
                }
                //Вывод информациии о выбраном пользователе в Name_comboBox
                else
                {
                    string sqlQuery = string.Format("SELECT cat.Id AS 'Номер', usr.Name AS 'Имя пользователя', cat.Name AS 'Наименование категории' " +
                                      "FROM [Categories] AS cat INNER JOIN [Users] AS usr ON cat.User_id = usr.Id " +
                                      "WHERE usr.Id = '{0}'", Name_comboBox.SelectedValue);
                    Categories_dgv.DataSource = sql.ExcuteData(sqlQuery);
                    //Акстивность кнопки "Сохранить изменения"
                    Save_changes_btn.Enabled = true;
                    //Вывод статистики по планированию
                    StatPlaning();
                }
            }
            //Вывод информации о текущем пользователе
            else
            {
                string sqlQuery = string.Format("SELECT cat.Id AS 'Номер', usr.Name AS 'Имя пользователя', cat.Name AS 'Наименование категории' " +
                                  "FROM [Categories] AS cat INNER JOIN [Users] AS usr ON cat.User_id = usr.Id " +
                                  "WHERE usr.Login = '{0}'", CurrentUser.GetLogin());
                Categories_dgv.DataSource = sql.ExcuteData(sqlQuery);
                //Скрытие имени пользователя для неадминистратора
                Categories_dgv.Columns[1].Visible = false;
                //Акстивность кнопки "Сохранить изменения"
                Save_changes_btn.Enabled = true;
            }
            Categories_dgv.Columns[0].Visible = false;
            //Нельзя редактировать имя пользователя
            Categories_dgv.Columns[1].ReadOnly = true;
            //Статистика
            Stat1_label.Text = "Статистика за выбранный период: недоступно.";
            Stat2_label.Text = "Статистика за месяц: недоступно.";
            Stat3_label.Text = "Статистика за неделю: недоступно.";
            From_dateTimePicker.Enabled = false;
            To_dateTimePicker.Enabled = false;
            //Вывод статистики по планированию
            StatPlaning();
        }
        //Редактирование категорий 
        private void EditCategories()
        {
            SqlServer sql = new SqlServer();
            string upd_cat_id = string.Empty;
            int upd_cat_index = -1;
            try
            {
                //Id расхода выбранной строки
                upd_cat_id = Categories_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                //Номер выбранной строки
                upd_cat_index = Categories_dgv.CurrentRow.Index;
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать данные!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Categories_dgv.Rows[upd_cat_index].Cells[2].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Имя категории не может быть пустым!", "Ошибка сохранения изменений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Поиск категории пользователя с заданным именем
                string sqlQuery = string.Format("SELECT Id, Name FROM [Categories] WHERE User_id = {0} AND Name = N'{1}'", Name_comboBox.SelectedValue, Categories_dgv.Rows[upd_cat_index].Cells[2].Value.ToString());
                DataTable FindCategoryTbl = sql.ExcuteData(sqlQuery);
                //Если категория найдена
                if (FindCategoryTbl.Rows.Count != 0)
                {
                    MessageBox.Show("Такая категория уже существует у пользователя!", "Ошибка редактирования", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    //Номер ячейки
                    int cell = 2;
                    sqlQuery = string.Format("UPDATE [Categories] SET Name = N'{0}' WHERE Id = {1}", Categories_dgv.Rows[upd_cat_index].Cells[cell].Value.ToString(), upd_cat_id);
                    sql.ExcuteDataNonQuery(sqlQuery);
                    MessageBox.Show("Строка " + (upd_cat_index + 1).ToString() + " обновлена!", "Строка обновлена", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        //Оотображения вкладки управления пользователями
        private void LoadUsers()
        {
            Add_btn.Enabled = false;
            Save_changes_btn.Enabled = false;
            Delete_btn.Enabled = false;
            Export_btn.Enabled = false;
            Print_btn.Enabled = false;


            SqlServer sql = new SqlServer();

            if (CurrentUser.GetLogin() == "admin")
            {
                string sqlQuery = "SELECT Id, Name FROM [Users]";
                Functions.FillComboBox(sqlQuery, Users_comboBox, "Id", "Name");
                Users_comboBox.Enabled = true;
                //Вывод статистики по планированию
                Message_richTextBox.Text = string.Empty;
            }
            //Вывод информации о текущем пользователе
            else
            {
                string sqlQuery = string.Format("SELECT Id, Name FROM [Users] WHERE Login = N'{0}'", CurrentUser.GetLogin());
                Functions.FillComboBox(sqlQuery, Users_comboBox, "Id", "Name");
                Users_comboBox.Enabled = false;
            }

            //Статистика
            Stat1_label.Text = "Статистика за выбранный период: недоступно.";
            Stat2_label.Text = "Статистика за месяц: недоступно.";
            Stat3_label.Text = "Статистика за неделю: недоступно.";
            From_dateTimePicker.Enabled = false;
            To_dateTimePicker.Enabled = false;
            //Вывод статистики по планированию
            StatPlaning();
        }
        //Кнопка "Изменить пароль" во вкладке управления пользователями
        private void ChangePassword_btn_Click(object sender, EventArgs e)
        {
            if ((NewPassword1_textBox.Text != string.Empty) | (NewPassword2_textBox.Text != string.Empty))
            {
                if (NewPassword1_textBox.Text == NewPassword2_textBox.Text)
                {
                    SqlServer sql = new SqlServer();
                    string sqlQuery = string.Format("UPDATE [Users] SET Password = N'{0}' WHERE Id = {1}", NewPassword1_textBox.Text, Users_comboBox.SelectedValue);
                    sql.ExcuteDataNonQuery(sqlQuery);
                    MessageBox.Show("Пароль успешно изменён!", "Пароль изменен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Пароли не совпадают!", "Ошибка смены пароля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Пароль не может быть пустым!", "Ошибка смены пароля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //Кнопка смены пользователя
        private void ChangeUser_button_Click(object sender, EventArgs e)
        {
            //Закрываем текущую сессию (закрываем окно с финансовыми категориями)
            this.Close();
        }
        //Кнопка "Изменить пароль"
        private void ChangePasswordTab_btn_Click(object sender, EventArgs e)
        {
            TabControl.SelectedIndex = 4;
        }


        //Предупреждение о возможной потере данных
        private void Main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Завершить сеанс?", "Завершение сеанса", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        //После закрытия формы показываем окно авторизации
        private void Main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginF.Visible = true;
        }

        //Кнопка добавления данных
        private void Add_btn_Click(object sender, EventArgs e)
        {
            //Добавление данных в зависимости от вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Доходы
                case ("0"):
                    {
                        //Отобразить форму добавления дохода
                        AddIncome_form AddIncome = new AddIncome_form();
                        AddIncome.Show();
                        break;
                    }
                //Расходы
                case ("1"):
                    {
                        //Отобразить форму добавления расхода
                        AddCost_form AddCost = new AddCost_form();
                        AddCost.Show();
                        break;
                    }
                //Долги
                case ("2"):
                    {
                        //Отобразить форму добавления долга
                        AddDebt_form AddDebt = new AddDebt_form();
                        AddDebt.Show();
                        break;
                    }
                //Планирование
                case ("3"):
                    {
                        //Отобразить форму добавления планирования
                        AddPlaning_form AddPlaning = new AddPlaning_form();
                        AddPlaning.Show();
                        break;
                    }
                //Категории
                case ("4"):
                    {
                        //Отобразить форму добавления категории
                        AddCategory_form AddCategory = new AddCategory_form();
                        AddCategory.Show();
                        break;
                    }
            }
        }
        //Кнопка удаления данных
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            //Удаление данных в зависимости от вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Доходы
                case ("0"):
                    {
                        try
                        {
                            string del_inc_id = Incomes_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                            SqlServer sql = new SqlServer();
                            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                sql.ExcuteDataNonQuery(String.Format("DELETE [Incomes] WHERE Id='{0}'", del_inc_id));
                            }
                        }

                        catch
                        {
                            MessageBox.Show("Не удалось удалить данные!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //Отображение обновленной таблицы доходов
                        LoadIncomes();
                        break;
                    }
                //Расходы
                case ("1"):
                    {
                        try
                        {
                            string del_cst_id = Costs_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                            SqlServer sql = new SqlServer();
                            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                sql.ExcuteDataNonQuery(String.Format("DELETE [Costs] WHERE Id='{0}'", del_cst_id));
                            }
                        }

                        catch
                        {
                            MessageBox.Show("Не удалось удалить данные!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Отображение обновленной таблицы расходов
                        LoadCosts();
                        break;
                    }
                //Долги
                case ("2"):
                    {
                        try
                        {
                            string del_cst_id = Debts_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                            SqlServer sql = new SqlServer();
                            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                sql.ExcuteDataNonQuery(String.Format("DELETE [Debts] WHERE Id='{0}'", del_cst_id));
                            }
                        }

                        catch
                        {
                            MessageBox.Show("Не удалось удалить данные!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Отображение обновленной таблицы долгов
                        LoadDebts();
                        break;
                    }
                //Планирование
                case ("3"):
                    {
                        string del_pln_id = Planing_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                        SqlServer sql = new SqlServer();
                        if (MessageBox.Show("Вы действительно хотите удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sql.ExcuteDataNonQuery(String.Format("DELETE [Planings] WHERE Id='{0}'", del_pln_id));
                        }
                        //Отображение обновлённой таблицы планирования
                        LoadPlaning();
                        break;
                    }
                //Категории
                case ("4"):
                    {
                        //ЕСЛИ КАТЕГОРИЯ ЗАНЯТА, ТО НЕЛЬЗЯ ЕЕ УДАЛИТЬ
                        try
                        {
                            string del_cst_id = Categories_dgv.CurrentRow.Cells["Номер"].Value.ToString();
                            SqlServer sql = new SqlServer();
                            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                sql.ExcuteDataNonQuery(String.Format("DELETE [Categories] WHERE Id='{0}'", del_cst_id));
                            }
                        }

                        catch
                        {
                            MessageBox.Show("Не удалось удалить данные!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Отображение обновленной таблицы долгов
                        LoadCategories();
                        break;
                    }
            }
        }
        //Кнопка экспорта данных
        private void Export_btn_Click(object sender, EventArgs e)
        {
            //Экспорт данных в зависимости от вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Экспорт доходов
                case ("0"):
                    {
                        Functions.ExportToFile(Incomes_dgv, "Экспорт доходов");
                        break;
                    }
                //Экспорт расходов
                case ("1"):
                    {
                        Functions.ExportToFile(Costs_dgv, "Экспорт расходов");
                        break;
                    }
                //Экспорт долгов
                case ("2"):
                    {
                        Functions.ExportToFile(Debts_dgv, "Экспорт долгов");
                        break;
                    }
                //Экспорт планирования
                case ("3"):
                    {
                        Functions.ExportToFile(Planing_dgv, "Экспорт планирования");
                        break;
                    }
                //Экспорт категорий
                case ("4"):
                    {
                        Functions.ExportToFile(Categories_dgv, "Экспорт категорий");
                        break;
                    }
            }
        }
        //Кнопка "Сохранить изменения"
        private void Save_changes_btn_Click(object sender, EventArgs e)
        {
            //Сохранение изменений в зависимости от вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Сохранение доходов
                case ("0"):
                    {
                        EditIncomes();
                        LoadIncomes();
                        break;
                    }
                //Сохранение расходов
                case ("1"):
                    {
                        EditCosts();
                        LoadCosts();
                        break;
                    }
                //Сохранение долгов
                case ("2"):
                    {
                        EditDebts();
                        LoadDebts();
                        break;
                    }
                //Сохранение планирования
                case ("3"):
                    {
                        EditPlaning();
                        LoadPlaning();
                        break;
                    }
                //Сохранение категорий
                case ("4"):
                    {
                        EditCategories();
                        LoadCategories();
                        break;
                    }
            }
        }

        //Событие выбора вкладки
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            //Подгрузка данных в зависимости от выбора вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Отображение доходов
                case ("0"):
                    {
                        LoadIncomes();
                        break;
                    }
                //Отображение расходов
                case ("1"):
                    {
                        LoadCosts();
                        break;
                    }
                //Отображение долгов
                case ("2"):
                    {
                        LoadDebts();
                        break;
                    }
                //Отображение планирования
                case ("3"):
                    {
                        LoadPlaning();
                        break;
                    }
                //Отображение категорий
                case ("4"):
                    {
                        LoadCategories();
                        break;
                    }
                //Отображение вкладки управления пользователями
                case ("5"):
                    {
                        LoadUsers();
                        break;
                    }
            }
        }

        //При смене пользователя (для администратора) обновляем datagrid-ы
        private void Name_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Обновление данных при смене пользователя
            switch (TabControl.SelectedIndex.ToString())
            {
                //Доходы
                case ("0"):
                    {
                        LoadIncomes();
                        break;
                    }
                //Расходы
                case ("1"):
                    {
                        LoadCosts();
                        break;
                    }
                //Долги
                case ("2"):
                    {
                        LoadDebts();
                        break;
                    }
                //Планирование
                case ("3"):
                    {
                        LoadPlaning();
                        break;
                    }
                //Категории
                case ("4"):
                    {
                        LoadCategories();
                        break;
                    }
                //Пользователи
                case ("5"):
                    {
                        LoadUsers();
                        break;
                    }
            }
        }

        //Событие изменения значения в To_dateTimePicker
        private void To_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //Обновление статистики в зависимости от вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Статистика доходов
                case ("0"):
                    {
                        Stat1_label.Text = "Доходы за выбранный период: " + StatIncomes(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                        break;
                    }
                //Статистика расходов
                case ("1"):
                    {
                        Stat1_label.Text = "Расходы за выбранный период: " + StatCosts(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                        break;
                    }
                //Статистика долгов
                case ("2"):
                    {
                        break;
                    }
            }
        }

        //Событие изменения значения в From_dateTimePicker
        private void From_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //Обновление статистики в зависимости от вкладки
            switch (TabControl.SelectedIndex.ToString())
            {
                //Статистика доходов
                case ("0"):
                    {
                        Stat1_label.Text = "Доходы за выбранный период: " + StatIncomes(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                        break;
                    }
                //Статистика расходов
                case ("1"):
                    {
                        Stat1_label.Text = "Расходы за выбранный период: " + StatCosts(From_dateTimePicker.Value.Date.ToString("yyyy-MM-dd"), To_dateTimePicker.Value.Date.ToString("yyyy-MM-dd")) + " рублей.";
                        break;
                    }
                //Статистика долгов
                case ("2"):
                    {
                        break;
                    }
            }
        }

        //Ошибка несоответсвия типа введенных данных в Incomes_dgv
        private void Incomes_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Проверьте формат введённых данных!", "Ошибка редактирования ячейки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ошибка несоответсвия типа введенных данных в Costs_dgv
        private void Costs_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Проверьте формат введённых данных!", "Ошибка редактирования ячейки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ошибка несоответсвия типа введенных данных в Debts_dgv
        private void Debts_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Проверьте формат введённых данных!", "Ошибка редактирования ячейки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ошибка несоответсвия типа введенных данных в Planing_dgv
        private void Planing_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Проверьте формат введённых данных!", "Ошибка редактирования ячейки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ошибка несоответсвия типа введенных данных в Categories_dgv
        private void Categories_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Проверьте формат введённых данных!", "Ошибка редактирования ячейки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Print_btn_Click(object sender, EventArgs e)
        {
            PrintDialog printdialog = new PrintDialog();
            printdialog.Document = printDocument;
            printdialog.UseEXDialog = true;
            if (DialogResult.OK == printdialog.ShowDialog())
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            switch (TabControl.SelectedIndex.ToString())
            {

                case ("0"):
                    {
                        Bitmap bm = new Bitmap(this.Incomes_dgv.Width, this.Incomes_dgv.Height);
                        Incomes_dgv.DrawToBitmap(bm, new Rectangle(0, 0, this.Incomes_dgv.Width, this.Incomes_dgv.Height));
                        e.Graphics.DrawImage(bm, 80, 20);
                        break;
                    }
                case ("1"):
                    {
                        Bitmap bm = new Bitmap(this.Costs_dgv.Width, this.Costs_dgv.Height);
                        Costs_dgv.DrawToBitmap(bm, new Rectangle(0, 0, this.Costs_dgv.Width, this.Costs_dgv.Height));
                        e.Graphics.DrawImage(bm, 80, 20);
                        break;
                    }
                case ("2"):
                    {
                        Bitmap bm = new Bitmap(this.Debts_dgv.Width, this.Debts_dgv.Height);
                        Debts_dgv.DrawToBitmap(bm, new Rectangle(0, 0, this.Debts_dgv.Width, this.Debts_dgv.Height));
                        e.Graphics.DrawImage(bm, 80, 20);
                        break;
                    }
                case ("3"):
                    {
                        Bitmap bm = new Bitmap(this.Planing_dgv.Width, this.Planing_dgv.Height);
                        Planing_dgv.DrawToBitmap(bm, new Rectangle(0, 0, this.Planing_dgv.Width, this.Planing_dgv.Height));
                        e.Graphics.DrawImage(bm, 80, 20);
                        break;
                    }
                case ("4"):
                    {
                        Bitmap bm = new Bitmap(this.Categories_dgv.Width, this.Categories_dgv.Height);
                        Categories_dgv.DrawToBitmap(bm, new Rectangle(0, 0, this.Categories_dgv.Width, this.Categories_dgv.Height));
                        e.Graphics.DrawImage(bm, 80, 20);
                        break;
                    }

            }
        }
    }
}
