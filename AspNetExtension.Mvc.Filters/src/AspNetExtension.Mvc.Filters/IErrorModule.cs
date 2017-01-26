using System.Threading.Tasks;

namespace AspNetExtension.Mvc.Filters
{
    public interface IErrorModule
    {
        Task InvokeAsync(ErrorFilterContext context, ModuleExecutionDelegate next);
    }
}
