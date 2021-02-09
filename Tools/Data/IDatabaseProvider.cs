using System;

namespace Nodsoft.YumeChan.PluginBase.Tools.Data
{
	public interface IDatabaseProvider<TPlugin> where TPlugin : Plugin
	{
		public IEntityRepository<TEntity, TKey> GetEntityRepository<TEntity, TKey>()
			where TEntity : IDocument<TKey>
			where TKey : IEquatable<TKey>;
	}
}
