/************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************
 Created By: EJ Alexandra - 2016
             An Abstract Level, llc
 License:    Mozilla Public License 2.0
 ************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

using MorseCodeHelper.Lib.DataClasses;

using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.SqlDataManagement
{
    public partial class SqlDataManager : IDisposable
    {
        public SqlDataManager() : this(SqlDataManager.LastConnectionString) 
        {
            this.Schema = "dbo";
        }
    
        public SqlDataManager(String connectionString)
        {
            this.Schema = "dbo";
            this.ConnectionString = connectionString;
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                this.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }
        }

        public SqlDataManager(String dataSourceName, String dbName) 
        {
            this.Schema = "dbo";
            this.DataSourceName = dataSourceName;
            this.DBName = dbName;
        }
        
        public void Dispose() 
        {
            this.IsDisposed = true;
        }
        
        public static string LastConnectionString { get; set; }
        public string ConnectionString { get; set; }
        public String DataSourceName { get; set; }
        public String DBName { get; set; }
        public Boolean IsDisposed { get; set; }
        public String Schema { get; set; }
        

  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Alphabet alphabet)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Alphabet] (AlphabetId, Name, Description, CountryId)
                                    VALUES (@AlphabetId, @Name, @Description, @CountryId)", this.Schema);

                
                  
                if (ReferenceEquals(alphabet.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", alphabet.AlphabetId);
                
                  
                if (ReferenceEquals(alphabet.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", alphabet.Name);
                
                  
                if (ReferenceEquals(alphabet.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", alphabet.Description);
                
                  
                if (ReferenceEquals(alphabet.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CountryId", alphabet.CountryId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Alphabet alphabet)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = alphabet.AlphabetId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Alphabet WHERE AlphabetId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(alphabet);
                else return this.Insert(alphabet);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAlphabets<T>()
            where T : Alphabet, new()
        {
            return this.GetAllAlphabets<T>(String.Empty);
        }

        
        public List<T> GetAllAlphabets<T>(String whereClause)
            where T : Alphabet, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Alphabet]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T alphabet = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AlphabetId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          alphabet.AlphabetId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          alphabet.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          alphabet.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CountryId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          alphabet.CountryId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(alphabet);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Alphabet
        /// </summary>
        /// <returns></returns>
        public int Update(Alphabet alphabet)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Alphabet] SET 
                                    Name = @Name,Description = @Description,CountryId = @CountryId
                                    WHERE AlphabetId = @AlphabetId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(alphabet.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", alphabet.AlphabetId);
                 //TEXT
                
                if (ReferenceEquals(alphabet.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", alphabet.Name);
                 //TEXT
                
                if (ReferenceEquals(alphabet.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", alphabet.Description);
                 //GUID
                
                if (ReferenceEquals(alphabet.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CountryId", alphabet.CountryId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Alphabet
        /// </summary>
        /// <returns></returns>
        public int Delete(Alphabet alphabet)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Alphabet] 
                                    WHERE AlphabetId = @AlphabetId", this.Schema);
                                    
                
                if (ReferenceEquals(alphabet.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AlphabetId", alphabet.AlphabetId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Character character)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Character] (CharacterId, Name, Description, SequenceCode, Symbol, AlphabetId)
                                    VALUES (@CharacterId, @Name, @Description, @SequenceCode, @Symbol, @AlphabetId)", this.Schema);

                
                  
                if (ReferenceEquals(character.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", character.CharacterId);
                
                  
                if (ReferenceEquals(character.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", character.Name);
                
                  
                if (ReferenceEquals(character.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", character.Description);
                
                  
                if (ReferenceEquals(character.SequenceCode, null)) cmd.Parameters.AddWithValue("@SequenceCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SequenceCode", character.SequenceCode);
                
                  
                if (ReferenceEquals(character.Symbol, null)) cmd.Parameters.AddWithValue("@Symbol", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Symbol", character.Symbol);
                
                  
                if (ReferenceEquals(character.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", character.AlphabetId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Character character)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = character.CharacterId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Character WHERE CharacterId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(character);
                else return this.Insert(character);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllCharacters<T>()
            where T : Character, new()
        {
            return this.GetAllCharacters<T>(String.Empty);
        }

        
        public List<T> GetAllCharacters<T>(String whereClause)
            where T : Character, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Character]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T character = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          character.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          character.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          character.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("SequenceCode");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          character.SequenceCode = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Symbol");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          character.Symbol = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("AlphabetId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          character.AlphabetId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(character);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Character
        /// </summary>
        /// <returns></returns>
        public int Update(Character character)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Character] SET 
                                    Name = @Name,Description = @Description,SequenceCode = @SequenceCode,Symbol = @Symbol,AlphabetId = @AlphabetId
                                    WHERE CharacterId = @CharacterId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(character.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", character.CharacterId);
                 //TEXT
                
                if (ReferenceEquals(character.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", character.Name);
                 //TEXT
                
                if (ReferenceEquals(character.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", character.Description);
                 //TEXT
                
                if (ReferenceEquals(character.SequenceCode, null)) cmd.Parameters.AddWithValue("@SequenceCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SequenceCode", character.SequenceCode);
                 //text
                
                if (ReferenceEquals(character.Symbol, null)) cmd.Parameters.AddWithValue("@Symbol", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Symbol", character.Symbol);
                 //GUID
                
                if (ReferenceEquals(character.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", character.AlphabetId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Character
        /// </summary>
        /// <returns></returns>
        public int Delete(Character character)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Character] 
                                    WHERE CharacterId = @CharacterId", this.Schema);
                                    
                
                if (ReferenceEquals(character.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CharacterId", character.CharacterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Communication communication)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Communication] (CommunicationId, Name, Description, TelegraphStationId, AlphabetId)
                                    VALUES (@CommunicationId, @Name, @Description, @TelegraphStationId, @AlphabetId)", this.Schema);

                
                  
                if (ReferenceEquals(communication.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", communication.CommunicationId);
                
                  
                if (ReferenceEquals(communication.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", communication.Name);
                
                  
                if (ReferenceEquals(communication.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", communication.Description);
                
                  
                if (ReferenceEquals(communication.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphStationId", communication.TelegraphStationId);
                
                  
                if (ReferenceEquals(communication.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", communication.AlphabetId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Communication communication)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = communication.CommunicationId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Communication WHERE CommunicationId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(communication);
                else return this.Insert(communication);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllCommunications<T>()
            where T : Communication, new()
        {
            return this.GetAllCommunications<T>(String.Empty);
        }

        
        public List<T> GetAllCommunications<T>(String whereClause)
            where T : Communication, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Communication]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T communication = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          communication.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          communication.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          communication.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("TelegraphStationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          communication.TelegraphStationId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("AlphabetId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          communication.AlphabetId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(communication);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Communication
        /// </summary>
        /// <returns></returns>
        public int Update(Communication communication)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Communication] SET 
                                    Name = @Name,Description = @Description,TelegraphStationId = @TelegraphStationId,AlphabetId = @AlphabetId
                                    WHERE CommunicationId = @CommunicationId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(communication.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", communication.CommunicationId);
                 //TEXT
                
                if (ReferenceEquals(communication.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", communication.Name);
                 //TEXT
                
                if (ReferenceEquals(communication.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", communication.Description);
                 //GUID
                
                if (ReferenceEquals(communication.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphStationId", communication.TelegraphStationId);
                 //GUID
                
                if (ReferenceEquals(communication.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", communication.AlphabetId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Communication
        /// </summary>
        /// <returns></returns>
        public int Delete(Communication communication)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Communication] 
                                    WHERE CommunicationId = @CommunicationId", this.Schema);
                                    
                
                if (ReferenceEquals(communication.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CommunicationId", communication.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Controller controller)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Controller] (ControllerId, Name, Description, CommunicationId)
                                    VALUES (@ControllerId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(controller.ControllerId, null)) cmd.Parameters.AddWithValue("@ControllerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ControllerId", controller.ControllerId);
                
                  
                if (ReferenceEquals(controller.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", controller.Name);
                
                  
                if (ReferenceEquals(controller.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", controller.Description);
                
                  
                if (ReferenceEquals(controller.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", controller.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Controller controller)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = controller.ControllerId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Controller WHERE ControllerId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(controller);
                else return this.Insert(controller);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllControllers<T>()
            where T : Controller, new()
        {
            return this.GetAllControllers<T>(String.Empty);
        }

        
        public List<T> GetAllControllers<T>(String whereClause)
            where T : Controller, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Controller]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T controller = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ControllerId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          controller.ControllerId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          controller.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          controller.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          controller.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(controller);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Controller
        /// </summary>
        /// <returns></returns>
        public int Update(Controller controller)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Controller] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE ControllerId = @ControllerId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(controller.ControllerId, null)) cmd.Parameters.AddWithValue("@ControllerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ControllerId", controller.ControllerId);
                 //TEXT
                
                if (ReferenceEquals(controller.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", controller.Name);
                 //TEXT
                
                if (ReferenceEquals(controller.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", controller.Description);
                 //GUID
                
                if (ReferenceEquals(controller.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", controller.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Controller
        /// </summary>
        /// <returns></returns>
        public int Delete(Controller controller)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Controller] 
                                    WHERE ControllerId = @ControllerId", this.Schema);
                                    
                
                if (ReferenceEquals(controller.ControllerId, null)) cmd.Parameters.AddWithValue("@ControllerId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ControllerId", controller.ControllerId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Country country)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Country] (CountryId, Name, Description)
                                    VALUES (@CountryId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(country.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
                
                  
                if (ReferenceEquals(country.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", country.Name);
                
                  
                if (ReferenceEquals(country.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", country.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Country country)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = country.CountryId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Country WHERE CountryId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(country);
                else return this.Insert(country);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllCountries<T>()
            where T : Country, new()
        {
            return this.GetAllCountries<T>(String.Empty);
        }

        
        public List<T> GetAllCountries<T>(String whereClause)
            where T : Country, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Country]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T country = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("CountryId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          country.CountryId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          country.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          country.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(country);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Country
        /// </summary>
        /// <returns></returns>
        public int Update(Country country)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Country] SET 
                                    Name = @Name,Description = @Description
                                    WHERE CountryId = @CountryId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(country.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
                 //TEXT
                
                if (ReferenceEquals(country.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", country.Name);
                 //TEXT
                
                if (ReferenceEquals(country.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", country.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Country
        /// </summary>
        /// <returns></returns>
        public int Delete(Country country)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Country] 
                                    WHERE CountryId = @CountryId", this.Schema);
                                    
                
                if (ReferenceEquals(country.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(MCDevice mCDevice)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[MCDevice] (MCDeviceId, Name, Description, TelegraphStationId)
                                    VALUES (@MCDeviceId, @Name, @Description, @TelegraphStationId)", this.Schema);

                
                  
                if (ReferenceEquals(mCDevice.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", mCDevice.MCDeviceId);
                
                  
                if (ReferenceEquals(mCDevice.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", mCDevice.Name);
                
                  
                if (ReferenceEquals(mCDevice.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", mCDevice.Description);
                
                  
                if (ReferenceEquals(mCDevice.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphStationId", mCDevice.TelegraphStationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(MCDevice mCDevice)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = mCDevice.MCDeviceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM MCDevice WHERE MCDeviceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(mCDevice);
                else return this.Insert(mCDevice);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllMCDevices<T>()
            where T : MCDevice, new()
        {
            return this.GetAllMCDevices<T>(String.Empty);
        }

        
        public List<T> GetAllMCDevices<T>(String whereClause)
            where T : MCDevice, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[MCDevice]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T mCDevice = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("MCDeviceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          mCDevice.MCDeviceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          mCDevice.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          mCDevice.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("TelegraphStationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          mCDevice.TelegraphStationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(mCDevice);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified MCDevice
        /// </summary>
        /// <returns></returns>
        public int Update(MCDevice mCDevice)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[MCDevice] SET 
                                    Name = @Name,Description = @Description,TelegraphStationId = @TelegraphStationId
                                    WHERE MCDeviceId = @MCDeviceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(mCDevice.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", mCDevice.MCDeviceId);
                 //TEXT
                
                if (ReferenceEquals(mCDevice.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", mCDevice.Name);
                 //TEXT
                
                if (ReferenceEquals(mCDevice.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", mCDevice.Description);
                 //GUID
                
                if (ReferenceEquals(mCDevice.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphStationId", mCDevice.TelegraphStationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified MCDevice
        /// </summary>
        /// <returns></returns>
        public int Delete(MCDevice mCDevice)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[MCDevice] 
                                    WHERE MCDeviceId = @MCDeviceId", this.Schema);
                                    
                
                if (ReferenceEquals(mCDevice.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@MCDeviceId", mCDevice.MCDeviceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Language language)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Language] (LanguageId, Name, Description, CountryId)
                                    VALUES (@LanguageId, @Name, @Description, @CountryId)", this.Schema);

                
                  
                if (ReferenceEquals(language.LanguageId, null)) cmd.Parameters.AddWithValue("@LanguageId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LanguageId", language.LanguageId);
                
                  
                if (ReferenceEquals(language.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", language.Name);
                
                  
                if (ReferenceEquals(language.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", language.Description);
                
                  
                if (ReferenceEquals(language.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CountryId", language.CountryId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Language language)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = language.LanguageId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Language WHERE LanguageId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(language);
                else return this.Insert(language);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllLanguages<T>()
            where T : Language, new()
        {
            return this.GetAllLanguages<T>(String.Empty);
        }

        
        public List<T> GetAllLanguages<T>(String whereClause)
            where T : Language, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Language]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T language = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("LanguageId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          language.LanguageId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          language.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          language.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CountryId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          language.CountryId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(language);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Language
        /// </summary>
        /// <returns></returns>
        public int Update(Language language)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Language] SET 
                                    Name = @Name,Description = @Description,CountryId = @CountryId
                                    WHERE LanguageId = @LanguageId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(language.LanguageId, null)) cmd.Parameters.AddWithValue("@LanguageId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LanguageId", language.LanguageId);
                 //TEXT
                
                if (ReferenceEquals(language.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", language.Name);
                 //TEXT
                
                if (ReferenceEquals(language.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", language.Description);
                 //GUID
                
                if (ReferenceEquals(language.CountryId, null)) cmd.Parameters.AddWithValue("@CountryId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CountryId", language.CountryId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Language
        /// </summary>
        /// <returns></returns>
        public int Delete(Language language)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Language] 
                                    WHERE LanguageId = @LanguageId", this.Schema);
                                    
                
                if (ReferenceEquals(language.LanguageId, null)) cmd.Parameters.AddWithValue("@LanguageId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@LanguageId", language.LanguageId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Light light)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Light] (LightId, Name, Description, MCDeviceId)
                                    VALUES (@LightId, @Name, @Description, @MCDeviceId)", this.Schema);

                
                  
                if (ReferenceEquals(light.LightId, null)) cmd.Parameters.AddWithValue("@LightId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LightId", light.LightId);
                
                  
                if (ReferenceEquals(light.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", light.Name);
                
                  
                if (ReferenceEquals(light.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", light.Description);
                
                  
                if (ReferenceEquals(light.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", light.MCDeviceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Light light)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = light.LightId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Light WHERE LightId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(light);
                else return this.Insert(light);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllLights<T>()
            where T : Light, new()
        {
            return this.GetAllLights<T>(String.Empty);
        }

        
        public List<T> GetAllLights<T>(String whereClause)
            where T : Light, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Light]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T light = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("LightId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          light.LightId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          light.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          light.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("MCDeviceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          light.MCDeviceId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(light);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Light
        /// </summary>
        /// <returns></returns>
        public int Update(Light light)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Light] SET 
                                    Name = @Name,Description = @Description,MCDeviceId = @MCDeviceId
                                    WHERE LightId = @LightId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(light.LightId, null)) cmd.Parameters.AddWithValue("@LightId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LightId", light.LightId);
                 //TEXT
                
                if (ReferenceEquals(light.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", light.Name);
                 //TEXT
                
                if (ReferenceEquals(light.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", light.Description);
                 //GUID
                
                if (ReferenceEquals(light.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", light.MCDeviceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Light
        /// </summary>
        /// <returns></returns>
        public int Delete(Light light)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Light] 
                                    WHERE LightId = @LightId", this.Schema);
                                    
                
                if (ReferenceEquals(light.LightId, null)) cmd.Parameters.AddWithValue("@LightId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@LightId", light.LightId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Listener listener)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Listener] (ListenerId, Name, Description, CommunicationId)
                                    VALUES (@ListenerId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(listener.ListenerId, null)) cmd.Parameters.AddWithValue("@ListenerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ListenerId", listener.ListenerId);
                
                  
                if (ReferenceEquals(listener.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", listener.Name);
                
                  
                if (ReferenceEquals(listener.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", listener.Description);
                
                  
                if (ReferenceEquals(listener.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", listener.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Listener listener)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = listener.ListenerId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Listener WHERE ListenerId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(listener);
                else return this.Insert(listener);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllListeners<T>()
            where T : Listener, new()
        {
            return this.GetAllListeners<T>(String.Empty);
        }

        
        public List<T> GetAllListeners<T>(String whereClause)
            where T : Listener, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Listener]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T listener = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ListenerId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          listener.ListenerId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          listener.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          listener.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          listener.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(listener);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Listener
        /// </summary>
        /// <returns></returns>
        public int Update(Listener listener)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Listener] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE ListenerId = @ListenerId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(listener.ListenerId, null)) cmd.Parameters.AddWithValue("@ListenerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ListenerId", listener.ListenerId);
                 //TEXT
                
                if (ReferenceEquals(listener.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", listener.Name);
                 //TEXT
                
                if (ReferenceEquals(listener.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", listener.Description);
                 //GUID
                
                if (ReferenceEquals(listener.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", listener.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Listener
        /// </summary>
        /// <returns></returns>
        public int Delete(Listener listener)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Listener] 
                                    WHERE ListenerId = @ListenerId", this.Schema);
                                    
                
                if (ReferenceEquals(listener.ListenerId, null)) cmd.Parameters.AddWithValue("@ListenerId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ListenerId", listener.ListenerId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Observer observer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Observer] (ObserverId, Name, Description, CommunicationId)
                                    VALUES (@ObserverId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(observer.ObserverId, null)) cmd.Parameters.AddWithValue("@ObserverId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ObserverId", observer.ObserverId);
                
                  
                if (ReferenceEquals(observer.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", observer.Name);
                
                  
                if (ReferenceEquals(observer.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", observer.Description);
                
                  
                if (ReferenceEquals(observer.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", observer.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Observer observer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = observer.ObserverId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Observer WHERE ObserverId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(observer);
                else return this.Insert(observer);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllObservers<T>()
            where T : Observer, new()
        {
            return this.GetAllObservers<T>(String.Empty);
        }

        
        public List<T> GetAllObservers<T>(String whereClause)
            where T : Observer, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Observer]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T observer = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ObserverId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          observer.ObserverId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          observer.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          observer.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          observer.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(observer);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Observer
        /// </summary>
        /// <returns></returns>
        public int Update(Observer observer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Observer] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE ObserverId = @ObserverId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(observer.ObserverId, null)) cmd.Parameters.AddWithValue("@ObserverId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ObserverId", observer.ObserverId);
                 //TEXT
                
                if (ReferenceEquals(observer.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", observer.Name);
                 //TEXT
                
                if (ReferenceEquals(observer.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", observer.Description);
                 //GUID
                
                if (ReferenceEquals(observer.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", observer.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Observer
        /// </summary>
        /// <returns></returns>
        public int Delete(Observer observer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Observer] 
                                    WHERE ObserverId = @ObserverId", this.Schema);
                                    
                
                if (ReferenceEquals(observer.ObserverId, null)) cmd.Parameters.AddWithValue("@ObserverId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ObserverId", observer.ObserverId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(TelegraphOperator telegraphOperator)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[TelegraphOperator] (TelegraphOperatorId, Name, Description, CommunicationId)
                                    VALUES (@TelegraphOperatorId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(telegraphOperator.TelegraphOperatorId, null)) cmd.Parameters.AddWithValue("@TelegraphOperatorId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphOperatorId", telegraphOperator.TelegraphOperatorId);
                
                  
                if (ReferenceEquals(telegraphOperator.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", telegraphOperator.Name);
                
                  
                if (ReferenceEquals(telegraphOperator.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", telegraphOperator.Description);
                
                  
                if (ReferenceEquals(telegraphOperator.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", telegraphOperator.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(TelegraphOperator telegraphOperator)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = telegraphOperator.TelegraphOperatorId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM TelegraphOperator WHERE TelegraphOperatorId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(telegraphOperator);
                else return this.Insert(telegraphOperator);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllTelegraphOperators<T>()
            where T : TelegraphOperator, new()
        {
            return this.GetAllTelegraphOperators<T>(String.Empty);
        }

        
        public List<T> GetAllTelegraphOperators<T>(String whereClause)
            where T : TelegraphOperator, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[TelegraphOperator]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T telegraphOperator = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("TelegraphOperatorId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          telegraphOperator.TelegraphOperatorId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          telegraphOperator.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          telegraphOperator.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          telegraphOperator.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(telegraphOperator);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified TelegraphOperator
        /// </summary>
        /// <returns></returns>
        public int Update(TelegraphOperator telegraphOperator)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[TelegraphOperator] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE TelegraphOperatorId = @TelegraphOperatorId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(telegraphOperator.TelegraphOperatorId, null)) cmd.Parameters.AddWithValue("@TelegraphOperatorId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphOperatorId", telegraphOperator.TelegraphOperatorId);
                 //TEXT
                
                if (ReferenceEquals(telegraphOperator.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", telegraphOperator.Name);
                 //TEXT
                
                if (ReferenceEquals(telegraphOperator.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", telegraphOperator.Description);
                 //GUID
                
                if (ReferenceEquals(telegraphOperator.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", telegraphOperator.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified TelegraphOperator
        /// </summary>
        /// <returns></returns>
        public int Delete(TelegraphOperator telegraphOperator)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[TelegraphOperator] 
                                    WHERE TelegraphOperatorId = @TelegraphOperatorId", this.Schema);
                                    
                
                if (ReferenceEquals(telegraphOperator.TelegraphOperatorId, null)) cmd.Parameters.AddWithValue("@TelegraphOperatorId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@TelegraphOperatorId", telegraphOperator.TelegraphOperatorId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Proficiency proficiency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Proficiency] (ProficiencyId, Name, Description, OperatorId)
                                    VALUES (@ProficiencyId, @Name, @Description, @OperatorId)", this.Schema);

                
                  
                if (ReferenceEquals(proficiency.ProficiencyId, null)) cmd.Parameters.AddWithValue("@ProficiencyId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ProficiencyId", proficiency.ProficiencyId);
                
                  
                if (ReferenceEquals(proficiency.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", proficiency.Name);
                
                  
                if (ReferenceEquals(proficiency.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", proficiency.Description);
                
                  
                if (ReferenceEquals(proficiency.OperatorId, null)) cmd.Parameters.AddWithValue("@OperatorId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@OperatorId", proficiency.OperatorId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Proficiency proficiency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = proficiency.ProficiencyId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Proficiency WHERE ProficiencyId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(proficiency);
                else return this.Insert(proficiency);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllProficiencies<T>()
            where T : Proficiency, new()
        {
            return this.GetAllProficiencies<T>(String.Empty);
        }

        
        public List<T> GetAllProficiencies<T>(String whereClause)
            where T : Proficiency, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Proficiency]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T proficiency = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ProficiencyId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          proficiency.ProficiencyId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          proficiency.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          proficiency.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("OperatorId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          proficiency.OperatorId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(proficiency);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Proficiency
        /// </summary>
        /// <returns></returns>
        public int Update(Proficiency proficiency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Proficiency] SET 
                                    Name = @Name,Description = @Description,OperatorId = @OperatorId
                                    WHERE ProficiencyId = @ProficiencyId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(proficiency.ProficiencyId, null)) cmd.Parameters.AddWithValue("@ProficiencyId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ProficiencyId", proficiency.ProficiencyId);
                 //TEXT
                
                if (ReferenceEquals(proficiency.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", proficiency.Name);
                 //TEXT
                
                if (ReferenceEquals(proficiency.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", proficiency.Description);
                 //GUID
                
                if (ReferenceEquals(proficiency.OperatorId, null)) cmd.Parameters.AddWithValue("@OperatorId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@OperatorId", proficiency.OperatorId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Proficiency
        /// </summary>
        /// <returns></returns>
        public int Delete(Proficiency proficiency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Proficiency] 
                                    WHERE ProficiencyId = @ProficiencyId", this.Schema);
                                    
                
                if (ReferenceEquals(proficiency.ProficiencyId, null)) cmd.Parameters.AddWithValue("@ProficiencyId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ProficiencyId", proficiency.ProficiencyId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Repeater repeater)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Repeater] (RepeaterId, Name, Description, MCDeviceId)
                                    VALUES (@RepeaterId, @Name, @Description, @MCDeviceId)", this.Schema);

                
                  
                if (ReferenceEquals(repeater.RepeaterId, null)) cmd.Parameters.AddWithValue("@RepeaterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@RepeaterId", repeater.RepeaterId);
                
                  
                if (ReferenceEquals(repeater.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", repeater.Name);
                
                  
                if (ReferenceEquals(repeater.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", repeater.Description);
                
                  
                if (ReferenceEquals(repeater.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", repeater.MCDeviceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Repeater repeater)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = repeater.RepeaterId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Repeater WHERE RepeaterId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(repeater);
                else return this.Insert(repeater);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllRepeaters<T>()
            where T : Repeater, new()
        {
            return this.GetAllRepeaters<T>(String.Empty);
        }

        
        public List<T> GetAllRepeaters<T>(String whereClause)
            where T : Repeater, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Repeater]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T repeater = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("RepeaterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          repeater.RepeaterId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          repeater.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          repeater.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("MCDeviceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          repeater.MCDeviceId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(repeater);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Repeater
        /// </summary>
        /// <returns></returns>
        public int Update(Repeater repeater)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Repeater] SET 
                                    Name = @Name,Description = @Description,MCDeviceId = @MCDeviceId
                                    WHERE RepeaterId = @RepeaterId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(repeater.RepeaterId, null)) cmd.Parameters.AddWithValue("@RepeaterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@RepeaterId", repeater.RepeaterId);
                 //TEXT
                
                if (ReferenceEquals(repeater.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", repeater.Name);
                 //TEXT
                
                if (ReferenceEquals(repeater.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", repeater.Description);
                 //GUID
                
                if (ReferenceEquals(repeater.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", repeater.MCDeviceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Repeater
        /// </summary>
        /// <returns></returns>
        public int Delete(Repeater repeater)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Repeater] 
                                    WHERE RepeaterId = @RepeaterId", this.Schema);
                                    
                
                if (ReferenceEquals(repeater.RepeaterId, null)) cmd.Parameters.AddWithValue("@RepeaterId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@RepeaterId", repeater.RepeaterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(CharacterSquence characterSquence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[CharacterSquence] (CharacterSquenceId, Name, Description, Index, CharacterId, SignalId)
                                    VALUES (@CharacterSquenceId, @Name, @Description, @Index, @CharacterId, @SignalId)", this.Schema);

                
                  
                if (ReferenceEquals(characterSquence.CharacterSquenceId, null)) cmd.Parameters.AddWithValue("@CharacterSquenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterSquenceId", characterSquence.CharacterSquenceId);
                
                  
                if (ReferenceEquals(characterSquence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", characterSquence.Name);
                
                  
                if (ReferenceEquals(characterSquence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", characterSquence.Description);
                
                  
                if (ReferenceEquals(characterSquence.Index, null)) cmd.Parameters.AddWithValue("@Index", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Index", characterSquence.Index);
                
                  
                if (ReferenceEquals(characterSquence.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", characterSquence.CharacterId);
                
                  
                if (ReferenceEquals(characterSquence.SignalId, null)) cmd.Parameters.AddWithValue("@SignalId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SignalId", characterSquence.SignalId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(CharacterSquence characterSquence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = characterSquence.CharacterSquenceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM CharacterSquence WHERE CharacterSquenceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(characterSquence);
                else return this.Insert(characterSquence);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllCharacterSquences<T>()
            where T : CharacterSquence, new()
        {
            return this.GetAllCharacterSquences<T>(String.Empty);
        }

        
        public List<T> GetAllCharacterSquences<T>(String whereClause)
            where T : CharacterSquence, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[CharacterSquence]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T characterSquence = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("CharacterSquenceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          characterSquence.CharacterSquenceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          characterSquence.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          characterSquence.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Index");
                      if (!reader.IsDBNull(propertyIndex)) //INT32
                      {
                          
                          characterSquence.Index = reader.GetInt32(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          characterSquence.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("SignalId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          characterSquence.SignalId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(characterSquence);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified CharacterSquence
        /// </summary>
        /// <returns></returns>
        public int Update(CharacterSquence characterSquence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[CharacterSquence] SET 
                                    Name = @Name,Description = @Description,Index = @Index,CharacterId = @CharacterId,SignalId = @SignalId
                                    WHERE CharacterSquenceId = @CharacterSquenceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(characterSquence.CharacterSquenceId, null)) cmd.Parameters.AddWithValue("@CharacterSquenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterSquenceId", characterSquence.CharacterSquenceId);
                 //TEXT
                
                if (ReferenceEquals(characterSquence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", characterSquence.Name);
                 //TEXT
                
                if (ReferenceEquals(characterSquence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", characterSquence.Description);
                 //INT32
                
                if (ReferenceEquals(characterSquence.Index, null)) cmd.Parameters.AddWithValue("@Index", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Index", characterSquence.Index);
                 //GUID
                
                if (ReferenceEquals(characterSquence.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", characterSquence.CharacterId);
                 //GUID
                
                if (ReferenceEquals(characterSquence.SignalId, null)) cmd.Parameters.AddWithValue("@SignalId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SignalId", characterSquence.SignalId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified CharacterSquence
        /// </summary>
        /// <returns></returns>
        public int Delete(CharacterSquence characterSquence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[CharacterSquence] 
                                    WHERE CharacterSquenceId = @CharacterSquenceId", this.Schema);
                                    
                
                if (ReferenceEquals(characterSquence.CharacterSquenceId, null)) cmd.Parameters.AddWithValue("@CharacterSquenceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CharacterSquenceId", characterSquence.CharacterSquenceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Signal signal)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Signal] (SignalId, Name, Description, Symbol, ShortCode, LongCode, BinaryCode, SortOrder, RelativeTime)
                                    VALUES (@SignalId, @Name, @Description, @Symbol, @ShortCode, @LongCode, @BinaryCode, @SortOrder, @RelativeTime)", this.Schema);

                
                  
                if (ReferenceEquals(signal.SignalId, null)) cmd.Parameters.AddWithValue("@SignalId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SignalId", signal.SignalId);
                
                  
                if (ReferenceEquals(signal.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", signal.Name);
                
                  
                if (ReferenceEquals(signal.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", signal.Description);
                
                  
                if (ReferenceEquals(signal.Symbol, null)) cmd.Parameters.AddWithValue("@Symbol", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Symbol", signal.Symbol);
                
                  
                if (ReferenceEquals(signal.ShortCode, null)) cmd.Parameters.AddWithValue("@ShortCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ShortCode", signal.ShortCode);
                
                  
                if (ReferenceEquals(signal.LongCode, null)) cmd.Parameters.AddWithValue("@LongCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LongCode", signal.LongCode);
                
                  
                if (ReferenceEquals(signal.BinaryCode, null)) cmd.Parameters.AddWithValue("@BinaryCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@BinaryCode", signal.BinaryCode);
                
                  
                if (ReferenceEquals(signal.SortOrder, null)) cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SortOrder", signal.SortOrder);
                
                  
                if (ReferenceEquals(signal.RelativeTime, null)) cmd.Parameters.AddWithValue("@RelativeTime", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@RelativeTime", signal.RelativeTime);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Signal signal)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = signal.SignalId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Signal WHERE SignalId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(signal);
                else return this.Insert(signal);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllSignals<T>()
            where T : Signal, new()
        {
            return this.GetAllSignals<T>(String.Empty);
        }

        
        public List<T> GetAllSignals<T>(String whereClause)
            where T : Signal, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Signal]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T signal = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("SignalId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          signal.SignalId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          signal.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          signal.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Symbol");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          signal.Symbol = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ShortCode");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          signal.ShortCode = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("LongCode");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          signal.LongCode = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("BinaryCode");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          signal.BinaryCode = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("SortOrder");
                      if (!reader.IsDBNull(propertyIndex)) //INT32
                      {
                          
                          signal.SortOrder = reader.GetInt32(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("RelativeTime");
                      if (!reader.IsDBNull(propertyIndex)) //INT32
                      {
                          
                          signal.RelativeTime = reader.GetInt32(propertyIndex);
                      }
                   
                    results.Add(signal);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Signal
        /// </summary>
        /// <returns></returns>
        public int Update(Signal signal)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Signal] SET 
                                    Name = @Name,Description = @Description,Symbol = @Symbol,ShortCode = @ShortCode,LongCode = @LongCode,BinaryCode = @BinaryCode,SortOrder = @SortOrder,RelativeTime = @RelativeTime
                                    WHERE SignalId = @SignalId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(signal.SignalId, null)) cmd.Parameters.AddWithValue("@SignalId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SignalId", signal.SignalId);
                 //TEXT
                
                if (ReferenceEquals(signal.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", signal.Name);
                 //TEXT
                
                if (ReferenceEquals(signal.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", signal.Description);
                 //TEXT
                
                if (ReferenceEquals(signal.Symbol, null)) cmd.Parameters.AddWithValue("@Symbol", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Symbol", signal.Symbol);
                 //TEXT
                
                if (ReferenceEquals(signal.ShortCode, null)) cmd.Parameters.AddWithValue("@ShortCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ShortCode", signal.ShortCode);
                 //TEXT
                
                if (ReferenceEquals(signal.LongCode, null)) cmd.Parameters.AddWithValue("@LongCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LongCode", signal.LongCode);
                 //TEXT
                
                if (ReferenceEquals(signal.BinaryCode, null)) cmd.Parameters.AddWithValue("@BinaryCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@BinaryCode", signal.BinaryCode);
                 //int32
                
                if (ReferenceEquals(signal.SortOrder, null)) cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SortOrder", signal.SortOrder);
                 //int32
                
                if (ReferenceEquals(signal.RelativeTime, null)) cmd.Parameters.AddWithValue("@RelativeTime", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@RelativeTime", signal.RelativeTime);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Signal
        /// </summary>
        /// <returns></returns>
        public int Delete(Signal signal)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Signal] 
                                    WHERE SignalId = @SignalId", this.Schema);
                                    
                
                if (ReferenceEquals(signal.SignalId, null)) cmd.Parameters.AddWithValue("@SignalId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SignalId", signal.SignalId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Telegraph telegraph)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Telegraph] (TelegraphId, Name, Description, CommunicationId)
                                    VALUES (@TelegraphId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(telegraph.TelegraphId, null)) cmd.Parameters.AddWithValue("@TelegraphId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphId", telegraph.TelegraphId);
                
                  
                if (ReferenceEquals(telegraph.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", telegraph.Name);
                
                  
                if (ReferenceEquals(telegraph.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", telegraph.Description);
                
                  
                if (ReferenceEquals(telegraph.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", telegraph.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Telegraph telegraph)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = telegraph.TelegraphId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Telegraph WHERE TelegraphId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(telegraph);
                else return this.Insert(telegraph);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllTelegraphs<T>()
            where T : Telegraph, new()
        {
            return this.GetAllTelegraphs<T>(String.Empty);
        }

        
        public List<T> GetAllTelegraphs<T>(String whereClause)
            where T : Telegraph, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Telegraph]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T telegraph = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("TelegraphId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          telegraph.TelegraphId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          telegraph.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          telegraph.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          telegraph.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(telegraph);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Telegraph
        /// </summary>
        /// <returns></returns>
        public int Update(Telegraph telegraph)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Telegraph] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE TelegraphId = @TelegraphId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(telegraph.TelegraphId, null)) cmd.Parameters.AddWithValue("@TelegraphId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphId", telegraph.TelegraphId);
                 //TEXT
                
                if (ReferenceEquals(telegraph.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", telegraph.Name);
                 //TEXT
                
                if (ReferenceEquals(telegraph.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", telegraph.Description);
                 //GUID
                
                if (ReferenceEquals(telegraph.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", telegraph.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Telegraph
        /// </summary>
        /// <returns></returns>
        public int Delete(Telegraph telegraph)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Telegraph] 
                                    WHERE TelegraphId = @TelegraphId", this.Schema);
                                    
                
                if (ReferenceEquals(telegraph.TelegraphId, null)) cmd.Parameters.AddWithValue("@TelegraphId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@TelegraphId", telegraph.TelegraphId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Transmission transmission)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Transmission] (TransmissionId, Name, Description, CommuncatinoId)
                                    VALUES (@TransmissionId, @Name, @Description, @CommuncatinoId)", this.Schema);

                
                  
                if (ReferenceEquals(transmission.TransmissionId, null)) cmd.Parameters.AddWithValue("@TransmissionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TransmissionId", transmission.TransmissionId);
                
                  
                if (ReferenceEquals(transmission.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", transmission.Name);
                
                  
                if (ReferenceEquals(transmission.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", transmission.Description);
                
                  
                if (ReferenceEquals(transmission.CommuncatinoId, null)) cmd.Parameters.AddWithValue("@CommuncatinoId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommuncatinoId", transmission.CommuncatinoId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Transmission transmission)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = transmission.TransmissionId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Transmission WHERE TransmissionId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(transmission);
                else return this.Insert(transmission);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllTransmissions<T>()
            where T : Transmission, new()
        {
            return this.GetAllTransmissions<T>(String.Empty);
        }

        
        public List<T> GetAllTransmissions<T>(String whereClause)
            where T : Transmission, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Transmission]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T transmission = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("TransmissionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          transmission.TransmissionId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          transmission.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          transmission.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommuncatinoId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          transmission.CommuncatinoId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(transmission);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Transmission
        /// </summary>
        /// <returns></returns>
        public int Update(Transmission transmission)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Transmission] SET 
                                    Name = @Name,Description = @Description,CommuncatinoId = @CommuncatinoId
                                    WHERE TransmissionId = @TransmissionId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(transmission.TransmissionId, null)) cmd.Parameters.AddWithValue("@TransmissionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TransmissionId", transmission.TransmissionId);
                 //TEXT
                
                if (ReferenceEquals(transmission.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", transmission.Name);
                 //TEXT
                
                if (ReferenceEquals(transmission.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", transmission.Description);
                 //GUID
                
                if (ReferenceEquals(transmission.CommuncatinoId, null)) cmd.Parameters.AddWithValue("@CommuncatinoId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommuncatinoId", transmission.CommuncatinoId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Transmission
        /// </summary>
        /// <returns></returns>
        public int Delete(Transmission transmission)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Transmission] 
                                    WHERE TransmissionId = @TransmissionId", this.Schema);
                                    
                
                if (ReferenceEquals(transmission.TransmissionId, null)) cmd.Parameters.AddWithValue("@TransmissionId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@TransmissionId", transmission.TransmissionId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Understanding understanding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Understanding] (UnderstandingId, Name, Description, CommunicationId)
                                    VALUES (@UnderstandingId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(understanding.UnderstandingId, null)) cmd.Parameters.AddWithValue("@UnderstandingId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@UnderstandingId", understanding.UnderstandingId);
                
                  
                if (ReferenceEquals(understanding.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", understanding.Name);
                
                  
                if (ReferenceEquals(understanding.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", understanding.Description);
                
                  
                if (ReferenceEquals(understanding.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", understanding.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Understanding understanding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = understanding.UnderstandingId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Understanding WHERE UnderstandingId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(understanding);
                else return this.Insert(understanding);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllUnderstandings<T>()
            where T : Understanding, new()
        {
            return this.GetAllUnderstandings<T>(String.Empty);
        }

        
        public List<T> GetAllUnderstandings<T>(String whereClause)
            where T : Understanding, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Understanding]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T understanding = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("UnderstandingId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          understanding.UnderstandingId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          understanding.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          understanding.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          understanding.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(understanding);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Understanding
        /// </summary>
        /// <returns></returns>
        public int Update(Understanding understanding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Understanding] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE UnderstandingId = @UnderstandingId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(understanding.UnderstandingId, null)) cmd.Parameters.AddWithValue("@UnderstandingId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@UnderstandingId", understanding.UnderstandingId);
                 //TEXT
                
                if (ReferenceEquals(understanding.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", understanding.Name);
                 //TEXT
                
                if (ReferenceEquals(understanding.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", understanding.Description);
                 //GUID
                
                if (ReferenceEquals(understanding.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", understanding.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Understanding
        /// </summary>
        /// <returns></returns>
        public int Delete(Understanding understanding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Understanding] 
                                    WHERE UnderstandingId = @UnderstandingId", this.Schema);
                                    
                
                if (ReferenceEquals(understanding.UnderstandingId, null)) cmd.Parameters.AddWithValue("@UnderstandingId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@UnderstandingId", understanding.UnderstandingId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Word word)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Word] (WordId, Name, Description, CommunicationId)
                                    VALUES (@WordId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(word.WordId, null)) cmd.Parameters.AddWithValue("@WordId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@WordId", word.WordId);
                
                  
                if (ReferenceEquals(word.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", word.Name);
                
                  
                if (ReferenceEquals(word.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", word.Description);
                
                  
                if (ReferenceEquals(word.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", word.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Word word)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = word.WordId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Word WHERE WordId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(word);
                else return this.Insert(word);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllWords<T>()
            where T : Word, new()
        {
            return this.GetAllWords<T>(String.Empty);
        }

        
        public List<T> GetAllWords<T>(String whereClause)
            where T : Word, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Word]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T word = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("WordId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          word.WordId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          word.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          word.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          word.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(word);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Word
        /// </summary>
        /// <returns></returns>
        public int Update(Word word)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Word] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE WordId = @WordId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(word.WordId, null)) cmd.Parameters.AddWithValue("@WordId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@WordId", word.WordId);
                 //TEXT
                
                if (ReferenceEquals(word.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", word.Name);
                 //TEXT
                
                if (ReferenceEquals(word.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", word.Description);
                 //GUID
                
                if (ReferenceEquals(word.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", word.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Word
        /// </summary>
        /// <returns></returns>
        public int Delete(Word word)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Word] 
                                    WHERE WordId = @WordId", this.Schema);
                                    
                
                if (ReferenceEquals(word.WordId, null)) cmd.Parameters.AddWithValue("@WordId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@WordId", word.WordId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(TelegraphStation telegraphStation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[TelegraphStation] (TelegraphStationId, Name, Description)
                                    VALUES (@TelegraphStationId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(telegraphStation.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphStationId", telegraphStation.TelegraphStationId);
                
                  
                if (ReferenceEquals(telegraphStation.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", telegraphStation.Name);
                
                  
                if (ReferenceEquals(telegraphStation.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", telegraphStation.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(TelegraphStation telegraphStation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = telegraphStation.TelegraphStationId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM TelegraphStation WHERE TelegraphStationId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(telegraphStation);
                else return this.Insert(telegraphStation);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllTelegraphStations<T>()
            where T : TelegraphStation, new()
        {
            return this.GetAllTelegraphStations<T>(String.Empty);
        }

        
        public List<T> GetAllTelegraphStations<T>(String whereClause)
            where T : TelegraphStation, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[TelegraphStation]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T telegraphStation = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("TelegraphStationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          telegraphStation.TelegraphStationId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          telegraphStation.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          telegraphStation.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(telegraphStation);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified TelegraphStation
        /// </summary>
        /// <returns></returns>
        public int Update(TelegraphStation telegraphStation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[TelegraphStation] SET 
                                    Name = @Name,Description = @Description
                                    WHERE TelegraphStationId = @TelegraphStationId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(telegraphStation.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TelegraphStationId", telegraphStation.TelegraphStationId);
                 //TEXT
                
                if (ReferenceEquals(telegraphStation.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", telegraphStation.Name);
                 //TEXT
                
                if (ReferenceEquals(telegraphStation.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", telegraphStation.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified TelegraphStation
        /// </summary>
        /// <returns></returns>
        public int Delete(TelegraphStation telegraphStation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[TelegraphStation] 
                                    WHERE TelegraphStationId = @TelegraphStationId", this.Schema);
                                    
                
                if (ReferenceEquals(telegraphStation.TelegraphStationId, null)) cmd.Parameters.AddWithValue("@TelegraphStationId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@TelegraphStationId", telegraphStation.TelegraphStationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Sentence sentence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Sentence] (SentenceId, Name, Description, CommunicationId)
                                    VALUES (@SentenceId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(sentence.SentenceId, null)) cmd.Parameters.AddWithValue("@SentenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SentenceId", sentence.SentenceId);
                
                  
                if (ReferenceEquals(sentence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", sentence.Name);
                
                  
                if (ReferenceEquals(sentence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", sentence.Description);
                
                  
                if (ReferenceEquals(sentence.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", sentence.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Sentence sentence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = sentence.SentenceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Sentence WHERE SentenceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(sentence);
                else return this.Insert(sentence);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllSentences<T>()
            where T : Sentence, new()
        {
            return this.GetAllSentences<T>(String.Empty);
        }

        
        public List<T> GetAllSentences<T>(String whereClause)
            where T : Sentence, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Sentence]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T sentence = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("SentenceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          sentence.SentenceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          sentence.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          sentence.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          sentence.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(sentence);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Sentence
        /// </summary>
        /// <returns></returns>
        public int Update(Sentence sentence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Sentence] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE SentenceId = @SentenceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(sentence.SentenceId, null)) cmd.Parameters.AddWithValue("@SentenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SentenceId", sentence.SentenceId);
                 //TEXT
                
                if (ReferenceEquals(sentence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", sentence.Name);
                 //TEXT
                
                if (ReferenceEquals(sentence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", sentence.Description);
                 //GUID
                
                if (ReferenceEquals(sentence.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", sentence.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Sentence
        /// </summary>
        /// <returns></returns>
        public int Delete(Sentence sentence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Sentence] 
                                    WHERE SentenceId = @SentenceId", this.Schema);
                                    
                
                if (ReferenceEquals(sentence.SentenceId, null)) cmd.Parameters.AddWithValue("@SentenceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SentenceId", sentence.SentenceId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Customer customer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Customer] (CustomerId, Name, Description, CommunicationId)
                                    VALUES (@CustomerId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(customer.CustomerId, null)) cmd.Parameters.AddWithValue("@CustomerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                
                  
                if (ReferenceEquals(customer.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", customer.Name);
                
                  
                if (ReferenceEquals(customer.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", customer.Description);
                
                  
                if (ReferenceEquals(customer.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", customer.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Customer customer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = customer.CustomerId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Customer WHERE CustomerId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(customer);
                else return this.Insert(customer);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllCustomers<T>()
            where T : Customer, new()
        {
            return this.GetAllCustomers<T>(String.Empty);
        }

        
        public List<T> GetAllCustomers<T>(String whereClause)
            where T : Customer, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Customer]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T customer = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("CustomerId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          customer.CustomerId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          customer.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          customer.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          customer.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(customer);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Customer
        /// </summary>
        /// <returns></returns>
        public int Update(Customer customer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Customer] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE CustomerId = @CustomerId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(customer.CustomerId, null)) cmd.Parameters.AddWithValue("@CustomerId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                 //TEXT
                
                if (ReferenceEquals(customer.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", customer.Name);
                 //TEXT
                
                if (ReferenceEquals(customer.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", customer.Description);
                 //GUID
                
                if (ReferenceEquals(customer.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", customer.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Customer
        /// </summary>
        /// <returns></returns>
        public int Delete(Customer customer)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Customer] 
                                    WHERE CustomerId = @CustomerId", this.Schema);
                                    
                
                if (ReferenceEquals(customer.CustomerId, null)) cmd.Parameters.AddWithValue("@CustomerId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

                  
            
            

        public object LastIdentity { get; set; }
        public string ExecuteAsUser { get; set; }
        
        private SqlConnection CreateSqlConnection() 
        {
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = this.DataSourceName;
                scsb.InitialCatalog = this.DBName;
                scsb.IntegratedSecurity = true;
                this.ConnectionString = scsb.ConnectionString;
            }
            
            SqlDataManager.LastConnectionString = this.ConnectionString;
            
            return new SqlConnection(this.ConnectionString);
        }
        
        
        private void InitializeConnection(SqlConnection conn)
        {
            conn.Open();
            if (!String.IsNullOrEmpty(this.ExecuteAsUser))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("EXECUTE AS USER='{0}'", this.ExecuteAsUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

      