﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICardService
    {
        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);

        IDataResult<List<Card>> GetAll();
        IDataResult<Card> GetByCardId(int cardId);
    }
}
