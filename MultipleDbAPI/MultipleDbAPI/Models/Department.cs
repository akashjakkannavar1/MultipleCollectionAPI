using MongoDB.Bson.Serialization.Attributes;

namespace MultipleDbAPI.Models
{
    public class Department
    {
        [BsonId]
        public string _id { get; set; }
        public string department_name { get; set; }
        public string location { get; set; }
    }
}
