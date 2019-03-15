using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace nankamApp.Models
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Vorname { get; set; }

        public string Jobtitel { get; set; }

        public string Abteilung { get; set; }

        public byte[] Foto { get; set; }
    }


    public class FileTable
    {
      [Key]
        public int ID { get; set; } //primary key will be auto increament

        public byte[] Foto { get; set; } //This is will saved as varcharbindary(max) into the database
    }

    public class Context : DbContext
    {
        public Context()
           : base("FileContext") //connection string name in the database
        {

        }

        public DbSet<FileTable> FileTable { get; set; }
    }

}