using Microsoft.AspNetCore.Mvc;
using UEditor.Core;
namespace YMWeb.Web.Controllers
{
    [Route("api/[controller]")]
    public class UEditorController : Controller
    {
        private UEditorService ue;
        
        public UEditorController(UEditorService ue)
        {
            this.ue = ue;
        }

        [ServiceFilter(typeof(HandlerLoginAttribute))]
        public void Do()
        {
            try
            {
                ue.DoAction(HttpContext);
            }
            catch (System.Exception ex)
            {

                
            }
          
        }
    }
}
