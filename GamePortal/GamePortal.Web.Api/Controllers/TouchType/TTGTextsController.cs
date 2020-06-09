﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSharpFunctionalExtensions;
using FluentValidation;
using JetBrains.Annotations;
using Kbalan.TouchType.Logic.Dto;
using Kbalan.TouchType.Logic.Services;

namespace GamePortal.Web.Api.Controllers.TouchType
{
    /// <summary>
    /// Controller for TextSet
    /// </summary>
    [RoutePrefix("api/textsets")]
    public class TTGTextsController : ApiController
    {
        private readonly ITextSetService _textSetService;
        private readonly IValidator<TextSetDto> _textSetValidator;

        public TTGTextsController([NotNull]ITextSetService textSetService, [NotNull]IValidator<TextSetDto> TextSetValidator)
        {
            this._textSetService = textSetService;
            _textSetValidator = TextSetValidator;
        }

        //Get All TextSets
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var result = _textSetService.GetAll();
            return result.IsSuccess ? Ok(result.Value) : (IHttpActionResult)BadRequest(result.Error);
        }

        //Get TextSet by Id
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = _textSetService.GetById(id);
            return result.IsSuccess ? Ok(result.Value) : (IHttpActionResult)BadRequest(result.Error);
        }

        ///Get Random TextSet by Level of the text
        [HttpGet]
        [Route("searchbylevel/{level}")]
        public IHttpActionResult GetRandomByLevel(int level)
        {
            if (level < 0 || level > 2)
            {
                return BadRequest("Level must be Easy, Middle or Hard");
            }

            var result = _textSetService.GetByLevel(level);
            return result.IsSuccess ? Ok(result.Value) : (IHttpActionResult)BadRequest(result.Error);

        }

        //Add new text
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add([FromBody]TextSetDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var preValidResult = _textSetValidator.Validate(model, ruleSet: "PreValidation");
            if (!preValidResult.IsValid)
            {
                return BadRequest(preValidResult.Errors.Select(x => x.ErrorMessage).First());
            }

            var result = _textSetService.Add(model);
            return result.IsSuccess ? Created($"/textsets/{result.Value.Id}", result.Value) : (IHttpActionResult)BadRequest(result.Error); 
        }

        //Update Text by Id 
        [HttpPut]
        [Route("")]
        public IHttpActionResult Update([FromBody]TextSetDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var preValidResult = _textSetValidator.Validate(model, ruleSet: "PreValidation");
            if (!preValidResult.IsValid)
            {
                return BadRequest(preValidResult.Errors.Select(x => x.ErrorMessage).First());
            }

            var result = _textSetService.Update(model);
            return result.IsSuccess ? Ok($"Text set with id {model.Id} updated succesfully!") : (IHttpActionResult)BadRequest(result.Error);

        }

        //Delete Text by Id
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = _textSetService.Delete(id);
            return result.IsSuccess ? Ok($"Text set with id {id} deleted succesfully!") : (IHttpActionResult)BadRequest(result.Error);
        }
    }
}
