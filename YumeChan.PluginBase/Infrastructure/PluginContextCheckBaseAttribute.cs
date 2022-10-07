using DSharpPlus.SlashCommands;

namespace YumeChan.PluginBase.Infrastructure;

/// <summary>
/// Provides a base class for all Plugins implementing Context menu Command pre-execution checks.
/// </summary>
public abstract class PluginContextCheckBaseAttribute : ContextMenuCheckBaseAttribute
{
	/// <summary>
	/// Error returned if this check fails.
	/// </summary>
	public abstract string ErrorMessage { get; protected set; }
}