#pragma checksum "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fabdb90ecc7f19d88221a6b3d665dcd320e9a689"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserList), @"mvc.1.0.view", @"/Views/User/UserList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fabdb90ecc7f19d88221a6b3d665dcd320e9a689", @"/Views/User/UserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11804900f707b69b308f3cae29b6b9331010d317", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Penguins_Front_End.Models.ViewModels.UserListVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
  
    ViewData["Title"] = "User List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 13 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 16 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 19 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
       Write(Html.DisplayNameFor(model => model.NumberOfRoles));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 22 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
       Write(Html.DisplayNameFor(model => model.RoleNames));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
     foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfRoles));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
           Write(Html.DisplayFor(modelItem => item.RoleNames));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 43 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n    <tr>\r\n        <td>\r\n            ");
#nullable restore
#line 48 "G:\ETSU\GetHub\PenguinsFrontEnd\Penguins Front End\Views\User\UserList.cshtml"
       Write(Html.ActionLink("Assign Roles", "assignRoles"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    </tfoot>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Penguins_Front_End.Models.ViewModels.UserListVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591