using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataGov_API_Intro_6.Models
{
    
    public class Rootobject
    {
        [Key]
        public int Id { get; set; }

        public int page { get; set; }
        public List<Result> results { get; set; }
        
    }

    public class Result
    {[Key]
    public int id { get; set; }
        public Genre genres { get; set; }
        public string imdbid { get; set; }
        public string title { get; set; }
        public float imdbrating { get; set; }
        public int released { get; set; }
        public string synopsis { get; set; }
        public string type { get; set; }
        public Rootobject root { get; set; }
    }
    public class Genre
    { [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public List<Result> result { get; set; }
    }
}