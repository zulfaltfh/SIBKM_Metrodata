using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Connections;

public class Program
{
    private static SqlConnection connection;
    private static string connectionString = "Data Source=MSI;Initial Catalog=db_hr_sibkm; Integrated Security=True;Connect Timeout=30;Encrypt=False;";  
    public static void Main(string[] args)
    {
        //GetAllCountry();
        //GetIdCountry("ZW");
        //InsertCountry("NK", "North Korea", 3);

        //UpdateCountry("NK", "Korea Utara");
        //Console.WriteLine();
        //GetIdCountry("NK");

        //UpdateCountry("ID", 3);
        //Console.WriteLine();
        //GetIdCountry("ID");

        //DeleteCountry("NK");
    }

    //Get All : Country --> method untuk menampilkan semua data yang ada pada tabel
    public static void GetAllCountry()
    {
        //instance SQL Connection
        connection = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "Select c.id,c.name,r.name from country c join region r on c.region_id = r.id;"; 
        //CommandText = untuk menuliskan perintah query yang ingin kita jalankan
        //Perintah query yang digunakan adalah seperti diatas yang mana untuk kolom region id diubah menjadi region namenya

        connection.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                //reader[x] diambil dari urutan kolomnya, index (x) diisi mulai dari 0
                Console.WriteLine("Country : " + reader[1]);
                Console.WriteLine("Region : " + reader[2]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Data Country masih kosong!");
        }
        reader.Close();
        connection.Close();
    }


    //Get Id : Country
    public static void GetIdCountry(string id)
    {
        //instance SQL Connection
        connection = new SqlConnection(connectionString);

        //SQL Command
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "Select c.id,c.name,r.name from country c join region r on c.region_id = r.id where c.id = @id;";
        //CommandText = untuk menuliskan perintah query yang ingin kita jalankan

        //SQL Parameter
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id"; //diisi sesuai dengan parameternya
        pId.SqlDbType = System.Data.SqlDbType.VarChar; //inisialisasi tipe data dari kolom id pada sql
        pId.Value = id;
        cmd.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            Console.WriteLine("Id : " + reader[0]);
            Console.WriteLine("Country : " + reader[1]);
            Console.WriteLine("Region : " + reader[2]);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Data Country dengan id : {id} tidak ditemukan!");
        }
        reader.Close();
        connection.Close();
    }

    //Insert Country
    public static void InsertCountry(string id, string name, int region_id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert into country (id,name,region_id) values (@id, @name, @region_id);";
            cmd.Transaction = transaction;

            //Instance SQL Parameter @id
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            cmd.Parameters.Add(pId);

            //Instance SQL Parameter @name
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            cmd.Parameters.Add(pName);

            //Instance SQL Parameter @region_id
            SqlParameter pReg = new SqlParameter();
            pReg.ParameterName = "@region_id";
            pReg.SqlDbType = System.Data.SqlDbType.Int;
            pReg.Value = region_id;
            cmd.Parameters.Add(pReg);

            cmd.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    //Update Country by Name
    public static void UpdateCountry(string id, string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Update country Set name = @name Where id = @id;";
            cmd.Transaction = transaction;

            //Instance SQL Parameter @id
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            cmd.Parameters.Add(pId);

            //Instance SQL Parameter @name
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            cmd.Parameters.Add(pName);

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    //Update Country by Region
    public static void UpdateCountry(string id, int region_id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Update country Set region_id = @region_id Where id = @id;";
            cmd.Transaction = transaction;

            //Instance SQL Parameter @id
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            cmd.Parameters.Add(pId);

            //Instance SQL Parameter @region_id
            SqlParameter pReg = new SqlParameter();
            pReg.ParameterName = "@region_id";
            pReg.SqlDbType = System.Data.SqlDbType.Int;
            pReg.Value = region_id;
            cmd.Parameters.Add(pReg);

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    //Delete Country
    public static void DeleteCountry(string id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete from country where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}