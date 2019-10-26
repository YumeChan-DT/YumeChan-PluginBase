using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Nodsoft.YumeChan.PluginBase
{
	public interface IMessageTap
	{
		Task OnMessageReceived(SocketMessage message);
		Task OnMessageUpdated(Cacheable<IMessage, ulong> messageBeforeUpdate, SocketMessage messageAfterUpdate, ISocketMessageChannel channel);
		Task OnMessageDeleted(Cacheable<IMessage, ulong> message, ISocketMessageChannel channel);
	}
}
