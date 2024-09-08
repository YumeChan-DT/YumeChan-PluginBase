using System.IO;
using JetBrains.Annotations;

/*
 *	IInterfaceConfigProvider.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

namespace YumeChan.PluginBase.Tools;

/// <summary>
/// Provides a simple, Interface-based Config Tool, for Plugins.
/// </summary>
/// <typeparam name="TConfig">Interface with to-be-used Config Properties</typeparam>
[PublicAPI]
public interface IInterfaceConfigProvider<out TConfig> where TConfig : class
{
	/// <summary>
	/// Config Interface. Config changes are effected by getting & setting values to these variables.
	/// </summary>
	/// <remarks>
	/// Do not forget to properly set your access modifiers & scopes. These will serve as foundation for the Config Tool.
	///
	/// Also don't forget to populate your Properties' defaults, to programatically create the Config File.
	/// Use <see cref="string.Empty"/> if a Default is or must be Empty. Null-coalescing assignment is what you'll be looking for, when creating the defaults.
	/// </remarks>
	TConfig? Configuration { get; }

	/// <summary>
	/// Get-only Property pointing to the Config File itself.
	/// </summary>
	FileInfo? ConfigFile { get; }

	/// <summary>
	/// Initialization Method for the Config File. Use this before attempting access on <see cref="Configuration"/>.
	/// </summary>
	/// <param name="filename">Config File's expected filename.</param>
	/// <returns>Config-ready Interface, mirrored on <see cref="Configuration"/>.</returns>
	TConfig InitConfig(string filename);
}