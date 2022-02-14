using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetCarsByColorId(int id)
        {
            return _colorDal.GetAll(p => p.ColorId == id);
        }

        public void Add(Color color)
        {
           _colorDal.Add(color);
           Console.WriteLine("Color successfully added");
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Color successfully updated!");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Color successfully  deleted!");
        }
    }
}
