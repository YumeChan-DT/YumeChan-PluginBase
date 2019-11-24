﻿using System;
using System.Threading.Tasks;

/**
 *	IPlugin.cs
 *	Licensed by YumeChan-DT (Nodsoft ES) under GNU-LGPLv3
 **/

namespace Nodsoft.YumeChan.PluginBase
{
	/// <summary>
	/// Defines a Plugin Manifest for YumeChan
	/// </summary>
	/// <remarks>
	/// For easy setup and/or good practice, it is recommended to use the <see cref="Plugin"/> Abstract Class instead of the <see cref="IPlugin"/> Interface.
	/// </remarks>

	[Obsolete("Consider Using \"Plugin\" Abstract Class instead.")]
	public interface IPlugin
	{
		/// <summary>
		/// Defines Plugin's Current Version.
		/// </summary>
		/// <remarks>
		/// It is best practice to mirror the Assembly's Versionning, using <code>typeof(PluginManifestClass).Assembly.GetName().Version</code>.
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
		/// Bot Owner & Operators, and Verified Server Admins, may be able to bypass <see cref="PluginStealth"/> Property.
		/// It is only intended to keep the plugin's existence unknown of the general public.
		/// </remarks>
		/// <value><see cref="false"/> defines the Plugin as visible ; <see cref="true"/> defines the Plugin as Stealth-ed.</value>
		bool PluginStealth { get; }

		/// <summary>
		/// Defines if the Plugin has been Loaded by the Bot.
		/// </summary>
		/// <remarks>
		/// It is best practice to let the behaviour of this property be handled by <see cref="LoadPlugin()"/> and <see cref="UnloadPlugin()"/>.
		/// </remarks>
		bool PluginLoaded { get; }

		/// <summary>
		/// Initializes the Plugin.
		/// </summary>
		/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Loaded.</returns>
		/// <remarks>This method should control the behaviour of property <see cref="PluginLoaded"/>, assigning it <see cref="true"/>.</remarks>
		Task LoadPlugin();

		/// <summary>
		/// Unloads the Plugin.
		/// </summary>
		/// <returns><see cref="Task.CompletedTask"/> will note Plugin as Unloaded.</returns>
		/// <remarks>This method should control the behaviour of property <see cref="PluginLoaded"/>, assigning it <see cref="true"/>.</remarks>
		Task UnloadPlugin();
	}
}
