using System;

namespace Prova.Specifications
{
    public interface IArrange<TState> where TState : new()
    {
        IAct<TState> When(Action action);
        IArrange<TState> And(Action action);
    }
}