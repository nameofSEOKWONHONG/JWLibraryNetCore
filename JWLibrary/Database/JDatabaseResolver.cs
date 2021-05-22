﻿using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;

namespace JWLibrary.Database {
    /// <summary>
    ///     create database connection Resolver
    /// </summary>
    public class JDatabaseResolver {
        public static IDbConnection Resolve<TDatabase>()
            where TDatabase : IDbConnection {
            if (typeof(TDatabase) == typeof(Microsoft.Data.SqlClient.SqlConnection)) return JDatabaseInfo.Instance
                .GetConnection(ENUM_DATABASE_TYPE.MSSQL);
            if (typeof(TDatabase) == typeof(MySqlConnection)) return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.MYSQL);
            if (typeof(TDatabase) == typeof(NpgsqlConnection)) return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.POSTGRESQL);
            throw new NotImplementedException();
        }

        public static IDbConnection Resolve(ENUM_DATABASE_TYPE type) {
            if (type == ENUM_DATABASE_TYPE.MSSQL)
                return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.MSSQL);
            else if (type == ENUM_DATABASE_TYPE.MYSQL)
                return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.MYSQL);
            else if (type == ENUM_DATABASE_TYPE.POSTGRESQL)
                return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.POSTGRESQL);
            else if (type == ENUM_DATABASE_TYPE.REDIS)
                return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.REDIS);
            else if (type == ENUM_DATABASE_TYPE.MONGODB)
                return JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.MONGODB);
            else
                throw new NotImplementedException();
        }

        public static (IDbConnection first, IDbConnection second) Resolve<TDatabaseA, TDatabaseB>()
            where TDatabaseA : IDbConnection
            where TDatabaseB : IDbConnection {
            if (typeof(TDatabaseA) == typeof(TDatabaseB)) throw new Exception("not allow same database connection.");
            return new ValueTuple<IDbConnection, IDbConnection>(Resolve<TDatabaseA>(), Resolve<TDatabaseB>());
        }
    }
}