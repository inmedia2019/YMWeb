#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cc9d1aec8c91ccdf6e6113b8e4c5c6513788b94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_InfoManage_Views_Commentdzinfo_Index), @"mvc.1.0.view", @"/Areas/InfoManage/Views/Commentdzinfo/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cc9d1aec8c91ccdf6e6113b8e4c5c6513788b94", @"/Areas/InfoManage/Views/Commentdzinfo/Index.cshtml")]
    public class Areas_InfoManage_Views_Commentdzinfo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Index.cshtml";
 

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <div class=""layuimini-container"">
     <div class=""layuimini-main"">
         <fieldset class=""table-search-fieldset"">
             <div>
                 <form class=""layui-form layui-form-pane"" >
                     <div class=""layui-form-item"">
                         <div class=""layui-inline"">
                             <label class=""layui-form-label"">关键字:</label>
                             <div class=""layui-input-inline"">
                                 <input type=""text"" id=""txt_keyword"" name=""txt_keyword"" autocomplete=""off"" class=""layui-input"" >
                             </div>
                         </div>
                        <div class=""layui-inline""> 
                             <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon"">&#xe615;</i> 搜 索</button>
                         </div>
                     </div>
                 </form>
             </div>
         </fieldset>
         <script t");
            WriteLiteral(@"ype=""text/html"" id=""toolbarDemo"">
             <div class=""layui-btn-container"" id=""toolbar"">
                 <button id=""NF-delete"" authorize class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn layui-hide"" lay-event=""delete""> <i class=""layui-icon"">&#xe640;</i>删除</button>
                 <button id=""NF-details"" authorize class=""layui-btn layui-btn-sm layui-btn-normal data-info-btn layui-hide"" lay-event=""details""> <i class=""layui-icon"">&#xe60b;</i>查看</button>
             </div>
         </script>
         <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>
     </div>
 </div>
 <script>
     layui.use(['jquery', 'form','table','commonTable', 'common','optimizeSelectOption'], function () {
         var $ = layui.jquery,
             form = layui.form,
             table = layui.table,commonTable = layui.commonTable
             common = layui.common;
         var entity;
         //权限控制(js是值传递)
         toolbarDemo.innerHTML = common.authorizeButt");
            WriteLiteral("onNew(toolbarDemo.innerHTML);\r\n         commonTable.rendertable({\r\n             elem: \'#currentTableId\',\r\n             id: \'currentTableId\',\r\n             url: \'");
#nullable restore
#line 45 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml"
               Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/InfoManage/Commentdzinfo/GetGridJson',
             cols: [[
                 { type: ""checkbox"", width: 50 },
                 //此处需修改
                 { field: 'commentId', title: 'commentId', width: 120, sort: true },
                 { field: 'createDate', title: 'createDate', width: 120, sort: true },
                 { field: 'infoId', title: 'infoId', width: 120, sort: true },
                 { field: 'mid', title: 'mid', width: 120, sort: true },
                 { field: 'morecol', title: 'morecol', width: 120, sort: true },
                 { field: 'morecol1', title: 'morecol1', width: 120, sort: true },
                 { field: 'state', title: 'state', minWidth: 120, sort: true },
             ]]
         });
         // 监听搜索操作
         form.on('submit(data-search-btn)', function (data) {
             //执行搜索重载
             commonTable.reloadtable({
                 elem: 'currentTableId',
                 curr: 1,
                 where: { keyword: data.field.txt_keyword}
  ");
            WriteLiteral(@"           });
             entity = null;
             return false;
         });
         wcLoading.close();
         table.on('row(currentTableFilter)', function (obj) {
             obj.tr.find(""div.layui-unselect.layui-form-checkbox"")[0].click();
             entity = obj;
         })
         //toolbar监听事件
         table.on('toolbar(currentTableFilter)', function (obj) { 
             if (obj.event === 'add') {  // 监听添加操作
                 common.modalOpen({
                     title: ""添加界面"",
                     url: """);
#nullable restore
#line 79 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/InfoManage/Commentdzinfo/Form"",
                     width: ""500px"",
                     height: ""500px"",
                 });
             } 
             else if (obj.event === 'delete') {
                 var entity = table.checkStatus('currentTableId').data;
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
#line 95 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/InfoManage/Commentdzinfo/DeleteForm"",
                     param: { keyValue: ids.join(',') },
                     success: function () {
                         common.reload('data-search-btn');
                         entity = null;
                   }
               });
           }
           else if (obj.event === 'edit') {
                 var entity = table.checkStatus('currentTableId').data;
                if (entity.length == 0) {
                   common.modalMsg(""未选中数据"", ""warning"");
                   return false;
                }
                if (entity.length > 1) {
                   common.modalMsg(""只能选择一条编辑"", ""warning"");
                   return false;
                 }
               common.modalOpen({
                  title: ""编辑界面"",
                   url: """);
#nullable restore
#line 115 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/InfoManage/Commentdzinfo/Form?keyValue="" + entity.data.Id,
                   width: ""500px"",
                   height: ""500px"",
               });
           }
           else if (obj.event === 'details') {
                 var entity = table.checkStatus('currentTableId').data;
                if (entity.length == 0) {
                   common.modalMsg(""未选中数据"", ""warning"");
                   return false;
                 }
                if (entity.length > 1) {
                   common.modalMsg(""只能选择一条查看"", ""warning"");
                   return false;
                 }
               common.modalOpen({
                  title: ""查看界面"",
                   url: """);
#nullable restore
#line 132 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\InfoManage\Views\Commentdzinfo\Index.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral("/InfoManage/Commentdzinfo/Details?keyValue=\" + entity.data.Id,\r\n                   width: \"500px\",\r\n                   height: \"500px\",\r\n                  btn: []\r\n               });\r\n           }\r\n           return false;\r\n       });\r\n   });\r\n</script>\r\n");
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
