using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Piranha.AspNetCore;
using ContactModule;

public static class ContactModuleExtensions
{
    /// <summary>
    /// Adds the ContactModule module.
    /// </summary>
    /// <param name="serviceBuilder"></param>
    /// <returns></returns>
    public static PiranhaServiceBuilder UseContactModule(this PiranhaServiceBuilder serviceBuilder)
    {
        serviceBuilder.Services.AddContactModule();

        return serviceBuilder;
    }

    /// <summary>
    /// Uses the ContactModule module.
    /// </summary>
    /// <param name="applicationBuilder">The current application builder</param>
    /// <returns>The builder</returns>
    public static PiranhaApplicationBuilder UseContactModule(this PiranhaApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Builder.UseContactModule();

        return applicationBuilder;
    }

    /// <summary>
    /// Adds the ContactModule module.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <returns>The services</returns>
    public static IServiceCollection AddContactModule(this IServiceCollection services)
    {
        // Add the ContactModule module
        Piranha.App.Modules.Register<Module>();

        // Setup authorization policies
        services.AddAuthorization(o =>
        {
            // ContactModule policies
            o.AddPolicy(Permissions.ContactModule, policy =>
            {
                policy.RequireClaim(Permissions.ContactModule, Permissions.ContactModule);
            });

            // ContactModule add policy
            o.AddPolicy(Permissions.ContactModuleAdd, policy =>
            {
                policy.RequireClaim(Permissions.ContactModule, Permissions.ContactModule);
                policy.RequireClaim(Permissions.ContactModuleAdd, Permissions.ContactModuleAdd);
            });

            // ContactModule edit policy
            o.AddPolicy(Permissions.ContactModuleEdit, policy =>
            {
                policy.RequireClaim(Permissions.ContactModule, Permissions.ContactModule);
                policy.RequireClaim(Permissions.ContactModuleEdit, Permissions.ContactModuleEdit);
            });

            // ContactModule delete policy
            o.AddPolicy(Permissions.ContactModuleDelete, policy =>
            {
                policy.RequireClaim(Permissions.ContactModule, Permissions.ContactModule);
                policy.RequireClaim(Permissions.ContactModuleDelete, Permissions.ContactModuleDelete);
            });
        });

        // Return the service collection
        return services;
    }

    /// <summary>
    /// Uses the ContactModule.
    /// </summary>
    /// <param name="builder">The application builder</param>
    /// <returns>The builder</returns>
    public static IApplicationBuilder UseContactModule(this IApplicationBuilder builder)
    {
        return builder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new EmbeddedFileProvider(typeof(Module).Assembly, "ContactModule.assets.dist"),
            RequestPath = "/manager/contactmodule"
        });
    }

    /// <summary>
    /// Static accessor to ContactModule module if it is registered in the Piranha application.
    /// </summary>
    /// <param name="modules">The available modules</param>
    /// <returns>The ContactModule module</returns>
    public static Module ContactModule(this Piranha.Runtime.AppModuleList modules)
    {
        return modules.Get<Module>();
    }
}
