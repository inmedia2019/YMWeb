#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8406d7a10f0ffaf70ddf09248d95a32e8872407b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ContentManage_Views_Content_Form4), @"mvc.1.0.view", @"/Areas/ContentManage/Views/Content/Form4.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8406d7a10f0ffaf70ddf09248d95a32e8872407b", @"/Areas/ContentManage/Views/Content/Form4.cshtml")]
    public class Areas_ContentManage_Views_Content_Form4 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/themes/default/css/ueditor.css?v=1.3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/ueditor.config.js?v=1.3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/ueditor.all.js?v=1.3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/lang/zh-cn/zh-cn.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
  
    ViewBag.Title = "Form";
    Layout = "~/Views/Shared/_Form.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    layui.use(['jquery', 'form', 'laydate','xmSelect', 'optimizeSelectOption', 'common'], function () {
        var form = layui.form,
            $ = layui.$,
            common = layui.common,
            laydate = layui.laydate,
            upload = layui.upload,
            xmSelect = layui.xmSelect;

        var keyValue = $.request(""keyValue"");
        var itemId = $.request(""itemId"");
        //权限字段
        common.authorizeFields('adminform');

        laydate.render({
            elem: '#F_MeetingStartTime',
            format: 'yyyy/MM/dd HH:mm:ss',
            type:'datetime',
        });
        laydate.render({
            elem: '#F_MeetingEndTime',
            format: 'yyyy/MM/dd HH:mm:ss',
            type: 'datetime',
        });
        laydate.render({
            elem: '#F_PublishTime',
            format: 'yyyy/MM/dd HH:mm:ss',
            type: 'datetime',
        });
         var channelSelect= xmSelect.render({
              el: '#channelSelect',
 ");
            WriteLiteral(@"           autoRow: true,
             filterable: true,
             radio: true,
            direction: 'down',
            tree: {
                show: true,
                showFolderIcon: true,
                showLine: true,
                indent: 20,
                strict: false,
                clickExpand: true,
                clickCheck: true,
                expandedKeys: true
            },
            toolbar: {
                show: true,
                list: ['ALL', 'REVERSE', 'CLEAR']
            },
            filterable: true,
            height: 'auto',
            data: function () {
                return  ");
#nullable restore
#line 57 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                   Write(Html.Raw(ViewBag.channel));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            }
        });
        var tagSelect= xmSelect.render({
            el: '#tagSelect',
            autoRow: true,
            filterable: true,
            direction: 'down',
            tree: {
                show: true,
                showFolderIcon: true,
                showLine: true,
                indent: 20,
                strict: false,
                clickExpand: true,
                clickCheck: true,
                expandedKeys: true
            },
            toolbar: {
                show: true,
                list: ['ALL', 'REVERSE', 'CLEAR']
            },
            filterable: true,
            height: 'auto',
            data: function () {
                return  ");
#nullable restore
#line 82 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                   Write(Html.Raw(ViewBag.lable));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            }
        });
        var authorSelect =xmSelect.render({
            el: '#authorSelect',
            autoRow: true,
            filterable: true,
            toolbar: {
                show: true,
                list: ['ALL', 'REVERSE', 'CLEAR']
            },
            data: ");
#nullable restore
#line 93 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
             Write(Html.Raw(ViewBag.expert));

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
        });
        var event = $.request(""event"");
        wcLoading.close();
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

            if (event == ""edit"") {
                var newsdata = JSON.parse('");
#nullable restore
#line 109 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                                      Write(Html.Raw(ViewBag.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
                common.val('adminform', newsdata);
                var Description2 = newsdata.F_LiveIntroduction;
                var Description3 = newsdata.F_WonderfulContent;
                if (!!newsdata.ImgUrl) {
                    ImgUrlPic.src = newsdata.ImgUrl;
                }
                if (Description2 != null) {
                var editor2 = UE.getEditor(""F_LiveIntroduction"");
                editor2.ready(function () {
                    editor2.setContent(Description2);
                });
                }
                if (Description3 != null) {
                var editor3 = UE.getEditor(""F_WonderfulContent"");
                editor3.ready(function () {
                    editor3.setContent(Description3);
                });
                }
                if (newsdata.F_SubChannelId != null) {
                    var channelarr = newsdata.F_SubChannelId.split(',');
                    channelSelect.setValue(channelarr);
                }
            ");
            WriteLiteral(@"    if (newsdata.F_Tags != null) {
                    var tagarr = newsdata.F_Tags.split(',');
                    tagSelect.setValue(tagarr);
                }
                if (newsdata.F_Author != null) {
                    var authorrr = newsdata.F_Author.split(',');
                    authorSelect.setValue(authorrr);
                }
            }
            if ($(""#F_CoverImage"").val() != """") {
                $(""#F_ImgUrlPic"").attr(""src"", $(""#F_CoverImage"").val());
                $(""#imgshow"").removeAttr(""class"", ""layui-hide"");
            }
            if ($(""#F_LiveBroadcast"").val() != """") {
                $('.liveBroadcast').show();
                $('.video').hide();
                $('.href').hide();
            }
        if ($(""#F_Video"").val() != """") {
                $('.liveBroadcast').hide();
                $('.video').show();
                $('.href').hide();
            }
    if ($(""#F_ContentHref"").val() != """") {
                $('.liveBroadcast').hide()");
            WriteLiteral(";\r\n                $(\'.video\').hide();\r\n                $(\'.href\').show();\r\n            }\r\n\r\n           form.render();\r\n       });\r\n\r\n       function initControl() {\r\n           $(\"#F_ChannelId\").bindSelect({\r\n               url: \"");
#nullable restore
#line 166 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                 Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral("/ContentManage/Channel/GetTreeSelectJson\"\r\n           });\r\n           $(\"#F_ChannelId\").val(\'");
#nullable restore
#line 168 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                              Write(ViewBag.ChannelId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');

           $('#F_LiveBroadcast').on(""input propertychange"", function () {
               $('.liveBroadcast').show();
               $('.video').hide();
               $('.href').hide();
           });
           $('#F_Video').on(""input propertychange"", function () {
               $('.liveBroadcast').hide();
               $('.video').show();
               $('.href').hide();
           });
           $('#F_ContentHref').on(""input propertychange"", function () {
               $('.liveBroadcast').hide();
               $('.video').hide();
               $('.href').show();
           });
       }
        //select验证
        form.verify({
            required: function (value, item) {
                var msg = ""必填项不能为空"";
                value = $.trim(value);
                var isEmpty = !value || value.length < 1;
                // 当前验证元素是select且为空时,将页面定位至layui渲染的select处，或自定义想定位的位置
                if (item.tagName == 'SELECT' && isEmpty) {
                    $(""html"").animate({");
            WriteLiteral(@"
                        scrollTop: $(item).siblings("".layui-form-select"").offset().top - 74
                    }, 50);
                }
                if (isEmpty) {
                    return msg;
                }
            }
        });
       //监听提交
        form.on('submit(saveBtn)', function (data) {
           // 单击之后提交按钮不可选,防止重复提交
           $('.site-demo-active').addClass('layui-btn-disabled');
           $('.site-demo-active').attr('disabled', 'disabled');
            var postData = data.field;
           if (!postData[""F_LiveIntroduction""]) postData[""F_LiveIntroduction""] = UE.getEditor('F_LiveIntroduction').getContent();
           if (!postData[""F_WonderfulContent""]) postData[""F_WonderfulContent""] = UE.getEditor('F_WonderfulContent').getContent();
            if (!postData[""F_EnabledMark""]) postData[""F_EnabledMark""] = false;
            if (!postData[""F_IsRecommend""]) postData[""F_IsRecommend""] = false;
            if (!postData[""F_IsAuthorization""]) postData[""F_IsAuthorizati");
            WriteLiteral(@"on""] = false;
            if (!postData[""F_IsLive""]) postData[""F_IsLive""] = false;
            if (!postData[""F_IsTop""]) postData[""F_IsTop""] = false;
           if (!postData[""F_Status""]) postData[""F_Status""] = false;
            postData[""F_ItemId""] = itemId;
            postData[""F_SubChannelId""] = channelSelect.getValue('valueStr');
            postData[""F_Tags""] = tagSelect.getValue('valueStr');
            postData[""F_Author""] = authorSelect.getValue('valueStr');
           common.submitForm({
               url: event == ""edit"" ? """);
#nullable restore
#line 222 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                                   Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral("/ContentManage/Content/SubmitForm?keyValue=\" + keyValue : \"");
#nullable restore
#line 222 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                                                                                                                                                       Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral("/ContentManage/Content/SubmitForm\",\r\n               param: postData,\r\n               success: function () {\r\n                   common.reloadIframe(\"");
#nullable restore
#line 225 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\ContentManage\Views\Content\Form4.cshtml"
                                    Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral("/ContentManage/Content/Index\", \'data-search-btn\');\r\n               }\r\n           })\r\n           return false;\r\n       });\r\n   });\r\n</script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8406d7a10f0ffaf70ddf09248d95a32e8872407b16881", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"" style=""margin-bottom: 80px;"">
            <div class=""layui-form layuimini-form"" lay-filter=""adminform"">
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">栏目</label>
                    <div class=""layui-input-block"">
                        <select id=""F_ChannelId"" name=""F_ChannelId"" lay-filter=""F_ChannelId"" lay-search>
                            <option");
                BeginWriteAttribute("value", " value=\"", 9441, "\"", 9449, 0);
                EndWriteAttribute();
                WriteLiteral(@">请选择栏目</option>
                        </select>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">视频标题</label>
                    <div class=""layui-input-block"">
                        <input type=""hidden"" id=""F_HitCount"" name=""F_HitCount"" value=""0"">
                        <input type=""hidden"" id=""F_LikeCount"" name=""F_LikeCount"" value=""0"">
                        <input type=""hidden"" id=""F_CommentCount"" name=""F_CommentCount"" value=""0"">
                        <input type=""hidden"" id=""F_SubscriptionCount"" name=""F_SubscriptionCount"" value=""0"">
                        <input type=""hidden"" id=""F_FavoritesCount"" name=""F_FavoritesCount"" value=""0"">
                        <input type=""hidden"" id=""F_HitBackToCount"" name=""F_HitBackToCount"" value=""0"">
                        <input type=""text"" id=""F_Titile"" name=""F_Titile"" autocomplete=""off"" maxlength=""200"" lay-verify=""required"" class=");
                WriteLiteral(@"""layui-input"">
                    </div>
                </div>


                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">缩略图</label>
                    <div class=""layui-input-block"" style=""padding-right: 110px;"">
                        <input type=""text"" class=""layui-input"" name=""F_CoverImage"" id=""F_CoverImage"" maxlength=""255"" readonly=""readonly"">
                        <button type=""button"" class=""layui-btn"" style=""position: absolute;top: 0;right: 0;cursor: pointer;"" id=""j_upload_img_btn"">
                            <i class=""layui-icon""></i>上传图片
                        </button>
                        <ul id=""upload_img_wrap""></ul>
                        <textarea id=""uploadEditor"" style=""display: none;""></textarea>
                        <span style=""color:red"">(750*420)上传图片不能大于1M</span>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"" id=""imgshow"">
                    <");
                WriteLiteral(@"label class=""layui-form-label""></label>
                    <div class=""layui-input-block"">
                        <img id=""F_ImgUrlPic"" width=""200"" height=""200"" onclick=""previewImg(this)"" />
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label required"">简介</label>
                    <div class=""layui-input-block"">
                        <textarea id=""F_LiveIntroduction"" name=""F_LiveIntroduction"" type=""text/plain"" style=""width:100%;height:400px;""></textarea>
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"" style=""display:none;"">
                    <label class=""layui-form-label required"">精彩看点</label>
                    <div class=""layui-input-block"">
                        <textarea id=""F_WonderfulContent"" name=""F_WonderfulContent"" type=""text/plain"" style=""width:100%;height:400px;""></textarea>
                    </div>
        ");
                WriteLiteral(@"        </div>
                <div class=""layui-form-item"" style=""display:none;"">
                    <label class=""layui-form-label"">副栏目</label>
                    <div class=""layui-input-block"">
                        <div id=""channelSelect"" class=""xm-select-demo""></div>
                    </div>
                </div>
                <div class=""layui-form-item"" style=""display:none;"">
                    <label class=""layui-form-label"">标签</label>
                    <div class=""layui-input-block"">
                        <div id=""tagSelect"" class=""xm-select-demo""></div>
                    </div>
                </div>
                <div class=""layui-form-item"" style=""display:none;"">
                    <label class=""layui-form-label required"">讲者</label>
                    <div class=""layui-input-block"">
                        <div id=""authorSelect"" class=""xm-select-demo""></div>
                    </div>
                </div>
                <div class=""layui-form-item layui-hi");
                WriteLiteral(@"de"" style=""display:none;"">
                    <label class=""layui-form-label required"">会议开始时间</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_MeetingStartTime"" name=""F_MeetingStartTime"" autocomplete=""off"" maxlength=""200"" lay-verify=""required"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"" style=""display:none;"">
                    <label class=""layui-form-label required"">会议结束时间</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_MeetingEndTime"" name=""F_MeetingEndTime"" autocomplete=""off"" maxlength=""200"" lay-verify=""required"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"" style=""display:none;"">
                    <label class=""layui-form-label required"">会议时间段</label>
                    <div class=""layui-input-block"">
   ");
                WriteLiteral(@"                     <input type=""text"" id=""F_MeetingTimePeriod"" name=""F_MeetingTimePeriod"" autocomplete=""off"" maxlength=""200"" lay-verify=""required"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">排序</label>
                    <div class=""layui-input-block"">
                        <input type=""number"" pattern=""[0-9]*"" id=""F_Order"" name=""F_Order"" lay-verify=""required"" class=""layui-input"" value=""0"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">选项</label>
                    <div class=""layui-input-block"">
                        <input type=""checkbox"" name=""F_EnabledMark"" id=""F_EnabledMark""");
                BeginWriteAttribute("checked", " checked=\"", 15425, "\"", 15435, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""true"" title=""有效"">
                        <input id=""F_IsTop"" name=""F_IsTop"" type=""checkbox"" value=""true"" title=""是否置顶"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">发布时间</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_PublishTime"" name=""F_PublishTime"" autocomplete=""off"" maxlength=""200"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">审核状态</label>
                    <div class=""layui-input-block"">
                        <input type=""checkbox"" name=""F_Status"" id=""F_Status""");
                BeginWriteAttribute("checked", " checked=\"", 16240, "\"", 16250, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""true"" title=""审核通过"">
                    </div>
                </div>

                <div class=""layui-form-item layui-hide liveBroadcast"" style=""display:none;"">
                    <label class=""layui-form-label"">直播链接</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_LiveBroadcast"" name=""F_LiveBroadcast"" autocomplete=""off"" maxlength=""255"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide liveBroadcast"" style=""display:none;"">
                    <label class=""layui-form-label"">三方直播Id</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_LiveBroadcastId"" name=""F_LiveBroadcastId"" autocomplete=""off"" maxlength=""255"" class=""layui-input"" placeholder=""填写直播回传唯一标识"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide video"" style=""display:none;"">
      ");
                WriteLiteral(@"              <label class=""layui-form-label"">视频ID</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_Video"" name=""F_Video"" autocomplete=""off"" maxlength=""255"" class=""layui-input"" placeholder=""填写后后台数据分析出视频地址再进行跳转"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide href"" style=""display:none;"">
                    <label class=""layui-form-label"">外部链接</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_ContentHref"" name=""F_ContentHref"" autocomplete=""off"" maxlength=""255"" class=""layui-input"" placeholder=""填写后直接跳转到第三方视频平台"">
                    </div>
                </div>
");
                WriteLiteral(@"                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">Seo标题</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_SeoTitle"" name=""F_SeoTitle"" autocomplete=""off"" class=""layui-input"" placeholder=""不填写则默认为网站标题"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">Seo关键字</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" id=""F_SeoKeywords"" name=""F_SeoKeywords"" autocomplete=""off"" class=""layui-input"" placeholder=""不填写则默认为网站摘要"">
                    </div>
                </div>
                <div class=""layui-form-item layui-hide"">
                    <label class=""layui-form-label"">Seo描述</label>
                    <div class=""layui-input-block"">
                        <textarea id=""F_SeoDescription"" name=""F_SeoDescription"" autocomplet");
                WriteLiteral(@"e=""off"" class=""layui-textarea"" placeholder=""不填写则自动截取内容前255字符""></textarea>
                    </div>
                </div>

                <div class=""form-group-bottom text-right"">
                    <div class=""layui-input-block"">
                        <button class=""layui-btn site-demo-active"" lay-submit lay-filter=""saveBtn"">
                            &emsp;保存&emsp;
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8406d7a10f0ffaf70ddf09248d95a32e8872407b29021", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8406d7a10f0ffaf70ddf09248d95a32e8872407b30200", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8406d7a10f0ffaf70ddf09248d95a32e8872407b31474", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->\r\n    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8406d7a10f0ffaf70ddf09248d95a32e8872407b32870", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
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
        var ue1 = UE.getEditor('F_LiveIntroduction', {
            initialFrameHeight: 250,
            autoFloatEnabled: false, //取消悬浮
            // , initialFrameWidth:796
            zIndex: 0,
            wordCount: false
        });
        var ue2 = UE.getEditor('F_WonderfulContent', {
            initialFrameHeight: 250,
            autoFloatEnabled: false, //取消悬浮
            // , initialFrameWidth:796
            zIndex: 0,
            wordCount: false
        });

        // 实例化编辑器，这里注意配置项隐藏编辑器并禁用默认的基础功能。
        var uploadEditor = UE.getEditor(""uploadEditor"", {
            isShow: false,
            focus: false,
            enableAutoSave: false,
            autoSyncData: false,
            autoFloatEnabled: false,
            wordCount: false,
            sourceEditor: null,
            scaleEnabled: true,
            toolbars: [[");
                WriteLiteral(@"""insertimage"", ""attachment""]]
        });
    </script>
    <script>
        $(function () {
            // 监听多图上传和上传附件组件的插入动作
            uploadEditor.ready(function () {
                uploadEditor.addListener(""beforeInsertImage"", _beforeInsertImage);
            });
            // 自定义按钮绑定触发多图上传和上传附件对话框事件
            document.getElementById('j_upload_img_btn').onclick = function () {
                var dialog = uploadEditor.getDialog(""insertimage"");
                dialog.title = '图片上传';
                dialog.render();
                dialog.open();
            };
        });
        // 多图上传动作
        function _beforeInsertImage(t, result) {
            var imageHtml = '';
            $(""#F_CoverImage"").val(result[0].src);
            $(""#F_ImgUrlPic"").attr(""src"", result[0].src);
            $(""#imgshow"").removeAttr(""class"", ""layui-hide"");
            //for (var i in result) {
            //    imageHtml += '<li><img src=""' + result[i].src + '"" alt=""' + result[i].alt + '"" height=""");
                WriteLiteral(@"150""></li>';
            //}
            //document.getElementById('upload_img_wrap').innerHTML = imageHtml;
        }

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
