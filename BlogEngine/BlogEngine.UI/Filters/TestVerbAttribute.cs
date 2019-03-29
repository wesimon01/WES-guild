using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.UI.Filters
{
    public class TestVerbAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            //check the verb type
            var verbType = controllerContext.HttpContext.Request.HttpMethod;

            return true;
        }

    }
}