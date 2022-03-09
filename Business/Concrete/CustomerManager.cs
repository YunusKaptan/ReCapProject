﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Utilities.Results;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _costumerDal;

        public CustomerManager(ICustomerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<List<Customer>> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(c => c.CustomerId == customerId));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);

            _costumerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            _costumerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(Customer customer)
        {
            _costumerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
