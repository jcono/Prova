using System;

namespace Prova.Extensions
{
    public static class ForAction
    {
        public static Exception GetException(this Action action)
        {
            Exception exception = null;
            try
            {
                if (action.IsNotNothing())
                {
                    action();
                }
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            return exception;
        }
    }
}
