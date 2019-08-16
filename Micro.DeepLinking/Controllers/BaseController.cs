
using Micro.DeepLinking.Helpers;
using Micro.DeepLinking.Models;
using Micro.Common.Log;
using Micro.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Micro.DeepLinking.Controllers
{
    public class BaseController : Controller
    {
        DataHelper _dataHepler = new DataHelper();
        private LogHelper _logHelper = new LogHelper();
        public BaseRequest Base
        {
            get
            {
                return _dataHepler.BaseRequest;
            }
        }


        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

    }
}