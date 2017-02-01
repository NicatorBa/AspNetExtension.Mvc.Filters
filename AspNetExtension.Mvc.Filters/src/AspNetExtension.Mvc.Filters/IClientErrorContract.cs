using System.Threading.Tasks;

namespace AspNetExtension.Mvc.Filters
{
    public interface IClientErrorContract
    {
        Task InvokeAsync(ClientErrorContext context, ContractExecutionDelegate next);
    }
}
