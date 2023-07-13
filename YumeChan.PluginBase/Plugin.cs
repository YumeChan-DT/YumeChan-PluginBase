using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace YumeChan.PluginBase;

/// <summary>
/// Provides a base class for YumeChan plugin implementations.
/// </summary>
/// <inheritdoc cref="IPlugin" />
[PublicAPI]
public abstract class Plugin : IPlugin
{
	/// <inheritdoc />
	public string Version { get; }

	/// <inheritdoc />
	public string AssemblyName { get; }

	/// <inheritdoc />
	public abstract string DisplayName { get; }

	/// <inheritdoc />
	public virtual bool ShouldUseNetRunner => true;

	/// <inheritdoc />
	public virtual bool StealthMode => false;

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
