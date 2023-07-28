#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd512a601bba5fa80d79f3edfa026137a220378b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ContentManage_Views_Block_Details), @"mvc.1.0.view", @"/Areas/ContentManage/Views/Block/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd512a601bba5fa80d79f3edfa026137a220378b", @"/Areas/ContentManage/Views/Block/Details.cshtml")]
    public class Areas_ContentManage_Views_Block_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Details.cshtml"
  
    ViewBag.Title = "Details"; 
    Layout = "~/Views/Shared/_Form.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    layui.use(['jquery', 'form', 'laydate', 'common'], function () {
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
            common.ajax({
                url: '");
#nullable restore
#line 26 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Block\Details.cshtml"
                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/ContentManage/Block/GetFormJson',
                dataType: 'json',
                data: { keyValue: keyValue },
                async: false,
                success: function (data) {
                    common.val('adminform', data);
                    common.setReadOnly('adminform');
                    form.render();
                 }
            });
       });
       wcLoading.close();

       function initControl() {
           //此处需修改
           //绑定数据源
           //类型为下拉框时
       }
   });
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd512a601bba5fa80d79f3edfa026137a220378b4330", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">
            <div class=""layui-form layuimini-form"" lay-filter=""adminform"">
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">上级区块</label>
                    <div class=""layui-input-block"">
                        <select id=""F_ParentId"" name=""F_ParentId"" lay-verify=""required"" lay-search>
                            <option value=""0"" selected>父节点</option>
                        </select>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">类型</label>
                    <div class=""layui-input-block"">
                        <select id=""F_Type"" name=""F_Type"" lay-verify=""required"" lay-search>
                            <option value=""0"">==请选择==</option>
                        </select>
                    </div>
                </div>");
                WriteLiteral(@"
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">名称</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_Name"" name=""F_Name"" lay-verify=""required"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">数量</label>
                    <div class=""layui-input-block"">
                        <input type=""number"" pattern=""[0-9]*"" id=""F_Number"" name=""F_Number"" lay-verify=""required|number"" oninput=""if(value.length>8)value=value.slice(0,8)"" class=""layui-input "">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">图片</label>
                    <div class=""layui-input-block"" style=""padding-right: 110px;"">
                        <input type=""");
                WriteLiteral(@"text"" class=""layui-input"" name=""F_ImageUrl"" id=""F_ImageUrl"" maxlength=""255"" readonly=""readonly"">
                        <button type=""button"" class=""layui-btn"" style=""position: absolute;top: 0;right: 0;cursor: pointer;"" id=""j_upload_img_btn"">
                            <i class=""layui-icon""></i>上传图片
                        </button>
                        <ul id=""upload_img_wrap""></ul>
                        <textarea id=""uploadEditor"" style=""display: none;""></textarea>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"" id=""imgshow"">
                    <label class=""layui-form-label""></label>
                    <div class=""layui-input-block"">
                        <img id=""F_ImgUrlPic"" width=""200"" height=""200"" onclick=""previewImg(this)"" />
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">链接</label>
                    <div ");
                WriteLiteral(@"class=""layui-input-block"">
                        <input type=""text"" id=""F_LinkUrl"" name=""F_LinkUrl"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">内容</label>
                    <div class=""layui-input-block"">
                        <textarea id=""F_Content"" name=""F_Content"" type=""text/plain"" style=""width:100%;height:400px;""></textarea>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">选项</label>
                    <div class=""layui-input-block"">
                        <input type=""checkbox"" name=""F_EnabledMark"" id=""F_EnabledMark""");
                BeginWriteAttribute("checked", " checked=\"", 5213, "\"", 5223, 0);
                EndWriteAttribute();
                WriteLiteral(" value=\"true\" title=\"有效\">\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
