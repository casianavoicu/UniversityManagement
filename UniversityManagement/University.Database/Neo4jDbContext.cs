using Neo4j.Driver;

namespace University.Database
{
    public class Neo4jDbContext : IDisposable
    {
        private readonly IDriver _driver;

        public Neo4jDbContext(IDriver driver)
        {
            _driver = driver;
        }

        public IAsyncSession Session => _driver.AsyncSession(o => o.WithDatabase("neo4j"));

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}