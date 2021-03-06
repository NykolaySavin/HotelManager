﻿using HotelManager.Model.OrderDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Employee : Person
    {
        public Employee( string name,string surname, string phone, string email, string role) : base(name, surname, email, phone)
        {
            Username =email;
            Email = email;
            Role = role;
        }
        public Employee()
        {

        }
        public Service Service
        {
            get;set;
        }
        public string Username
        {
            get;
            set;
        }
        public string Role
        {
            get;
            set;
        }
    }
}
