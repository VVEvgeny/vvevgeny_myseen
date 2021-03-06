﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MySeenResources;
using MySeenWeb.Models.OtherViewModels;
using MySeenWeb.Models.TablesViews;

namespace MySeenWeb.Models
{
    public class HomeViewModelTrackEditor
    {
        public IEnumerable<SelectListItem> TypeList { get; set; }
        public bool NewTrack { get; set; }
        public int Id { get; set; }
        public RoadsView Data { get; set; }

        public HomeViewModelTrackEditor(string id, string userId)
        {
            var ac = new ApplicationDbContext();
            Id = string.IsNullOrEmpty(id) ? -1 : Convert.ToInt32(id);
            var typeValue = RoadTypes.Foot;
            NewTrack = !ac.Tracks.Any(t => t.UserId == userId && t.Id == Id); //Если пустое или с таким айди нет трека
            if (!NewTrack)
            {
                Data = ac.Tracks.AsNoTracking().Select(RoadsView.Map).First(t => t.UserId == userId && t.Id == Id);
                typeValue = (RoadTypes) Data.Type;
            }
            TypeList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Resource.Foot,
                    Value = ((int) RoadTypes.Foot).ToString(),
                    Selected = RoadTypes.Foot == typeValue
                },
                new SelectListItem
                {
                    Text = Resource.Car,
                    Value = ((int) RoadTypes.Car).ToString(),
                    Selected = RoadTypes.Car == typeValue
                },
                new SelectListItem
                {
                    Text = Resource.Bike,
                    Value = ((int) RoadTypes.Bike).ToString(),
                    Selected = RoadTypes.Bike == typeValue
                }
            };
        }
    }
}