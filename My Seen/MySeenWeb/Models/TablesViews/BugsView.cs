﻿using System.Linq;
using MySeenLib;
using MySeenWeb.Models.Tables;

namespace MySeenWeb.Models.TablesViews
{
    public class BugsView : Bugs
    {
        public static BugsView Map(Bugs model)
        {
            if (model == null) return new BugsView();
            return new BugsView
            {
                DateEnd = model.DateEnd,
                DateFound = model.DateFound,
                Id = model.Id,
                Text = model.Text,
                TextEnd = model.TextEnd,
                UserId = model.UserId,
                Complex = model.Complex,
                Version = model.Version
            };
        }
        public string ComplexText
        {
            get
            {
                return Defaults.Complexes.GetById(Complex);
            }
        }
        public string UserName
        {
            get
            {
                if (!string.IsNullOrEmpty(UserId))
                {
                    var ac = new ApplicationDbContext();
                    var firstOrDefault = ac.Users.FirstOrDefault(u => u.Id == UserId);
                    if (firstOrDefault != null)
                    {
                        string user = firstOrDefault.UserName;
                        if (string.IsNullOrEmpty(user)) return string.Empty;
                        if (user.Contains('@')) user = user.Remove(user.IndexOf('@'));
                        return user;
                    }
                }
                return string.Empty;
            }
        }
        public string DateEndText
        {
            get
            {
                return DateEnd != null ? DateEnd.Value.ToShortDateString() : string.Empty;
            }
        }
        public string DateFoundText
        {
            get { return DateFound.ToShortDateString(); }
        }
        public string VersionText
        {
            get
            {
                return Version != 0 ? Version.ToString() : string.Empty;
            }
        }

        public bool Ended
        {
            get { return !string.IsNullOrEmpty(TextEnd); }
        }
    }
}
