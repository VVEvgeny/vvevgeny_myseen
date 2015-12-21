﻿using System;
using System.Linq;
using MySeenLib;
using MySeenWeb.Add_Code;
using MySeenWeb.Models.OtherViewModels;
using MySeenWeb.Models.Tables;

namespace MySeenWeb.Models.TablesLogic
{
    public class UserCreditsLogic : UserCredits
    {
        private readonly ApplicationDbContext _ac;
        public string ErrorMessage;
        private UserCredits _userCredits;

        public UserCreditsLogic()
        {
            ErrorMessage = string.Empty;
            _ac = new ApplicationDbContext();
            _userCredits = new UserCredits();
        }

        public string GetNew(string userName, string userAgent)
        {
            var user = _ac.Users.First(u => u.UserName == userName);
            UserId = user.Id;
            User = user;
            DateTo = DateTime.Now.AddDays(14);
            PrivateKey = Md5Tools.Get(User.Email.ToLower() + userAgent + User.UniqueKey.ToLower());
            if (Exists(PrivateKey)) Delete(PrivateKey);
            Add();                
            return PrivateKey;
        }
        public void Remove(string userId, string userAgent)
        {
            var user = _ac.Users.First(u => u.Id == userId);
            PrivateKey = Md5Tools.Get(user.Email.ToLower() + userAgent + user.UniqueKey.ToLower());
            Delete(PrivateKey);
        }

        private bool Exists(string privateKey)
        {
            return _ac.UserCredits.Any(u => u.PrivateKey == privateKey);
        }
        private bool Add()
        {
            try
            {
                _ac.UserCredits.Add(this);
                _ac.SaveChanges();
            }
            catch (Exception e)
            {
                ErrorMessage = Resource.ErrorWorkWithDB + "=" + e.Message;
                return false;
            }
            return true;
        }
        public string UserName
        {
            get { return _userCredits.User.UserName; }
        }
        public bool Verify(string privateKey, string userAgent)
        {
            //LogSave.Save("", "", "", "верфикация privateKey", privateKey);
            //LogSave.Save("", "", "", "верфикация userAgent", userAgent);
            
            if (_ac.UserCredits.Any(u => u.PrivateKey == privateKey))
            {
                //LogSave.Save("", "", "", "верфикация поиск записи", "нашли!");

                _userCredits = _ac.UserCredits.First(u => u.PrivateKey == privateKey);

                if (_userCredits.DateTo < DateTime.Now)
                {
                    if (!Delete(_userCredits.PrivateKey)) return false;

                    ErrorMessage = "Date To Ended record removed";
                    return false;
                }
                //Проверим валидный ли ключик, принадлежит ли агенту который закодирован тут
                //_userCredits.User.Email.ToLower(),
                //userAgent
                //_userCredits.User.UniqueKey.ToLower()
                //LogSave.Save("", "", "", "верфикация", "перед проверкой МД5");

                //LogSave.Save("", "", "", "верфикация старый ключ", privateKey);
                //LogSave.Save("", "", "", "верфикация новый ключ", Md5Tools.Get(_userCredits.User.Email.ToLower() + userAgent + _userCredits.User.UniqueKey.ToLower()));
                if (Md5Tools.Get(_userCredits.User.Email.ToLower() + userAgent + _userCredits.User.UniqueKey.ToLower()) == _userCredits.PrivateKey) return true;

                return false;
            }
            else
            {
                ErrorMessage = "No UserCredits by this key";
            }
            return false;
        }

        private bool Delete(string privateKey)
        {
            try
            {
                if (_ac.UserCredits.Any(u => u.PrivateKey == privateKey))
                {
                    _ac.UserCredits.RemoveRange(_ac.UserCredits.Where(u => u.PrivateKey == privateKey));
                    _ac.SaveChanges();
                }
                else
                {
                    ErrorMessage = Resource.NoData;
                    return false;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = Resource.ErrorWorkWithDB + "=" + e.Message;
                return false;
            }
            return true;
        }

    }
}