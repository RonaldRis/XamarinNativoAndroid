using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidEmpty
{
    public static class PhoneTranslator
    {
        public static string ToNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            else
            {
                text = text.ToUpper();
                var newnumber = new StringBuilder();
                foreach (var c in text)
                {
                    if ("-0123456789".Contains(c))
                    {
                        newnumber.Append(c);
                    }
                    else
                    {
                        var result = TranslateToNumber(c);
                        if (result!=null)
                        {
                            newnumber.Append(result);
                        }
                    }
                }
                return newnumber.ToString();
            }
        }

        private static int? TranslateToNumber(char c)
        {

            if ("ABC".Contains(c))
            {
                return 2;
            }
            else if ("DEF".Contains(c))
            {
                return 3;
            }
            else if ("GHI".Contains(c))
            {
                return 4;
            }
            else if ("JKL".Contains(c))
            {
                return 5;
            }
            else if ("MNOÑ".Contains(c))
            {
                return 6;
            }
            else if ("PQRS".Contains(c))
            {
                return 7;
            }
            else if ("TUV".Contains(c))
            {
                return 8;
            }
            else if ("WXYZ".Contains(c))
            {
                return 9;
            }
            else
            {
                return null;
            }
        }
    }
}