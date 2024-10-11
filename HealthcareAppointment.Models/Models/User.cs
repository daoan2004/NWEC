﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HealthcareAppointment.Models.Models
{
    public partial class User
    {
        public User()
        {
            AppointmentDoctors = new HashSet<Appointment>();
            AppointmentPatients = new HashSet<Appointment>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Specialization { get; set; }

        public virtual ICollection<Appointment> AppointmentDoctors { get; set; }
        public virtual ICollection<Appointment> AppointmentPatients { get; set; }
    }
}