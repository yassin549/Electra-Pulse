using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class RatingDL
    {
        static string[] Ratings = [
            "Very Poor",
            "Poor",
            "Needs Improvements",
            "Good",
            "Excellent"
        ];
        public static string[] GetRatings()
        {
            return Ratings;
        }
    }
}
