using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.Chat;

namespace VictimsHelp.PL.Controllers
{
    [Authorize]
    [Route("chat")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ChatController : Controller
    {
        private readonly IMessageService _messageService;

        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{receiverEmail}")]
        public async Task<IActionResult> Chat(string receiverEmail)
        {
            var currentUserEmail = HttpContext.User.Identity.Name;

            if (currentUserEmail == receiverEmail)
            {
                return RedirectToAction("Forbidden", "Error");
            }

            var messages = await _messageService.GetMessagesAsync(currentUserEmail, receiverEmail);

            var model = new MessageViewModel
            {
                Messages = messages.ToList(),
            };

            return View(model);
        }

        [HttpGet("messages/{receiverEmail}")]
        public async Task<IActionResult> Messages(string receiverEmail)
        {
            var currentUserEmail = HttpContext.User.Identity.Name;

            if (currentUserEmail == receiverEmail)
            {
                return RedirectToAction("Forbidden", "Error");
            }

            var messages = await _messageService.GetMessagesAsync(currentUserEmail, receiverEmail);

            return View("_MessagesPartial", messages);
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

            await _messageService.SendMessageAsync(model);

            return RedirectToAction("Chat", new { receiverEmail });
        }
    }
}
