#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySeenMobileWebViewLib.Views
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 1 "AddFilm2.cshtml"
using MySeenMobileWebViewLib;

#line default
#line hidden

#line 3 "AddFilm2.cshtml"
using MySeenLib;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "3.11.0.0")]
public partial class AddFilm2 : PortableRazor.ViewBase
{

#line hidden

#line 4 "AddFilm2.cshtml"
public FilmAddViewModel Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1\"");

WriteLiteral(" />\r\n\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"jquery.mobile-1.4.0.min.css\"");

WriteLiteral(" />\r\n    <script");

WriteLiteral(" src=\"jquery-1.10.2.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"jquery.mobile-1.4.0.min.js\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteLiteral(" src=\"bootstrap.min.js\"");

WriteLiteral("></script>\r\n    <link");

WriteLiteral(" href=\"bootstrap.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n</head>\r\n    <body>\r\n        <form>\r\n            <fieldset>\r\n             " +
"   <div");

WriteLiteral("  class=\"form-inline\"");

WriteLiteral(">\r\n");


#line 24 "AddFilm2.cshtml"
                    

#line default
#line hidden

#line 24 "AddFilm2.cshtml"
                     if (Model.Unknown_Error)
                    {

#line default
#line hidden
WriteLiteral(" <label");

WriteLiteral(" for=\"\"");

WriteLiteral(">UNKNOWN ERROR</label>");


#line 25 "AddFilm2.cshtml"
                                                         }


#line default
#line hidden
WriteLiteral("                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"editor-label\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(">Film Name</label>\r\n");

WriteLiteral("                    ");


#line 30 "AddFilm2.cshtml"
               Write(Html.TextArea("Name", Model.Name));


#line default
#line hidden
WriteLiteral("\r\n\r\n\r\n");


#line 33 "AddFilm2.cshtml"
                    

#line default
#line hidden

#line 33 "AddFilm2.cshtml"
                     if (!string.IsNullOrEmpty(Model.Name_Error)) 
                    {

#line default
#line hidden
WriteLiteral(" <label");

WriteLiteral(" for=\"\"");

WriteLiteral(">");


#line 34 "AddFilm2.cshtml"
                               Write(Model.Name_Error);


#line default
#line hidden
WriteLiteral("</label>");


#line 34 "AddFilm2.cshtml"
                                                             }


#line default
#line hidden
WriteLiteral("                </div>\r\n                <div");

WriteLiteral(" class=\"editor-field\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"Name2\"");

WriteLiteral(" name=\"Name2\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" />\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"editor-label\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(">Genre</label>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"editor-field\"");

WriteLiteral(">\r\n                    <select");

WriteLiteral(" id=\"Genre\"");

WriteLiteral(" name=\"Genre\"");

WriteLiteral(">\r\n                        <option ");


#line 44 "AddFilm2.cshtml"
                            Write(Model.Genre == 0 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"0\">1</option>\r\n                        <option ");


#line 45 "AddFilm2.cshtml"
                            Write(Model.Genre == 1 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"1\">2</option>\r\n                        <option ");


#line 46 "AddFilm2.cshtml"
                            Write(Model.Genre == 2 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"2\">3</option>\r\n                        <option ");


#line 47 "AddFilm2.cshtml"
                            Write(Model.Genre == 3 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"3\">4</option>\r\n                        <option ");


#line 48 "AddFilm2.cshtml"
                            Write(Model.Genre == 4 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"4\">5</option>\r\n                        <option ");


#line 49 "AddFilm2.cshtml"
                            Write(Model.Genre == 5 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"6\">6</option>\r\n                        <option ");


#line 50 "AddFilm2.cshtml"
                            Write(Model.Genre == 6 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"6\">7</option>\r\n                        <option ");


#line 51 "AddFilm2.cshtml"
                            Write(Model.Genre == 7 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"7\">8</option>\r\n                        <option ");


#line 52 "AddFilm2.cshtml"
                            Write(Model.Genre == 8 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"8\">9</option>\r\n                        <option ");


#line 53 "AddFilm2.cshtml"
                            Write(Model.Genre == 9 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"9\">10</option>\r\n                    </select>\r\n                    <div");

WriteLiteral(" class=\"editor-label\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"\"");

WriteLiteral(">Rating</label>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"editor-field\"");

WriteLiteral(">\r\n                        <select");

WriteLiteral(" id=\"Rating\"");

WriteLiteral(" name=\"Rating\"");

WriteLiteral(">\r\n                            <option ");


#line 60 "AddFilm2.cshtml"
                                Write(Model.Rating == 0 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"0\">1</option>\r\n                            <option ");


#line 61 "AddFilm2.cshtml"
                                Write(Model.Rating == 1 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"1\">2</option>\r\n                            <option ");


#line 62 "AddFilm2.cshtml"
                                Write(Model.Rating == 2 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"2\">3</option>\r\n                            <option ");


#line 63 "AddFilm2.cshtml"
                                Write(Model.Rating == 3 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"3\">4</option>\r\n                            <option ");


#line 64 "AddFilm2.cshtml"
                                Write(Model.Rating == 4 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"4\">5</option>\r\n                            <option ");


#line 65 "AddFilm2.cshtml"
                                Write(Model.Rating == 5 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"6\">6</option>\r\n                            <option ");


#line 66 "AddFilm2.cshtml"
                                Write(Model.Rating == 6 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"6\">7</option>\r\n                            <option ");


#line 67 "AddFilm2.cshtml"
                                Write(Model.Rating == 7 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"7\">8</option>\r\n                            <option ");


#line 68 "AddFilm2.cshtml"
                                Write(Model.Rating == 8 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"8\">9</option>\r\n                            <option ");


#line 69 "AddFilm2.cshtml"
                                Write(Model.Rating == 9 ? "selected" : "");


#line default
#line hidden
WriteLiteral(" value=\"9\">10</option>\r\n                        </select>\r\n                      " +
"  <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteAttribute ("onclick", " onclick=\"", "\""
, Tuple.Create<string,object,bool> ("", "location.href=\'", true)

#line 71 "AddFilm2.cshtml"
                                                       , Tuple.Create<string,object,bool> ("", Url.Action("SaveFilm", new { Name = @Model.Name, Genre = @Model.Genre, Rating = @Model.Rating })

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\'", true)
);
WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></span>&nbsp;SAVe</button>\r\n            </fieldset>\r\n            <div");

WriteLiteral(" data-role=\"footer\"");

WriteLiteral(" data-id=\"foo1\"");

WriteLiteral(" data-position=\"fixed\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" data-role=\"navbar\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteAttribute ("onclick", " onclick=\"", "\""
, Tuple.Create<string,object,bool> ("", "location.href=\'", true)

#line 75 "AddFilm2.cshtml"
                                                   , Tuple.Create<string,object,bool> ("", Url.Action("ShowFilmList")

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\'", true)
);
WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></span>&nbsp;BAck</button>\r\n                </div>\r\n            </div>\r\n        " +
"</form>\r\n</body>\r\n</html>\r\n");

}
}
}
#pragma warning restore 1591