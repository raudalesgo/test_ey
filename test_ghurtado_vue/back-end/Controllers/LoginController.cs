using back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        User usermodel = new User();
        public TECH_TEST_G_HURTADOContext _tECH_TEST_G_HURTADOContext;
        ResponseModel response = new ResponseModel();

        public readonly TECH_TEST_G_HURTADOContext _context;
       
        //public LoginController(TECH_TEST_G_HURTADOContext context)
        //{
        //     context = _context;

        //}



        //[HttpPost]
        //[Authorize]
        //public ActionResult  Index(LoginModel model)
        //{

        //    using (var context = new TECH_TEST_G_HURTADOContext())
        //    {
        //        return context.Users;
        //    }

        //    var user = context().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();
        //    return user;
        //}




        [HttpGet("metodo")]
        public IEnumerable<User> Get()
        {

            ResponseModel response = new ResponseModel();



            //var pass = _tECH_TEST_G_HURTADOContext.Users.Find(login.UserPass);
            //string user = "gerald";

            //    try
            //    {


            using (var context = new TECH_TEST_G_HURTADOContext())
            {
                return context.Users.ToList();
            }



            //        //    if (users.Count() != null || login.UserName != "gerald")
            //        //    {
            //        //        response.status = 401;
            //        //        response.message = "Unauthorized";
            //        //        response.data = null;
            //        //    }
            //        //    else
            //        //    {
            //        //        response.status = 200;
            //        //        response.message = "Ok";
            //        //        response.data = null;
            //        //        usermodel.UserPass = login.UserPass;
            //        //        usermodel.UserName = login.UserName;





            //        //    }


            //        //}
            //        //catch (Exception)
            //        //{

            //        //    throw;
            //        //}





            //        return response;


        }


        [HttpPost]
        public object Post(LoginModel model)
        {
            
            try
            {
                if (model != null)
                {
                    using (var context = new TECH_TEST_G_HURTADOContext())
                    {
                        
                            User user = (from u in context.Users
                                         where u.UserEmail.Equals(model.UserName) &&
                                               u.UserPass.Equals(model.UserPass)
                                         select u).FirstOrDefault();
                        }

                    response.status = 200;
                    response.message = "Ok";

                }

            }
            catch (Exception)
            {

                response.status = 401;
                response.message = "Unauthorized";
            }

            
            //if (user == null)
            //{
            //    // Invalid user name or password
            //}
            //else if (user != true)
            //{
            //    // User inactive
            //}
            //else
            //{
            //    // Success
            //}

            return response;

        }


    }
}
