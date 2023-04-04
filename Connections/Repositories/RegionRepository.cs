using Connections.Dbconnect;
using Connections.Models;
using Connections.Repositories.Interfaces;
using Connections.Views.RegionView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connections.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        public List<Region> GetAll()
        {
            List<Region> regions = new List<Region>();

            //Instance sql connection
            var connection = Sqlconnect.GetConnect();

            //Membuat instance SQL Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * from region";

            connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    // alt 1
                    /*Region region = new Region();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);*/

                    // alt 2
                    /*Region region = new Region {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    regions.Add(region);*/

                    // alt 3
                    regions.Add(new Region
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1)
                    });
                }
            } else {
                return null;
            }
            reader.Close();
            connection.Close();

            return regions;
        }

        public Region GetById(int id)
        {

            Region regions = new Region();

            //Instance sql connection
            var connection = Sqlconnect.GetConnect();

            //Membuat instance SQL Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * From region Where id = @id;";

            //Instance SQL Parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            cmd.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                regions.id = reader.GetInt32(0);
                regions.name = reader.GetString(1);
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();

            return regions;
        }

        public int Insert(Region region)
        {
            var result = 0;
            var connection = Sqlconnect.GetConnect();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Insert Into region name Values @name;";
                cmd.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = region.name;
                cmd.Parameters.Add(pName);

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

        public int Update(Region region)
        {
            var result = 0;
            var connection = Sqlconnect.GetConnect();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Update region Set name = @name Where id = @id;";
                cmd.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = region.id;
                cmd.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = region.name;
                cmd.Parameters.Add(pName);

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

        public int Delete(int id)
        {
            var result = 0;
            var connection = Sqlconnect.GetConnect();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Delete From region where id = @id;";
                cmd.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
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
