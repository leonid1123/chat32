using MySql.Data.MySqlClient;
string connectionString = @"server=192.168.1.45;userid=chat_admin;password=123456;database=chat32";
MySqlConnection conn = new MySqlConnection(connectionString);
conn.Open();
if (conn.State.ToString() == "Open")
{
    Console.WriteLine("Подключение успешно");
}
else
{
    Console.WriteLine("Всё пропало!");
}
Console.WriteLine("Введите логин");
string login = Console.ReadLine().Trim();
Console.WriteLine("Введите пароль");
string password = Console.ReadLine().Trim();
if (login.Length > 0 & password.Length > 0)
{
    string sql1 = "SELECT password FROM auth WHERE login = @login";
    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
    cmd1.Parameters.AddWithValue("@login", login);
    cmd1.Prepare();
    MySqlDataReader rdr = cmd1.ExecuteReader();
    if (rdr.HasRows)
    {
        //проверить пароль
        while (rdr.Read())
        {
            string storedPassword = rdr.GetString(0);
            if (password.Equals(storedPassword)) {
                Console.WriteLine("всё хорошо");
            }
        }
    }
    else
    {
        Console.WriteLine("ТАКОГО ПОЛЬЗОВАТЕЛЯ НЕТ!!!");
    }
}