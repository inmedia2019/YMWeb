#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afb441c48d340c1931c9fe30125738a9ac8d8bf3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ContentManage_Views_Block_Index), @"mvc.1.0.view", @"/Areas/ContentManage/Views/Block/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afb441c48d340c1931c9fe30125738a9ac8d8bf3", @"/Areas/ContentManage/Views/Block/Index.cshtml")]
    public class Areas_ContentManage_Views_Block_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Index.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""layuimini-container"">
    <div class=""layuimini-main"">
        <fieldset class=""table-search-fieldset"">
            <div>
                <form class=""layui-form layui-form-pane"">
                    <div class=""layui-form-item"">
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">关键字:</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" id=""txt_keyword"" name=""txt_keyword"" autocomplete=""off"" class=""layui-input"">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon"">&#xe615;</i> 搜 索</button>
                        </div>
                    </div>
                </form>
            </div>
        </fieldset>
        <script type=""text/html"" id=""to");
            WriteLiteral(@"olbarDemo"">
            <div class=""layui-btn-container"" id=""toolbar"">
                <button id=""NF-add"" authorize class=""layui-btn layui-btn-sm data-add-btn layui-hide"" lay-event=""add""><i class=""layui-icon"">&#xe654;</i>新增</button>
                <button id=""NF-edit"" authorize class=""layui-btn layui-btn-sm layui-btn-warm data-edit-btn layui-hide"" lay-event=""edit""><i class=""layui-icon"">&#xe642;</i>修改</button>
                <button id=""NF-delete"" authorize class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn layui-hide"" lay-event=""delete""> <i class=""layui-icon"">&#xe640;</i>删除</button>
                <button id=""NF-export"" authorize=""yes"" class=""layui-btn layui-btn-sm  data-export-btn layui-hide"" lay-event=""export""> <i class=""fa fa-key""></i>导出</button>
            </div>
        </script>
        <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>
        <script type=""text/html"" id=""currentTableBar"">
            <a id=""NF-edit"" authorize=""yes"" class=""");
            WriteLiteral(@"layui-btn layui-btn-sm"" lay-event=""edit"">修改</a>
            <a id=""NF-delete"" authorize=""yes"" class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn"" lay-event=""delete"">删除</a>
        </script>
    </div>
</div>
<script>
    layui.use(['jquery', 'form', 'treeTable', 'commonTable', 'soulTable', 'common','optimizeSelectOption'], function () {
         var $ = layui.jquery,
             form = layui.form,
             treeTable = layui.treeTable,
        soulTable = layui.soulTable,
            common = layui.common;
        wcLoading.close();
         var entity;
         //权限控制(js是值传递)
         currentTableBar.innerHTML = common.authorizeButtonNew(currentTableBar.innerHTML);
         toolbarDemo.innerHTML = common.authorizeButtonNew(toolbarDemo.innerHTML);
        var rendertree = common.rendertreetable({
             elem: '#currentTableId',
             id: 'currentTableId',
            url: '");
#nullable restore
#line 54 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
              Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/GetTreeGridJson',
            tree: {
                iconIndex: 1,           // 折叠图标显示在第几列
                isPidData: true,        // 是否是id、pid形式数据
                idName: 'F_Id',  // id字段名称
                pidName: 'F_ParentId',     // pid字段名称
                arrowType: 'arrow2',
                getIcon: 'ew-tree-icon-style2',
            },
             cols: [[
                 { type: ""checkbox"", width: 50 },
                 { field: 'F_Id', title: 'ID', width: 250, sort: true },
                 { field: 'F_Name', title: '名称', width: 250, sort: true },
                 //此处需修改
                 {
                     field: 'F_Type', title: '类型',  width: 120, sort: true,
                     templet: function (d) {
                         return top.clients.dataItems[""BlockType""][d.F_Type] == undefined ? """" : top.clients.dataItems[""BlockType""][d.F_Type];
                     }
                 },
                 {
                     field: 'F_ShowType', titl");
            WriteLiteral(@"e: '显示标识', width: 120, sort: true,
                     templet: function (d) {
                         return top.clients.dataItems[""ShowType""][d.F_ShowType] == undefined ? """" : top.clients.dataItems[""ShowType""][d.F_ShowType];
                     }
                 },
                 { field: 'F_Number', title: '数量', width: 120, sort: true },
                 {
                     field: 'F_CreatorTime', title: '添加时间', width: 120, templet: function (d) {
                         if (d.F_CreatorTime) {
                             var time = new Date(d.F_CreatorTime);
                             return time.Format(""yyyy-MM-dd"");
                         }
                         return '';
                     } },
                 {
                     field: 'F_LastModifyTime', title: '更新时间', width: 120, templet: function (d) {
                         if (d.F_LastModifyTime) {
                             var time = new Date(d.F_LastModifyTime);
                             return ");
            WriteLiteral(@"time.Format(""yyyy-MM-dd"");
                         }
                         return '';
                     }},
                 {
                     field: 'F_EnabledMark', title: '状态', width: 120, templet: function (d) {
                         if (d.F_EnabledMark == true) {
                             return ""<span class='layui-btn layui-btn-normal layui-btn-xs'>有效</span>"";
                         } else {
                             return ""<span class='layui-btn layui-btn-warm layui-btn-xs'>无效</span>"";
                         }
                     }
                 },
                 {
                     field: 'F_ImageUrl', title: '图片', width: 200, templet: function(d) {
                         if (d.F_ImageUrl == """") {
                             return """";
                         } else {
                             var imageHtml = '';
                             var result = d.F_ImageUrl.split(',');
                             for (var i in result) {
        ");
            WriteLiteral(@"                         imageHtml += '<a href=""javascript:""><img class=""img-sm img-center"" src=""' + result[i] +'"" onclick=""previewImg(this)""  style=""width: 30px !important;height: 30px !important;""  ></a>';
                             }
                             return imageHtml;
                         }
                     }
                 },
                 { title: '操作', minWidth: 180, toolbar: '#currentTableBar', align: ""center"", fixed: 'right' }

            ]],
            done: function () {
                //展开全部
                rendertree.expandAll();
            }
         });
         // 监听搜索操作
         form.on('submit(data-search-btn)', function (data) {
             var queryJson = data.field.txt_keyword;
             //执行搜索重载
             common.reloadtreetable(rendertree, {
                 where: { keyword: queryJson },
             });
             entity = null;
             return false;
         });
        treeTable.on('row(currentTableId)', function (ob");
            WriteLiteral(@"j) {
             obj.tr.find(""div.layui-unselect.layui-form-checkbox"")[0].click();
             entity = obj;
         })
         //toolbar监听事件
        treeTable.on('toolbar(currentTableId)', function (obj) {
             if (obj.event === 'add') {  // 监听添加操作
                 common.openNewTabByIframe({
                     title: ""添加区块"",
                     href: """);
#nullable restore
#line 147 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
                        Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/Form""
                 });
             }
             else if (obj.event === 'delete') {
                 var entity = rendertree.checkStatus(false);
                 if (entity.length == 0) {
                     common.modalMsg(""未选中数据"", ""warning"");
                     return false;
                 }
                 var ids = [];
                 for (var i = 0; i < entity.length; i++) {
                     ids.push(entity[i].F_Id);
                 }
                 common.deleteForm({
                     url: """);
#nullable restore
#line 161 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/DeleteForm"",
                     param: { keyValue: ids.join(',') },
                     success: function () {
                         common.reload('data-search-btn');
                         entity = null;
                   }
               });
             }
             else if (obj.event === 'export') {
                 var entity = rendertree.checkStatus(false);

                 table.exportFile(rendertree.config.id, entity, 'xls');
             }
           else if (obj.event === 'edit') {
                 var entity = rendertree.checkStatus(false);
                 if (entity.length == 0) {
                     common.modalMsg(""未选中数据"", ""warning"");
                     return false;
                 }
                 if (entity.length > 1) {
                     common.modalMsg(""只能选择一条编辑"", ""warning"");
                     return false;
                 }
                 common.openNewTabByIframe({
                  title: ""编辑区块"",
                  ");
            WriteLiteral("href: \"");
#nullable restore
#line 186 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/Form?event=edit&keyValue="" + entity[0].F_Id
               });
           }
           return false;
         });
                      //toolrow监听事件
        treeTable.on('tool(currentTableId)', function (obj) {
            if (obj.event === 'delete') {
                common.deleteForm({
                    url: """);
#nullable restore
#line 195 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/DeleteForm"",
                    param: { keyValue: obj.data.F_Id },
                    success: function () {
                        obj.del();
                    }
                });
            }
            else if (obj.event === 'edit') {
                common.openNewTabByIframe({
                    title: ""编辑区块"",
                    href: """);
#nullable restore
#line 205 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Index.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/Form?event=edit&keyValue="" + obj.data.F_Id,
                });
            }
            return false;
        });
     });
    function previewImg(obj) {
        var imgHtml = ""<img src='"" + obj.src + ""' />"";
        //弹出层
        layer.open({
            type: 1,
            shade: 0.8,
            offset: 'auto',
            area: ['750px', '600px'],
            shadeClose: true,//点击外围关闭弹窗
            scrollbar: false,//不现实滚动条
            title: ""图片预览"", //不显示标题
            content: imgHtml, //捕获的元素，注意：最好该指定的元素要存放在body最外层，否则可能被其它的相对元素所影响
            cancel: function () {
                //layer.msg('捕获就是从页面已经存在的元素上，包裹layer的结构', { time: 5000, icon: 6 });
            }
        });
    }
</script>
");
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
