using System;
using System.Threading.Tasks;

namespace CurrencyLayer4NET.Infrastructure.Execution
{
    /// <summary>
    /// This class invokes provided delegate by simply calling it
    /// </summary>
    public class SimpleRequestPolicy : IRequestPolicy
    {
        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
        {
            return await action();
        }
    }
}