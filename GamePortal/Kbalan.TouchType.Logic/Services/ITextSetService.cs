﻿using CSharpFunctionalExtensions;
using Kbalan.TouchType.Logic.Dto;
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
        Result<IEnumerable<TextSetDtomin>> GetAll();
        Task<Result<IEnumerable<TextSetDtomin>>> GetAllAsync();

        /// <summary>
        /// Returns text set from TextSetDto collection by it's id. 
        /// </summary>
        /// <param name="Id">text set ID</param>
        /// <returns>Single text set from TextSetDto or null</returns>
        Result<Maybe<TextSetDto>> GetById(int Id);
        Task<Result<Maybe<TextSetDto>>> GetByIdAsync(int Id);

        /// <summary>
        /// Returns text set from TextSetDto collection by it's id.
        /// </summary>
        /// <param name="level">text set level</param>
        /// <returns>Single text set from TextSetDto or null</returns>
        Result<TextSetDto> GetByLevelRandom(int level);
        Task<Result<TextSetDto>> GetByLevelAsyncRandom(string id);

        /// <summary>
        /// Returns text set from TextSetDto collection by it's id.
        /// </summary>
        /// <param name="level">text set level</param>
        /// <returns>Single text set from TextSetDto or null</returns>
        Result<IEnumerable<TextSetDto>> GetByLevel(int level);
        Task<Result<IEnumerable<TextSetDto>>> GetByLevelAsync(int level);

        /// <summary>
        /// Add new text set to TextSetDto collection
        /// </summary>
        /// <param name="model">New text set</param>
        /// <returns>New text set or null</returns>
        Task<Result<TextSetDto>> AddAsync(TextSetDto model);

        /// <summary>
        /// Updating existing text set in TextSetDto collection by id
        /// </summary>
        /// <param name="id">text set id</param>
        /// <param name="model">New text set model</param>
        /// <returns>New text set or null</returns>
        Task<Result> UpdateAsync(TextSetDto model);

        /// <summary>
        /// Delete existing text set in TextSetDto by it's id
        /// </summary>
        /// <param name="id">text set id</param>
        /// <returns>true of false</returns>
        Task<Result> DeleteAsync(int id);
    }
}
