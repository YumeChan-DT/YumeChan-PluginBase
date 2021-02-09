using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;



namespace Nodsoft.YumeChan.PluginBase.Tools.Data
{
    /// <summary>
    /// This class represents a basic document that can be stored in MongoDb.
    /// Your document must implement this class in order for the Entity Repository to handle them.
    /// </summary>
    public interface IDocument<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The Primary Key, which must be decorated with the [BsonId] attribute 
        /// if you want the MongoDb C# driver to consider it to be the document ID.
        /// </summary>
        [BsonId]
        TKey Id { get; set; }
    }
}
