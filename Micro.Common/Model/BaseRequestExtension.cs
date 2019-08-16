using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Micro.Common.Model
{
    public static class BaseRequestExtension
    {
        public static T FillBaseModel<T>(this BaseRequest request) where T : BaseRequest
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            try
            {
                if (instance is BaseRequest)
                {
                    ((BaseRequest)instance).Action = request.Action;
                    ((BaseRequest)instance).APP_Version = request.APP_Version;
                    ((BaseRequest)instance).LanguageCode = request.LanguageCode;
                    ((BaseRequest)instance).PlatformTag = Platform.Web + "";
                    ((BaseRequest)instance).ChannelTag = Channel.CMS + "";
                    ((BaseRequest)instance).IPAddress = new HttpRequestWrapper(System.Web.HttpContext.Current.Request).GetClientIpAddress();
                    ((BaseRequest)instance).UserAgent = System.Web.HttpContext.Current.Request.UserAgent + "";
                    ((BaseRequest)instance).Token = request.Token;
                }
            }
            catch
            {
            }
            return instance;
        }

        public static T FillBaseModel<T>(this BaseRequest request, T data) where T : BaseRequest
        {
            try
            {
                if (data is BaseRequest)
                {
                    ((BaseRequest)data).Action = request.Action;
                    ((BaseRequest)data).APP_Version = request.APP_Version;
                    ((BaseRequest)data).LanguageCode = request.LanguageCode;
                    ((BaseRequest)data).PlatformTag = Platform.Web + "";
                    ((BaseRequest)data).ChannelTag = Channel.CMS + "";
                    ((BaseRequest)data).IPAddress = new HttpRequestWrapper(System.Web.HttpContext.Current.Request).GetClientIpAddress();
                    ((BaseRequest)data).UserAgent = System.Web.HttpContext.Current.Request.UserAgent + "";
                    ((BaseRequest)data).Token = request.Token;
                }
            }
            catch
            {
            }
            return data;
        }
    }
}
