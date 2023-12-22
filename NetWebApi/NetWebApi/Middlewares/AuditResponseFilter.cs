using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.Entities;
using NetWebApi.Context;
using Repository;
using System.Text.Json;

namespace NetWebApi.Middlewares
{
    public class AuditResponseFilter : ActionFilterAttribute
    {
        private readonly ResponseAuditRepository _responseAuditRepository;

        public AuditResponseFilter()
        {
            this._responseAuditRepository = ApplicationDbContextFactoryConfig.Get<ResponseAuditRepository>();
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var action = await next();
            var result = action.Result as OkObjectResult;
            var audit = new ResponseAudit()
            {
                Date = DateTime.Now,
                Item = JsonSerializer.Serialize(result.Value)
            };
            //await this._responseAuditRepository.InsertAsync(audit);
        }
    }

    public class Response
    {
        public object Result { get; set; }
        public DateTime Date { get; set; }
    }
}