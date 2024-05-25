using CleanApp.Application.Services.Stripes;
using CleanApp.Infrastructure;
using CleanApp.Infrastructure.DTOs.Stripe;
using CleanApplication.Application.Services.Stripes;
using System.Threading.Tasks;
using System.Web.Http;


namespace CleanApp.API.Controllers
{
    [RoutePrefix("api/stripe")] // RoutePrefix for the entire controller

    public class StripeController: ApiController
    {
        private readonly IStripeService stripeService;
        public StripeController()
        {
            this.stripeService=new StripeService();
        }
       
        [HttpPost]
        [Route("CheckOutSessionAsync")]
        public async Task<ResponseDto> CheckOutSessionAsync(CheckOutDTO checkOutDTO)
        {
            return await this.stripeService.CheckOutSessionAsync(checkOutDTO.PriceIds, checkOutDTO.UserId);
        }

        [HttpPost]
        [Route("StripeWebhook")]
        public async Task<ResponseDto> StripeWebhook(string fromRequest)
        {
            return await stripeService.StripeWebhook(fromRequest);
        }

    }
}