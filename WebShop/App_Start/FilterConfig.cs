using System.Web;
using System.Web.Mvc;
using WebShop.Infrastructure.Exeption;

namespace WebShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorLoggerAttribute());
        }
    }
}
