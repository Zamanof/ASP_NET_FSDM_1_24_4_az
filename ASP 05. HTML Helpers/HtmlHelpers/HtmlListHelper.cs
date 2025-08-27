﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace ASP_05._HTML_Helpers.HtmlHelpers;

public static class HtmlListHelper
{
    public static HtmlString ListFor(
                                    this IHtmlHelper helper,
                                    IEnumerable<object> items,
                                    string listTag = "ul",
                                    string color = "black",
                                    string fontSize = "16"
                                    )
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<{listTag} style='color:{color}; font-size:{fontSize}px'>");
        foreach(var item in items)
        {
            sb.AppendLine($"<li>{item}</li>");
        }
        sb.AppendLine($"</{listTag}>");

        return new HtmlString(sb.ToString());
    }

    public static HtmlString myForm(this IHtmlHelper helper, string method="get", string controller="", string action="")
    {
        return new HtmlString(@$"<form method='{method}' action='/{controller}/{action}'>
        <input type=""hidden"" value=""1"" name=""Id""/>
        <p>
            <label for=""Login"">Login</label>
        </p>

        <p>
            <input type=""text"" name=""Login""/>
        </p>

        <p>
            <label for=""Password"">Password</label>
        </p>

        <p>
            <input type=""password"" name=""Password"" />
        </p>
        <p>
            <input type=""submit"" value=""Send""/>
        </p>
    </form>");
       
    }
}
