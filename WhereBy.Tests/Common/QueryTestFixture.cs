using AutoMapper;
using System;
using WhereBy.Application.Interfaces;
using WhereBy.Application.Common.Mappings;
using WhereBy.Persistence;
using Xunit;

namespace WhereBy.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DatabaseCOntextContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = NotesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(INotesDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
