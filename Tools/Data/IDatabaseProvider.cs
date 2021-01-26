namespace Nodsoft.YumeChan.PluginBase.Tools.Data
{
	public interface IDatabaseProvider<TPlugin> where TPlugin : Plugin
	{
		public IEntityRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : IDocument;
	}
}
