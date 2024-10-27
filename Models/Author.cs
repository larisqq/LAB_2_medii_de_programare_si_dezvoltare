﻿using System.ComponentModel.DataAnnotations;

namespace LAB_2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book>? Books { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
