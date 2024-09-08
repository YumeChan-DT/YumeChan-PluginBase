using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;

/*
 *	Plugin.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

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
	public virtual string? Description { get; }
	
	/// <inheritdoc />
	public virtual string? Author { get; }
	
	/// <inheritdoc />
	public virtual string? AuthorContact { get; }
	
	/// <inheritdoc />
	public virtual Uri? ProjectHomepage { get; }
	
	/// <inheritdoc />
	public virtual Uri? SourceCodeRepository { get; }
	
	/// <inheritdoc />
	public virtual Uri? IconUri { get; }
	
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
		Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
		Author = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
		
		IconUri = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
			.FirstOrDefault(static x => x.Key is "IconUri" or "PackageIconUri")?.Value is { } iconUri ? new Uri(iconUri) : null;
		
		AuthorContact = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
			.FirstOrDefault(static x => x.Key is "AuthorContact" or "PackageAuthorContact")?.Value;
		
		ProjectHomepage = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
			.FirstOrDefault(static x => x.Key is "ProjectHomepage" or "PackageProjectUrl")?.Value is { } projectHomepage ? new Uri(projectHomepage) : null;
		
		SourceCodeRepository = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
			.FirstOrDefault(static x => x.Key is "SourceCodeRepository" or "RepositoryUrl")?.Value is { } sourceCodeRepository ? new Uri(sourceCodeRepository) : null;
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
