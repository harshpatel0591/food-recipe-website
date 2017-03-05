using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class PopularCuisinesBL
    {
        public static DataSet GetPopularCuisines()
        {
            return PopularCuisinesDL.GetPopularCuisines();
        }

    }
}
