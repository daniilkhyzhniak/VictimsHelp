using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.Chat;

namespace VictimsHelp.PL.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/chat")]
    public class ChatApiController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public ChatApiController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{receiverEmail}")]
        public async Task<IActionResult> Chat(string receiverEmail)
        {
            var currentUserEmail = HttpContext.User.Identity.Name;

            if (currentUserEmail == receiverEmail)
            {
                return BadRequest();
            }

            var messages = await _messageService.GetMessagesAsync(currentUserEmail, receiverEmail);

            return Ok(messages);
        }

        [HttpPost("{receiverEmail}")]
        public async Task<IActionResult> SendMessage(CreateMessageViewModel viewModel, string receiverEmail)
        {
            var model = new MessageModel
            {
                Text = viewModel.Text
            };
            var currentUserEmail = HttpContext.User.Identity.Name;
            model.SenderEmail = currentUserEmail;
            model.ReceiverEmail = receiverEmail;

            var result = await _messageService.SendMessageAsync(model);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
