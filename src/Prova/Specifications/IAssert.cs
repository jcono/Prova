using System;

namespace Prova.Specifications
{
    public interface IAssert<TState> where TState : new()
    {
        IAssert<TState> And(Action action);
    }
}