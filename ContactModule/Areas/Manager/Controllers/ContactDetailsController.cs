using ContactModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha.Manager;
using Piranha.Manager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactModule.Areas.Manager.Controllers
{
    [Area("manager")]
    [Route("/manager/contactdetails")]
    [Authorize(Policy = Permissions.ContactModule)]
    [ApiController]
    public class ContactDetailsController : Controller
    {
        private readonly ManagerLocalizer _localizer;
        public ContactDetailsController(ManagerLocalizer localizer)
        {
            _localizer = localizer;
        }

        [Route("load")]
        [HttpGet]
        [Authorize(Policy = Permissions.ContactModuleEdit)]
        public async Task<ContactDetailsEditModel> LoadAsync()
        {
            return new ContactDetailsEditModel 
            { 
                Profile = new Profile
                {
                    Name = "Chris",
                    Aka = "Gangster Geek",
                    Intro = "Software & Web Developer"
                },
                ContactInfo = new ContactInfo
                {
                    Email = "test@test.com",
                    UkPhone = "01745 255 255",
                    UsaPhone = "",
                    Address = "North Wales Coast"
                },
                OpeningTimes =  new OpeningTimes
                {
                    Monday = new OpeningTime { Open = "9am", Close = "5pm"},
                    Tuesday = new OpeningTime { Open = "9am", Close = "5pm"},
                    Wednesday = new OpeningTime { Open = "9am", Close = "5pm"},
                    Thursday = new OpeningTime { Open = "9am", Close = "5pm"},
                    Friday = new OpeningTime { Open = "9am", Close = "5pm"},
                    Saturday = new OpeningTime { Open = "9am", Close = "1pm"},
                    Sunday = new OpeningTime { Open = "Closed", Close = "Closed" },
                }
            };
        }

        [Route("save")]
        [HttpPost]
        [Authorize(Policy = Permissions.ContactModuleAdd)]
        public async Task<ContactDetailsEditModel> SaveAsync(ContactDetailsEditModel model)
        {
            try
            {
                // Save Model Accordingly
                var vuePassedModel = model;
                model.Status = new StatusMessage
                {
                    Type = StatusMessage.Success,
                    Body = _localizer.Page["Contact Details Saved!"]
                };
            }
            catch
            {
                model.Status = new StatusMessage
                {
                    Type = StatusMessage.Error,
                    Body = _localizer.Page["Could Not Save Contact Details!"]
                };
            }

            return model;
        }
    }
}
