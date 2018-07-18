using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using TinyShoppingCart.Presentation.Admin.Settings;

namespace TinyShoppingCart.Presentation.Admin.Filters.ActionFilters
{
    public class ThemeActionFilter : IActionFilter
    {
        private readonly AppSettings _appSettings;
        public ThemeActionFilter(IOptions<AppSettings> appSettings)
        {
            if(appSettings == null || appSettings.Value == null)
            {
                throw new ArgumentNullException(nameof(appSettings)); 
            }

            _appSettings = appSettings.Value;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Controller controller = context.Controller as Controller;
            if(controller != null)
            {
                controller.ViewBag.Theme = _appSettings.jQWidgetsTheme;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}