namespace TheAncientMerch.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TheAncientMerch.Services.Data.Sculpture;
    using TheAncientMerch.Services.Data.SculptureMaterial;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    [Authorize]
    public class SculpturesController : Controller
    {
        private readonly ISculptureMaterialService sculptureMaterialService;

        private readonly ISculptureService sculptureService;

        public SculpturesController(
            ISculptureMaterialService sculptureMaterialService,
            ISculptureService sculptureService
            )
        {
            this.sculptureMaterialService = sculptureMaterialService;
            this.sculptureService = sculptureService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateSculptureInputModel
            {
                Materials = this.sculptureMaterialService.GetAllMaterials(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSculptureInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.GetId();

            await this.sculptureService.Create(model,userId);

            this.TempData["Message"] = "Sculpture created successfully.";

            return this.Redirect("/Sculptures/All");
        }

        public async Task<IActionResult> All([FromQuery] SculpturesQueryViewModel query)
        {
            var itemsPerPage = 6;
            var sculpturesQuery = await this.sculptureService.GetAllSculptures(query.PageNumber, itemsPerPage, query.Material, query.SculptureType, query.Color);

            return this.View(sculpturesQuery);
        }

        public IActionResult Sculpture(int id)
        {
            if (!this.sculptureService.ChekIfSculptureIdIsValid(id))
            {
                return this.BadRequest();
            }

            var sculpture = this.sculptureService.GetSculptureById(id);

            return this.View(sculpture);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.sculptureService.ChekIfSculptureIdIsValid(id))
            {
                return this.BadRequest();
            }

            var currentUser = this.User.GetId();
            var viewModel = new EditSculptureViewModel();
            var model = this.sculptureService.GetSculptureById(id);

            if (currentUser != model.UserId)
            {
                return this.Redirect($"/Sculptures/Sculpture/{id}");
            }

            viewModel.Id = model.Id;
            viewModel.ImageUrl = model.ImageUrl;
            viewModel.Name = model.Name;
            viewModel.Description = model.Description;
            viewModel.Weigth = model.Weigth;
            viewModel.Height = model.Height;
            viewModel.Width = model.Width;
            viewModel.Materials = this.sculptureMaterialService.GetAllMaterials();
            viewModel.Origin = model.Origin;
            viewModel.Price = model.Price;
            viewModel.UserId = model.UserId;


            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, EditSculptureViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Materials = this.sculptureMaterialService.GetAllMaterials();
                return this.View(model);
            }

            await this.sculptureService.EditSculptureAsync(model, id);

            this.TempData["Message"] = "Sculpture edited successfully.";

            return this.Redirect("/Sculptures/All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.sculptureService.DeleteSculptureAsync(id);
            this.TempData["Message"] = "Sculpture deleted successfully.";
            return this.Redirect("/Sculptures/All");
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            if (!this.sculptureService.ChekIfSculptureIdIsValid(id))
            {
                return this.BadRequest();
            }

            var userId = this.User.GetId();

            var viewModel = new BuySculptureFormModel
            {
                SculptureModel = this.sculptureService.GetSculptureForBuyViewModel(id, userId),
            };

            if (viewModel.SculptureModel == null)
            {
                this.TempData["Message"] = "Invalid sculpture.";
                return this.Redirect("/Sculptures/All");
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuySculptureFormModel model)
        {
            var userId = this.User.GetId();

            if (!this.ModelState.IsValid)
            {
                model.SculptureModel = this.sculptureService.GetSculptureForBuyViewModel(model.SculptureId, userId);
                return this.View(model);
            }

            await this.sculptureService.BuySculpture(model, userId);

            this.TempData["Message"] = "Thank you for your order! Delivery will be made within three working days!";

            return this.Redirect("/Sculptures/All");
        }
    }
}
