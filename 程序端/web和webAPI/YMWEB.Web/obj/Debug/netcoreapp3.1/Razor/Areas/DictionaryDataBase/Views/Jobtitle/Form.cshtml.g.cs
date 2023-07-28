#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Jobtitle\Form.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b6961f06dcc07e96c667b358ca209b4a30c5228"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_DictionaryDataBase_Views_Jobtitle_Form), @"mvc.1.0.view", @"/Areas/DictionaryDataBase/Views/Jobtitle/Form.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b6961f06dcc07e96c667b358ca209b4a30c5228", @"/Areas/DictionaryDataBase/Views/Jobtitle/Form.cshtml")]
    public class Areas_DictionaryDataBase_Views_Jobtitle_Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Jobtitle\Form.cshtml"
  
    ViewBag.Title = "Form"; 
    Layout = "~/Views/Shared/_Form.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    layui.use(['jquery', 'form', 'laydate', 'common','optimizeSelectOption'], function () {
        var form = layui.form,
            $ = layui.$,
            common = layui.common,
            laydate = layui.laydate;
        var keyValue = $.request(""keyValue"");
        //权限字段
        common.authorizeFields('adminform');
        //此处需修改
        //类型为时间时
        //laydate.render({
            //elem: '#F_Birthday'
            //, btns: ['clear', 'now']
            //, trigger: 'click',
            //format: 'yyyy-MM-dd',
        //});

        $(function () {
            initControl();
            if (!!keyValue) {
                 common.ajax({
                   url: '");
#nullable restore
#line 27 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Jobtitle\Form.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Jobtitle/GetFormJson',
                   dataType: 'json',
                   data: { keyValue: keyValue },
                   async: false,
                   success: function (data) {
                       common.val('adminform', data);
                    }
               });
           }
           form.render();
       });
       wcLoading.close();

       function initControl() {
           //此处需修改
           //绑定数据源
           //类型为下拉框时
       }

       //监听提交
       form.on('submit(saveBtn)', function (data) {
           // 单击之后提交按钮不可选,防止重复提交
           $('.site-demo-active').addClass('layui-btn-disabled');
           $('.site-demo-active').attr('disabled', 'disabled');
           var postData = data.field;
           common.submitForm({
               url: '");
#nullable restore
#line 53 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Jobtitle\Form.cshtml"
                 Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Jobtitle/SubmitForm?keyValue=' + keyValue,
               param: postData,
               success: function () {
                   common.parentreload('data-search-btn');
               }
           })
           return false;
       });
   });
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b6961f06dcc07e96c667b358ca209b4a30c52285278", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">
            <div class=""layui-form layuimini-form"" lay-filter=""adminform"">
                <div class=""layui-form-item layui-hide"">
                   <label class=""layui-form-label required"">职称 </label>
                   <div class=""layui-input-block"">
                        <input type=""text"" id=""F_Name"" name=""F_Name"" autocomplete=""off"" lay-verify=""required"" placeholder=""请输入"" class=""layui-input"">
                   </div>
               </div>
                <div class=""layui-form-item layui-hide"">
                   <label class=""layui-form-label"">简介</label>
                   <div class=""layui-input-block"">
                       <textarea id=""F_Introduction"" name=""F_Introduction"" type=""text/plain"" style=""width:100%;height:200px;""></textarea>
                   </div>
               </div>
                <div class=""layui-form-item layui-hide"">
                    <button class=""layui-btn site-demo-active"" lay");
                WriteLiteral("-submit id=\"submit\" lay-filter=\"saveBtn\">确认保存</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n\r\n");
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
