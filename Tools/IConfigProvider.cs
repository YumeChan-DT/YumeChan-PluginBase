using System.IO;


namespace YumeChan.PluginBase.Tools
{
	/// <summary>
	/// Provides a simple, Interface-based Config Tool, for Plugins.
	/// </summary>
	/// <typeparam name="T"><see cref="interface"/> with to-be-used Config Properties</typeparam>
	public interface IConfigProvider<T> where T : class
	{
		/// <summary>
		/// Config Interface. Config changes are effected by getting & setting values to these variables.
		/// </summary>
		/// <remarks>
		/// Do not forget to properly set your access modifiers & scopes. These will serve as foundation for the Config Tool.
		///
		/// Also don't forget to populate your Properties' defaults, to programatically create the Config File.
		/// Use <see cref="string.Empty"/> if a Default is, or must be, Empty. Null-coalescing assignment is what you'll be looking for, when creating the defaults.
		/// </remarks>
		T Configuration { get; set; }

		/// <summary>
		/// Get-only Property pointing to the Config File itself.
		/// </summary>
		FileInfo ConfigFile { get; }

		/// <summary>
		/// Initialization Method for the Config File. Use this before attempting access on <see cref="Configuration"/>.
		/// </summary>
		/// <param name="filename">Config File's expected filename.</param>
		/// <returns>Config-ready Interface, mirrored on <see cref="Configuration"/>.</returns>
		T InitConfig(string filename);
	}
}
