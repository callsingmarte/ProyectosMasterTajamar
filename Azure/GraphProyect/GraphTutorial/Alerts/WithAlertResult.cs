using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace GraphTutorial
{
    public class WithAlertResult : IActionResult
    {

        public IActionResult Result { get; }
        public string Type { get; }
        public string Message { get; }
        public string DebugInfo { get; }

        public WithAlertResult(IActionResult result, string type, string message, string debugInfo)
        {
            Result = result;
            Type = type;
            Message = message;
            DebugInfo = debugInfo;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var factory = context.HttpContext.RequestServices
           .GetService<ITempDataDictionaryFactory>();

            var tempData = factory.GetTempData(context.HttpContext);

            tempData["_alertType"] = Type;
            tempData["_alertMessage"] = Message;
            tempData["_alertDebugInfo"] = DebugInfo;

            await Result.ExecuteResultAsync(context);
        }
    }
}