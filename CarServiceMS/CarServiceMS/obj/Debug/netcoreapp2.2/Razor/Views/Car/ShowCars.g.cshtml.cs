#pragma checksum "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3a6389935a8b14a66758b13007dc530f2724b11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car_ShowCars), @"mvc.1.0.view", @"/Views/Car/ShowCars.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Car/ShowCars.cshtml", typeof(AspNetCore.Views_Car_ShowCars))]
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
#line 1 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\_ViewImports.cshtml"
using CarServiceMS;

#line default
#line hidden
#line 2 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\_ViewImports.cshtml"
using CarServiceMS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3a6389935a8b14a66758b13007dc530f2724b11", @"/Views/Car/ShowCars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f93e211ec252256ce55286b52d647a4d8b93d583", @"/Views/_ViewImports.cshtml")]
    public class Views_Car_ShowCars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarServiceMS.Models.BindingModels.CarListingModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CarTable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Car", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("size", new global::Microsoft.AspNetCore.Html.HtmlString("20"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(179, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(188, 33, true);
            WriteLiteral("\r\n\r\n\r\n<html lang=\"en\">\r\n</html>\r\n");
            EndContext();
            BeginContext(221, 249, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b118325", async() => {
                BeginContext(227, 169, true);
                WriteLiteral("\r\n \r\n    <meta charset=\"utf-8\" />\r\n    <title>Table Style</title>\r\n    <meta name=\"viewport\" content=\"initial-scale=1.0; maximum-scale=1.0; width=device-width;\">\r\n\r\n    ");
                EndContext();
                BeginContext(396, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f3a6389935a8b14a66758b13007dc530f2724b118891", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(461, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(470, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(474, 4538, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1111112", async() => {
                BeginContext(480, 87, true);
                WriteLiteral("\r\n\r\n\r\n    <div class=\"table-title\">\r\n        <h3 align=\"center\">Cars</h3>\r\n    </div>\r\n");
                EndContext();
#line 27 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
     if (@Model.Cars != null)
    {
        

#line default
#line hidden
#line 29 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
         if (Model.Cars.Any())
        {


#line default
#line hidden
                BeginContext(650, 613, true);
                WriteLiteral(@"            <div>
                <table class=""table-fill"">
                    <thead>
                        <tr>
                            <th class=""text-center"">Brand</th>
                            <th class=""text-center"">Model</th>
                            <th class=""text-center"">Year From</th>
                            <th class=""text-center"">Number</th>
                            <th class=""text-left""></th>
                            <th class=""text-left""></th>

                        </tr>
                    </thead>
                    <tbody class=""table-hover"">


");
                EndContext();
#line 48 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                         foreach (var car in this.Model.Cars)
                        {

#line default
#line hidden
                BeginContext(1353, 90, true);
                WriteLiteral("                            <tr>\r\n                                <td class=\"text-center\">");
                EndContext();
                BeginContext(1444, 9, false);
#line 51 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                                                   Write(car.Brand);

#line default
#line hidden
                EndContext();
                BeginContext(1453, 63, true);
                WriteLiteral("</td>\r\n                                <td class=\"text-center\">");
                EndContext();
                BeginContext(1517, 9, false);
#line 52 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                                                   Write(car.Model);

#line default
#line hidden
                EndContext();
                BeginContext(1526, 63, true);
                WriteLiteral("</td>\r\n                                <td class=\"text-center\">");
                EndContext();
                BeginContext(1590, 17, false);
#line 53 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                                                   Write(car.YearFrom.Year);

#line default
#line hidden
                EndContext();
                BeginContext(1607, 63, true);
                WriteLiteral("</td>\r\n                                <td class=\"text-center\">");
                EndContext();
                BeginContext(1671, 10, false);
#line 54 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                                                   Write(car.Number);

#line default
#line hidden
                EndContext();
                BeginContext(1681, 127, true);
                WriteLiteral("</td>\r\n                                <td class=\"text-center\">\r\n                                    <button id=\"remove-button\"");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 1808, "\"", 1842, 3);
                WriteAttributeValue("", 1818, "showRemoveField(", 1818, 16, true);
#line 56 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
WriteAttributeValue("", 1834, car.Id, 1834, 7, false);

#line default
#line hidden
                WriteAttributeValue("", 1841, ")", 1841, 1, true);
                EndWriteAttribute();
                BeginContext(1843, 170, true);
                WriteLiteral(" class=\"badge-dark\">Remove</button>\r\n                                </td>\r\n                                <td class=\"text-center\">\r\n                                    ");
                EndContext();
                BeginContext(2013, 189, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1116026", async() => {
                    BeginContext(2078, 120, true);
                    WriteLiteral("\r\n                                        <button class=\"badge-dark\">Edit</button>\r\n                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 59 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                                                                                WriteLiteral(car.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2202, 107, true);
                WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n                            <tr");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 2309, "\"", 2321, 1);
#line 64 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
WriteAttributeValue("", 2314, car.Id, 2314, 7, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2322, 192, true);
                WriteLiteral(" style=\"display: none\">\r\n                                <td style=\"padding-right:10px; padding-left:10px\" class=\"text-center\" colspan=\"2\">Your password:</td>\r\n                                ");
                EndContext();
                BeginContext(2514, 1024, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1119648", async() => {
                    BeginContext(2575, 164, true);
                    WriteLiteral("\r\n                                    <td style=\"padding-right:10px; padding-left:10px\" class=\"text-center\" colspan=\"2\">\r\n\r\n                                        ");
                    EndContext();
                    BeginContext(2739, 55, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f3a6389935a8b14a66758b13007dc530f2724b1120226", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 69 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Password);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2794, 42, true);
                    WriteLiteral("\r\n                                        ");
                    EndContext();
                    BeginContext(2836, 63, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1122297", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 70 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Password);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2899, 42, true);
                    WriteLiteral("\r\n                                        ");
                    EndContext();
                    BeginContext(2941, 52, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f3a6389935a8b14a66758b13007dc530f2724b1124220", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 71 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_8.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                    BeginWriteTagHelperAttribute();
#line 71 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                                                                     WriteLiteral(car.Id);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2993, 247, true);
                    WriteLiteral("\r\n\r\n\r\n                                    </td>\r\n                                    <td style=\"padding-right:5px; padding-left:5px\" class=\"text-center\">\r\n\r\n                                        <button type=\"submit\" size=\"30\" id=\"remove-button\"");
                    EndContext();
                    BeginWriteAttribute("onclick", " onclick=\"", 3240, "\"", 3274, 3);
                    WriteAttributeValue("", 3250, "showRemoveField(", 3250, 16, true);
#line 77 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
WriteAttributeValue("", 3266, car.Id, 3266, 7, false);

#line default
#line hidden
                    WriteAttributeValue("", 3273, ")", 3273, 1, true);
                    EndWriteAttribute();
                    BeginContext(3275, 256, true);
                    WriteLiteral(@"
                                                class=""badge-dark"">
                                            Confirm
                                        </button>



                                    </td>
                                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3538, 199, true);
                WriteLiteral("\r\n                               \r\n                                <td style=\"padding-right:5px; padding-left:5px\" class=\"text-center\">\r\n                                    <button id=\"remove-button\"");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 3737, "\"", 3772, 3);
                WriteAttributeValue("", 3747, "hiderRemoveField(", 3747, 17, true);
#line 88 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
WriteAttributeValue("", 3764, car.Id, 3764, 7, false);

#line default
#line hidden
                WriteAttributeValue("", 3771, ")", 3771, 1, true);
                EndWriteAttribute();
                BeginContext(3773, 236, true);
                WriteLiteral("\r\n                                            class=\"badge-dark\">\r\n                                        Cancel\r\n                                    </button>\r\n                                </td>\r\n                            </tr>\r\n");
                EndContext();
#line 94 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
                        }

#line default
#line hidden
                BeginContext(4036, 153, true);
                WriteLiteral("                    </tbody>\r\n\r\n                </table>\r\n            </div>\r\n            <div class=\"d-flex justify-content-center\">\r\n\r\n                ");
                EndContext();
                BeginContext(4189, 136, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1131333", async() => {
                    BeginContext(4233, 88, true);
                    WriteLiteral("\r\n                    <button class=\"badge-dark\">Add Your Car</button>\r\n                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4325, 24, true);
                WriteLiteral("\r\n\r\n            </div>\r\n");
                EndContext();
#line 106 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(4385, 63, true);
                WriteLiteral("            <h1 align=\"center\">You do not have any cars!</h1>\r\n");
                EndContext();
                BeginContext(4450, 75, true);
                WriteLiteral("            <div class=\"d-flex justify-content-center\">\r\n\r\n                ");
                EndContext();
                BeginContext(4525, 136, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1133698", async() => {
                    BeginContext(4569, 88, true);
                    WriteLiteral("\r\n                    <button class=\"badge-dark\">Add Your Car</button>\r\n                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4661, 24, true);
                WriteLiteral("\r\n\r\n            </div>\r\n");
                EndContext();
#line 118 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
        }

#line default
#line hidden
#line 118 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
         
    }
    else
    {

#line default
#line hidden
                BeginContext(4720, 59, true);
                WriteLiteral("        <h1 align=\"center\">You do not have any cars!</h1>\r\n");
                EndContext();
                BeginContext(4781, 67, true);
                WriteLiteral("        <div class=\"d-flex justify-content-center\">\r\n\r\n            ");
                EndContext();
                BeginContext(4848, 128, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3a6389935a8b14a66758b13007dc530f2724b1136222", async() => {
                    BeginContext(4892, 80, true);
                    WriteLiteral("\r\n                <button class=\"badge-dark\">Add Your Car</button>\r\n            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4976, 20, true);
                WriteLiteral("\r\n\r\n        </div>\r\n");
                EndContext();
#line 131 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Car\ShowCars.cshtml"
    }

#line default
#line hidden
                BeginContext(5003, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
            EndContext();
            BeginContext(5012, 336, true);
            WriteLiteral(@"

<script>

    function showRemoveField(number) {

        let div = document.getElementById(number.toString());

        div.style.display = ""table-row"";
    }

    function hiderRemoveField(number){
        let div = document.getElementById(number.toString());

        div.style.display = ""none"";
    }
</script>

");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarServiceMS.Models.BindingModels.CarListingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
