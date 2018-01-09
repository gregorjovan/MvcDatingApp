using System;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace DatingApp.Models.Extensions.NameValueCollectionExtensions
{
    public static class NameValueCollectionExtension
    {
        public static void CopyToModelState(this NameValueCollection ex, ModelStateDictionary modelState)
        {
            foreach (string key in ex)
                foreach (string value in ex.GetValues(key))
                    modelState.AddModelError(key, value);
        }
    }
}