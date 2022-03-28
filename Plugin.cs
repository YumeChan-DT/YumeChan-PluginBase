using System;
using System.Reflection;
using System.Threading.Tasks;

/**
 *	Plugin.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under GNU-LGPL v2.1
 **/

namespace YumeChan.PluginBase;

/// <inheritdoc cref="IPlugin" />
public abstract class Plugin : IPlugin
{
	/// <inheritdoc />
	public virtual string Version { get; protected set; }

	/// <inheritdoc />
	public string AssemblyName { get; private set; }

	/// <inheritdoc />
	public abstract string DisplayName { get; }

	/// <inheritdoc />
	public virtual bool StealthMode { get; } = false;

	/// <inheritdoc />
	public bool Loaded { get; protected set; }

	protected Plugin()
	{
		Assembly assembly = GetType().Assembly;

		Version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "1.0.0";
		AssemblyName = assembly.GetName().Name ?? throw new("Assembly name not found");
	}

	/// <inheritdoc />
	public virtual Task LoadAsync()
	{
		Loaded = true;
		return Task.CompletedTask;
	}

	/// <inheritdoc />
	public virtual Task UnloadAsync()
	{
		Loaded = false;
		return Task.CompletedTask;
	}
}
