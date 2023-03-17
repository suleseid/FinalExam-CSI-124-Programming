using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamClass_Library
{
    public class Manager
    {
        //We need Manager Classser Class)
        //Under Manager Class we have to have 
        // string _Name
        // string _UserName 
        //string  _Password
        //enum position (Manager, General Manager)
        public enum Position {Manager, General_Manager}
        string _name;
        string _username;
        string _password;
        Position _role;

        public string Name { get => _name; set => _name = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public Position Role { get => _role; set => _role = value; }

        public Manager(string name, string username, string password, Position role)
        {
            _name = name;
            _username = username;
            _password = password;
            _role = role;
        }
        //Required to saving CSV and Json files, as a defoult constractor and Properties with set.
        public Manager()
        {

        }
        //Lets create a Methods
        public bool CheckName(string username)
        {
            return _username == username;
        }
        public bool ValidateUser(string username, string password)
        {
            return _username == Username && _password == password;  
        }
    }
}
