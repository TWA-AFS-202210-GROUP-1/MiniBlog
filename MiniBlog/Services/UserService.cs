﻿using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services;

public class UserService : IUserService
{
    private readonly IUserStore _userStore;

    public UserService(IUserStore userStore)
    {
        _userStore = userStore;
    }

    public User? RegisterUser(User user)
    {
        if (!_userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
        {
            _userStore.Save(user);
            return user;
        }

        return null;
    }

    public List<User> GetAllUsers()
    {
        return _userStore.GetAll();
    }

    public User? Update(User user)
    {
        var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
        if (foundUser != null)
        {
            foundUser.Email = user.Email;
        }

        return foundUser;
    }
}