using back_end.Models;

namespace back_end.Services
{
    public class UserService 
    {
        private TECH_TEST_G_HURTADOContext _tECH_TEST_G_HURTADOContext;

        public UserService(TECH_TEST_G_HURTADOContext tECH_TEST_G_HURTADOContext)
        {
            _tECH_TEST_G_HURTADOContext = tECH_TEST_G_HURTADOContext;
        }


        //public  Authenticate(LoginModel model)
        //{
        //    var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        //    // validate
        //    if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
        //        throw new AppException("Username or password is incorrect");

        //    // authentication successful
        //    var response = _mapper.Map<AuthenticateResponse>(user);
        //    response.Token = _jwtUtils.GenerateToken(user);
        //    return response;
        //}


    }
}
