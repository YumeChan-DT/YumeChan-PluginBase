using System;
using JetBrains.Annotations;

/*
 *	PluginDocsAttribute.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

namespace YumeChan.PluginBase.Infrastructure;

/// <summary>
/// Defines the documentation for a Yume-Chan plugin.
/// </summary>
[PublicAPI, AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
public sealed class PluginDocsAttribute : Attribute
{
	public const string DefaultPath = "/docs";
	
	/// <summary>
	/// Defines whether documentation is available for this plugin.
	/// </summary>
	public bool Enabled { get; init; }
	
	/// <summary>
	/// Defines the path to the documentation root folder.
	/// </summary>
	/// <remarks>
	/// This path is relative to the plugin's directory, defaults to <c>/docs</c>.
	/// </remarks>
	public string Path { get; init; } =	DefaultPath;
}