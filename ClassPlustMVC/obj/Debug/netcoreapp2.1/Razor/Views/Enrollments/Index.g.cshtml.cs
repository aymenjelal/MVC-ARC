#pragma checksum "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691e122d6fa7ac9d860f9906643188ac8d16340b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Enrollments_Index), @"mvc.1.0.view", @"/Views/Enrollments/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Enrollments/Index.cshtml", typeof(AspNetCore.Views_Enrollments_Index))]
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
#line 1 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\_ViewImports.cshtml"
using ClassPlustMVC;

#line default
#line hidden
#line 2 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\_ViewImports.cshtml"
using ClassPlustMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"691e122d6fa7ac9d860f9906643188ac8d16340b", @"/Views/Enrollments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b749e0addcc5566d6539ed970a4c2920bb92867", @"/Views/_ViewImports.cshtml")]
    public class Views_Enrollments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClassPlustMVC.Models.Enrollment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(96, 52, true);
            WriteLiteral("\r\n<h2>Enrolled Courses</h2>\r\n\r\n<div class=\"row\">\r\n\r\n");
            EndContext();
#line 11 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
         foreach (var item in Model)
        {
         



#line default
#line hidden
            BeginContext(212, 456, true);
            WriteLiteral(@"                <div class=""demo-card-square mdl-card mdl-shadow--2dp col-sm-5"" style="" margin-bottom:15px; margin-left:10px; padding-left:0px"">
                    <div class=""mdl-card__title mdl-card--expand"" style=""background: #00467F; background: -webkit-linear-gradient(to right, #A5CC82, #00467F); background: linear-gradient(to right, #A5CC82, #00467F); width:80rem;"">
                        <h2 class=""mdl-card__title-text"" style=""color:white""> ");
            EndContext();
            BeginContext(669, 52, false);
#line 18 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
                                                                         Write(Html.DisplayFor(modelItem => item.Course.CourseName));

#line default
#line hidden
            EndContext();
            BeginContext(721, 254, true);
            WriteLiteral("</h2>\r\n                    </div>\r\n                    <div class=\"mdl-card__supporting-text\" style=\"padding-left:15px\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-sm-12\">\r\n                                <h5>");
            EndContext();
            BeginContext(976, 59, false);
#line 23 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Course.CourseDescription));

#line default
#line hidden
            EndContext();
            BeginContext(1035, 208, true);
            WriteLiteral("</h5>\r\n                            </div>\r\n\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-sm-3\">\r\n                                <h6>");
            EndContext();
            BeginContext(1244, 52, false);
#line 29 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.Course.TeacherId));

#line default
#line hidden
            EndContext();
            BeginContext(1296, 131, true);
            WriteLiteral("</h6>\r\n                            </div>\r\n                            <div class=\"col-sm-6\">\r\n                                <h6>");
            EndContext();
            BeginContext(1428, 51, false);
#line 32 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Course.TeacherId));

#line default
#line hidden
            EndContext();
            BeginContext(1479, 212, true);
            WriteLiteral("</h6>\r\n\r\n                            </div>\r\n\r\n                        </div>\r\n\r\n                        <div class=\"row\">\r\n                            <div class=\"col-sm-3\">\r\n                                <h6>");
            EndContext();
            BeginContext(1692, 53, false);
#line 40 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.Course.SchoolName));

#line default
#line hidden
            EndContext();
            BeginContext(1745, 131, true);
            WriteLiteral("</h6>\r\n                            </div>\r\n                            <div class=\"col-sm-6\">\r\n                                <h6>");
            EndContext();
            BeginContext(1877, 52, false);
#line 43 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Course.SchoolName));

#line default
#line hidden
            EndContext();
            BeginContext(1929, 486, true);
            WriteLiteral(@"</h6>

                            </div>

                        </div>

                        <div class=""row"">
                            <div class=""col-sm-4""></div>
                            <div class=""col-sm-2"">
                            </div>
                            <div class=""col-sm-2"">
                               

                            </div>

                            <div class=""col-sm-2"">
                                <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2415, "\"", 2502, 5);
            WriteAttributeValue("", 2425, "location.href=\'", 2425, 15, true);
#line 59 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
WriteAttributeValue("", 2440, Url.Action("PendingAssignment","assignments"), 2440, 46, false);

#line default
#line hidden
            WriteAttributeValue("", 2486, "/", 2486, 1, true);
#line 59 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
WriteAttributeValue("", 2487, item.CourseId, 2487, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 2501, "\'", 2501, 1, true);
            EndWriteAttribute();
            BeginContext(2503, 346, true);
            WriteLiteral(@" class=""mdl-button mdl-js-button mdl-button--fab mdl-js-ripple-effect mdl-button--primary"">
                                    <i class=""material-icons"">description</i>
                                </button>


                            </div>
                            <div class=""col-sm-2"">
                                <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2849, "\"", 2915, 5);
            WriteAttributeValue("", 2859, "location.href=\'", 2859, 15, true);
#line 66 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
WriteAttributeValue("", 2874, Url.Action("Delete"), 2874, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2895, "/", 2895, 1, true);
#line 66 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
WriteAttributeValue("", 2896, item.EnrollmentId, 2896, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 2914, "\'", 2914, 1, true);
            EndWriteAttribute();
            BeginContext(2916, 340, true);
            WriteLiteral(@" class=""mdl-button mdl-js-button mdl-button--fab mdl-js-ripple-effect mdl-button--primary"">
                                    <i class=""material-icons"">delete</i>
                                </button>

                            </div>
                        </div>
                    </div>




                </div>
");
            EndContext();
#line 78 "C:\Users\Aymen\source\repos\ClassPlustMVC\ClassPlustMVC\Views\Enrollments\Index.cshtml"
            
        }

#line default
#line hidden
            BeginContext(3281, 12, true);
            WriteLiteral("\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClassPlustMVC.Models.Enrollment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
