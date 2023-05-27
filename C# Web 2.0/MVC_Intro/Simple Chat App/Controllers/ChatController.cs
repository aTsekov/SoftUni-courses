using Microsoft.AspNetCore.Mvc;
using Simple_Chat_App.Models.Message;

namespace Simple_Chat_App.Controllers
{
	public class ChatController : Controller
	{
		//A collection of messages, which has the message sender as key and the message text as value
		private static List<KeyValuePair<string, string>> s_messages = new List<KeyValuePair<string, string>>();

		//A "GET" method Show(), which returns a view with model (the model may hold the messages)
		[HttpGet]
		public IActionResult Show()
		{
			if (s_messages.Count() < 0)
			{
				return View(new ChatViewModel()); //If no messages return empty model
			}
			//else
			var chatModel = new ChatViewModel()
			{
				Messages = s_messages.Select(m => new MessageViewModel()
				{
					Sender = m.Key,
					MessageText = m.Value
				}).ToList()
			};

			return View(chatModel);
		}


		//A "POST" method Send(), which accepts a model from the view and adds a message to the collection.
		//Then, it redirects to the Show() action
				[HttpPost]
		public IActionResult Send(ChatViewModel chat)
		{
			var newMessage = chat.CurrentMessage;
			s_messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));
			return RedirectToAction("Show");
		}

		//Warning: the above code holds the shared app data in a static field in the controller class. This is just
		//for the example, and it is generally a bad practice! Use a database or other persistent storage to hold
		//	data, which should survive between the app requests and should be shared between all app users
	}
	
}
