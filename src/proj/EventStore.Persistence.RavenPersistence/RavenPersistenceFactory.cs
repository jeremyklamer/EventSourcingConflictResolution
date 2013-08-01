﻿namespace EventStore.Persistence.RavenPersistence
{
	using Raven.Client;
	using Raven.Client.Document;

	public class RavenPersistenceFactory : IPersistenceFactory
	{
		private readonly RavenConfiguration config;

		public RavenPersistenceFactory(RavenConfiguration config)
		{
			this.config = config;
		}

		public virtual IPersistStreams Build()
		{
			var store = this.GetStore();
			return new RavenPersistenceEngine(store, this.config);
		}
		protected virtual IDocumentStore GetStore()
		{
			var store = new DocumentStore();

			if (!string.IsNullOrEmpty(this.config.ConnectionName))
				store.ConnectionStringName = this.config.ConnectionName;

			if (this.config.Url != null)
				store.Url = this.config.Url.ToString();

			if (!string.IsNullOrEmpty(this.config.DefaultDatabase))
				store.DefaultDatabase = this.config.DefaultDatabase;

			store.Initialize();

			return store;
		}
	}
}