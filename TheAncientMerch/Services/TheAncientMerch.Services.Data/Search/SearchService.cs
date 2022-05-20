namespace TheAncientMerch.Services.Data.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using TheAncientMerch.Data.Common.Repositories;
    using TheAncientMerch.Data.Models;
    using TheAncientMerch.Web.ViewModels.Articles;
    using TheAncientMerch.Web.ViewModels.GreekDeitys;
    using TheAncientMerch.Web.ViewModels.Sculptures;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Sculpture> sculptureRepository;
        private readonly IDeletableEntityRepository<Article> articleRepository;
        private readonly IRepository<GreekDeity> greekDeityRepository;

        public SearchService(
            IDeletableEntityRepository<Sculpture> sculptureRepository,
            IDeletableEntityRepository<Article> articleRepository,
            IRepository<GreekDeity> greekDeityRepository)
        {
            this.sculptureRepository = sculptureRepository;
            this.articleRepository = articleRepository;
            this.greekDeityRepository = greekDeityRepository;
        }

        public IEnumerable<ArticleViewModel> SearchArticleByKeyword(string keyword)
        {
            var articlesView = this.articleRepository
               .All()
               .Where(x => x.Title.Contains(keyword))
            .Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ImageUrl = x.ImageUrl,
                UserId = x.AddedByUserId,
                CreatedOn = x.CreatedOn.ToString("f"),
                Username = x.AddedByUser.UserName,
            })
            .ToList();

            return articlesView;
        }

        public IEnumerable<DeityViewModel> SearchGreekDeityByKeyword(string username)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SculptureViewModel> SearcSculptureByKeyword(string keyword)
        {
            throw new System.NotImplementedException();
        }
    }
}
