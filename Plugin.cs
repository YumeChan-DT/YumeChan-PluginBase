using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

/**
 *	Plugin.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under GNU-LGPLv3
 **/

namespace YumeChan.PluginBase
{
	/// <summary>
	/// Defines a Plugin Manifest for YumeChan
	/// </summary>
	public abstract class Plugin
	{
		/// <summary>
		/// Defines Plugin's Current Version.
		/// </summary>
		/// <remarks>
		/// It is best practice to mirror the Assembly's Versionning, using <c>typeof(PluginManifestClass).Assembly.GetName().Version</c>.
		/// </remarks>
		public virtual string PluginVersion { get; protected set; }

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
			Assembly assembly = GetType().Assembly;

			PluginVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			PluginAssemblyName = assembly.GetName().Name;
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


		/// <summary>
		/// Configures additional services in use by this Plugin, for use in Dependency Injection.
		/// </summary>
		public virtual IServiceCollection ConfigureServices(IServiceCollection services) => services;
	}
}
