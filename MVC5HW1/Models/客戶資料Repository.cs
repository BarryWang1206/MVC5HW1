using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5HW1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public IQueryable<客戶資料> All(bool isAll = false)
        {
            
            if (isAll)
            {
                //所有資料(不篩選)
                return base.All();
            }
            else
            {
                //僅篩選出未刪除的資料
                return base.All().Where(p => p.是否已刪除 == false); 
            }
        }

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<客戶資料> KeyWordSearch(string keyword)
        {
            var data = this.All();

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(keyword) ||
                p.統一編號.Contains(keyword) ||
                p.電話.Contains(keyword) ||
                p.傳真.Contains(keyword) ||
                p.地址.Contains(keyword) ||
                p.Email.Contains(keyword));
            }

            return data;
        }

        public override void Delete(客戶資料 entity)
        {
            entity.是否已刪除 = true;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}