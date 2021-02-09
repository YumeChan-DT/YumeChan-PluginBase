using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;



namespace Nodsoft.YumeChan.PluginBase.Tools.Data
{
	public interface IEntityRepository<TDocument, TKey> 
		where TDocument : IDocument<TKey>
		where TKey : IEquatable<TKey>
	{
		IQueryable<TDocument> AsQueryable();

		IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);
		IEnumerable<TProjected> FilterBy<TProjected>(
			Expression<Func<TDocument, bool>> filterExpression,
			Expression<Func<TDocument, TProjected>> projectionExpression);

		TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);
		Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

		TDocument FindById(TKey id);
		Task<TDocument> FindByIdAsync(TKey id);

		void InsertOne(TDocument document);
		Task InsertOneAsync(TDocument document);

		void InsertMany(ICollection<TDocument> documents);
		Task InsertManyAsync(ICollection<TDocument> documents);

		void ReplaceOne(TDocument document);
		Task ReplaceOneAsync(TDocument document);

		void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);
		Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

		void DeleteById(TKey id);
		Task DeleteByIdAsync(TKey id);

		void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);
		Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
	}
}
