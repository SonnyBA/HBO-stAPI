﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MySql.Data.MySqlClient;

namespace PoohAPI.Infrastructure.Common.Repositories
{
    public abstract class MySQLBaseRepository : IMySQLBaseRepository
    {  
        private readonly IMapper _mapper;
        private readonly IMySQLClient _client;

        public MySQLBaseRepository(IMapper mapper, IMySQLClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        //Add methods for SELECT, INSERT, UPDATE statements that also manage the connectionstate so as to keep the responsability
        //for the connectionstate it in this class.
        public T GetSingle<T>(string query)
        {
            if (_client.OpenConnection())
            {
                var command = new MySqlCommand(query, _client.Connection());
                var reader = command.ExecuteReader();
                _client.CloseConnection();
                if (reader.HasRows)
                    return _mapper.Map<IDataReader, T>(reader);
            }

            return default(T);
        }

        public IEnumerable<T> GetAll<T>(string query)
        {
            if (_client.OpenConnection())
            {
                var command = new MySqlCommand(query, _client.Connection());
                var reader = command.ExecuteReader();
                _client.CloseConnection();
                if (reader.HasRows)
                    return _mapper.Map<IDataReader, List<T>>(reader);
            }
            return null;
        }

        public void NonQuery(string query)
        {
            if (_client.OpenConnection())
            {
                var command = new MySqlCommand(query, _client.Connection());
                command.ExecuteNonQuery();
                _client.CloseConnection();
            }
        }
    }
}