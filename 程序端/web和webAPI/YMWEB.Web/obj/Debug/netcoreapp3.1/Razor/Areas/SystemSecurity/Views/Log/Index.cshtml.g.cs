#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\Log\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d80dd8da8dd9392b4c53f817d7a82da050697f19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemSecurity_Views_Log_Index), @"mvc.1.0.view", @"/Areas/SystemSecurity/Views/Log/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d80dd8da8dd9392b4c53f817d7a82da050697f19", @"/Areas/SystemSecurity/Views/Log/Index.cshtml")]
    public class Areas_SystemSecurity_Views_Log_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\Log\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Index.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d80dd8da8dd9392b4c53f817d7a82da050697f193015", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d80dd8da8dd9392b4c53f817d7a82da050697f194252", async() => {
                WriteLiteral("\r\n    <div class=\"layuimini-container\">\r\n        <div class=\"layuimini-main\">\r\n\r\n            <fieldset class=\"table-search-fieldset\">\r\n");
                WriteLiteral("                <div>\r\n                    <form class=\"layui-form layui-form-pane\"");
                BeginWriteAttribute("action", " action=\"", 650, "\"", 659, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""layui-form-item"">
                            <div class=""layui-inline"">
                                <label class=""layui-form-label required"">日期:</label>
                                <div class=""layui-input-block"">
                                    <select id=""time_horizon"" name=""time_horizon"" lay-verify=""required"">
                                        <option value=""1"">今天</option>
                                        <option value=""2"" selected>近7天</option>
                                        <option value=""3"">近1个月</option>
                                        <option value=""4"">近2个月</option>
                                    </select>
                                </div>
                            </div>
                            <div class=""layui-inline"">
                                <label class=""layui-form-label"">关键字:</label>
                                <div class=""layui-input-inline"">
                                ");
                WriteLiteral("    <input type=\"text\" id=\"txt_keyword\" name=\"txt_keyword\" autocomplete=\"off\" class=\"layui-input\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1781, "\"", 1795, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </div>
                            </div>
                            <div class=""layui-inline"">
                                <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon""></i> 搜 索</button>
                            </div>
                        </div>
                    </form>
                </div>
            </fieldset>

            <script type=""text/html"" id=""toolbarDemo"">
                <div class=""layui-btn-container"" id=""toolbar"">
                    <button id=""NF-removelog"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn layui-hide"" lay-event=""add""><i class=""layui-icon"">&#xe640;</i>清空日志</button>
                </div>
            </script>
            <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>
        </div>
    </div>
    <script>
        layui.use(['jquery', 'form', 'table', 'common', 'o");
                WriteLiteral(@"ptimizeSelectOption', 'commonTable'], function () {
            var $ = layui.jquery,
                form = layui.form,
                table = layui.table,
                commonTable = layui.commonTable,
                common = layui.common;
            //加载数据
            wcLoading.close();
            //权限控制(js是值传递)
            toolbarDemo.innerHTML = common.authorizeButtonNew(toolbarDemo.innerHTML);
            commonTable.rendertable({
                elem: '#currentTableId',
                id: 'currentTableId',
                url: '");
#nullable restore
#line 70 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\Log\Index.cshtml"
                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/SystemSecurity/Log/GetGridJson',
                cols: [[
                    { field: 'F_Account', title: '账户', width: 100, sort: true },
                    { field: 'F_NickName', title: '姓名', width: 100, sort: true },
                    { field: 'F_ModuleName', title: '操作菜单', width: 220, sort: true },
                    {
                        field: 'F_Type', title: '操作类型', width: 120, sort: true,
                        templet: function (d) {
                            return top.clients.dataItems[""DbLogType""][d.F_Type] == undefined ? """" : top.clients.dataItems[""DbLogType""][d.F_Type]
                        }
                    },
                    {
                        field: 'F_IPAddress', title: 'IP地址', width: 200,
                        templet: function (d) {
                            return d.F_IPAddress + "";"" + d.F_IPAddressName;
                        }, sort: true
                    },
                    { field: 'F_KeyValue', title: '操作对象', width: 300, hide:");
                WriteLiteral(@" true },
                    {
                        field: 'F_CreatorTime', title: '创建时间', width: 180,
                        templet: function (d) {
                            if (d.F_CreatorTime) {
                                return new Date(d.F_CreatorTime).Format(""yyyy-MM-dd hh:mm:ss"");

                            }
                            return '';
                        }
                    },
                    { field: 'F_Description', title: '备注', minWidth: 250 },
                ]]
            });
            //select验证
            form.verify({
                required: function (value, item) {
                    var msg = ""必填项不能为空"";
                    value = $.trim(value);
                    var isEmpty = !value || value.length < 1;
                    // 当前验证元素是select且为空时,将页面定位至layui渲染的select处，或自定义想定位的位置
                    if (item.tagName == 'SELECT' && isEmpty) {
                        $(""html"").animate({
                            scrollTop: $(it");
                WriteLiteral(@"em).siblings("".layui-form-select"").offset().top - 74
                        }, 50);
                    }
                    if (isEmpty) {
                        return msg;
                    }
                }
            });
            // 监听搜索操作
            form.on('submit(data-search-btn)', function (data) {
                var queryJson = JSON.stringify(data.field);
                //执行搜索重载
                commonTable.reloadtable({
                    elem: 'currentTableId',
                    curr: 1,
                    where: { timetype: data.field.time_horizon, keyword: data.field.txt_keyword }
                });
                return false;
            });

            /**
             * toolbar监听事件
             */
            table.on('toolbar(currentTableFilter)', function (obj) {
                if (obj.event === 'add') {  // 监听删除操作
                    common.modalOpen({
                        id: ""removelog"",
                        title: ""清空日志"",
         ");
                WriteLiteral("               url: \"");
#nullable restore
#line 138 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\Log\Index.cshtml"
                          Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
                WriteLiteral("/SystemSecurity/Log/RemoveLog\",\r\n                        width: \"300px\",\r\n                        height: \"200px\",\r\n                    });\r\n                }\r\n                return false;\r\n            });\r\n        });\r\n    </script>\r\n\r\n");
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
            WriteLiteral("\r\n</html>");
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
