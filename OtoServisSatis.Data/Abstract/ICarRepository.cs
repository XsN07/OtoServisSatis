using OtoServisSatis.Data.Concrete;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Abstract
{
  public interface ICarRepository: IRepository<Arac>
  {

     Task<List<Arac>> GetCustomerList();
     Task<List<Arac>> GetCustomerList(Expression<Func<Arac, bool>> expression);
     Task<Arac> GetCustomerCar(int id);

  }
}
