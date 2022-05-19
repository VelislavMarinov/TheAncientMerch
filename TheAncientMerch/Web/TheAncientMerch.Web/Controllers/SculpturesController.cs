namespace TheAncientMerch.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TheAncientMerch.Services.Data.Sculpture;
    using TheAncientMerch.Services.Data.SculptureMaterial;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SculpturesController : Controller
    {
        public SculpturesController(
            ISculptureMaterialService sculptureMaterialService,
            ISculptureService sculptureService
            )
        {
            this.SculptureMaterialService = sculptureMaterialService;
            this.SculptureService = sculptureService;
        }

        public ISculptureMaterialService SculptureMaterialService { get; }

        public ISculptureService SculptureService { get; }

        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateSculptureInputModel
            {
                Materials = this.SculptureMaterialService.GetAllMaterials(),
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

            await this.SculptureService.Create(model,userId);

            this.TempData["Message"] = "Sculpture created successfully.";

            // TODo Redirect to recipi info page.
            return this.Redirect("/Sculptures/All");
        }

        public async Task<IActionResult> All([FromQuery] SculpturesQueryViewModel query)
        {
            var itemsPerPage = 6;
            var sculpturesQuery = await this.SculptureService.GetAllSculptures(query.PageNumber, itemsPerPage, query.Material, query.SculptureType, query.Color);

            return this.View(sculpturesQuery);
        }

        public IActionResult Sculpture(int id)
        {
            var sculpture = this.SculptureService.GetSculptureById(id);

            return this.View(sculpture);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var currentUser = this.User.GetId();
            var viewModel = new EditSculptureViewModel();
            var model = this.SculptureService.GetSculptureById(id);

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
            viewModel.Materials = this.SculptureMaterialService.GetAllMaterials();
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
                model.Materials = this.SculptureMaterialService.GetAllMaterials();
                return this.View(model);
            }

            await this.SculptureService.EditSculptureAsync(model, id);

            this.TempData["Message"] = "Sculpture edited successfully.";

            return this.Redirect("/Sculptures/All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SculptureService.DeleteSculptureAsync(id);
            this.TempData["Message"] = "Sculpture deleted successfully.";
            return this.Redirect("/Sculptures/All");
        }

        
    }
}
