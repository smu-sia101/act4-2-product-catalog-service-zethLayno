﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ProductCatalog_Layno.Models;

  

    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public int Stock { get; set; } 
        public string ImageUrl { get; set; } = null!;
    }