using Domain.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HaveNotification())
            {
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                var erros = JsonConvert.SerializeObject(_notificationContext.GetErrors());
                await context.HttpContext.Response.WriteAsync(erros);

                return;
            }

            await next();
        }
    }
}