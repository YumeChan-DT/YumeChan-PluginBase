using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace YumeChan.PluginBase.Database.Postgres;


public interface IPostgresDatabaseProvider<in TPlugin> where TPlugin : IPlugin
{
	/// <summary>
	///	Provides a <see cref="DbContextOptionsBuilder"/> used for building a PostgreSQL-type <see cref="DbContext"/> implementation.
	/// </summary>
	/// <returns><see cref="DbContextOptionsBuilder"/> tailored to <see cref="TPlugin"/>.</returns>
	public Action<DbContextOptionsBuilder> GetPostgresContextOptionsBuilder();

	/// <summary>
	/// Provides a <see cref="DbContextOptionsBuilder"/> used for building a PostgreSQL-type <see cref="TContext"/> implementation.
	/// </summary>
	public Action<DbContextOptionsBuilder<TContext>> GetPostgresContextOptionsBuilder<TContext>() where TContext : DbContext;
}