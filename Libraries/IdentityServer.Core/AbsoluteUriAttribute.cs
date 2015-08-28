using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer
{
    public class AbsoluteUriAttribute : ValidationAttribute
    {
        public AbsoluteUriAttribute()
        {
            ErrorMessageResourceName = "UriMustBeAbsolute";
            ErrorMessageResourceType = typeof (Core.Resources.AbsoluteUriAttribute);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var uri = value as Uri;
            if (uri == null)
            {
                var s = value as string;
                if (s != null)
                {
                    if (!Uri.TryCreate(s, UriKind.Absolute, out uri))
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("AbsoluteUriAttribute applied to a value that is not a Uri or a string.");
                }
            }
            return uri.IsAbsoluteUri;
        }
    }
}