﻿using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

/**
 *	MessageTap.cs
 *	Licensed by YumeChan-DT (Nodsoft ES) under GNU-GPLv3
 **/

namespace Nodsoft.YumeChan.PluginBase
{
	/// <summary>
	/// Defines the Plugin's ability to Tap into Non-Command messages.
	/// </summary>
	public interface IMessageTap
	{
		/// <summary>
		/// Plugin's Internal Handler for <see cref="BaseSocketClient.MessageReceived"/> Event.
		/// </summary>
		/// <param name="message">Provides the Message that was received by the Event.</param>
		/// <returns><see cref="Task.CompletedTask"/> when all operations were performed.</returns>
		Task OnMessageReceived(SocketMessage message);

		/// <summary>
		/// Plugin's Internal Handler for <see cref="BaseSocketClient.MessageUpdated"/> Event.
		/// </summary>
		/// <param name="messageBeforeUpdate">Provides the Message's state (cached) prior to the Message Update.</param>
		/// <param name="messageAfterUpdate">Provides the Message's state following the Message Update.</param>
		/// <param name="channel">Provides the Channel of the Updated Message.</param>
		/// <returns><see cref="Task.CompletedTask"/> when all operations were performed.</returns>
		Task OnMessageUpdated(Cacheable<IMessage, ulong> messageBeforeUpdate, SocketMessage messageAfterUpdate, ISocketMessageChannel channel);

		/// <summary>
		/// Plugin's Internal Handler for <see cref="BaseSocketClient.MessageDeleted"/> Event.
		/// </summary>
		/// <param name="message">Provides the Message's state (cached) before deletion.</param>
		/// <param name="channel">Provides the Channel of the now Deleted Message.</param>
		/// <returns><see cref="Task.CompletedTask"/> when all operations were performed.</returns>
		Task OnMessageDeleted(Cacheable<IMessage, ulong> message, ISocketMessageChannel channel);
	}
}
