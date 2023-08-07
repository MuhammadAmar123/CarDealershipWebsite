﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarDealershipWebsite.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CarDealershipWebsiteUser class
public class CarDealershipWebsiteUser : IdentityUser
{
    [Required] // requires user to fill in 
    public string FirstName { get; set; }
    [Required] // requires user to fill in
    public string LastName { get; set; }
}

