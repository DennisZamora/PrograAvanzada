#pragma checksum "C:\Users\denza\Documents\GitHub\PrograAvanzada\Guia02\Guia02\Views\Info\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e29456c162f0c74ab4a9972d718d3d16627b1c6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Info_Info), @"mvc.1.0.view", @"/Views/Info/Info.cshtml")]
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
#line 1 "C:\Users\denza\Documents\GitHub\PrograAvanzada\Guia02\Guia02\Views\_ViewImports.cshtml"
using Guia02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\denza\Documents\GitHub\PrograAvanzada\Guia02\Guia02\Views\_ViewImports.cshtml"
using Guia02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e29456c162f0c74ab4a9972d718d3d16627b1c6f", @"/Views/Info/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d2b9d9f85c7e8d451a513dc11405968d038b0e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Info_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\denza\Documents\GitHub\PrograAvanzada\Guia02\Guia02\Views\Info\Info.cshtml"
  
    ViewData["Title"] = "NavBar";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<nav class=""nav"">
    <a class=""nav-link active"" aria-current=""page"" href=""https://www.youtube.com/watch?v=fY_O1Fb-e5Y"">Que es Bootstrap</a>
    <a class=""nav-link"" href=""https://www.youtube.com/watch?v=hqH8jk7t32Q"">Como implementar bootstraps</a>
</nav>

<div class=""text-body"">
    <h1 class=""display-4"">Bootstrap</h1>
    <p>Bootstrap es un marco de trabajo desarrollado en Twitter, el cual a través de clases y selectores de HTML permite la inclusión de estilos de CSS predeterminados lo que hace que el diagramado de páginas usando este marco sea más fácil y rápida.</a>.</p>
</div>

<div class=""dropdown"">
    <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenuButton1"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
        Mas informacion
    </button>
    <ul class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton1"">
        <li><a class=""dropdown-item"" href=""https://www.youtube.com/watch?v=hqH8jk7t32Q"">Como implementar bootstraps</a></li>
        <li><a cla");
            WriteLiteral("ss=\"dropdown-item\" href=\"https://www.youtube.com/watch?v=fY_O1Fb-e5Y\">Que es Bootstrap</a></li>\r\n        <li><a class=\"dropdown-item\" href=\"#\">Something else here</a></li>\r\n    </ul>\r\n</div>\r\n\r\n");
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
