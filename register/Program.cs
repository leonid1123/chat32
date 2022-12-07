using MySql.Data.MySqlClient;
//string connectionString = @"server=192.168.1.45;userid=chat_admin;password=123456;database=chat32";
string connectionString = @"server=localhost;userid=chat_admin;password=123456;database=chat32";
MySqlConnection conn = new MySqlConnection(connectionString);
conn.Open();
if (conn.State.ToString()=="Open") {
    Console.WriteLine("Подключение успешно");
} else {
    Console.WriteLine("Всё пропало!");
}
Console.WriteLine("Пройдите обязательную регистрацию");
Console.WriteLine("Введите ник и нажмите Enter");
string nik = Console.ReadLine();
Console.WriteLine("Введите логин и нажмите Enter");
string login = Console.ReadLine();
Console.WriteLine("Введите пароль и нажмите Enter");
string password = Console.ReadLine();

string sql1 = "SELECT id FROM auth WHERE username = @nik";
MySqlCommand cmd1 = new MySqlCommand(sql1,conn);
cmd1.Parameters.AddWithValue("@nik",nik);
cmd1.Prepare();
MySqlDataReader rdr = cmd1.ExecuteReader();
if(rdr.HasRows) {
    Console.WriteLine("Такой ник занят");
}else {
    Console.WriteLine("Такой ник свободен");
    conn.Close();
    conn.Open();
    string sql2 ="INSERT INTO auth(username,login,password) VALUES(@nik,@login,@pass)";
    MySqlCommand cmd2 = new MySqlCommand(sql2,conn);
    cmd2.Parameters.AddWithValue("@nik",nik);
    cmd2.Parameters.AddWithValue("@login",login);
    cmd2.Parameters.AddWithValue("@pass",password);
    cmd2.Prepare();
    cmd2.ExecuteNonQuery();
    Console.WriteLine("Ты зарегистрирован! ПОДГОТОВЬСЯ!!!");
}
