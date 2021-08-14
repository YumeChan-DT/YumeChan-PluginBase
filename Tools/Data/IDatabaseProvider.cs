using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

/**
 *	IDatabaseProvider.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under GNU-LGPL v2.1
 **/

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
		public void SetMongoDb(string connectionString, string databaseName);

		/// <summary>
		///	Provides a <see cref="DbContextOptionsBuilder"/> used for building a <see cref="DbContext"/> for a Postgres type server.
		/// </summary>
		/// <returns><see cref="DbContextOptionsBuilder"/> tailored to <see cref="TPlugin"/>.</returns>
		public DbContextOptionsBuilder GetPostgresContextOptionsBuilder();
	}
}
