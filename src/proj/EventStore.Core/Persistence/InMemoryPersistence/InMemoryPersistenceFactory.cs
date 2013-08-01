﻿namespace EventStore.Persistence.InMemoryPersistence
{
	public class InMemoryPersistenceFactory : IPersistenceFactory
	{
		public virtual IPersistStreams Build()
		{
			return new InMemoryPersistenceEngine();
		}
	}
}
