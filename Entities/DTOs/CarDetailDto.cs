using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IEntityDto
    {
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
    }
}
