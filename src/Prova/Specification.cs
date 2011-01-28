using System;
using Prova.Specifications;

namespace Prova
{
    public abstract class Specification<TContext> : IArrange<TContext>, IAct<TContext>, IAssert<TContext> where TContext : new()
    {
        private readonly TContext _context = new TContext();

        protected TContext I
        {
            get { return _context; }
        }

        IAct<TContext> IAct<TContext>.And(Action action)
        {
            return Execute(action);
        }

        public IAssert<TContext> Then(Action action)
        {
            return Execute(action);
        }

        IArrange<TContext> IArrange<TContext>.And(Action action)
        {
            return Execute(action);
        }

        public IAct<TContext> When(Action action)
        {
            return Execute(action);
        }

        IAssert<TContext> IAssert<TContext>.And(Action action)
        {
            return Execute(action);
        }

        protected IArrange<TContext> Given(Action action)
        {
            return Execute(action);
        }

        private dynamic Execute(Action action)
        {
            action();
            return this;
        }
    }
}