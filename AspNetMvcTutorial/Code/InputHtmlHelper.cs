using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// using System.Web.WebPages.Html;

namespace AspNetMvcTutorial.Code
{
    public static class InputHtmlHelper
    {
        public static IHtmlString ValuedCheckBox(this HtmlHelper helper, string name, string value, bool isChecked)
        {
            string checkedStr = isChecked ? "checked=\"checked\"" : "";
            string html = @"<input type=""checkbox"" name=""{0}"" value=""{1}"" {2}/>";
            return helper.Raw(String.Format(html, name, value, checkedStr));
        }
    }
}