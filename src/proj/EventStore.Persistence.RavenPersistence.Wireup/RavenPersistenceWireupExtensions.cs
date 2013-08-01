namespace EventStore
{
	public static class RavenPersistenceWireupExtensions
	{
		public static RavenPersistenceWireup UsingRavenPersistence(
			this Wireup wireup, string connectionName)
		{
			return new RavenPersistenceWireup(wireup, connectionName);
		}
	}
}