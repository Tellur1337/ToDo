using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class Job
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Date_Time { get; set; }
        public bool Done { get; set; }
        public string Decription { get; set; }
    }
}