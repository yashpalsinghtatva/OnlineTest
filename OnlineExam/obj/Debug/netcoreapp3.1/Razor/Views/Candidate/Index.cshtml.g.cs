#pragma checksum "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candidate_Index), @"mvc.1.0.view", @"/Views/Candidate/Index.cshtml")]
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
#line 1 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\_ViewImports.cshtml"
using OnlineExam;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\_ViewImports.cshtml"
using OnlineExam.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab", @"/Views/Candidate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c26b38a268148b41f8d27cf9435d899b998ac06", @"/Views/_ViewImports.cshtml")]
    public class Views_Candidate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineTest.Models.Candidate>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/site.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<button type=\"button\" id=\"btnCandidateDetails\" class=\"btn btn-lg btn-primary\">Take Test</button>\r\n\r\n<!-- Modal HTML -->\r\n<div id=\"candidateModel\" class=\"modal fade\" tabindex=\"-1\">\r\n    <div class=\"modal-dialog\">\r\n        <div class=\"modal-content\">\r\n");
#nullable restore
#line 9 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
             using (Html.BeginForm("Create", "Candidate", FormMethod.Post))
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""modal-header"">
                    <h5 class=""modal-title"">Add Your Details</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                </div>
                <div class=""modal-body"">
                    ");
#nullable restore
#line 17 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <div class=\"form-horizontal\">\r\n                        ");
#nullable restore
#line 20 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 22 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                       Write(Html.LabelFor(model => model.candidateName, htmlAttributes: new { @class = "control-label col-md-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-7\">\r\n                                ");
#nullable restore
#line 24 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.EditorFor(model => model.candidateName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.ValidationMessageFor(model => model.candidateName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 30 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                       Write(Html.LabelFor(model => model.candidateEmail, htmlAttributes: new { @class = "control-label col-md-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-7\">\r\n                                ");
#nullable restore
#line 32 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.EditorFor(model => model.candidateEmail, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 33 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.ValidationMessageFor(model => model.candidateEmail, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 37 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                       Write(Html.LabelFor(model => model.candidiatePhoneNo, htmlAttributes: new { @class = "control-label col-md-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-7\">\r\n                                ");
#nullable restore
#line 39 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.EditorFor(model => model.candidiatePhoneNo, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 40 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.ValidationMessageFor(model => model.candidiatePhoneNo, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 44 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                       Write(Html.Label("lblCandidatePreferedLanguage", "Test Prefered Language", htmlAttributes: new { @class = "control-label col-md-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-6\">\r\n                                ");
#nullable restore
#line 46 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.DropDownListFor(model => model.candidatePreferedLanguageId, Model.lstPreferedLanguages, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 47 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.ValidationMessageFor(model => model.candidatePreferedLanguageId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 51 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                       Write(Html.Label("lblCandidateGender", "Gender", htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-6\">\r\n                                Male\r\n                                ");
#nullable restore
#line 54 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.RadioButton("candidateGender", 'M', new { @checked = "checked" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                Female\r\n                                ");
#nullable restore
#line 56 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
                           Write(Html.RadioButton("candidateGender", 'F'));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n\r\n");
            WriteLiteral(@"                    </div>

                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cancel</button>
                    <input type=""submit"" value=""Start Test"" class=""btn btn-success"" />
                </div>
");
#nullable restore
#line 74 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab13603", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab14643", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab15683", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 80 "C:\Users\tatva\source\repos\OnlineExam\OnlineExam\Views\Candidate\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab17565", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74108f8c6d0f0e0c476e87c5e65f1aa15c2952ab18605", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\"#btnCandidateDetails\").click(function () {\r\n            $(\"#candidateModel\").modal(\'show\');\r\n        });\r\n    });\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineTest.Models.Candidate> Html { get; private set; }
    }
}
#pragma warning restore 1591
