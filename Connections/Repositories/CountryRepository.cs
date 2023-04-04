using Connections.Models;
using Connections.Dbconnect;
using Connections.Repositories.Interfaces;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connections.Views.RegionView;
using System.Xml.Linq;

namespace Connections.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();

            //Instance sql connection
            var connection = Sqlconnect.GetConnect();

            //Membuat instance SQL Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * from country";

            connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    countries.Add(new Country
                    {
                        id = reader.GetString(0),
                        name = reader.GetString(1),
                        region_id = reader.GetInt32(2)
                    });
                }
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();

            return countries;
        }

        public Country GetById(string id)
        {
            Country countries = new Country();

            //Instance sql connection
            var connection = Sqlconnect.GetConnect();

            //SQL Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * from country where id = @id;";

            //SQL Parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            cmd.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                countries.id = reader.GetString(0);
                countries.name = reader.GetString(1);
                countries.region_id = reader.GetInt32(2);
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();

            return countries;
        }

        public int Insert(Country countries)
        {
            var result = 0;
            var connection = Sqlconnect.GetConnect();
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
                pId.Value = countries.id;
                cmd.Parameters.Add(pId);

                //Instance SQL Parameter @name
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = countries.name;
                cmd.Parameters.Add(pName);
                
                //Instance SQL Parameter @region_id
                SqlParameter pReg = new SqlParameter();
                pReg.ParameterName = "@region_id";
                pReg.SqlDbType = System.Data.SqlDbType.Int;
                pReg.Value = countries.region_id;
                cmd.Parameters.Add(pReg);

                result = cmd.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }

            return result;
        }

        public int Update(Country countries)
        {
            var result = 0;
            var connection = Sqlconnect.GetConnect();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE country SET name = @name, region_id = @region_id WHERE id = @id;";
                cmd.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = countries.name;
                cmd.Parameters.Add(pName);

                SqlParameter pRegion = new SqlParameter();
                pRegion.ParameterName = "@region_id";
                pRegion.SqlDbType = System.Data.SqlDbType.Int;
                pRegion.Value = countries.region_id;
                cmd.Parameters.Add(pRegion);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = countries.id;
                cmd.Parameters.Add(pId);

                result = cmd.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception) { throw; }
            }
            return result;
        }
        public int Delete(string id)
        {
            var result = 0;
            var connection = Sqlconnect.GetConnect();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Delete from country where id = @id;";
                cmd.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                result = cmd.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }

            return result;
        }
    }
}
