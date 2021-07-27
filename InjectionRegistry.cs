using Microsoft.Extensions.DependencyInjection;



namespace YumeChan.PluginBase
{
	/// <summary>
	/// Startup class to register Plugin dependencies.
	/// </summary>
	public abstract class InjectionRegistry
	{
		/// <summary>
		/// Default ctor. This should remain open and parameterless, to get instantiated by the Core.
		/// </summary>
		public InjectionRegistry() { }

		/// <summary>
		/// Configures services for the current plugin.
		/// </summary>
		/// <remarks>
		/// This method gets called before Plugin Manifest instantiation.
		/// </remarks>
		/// <param name="services">Service Collection to register services with.</param>
		/// <returns>Service Collection with registered services.</returns>
		public abstract IServiceCollection ConfigureServices(IServiceCollection services);
	}
}
