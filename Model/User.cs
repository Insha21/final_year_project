using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }
        public string? ClientId { get; set; }
        public string? Name { get; set; } = "";
        public string? Reason { get; set; } = "";
        public string? Time { get; set; } = "";
        public string? Address { get; set; } = "";
        public DateTime DOB { get; set; }
        public string? Sex { get; set; } = "";
        public string? Weight { get; set; } = "";
        public string? Height { get; set; } = "";
        public DateTime LastAppointment { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Phone { get; set; } = "";
        public List<string> Tags { get; set; } = new();
    }
}
