using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDLibrary.UI.Util
{
    public class Utilities
    {
        public static IEnumerable<SelectListItem> SetDVDItems(IEnumerable<DVD> dvds)
        {
            var DVDItems = new List<SelectListItem>();
            foreach (var dvd in dvds)
            {
                DVDItems.Add(new SelectListItem()
                {
                    Value = dvd.Id.ToString(),
                    Text = dvd.Title
                });
            }
            return DVDItems;
        }

        public static IDictionary<int, string> PopulateRatingsDictionary()
        {
            var mpaaRatings = new Dictionary<int, string>();
            var mpaaValues = new List<int>();
            var mpaaNames = Enum.GetNames(typeof(MPAARating));

            foreach (var value in Enum.GetValues(typeof(MPAARating)))
            {
                mpaaValues.Add((int)value);
            }
            if (mpaaValues.Count == mpaaNames.Length)
            {
                for (int i = 0; i < mpaaValues.Count; i++)
                {
                    if (!mpaaRatings.ContainsKey(mpaaValues[i]))
                        mpaaRatings.Add(mpaaValues[i], mpaaNames[i]);
                }
            }
            else {
                throw new InvalidDataException("Problem parsing MPAA rating id/value pairs!");
            }

            return mpaaRatings;
        }
    }
}