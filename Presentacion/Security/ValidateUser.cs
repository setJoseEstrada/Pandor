using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Presentacion.Security
{
    //public class ValidateUser: IActionFilter
    //{




        public class ValidarUsuario : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
           
            var nombre = filterContext.HttpContext.Session.GetString("nombre");

            if (nombre == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }


            base.OnActionExecuting(filterContext);
        }
    }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{

        //    var nombre = context.HttpContext.Session.GetString("nombre");

        //    if (nombre == null)
        //    {
        //        context.Result = new RedirectResult("~/Login/Index");
        //    }


        //    base.OnActionExecuting(context); 

        //}




        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public ValidateUser(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //public void OnActionExecuted(ActionExecutedContext context)
        //{

        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var session = _httpContextAccessor.HttpContext.Session;
        //    var nombre = session.GetString("nombre");



        //    if(nombre == null)
        //    {
        //        context.Result = new RedirectResult("~/Login/Index");
        //    }





        //}


    }
//}
