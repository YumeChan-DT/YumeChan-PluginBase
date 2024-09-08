using System;
using DSharpPlus.SlashCommands;
using JetBrains.Annotations;

/*
 *	PluginSlashCheckBaseAttribute.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

namespace YumeChan.PluginBase.Infrastructure;

/// <summary>
/// Provides a base class for all Plugins implementing Slash Command pre-execution checks.
/// </summary>
[PublicAPI, AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public abstract class PluginSlashCheckBaseAttribute : SlashCheckBaseAttribute
{
	/// <summary>
	/// Error returned if this check fails.
	/// </summary>
	public abstract string ErrorMessage { get; protected set; }
}