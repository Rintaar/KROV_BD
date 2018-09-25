using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krov.Core;
using MySql.Data.MySqlClient;

// Класс для подключения к БД, используется библиотека MySql.Data, скачаено с nugget пакетов. 
namespace Krov
{
    class dataBaseConnect
    {
        // Свойства класса для задачи, пути, имени, логина и пароля для БД.
        public string dbBase { get; }
        public string dbSource { get; }
        public string dbLogin { get; }
        public string dbPassword { get; }

        // Переменная для генерации строки обращения к БД
        MySqlConnectionStringBuilder mySCSB = new MySqlConnectionStringBuilder();


        // Конструкторы на все случаи жизни 
        public dataBaseConnect (string _dbBase, string _dbSource, string _dbLogin, string _dbPassword)
        {
            mySCSB.Server = _dbSource;
            mySCSB.Database = _dbBase;
            mySCSB.UserID = _dbLogin;
            mySCSB.Password = _dbPassword;
            mySCSB.CharacterSet = "UTF8";
        }

        public dataBaseConnect(string _dbBase, string _dbLogin, string _dbPassword)
        {
            Configs conf = new Configs();
            conf.GetConfig();
            mySCSB.Server = conf.serverID;
            mySCSB.Database = _dbBase;
            mySCSB.UserID = _dbLogin;
            mySCSB.Password = _dbPassword;
            mySCSB.CharacterSet = "UTF8";
        }

        public dataBaseConnect(string _dbBase)
        {
            Configs conf = new Configs();
            conf.GetConfig();
            mySCSB.Server = conf.serverID;
            mySCSB.Database = conf.database;
            mySCSB.UserID = "u0465505_roofuse";
            mySCSB.Password = "roofpass123";              
            mySCSB.CharacterSet = "UTF8";
        }

        // Метод получения данных из конкретной таблицы БД

