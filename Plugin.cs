using System;
using System.Threading.Tasks;

/**
 *	Plugin.cs
 *	Licensed by YumeChan-DT (Nodsoft ES) under GNU-LGPLv3
 **/

namespace Nodsoft.YumeChan.PluginBase
{
	/// <summary>
	/// Defines a Plugin Manifest for YumeChan
	/// </summary>
	public abstract class Plugin : IPlugin
	{
		/// <summary>
		/// Defines Plugin's Current Version.
		/// </summary>
		/// <remarks>
		/// It is best practice to mirror the Assembly's Versionning, using <c>typeof(PluginManifestClass).Assembly.GetName().Version</c>.
		/// </remarks>
		public virtual Version PluginVersion { get; protected set; }

		/// <summary>
		/// Reflects the Plugin's Assembly Name.
		/// </summary>
		public string PluginAssemblyName { get; private set; }

		/// <summary>
		/// Defines Plugin's Display Name.
		/// </summary>
		public abstract string PluginDisplayName { get; }

		/// <summary>
		/// Controls whether Plugin is shown when listing active Plugins.
		/// </summary>
		/// <remarks>
		/// Bot Owner & Operators, and Verified Server Admins, may be able to bypass <see cref="PluginStealth"/> Property.
		/// It is only intended to keep the plugin's existence unknown of the general public.
		/// </remarks>
		/// <value><see cref="false"/> defines the Plugin as visible ; <see cref="true"/> defines the Plugin as Stealth-ed.</value>
		public abstract bool PluginStealth { get; }

		/// <summary>
		/// Defines if the Plugin has been Loaded by the Bot.
		/// </summary>
		/// <remarks>
		/// It is best practice to let this property be handled by <see cref="LoadPlugin()"/> and <see cref="UnloadPlugin()"/>.
		/// </remarks>
		public bool PluginLoaded { get; protected set; }

		protected Plugin()
		{
			PluginVersion = GetType().Assembly.GetName().Version;
			PluginAssemblyName = GetType().Assembly.GetName().Name;
		}

		/// <summary>
		/// Initializes the Plugin.
		/// </summary>
		/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Loaded.</returns>
		/// <remarks>This method should control the behaviour of property <see cref="PluginLoaded"/>, assigning it <see cref="true"/>.</remarks>
		public virtual Task LoadPlugin()
		{
			PluginLoaded = true;
			return Task.CompletedTask;
		}

		/// <summary>
		/// Unloads the Plugin.
		/// </summary>
		/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Unloaded.</returns>
		/// <remarks>This method should control the behaviour of property <see cref="PluginLoaded"/>, assigning it <see cref="true"/>.</remarks>
		public virtual Task UnloadPlugin()
		{
			PluginLoaded = false;
			return Task.CompletedTask;
		}
	}
}
