#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\ModuleFields\CloneFields.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b534b00c0c903f5ead879797a35a765b39a0322"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemManage_Views_ModuleFields_CloneFields), @"mvc.1.0.view", @"/Areas/SystemManage/Views/ModuleFields/CloneFields.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b534b00c0c903f5ead879797a35a765b39a0322", @"/Areas/SystemManage/Views/ModuleFields/CloneFields.cshtml")]
    public class Areas_SystemManage_Views_ModuleFields_CloneFields : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\ModuleFields\CloneFields.cshtml"
  
    ViewBag.Title = "CloneFields";
    Layout = "~/Views/Shared/_Form.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
    layui.use(['jquery', 'form', 'laydate', 'common', 'dtree', 'optimizeSelectOption'], function () {
        var form = layui.form,
            $ = layui.$,
            dtree = layui.dtree,
            common = layui.common;
        var moduleId = $.request(""moduleId"");
        wcLoading.close();
        //$(function () {
        //    $(""#itemTree"").treeview({
        //        showcheck: true,
        //        url: ""~/SystemManage/ModuleButton/GetCloneButtonTreeJson""
        //    });
        //});
        var DemoTree = dtree.render({
            elem: ""#demoTree"",
            width: '250px',
            method: ""GET"",
            async: false,
            checkbar: true,
            line: true,  // 显示树线
            initLevel: 0,
            icon: ""-1"", // 隐藏二级图标
            scroll: ""#toolbarDiv"", // 绑定div元素
            url: """);
#nullable restore
#line 29 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\ModuleFields\CloneFields.cshtml"
              Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemManage/ModuleFields/GetCloneFieldsTreeJson?v="" + new Date().Format(""yyyy-MM-dd hh:mm:ss""),
        });
        //监听提交
        var lock = false;
        form.on('submit(saveBtn)', function (data) {
            if (!lock) {
                var params = dtree.getCheckbarNodesParam(""demoTree"");
                var Ids = [];
                for (var i = 0; i < params.length; i++) {
                    Ids.push(params[i].nodeId);
                }
                if (Ids.length == 0) {
                    common.modalMsg(""请选择字段"",'warning');
                    return false;
                }
                common.submitForm({
                    url: """);
#nullable restore
#line 45 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemManage\Views\ModuleFields\CloneFields.cshtml"
                      Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemManage/ModuleFields/SubmitCloneFields"",
                    param: { moduleId: moduleId, Ids: String(Ids) },
                    success: function () {
                        common.parentreload(""data-search-btn"");
                    }
                })
            }
            return false;
        });
    });
    </script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b534b00c0c903f5ead879797a35a765b39a03225427", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">
            <div class=""layui-form layuimini-form"" style=""padding-bottom: 50px;"" lay-filter=""adminform"">
                <div style=""height: 350px;overflow: auto;"" id=""toolbarDiv"">
                    <ul id=""demoTree"" class=""dtree"" data-id=""0""></ul>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <button class=""layui-btn"" lay-submit id=""submit"" lay-filter=""saveBtn"">确认保存</button>
                </div>
            </div>
        </div>
    </div>
");
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
            WriteLiteral("\r\n");
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
