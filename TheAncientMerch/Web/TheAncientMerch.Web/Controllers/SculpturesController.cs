﻿namespace TheAncientMerch.Web.Controllers
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

        public IActionResult Create()
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

            await this.SculptureService.Create(model);

            // TODo Redirect to recipi info page.
            return this.Redirect("/");
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
    }
}
