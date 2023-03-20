using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamClass_Library
{
   public class Player : IComparable<Player>
    {
        //We need Player Class: IComparable( it's a defolt sort)
        //string _fristName
        //string _lastName
        //string _number
        //double _salary

        string _fristName;
        string _lastName;
        string _number;
        double _salary;

        public Player(string fristName, string lastName, string number, double salary)
        {
            _fristName = fristName;
            _lastName = lastName;
            _number = number;
            _salary = salary;
        }
        public Player()
        {

        }

        public string FristName { get => _fristName; set => _fristName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Number { get => _number; set => _number = value; }
        public double Salary { get => _salary; set => _salary = value; }

        public int CompareTo(Player other)
        {
            return _lastName.CompareTo(other._lastName);
        }
    }
}
