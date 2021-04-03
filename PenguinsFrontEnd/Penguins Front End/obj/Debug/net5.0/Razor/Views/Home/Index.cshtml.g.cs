#pragma checksum "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c8b1defcf2f6205838248ed7f03e1e1b871f2fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\_ViewImports.cshtml"
using Penguins_Front_End.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c8b1defcf2f6205838248ed7f03e1e1b871f2fa", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11804900f707b69b308f3cae29b6b9331010d317", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Graphical Data";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 5 "C:\Users\Jonesad\Penguins\PenguinsFrontEnd\Penguins Front End\Views\Home\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<header>
    <script src=""https://code.highcharts.com/highcharts.src.js""></script>
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    <script src=""https://code.jquery.com/jquery-3.3.1.min.js""
            integrity=""sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=""
            crossorigin=""anonymous""></script>
</header>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c8b1defcf2f6205838248ed7f03e1e1b871f2fa4363", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <h2 id=""h2"">Index</h2>
        <figure class=""highcharts-figure container"">
            <div id=""container-fluid"" class=""container-fluid""></div>
            <p class=""highcharts-description"">
                A basic column chart .
            </p>
        </figure>
    </div>
    <script type=""text/javascript"">

        google.charts.load('visualization', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawLineChart);
        function drawLineChart() {
            $(document).ready(function () {
");
                WriteLiteral(@"                var response = $.ajax({
                    type: ""GET"",
                    url: ""http://penguinsapi.us-east-1.elasticbeanstalk.com/api/Metrics"",
                    data: ""{}"",
                    contentType: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    async: true,
                    success: function (result) {
                        $.each(result, function (key, item) {
                            name.push(item.name);
                            id.push(item.id);
                            login.push(item.login);
                            logout.push(item.logout);
                        });
                        //loadChart(name, id, login, logout);
                    },
                    error: function (errormessage) {
                        $('#h2').html(errormessage.responseText);
                        return false;
                    }
                }).responseText;

                var options =");
                WriteLiteral(@" {
                    title: 'Title',
                    curveType: 'function',
                    legend: { position: 'bottom', textStyle: { color: '#555', fontSize: 14 } }  // You can position the legend on 'top' or at the 'bottom'.
                };

                var figures = google.visualization.arrayToDataTable(name);

                var chart = new google.visualization.LineChart(document.getElementById('container-fluid'));
                chart.draw(figures, options);      // Draw the chart with Options.

");
                WriteLiteral("});\r\n        }\r\n    </script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
