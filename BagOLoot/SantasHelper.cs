using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelper
    {
        private List<string> _children = new List<string>();
        private List<Toys> _toys = new List<Toys>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public SantaHelper()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public int AddToyToBag(string toy, int child)
        {
            // Return the new toy id
            //return 4;
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                ChildRegister myregister = new ChildRegister();
                dbcmd.CommandText = $"insert into bag values (null, '{toy}', {child})";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _lastId;
        }

        public List<Toys> GetChildsToys(int child)
        {
           
            using(_connection)
            {
                _connection.Open();
                
                SqliteCommand dbcmd = _connection.CreateCommand();
                //slect id and name of every child
                dbcmd.CommandText = $"select toy_id,toy,child_id from bag where child_id={child}";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    //read each row of the result set
                    
                    while(dr.Read())
                    {
                        _toys.Add( new Toys(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)) );//add toy name to list
                    }
                }

                //cleanup
                dbcmd.Dispose();
                _connection.Close();
            }
            return _toys;
            //return new List<int>() { 4, 6, 7, 8 };
        }

         public void RemoveToyFromBag (int toyId)
        {
             _connection.Open();
                
                SqliteCommand dbcmd = _connection.CreateCommand();
                //slect id and name of every child
                dbcmd.CommandText = $"delete from bag where toy_id={toyId}";
                Console.WriteLine(dbcmd.CommandText);
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    //read each row of the result set
                    
                    while(dr.Read())
                    {
                    
                    }
                }
                
                //cleanup
                dbcmd.Dispose();
                _connection.Close();
            
        }

        public bool IsDelivered(int child)
        {
             using(_connection)
            {
                _connection.Open();
                
                SqliteCommand dbcmd = _connection.CreateCommand();
                //update delivered in child table
                dbcmd.CommandText = $"update child set delivered = 1 where id={child}";
                Console.WriteLine(dbcmd.CommandText);
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    //read each row of the result set
                    
                    while(dr.Read())
                    {
                        
                    }
                }
                //cleanup
                dbcmd.Dispose();
                _connection.Close();
            }
            return true;
        }
        public List<int> GetChildrenWithToys()
        {
            return new List<int>() { 1, 2, 3, 4, 6 };
        }
    }
}