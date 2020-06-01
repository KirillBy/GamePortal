﻿using Kbalan.TouchType.Logic.Dto;
using System;
using System.Collections.Generic;

namespace Kbalan.TouchType.Logic.Services
{
    /// <summary>
    /// Service for User
    /// </summary>
    public interface IUserService : IDisposable
    {
        /// <summary>
        /// Return full information(with statistic and settings) about all users
        /// </summary>
        /// <returns>All users</returns>
        IEnumerable<UserSettingStatisticDto> GetAll();

        /// <summary>
        /// Return full information(with statistic and settings) about user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>user</returns>
        UserSettingStatisticDto GetById(int id);

        /// <summary>
        /// Add new user 
        /// </summary>
        /// <param name="model">New user</param>
        /// <returns>New registered user</returns>
        UserSettingDto Add(UserSettingDto model);

        /// <summary>
        /// Updating existing user by id
        /// </summary>
        /// <param name="model">New user model</param>
        void Update(UserDto model);

        /// <summary>
        /// Delete existing user by it's id
        /// </summary>
        /// <param name="id">User id</param>
        void Delete(int id);
    }
}