using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;



namespace Nodsoft.YumeChan.PluginBase.Tools.Data
{
	public interface IDocument
	{
		[BsonId, BsonRepresentation(BsonType.String)]
		ObjectId Id { get; set; }

		DateTime CreatedAt { get; }
	}
}