        public DataTable getData(string _queryCommand)
        {
            DataTable dataTable = new DataTable(); // Временное хранилище для данных

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using(MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(_queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    // Получение данных из таблицы
                    using (MySqlDataReader mySQLDR = mySQLComm.ExecuteReader())
                    {
                        if (mySQLDR.HasRows)
                        {
                            dataTable.Load(mySQLDR); // Выгружаем полученное в хранилище
                        }
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }
            return dataTable; // Возвращаем хранилище
        }
        public string getlastid(string tablename)
        {
            DataTable dataTable = new DataTable(); // Временное хранилище для данных

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(String.Format("SELECT id FROM `{0}` ORDER BY `id` DESC LIMIT 1",tablename), mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    // Получение данных из таблицы
                    using (MySqlDataReader mySQLDR = mySQLComm.ExecuteReader())
                    {
                        if (mySQLDR.HasRows)
                        {
                            dataTable.Load(mySQLDR);
                        }
                    }
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }
            return dataTable.Rows[0].ItemArray[0].ToString(); ; // Возвращаем хранилище
        }

        //вставка данных в таблицу недописана
        public void insertData(string _queryCommand)
        {
            
            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(_queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }

        //вставка данных в таблицу Объекты
        public void insertDataToObjects(BDObject objec)
        {
            string _queryCommand = String.Format("INSERT INTO `Object` " +
                "(`id`, `name`, `address`, `jobkind`, `date_auction`, `date_contract`, `date_plan`, `date_real`, `date_payment`, `crew`, `Photo`,  `manager`,  `workskind`, `info`, `part_list`, `part`) " +
                "VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', NULL,'{9}', '{10}', '{11}', '{12}', '{13}')",
                objec.name, objec.address, objec.workstype, objec.d_auction.ToString("yyyy-MM-dd"), objec.d_contract.ToString("yyyy-MM-dd"), objec.d_planned.ToString("yyyy-MM-dd"),
                objec.d_real.ToString("yyyy-MM-dd"), objec.d_payment.ToString("yyyy-MM-dd"), objec.crew, objec.manager, objec.workskind, Convert.ToString(objec.info), objec.part_list, objec.parts);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(_queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //создание нового пользователя. пока с заглушкой или админ или юзер, далее можно расширить
        //входные данные: имя, пароль, уровень доступа true - admin; false - user
        public void createuser(string name, string password, bool privil)
        {
            string queryCommand = String.Format("CREATE USER '{0}'@'%' IDENTIFIED BY '{1}';", name, password);
        
            if(privil == true)
                queryCommand = queryCommand+ String.Format("GRANT SELECT, INSERT, UPDATE, DELETE, FILE, CREATE USER ON *.* TO '{0}'@'%' IDENTIFIED BY '{1}';", name, password);
            else
                queryCommand = queryCommand + String.Format("GRANT SELECT ON *.* TO '{0}'@'%' IDENTIFIED BY '{1}';", name, password);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при создании пользователя.\nВведены неправильные данные"); // Если ошибка, выводим её
                }
            }

        }
        //редактирование таблицы Менеджеры
        public void changeManager(string login, string raw, string new_value)
        {
            string queryCommand = String.Format("UPDATE `Manager` SET `{0}` = '{1}' WHERE `manager`.`login` = {2}", raw, new_value, login);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //редактирование выбранной таблицы по id
        public void updateDataById(string tablename, int id_value, string raw, string new_value)
        {
            string queryCommand = String.Format("UPDATE `{0}` SET `{1}` = '{2}' WHERE `{0}`.`id` = {3}",tablename, raw, new_value, id_value);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //редактирование выбранной таблицы по произвольному ключу
        public void updateDataByKey(string tablename, string key_name, string key_data, string row, string new_value)
        {
            string queryCommand = String.Format("UPDATE `{0}` SET `{1}` = '{2}' WHERE `{0}`.`{3}` = `{4}`", tablename, row, new_value, key_name, key_data);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        public void updateDataByNumericKey(string tablename, string key_name, string key_data, string row, string new_value)
        {
            string queryCommand = String.Format("UPDATE `{0}` SET `{1}` = '{2}' WHERE `{0}`.`{3}` = {4}", tablename, row, new_value, key_name, key_data);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //обновление столбца целиком
        public void updateDataRow(string tablename, string row, string new_value)
        {
            string queryCommand = String.Format("UPDATE `{0}` SET `{1}` = '{2}'", tablename, row, new_value);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //удаление данных по ключу
        public void deleteDataByKey(string tablename, string row, string key_name, string key_data)
        {
            string queryCommand = String.Format("DELETE `{0}` FROM `{1}`  WHERE `{0}`.`{2}` = `{3}`", tablename, row,  key_name, key_data);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //удаление данных по id
        public void deleteDataById(string tablename, string row, int id)
        {
            string queryCommand = String.Format("DELETE `{0}` FROM `{1}`  WHERE `{0}`.`id` = {2}", tablename, row, id);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //удаление строки
        public void deleteRawDataById(string tablename, int id)
        {
            string queryCommand = String.Format("DELETE FROM `{0}`  WHERE `{0}`.`id` = {1}", tablename,  id);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //удаление строки по значению ячейки
        public void deleteRawDataBykey(string tablename, string key_name, string value)
        {
            string queryCommand = String.Format("DELETE FROM `{0}`  WHERE `{0}`.`{1}` = '{2}'", tablename, key_name, value);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
        //удаление всех данных
        public void deleteDataAll(string tablename)
        {
            string queryCommand = String.Format("DELETE FROM `{0}` ", tablename);

            // Необходимая "ловушка" для случаев не возможности подкл. к БД
            using (MySqlConnection mySQLConn = new MySqlConnection())
            {
                // Строка для подключения
                mySQLConn.ConnectionString = mySCSB.ConnectionString;
                // Строка запроса
                MySqlCommand mySQLComm = new MySqlCommand(queryCommand, mySQLConn);
                try
                {
                    mySQLConn.Open(); // Открываем подключение к БД
                    mySQLComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Если ошибка, выводим её
                }
            }

        }
    }
}
