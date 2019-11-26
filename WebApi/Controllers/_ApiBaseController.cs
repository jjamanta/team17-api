using Microsoft.AspNetCore.Mvc;

namespace Team17.Api.Controllers
{
    public class _ApiBaseController : ControllerBase
    {
        protected string PersonId
        {
            get
            {
                string usr = "";
                try
                {
                  usr = User.FindFirst("PersonId")?.Value;
                }
                catch
                {
                    usr = "00000000-0000-0000-0000-000000000000";
                }
                return usr.ToUpper();
            }
        }              
    }
}
