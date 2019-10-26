using System;
using System.Threading.Tasks;

/**
 *	IPlugin.cs
 *	Licensed by YumeChan-DT (Nodsoft ES) under GNU-GPLv3
 **/

namespace Nodsoft.YumeChan.PluginBase
{
	/// <summary>
	/// Defines a Plugin Manifest for YumeChan
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// Defines Plugin's Current Version.
		/// </summary>
		/// <remarks>
		/// It is best practice to mirror the Assembly's Versionning, using <c>typeof(PluginManifestClass).Assembly.GetName().Version</c>.
		/// </remarks>
		Version PluginVersion { get; }

		/// <summary>
		/// Defines Plugin's Display Name.
		/// </summary>
		string PluginDisplayName { get; }

		/// <summary>
		/// Controls whether Plugin is shown when listing active Plugins.
		/// </summary>
		/// <remarks>
		/// Bot Owner & Operators, and Verified Server Admins, may be able to bypass <c>PluginStealth</c> Property.
		/// It is only intended to keep the plugin's existence unknown of the general public.
		/// </remarks>
		/// <value><c>false</c> defines the Plugin as visible ; <c>true</c> defines the Plugin as Stealth-ed.</value>
		bool PluginStealth { get; }

		/// <summary>
		/// Defines if the Plugin has been Loaded by the Bot.
		/// </summary>
		/// <remarks>
		/// It is best practice to let the behaviour of this property be handled by <c>LoadPlugin()</c> and <c>UnloadPlugin()</c>.
		/// </remarks>
		bool PluginLoaded { get; }

		/// <summary>
		/// Initializes the Plugin.
		/// </summary>
		/// <returns><c>Task.CompletedTask</c> will note Plugin as Loaded.</returns>
		/// <remarks>This method should control the behaviour of property <c>PluginLoaded</c>, assigning it <c>true</c>.</remarks>
		Task LoadPlugin();

		/// <summary>
		/// Unloads the Plugin.
		/// </summary>
		/// <returns><c>Task.CompletedTask</c> will note Plugin as Unloaded.</returns>
		/// <remarks>This method should control the behaviour of property <c>PluginLoaded</c>, assigning it <c>false</c>.</remarks>
		Task UnloadPlugin();
	}
}
