#pragma checksum "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3806218ce597a4fe3a70b63a7091721ae96b7c8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ListUsers), @"mvc.1.0.view", @"/Views/Admin/ListUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ListUsers.cshtml", typeof(AspNetCore.Views_Admin_ListUsers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3806218ce597a4fe3a70b63a7091721ae96b7c8b", @"/Views/Admin/ListUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f93e211ec252256ce55286b52d647a4d8b93d583", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ListUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarServiceMS.Models.BindingModels.UsersListingModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CarTable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Username", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "PhoneNumber", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "MemberSince", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "CarBrand", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "CarModel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "CarNumber", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Car", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowCars", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(181, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(190, 31, true);
            WriteLiteral("\r\n\r\n<html lang=\"en\">\r\n</html>\r\n");
            EndContext();
            BeginContext(221, 88, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b7822", async() => {
                BeginContext(227, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(235, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3806218ce597a4fe3a70b63a7091721ae96b7c8b8211", async() => {
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
                BeginContext(300, 2, true);
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
            BeginContext(309, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(313, 3301, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b10432", async() => {
                BeginContext(319, 49, true);
                WriteLiteral("\r\n\r\n\r\n    <div class=\"table-title\">\r\n    </div>\r\n");
                EndContext();
#line 21 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
     if (@Model.Users != null)
    {
        

#line default
#line hidden
#line 23 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
         if (Model.Users.Any())
        {

#line default
#line hidden
                BeginContext(451, 64, true);
                WriteLiteral("            <h1 align=\"center\" style=\"color: black\">Users</h1>\r\n");
                EndContext();
                BeginContext(517, 753, true);
                WriteLiteral(@"            <div>
                <table class=""table-fill"">
                    <thead>
                        <tr>
                            <th class=""text-center"" colspan=""2"">
                                <input id=""search-box"" class=""form-control input"" type=""search"" placeholder=""Search..."" />
                            </th>
                            <th class=""text-center"">
                                <button class=""btn btn-light"" id=""search-btn"" onclick=""search()"">Search</button>
                            </th>
                            <th class=""text-center"" colspan=""2"">
                                <select class=""browser-default custom-select"" id=""search-selector"">
                                    ");
                EndContext();
                BeginContext(1270, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b12371", async() => {
                    BeginContext(1295, 8, true);
                    WriteLiteral("Username");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1312, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1350, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b13875", async() => {
                    BeginContext(1372, 5, true);
                    WriteLiteral("Email");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1386, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1424, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b15376", async() => {
                    BeginContext(1452, 12, true);
                    WriteLiteral("Phone Number");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1473, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1511, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b16885", async() => {
                    BeginContext(1539, 12, true);
                    WriteLiteral("Member Since");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1560, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1598, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b18394", async() => {
                    BeginContext(1623, 9, true);
                    WriteLiteral("Car Brand");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1641, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1679, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b19899", async() => {
                    BeginContext(1704, 9, true);
                    WriteLiteral("Car Model");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1722, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
                BeginContext(1760, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b21404", async() => {
                    BeginContext(1786, 10, true);
                    WriteLiteral("Car Number");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1805, 593, true);
                WriteLiteral(@"


                                </select>

                            </th>
                        </tr>
                        <tr>
                            <th class=""text-center"">Username</th>
                            <th class=""text-center"">Email</th>
                            <th class=""text-center"">Phone Number</th>
                            <th class=""text-center"">Member Since</th>
                            <th class=""text-left""></th>

                        </tr>
                    </thead>
                    <tbody class=""table-hover"">


");
                EndContext();
#line 64 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                         foreach (var user in this.Model.Users)
                        {

#line default
#line hidden
                BeginContext(2490, 106, true);
                WriteLiteral("                            <tr>\r\n                                <td name=\"Username\" class=\"text-center\">");
                EndContext();
                BeginContext(2597, 13, false);
#line 67 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                                                                   Write(user.Username);

#line default
#line hidden
                EndContext();
                BeginContext(2610, 76, true);
                WriteLiteral("</td>\r\n                                <td name=\"Email\" class=\"text-center\">");
                EndContext();
                BeginContext(2687, 10, false);
#line 68 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                                                                Write(user.Email);

#line default
#line hidden
                EndContext();
                BeginContext(2697, 82, true);
                WriteLiteral("</td>\r\n                                <td name=\"PhoneNumber\" class=\"text-center\">");
                EndContext();
                BeginContext(2780, 16, false);
#line 69 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                                                                      Write(user.PhoneNumber);

#line default
#line hidden
                EndContext();
                BeginContext(2796, 82, true);
                WriteLiteral("</td>\r\n                                <td name=\"MemberSince\" class=\"text-center\">");
                EndContext();
                BeginContext(2879, 36, false);
#line 70 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                                                                      Write(user.MemberSince.ToShortDateString());

#line default
#line hidden
                EndContext();
                BeginContext(2915, 103, true);
                WriteLiteral("</td>\r\n\r\n                                <td class=\"text-center\">\r\n                                    ");
                EndContext();
                BeginContext(3018, 212, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3806218ce597a4fe3a70b63a7091721ae96b7c8b26136", async() => {
                    BeginContext(3088, 138, true);
                    WriteLiteral("\r\n                                        <button class=\"btn btn-dark button-Register\">Cars</button>\r\n                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 73 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                                                                                    WriteLiteral(user.Id);

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
                BeginContext(3230, 78, true);
                WriteLiteral("\r\n                                </td>\r\n\r\n                            </tr>\r\n");
                EndContext();
#line 79 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
                        }

#line default
#line hidden
                BeginContext(3335, 78, true);
                WriteLiteral("                    </tbody>\r\n\r\n                </table>\r\n            </div>\r\n");
                EndContext();
#line 84 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"

        }
        else
        {

#line default
#line hidden
                BeginContext(3451, 57, true);
                WriteLiteral("            <h1 align=\"center\">There are no users!</h1>\r\n");
                EndContext();
#line 89 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"

        }

#line default
#line hidden
#line 90 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
         
    }
    else
    {

#line default
#line hidden
                BeginContext(3545, 53, true);
                WriteLiteral("        <h1 align=\"center\">There are no users!</h1>\r\n");
                EndContext();
#line 95 "C:\Users\Qni\Desktop\Projects\C# Web\GitHub\Educational-projects\CarServiceMS\CarServiceMS\Views\Admin\ListUsers.cshtml"
    }

#line default
#line hidden
                BeginContext(3605, 2, true);
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
            BeginContext(3614, 982, true);
            WriteLiteral(@"



<script>
    let serachBox = document.getElementById(""search-box"");
    let serachSelector = document.getElementById(""search-selector"");
    let searchText = """";


    function search() {

        let searchElementsCategory = Array.from(document.getElementsByTagName(""td""));

        searchText = serachBox.value;

        searchElementsCategory.forEach(element => filterTheElements(element));

    }

    function filterTheElements(element) {

        if (element.getAttribute('name') === serachSelector.value) {

            if (element.innerText !== searchText) {

                element.parentElement.style.display = ""none"";

            }
            else {

                let isTheElementHidden = element.parentElement.style.display === ""none"";


                if (isTheElementHidden) {

                    element.parentElement.style.display = ""table-row"";
                }
            }

        }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarServiceMS.Models.BindingModels.UsersListingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
