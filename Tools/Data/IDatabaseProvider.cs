using System;
using MongoDB.Driver;

namespace YumeChan.PluginBase.Tools.Data
{
	
	public interface IDatabaseProvider<TPlugin> where TPlugin : Plugin
	{
		public IMongoDatabase GetMongoDatabase();

		public void SetDb(string connectionString, string databaseName);
	}
}
