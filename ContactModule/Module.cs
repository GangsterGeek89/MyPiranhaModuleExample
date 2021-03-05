using Piranha;
using Piranha.Extend;
using Piranha.Manager;
using Piranha.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactModule
{
    public class Module : IModule
    {
        private readonly List<PermissionItem> _permissions = new List<PermissionItem>
        {
            new PermissionItem { Name = Permissions.ContactModule, Title = "List ContactModule content", Category = "ContactModule", IsInternal = true },
            new PermissionItem { Name = Permissions.ContactModuleAdd, Title = "Add ContactModule content", Category = "ContactModule", IsInternal = true },
            new PermissionItem { Name = Permissions.ContactModuleEdit, Title = "Edit ContactModule content", Category = "ContactModule", IsInternal = true },
            new PermissionItem { Name = Permissions.ContactModuleDelete, Title = "Delete ContactModule content", Category = "ContactModule", IsInternal = true }
        };

        /// <summary>
        /// Gets the module author
        /// </summary>
        public string Author => "Gangster Geek";

        /// <summary>
        /// Gets the module name
        /// </summary>
        public string Name => "Manager Module Example";

        /// <summary>
        /// Gets the module version
        /// </summary>
        public string Version => Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the module description
        /// </summary>
        public string Description => "";

        /// <summary>
        /// Gets the module package url
        /// </summary>
        public string PackageUrl => "";

        /// <summary>
        /// Gets the module icon url
        /// </summary>
        public string IconUrl => "/manager/PiranhaModule/piranha-logo.png";

        public void Init()
        {
            // Register permissions
            foreach (var permission in _permissions)
            {
                App.Permissions["ContactModule"].Add(permission);
            }

            // Add manager menu items
            Menu.Items.Add(new MenuItem
            {
                InternalId = "ContactDetails",
                Name = "Contact Details",
                Css = "fas fa-box"
            });
            Menu.Items["ContactDetails"].Items.Add(new MenuItem
            {
                InternalId = "ContactDetailsEdit",
                Name = "Edit",
                Route = "~/manager/contactdetails",
                Policy = Permissions.ContactModule,
                Css = "fas fa-box"
            });
        }
    }
}
