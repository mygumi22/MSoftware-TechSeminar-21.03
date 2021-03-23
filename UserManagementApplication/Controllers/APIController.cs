using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using UserManagementApplication.Models;

namespace UserManagementApplication.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public APIController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// 유저정보를 조회한다
        /// GET : /api/users/1
        /// </summary>
        /// <param name="uidx">조회대상 회원고유번호</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{uidx}")]
        public ActionResult<Users> GetUser(int uidx)
        {
            var user = _dbContext.Users.Find(uidx);
            return Ok(user);
        }

        /// <summary>
        /// 전체유저목록을 조회한다
        /// GET : /api/users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/users")]
        public ActionResult<IEnumerable<Users>> GetUserList()
        {
            var userList = _dbContext.Users.ToList();
            return Ok(userList);
        }

        /// <summary>
        /// 유저정보를 등록한다
        /// </summary>
        /// <param name="user">등록할 유저정보</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Users> PostUser(Users user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Ok(user);
        }

        /// <summary>
        /// 유저정보를 수정한다
        /// </summary>
        /// <param name="user">수정할 유저정보</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<Users> PutUser(Users user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            return Ok(user);
        }

        /// <summary>
        /// 유저정보를 삭제한다
        /// </summary>
        /// <param name="uidx">삭제대상 회원고유번호</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<int> DeleteUser(int uidx)
        {
            var user = _dbContext.Users.Find(uidx);
            _dbContext.Users.Remove(user);
            return _dbContext.SaveChanges();
        }
    }
}
