using Xunit;

namespace JoaoLuizDeveloper.IntegrationTest.Config
{
    //[CollectionDefinition(nameof(IntegrationTestFixtureCollection))]
    //public class IntegrationTestFixtureCollection : ICollectionFixture<IntegrationTestsFixture<ProgramTesting>>
    //{
          
    //}

    public class IntegrationTestsFixture<TProgram> : IDisposable where TProgram : class
    {
        public void Dispose()
        {

        }
    }
}
