﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace ChocoboManagement.Models
{
    public partial class Stable
    {
        public Stable()
        {
            Chocobos = new HashSet<Chocobo>();
            TrainerStables = new HashSet<TrainerStable>();
        }

        public int Id { get; set; }
        public string StableName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Chocobo> Chocobos { get; set; }
        public virtual ICollection<TrainerStable> TrainerStables { get; set; }
    }
}