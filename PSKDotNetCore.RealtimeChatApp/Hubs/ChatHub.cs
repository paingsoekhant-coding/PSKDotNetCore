﻿using Microsoft.AspNetCore.SignalR;

namespace PSKDotNetCore.RealtimeChatApp.Hubs;

public class ChatHub : Hub
{
	public async Task ServerReceiveMessage(string user, string message)
	{
		await Clients.All.SendAsync("ClientReceiveMessage", user, message);
	}
}
