﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Globalization;
using System.Threading;
using Newtonsoft.Json;

namespace MySeenLib
{
    public static class CultureInfoTool
    {
        public static string CoockieCultureKey = "_culture";
        public static class Cultures
        {
            private static string eng = "en";
            private static string rus = "ru";
            public static string English
            {
                get
                {
                    return eng;
                }
            }
            public static string Russian
            {
                get
                {
                    return rus;
                }
            }
        }
        public static string GetCulture()
        {
            return Thread.CurrentThread.CurrentUICulture.ToString();
        }
        public static bool SetCulture(string cult)
        {
            if (GetCulture() != cult)
            {
                //Thread.CurrentThread.CurrentCulture = new CultureInfo(cult);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cult);
                return true;
            }
            return false;
        }

    }
    public static class MySeenWebApi
    {
        public static string ApiHost = @"https://localhost:44300";
        public static string ApiUsers = @"/api/ApiUsers/";
        public static string ApiSync = @"/api/ApiSync/";

        public enum SyncModesApiUsers
        {
            isUserExists = 1
        }
        public enum SyncModesApiData
        {
            GetAll = 1,
            GetNew = 2,
            PostNewUpdatedDeleted = 3,
            GetNewUpdatedDeleted = 4
        }
        public class SyncJsonAnswer
        {
            public enum Values
            {
                Ok = 1,
                NoData = 2,
                BadRequestMode = 3,
                UserNotExist = 4,
                NewDataRecieved = 5
            }
            [JsonProperty("Value")]
            public Values Value { get; set; }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public class SyncJsonData
        {
            [JsonProperty("IsFilm")]
            public bool IsFilm { get; set; }
            [JsonProperty("Id")]
            public int? Id { get; set; }
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Genre")]
            public int Genre { get; set; }
            [JsonProperty("Rate")]
            public int Rate { get; set; }
            [JsonProperty("DateSee")]
            public DateTime DateSee { get; set; }
            [JsonProperty("DateChange")]
            public DateTime? DateChange { get; set; }
            [JsonProperty("isDeleted")]
            public bool? isDeleted { get; set; }

            //serials
            [JsonProperty("LastSeason")]
            public int LastSeason { get; set; }
            [JsonProperty("LastSeries")]
            public int LastSeries { get; set; }
            [JsonProperty("DateLast")]
            public DateTime DateLast { get; set; }
            [JsonProperty("DateBegin")]
            public DateTime DateBegin { get; set; }
        }
        public static IEnumerable<SyncJsonData> GetResponse(string data)
        {
            return JsonConvert.DeserializeObject<IEnumerable<SyncJsonData>>(data);
        }
        public static string SetResponse(IEnumerable<SyncJsonData> data)
        {
            return JsonConvert.SerializeObject(data);
        }
        public static SyncJsonAnswer GetResponseAnswer(string data)
        {
            SyncJsonAnswer answer = null;
            try
            {
                answer = JsonConvert.DeserializeObject<SyncJsonAnswer>(data);
            }
            catch
            {

            }
            return answer;
        }
    }
    public static class Defaults
    {
        public abstract class ListStringBase
        {
            public abstract void Load();
            public List<string> All;
            public List<string> GetAll()
            {
                if (All == null) Load();
                return All;
            }

            public int GetId(string _str)
            {
                if (All == null) Load();
                return All.IndexOf(_str);
            }
            public string GetById(int _id)
            {
                if (All == null) Load();
                if (_id >= All.Count) return "";
                return All[_id];
            }
            public int GetMaxId()
            {
                if (All == null) Load();
                return All.Count - 1;
            }
            public string GetMaxValue()
            {
                if (All == null) Load();
                if (All.Count == 0) return "";
                return All[GetMaxId()];
            }
        }
        public class GenresBase : ListStringBase
        {
            public override void Load()
            {
                if (All == null)
                {
                    All = new List<string>();
                    All.Add(Resource.GenreThriller);
                    All.Add(Resource.GenreDocumentary);
                    All.Add(Resource.GenreDrama);
                    All.Add(Resource.GenreComedy);
                    All.Add(Resource.GenreConcert);
                    All.Add(Resource.GenreCartoon);
                    All.Add(Resource.GenreHorror);
                    All.Add(Resource.GenreFantastic);
                }
            }
        }
        public class RatingsBase : ListStringBase
        {
            public override void Load()
            {
                if (All == null)
                {
                    All = new List<string>();
                    All.Add("1");
                    All.Add("2");
                    All.Add("3");
                    All.Add("4");
                    All.Add("5");
                    All.Add("6");
                    All.Add("7");
                    All.Add("8");
                    All.Add("9");
                    All.Add("10");
                }
            }
        }
        public class CategoryBase : ListStringBase
        {
            public static int FilmIndex = 0;
            public static int SerialIndex = 1;
            public override void Load()
            {
                if (All == null)
                {
                    All = new List<string>();
                    All.Add(Resource.Films);
                    All.Add(Resource.Serials);
                }
            }
        }
        public class LanguagesBase : ListStringBase
        {
            public override void Load()
            {
                if (All == null)
                {
                    All = new List<string>();
                    All.Add(Resource.English);
                    All.Add(Resource.Russian);
                }
            }
            public int GetIdDB(string s)
            {
                if (s == CultureInfoTool.Cultures.English) return All.IndexOf(Resource.English);
                return All.IndexOf(Resource.Russian);
            }
            public string GetValDB(int i)
            {
                if (All[i] == Resource.English) return CultureInfoTool.Cultures.English;
                return CultureInfoTool.Cultures.Russian;
            }
        }

        public static GenresBase Genres = new GenresBase();
        public static RatingsBase Ratings = new RatingsBase();
        public static CategoryBase Categories = new CategoryBase();
        public static LanguagesBase Languages = new LanguagesBase();

        public static void ReloadResources()
        {
            Genres.All = null;
            Genres.Load();
            Ratings.All = null;
            Ratings.Load();
            Categories.All = null;
            Categories.Load();
            Languages.All = null;
            Languages.Load();
        }
    }
    public static class Validations
    {
        public static bool ValidateName(ref string message, string filmName)
        {
            if (filmName.Length < 1)
            {
                message = Resource.ShortUserName;
                return false;
            }
            return true;
        }
        public static bool ValidateUserName(ref string message, string userName)
        {
            if (userName.Length < 5)
            {
                message = Resource.ShortUserName;
                return false;
            }
            return true;
        }
        public static bool ValidateEmail(ref string message, string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                message = Resource.EmailIncorrect;
                return false;
            }
            return true;
        }
        public static bool ValidatePassword(ref string message, string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                message = Resource.PasswordsNotEqual;
                return false;
            }
            if (password.Length < 6)
            {
                message = Resource.PasswordLength;
                return false;
            }
            if (password.Contains("0") || password.Contains("1") || password.Contains("2") || password.Contains("3") || password.Contains("4") || password.Contains("5") || password.Contains("6") || password.Contains("7") || password.Contains("8") || password.Contains("9"))
            {
                //Потом мож какие другие контроли
            }
            else
            {
                message = Resource.PasswordNOTContainsDigit;
                return false;
            }
            return true;
        }
    }
}
