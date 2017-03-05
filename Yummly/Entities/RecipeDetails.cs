using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RecipeDetails
    {
        public string totalTime { get; set; }
        public string name { get; set; }

        public Source source { get; set; }
        public List<Images> images { get; set; }

        public string id { get; set; }
        public List<string> ingredientLines { get; set; }

        //public string IngredientsCount { get; set; }
        public Attribution attribution { get; set; }

        public string rating { get; set; }


    }

    public class IngredientLines
    {
        public string ingredients { get; set; }
    }

    public class Attribution
    {
        public string html { get; set; }
        public string url { get; set; }

        public string text { get; set; }
        public string logo { get; set; }

    }

    public class Source
    {
        public string sourceDisplayName { get; set; }
        public string sourceSiteUrl { get; set; }
        public string sourceRecipeUrl { get; set; }
    }

    public class Images
    {
        public string hostedSmallUrl { get; set; }

        public string hostedMediumUrl { get; set; }

        public string hostedLargeUrl { get; set; }

       
    }


}
