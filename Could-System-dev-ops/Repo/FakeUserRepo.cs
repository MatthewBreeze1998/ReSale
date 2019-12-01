﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeUserRepo : UserRepo

    {

        private List<UsersModel> _UserList;

        public FakeUserRepo()
        {
            _UserList = new List<UsersModel>()
            {
                new UsersModel() {UserId = 1,FirstName = "cameron", lastName = "charlton",Email = "charlton98@gmail.com", isActive = true, PurchaseAbility = true },
                new UsersModel() {UserId = 1,FirstName = "Shaun", lastName = "andrew",Email = "shaun_andrew@hotmail.com",isActive = false,  PurchaseAbility = false  },
                new UsersModel() {UserId = 1,FirstName = "danielle", lastName = "houston",Email = "Danielle@outlook.com",isActive = true,  PurchaseAbility = false}
            };
        }


        public UsersModel CreateUser(UsersModel users)
        {
            _UserList.Add(users);
            return users;
        }

        public UsersModel GetUserByName(String Name)
        {
            return _UserList.FirstOrDefault(x => Name.Contains(x.FirstName + " " + x.lastName));
        }


        public UsersModel GetUser(int id)
        {
            return _UserList.FirstOrDefault(x => id == x.UserId);
        }

        public IEnumerable<UsersModel> GetUser(int? UserId, string FirstName, string LastName, string Email, Boolean? isActive, Boolean? PurchaseAbility)
        {
            return _UserList.AsEnumerable<UsersModel>();
        }

        public IEnumerable<UsersModel> GetUserIsActive(Boolean Active)
        {
            return _UserList.Where(x => x.isActive == Active);
        }

        public  UsersModel SetActivity(int Id)
        {
            UsersModel activity = _UserList.FirstOrDefault(x => Id == x.UserId);
            activity.isActive = !activity.isActive;
            _UserList.Insert(_UserList.IndexOf(_UserList.FirstOrDefault(x => Id == x.UserId)), activity);
            return activity;
        }

        public UsersModel EditUser(UsersModel User)
        {
           
            _UserList[_UserList.IndexOf(_UserList.FirstOrDefault(x => x.UserId == User.UserId))] = User;

            return User;
        }
    }
}
