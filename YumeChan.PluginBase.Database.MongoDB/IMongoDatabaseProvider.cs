using MongoDB.Driver;

namespace YumeChan.PluginBase.Database.MongoDB;

/// <summary>
/// Provides a database handler, for a plugin manifest of type <see cref="TPlugin"/>.
/// </summary>
/// <typeparam name="TPlugin">Type of current Plugin Manifest (inheriting <see cref="IPlugin"/>)</typeparam>
public interface IMongoDatabaseProvider<in TPlugin> where TPlugin : IPlugin
{
	/// <summary>
	/// Gets a dedicated <see cref="IMongoDatabase"/> that can be used inside <see cref="TPlugin"/>.
	/// </summary>
	/// <returns><see cref="IMongoDatabase"/> tailored to <see cref="TPlugin"/></returns>
	public IMongoDatabase GetMongoDatabase();

	/// <summary>
	/// Sets the connection details for <see cref="GetMongoDatabase"/>.
	/// </summary>
	/// <param name="connectionString">ConnectionString for MongoDB server connection</param>
	/// <param name="databaseName">Name of database within the server</param>
	public void SetMongoDb(string connectionString, string databaseName);
}