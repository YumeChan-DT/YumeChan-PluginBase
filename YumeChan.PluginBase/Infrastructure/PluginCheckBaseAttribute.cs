using DSharpPlus.CommandsNext.Attributes;
using JetBrains.Annotations;

namespace YumeChan.PluginBase.Infrastructure;

/// <summary>
/// Provides a base class for all Plugins implementing Command pre-execution checks.
/// </summary>
[PublicAPI]
public abstract class PluginCheckBaseAttribute : CheckBaseAttribute
{
	/// <summary>
	/// Error returned if this check fails.
	/// </summary>
	public abstract string ErrorMessage { get; protected set; }
}