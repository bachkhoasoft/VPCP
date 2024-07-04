
using Amazon.Util;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class vpcp
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("MaNhiemVu")]
        [JsonPropertyName("MaNhiemVu")]
      
        public string MaNhiemVu { get; set; } = null!;
        public int LoaiNhiemVu { get; set; }
        public int DaDongBo { get; set; }

        public int TrangThaiCapNhat { get; set; }
        
            



    }
}
