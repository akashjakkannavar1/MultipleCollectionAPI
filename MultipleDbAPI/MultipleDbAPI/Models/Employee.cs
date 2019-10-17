using MongoDB.Bson.Serialization.Attributes;


namespace MultipleDbAPI.Models
{
    public class Employee
    {
        [BsonId]
        public int _id { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string department_id { get; set; }
        public int salary { get; set; }
    }
}
