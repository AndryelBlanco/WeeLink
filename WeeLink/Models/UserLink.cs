using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WeeLink.Models
{
    public class UserLink
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserLinkRaw")]
        public string userLinkRaw { get; set; }

        [BsonElement("UserLinkShorted")]
        public string userLinkShorted { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("Owner")]
        public string Owner { get; set; }

        public UserLink()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
