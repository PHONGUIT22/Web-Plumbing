using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Claims;

namespace Web.Plumbing.Areas.User.TagHelpers
{
    public class UserPictureTagHelper : TagHelper
    {
        public string FileName { get; set; } = null!;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        
        public UserPictureTagHelper( SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            
            _signInManager = signInManager;
            _userManager = userManager;
            
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            // Check if the user is authenticated
            if (_signInManager.Context.User?.Identity?.IsAuthenticated == true)
            {
                // Try to get the 'identifier' claim safely
                var claim = _signInManager.Context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (claim != null)
                {
                    var signedInUsername = claim.Value;
                    var user = await _userManager.FindByNameAsync(signedInUsername);

                    if (user != null && !string.IsNullOrEmpty(user.FileName))
                    {
                        // Set the user-specific image
                        output.Attributes.SetAttribute("src", $"/images/{user.FileName}");
                    }
                    else
                    {
                        // Fallback to default image if user or FileName is missing
                        output.Attributes.SetAttribute("src", "/images/default.png");
                    }
                }
                else
                {
                    // If no identifier claim exists, fallback to default image
                    output.Attributes.SetAttribute("src", "/images/default.png");
                }
            }
            else
            {
                // If user is not authenticated, fallback to default image
                output.Attributes.SetAttribute("src", "/images/default.png");
            }
        }
    }
}
