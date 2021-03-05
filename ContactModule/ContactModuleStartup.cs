using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Piranha.AspNetCore;
using ContactModule;

public static class ContactModuleStartup
{
    /// <summary>
    /// Uses the Contact Module.
    /// </summary>
    /// <param name="serviceBuilder">The service builder</param>
    /// <returns>The updated service builder</returns>
    public static PiranhaServiceBuilder UseContactModuleStartup(this PiranhaServiceBuilder serviceBuilder)
    {
        serviceBuilder.Services.AddContactModule();

        return serviceBuilder;
    }

    /// <summary>
    /// Uses the Contact Module.
    /// </summary>
    /// <param name="applicationBuilder">The application builder</param>
    /// <returns>The updated application builder</returns>
    public static PiranhaApplicationBuilder UseContactModuleStartup(this PiranhaApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Builder.UseContactModule();
        return applicationBuilder;
    }
}
