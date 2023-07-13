using System.Threading.Tasks;
using JetBrains.Annotations;

/*
 *	IWritableConfiguration.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

namespace YumeChan.PluginBase;

/// <summary>
/// Specifies a Plugin's Manifest for YumeChan.
/// </summary>
/// <remarks>
///	Only one concrete implementation of <see cref="IPlugin"/> should exist per assembly.
/// </remarks>
[PublicAPI]
public interface IPlugin
{
	#region Identification
	
	/// <summary>
	/// The Plugin's Assembly Name, used for internal identification purposes.
	/// </summary>
	public string AssemblyName { get; }

	/// <summary>
	/// The Plugin's Display Name, used for external, user and UI display purposes.
	/// </summary>
	public string DisplayName { get; }
	
	/// <summary>
	/// The Plugin's Current Version.
	/// </summary>
	/// <remarks>
	/// It is best practice to mirror the Assembly's Versionning, using <c>typeof(PluginManifestClass).Assembly.GetName().Version</c>.
	/// </remarks>
	string Version { get; }
	
	#endregion
	
	#region Specification
	
	/// <summary>
	/// Advises if the Plugin should be loaded from a NetRunner only.
	/// </summary>
	/// <value>
	///	<see langword="false"/>: The Plugin is suitable for both NetRunner and ConsoleRunner.
	/// <br />
	/// <see langword="true"/>: The Plugin is only suitable for NetRunner.
	/// </value>
	public bool ShouldUseNetRunner { get; }

	/// <summary>
	/// Controls whether Plugin is shown when listing active Plugins.
	/// </summary>
	/// <remarks>
	/// Bot Owners, Operators, and Verified Server Admins, may be able to bypass Stealth Mode.
	/// It is only intended to keep the plugin's existence unknown to the general public.
	/// </remarks>
	/// <value>
	/// <see langword="false"/>: defines the Plugin as visible.
	/// <see langword="true"/>: defines the Plugin as hidden.
	/// </value>
	public bool StealthMode { get; }

	#endregion

	/// <summary>
	/// Defines if the Plugin has been Loaded by the Core.
	/// </summary>
	/// <remarks>
	/// It is best practice to let this property be handled by <see cref="LoadAsync()"/> and <see cref="UnloadAsync()"/>.
	/// </remarks>
	public bool Loaded { get; }
	
	/// <summary>
	/// Initializes the Plugin.
	/// </summary>
	/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Loaded.</returns>
	/// <remarks>This method should control the behaviour of property <see cref="Loaded"/>, assigning it <see langword="true"/>.</remarks>
	public Task LoadAsync();

	/// <summary>
	/// Unloads the Plugin.
	/// </summary>
	/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Unloaded.</returns>
	/// <remarks>This method should control the behaviour of property <see cref="Loaded"/>, assigning it <see langword="true"/>.</remarks>
	public Task UnloadAsync();
}