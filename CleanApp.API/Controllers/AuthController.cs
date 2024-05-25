using CleanApp.Application.Services.Auths;
using CleanApp.Infrastructure;
using CleanApp.Infrastructure.DTOs.Auth;
using System.Threading.Tasks;
using System.Web.Http;

namespace CleanApp.API.Controllers
{
    [RoutePrefix("api/auth")] // RoutePrefix for the entire controller
    public class AuthController : ApiController // Inherit from ApiController for Web API
    {
        private readonly IAuthService authService;

        public AuthController()
        {
            this.authService = new AuthService();
        }

        // Prefer IHttpActionResult for Web API actions
        [HttpPost]
        [Route("login")] // Route specific to login action
        public async Task<ResponseDto> Login(LoginDto loginDto)
        {

            return await this.authService.Login(loginDto);
        }

        [HttpPost]
        [Route("signup")] // Route specific to signup action
        public async Task<ResponseDto> Signup(SignupDto signupDto)
        {
            return await this.authService.Signup(signupDto);
        }
        [HttpPost]
        [Route("SendSMSOTP")]
        public async Task<ResponseDto> SendSMSOTP(LoginDto loginDto)
        {
            return await this.authService.SendSMSOTP(loginDto);
        }
        [HttpPost]
        [Route("SendWhatsAppOTP")]
        public async Task<ResponseDto> SendWhatsAppOTP(LoginDto loginDto)
        {
            return await this.authService.SendWhatsAppOTP(loginDto);
        }
        [HttpPost]
        [Route("VerifyOTP")]
        public async Task<ResponseDto> VerifyOTP(VerifyOTPDto otpDto)
        {
            return await this.authService.VerifyOTP(otpDto);
        }
    }
}
