using System.Threading.Tasks;
using YMWeb.Code;

namespace YMWeb.Service.AutoJob
{
    public interface IJobTask
    {
        Task<AjaxResult> Start();
    }
}
