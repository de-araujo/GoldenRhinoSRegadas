using System;
using System.Collections.Generic;
using System.Text;
//Libs
using SQLite;
namespace GoldenRhino.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
    }
}
