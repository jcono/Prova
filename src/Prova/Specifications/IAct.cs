using System;

namespace Prova.Specifications
{
    public interface IAct<TState> where TState : new()
    {
        IAssert<TState> Then(Action action);
        IAct<TState> And(Action action);
    }
}