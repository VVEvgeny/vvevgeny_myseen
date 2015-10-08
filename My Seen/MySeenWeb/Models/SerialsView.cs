﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Web.Mvc;
using MySeenLib;

namespace MySeenWeb.Models
{
    public class SerialsView : Serials
    {
        public static SerialsView Map(Serials model)
        {
            if (model == null) return new SerialsView();

            return new SerialsView
            {
                Id = model.Id,
                Name = model.Name,
                UserId = model.UserId,
                DateChange = model.DateChange,
                Genre = model.Genre,
                Rate = model.Rate,
                DateBegin=model.DateBegin,
                DateLast=model.DateLast,
                LastSeason=model.LastSeason,
                LastSeries=model.LastSeries
            };
        }
        public string GenreText
        {
            get
            {
                return LibTools.Genres.GetById(Genre);
            }
        }
        public string RateText
        {
            get
            {
                return LibTools.Ratings.GetById(Rate);
            }
        }
    }
}