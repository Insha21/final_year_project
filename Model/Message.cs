using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Model
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }       // Unique message ID
        public string? SenderId { get; set; } = "";
        public string? SenderName { get; set; } = "";
        public string? Text { get; set; } = "";
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
