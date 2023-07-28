#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Lable\Form.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e25171a32994d4522861ca16dcc35c443e69f785"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ContentManage_Views_Lable_Form), @"mvc.1.0.view", @"/Areas/ContentManage/Views/Lable/Form.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e25171a32994d4522861ca16dcc35c443e69f785", @"/Areas/ContentManage/Views/Lable/Form.cshtml")]
    public class Areas_ContentManage_Views_Lable_Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Lable\Form.cshtml"
  
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
#line 27 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Lable\Form.cshtml"
                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Lable/GetFormJson',
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

            $(""#F_ParentId"").bindSelect({
                url: """);
#nullable restore
#line 43 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Lable\Form.cshtml"
                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Lable/GetTreeSelectJson"",
            });
       }

       //监听提交
       form.on('submit(saveBtn)', function (data) {
           // 单击之后提交按钮不可选,防止重复提交
           $('.site-demo-active').addClass('layui-btn-disabled');
           $('.site-demo-active').attr('disabled', 'disabled');
           var postData = data.field;
           if (!postData[""F_EnabledMark""]) postData[""F_EnabledMark""] = false;
           common.submitForm({
               url: '");
#nullable restore
#line 55 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Lable\Form.cshtml"
                 Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Lable/SubmitForm?keyValue=' + keyValue,
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e25171a32994d4522861ca16dcc35c443e69f7855622", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">
            <div class=""layui-form layuimini-form"" lay-filter=""adminform"">
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">上级</label>
                    <div class=""layui-input-block"">
                        <select id=""F_ParentId"" name=""F_ParentId"" lay-verify=""required"" lay-search>
                            <option value=""0"" selected>父节点</option>
                        </select>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">名称</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_Name"" name=""F_Name"" autocomplete=""off"" lay-verify=""required"" placeholder=""请输入"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-ite");
                WriteLiteral(@"m layui-hide"">
                    <label class=""layui-form-label required"">排序</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_Order"" name=""F_Order"" autocomplete=""off"" lay-verify=""required"" placeholder=""请输入"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">选项</label>
                    <div class=""layui-input-block"">
                        <input type=""checkbox"" name=""F_EnabledMark"" id=""F_EnabledMark""");
                BeginWriteAttribute("checked", " checked=\"", 3845, "\"", 3855, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""true"" title=""有效"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <button class=""layui-btn site-demo-active"" lay-submit id=""submit"" lay-filter=""saveBtn"">确认保存</button>
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
