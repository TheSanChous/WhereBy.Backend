using System;
using WhereBy.Persistence;

namespace WhereBy.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DatabaseCOntextContext Context;

        public TestCommandBase()
        {
            Context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
}
