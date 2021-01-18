using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int Age { set; get; }
        public int salary { set; get; }
        public string Address { set; get; }
        public int Phone { set; get; }
        public string Postion { set; get; }
        public DateTime JoiningDate { set; get; }
    }
}
