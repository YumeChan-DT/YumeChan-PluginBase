using DSharpPlus.SlashCommands;
using JetBrains.Annotations;

namespace YumeChan.PluginBase.Infrastructure;

/// <summary>
/// Provides a base class for all Plugins implementing Context menu Command pre-execution checks.
/// </summary>
[PublicAPI]
public abstract class PluginContextCheckBaseAttribute : ContextMenuCheckBaseAttribute
{
	/// <summary>
	/// Error returned if this check fails.
	/// </summary>
	public abstract string ErrorMessage { get; protected set; }
}