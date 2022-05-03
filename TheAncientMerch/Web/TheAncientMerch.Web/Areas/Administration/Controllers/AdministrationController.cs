namespace TheAncientMerch.Web.Areas.Administration.Controllers
{
    using TheAncientMerch.Common;
    using TheAncientMerch.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
