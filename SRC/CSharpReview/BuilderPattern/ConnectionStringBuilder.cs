using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class ConnectionStringBuilder
    {
        public string _userName;
        public string _password;
        public string _host;
        public int? _port;
        public string _database;
        public bool _trustedConnection;
        public bool _multipleActiveRecords;

        public ConnectionStringBuilder(string host, string database) 
        {
            _host = host;
            _database = database;
        }
        public ConnectionStringBuilder SetCredentials(string username, string password)
        {
            _userName= username;
            _password = password;
            return this;
        }
        public ConnectionStringBuilder UseTrustedConnection()
        {
        _trustedConnection = true; 
            return this;
        }
        public ConnectionStringBuilder UseMultipleActiveRecordSet()
        {
            _multipleActiveRecords = true;
            return this;
        }
        public ConnectionStringBuilder UsePort(int port)
        {
        _port = port; 
            return this;
        }

        public string GetConnectionString()
        {
            string port = _port.HasValue ? "," + _port : "";
            string credentials;
            if ((!_trustedConnection))
                credentials = $"User Id = {_userName}; Password={_password}";
            else
                credentials = "Trusted_Connection = True;";

            string activeRecordSet = string.Empty;
            if (_multipleActiveRecords)
                activeRecordSet = "MultipleActiveResultSets=true";
            return $"Server={_host} {port};Database = {_database};{credentials} {activeRecordSet} ";
        }

    }
}
