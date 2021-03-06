﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MySeenLib;
using MySeenResources;
using MySeenWeb.Models.OtherViewModels;
using MySeenWeb.Models.TablesLogic;
using static MySeenLib.Defaults;

namespace MySeenWeb.Models
{
    public class HomeViewModelSettings
    {
        public bool HasPassword { get; set; }
        public int CountLogins { get; set; }
        public string Lang { get; set; }
        public IEnumerable<SelectListItem> LangList { get; set; }
        public string Rpp { get; set; }
        public string Markers { get; set; }
        public IEnumerable<SelectListItem> RppList { get; set; }
        public IEnumerable<SelectListItem> MarkersOnRoadsList { get; set; }
        public bool HaveData { get; set; }
        public IEnumerable<SelectListItem> Themes { get; set; }
        public string Theme { get; set; }
        public string EnableAnimation { get; set; }
        public IEnumerable<SelectListItem> EnableAnimationList { get; set; }

        public int Version { get; set; }
        public string ResourceVersion { get; set; }

        public HomeViewModelSettings(string userId, int lang, int rpp, int theme, int markersOnRoads, int enableAnimation)
        {
            Version = Versions.Version;
            ResourceVersion = Resource.ResourceVersionNum;

            if (string.IsNullOrEmpty(userId))
            {
                Lang = lang.ToString();
                Rpp = RecordPerPage.GetId(rpp.ToString()).ToString();
                Theme = theme.ToString();
                Markers = markersOnRoads.ToString();
                EnableAnimation = enableAnimation.ToString();
            }
            else
            {
                using (var ac = new ApplicationDbContext())
                {
                    var user = ac.Users.First(u => u.Id == userId);

                    Lang = Languages.GetIdDb(user.Culture).ToString();
                    Rpp = user.RecordPerPage.ToString();
                    Markers = user.MarkersOnRoads.ToString();
                    HasPassword = user.PasswordHash != null;
                    Theme = user.Theme.ToString();
                    EnableAnimation = user.EnableAnimation.ToString();

                    var userLogic = new UserLogic();
                    CountLogins = userLogic.GetCountLogins(userId);
                }
            }

            MarkersOnRoadsList =
                EnabledDisabled.GetAll()
                    .Select(
                        sel =>
                            new SelectListItem
                            {
                                Text = sel,
                                Value = EnabledDisabled.GetId(sel).ToString(),
                                Selected = EnabledDisabled.GetId(sel).ToString() == Markers
                            })
                    .ToList();

            EnableAnimationList = EnabledDisabled.GetAll()
                .Select(
                    sel =>
                        new SelectListItem
                        {
                            Text = sel,
                            Value = EnabledDisabled.GetId(sel).ToString(),
                            Selected = EnabledDisabled.GetId(sel).ToString() == Markers
                        })
                .ToList();

            LangList =
                Languages.GetAll()
                    .Select(
                        sel =>
                            new SelectListItem
                            {
                                Text = sel,
                                Value = Languages.GetId(sel).ToString(),
                                Selected = Languages.GetId(sel).ToString() == Lang
                            })
                    .ToList();

            RppList =
                RecordPerPage.GetAll()
                    .Select(
                        sel =>
                            new SelectListItem
                            {
                                Text = sel,
                                Value = RecordPerPage.GetId(sel).ToString(),
                                Selected = RecordPerPage.GetId(sel).ToString() == Rpp
                            })
                    .ToList();

            Themes =
                Defaults.Themes.GetAll()
                    .Select(
                        sel =>
                            new SelectListItem
                            {
                                Text = sel,
                                Value = Defaults.Themes.GetId(sel).ToString(),
                                Selected = Defaults.Themes.GetId(sel).ToString() == Theme
                            })
                    .ToList();
        }
    }
}