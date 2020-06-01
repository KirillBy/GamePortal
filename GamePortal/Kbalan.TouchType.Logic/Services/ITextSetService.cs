﻿using Kbalan.TouchType.Logic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbalan.TouchType.Logic.Services
{
    /// <summary>
    /// Service for Text Set. 
    /// </summary>
    public interface ITextSetService: IDisposable
    {
        /// <summary>
        /// Return all text sets from TextSetDto
        /// </summary>
        /// <returns>All text sets from RegisterUserDto</returns>
        IEnumerable<TextSetDto> GetAll();

        /// <summary>
        /// Returns text set from TextSetDto collection by it's id. 
        /// </summary>
        /// <param name="Id">text set ID</param>
        /// <returns>Single text set from TextSetDto or null</returns>
        TextSetDto GetById(int Id);

        /// <summary>
        /// Returns text set from TextSetDto collection by it's id.
        /// </summary>
        /// <param name="level">text set level</param>
        /// <returns>Single text set from TextSetDto or null</returns>
        TextSetDto GetByLevel(int level);

        /// <summary>
        /// Add new text set to TextSetDto collection
        /// </summary>
        /// <param name="model">New text set</param>
        /// <returns>New text set or null</returns>
        TextSetDto Add(TextSetDto model);

        /// <summary>
        /// Updating existing text set in TextSetDto collection by id
        /// </summary>
        /// <param name="id">text set id</param>
        /// <param name="model">New text set model</param>
        /// <returns>New text set or null</returns>
        void Update(TextSetDto model);

        /// <summary>
        /// Delete existing text set in TextSetDto by it's id
        /// </summary>
        /// <param name="id">text set id</param>
        /// <returns>true of false</returns>
        void Delete(int id);
    }
}