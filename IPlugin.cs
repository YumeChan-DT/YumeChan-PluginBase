using System.Threading.Tasks;

/*
 *	IPlugin.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT License.
 */

namespace YumeChan.PluginBase;

/// <summary>
/// Defines a Plugin Manifest for YumeChan
/// </summary>
public interface IPlugin
{
	/// <summary>
	/// Reflects the Plugin's Assembly Name.
	/// </summary>
	public string AssemblyName { get; }

	/// <summary>
	/// Defines Plugin's Display Name.
	/// </summary>
	public string DisplayName { get; }

	/// <summary>
	/// Defines if the Plugin has been Loaded by the Core.
	/// </summary>
	/// <remarks>
	/// It is best practice to let this property be handled by <see cref="LoadAsync()"/> and <see cref="UnloadAsync()"/>.
	/// </remarks>
	public bool Loaded { get; }

	/// <summary>
	/// Controls whether Plugin is shown when listing active Plugins.
	/// </summary>
	/// <remarks>
	/// Bot Owners, Operators, and Verified Server Admins, may be able to bypass Stealth Mode.
	/// It is only intended to keep the plugin's existence unknown to the general public.
	/// </remarks>
	/// <value><see cref="false"/> defines the Plugin as visible ; <see cref="true"/> defines the Plugin as Hidden.</value>
	public bool StealthMode { get; }

	/// <summary>
	/// Defines Plugin's Current Version.
	/// </summary>
	/// <remarks>
	/// It is best practice to mirror the Assembly's Versionning, using <c>typeof(PluginManifestClass).Assembly.GetName().Version</c>.
	/// </remarks>
	string Version { get; }

	/// <summary>
	/// Initializes the Plugin.
	/// </summary>
	/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Loaded.</returns>
	/// <remarks>This method should control the behaviour of property <see cref="Loaded"/>, assigning it <see cref="true"/>.</remarks>
	public Task LoadAsync();

	/// <summary>
	/// Unloads the Plugin.
	/// </summary>
	/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Unloaded.</returns>
	/// <remarks>This method should control the behaviour of property <see cref="Loaded"/>, assigning it <see cref="true"/>.</remarks>
	public Task UnloadAsync();
}