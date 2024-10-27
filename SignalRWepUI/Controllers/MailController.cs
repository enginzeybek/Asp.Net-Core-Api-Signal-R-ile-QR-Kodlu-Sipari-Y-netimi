using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWepUI.DTOs.MailDTOs;

namespace SignalRWepUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]

		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("E&Z Restoran Rezervasyon", "mail adresi");

			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("user",createMailDto.ReceiveMail);

			mimeMessage.To.Add(mailboxAddressTo);


			var bodyBuilder = new BodyBuilder();

			bodyBuilder.TextBody = createMailDto.Body;

			mimeMessage.Body = bodyBuilder.ToMessageBody();


			mimeMessage.Subject = createMailDto.Subject;


			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("mail adresi", "key");

			client.Send(mimeMessage);
			client.Disconnect(true);

			return RedirectToAction("Index", "Category");
		}
	}
}
