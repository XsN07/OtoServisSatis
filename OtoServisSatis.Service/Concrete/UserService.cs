using OtoServisSatis.Data;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtoServisSatis.Data.Concrete;

namespace OtoServisSatis.Service.Concrete
{
	public class UserService : UserRepository,IUserService
	{
		public UserService(DatabaseContext context) : base(context)
		{
		}
	}
}
