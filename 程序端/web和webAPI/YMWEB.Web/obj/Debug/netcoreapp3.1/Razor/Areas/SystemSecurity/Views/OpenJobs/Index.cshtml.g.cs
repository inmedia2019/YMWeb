#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2738fec7f5be3143616d37feee3ead28a48d0d8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemSecurity_Views_OpenJobs_Index), @"mvc.1.0.view", @"/Areas/SystemSecurity/Views/OpenJobs/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2738fec7f5be3143616d37feee3ead28a48d0d8a", @"/Areas/SystemSecurity/Views/OpenJobs/Index.cshtml")]
    public class Areas_SystemSecurity_Views_OpenJobs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Index.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
        layui.use(['commonTable', 'form', 'table', 'common', 'optimizeSelectOption'], function () {
            var commonTable = layui.commonTable,
                form = layui.form,
                table = layui.table,
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
#line 18 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemSecurity/OpenJobs/GetGridJson',
                page: false,
                cols: [[
                    { field: 'F_JobName', title: '名称', width: 150 },
                    { field: 'F_JobGroup', title: '组名', width: 150 },
                    { field: 'F_FileName', title: '文件名', minWidth: 200 },
                    { field: 'F_CronExpress', title: 'CRON', width: 180 },
                    {
                        field: 'F_EnabledMark', title: '状态', width: 80, sort: true,
                        templet: function (d) {
                            if (d.F_EnabledMark == true) {
                                return ""<span class='layui-btn layui-btn-normal layui-btn-xs'>有效</span>"";
                            } else {
                                return ""<span class='layui-btn layui-btn-warm layui-btn-xs'>无效</span>"";
                            }
                        }
                    },
                    {
                        field: 'F_LastRunTime', title: '最近执行时间',");
            WriteLiteral(@" width: 180,
                        templet: function (d) {
                            if (d.F_LastRunTime) {
                                var time = new Date(d.F_LastRunTime);
                                return time.Format(""yyyy-MM-dd hh:mm:ss"");
                            }
                            return '';
                        }
                    },
                    {
                        field: 'F_StarRunTime', title: '最近启动时间', width: 180,
                        templet: function (d) {
                            if (d.F_StarRunTime) {
                                var time = new Date(d.F_StarRunTime);
                                return time.Format(""yyyy-MM-dd hh:mm:ss"");
                            }
                            return '';
                        }
                    },
                    {
                        field: 'F_EndRunTime', title: '最近关闭时间', width: 180,
                        templet: function (d) {
                    ");
            WriteLiteral(@"        if (d.F_EndRunTime) {
                                var time = new Date(d.F_EndRunTime);
                                return time.Format(""yyyy-MM-dd hh:mm:ss"");
                            }
                            return '';
                        }
                    },

                    { field: 'F_Description', title: '备注', minWidth: 200 },
                ]]
            });
            // 监听搜索操作
            form.on('submit(data-search-btn)', function (data) {
                //执行搜索重载
                commonTable.reloadtable({
                    elem: 'currentTableId',
                    page: false,
                    curr: 1,
                    where: { keyword: data.field.txt_keyword }
                });
                entity = null;
                return false;
            });
            var entity;
            table.on('row(currentTableFilter)', function (obj) {
                obj.tr.addClass(""layui-table-click"").siblings().removeClass(""layui-tab");
            WriteLiteral(@"le-click"");
                entity = obj;
            })
            /**
             * toolbar监听事件
             */
            table.on('toolbar(currentTableFilter)', function (obj) {
                if (obj.event === 'add') {  // 监听删除操作
                    common.modalOpen({
                        title: ""添加任务"",
                        url: """);
#nullable restore
#line 93 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
                          Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemSecurity/OpenJobs/Form"",
                        width: ""550px"",
                        height: ""500px"",
                    });
                }
                else if (obj.event === 'delete') {
                    if (entity == null) {
                        common.modalMsg(""未选中数据"", ""warning"");
                        return false;
                    }
                    common.deleteForm({
                        url: """);
#nullable restore
#line 104 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
                          Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemSecurity/OpenJobs/DeleteForm"",
                        param: { keyValue: entity.data.F_Id },
                        success: function () {
                            common.reload('data-search-btn');
                        }
                    });
                }
                else if (obj.event === 'edit') {
                    if (entity == null) {
                        common.modalMsg(""未选中数据"", ""warning"");
                        return false;
                    }
                    common.modalOpen({
                        title: ""修改任务"",
                        url: """);
#nullable restore
#line 118 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
                          Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemSecurity/OpenJobs/Form?keyValue="" + entity.data.F_Id,
                        width: ""550px"",
                        height: ""500px"",
                    });
                }
                else if (obj.event === 'disabled') {
                    if (entity == null) {
                        common.modalMsg(""未选中数据"", ""warning"");
                        return false;
                    }
                    if (entity.data.F_EnabledMark!=true) {
                        common.modalMsg(""任务未启动，无法关闭！"", ""warning"");
                        return false;
                    }
                    common.modalConfirm(""注：您确定要【关闭】该项任务吗？"", function (r) {
                        if (r) {
                            common.submitForm({
                                url: """);
#nullable restore
#line 135 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
                                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemSecurity/OpenJobs/ChangeStatus"",
                                param: { keyValue: entity.data.F_Id, status: 0},
                                close: false,
                                success: function () {
                                    common.reload('data-search-btn');
                                }
                            })
                        }
                    });
                }
                else if (obj.event === 'enabled') {
                    if (entity == null) {
                        common.modalMsg(""未选中数据"", ""warning"");
                        return false;
                    }
                    if (entity.data.F_EnabledMark == true) {
                        common.modalMsg(""任务已启动，无法启动！"", ""warning"");
                        return false;
                    }
                    common.modalConfirm(""注：您确定要【启动】该项任务吗？"", function (r) {
                        if (r) {
                            common.submitForm({
                  ");
            WriteLiteral("              url: \"");
#nullable restore
#line 157 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemSecurity\Views\OpenJobs\Index.cshtml"
                                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemSecurity/OpenJobs/ChangeStatus"",
                                param: { keyValue: entity.data.F_Id, status: 1 },
                                close: false,
                                success: function () {
                                    common.reload('data-search-btn');
                                }
                            })
                        }
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
            BeginWriteAttribute("action", " action=\"", 8084, "\"", 8093, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""layui-form-item"">
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">关键字:</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" id=""txt_keyword"" name=""txt_keyword"" autocomplete=""off"" class=""layui-input""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 8461, "\"", 8475, 0);
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
                <button id=""NF-enabled"" authorize=""yes"" class=""layui-btn layui-btn-sm data-enabled-btn layui-hide"" lay-event=""enabled""> <i class=""fa fa-play-circle""></i>启动</button>
                <button id=""NF-disabled"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-danger data-disabled-btn layui-hide"" lay-event=""disabled""><i class=""fa fa-stop-circle""></i>关闭</button>

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
