using Microsoft.AspNetCore.Mvc.Rendering;

namespace VictimsHelp.PL.ViewModels.User
{
    public class UserEditorViewModel
    {
        public UserViewModel User { get; set; }
        public SelectList RolesSelectList { get; set; }
    }
}
