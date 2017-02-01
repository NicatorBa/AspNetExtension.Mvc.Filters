using System.Threading.Tasks;

namespace AspNetExtension.Mvc.Filters
{
    /// <summary>
    /// A delegate that asynchronously execute the next contract.
    /// </summary>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    public delegate Task ContractExecutionDelegate();
}
