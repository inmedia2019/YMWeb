#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c59ab09aff56a82cbf8579fa6359ce21a46aab92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_DictionaryDataBase_Views_Badgetypeinfo_Form), @"mvc.1.0.view", @"/Areas/DictionaryDataBase/Views/Badgetypeinfo/Form.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c59ab09aff56a82cbf8579fa6359ce21a46aab92", @"/Areas/DictionaryDataBase/Views/Badgetypeinfo/Form.cshtml")]
    public class Areas_DictionaryDataBase_Views_Badgetypeinfo_Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/lang/zh-cn/zh-cn.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml"
  
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
#line 27 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml"
                     Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Badgetypeinfo/GetFormJson',
                   dataType: 'json',
                   data: { keyValue: keyValue },
                   async: false,
                   success: function (data) {
                       common.val('adminform', data);
                    }
               });
            }

            var F_tagId = $(""#F_tagId"").val();
           
            if (F_tagId == 2) {
                $("".score"").hide();
            }
            else {
                $("".score"").show();
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
           c");
            WriteLiteral("ommon.submitForm({\r\n               url: \'");
#nullable restore
#line 64 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml"
                 Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/DictionaryDataBase/Badgetypeinfo/SubmitForm?keyValue=' + keyValue,
               param: postData,
               success: function () {
                   common.parentreload('data-search-btn');
               }
           })
           return false;
       });

        form.on('select(F_tagId)', function (data) {
            if (data.value == 2) {
                $("".score"").hide();
            }
            else {
                $("".score"").show();
            }
        });

   });
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59ab09aff56a82cbf8579fa6359ce21a46aab927414", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">
            <div class=""layui-form layuimini-form"" lay-filter=""adminform"">
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">分类名称</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_Name"" name=""F_Name"" autocomplete=""off"" lay-verify=""required"" placeholder=""请输入"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">徽章种类</label>
                    <div class=""layui-input-block"">
                        <select id=""F_tagId"" name=""F_tagId"" lay-filter=""F_tagId"" lay-search>
                            <option value=""1"">积分徽章</option>
                            <option value=""2"">类型徽章</option>
                            <option value=""3"">签到徽章</option>
                           ");
                WriteLiteral(@" <option value=""4"">留言徽章</option>
                        </select>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide score"">
                    <label class=""layui-form-label required"">首次积分数</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_FirstScore"" name=""F_FirstScore"" value=""0"" autocomplete=""off"" lay-verify=""required"" placeholder=""请输入"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide score"">
                    <label class=""layui-form-label required"">每次积分数</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_OneScore"" name=""F_OneScore"" autocomplete=""off"" value=""0"" lay-verify=""required"" placeholder=""请输入"" class=""layui-input"">
                    </div>
                </div>
                
                <div class=""layui-form-item layui-hide""");
                WriteLiteral(@">
                    <label class=""layui-form-label"">简介</label>
                    <div class=""layui-input-block"">

                        <textarea id=""F_Introduction"" name=""F_Introduction"" type=""text/plain"" style=""width:100%;height:400px;""></textarea>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">排序</label>
                    <div class=""layui-input-block"">

                        <input type=""number"" pattern=""[0-9]*"" id=""F_Order"" name=""F_Order"" value=""0"" lay-verify=""required|number"" oninput=""if(value.length>8)value=value.slice(0,8)"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class=""form-group-bottom text-right"">
                    <div class=""layui-input-block"">
                        <button class=""layui-btn site-demo-active"" lay-submit lay-filter=""saveBtn"">
                            &emsp;确认保存&emsp;
");
                WriteLiteral("                        </button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c59ab09aff56a82cbf8579fa6359ce21a46aab9211841", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5730, "~/lib/ueditor/themes/default/css/ueditor.css?v=", 5730, 47, true);
#nullable restore
#line 144 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml"
AddHtmlAttributeValue("", 5777, YMWeb.Code.GlobalContext.GetVersion(), 5777, 38, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59ab09aff56a82cbf8579fa6359ce21a46aab9213480", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5890, "~/lib/ueditor/ueditor.config.js?v=", 5890, 34, true);
#nullable restore
#line 145 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml"
AddHtmlAttributeValue("", 5924, YMWeb.Code.GlobalContext.GetVersion(), 5924, 38, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59ab09aff56a82cbf8579fa6359ce21a46aab9215196", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6027, "~/lib/ueditor/ueditor.all.js?v=", 6027, 31, true);
#nullable restore
#line 146 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\DictionaryDataBase\Views\Badgetypeinfo\Form.cshtml"
AddHtmlAttributeValue("", 6058, YMWeb.Code.GlobalContext.GetVersion(), 6058, 38, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->\r\n<!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c59ab09aff56a82cbf8579fa6359ce21a46aab9217023", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script type=""text/javascript"">
   
   

    // 加载 ueditor，传入的初始化参数可以覆盖掉 ueditor.config.js 中的配置
    // 对于同一项目中使用不同的配置的 ueditor 场景非常有用
    var ue = UE.getEditor('F_Introduction', {
        initialFrameHeight: 250,
        autoFloatEnabled: false, //取消悬浮
        // , initialFrameWidth:796
        zIndex: 0,
        wordCount: false
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
