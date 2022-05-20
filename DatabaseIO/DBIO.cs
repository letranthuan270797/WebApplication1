using DatabasaProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace DatabaseIO
{
    public class DBIO
    {
        //Object ket noi toi DB SERVER
        MyDB mydb = new MyDB();
        /// <summary>
        /// Them 1 ROW
        /// </summary>      
        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        //public kymdan_Users GetObject_User(string uid, string pwd)
        //{
        //    //Khong su dung Parameter
        //    //string SQL = " SELECT * FROM kymdan_Users WHERE Uid= '" + uid + "' AND Pwd ='" + pwd + "'";
        //    //return mydb.Database.SqlQuery<kymdan_Users>(SQL).FirstOrDefault();

        //    // Su dung Parameter

        //    //return mydb.Database.SqlQuery<kymdan_Users>(
        //    //    "SELECT * FROM kymdan_Users WHERE Uid=@U AND Pwd=@P",
        //    //    new SqlParameter("@U", uid),
        //    //    new SqlParameter("@P", pwd)
        //    //    ).FirstOrDefault();
        //}
        /// <summary>
        /// READ ALL
        /// </summary>
        /// <returns></returns>
        public List<kymdan_Users> GetList_User()
        {
            return mydb.kymdan_Users.ToList();
        }
        /// <summary>
        /// Delete 1 Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void DeleteObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }
        /// <summary>
        /// Read 1 User from ID
        /// </summary>
        /// <returns></returns>
        public kymdan_Users GetObject_User(string id)
        {
            return mydb.kymdan_Users.Where(c=> c.ID == id).FirstOrDefault();
        } 
        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            mydb.SaveChanges();
        }
        public IEnumerable<kymdan_Users> GetAllPage(int page, int pagesize)
        {
            return mydb.kymdan_Users.OrderByDescending(x => x.Fullname).ToPagedList(page, pagesize);
        }
    }
}
