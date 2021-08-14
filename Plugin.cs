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
		public virtual string Version { get; protected set; }

		/// <summary>
		/// Reflects the Plugin's Assembly Name.
		/// </summary>
		public string AssemblyName { get; private set; }

		/// <summary>
		/// Defines Plugin's Display Name.
		/// </summary>
		public abstract string DisplayName { get; }

		/// <summary>
		/// Controls whether Plugin is shown when listing active Plugins.
		/// </summary>
		/// <remarks>
		/// Bot Owner & Operators, and Verified Server Admins, may be able to bypass <see cref="StealthMode"/> Property.
		/// It is only intended to keep the plugin's existence unknown of the general public.
		/// </remarks>
		/// <value><see cref="false"/> defines the Plugin as visible ; <see cref="true"/> defines the Plugin as Stealth-ed.</value>
		public virtual bool StealthMode { get; } = false;

		/// <summary>
		/// Defines if the Plugin has been Loaded by the Bot.
		/// </summary>
		/// <remarks>
		/// It is best practice to let this property be handled by <see cref="LoadAsync()"/> and <see cref="UnloadAsync()"/>.
		/// </remarks>
		public bool Loaded { get; protected set; }

		protected Plugin()
		{
			Assembly assembly = GetType().Assembly;

			Version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			AssemblyName = assembly.GetName().Name;
		}

		/// <summary>
		/// Initializes the Plugin.
		/// </summary>
		/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Loaded.</returns>
		/// <remarks>This method should control the behaviour of property <see cref="Loaded"/>, assigning it <see cref="true"/>.</remarks>
		public virtual Task LoadAsync()
		{
			Loaded = true;
			return Task.CompletedTask;
		}

		/// <summary>
		/// Unloads the Plugin.
		/// </summary>
		/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Unloaded.</returns>
		/// <remarks>This method should control the behaviour of property <see cref="Loaded"/>, assigning it <see cref="true"/>.</remarks>
		public virtual Task UnloadAsync()
		{
			Loaded = false;
			return Task.CompletedTask;
		}
	}
}
