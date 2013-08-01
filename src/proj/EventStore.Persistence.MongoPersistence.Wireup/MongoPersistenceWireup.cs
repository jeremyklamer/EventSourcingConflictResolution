namespace EventStore
{
	using System.Transactions;
	using Logging;
	using Persistence.MongoPersistence;
	using Serialization;

	public class MongoPersistenceWireup : PersistenceWireup
	{
		private static readonly ILog Logger = LogFactory.BuildLogger(typeof(MongoPersistenceWireup));

		public MongoPersistenceWireup(Wireup inner, string connectionName, IDocumentSerializer serializer)
			: base(inner)
		{
			Logger.Debug("Configuring Mongo persistence engine.");

			var options = this.Container.Resolve<TransactionScopeOption>();
			if (options != TransactionScopeOption.Suppress)
				Logger.Warn("MongoDB does not participate in transactions using TransactionScope.");

			this.Container.Register(c => new MongoPersistenceFactory(
				connectionName,
				serializer).Build());
		}
	}
}