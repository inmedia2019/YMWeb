#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a9f90f600b694c463f20fd4ddf55ce34d7bebef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemOrganize_Views_Organize_Index), @"mvc.1.0.view", @"/Areas/SystemOrganize/Views/Organize/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a9f90f600b694c463f20fd4ddf55ce34d7bebef", @"/Areas/SystemOrganize/Views/Organize/Index.cshtml")]
    public class Areas_SystemOrganize_Views_Organize_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Index.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
    layui.use(['jquery', 'form', 'table', 'common', 'treeTable', 'optimizeSelectOption', 'layer'], function () {
        var $ = layui.jquery,
            form = layui.form,
            table = layui.table,
            layer = layui.layer,
            treeTable = layui.treeTable,
            common = layui.common;
        //加载数据
        wcLoading.close();
        //权限控制(js是值传递)
        toolbarDemo.innerHTML = common.authorizeButtonNew(toolbarDemo.innerHTML);
        var rendertree = common.rendertreetable({
            elem: '#currentTableId',
            url: '");
#nullable restore
#line 19 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml"
              Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/Organize/GetTreeGridJson' ,
            cols: [[
                { field: 'F_FullName', title: '名称', width: 250 },
                { field: 'F_EnCode', title: '编号', width: 200 },
                {
                    field: 'F_CategoryId', title: '分类', width: 120,
                    templet: function (d) {
                        return top.clients.dataItems[""OrganizeCategory""][d.F_CategoryId] == null ? """" : top.clients.dataItems[""OrganizeCategory""][d.F_CategoryId];
                    }
                },
                {
                    field: 'F_EnabledMark', title: '状态', width: 80,
                    templet: function (d) {
                        if (d.F_EnabledMark == true) {
                            return ""<span class='layui-btn layui-btn-normal layui-btn-xs'>有效</span>"";
                        } else {
                            return ""<span class='layui-btn layui-btn-warm layui-btn-xs'>无效</span>"";
                        }
                    }
        ");
            WriteLiteral(@"        },
                {
                    field: 'F_CreatorTime', title: '创建时间', width: 120,
                    templet: function (d) {
                        if (d.F_CreatorTime) {
                            var time = new Date(d.F_CreatorTime);
                            return time.Format(""yyyy-MM-dd"");
                        }
                        return '';
                    }
                },
                { field: 'F_Description', title: '备注', minWidth: 150 },
            ]],
            done: function () {
                //展开全部
                rendertree.expandAll();
            }
        });

        // 监听搜索操作
        form.on('submit(data-search-btn)', function (data) {
            queryJson = data.field.txt_keyword;
            common.reloadtreetable(rendertree, {
                where: { keyword: queryJson },
            });
            duty = null;
            return false;
        });
        var duty;
        treeTable.on('row(currentTableId)', ");
            WriteLiteral(@"function (obj) {
            obj.tr.addClass(""layui-table-click"").siblings().removeClass(""layui-table-click"");
            duty = obj;
        })
        /**
         * toolbar监听事件
         */
        treeTable.on('toolbar(currentTableId)', function (obj) {
            if (obj.event === 'add') {  // 监听操作
                keyValue = !!duty ? duty.data.F_Id : null;
                common.modalOpen({
                    title: ""添加机构"",
                    url: """);
#nullable restore
#line 79 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/Organize/Form?event=add&keyValue="" + keyValue,
                    width: ""450px"",
                    height: ""520px"",
                });
            }
            else if (obj.event === 'delete') {
                if (duty == null) {
                    common.modalMsg(""未选中数据"", ""warning"");
                    return false;
                }
                common.deleteForm({
                    url: """);
#nullable restore
#line 90 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/Organize/DeleteForm"",
                    param: { keyValue: duty.data.F_Id },
                    success: function () {
                        common.reload('data-search-btn');
                    }
                });
            }
            else if (obj.event === 'edit') {
                if (duty == null) {
                    common.modalMsg(""未选中数据"", ""warning"");
                    return false;
                }
                common.modalOpen({
                    title: ""编辑机构"",
                    url: """);
#nullable restore
#line 104 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/Organize/Form?event=edit&keyValue="" + duty.data.F_Id,
                    width: ""450px"",
                    height: ""520px"",
                });
            }
            else if (obj.event === 'details') {
                if (duty == null) {
                    common.modalMsg(""未选中数据"", ""warning"");
                    return false;
                }
                common.modalOpen({
                    title: ""查看机构"",
                    url: """);
#nullable restore
#line 116 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\Organize\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/Organize/Details?keyValue="" + duty.data.F_Id,
                    width: ""450px"",
                    height: ""520px"",
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
            BeginWriteAttribute("action", " action=\"", 5449, "\"", 5458, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""layui-form-item"">
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">关键字:</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" id=""txt_keyword"" name=""txt_keyword"" autocomplete=""off"" class=""layui-input""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 5826, "\"", 5840, 0);
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
                <button id=""NF-add"" authorize=""yes"" class=""layui-btn layui-btn-sm data-add-btn layui-hide"" lay-event=""add""><i class=""layui-icon"">&#xe654;</i>新建</button>
                <button id=""NF-edit"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-warm data-edit-btn layui-hide"" lay-event=""edit""><i class=""layui-icon"">&#xe642;</i>修改</button>
                <button id=""NF-delete"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn layui-hide");
            WriteLiteral(@""" lay-event=""delete""> <i class=""layui-icon"">&#xe640;</i>删除</button>
                <button id=""NF-details"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-normal data-info-btn layui-hide"" lay-event=""details""> <i class=""layui-icon"">&#xe60b;</i>查看</button>
            </div>
        </script>

        <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>

    </div>
</div>");
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
