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
  
  
  
        public int Insert(MorseCode morseCode)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[MorseCode] (MorseCodeId, Name, Description)
                                    VALUES (@MorseCodeId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(morseCode.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", morseCode.MorseCodeId);
                
                  
                if (ReferenceEquals(morseCode.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", morseCode.Name);
                
                  
                if (ReferenceEquals(morseCode.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", morseCode.Description);
                

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
        public int Upsert(MorseCode morseCode)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = morseCode.MorseCodeId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM MorseCode WHERE MorseCodeId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(morseCode);
                else return this.Insert(morseCode);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllMorseCodes<T>()
            where T : MorseCode, new()
        {
            return this.GetAllMorseCodes<T>(String.Empty);
        }

        
        public List<T> GetAllMorseCodes<T>(String whereClause)
            where T : MorseCode, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[MorseCode]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T morseCode = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("MorseCodeId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          morseCode.MorseCodeId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          morseCode.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          morseCode.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(morseCode);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified MorseCode
        /// </summary>
        /// <returns></returns>
        public int Update(MorseCode morseCode)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[MorseCode] SET 
                                    Name = @Name,Description = @Description
                                    WHERE MorseCodeId = @MorseCodeId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(morseCode.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", morseCode.MorseCodeId);
                 //TEXT
                
                if (ReferenceEquals(morseCode.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", morseCode.Name);
                 //TEXT
                
                if (ReferenceEquals(morseCode.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", morseCode.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified MorseCode
        /// </summary>
        /// <returns></returns>
        public int Delete(MorseCode morseCode)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[MorseCode] 
                                    WHERE MorseCodeId = @MorseCodeId", this.Schema);
                                    
                
                if (ReferenceEquals(morseCode.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@MorseCodeId", morseCode.MorseCodeId);
                

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
  
  
  
        public int Insert(DeliveryMethod deliveryMethod)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[DeliveryMethod] (DeliveryMethodId, Name, Description, MorseCodeId)
                                    VALUES (@DeliveryMethodId, @Name, @Description, @MorseCodeId)", this.Schema);

                
                  
                if (ReferenceEquals(deliveryMethod.DeliveryMethodId, null)) cmd.Parameters.AddWithValue("@DeliveryMethodId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DeliveryMethodId", deliveryMethod.DeliveryMethodId);
                
                  
                if (ReferenceEquals(deliveryMethod.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", deliveryMethod.Name);
                
                  
                if (ReferenceEquals(deliveryMethod.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", deliveryMethod.Description);
                
                  
                if (ReferenceEquals(deliveryMethod.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", deliveryMethod.MorseCodeId);
                

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
        public int Upsert(DeliveryMethod deliveryMethod)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = deliveryMethod.DeliveryMethodId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM DeliveryMethod WHERE DeliveryMethodId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(deliveryMethod);
                else return this.Insert(deliveryMethod);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDeliveryMethods<T>()
            where T : DeliveryMethod, new()
        {
            return this.GetAllDeliveryMethods<T>(String.Empty);
        }

        
        public List<T> GetAllDeliveryMethods<T>(String whereClause)
            where T : DeliveryMethod, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[DeliveryMethod]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T deliveryMethod = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DeliveryMethodId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          deliveryMethod.DeliveryMethodId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          deliveryMethod.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          deliveryMethod.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("MorseCodeId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          deliveryMethod.MorseCodeId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(deliveryMethod);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified DeliveryMethod
        /// </summary>
        /// <returns></returns>
        public int Update(DeliveryMethod deliveryMethod)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[DeliveryMethod] SET 
                                    Name = @Name,Description = @Description,MorseCodeId = @MorseCodeId
                                    WHERE DeliveryMethodId = @DeliveryMethodId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(deliveryMethod.DeliveryMethodId, null)) cmd.Parameters.AddWithValue("@DeliveryMethodId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DeliveryMethodId", deliveryMethod.DeliveryMethodId);
                 //TEXT
                
                if (ReferenceEquals(deliveryMethod.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", deliveryMethod.Name);
                 //TEXT
                
                if (ReferenceEquals(deliveryMethod.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", deliveryMethod.Description);
                 //GUID
                
                if (ReferenceEquals(deliveryMethod.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", deliveryMethod.MorseCodeId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified DeliveryMethod
        /// </summary>
        /// <returns></returns>
        public int Delete(DeliveryMethod deliveryMethod)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[DeliveryMethod] 
                                    WHERE DeliveryMethodId = @DeliveryMethodId", this.Schema);
                                    
                
                if (ReferenceEquals(deliveryMethod.DeliveryMethodId, null)) cmd.Parameters.AddWithValue("@DeliveryMethodId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DeliveryMethodId", deliveryMethod.DeliveryMethodId);
                

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
  
  
  
        public int Insert(MCDevice mCDevice)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[MCDevice] (MCDeviceId, Name, Description)
                                    VALUES (@MCDeviceId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(mCDevice.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", mCDevice.MCDeviceId);
                
                  
                if (ReferenceEquals(mCDevice.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", mCDevice.Name);
                
                  
                if (ReferenceEquals(mCDevice.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", mCDevice.Description);
                

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
                                    Name = @Name,Description = @Description
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
  
  
  
        public int Insert(Alphabet alphabet)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Alphabet] (AlphabetId, Name, Description, MorseCodeId)
                                    VALUES (@AlphabetId, @Name, @Description, @MorseCodeId)", this.Schema);

                
                  
                if (ReferenceEquals(alphabet.AlphabetId, null)) cmd.Parameters.AddWithValue("@AlphabetId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlphabetId", alphabet.AlphabetId);
                
                  
                if (ReferenceEquals(alphabet.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", alphabet.Name);
                
                  
                if (ReferenceEquals(alphabet.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", alphabet.Description);
                
                  
                if (ReferenceEquals(alphabet.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", alphabet.MorseCodeId);
                

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
                   
                      propertyIndex = reader.GetOrdinal("MorseCodeId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          alphabet.MorseCodeId = reader.GetGuid(propertyIndex);
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
                                    Name = @Name,Description = @Description,MorseCodeId = @MorseCodeId
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
                
                if (ReferenceEquals(alphabet.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", alphabet.MorseCodeId);
                

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
  
  
  
        public int Insert(Punctuation punctuation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Punctuation] (PunctuationId, Name, Description, CharacterId)
                                    VALUES (@PunctuationId, @Name, @Description, @CharacterId)", this.Schema);

                
                  
                if (ReferenceEquals(punctuation.PunctuationId, null)) cmd.Parameters.AddWithValue("@PunctuationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PunctuationId", punctuation.PunctuationId);
                
                  
                if (ReferenceEquals(punctuation.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", punctuation.Name);
                
                  
                if (ReferenceEquals(punctuation.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", punctuation.Description);
                
                  
                if (ReferenceEquals(punctuation.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", punctuation.CharacterId);
                

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
        public int Upsert(Punctuation punctuation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = punctuation.PunctuationId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Punctuation WHERE PunctuationId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(punctuation);
                else return this.Insert(punctuation);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllPunctuations<T>()
            where T : Punctuation, new()
        {
            return this.GetAllPunctuations<T>(String.Empty);
        }

        
        public List<T> GetAllPunctuations<T>(String whereClause)
            where T : Punctuation, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Punctuation]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T punctuation = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("PunctuationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          punctuation.PunctuationId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          punctuation.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          punctuation.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          punctuation.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(punctuation);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Punctuation
        /// </summary>
        /// <returns></returns>
        public int Update(Punctuation punctuation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Punctuation] SET 
                                    Name = @Name,Description = @Description,CharacterId = @CharacterId
                                    WHERE PunctuationId = @PunctuationId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(punctuation.PunctuationId, null)) cmd.Parameters.AddWithValue("@PunctuationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PunctuationId", punctuation.PunctuationId);
                 //TEXT
                
                if (ReferenceEquals(punctuation.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", punctuation.Name);
                 //TEXT
                
                if (ReferenceEquals(punctuation.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", punctuation.Description);
                 //GUID
                
                if (ReferenceEquals(punctuation.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", punctuation.CharacterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Punctuation
        /// </summary>
        /// <returns></returns>
        public int Delete(Punctuation punctuation)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Punctuation] 
                                    WHERE PunctuationId = @PunctuationId", this.Schema);
                                    
                
                if (ReferenceEquals(punctuation.PunctuationId, null)) cmd.Parameters.AddWithValue("@PunctuationId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@PunctuationId", punctuation.PunctuationId);
                

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
  
  
  
        public int Insert(Symbol symbol)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Symbol] (SymbolId, Name, Description, CharacterId)
                                    VALUES (@SymbolId, @Name, @Description, @CharacterId)", this.Schema);

                
                  
                if (ReferenceEquals(symbol.SymbolId, null)) cmd.Parameters.AddWithValue("@SymbolId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SymbolId", symbol.SymbolId);
                
                  
                if (ReferenceEquals(symbol.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", symbol.Name);
                
                  
                if (ReferenceEquals(symbol.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", symbol.Description);
                
                  
                if (ReferenceEquals(symbol.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", symbol.CharacterId);
                

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
        public int Upsert(Symbol symbol)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = symbol.SymbolId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Symbol WHERE SymbolId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(symbol);
                else return this.Insert(symbol);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllSymbols<T>()
            where T : Symbol, new()
        {
            return this.GetAllSymbols<T>(String.Empty);
        }

        
        public List<T> GetAllSymbols<T>(String whereClause)
            where T : Symbol, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Symbol]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T symbol = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("SymbolId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          symbol.SymbolId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          symbol.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          symbol.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          symbol.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(symbol);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Symbol
        /// </summary>
        /// <returns></returns>
        public int Update(Symbol symbol)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Symbol] SET 
                                    Name = @Name,Description = @Description,CharacterId = @CharacterId
                                    WHERE SymbolId = @SymbolId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(symbol.SymbolId, null)) cmd.Parameters.AddWithValue("@SymbolId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SymbolId", symbol.SymbolId);
                 //TEXT
                
                if (ReferenceEquals(symbol.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", symbol.Name);
                 //TEXT
                
                if (ReferenceEquals(symbol.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", symbol.Description);
                 //GUID
                
                if (ReferenceEquals(symbol.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", symbol.CharacterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Symbol
        /// </summary>
        /// <returns></returns>
        public int Delete(Symbol symbol)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Symbol] 
                                    WHERE SymbolId = @SymbolId", this.Schema);
                                    
                
                if (ReferenceEquals(symbol.SymbolId, null)) cmd.Parameters.AddWithValue("@SymbolId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SymbolId", symbol.SymbolId);
                

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
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Character] (CharacterId, Name, Description, AlphabetId)
                                    VALUES (@CharacterId, @Name, @Description, @AlphabetId)", this.Schema);

                
                  
                if (ReferenceEquals(character.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", character.CharacterId);
                
                  
                if (ReferenceEquals(character.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", character.Name);
                
                  
                if (ReferenceEquals(character.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", character.Description);
                
                  
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
                                    Name = @Name,Description = @Description,AlphabetId = @AlphabetId
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
  
  
  
        public int Insert(Numeral numeral)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Numeral] (NumeralId, Name, Description, CharacterId)
                                    VALUES (@NumeralId, @Name, @Description, @CharacterId)", this.Schema);

                
                  
                if (ReferenceEquals(numeral.NumeralId, null)) cmd.Parameters.AddWithValue("@NumeralId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@NumeralId", numeral.NumeralId);
                
                  
                if (ReferenceEquals(numeral.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", numeral.Name);
                
                  
                if (ReferenceEquals(numeral.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", numeral.Description);
                
                  
                if (ReferenceEquals(numeral.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", numeral.CharacterId);
                

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
        public int Upsert(Numeral numeral)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = numeral.NumeralId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Numeral WHERE NumeralId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(numeral);
                else return this.Insert(numeral);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllNumerals<T>()
            where T : Numeral, new()
        {
            return this.GetAllNumerals<T>(String.Empty);
        }

        
        public List<T> GetAllNumerals<T>(String whereClause)
            where T : Numeral, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Numeral]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T numeral = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("NumeralId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          numeral.NumeralId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          numeral.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          numeral.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          numeral.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(numeral);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Numeral
        /// </summary>
        /// <returns></returns>
        public int Update(Numeral numeral)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Numeral] SET 
                                    Name = @Name,Description = @Description,CharacterId = @CharacterId
                                    WHERE NumeralId = @NumeralId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(numeral.NumeralId, null)) cmd.Parameters.AddWithValue("@NumeralId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@NumeralId", numeral.NumeralId);
                 //TEXT
                
                if (ReferenceEquals(numeral.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", numeral.Name);
                 //TEXT
                
                if (ReferenceEquals(numeral.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", numeral.Description);
                 //GUID
                
                if (ReferenceEquals(numeral.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", numeral.CharacterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Numeral
        /// </summary>
        /// <returns></returns>
        public int Delete(Numeral numeral)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Numeral] 
                                    WHERE NumeralId = @NumeralId", this.Schema);
                                    
                
                if (ReferenceEquals(numeral.NumeralId, null)) cmd.Parameters.AddWithValue("@NumeralId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@NumeralId", numeral.NumeralId);
                

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
  
  
  
        public int Insert(Sequence sequence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Sequence] (SequenceId, Name, Description, CommunicationId)
                                    VALUES (@SequenceId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(sequence.SequenceId, null)) cmd.Parameters.AddWithValue("@SequenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SequenceId", sequence.SequenceId);
                
                  
                if (ReferenceEquals(sequence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", sequence.Name);
                
                  
                if (ReferenceEquals(sequence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", sequence.Description);
                
                  
                if (ReferenceEquals(sequence.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", sequence.CommunicationId);
                

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
        public int Upsert(Sequence sequence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = sequence.SequenceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Sequence WHERE SequenceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(sequence);
                else return this.Insert(sequence);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllSequences<T>()
            where T : Sequence, new()
        {
            return this.GetAllSequences<T>(String.Empty);
        }

        
        public List<T> GetAllSequences<T>(String whereClause)
            where T : Sequence, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Sequence]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T sequence = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("SequenceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          sequence.SequenceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          sequence.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          sequence.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          sequence.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(sequence);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Sequence
        /// </summary>
        /// <returns></returns>
        public int Update(Sequence sequence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Sequence] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE SequenceId = @SequenceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(sequence.SequenceId, null)) cmd.Parameters.AddWithValue("@SequenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SequenceId", sequence.SequenceId);
                 //TEXT
                
                if (ReferenceEquals(sequence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", sequence.Name);
                 //TEXT
                
                if (ReferenceEquals(sequence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", sequence.Description);
                 //GUID
                
                if (ReferenceEquals(sequence.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", sequence.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Sequence
        /// </summary>
        /// <returns></returns>
        public int Delete(Sequence sequence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Sequence] 
                                    WHERE SequenceId = @SequenceId", this.Schema);
                                    
                
                if (ReferenceEquals(sequence.SequenceId, null)) cmd.Parameters.AddWithValue("@SequenceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SequenceId", sequence.SequenceId);
                

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
  
  
  
        public int Insert(Dot dot)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Dot] (DotId, Name, Description)
                                    VALUES (@DotId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(dot.DotId, null)) cmd.Parameters.AddWithValue("@DotId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DotId", dot.DotId);
                
                  
                if (ReferenceEquals(dot.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", dot.Name);
                
                  
                if (ReferenceEquals(dot.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", dot.Description);
                

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
        public int Upsert(Dot dot)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = dot.DotId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Dot WHERE DotId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(dot);
                else return this.Insert(dot);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDots<T>()
            where T : Dot, new()
        {
            return this.GetAllDots<T>(String.Empty);
        }

        
        public List<T> GetAllDots<T>(String whereClause)
            where T : Dot, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Dot]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T dot = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DotId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          dot.DotId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          dot.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          dot.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(dot);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Dot
        /// </summary>
        /// <returns></returns>
        public int Update(Dot dot)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Dot] SET 
                                    Name = @Name,Description = @Description
                                    WHERE DotId = @DotId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(dot.DotId, null)) cmd.Parameters.AddWithValue("@DotId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DotId", dot.DotId);
                 //TEXT
                
                if (ReferenceEquals(dot.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", dot.Name);
                 //TEXT
                
                if (ReferenceEquals(dot.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", dot.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Dot
        /// </summary>
        /// <returns></returns>
        public int Delete(Dot dot)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Dot] 
                                    WHERE DotId = @DotId", this.Schema);
                                    
                
                if (ReferenceEquals(dot.DotId, null)) cmd.Parameters.AddWithValue("@DotId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DotId", dot.DotId);
                

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
  
  
  
        public int Insert(Duration duration)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Duration] (DurationId, Name, Description)
                                    VALUES (@DurationId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(duration.DurationId, null)) cmd.Parameters.AddWithValue("@DurationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DurationId", duration.DurationId);
                
                  
                if (ReferenceEquals(duration.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", duration.Name);
                
                  
                if (ReferenceEquals(duration.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", duration.Description);
                

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
        public int Upsert(Duration duration)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = duration.DurationId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Duration WHERE DurationId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(duration);
                else return this.Insert(duration);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDurations<T>()
            where T : Duration, new()
        {
            return this.GetAllDurations<T>(String.Empty);
        }

        
        public List<T> GetAllDurations<T>(String whereClause)
            where T : Duration, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Duration]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T duration = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DurationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          duration.DurationId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          duration.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          duration.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(duration);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Duration
        /// </summary>
        /// <returns></returns>
        public int Update(Duration duration)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Duration] SET 
                                    Name = @Name,Description = @Description
                                    WHERE DurationId = @DurationId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(duration.DurationId, null)) cmd.Parameters.AddWithValue("@DurationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DurationId", duration.DurationId);
                 //TEXT
                
                if (ReferenceEquals(duration.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", duration.Name);
                 //TEXT
                
                if (ReferenceEquals(duration.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", duration.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Duration
        /// </summary>
        /// <returns></returns>
        public int Delete(Duration duration)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Duration] 
                                    WHERE DurationId = @DurationId", this.Schema);
                                    
                
                if (ReferenceEquals(duration.DurationId, null)) cmd.Parameters.AddWithValue("@DurationId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DurationId", duration.DurationId);
                

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
  
  
  
        public int Insert(Unit unit)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Unit] (UnitId, Name, Description, MorseCodeId)
                                    VALUES (@UnitId, @Name, @Description, @MorseCodeId)", this.Schema);

                
                  
                if (ReferenceEquals(unit.UnitId, null)) cmd.Parameters.AddWithValue("@UnitId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@UnitId", unit.UnitId);
                
                  
                if (ReferenceEquals(unit.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", unit.Name);
                
                  
                if (ReferenceEquals(unit.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", unit.Description);
                
                  
                if (ReferenceEquals(unit.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", unit.MorseCodeId);
                

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
        public int Upsert(Unit unit)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = unit.UnitId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Unit WHERE UnitId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(unit);
                else return this.Insert(unit);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllUnits<T>()
            where T : Unit, new()
        {
            return this.GetAllUnits<T>(String.Empty);
        }

        
        public List<T> GetAllUnits<T>(String whereClause)
            where T : Unit, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Unit]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T unit = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("UnitId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          unit.UnitId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          unit.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          unit.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("MorseCodeId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          unit.MorseCodeId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(unit);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Unit
        /// </summary>
        /// <returns></returns>
        public int Update(Unit unit)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Unit] SET 
                                    Name = @Name,Description = @Description,MorseCodeId = @MorseCodeId
                                    WHERE UnitId = @UnitId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(unit.UnitId, null)) cmd.Parameters.AddWithValue("@UnitId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@UnitId", unit.UnitId);
                 //TEXT
                
                if (ReferenceEquals(unit.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", unit.Name);
                 //TEXT
                
                if (ReferenceEquals(unit.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", unit.Description);
                 //GUID
                
                if (ReferenceEquals(unit.MorseCodeId, null)) cmd.Parameters.AddWithValue("@MorseCodeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MorseCodeId", unit.MorseCodeId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Unit
        /// </summary>
        /// <returns></returns>
        public int Delete(Unit unit)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Unit] 
                                    WHERE UnitId = @UnitId", this.Schema);
                                    
                
                if (ReferenceEquals(unit.UnitId, null)) cmd.Parameters.AddWithValue("@UnitId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@UnitId", unit.UnitId);
                

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
  
  
  
        public int Insert(Dash dash)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Dash] (DashId, Name, Description)
                                    VALUES (@DashId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(dash.DashId, null)) cmd.Parameters.AddWithValue("@DashId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DashId", dash.DashId);
                
                  
                if (ReferenceEquals(dash.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", dash.Name);
                
                  
                if (ReferenceEquals(dash.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", dash.Description);
                

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
        public int Upsert(Dash dash)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = dash.DashId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Dash WHERE DashId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(dash);
                else return this.Insert(dash);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDashs<T>()
            where T : Dash, new()
        {
            return this.GetAllDashs<T>(String.Empty);
        }

        
        public List<T> GetAllDashs<T>(String whereClause)
            where T : Dash, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Dash]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T dash = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DashId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          dash.DashId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          dash.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          dash.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(dash);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Dash
        /// </summary>
        /// <returns></returns>
        public int Update(Dash dash)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Dash] SET 
                                    Name = @Name,Description = @Description
                                    WHERE DashId = @DashId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(dash.DashId, null)) cmd.Parameters.AddWithValue("@DashId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DashId", dash.DashId);
                 //TEXT
                
                if (ReferenceEquals(dash.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", dash.Name);
                 //TEXT
                
                if (ReferenceEquals(dash.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", dash.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Dash
        /// </summary>
        /// <returns></returns>
        public int Delete(Dash dash)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Dash] 
                                    WHERE DashId = @DashId", this.Schema);
                                    
                
                if (ReferenceEquals(dash.DashId, null)) cmd.Parameters.AddWithValue("@DashId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DashId", dash.DashId);
                

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
  
  
  
        public int Insert(Silence silence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Silence] (SilenceId, Name, Description, CharacterId)
                                    VALUES (@SilenceId, @Name, @Description, @CharacterId)", this.Schema);

                
                  
                if (ReferenceEquals(silence.SilenceId, null)) cmd.Parameters.AddWithValue("@SilenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SilenceId", silence.SilenceId);
                
                  
                if (ReferenceEquals(silence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", silence.Name);
                
                  
                if (ReferenceEquals(silence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", silence.Description);
                
                  
                if (ReferenceEquals(silence.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", silence.CharacterId);
                

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
        public int Upsert(Silence silence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = silence.SilenceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Silence WHERE SilenceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(silence);
                else return this.Insert(silence);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllSilences<T>()
            where T : Silence, new()
        {
            return this.GetAllSilences<T>(String.Empty);
        }

        
        public List<T> GetAllSilences<T>(String whereClause)
            where T : Silence, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Silence]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T silence = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("SilenceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          silence.SilenceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          silence.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          silence.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          silence.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(silence);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Silence
        /// </summary>
        /// <returns></returns>
        public int Update(Silence silence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Silence] SET 
                                    Name = @Name,Description = @Description,CharacterId = @CharacterId
                                    WHERE SilenceId = @SilenceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(silence.SilenceId, null)) cmd.Parameters.AddWithValue("@SilenceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SilenceId", silence.SilenceId);
                 //TEXT
                
                if (ReferenceEquals(silence.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", silence.Name);
                 //TEXT
                
                if (ReferenceEquals(silence.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", silence.Description);
                 //GUID
                
                if (ReferenceEquals(silence.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", silence.CharacterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Silence
        /// </summary>
        /// <returns></returns>
        public int Delete(Silence silence)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Silence] 
                                    WHERE SilenceId = @SilenceId", this.Schema);
                                    
                
                if (ReferenceEquals(silence.SilenceId, null)) cmd.Parameters.AddWithValue("@SilenceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SilenceId", silence.SilenceId);
                

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
  
  
  
        public int Insert(Space space)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Space] (SpaceId, Name, Description, CharacterId)
                                    VALUES (@SpaceId, @Name, @Description, @CharacterId)", this.Schema);

                
                  
                if (ReferenceEquals(space.SpaceId, null)) cmd.Parameters.AddWithValue("@SpaceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SpaceId", space.SpaceId);
                
                  
                if (ReferenceEquals(space.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", space.Name);
                
                  
                if (ReferenceEquals(space.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", space.Description);
                
                  
                if (ReferenceEquals(space.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", space.CharacterId);
                

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
        public int Upsert(Space space)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = space.SpaceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Space WHERE SpaceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(space);
                else return this.Insert(space);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllSpaces<T>()
            where T : Space, new()
        {
            return this.GetAllSpaces<T>(String.Empty);
        }

        
        public List<T> GetAllSpaces<T>(String whereClause)
            where T : Space, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Space]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T space = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("SpaceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          space.SpaceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          space.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          space.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CharacterId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          space.CharacterId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(space);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Space
        /// </summary>
        /// <returns></returns>
        public int Update(Space space)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Space] SET 
                                    Name = @Name,Description = @Description,CharacterId = @CharacterId
                                    WHERE SpaceId = @SpaceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(space.SpaceId, null)) cmd.Parameters.AddWithValue("@SpaceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SpaceId", space.SpaceId);
                 //TEXT
                
                if (ReferenceEquals(space.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", space.Name);
                 //TEXT
                
                if (ReferenceEquals(space.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", space.Description);
                 //GUID
                
                if (ReferenceEquals(space.CharacterId, null)) cmd.Parameters.AddWithValue("@CharacterId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CharacterId", space.CharacterId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Space
        /// </summary>
        /// <returns></returns>
        public int Delete(Space space)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Space] 
                                    WHERE SpaceId = @SpaceId", this.Schema);
                                    
                
                if (ReferenceEquals(space.SpaceId, null)) cmd.Parameters.AddWithValue("@SpaceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SpaceId", space.SpaceId);
                

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
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Communication] (CommunicationId, Name, Description)
                                    VALUES (@CommunicationId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(communication.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", communication.CommunicationId);
                
                  
                if (ReferenceEquals(communication.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", communication.Name);
                
                  
                if (ReferenceEquals(communication.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", communication.Description);
                

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
                                    Name = @Name,Description = @Description
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
  
  
  
        public int Insert(Frequency frequency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Frequency] (FrequencyId, Name, Description)
                                    VALUES (@FrequencyId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(frequency.FrequencyId, null)) cmd.Parameters.AddWithValue("@FrequencyId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@FrequencyId", frequency.FrequencyId);
                
                  
                if (ReferenceEquals(frequency.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", frequency.Name);
                
                  
                if (ReferenceEquals(frequency.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", frequency.Description);
                

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
        public int Upsert(Frequency frequency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = frequency.FrequencyId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Frequency WHERE FrequencyId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(frequency);
                else return this.Insert(frequency);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllFrequencies<T>()
            where T : Frequency, new()
        {
            return this.GetAllFrequencies<T>(String.Empty);
        }

        
        public List<T> GetAllFrequencies<T>(String whereClause)
            where T : Frequency, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Frequency]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T frequency = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("FrequencyId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          frequency.FrequencyId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          frequency.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          frequency.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(frequency);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Frequency
        /// </summary>
        /// <returns></returns>
        public int Update(Frequency frequency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Frequency] SET 
                                    Name = @Name,Description = @Description
                                    WHERE FrequencyId = @FrequencyId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(frequency.FrequencyId, null)) cmd.Parameters.AddWithValue("@FrequencyId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@FrequencyId", frequency.FrequencyId);
                 //TEXT
                
                if (ReferenceEquals(frequency.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", frequency.Name);
                 //TEXT
                
                if (ReferenceEquals(frequency.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", frequency.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Frequency
        /// </summary>
        /// <returns></returns>
        public int Delete(Frequency frequency)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Frequency] 
                                    WHERE FrequencyId = @FrequencyId", this.Schema);
                                    
                
                if (ReferenceEquals(frequency.FrequencyId, null)) cmd.Parameters.AddWithValue("@FrequencyId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@FrequencyId", frequency.FrequencyId);
                

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
  
  
  
        public int Insert(Signal signal)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Signal] (SignalId, Name, Description, MCDeviceId)
                                    VALUES (@SignalId, @Name, @Description, @MCDeviceId)", this.Schema);

                
                  
                if (ReferenceEquals(signal.SignalId, null)) cmd.Parameters.AddWithValue("@SignalId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SignalId", signal.SignalId);
                
                  
                if (ReferenceEquals(signal.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", signal.Name);
                
                  
                if (ReferenceEquals(signal.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", signal.Description);
                
                  
                if (ReferenceEquals(signal.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", signal.MCDeviceId);
                

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
                   
                      propertyIndex = reader.GetOrdinal("MCDeviceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          signal.MCDeviceId = reader.GetGuid(propertyIndex);
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
                                    Name = @Name,Description = @Description,MCDeviceId = @MCDeviceId
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
                 //GUID
                
                if (ReferenceEquals(signal.MCDeviceId, null)) cmd.Parameters.AddWithValue("@MCDeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@MCDeviceId", signal.MCDeviceId);
                

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
  
  
  
        public int Insert(Decoding decoding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Decoding] (DecodingId, Name, Description)
                                    VALUES (@DecodingId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(decoding.DecodingId, null)) cmd.Parameters.AddWithValue("@DecodingId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DecodingId", decoding.DecodingId);
                
                  
                if (ReferenceEquals(decoding.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", decoding.Name);
                
                  
                if (ReferenceEquals(decoding.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", decoding.Description);
                

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
        public int Upsert(Decoding decoding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = decoding.DecodingId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Decoding WHERE DecodingId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(decoding);
                else return this.Insert(decoding);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDecodings<T>()
            where T : Decoding, new()
        {
            return this.GetAllDecodings<T>(String.Empty);
        }

        
        public List<T> GetAllDecodings<T>(String whereClause)
            where T : Decoding, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Decoding]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T decoding = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DecodingId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          decoding.DecodingId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          decoding.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          decoding.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(decoding);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Decoding
        /// </summary>
        /// <returns></returns>
        public int Update(Decoding decoding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Decoding] SET 
                                    Name = @Name,Description = @Description
                                    WHERE DecodingId = @DecodingId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(decoding.DecodingId, null)) cmd.Parameters.AddWithValue("@DecodingId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DecodingId", decoding.DecodingId);
                 //TEXT
                
                if (ReferenceEquals(decoding.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", decoding.Name);
                 //TEXT
                
                if (ReferenceEquals(decoding.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", decoding.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Decoding
        /// </summary>
        /// <returns></returns>
        public int Delete(Decoding decoding)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Decoding] 
                                    WHERE DecodingId = @DecodingId", this.Schema);
                                    
                
                if (ReferenceEquals(decoding.DecodingId, null)) cmd.Parameters.AddWithValue("@DecodingId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DecodingId", decoding.DecodingId);
                

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
  
  
  
        public int Insert(Device device)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Device] (DeviceId, Name, Description)
                                    VALUES (@DeviceId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(device.DeviceId, null)) cmd.Parameters.AddWithValue("@DeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DeviceId", device.DeviceId);
                
                  
                if (ReferenceEquals(device.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", device.Name);
                
                  
                if (ReferenceEquals(device.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", device.Description);
                

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
        public int Upsert(Device device)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = device.DeviceId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Device WHERE DeviceId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(device);
                else return this.Insert(device);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDevices<T>()
            where T : Device, new()
        {
            return this.GetAllDevices<T>(String.Empty);
        }

        
        public List<T> GetAllDevices<T>(String whereClause)
            where T : Device, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Device]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T device = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DeviceId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          device.DeviceId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          device.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          device.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(device);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Device
        /// </summary>
        /// <returns></returns>
        public int Update(Device device)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Device] SET 
                                    Name = @Name,Description = @Description
                                    WHERE DeviceId = @DeviceId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(device.DeviceId, null)) cmd.Parameters.AddWithValue("@DeviceId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DeviceId", device.DeviceId);
                 //TEXT
                
                if (ReferenceEquals(device.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", device.Name);
                 //TEXT
                
                if (ReferenceEquals(device.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", device.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Device
        /// </summary>
        /// <returns></returns>
        public int Delete(Device device)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Device] 
                                    WHERE DeviceId = @DeviceId", this.Schema);
                                    
                
                if (ReferenceEquals(device.DeviceId, null)) cmd.Parameters.AddWithValue("@DeviceId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DeviceId", device.DeviceId);
                

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
  
  
  
        public int Insert(Alternative alternative)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Alternative] (AlternativeId, Name, Description)
                                    VALUES (@AlternativeId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(alternative.AlternativeId, null)) cmd.Parameters.AddWithValue("@AlternativeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlternativeId", alternative.AlternativeId);
                
                  
                if (ReferenceEquals(alternative.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", alternative.Name);
                
                  
                if (ReferenceEquals(alternative.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", alternative.Description);
                

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
        public int Upsert(Alternative alternative)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = alternative.AlternativeId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Alternative WHERE AlternativeId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(alternative);
                else return this.Insert(alternative);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAlternatives<T>()
            where T : Alternative, new()
        {
            return this.GetAllAlternatives<T>(String.Empty);
        }

        
        public List<T> GetAllAlternatives<T>(String whereClause)
            where T : Alternative, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Alternative]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T alternative = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AlternativeId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          alternative.AlternativeId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          alternative.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          alternative.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(alternative);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Alternative
        /// </summary>
        /// <returns></returns>
        public int Update(Alternative alternative)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Alternative] SET 
                                    Name = @Name,Description = @Description
                                    WHERE AlternativeId = @AlternativeId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(alternative.AlternativeId, null)) cmd.Parameters.AddWithValue("@AlternativeId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AlternativeId", alternative.AlternativeId);
                 //TEXT
                
                if (ReferenceEquals(alternative.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", alternative.Name);
                 //TEXT
                
                if (ReferenceEquals(alternative.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", alternative.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Alternative
        /// </summary>
        /// <returns></returns>
        public int Delete(Alternative alternative)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Alternative] 
                                    WHERE AlternativeId = @AlternativeId", this.Schema);
                                    
                
                if (ReferenceEquals(alternative.AlternativeId, null)) cmd.Parameters.AddWithValue("@AlternativeId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AlternativeId", alternative.AlternativeId);
                

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
  
  
  
        public int Insert(Tone tone)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Tone] (ToneId, Name, Description, CommunicationId)
                                    VALUES (@ToneId, @Name, @Description, @CommunicationId)", this.Schema);

                
                  
                if (ReferenceEquals(tone.ToneId, null)) cmd.Parameters.AddWithValue("@ToneId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ToneId", tone.ToneId);
                
                  
                if (ReferenceEquals(tone.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", tone.Name);
                
                  
                if (ReferenceEquals(tone.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", tone.Description);
                
                  
                if (ReferenceEquals(tone.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", tone.CommunicationId);
                

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
        public int Upsert(Tone tone)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = tone.ToneId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Tone WHERE ToneId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(tone);
                else return this.Insert(tone);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllTones<T>()
            where T : Tone, new()
        {
            return this.GetAllTones<T>(String.Empty);
        }

        
        public List<T> GetAllTones<T>(String whereClause)
            where T : Tone, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Tone]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T tone = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ToneId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          tone.ToneId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          tone.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          tone.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CommunicationId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          tone.CommunicationId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(tone);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Tone
        /// </summary>
        /// <returns></returns>
        public int Update(Tone tone)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Tone] SET 
                                    Name = @Name,Description = @Description,CommunicationId = @CommunicationId
                                    WHERE ToneId = @ToneId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(tone.ToneId, null)) cmd.Parameters.AddWithValue("@ToneId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ToneId", tone.ToneId);
                 //TEXT
                
                if (ReferenceEquals(tone.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", tone.Name);
                 //TEXT
                
                if (ReferenceEquals(tone.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", tone.Description);
                 //GUID
                
                if (ReferenceEquals(tone.CommunicationId, null)) cmd.Parameters.AddWithValue("@CommunicationId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CommunicationId", tone.CommunicationId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Tone
        /// </summary>
        /// <returns></returns>
        public int Delete(Tone tone)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Tone] 
                                    WHERE ToneId = @ToneId", this.Schema);
                                    
                
                if (ReferenceEquals(tone.ToneId, null)) cmd.Parameters.AddWithValue("@ToneId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ToneId", tone.ToneId);
                

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
  
  
  
        public int Insert(Click click)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Click] (ClickId, Name, Description)
                                    VALUES (@ClickId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(click.ClickId, null)) cmd.Parameters.AddWithValue("@ClickId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ClickId", click.ClickId);
                
                  
                if (ReferenceEquals(click.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", click.Name);
                
                  
                if (ReferenceEquals(click.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", click.Description);
                

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
        public int Upsert(Click click)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = click.ClickId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Click WHERE ClickId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(click);
                else return this.Insert(click);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllClicks<T>()
            where T : Click, new()
        {
            return this.GetAllClicks<T>(String.Empty);
        }

        
        public List<T> GetAllClicks<T>(String whereClause)
            where T : Click, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Click]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T click = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ClickId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          click.ClickId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          click.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          click.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(click);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Click
        /// </summary>
        /// <returns></returns>
        public int Update(Click click)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Click] SET 
                                    Name = @Name,Description = @Description
                                    WHERE ClickId = @ClickId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(click.ClickId, null)) cmd.Parameters.AddWithValue("@ClickId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ClickId", click.ClickId);
                 //TEXT
                
                if (ReferenceEquals(click.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", click.Name);
                 //TEXT
                
                if (ReferenceEquals(click.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", click.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Click
        /// </summary>
        /// <returns></returns>
        public int Delete(Click click)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Click] 
                                    WHERE ClickId = @ClickId", this.Schema);
                                    
                
                if (ReferenceEquals(click.ClickId, null)) cmd.Parameters.AddWithValue("@ClickId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ClickId", click.ClickId);
                

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
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Language] (LanguageId, Name, Description)
                                    VALUES (@LanguageId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(language.LanguageId, null)) cmd.Parameters.AddWithValue("@LanguageId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@LanguageId", language.LanguageId);
                
                  
                if (ReferenceEquals(language.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", language.Name);
                
                  
                if (ReferenceEquals(language.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", language.Description);
                

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
                                    Name = @Name,Description = @Description
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
  
  
  
        public int Insert(Extension extension)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Extension] (ExtensionId, Name, Description)
                                    VALUES (@ExtensionId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(extension.ExtensionId, null)) cmd.Parameters.AddWithValue("@ExtensionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ExtensionId", extension.ExtensionId);
                
                  
                if (ReferenceEquals(extension.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", extension.Name);
                
                  
                if (ReferenceEquals(extension.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", extension.Description);
                

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
        public int Upsert(Extension extension)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = extension.ExtensionId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Extension WHERE ExtensionId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(extension);
                else return this.Insert(extension);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllExtensions<T>()
            where T : Extension, new()
        {
            return this.GetAllExtensions<T>(String.Empty);
        }

        
        public List<T> GetAllExtensions<T>(String whereClause)
            where T : Extension, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Extension]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T extension = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ExtensionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          extension.ExtensionId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          extension.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          extension.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(extension);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Extension
        /// </summary>
        /// <returns></returns>
        public int Update(Extension extension)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Extension] SET 
                                    Name = @Name,Description = @Description
                                    WHERE ExtensionId = @ExtensionId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(extension.ExtensionId, null)) cmd.Parameters.AddWithValue("@ExtensionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ExtensionId", extension.ExtensionId);
                 //TEXT
                
                if (ReferenceEquals(extension.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", extension.Name);
                 //TEXT
                
                if (ReferenceEquals(extension.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", extension.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Extension
        /// </summary>
        /// <returns></returns>
        public int Delete(Extension extension)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Extension] 
                                    WHERE ExtensionId = @ExtensionId", this.Schema);
                                    
                
                if (ReferenceEquals(extension.ExtensionId, null)) cmd.Parameters.AddWithValue("@ExtensionId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ExtensionId", extension.ExtensionId);
                

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
  
  
  
        public int Insert(Human human)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Human] (HumanId, Name, Description)
                                    VALUES (@HumanId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(human.HumanId, null)) cmd.Parameters.AddWithValue("@HumanId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@HumanId", human.HumanId);
                
                  
                if (ReferenceEquals(human.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", human.Name);
                
                  
                if (ReferenceEquals(human.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", human.Description);
                

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
        public int Upsert(Human human)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = human.HumanId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Human WHERE HumanId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(human);
                else return this.Insert(human);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllHumans<T>()
            where T : Human, new()
        {
            return this.GetAllHumans<T>(String.Empty);
        }

        
        public List<T> GetAllHumans<T>(String whereClause)
            where T : Human, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Human]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T human = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("HumanId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          human.HumanId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          human.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          human.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(human);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Human
        /// </summary>
        /// <returns></returns>
        public int Update(Human human)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Human] SET 
                                    Name = @Name,Description = @Description
                                    WHERE HumanId = @HumanId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(human.HumanId, null)) cmd.Parameters.AddWithValue("@HumanId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@HumanId", human.HumanId);
                 //TEXT
                
                if (ReferenceEquals(human.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", human.Name);
                 //TEXT
                
                if (ReferenceEquals(human.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", human.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Human
        /// </summary>
        /// <returns></returns>
        public int Delete(Human human)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Human] 
                                    WHERE HumanId = @HumanId", this.Schema);
                                    
                
                if (ReferenceEquals(human.HumanId, null)) cmd.Parameters.AddWithValue("@HumanId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@HumanId", human.HumanId);
                

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
  
  
  
        public int Insert(Datum datum)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Datum] (DatumId, Name, Description)
                                    VALUES (@DatumId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(datum.DatumId, null)) cmd.Parameters.AddWithValue("@DatumId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DatumId", datum.DatumId);
                
                  
                if (ReferenceEquals(datum.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", datum.Name);
                
                  
                if (ReferenceEquals(datum.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", datum.Description);
                

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
        public int Upsert(Datum datum)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = datum.DatumId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Datum WHERE DatumId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(datum);
                else return this.Insert(datum);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllDatums<T>()
            where T : Datum, new()
        {
            return this.GetAllDatums<T>(String.Empty);
        }

        
        public List<T> GetAllDatums<T>(String whereClause)
            where T : Datum, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Datum]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T datum = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("DatumId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          datum.DatumId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          datum.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          datum.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(datum);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Datum
        /// </summary>
        /// <returns></returns>
        public int Update(Datum datum)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Datum] SET 
                                    Name = @Name,Description = @Description
                                    WHERE DatumId = @DatumId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(datum.DatumId, null)) cmd.Parameters.AddWithValue("@DatumId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DatumId", datum.DatumId);
                 //TEXT
                
                if (ReferenceEquals(datum.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", datum.Name);
                 //TEXT
                
                if (ReferenceEquals(datum.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", datum.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Datum
        /// </summary>
        /// <returns></returns>
        public int Delete(Datum datum)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Datum] 
                                    WHERE DatumId = @DatumId", this.Schema);
                                    
                
                if (ReferenceEquals(datum.DatumId, null)) cmd.Parameters.AddWithValue("@DatumId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@DatumId", datum.DatumId);
                

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
  
  
  
        public int Insert(Channel channel)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Channel] (ChannelId, Name, Description)
                                    VALUES (@ChannelId, @Name, @Description)", this.Schema);

                
                  
                if (ReferenceEquals(channel.ChannelId, null)) cmd.Parameters.AddWithValue("@ChannelId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ChannelId", channel.ChannelId);
                
                  
                if (ReferenceEquals(channel.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", channel.Name);
                
                  
                if (ReferenceEquals(channel.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", channel.Description);
                

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
        public int Upsert(Channel channel)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = channel.ChannelId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM Channel WHERE ChannelId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(channel);
                else return this.Insert(channel);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllChannels<T>()
            where T : Channel, new()
        {
            return this.GetAllChannels<T>(String.Empty);
        }

        
        public List<T> GetAllChannels<T>(String whereClause)
            where T : Channel, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Channel]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T channel = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ChannelId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          channel.ChannelId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          channel.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          channel.Description = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(channel);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Channel
        /// </summary>
        /// <returns></returns>
        public int Update(Channel channel)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Channel] SET 
                                    Name = @Name,Description = @Description
                                    WHERE ChannelId = @ChannelId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(channel.ChannelId, null)) cmd.Parameters.AddWithValue("@ChannelId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ChannelId", channel.ChannelId);
                 //TEXT
                
                if (ReferenceEquals(channel.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", channel.Name);
                 //TEXT
                
                if (ReferenceEquals(channel.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", channel.Description);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Channel
        /// </summary>
        /// <returns></returns>
        public int Delete(Channel channel)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Channel] 
                                    WHERE ChannelId = @ChannelId", this.Schema);
                                    
                
                if (ReferenceEquals(channel.ChannelId, null)) cmd.Parameters.AddWithValue("@ChannelId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ChannelId", channel.ChannelId);
                

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

      