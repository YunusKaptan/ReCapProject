using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Utilities.Results;
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

        public IDataResult<List<Customer>> GetCustomerById(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(c => c.UserId == userId));
        }

        public IResult Add(Customer customer)
        {
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
