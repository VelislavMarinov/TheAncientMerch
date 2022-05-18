﻿namespace TheAncientMerch.Common
{
    public static class DataConstants
    {
        // Articles
        public const int ArticleTitleMinLength = 4;
        public const int ArticleTitleMaxLength = 64;
        public const int ArticleContentMinLength = 20;
        public const int ArticleContentMaxLength = 10000;

        // ArticlesCategory
        public const int ArticleCategoryNameMaxLength = 20;

        // Comment
        public const int CommentContentMaxLength = 1000;

        // ForumCategory Model
        public const int ForumCategoryNameMinLength = 4;
        public const int ForumCategoryNameMaxLength = 50;
        public const int ForumCategoryDescriptionMinLength = 8;
        public const int ForumCategoryDescriptionMaxLength = 200;

        // GreekDeity
        public const int GreekDeityNameMaxLength = 30;
        public const int GreekDeityDescriptionMaxLength = 20000;

        // HomeDecor
        public const int HomeDecorNameMaxLegth = 100;
        public const int HomeDecorDescriptionMaxLength = 10000;

        // origin for Sculpture and HomeDecor
        public const int OriginMaxLegth = 50;

        // HomeDecorMaterial
        public const int HomeDecorMaterialNameMaxLength = 50;

        // SculptureMaterial
        public const int SculptureMaterialNameMaxLength = 50;

        // Post Model
        public const int PostTitleMinLength = 4;
        public const int PostTitleMaxLength = 50;
        public const int PostContentMinLength = 8;
        public const int PostContentMaxLength = 4094;

        // Sculpture
        public const int SculptureNameMinLegth = 4;
        public const int SculptureNameMaxLegth = 100;
        public const int SculptureDescriptionMinLength = 20;
        public const int SculptureDescriptionMaxLength = 10000;

        // User: Username
        public const int UserNameMinLength = 4;
        public const int UserNameMaxLength = 20;

    }
}
