#pragma checksum "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\User\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82c0f55d20194d404e32fdffb0545a56e35ae34d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemOrganize_Views_User_Details), @"mvc.1.0.view", @"/Areas/SystemOrganize/Views/User/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82c0f55d20194d404e32fdffb0545a56e35ae34d", @"/Areas/SystemOrganize/Views/User/Details.cshtml")]
    public class Areas_SystemOrganize_Views_User_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\User\Details.cshtml"
  
    ViewBag.Title = "Details";
    Layout = "~/Views/Shared/_Form.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
    layui.use(['jquery', 'form', 'laydate', 'common', 'optimizeSelectOption'], function () {
        var form = layui.form,
            $ = layui.$,
            common = layui.common,
            laydate = layui.laydate;
        var keyValue = $.request(""keyValue"");
        //权限字段
        common.authorizeFields('adminform');
        //执行一个laydate实例
        laydate.render({
            elem: '#F_Birthday'
            , btns: ['clear', 'now']
            , trigger: 'click',
            format: 'yyyy-MM-dd',
        });
        function initControl() {
            $(""#F_OrganizeId"").bindSelect({
                url: """);
#nullable restore
#line 23 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\User\Details.cshtml"
                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/SystemSet/GetListJson"",
                id: ""F_Id"",
                text: ""F_CompanyName""
            });
            $(""#F_DutyId"").bindSelect({
                data: top.clients.duty,
                id: ""encode"",
                text: ""fullname"",
            });
        }
        $(function () {
            initControl();
            common.ajax({
                url: """);
#nullable restore
#line 36 "E:\work\y疫苗小程序\发送源码\YMWEB.Web\Areas\SystemOrganize\Views\User\Details.cshtml"
                  Write(YMWeb.Code.GlobalContext.SystemConfig.VirtualDirectory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/SystemOrganize/User/GetFormJson"",
                data: { keyValue: keyValue },
                dataType: ""json"",
                async: false,
                success: function (data) {
                    common.val('adminform', data);
                    common.setReadOnly('adminform');
                    $(""#F_UserPassword"").val(""******"").attr('disabled', 'disabled');
                    form.render();
                }
            });
        });
        wcLoading.close();
    });
    </script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82c0f55d20194d404e32fdffb0545a56e35ae34d5013", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container "">
        <div class=""layuimini-main"">
            <div class=""layui-form layuimini-form"" lay-filter=""adminform"">
                <div class=""layui-form-item "">
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">账号</label>
                        <div class=""layui-input-inline"">
                            <input type=""text"" id=""F_Account"" name=""F_Account"" lay-verify=""required"" autocomplete=""off"" class=""layui-input"">
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">密码</label>
                        <div class=""layui-input-inline"">
                            <input type=""password"" id=""F_UserPassword"" name=""F_UserPassword"" lay-verify=""required"" autocomplete=""off"" class=""layui-input"">
                        </div>
                    </div>
                </div>
        ");
                WriteLiteral(@"        <div class=""layui-form-item"" style=""display:none;"">
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">公司</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_OrganizeId"" name=""F_OrganizeId"" lay-verify=""required""");
                BeginWriteAttribute("lay-search", " lay-search=\"", 3148, "\"", 3161, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                            </select>
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">部门</label>
                        <div class=""layui-input-inline"">
                            <input id=""F_DepartmentName"" name=""F_DepartmentName"" type=""text"" lay-verify=""required"" maxlength=""50"" autocomplete=""off"" class=""layui-input"" onclick=""search('部门')"" />
                            <input id=""F_DepartmentId"" name=""F_DepartmentId"" type=""text"" hidden />
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item"" style=""display:none;"">
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">类型</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_IsAdministrator"" name=""F_IsSenior"" lay-verify=""required"">
  ");
                WriteLiteral(@"                              <option value=""false"">普通用户</option>
                                <option value=""true"">系统管理员</option>
                            </select>
                        </div>
                    </div>
                    <div class=""layui-inline"">
                        <label class=""layui-form-label"">职位</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_DutyId"" name=""F_DutyId"" lay-verify=""required""");
                BeginWriteAttribute("lay-search", " lay-search=\"", 4682, "\"", 4695, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <option");
                BeginWriteAttribute("value", " value=\"", 4738, "\"", 4746, 0);
                EndWriteAttribute();
                WriteLiteral(@">==请选择==</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">姓名</label>
                        <div class=""layui-input-inline"">
                            <input id=""F_RealName"" name=""F_RealName"" type=""text"" lay-verify=""required"" autocomplete=""off"" class=""layui-input"" />
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">性别</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_Gender"" name=""F_Gender"" lay-verify=""required"">
                                <option value=""true"">男</option>
                                <option value=""false"">女</option>
                            </select>");
                WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">手机</label>
                        <div class=""layui-input-inline"">
                            <input type=""text"" id=""F_MobilePhone"" name=""F_MobilePhone"" autocomplete=""off"" class=""layui-input"">
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">生日</label>
                        <div class=""layui-input-inline"">
                            <input type=""text"" id=""F_Birthday"" name=""F_Birthday"" autocomplete=""off"" class=""layui-input"">
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <div class=""layui-inline layui-hide"">
                      ");
                WriteLiteral(@"  <label class=""layui-form-label"">微信</label>
                        <div class=""layui-input-inline"">
                            <input type=""text"" id=""F_WeChat"" name=""F_WeChat"" autocomplete=""off"" class=""layui-input"">
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">邮箱</label>
                        <div class=""layui-input-inline"">
                            <input type=""text"" id=""F_Email"" name=""F_Email"" autocomplete=""off"" class=""layui-input"">
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item"" style=""display:none;"">
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">高管</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_IsSenior"" name=""F_IsSenior"" lay-verify=""required"">
         ");
                WriteLiteral(@"                       <option value=""false"">否</option>
                                <option value=""true"">是</option>
                            </select>
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">部门主管</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_IsLeaderInDepts"" name=""F_IsLeaderInDepts"" lay-verify=""required"">
                                <option value=""false"">否</option>
                                <option value=""true"">是</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item"">
                  
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">角色</label>
                        <div class=""layui-input-inline"">
  ");
                WriteLiteral(@"                          <input id=""F_RoleName"" name=""F_RoleName"" type=""text"" lay-verify=""required"" maxlength=""50"" autocomplete=""off"" class=""layui-input"" onclick=""search('角色')"" />
                            <input id=""F_RoleId"" name=""F_RoleId"" type=""text"" hidden />
                        </div>
                    </div>
                    <div class=""layui-inline layui-hide"">
                        <label class=""layui-form-label"">允许登录</label>
                        <div class=""layui-input-inline"">
                            <select id=""F_EnabledMark"" name=""F_IsLeaderInDepts"" lay-verify=""required"">
                                <option value=""true"">是</option>
                                <option value=""false"">否</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class=""layui-form-item layui-form-text"">
                    <div class=""layui-row layui-hide"">
                        <label");
                WriteLiteral(@" class=""layui-form-label"">备注</label>
                        <div class=""layui-input-block"">
                            <textarea class=""layui-textarea""></textarea>
                        </div>
                    </div>
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
