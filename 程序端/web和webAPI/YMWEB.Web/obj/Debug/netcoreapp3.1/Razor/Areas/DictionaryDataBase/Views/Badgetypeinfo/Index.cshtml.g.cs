#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90d9a98e4e7503e30373d35be93929ec60c5b505"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_DictionaryDataBase_Views_Badgetypeinfo_Index), @"mvc.1.0.view", @"/Areas/DictionaryDataBase/Views/Badgetypeinfo/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90d9a98e4e7503e30373d35be93929ec60c5b505", @"/Areas/DictionaryDataBase/Views/Badgetypeinfo/Index.cshtml")]
    public class Areas_DictionaryDataBase_Views_Badgetypeinfo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml"
  
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
                 <button id=""NF-add"" authorize class=""layui-btn layui-btn-sm data-add-btn layui-hide"" lay-event=""add""><i class=""layui-icon"">&#xe654;</i>新增</button>
                 <button id=""NF-edit"" authorize class=""layui-btn layui-btn-sm layui-btn-warm data-edit-btn layui-hide"" lay-event=""edit""><i class=""layui-icon"">&#xe642;</i>修改</button>
                 <button id=""NF-delete"" authorize class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn layui-hide"" lay-event=""delete""> <i class=""layui-icon"">&#xe640;</i>删除</button>
                
             </div>
         </script>
         <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>
     </div>
 </div>
 <script>
     layui.use(['jquery', 'form','table','commonTable', 'common','optimizeSelectOption'], function () {
         var $ = layui.jquery,
             form = layui.form,
             table = layui.ta");
            WriteLiteral(@"ble,commonTable = layui.commonTable
             common = layui.common;
         var entity;
         //权限控制(js是值传递)
         toolbarDemo.innerHTML = common.authorizeButtonNew(toolbarDemo.innerHTML);
         commonTable.rendertable({
             elem: '#currentTableId',
             id: 'currentTableId',
             url: '");
#nullable restore
#line 47 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml"
               Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Badgetypeinfo/GetGridJson',
             cols: [[
                 { type: ""checkbox"", width: 50 },
                 //此处需修改
                 { field: 'F_Name', title: '名称', width: 120, sort: true },
                 {
                     field: 'F_tagId', title: '徽章种类', width: 120, templet: function (d) {
                         if (d.F_tagId == 1) {
                             return ""<span class='layui-btn layui-btn-normal layui-btn-xs'>积分徽章</span>"";
                         }
                         else if (d.F_tagId == 2) {
                             return ""<span class='layui-btn layui-btn-sm layui-btn-xs'>分类徽章</span>"";
                         }else {
                             return ""<span class='layui-btn layui-btn-warm layui-btn-xs'>其他徽章</span>"";
                         }
                     }
                 },
                 { field: 'F_FirstScore', title: '首次积分', width: 120, sort: true },
                 { field: 'F_OneScore', title: '每次积分', w");
            WriteLiteral(@"idth: 120, sort: true },

                 { field: 'F_CreatorTime', title: '创建时间', width: 120, sort: true },
                 //{ field: 'F_CreatorUserId', title: 'F_CreatorUserId', width: 120, sort: true },
                 //{ field: 'F_EnabledMark', title: 'F_EnabledMark', width: 120, sort: true },

                 //{ field: 'F_Introduction', title: 'F_Introduction', width: 120, sort: true },


                 //{ field: 'F_Order', title: 'F_Order', minWidth: 120, sort: true },
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
         wcLoading.close();
         table.on('row(currentTableFilter)', function (obj) {
             obj.tr.");
            WriteLiteral("find(\"div.layui-unselect.layui-form-checkbox\")[0].click();\r\n             entity = obj;\r\n         })\r\n         //toolbar监听事件\r\n         table.on(\'toolbar(currentTableFilter)\', function (obj) {\r\n             if (obj.event === \'add\') {  // 监听添加操作\r\n");
            WriteLiteral("                 common.openNewTabByIframe({\r\n                     title: \"添加徽章类型\",\r\n                     href: \"");
#nullable restore
#line 110 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml"
                        Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Badgetypeinfo/Form?event=add""
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
#line 124 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Badgetypeinfo/DeleteForm"",
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
              common.openNewTabByIframe({
                  title: ""编辑徽章类型"",
                  href: """);
#nullable restore
#line 144 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral("/DictionaryDataBase/Badgetypeinfo/Form?event=edit&keyValue=\" + entity[0].F_Id\r\n               });\r\n");
            WriteLiteral(@"           }
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
#line 165 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Index.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Badgetypeinfo/Details?keyValue="" + entity.data.F_Id,
                   width: ""500px"",
                   height: ""500px"",
                  btn: []
               });
           }
           return false;
       });
   });
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
