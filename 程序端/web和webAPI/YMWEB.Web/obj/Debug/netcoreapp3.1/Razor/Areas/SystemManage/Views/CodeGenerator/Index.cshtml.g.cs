#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\CodeGenerator\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "199d1441e74cbcbd5e3bd55b272dc98c02e22c5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemManage_Views_CodeGenerator_Index), @"mvc.1.0.view", @"/Areas/SystemManage/Views/CodeGenerator/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"199d1441e74cbcbd5e3bd55b272dc98c02e22c5a", @"/Areas/SystemManage/Views/CodeGenerator/Index.cshtml")]
    public class Areas_SystemManage_Views_CodeGenerator_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\CodeGenerator\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Index.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
    layui.use(['form', 'table', 'common', 'commonTable', 'optimizeSelectOption'], function () {
        var form = layui.form,
            table = layui.table,
            commonTable = layui.commonTable,
            common = layui.common;
        //加载数据
        wcLoading.close();
        //权限控制(js是值传递)
        toolbarDemo.innerHTML = common.authorizeButtonNew(toolbarDemo.innerHTML);
        commonTable.rendertable({
            elem: '#currentTableId',
            url: '");
#nullable restore
#line 17 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\CodeGenerator\Index.cshtml"
              Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemManage/CodeGenerator/GetTablePageListJson',
            sqlkey: 'TableName',//数据库主键
            cols: [[
                { field: 'TableName', title: '表名称', width: 200, sort: true },
                { field: 'TableKeyName', title: '主键名称', width: 100 },
                { field: 'TableKey', title: '主键字段', width: 250 },
                { field: 'TableCount', title: '记录数', width: 80 },
                { field: 'Remark', title: '备注', minWidth: 150 },
            ]]
        });
        // 监听搜索操作
        form.on('submit(data-search-btn)', function (data) {
            //执行搜索重载
            commonTable.reloadtable({
                elem: 'currentTableId',
                curr: 1,
                where: { keyword: data.field.txt_keyword}
            });
            entity = null;
            return false;
        });
        var entity;
        table.on('row(currentTableFilter)', function (obj) {
            obj.tr.addClass(""layui-table-click"").siblings().removeClass(""layui-table-click"");");
            WriteLiteral(@"
            entity = obj;
        })
        /**
         * toolbar监听事件
         */
        table.on('toolbar(currentTableFilter)', function (obj) {
            if (obj.event === 'add') {  // 监听删除操作
                if (entity == null) {
                    common.modalMsg(""未选中数据"", ""warning"");
                    return false;
                }
                common.openNewTabByIframe({
                    title: ""模板代码生成"",
                    href: """);
#nullable restore
#line 54 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\CodeGenerator\Index.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemManage/CodeGenerator/Form?keyValue="" + entity.data.TableName,
                });
            }
            else if (obj.event === 'entitycode') {
                if (entity == null) {
                    common.modalMsg(""未选中数据"", ""warning"");
                    return false;
                }
                common.modalOpen({
                    title: ""实体类生成"",
                    url: """);
#nullable restore
#line 64 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\CodeGenerator\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemManage/CodeGenerator/EntityCode?keyValue="" + entity.data.TableName,
                    width: ""700px"",
                    height: ""600px"",
                });
            }
            else if (obj.event === 'details') {
                if (entity == null) {
                    common.modalMsg(""未选中数据"", ""warning"");
                    return false;
                }
                common.modalOpen({
                    title: ""查看数据表"",
                    url: """);
#nullable restore
#line 76 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\CodeGenerator\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemManage/CodeGenerator/Details?keyValue="" + entity.data.TableName,
                    width: ""700px"",
                    height: ""600px"",
                    btn: []
                });
            }
            return false;
        });
    });
    </script>
<div class=""layuimini-container"">
    <div class=""layuimini-main"">
        <fieldset class=""table-search-fieldset"">
");
            WriteLiteral("            <div>\r\n                <form class=\"layui-form layui-form-pane\"");
            BeginWriteAttribute("action", " action=\"", 3708, "\"", 3717, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""layui-form-item"">
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">表名称:</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" id=""txt_keyword"" name=""txt_keyword"" autocomplete=""off"" class=""layui-input""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 4085, "\"", 4099, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon"">&#xe615;</i> 搜 索</button>
                        </div>
                    </div>
                </form>
            </div>
        </fieldset>

        <script type=""text/html"" id=""toolbarDemo"">
            <div class=""layui-btn-container"" id=""toolbar"">
                <button id=""NF-add"" authorize=""yes"" class=""layui-btn layui-btn-sm data-add-btn layui-hide"" lay-event=""add""><i class=""layui-icon"">&#xe654;</i>模板生成</button>
                <button id=""NF-entitycode"" authorize=""yes"" class=""layui-btn layui-btn-sm data-add-btn layui-hide"" lay-event=""entitycode""><i class=""layui-icon"">&#xe654;</i>实体生成</button>
                <button id=""NF-details"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-normal data-info-btn layui-hide""");
            WriteLiteral(" lay-event=\"details\"> <i class=\"layui-icon\">&#xe60b;</i>查看</button>\r\n            </div>\r\n        </script>\r\n\r\n        <table class=\"layui-hide\" id=\"currentTableId\" lay-filter=\"currentTableFilter\"></table>\r\n\r\n    </div>\r\n</div>");
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
