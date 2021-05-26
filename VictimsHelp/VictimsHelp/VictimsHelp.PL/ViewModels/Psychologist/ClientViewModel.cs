using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.User;

namespace VictimsHelp.PL.ViewModels.Psychologist
{
    public class ClientViewModel
    {
        public UserViewModel User { get; set; }
        public OrganizeEventModel OrganizeEventModel { get; set; }
    }
}
