﻿using Castle.DynamicProxy;
using CSharpFunctionalExtensions;
using FluentValidation;
using FluentValidation.Results;
using Kbalan.TouchType.Data.Contexts;
using Kbalan.TouchType.Logic.Dto;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbalan.TouchType.Logic.Aspects
{
    /// <summary>
    /// Interceptor for StatisticService Proxy. It includes PostValidation  Update method
    /// </summary>
    class StatisticValidationInterceptor : IInterceptor
    {
        private readonly IKernel _kernel;

        public StatisticValidationInterceptor(IKernel kernel)
        {
            this._kernel = kernel;
        }
        public void Intercept(IInvocation invocation)
        {
            //id null checking
            var userId = invocation.Arguments.SingleOrDefault(x => x.GetType() == typeof(Int32));
            if (userId == null)
            {
                invocation.Proceed();
                return;
            }

            //model null checking
            var model = invocation.Arguments.SingleOrDefault(x => x.GetType() == typeof(StatisticDto)) as StatisticDto;
            if (model == null)
            {
                invocation.Proceed();
                return;
            }

            //Implementation of validation for update method
            if (invocation.Method.Name.Equals("Update"))
            {
                //Cheking if user with id exist
                var userModel = _kernel.Get<TouchTypeGameContext>().Users.Include("Statistic").SingleOrDefault(x => x.Id == (int)userId);
                if (userModel == null)
                {
                    invocation.ReturnValue = Result.Failure($"No user with id {userId} exist");
                    return;
                }

                //Replace model statistic id from Dto to correct id from Db 
                model.StatisticId = userModel.Statistic.StatisticId;

                //Validation
                var validator = _kernel.Get<IValidator<StatisticDto>>();
                ValidationResult validationResult = validator.Validate(model, ruleSet: "PostValidation");
                if (!validationResult.IsValid)
                {
                    invocation.ReturnValue = Result.Failure(validationResult.Errors.Select(x => x.ErrorMessage).First());
                    return;
                }
            }

            invocation.Proceed();
        }
    }
}