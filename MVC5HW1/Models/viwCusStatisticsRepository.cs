using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5HW1.Models
{   
	public  class viwCusStatisticsRepository : EFRepository<viwCusStatistics>, IviwCusStatisticsRepository
	{

	}

	public  interface IviwCusStatisticsRepository : IRepository<viwCusStatistics>
	{

	}
}