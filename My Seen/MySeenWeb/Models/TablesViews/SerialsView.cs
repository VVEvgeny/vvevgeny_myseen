﻿using System.Globalization;
using MySeenLib;
using MySeenWeb.Models.Tables;

namespace MySeenWeb.Models.TablesViews
{
    public class SerialsView : Serials
    {
        public string GenreText
        {
            get { return Defaults.Genres.GetById(Genre); }
        }

        public string RatingText
        {
            get { return Defaults.Ratings.GetById(Rating); }
        }

        public string GenreVal
        {
            get { return Genre.ToString(); }
        }

        public string RatingVal
        {
            get { return Rating.ToString(); }
        }

        public string YearText
        {
            get { return Year == 0 ? "" : Year.ToString(); }
        }

        public string SeasonSeries
        {
            get { return LastSeason + "-" + LastSeries; }
        }

        public string DateLastText
        {
            get { return DateLast.ToString(CultureInfo.CurrentCulture); }
        }

        public string DateBeginText
        {
            get { return DateBegin.ToString(CultureInfo.CurrentCulture); }
        }

        public static SerialsView Map(Serials model)
        {
            if (model == null) return new SerialsView();

            return new SerialsView
            {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                UserId = model.UserId,
                DateChange = UmtTime.From(model.DateChange),
                Genre = model.Genre,
                Rating = model.Rating,
                DateBegin = UmtTime.From(model.DateBegin),
                DateLast = UmtTime.From(model.DateLast),
                LastSeason = model.LastSeason,
                LastSeries = model.LastSeries,
                Shared = model.Shared
            };
        }
    }
}