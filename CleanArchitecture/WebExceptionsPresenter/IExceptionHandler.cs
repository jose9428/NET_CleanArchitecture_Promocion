using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        public Task Handle(ExceptionContext context);
    }
}
