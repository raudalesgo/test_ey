using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        User usermodel = new User();
        public TECH_TEST_G_HURTADOContext _tECH_TEST_G_HURTADOContext;



        [HttpGet("login")]
        public ResponseModel login(LoginModel login)
        {
            
            ResponseModel response = new ResponseModel();

            string pass = null;
            
            pass = _tECH_TEST_G_HURTADOContext.Users.Find(login.UserPass);
            string user = "gerald";

            try
            {
                if (login.UserPass != "hola" || login.UserName != "gerald")
                {
                    response.status = 401;
                    response.message = "Unauthorized";
                    response.data = null;
                }
                else
                {
                    response.status = 200;
                    response.message = "Ok";
                    response.data = null;
                    usermodel.UserPass = login.UserPass;
                    usermodel.UserName = login.UserName;
                    


                    
                    
                }


            }
            catch (Exception)
            {

                throw;
            }





            return response;


        }


    }
}
