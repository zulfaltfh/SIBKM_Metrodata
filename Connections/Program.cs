using Connections.Controller;
using Connections.Controllers;
using Connections.Dbconnect;
using Connections.Models;
using Connections.Repositories;
using Connections.Views.CountryView;
using Connections.Views.RegionView;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Connections;

public class Program
{
    private static SqlConnection connection;

    public static void Main(string[] args)
    {
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Database Connectivity=========");
            Console.WriteLine("1. Manage Table Region");
            Console.WriteLine("2. Manage Table Country");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Region();
                    break;
                case 2:
                    Country();
                    break;
                case 3:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    public static void Region()
    {
        RegionController regionController = new RegionController(new RegionRepository(), new VRegion());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    regionController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get by Id Region =======");
                    Console.Write("Input Id: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    regionController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("======= Insert Region =======");
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    regionController.Insert(new Region
                    {
                        name = name
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    // Update
                    Console.Clear();
                    Console.WriteLine("======= Update Region =======");
                    Console.Write("Input Id : ");
                    var reg_id = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Edit Name : ");
                    var reg_name = Console.ReadLine();
                    regionController.Update(new Region
                    {
                        name = reg_name,
                        id = reg_id
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    // Delete
                    Console.Clear();
                    Console.WriteLine("======= Delete Region =======");
                    Console.Write("Input Id: ");
                    var del_id = Convert.ToInt16(Console.ReadLine());
                    regionController.Delete(del_id);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    public static void Country()
    {
        CountryController countryController = new CountryController(new CountryRepository(), new VCountry());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Country========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    countryController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get by Id Country =======");
                    Console.Write("Input Id: ");
                    var id = Console.ReadLine();
                    countryController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("======= Insert Country =======");
                    Console.Write("Input Id: ");
                    var idCountry = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var nameCountry = Console.ReadLine();
                    Console.Write("Input Id Region: ");
                    var idRegion = Convert.ToInt16(Console.ReadLine());
                    countryController.Insert(new Country
                    {
                        id = idCountry,
                        name = nameCountry,
                        region_id = idRegion
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    // Update
                    Console.Clear();
                    Console.WriteLine("======= Update Country =======");
                    Console.Write("Input Id: ");
                    var countryId = Console.ReadLine();
                    countryController.GetById(countryId);
                    Console.WriteLine("------------------------");
                    Console.Write("Edit Name: ");
                    var countryName = Console.ReadLine();
                    Console.Write("Edit Region: ");
                    var countryRegion = Convert.ToInt32(Console.ReadLine());
                    countryController.Update(new Country
                    {
                        id = countryId,
                        name = countryName,
                        region_id = countryRegion
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    // Delete
                    Console.Clear();
                    Console.WriteLine("======= Delete Country =======");
                    Console.Write("Input Id: ");
                    var deleteId = Console.ReadLine();
                    countryController.Delete(deleteId);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }
    //Get All : Country --> method untuk menampilkan semua data yang ada pada tabel
    /*public static void GetAllCountry()
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
            7
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
    }*/
}