using System;
using System.Threading.Tasks;

namespace CurrencyLayer4NET.Infrastructure.Execution
{
    /// <summary>
    /// Interface for requests invokation
    /// </summary>
    public interface IRequestPolicy
    {
        Task<T> ExecuteAsync<T>(Func<Task<T>> action);
    }
}