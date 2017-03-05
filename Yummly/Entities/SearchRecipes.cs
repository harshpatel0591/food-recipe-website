using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SearchRecipes
    {
        public Criteria criteria { get; set; }
        public List<Matches> matches { get; set; }
        public Attribution attribution { get; set; } 

    }

    public class Criteria
    {
        public string terms { get; set; }
        public string allowedIngredients { get; set; }
        public string excludedIngredients { get; set; }
    }

    public class Matches
    {
        public string sourceDisplayName { get; set; }
        public List<string> ingredients { get; set; }

        public string id { get; set; }
        public List<string> smallImageUrls { get; set; }

        public string smallImageUrl { get; set; }
        public string recipeName { get; set; }
        public string totalTimeInSeconds { get; set; }
        public string rating { get; set; }


    }


}
