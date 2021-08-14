using MongoDB.Driver;



namespace YumeChan.PluginBase.Tools.Data
{
	/// <summary>
	/// Provides a database handler, for a plugin manifest of type <see cref="TPlugin"/>.
	/// </summary>
	/// <typeparam name="TPlugin">Type of current Plugin Manifest (inheriting <see cref="Plugin"/>)</typeparam>
	public interface IDatabaseProvider<TPlugin> where TPlugin : Plugin
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
		public void SetDb(string connectionString, string databaseName);
	}
}
