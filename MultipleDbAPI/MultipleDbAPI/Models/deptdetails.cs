using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultipleDbAPI.Models
{
    public class deptdetails
    {
        
        public string name { get; set; }
        public string location { get; set; }
    }
}
