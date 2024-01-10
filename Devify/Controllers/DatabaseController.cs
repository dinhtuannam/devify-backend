using AutoMapper;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DatabaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("initLanguage")]
        public async Task<IActionResult> initLanguage()
        {
            SqlLanguage? lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("java") == 0).FirstOrDefault();
            if (lang == null)
            {
                SqlLanguage tmp = new SqlLanguage();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "java";
                tmp.name = "Java";
                tmp.des = "Java";
                _unitOfWork.LanguageRepository.Insert(tmp);
            }
            lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("javascript") == 0).FirstOrDefault();
            if (lang == null)
            {
                SqlLanguage tmp = new SqlLanguage();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "javascript";
                tmp.name = "Javascript";
                tmp.des = "Javascript";
                _unitOfWork.LanguageRepository.Insert(tmp);
            }
            lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("python") == 0).FirstOrDefault();
            if (lang == null)
            {
                SqlLanguage tmp = new SqlLanguage();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "python";
                tmp.name = "Python";
                tmp.des = "Python";
                _unitOfWork.LanguageRepository.Insert(tmp);
            }
            lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("c-sharp") == 0).FirstOrDefault();
            if (lang == null)
            {
                SqlLanguage tmp = new SqlLanguage();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "c-sharp";
                tmp.name = "C#";
                tmp.des = "C#";
                _unitOfWork.LanguageRepository.Insert(tmp);
            }
            lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("cpp") == 0).FirstOrDefault();
            if (lang == null)
            {
                SqlLanguage tmp = new SqlLanguage();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "cpp";
                tmp.name = "C++";
                tmp.des = "C++";
                _unitOfWork.LanguageRepository.Insert(tmp);
            }
            lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("sql") == 0).FirstOrDefault();
            if (lang == null)
            {
                SqlLanguage tmp = new SqlLanguage();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "sql";
                tmp.name = "SQL";
                tmp.des = "SQL";
                _unitOfWork.LanguageRepository.Insert(tmp);
            }
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("initUser")]
        public async Task<IActionResult> initUser()
        {
            SqlUser? user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("admin") == 0).FirstOrDefault();
            SqlRole? admin = _unitOfWork.RoleRepository.GetCode("admin", 0).FirstOrDefault();
            SqlRole? manager = _unitOfWork.RoleRepository.GetCode("manager", 0).FirstOrDefault();
            SqlRole? creator = _unitOfWork.RoleRepository.GetCode("creator", 0).FirstOrDefault();
            SqlRole? customer = _unitOfWork.RoleRepository.GetCode("customer", 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "admin";
                tmp.username = "admin";
                tmp.password = "123456";
                tmp.displayName = "admin";
                tmp.email = "admin";
                tmp.about = "";
                tmp.social = "";
                if(admin != null)
                {
                    tmp.role = admin;
                }
                _unitOfWork.AccountRepository.Insert(tmp);
            }
            user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("staff-1") == 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "staff-1";
                tmp.username = "staff-1";
                tmp.password = "123456";
                tmp.displayName = "staff-1";
                tmp.email = "staff-1";
                tmp.about = "";
                tmp.social = "";

                if (manager != null)
                {
                    tmp.role = manager;
                }

                _unitOfWork.AccountRepository.Insert(tmp);
            }
            user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("staff-2") == 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "staff-2";
                tmp.username = "staff-2";
                tmp.password = "123456";
                tmp.displayName = "staff-2";
                tmp.email = "staff-2";
                tmp.about = "";
                tmp.social = "";

                if (manager != null)
                {
                    tmp.role = manager;
                }

                _unitOfWork.AccountRepository.Insert(tmp);
            }
            user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("creator-1") == 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "creator-1";
                tmp.username = "creator-1";
                tmp.password = "123456";
                tmp.displayName = "creator-1";
                tmp.email = "creator-1";
                tmp.about = "";
                tmp.social = "";

                if (creator != null)
                {
                    tmp.role = creator;
                }

                _unitOfWork.AccountRepository.Insert(tmp);
            }
            user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("creator-2") == 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "creator-2";
                tmp.username = "creator-2";
                tmp.password = "123456";
                tmp.displayName = "creator-2";
                tmp.email = "creator-2";
                tmp.about = "";
                tmp.social = "";

                if (creator != null)
                {
                    tmp.role = creator;
                }

                _unitOfWork.AccountRepository.Insert(tmp);
            }
            user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("customer-1") == 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "customer-1";
                tmp.username = "customer-1";
                tmp.password = "123456";
                tmp.displayName = "customer-1";
                tmp.email = "customer-1";
                tmp.about = "";
                tmp.social = "";

                if (customer != null)
                {
                    tmp.role = customer;
                }

                _unitOfWork.AccountRepository.Insert(tmp);
            }
            user = _unitOfWork.AccountRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo("customer-2") == 0).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "customer-2";
                tmp.username = "customer-2";
                tmp.password = "123456";
                tmp.displayName = "customer-2";
                tmp.email = "customer-2";
                tmp.about = "";
                tmp.social = "";

                if (customer != null)
                {
                    tmp.role = customer;
                }

                _unitOfWork.AccountRepository.Insert(tmp);
            }
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("initRole")]
        public async Task<IActionResult> initRole()
        {
            SqlRole? role = _unitOfWork.RoleRepository.GetCondition(s => s.code.CompareTo("admin") == 0).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "admin";
                tmp.name = "admin";
                tmp.des = "admin";
                _unitOfWork.RoleRepository.Insert(tmp);
            }
            role = _unitOfWork.RoleRepository.GetCondition(s => s.code.CompareTo("manager") == 0).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "manager";
                tmp.name = "manager";
                tmp.des = "manager";
                _unitOfWork.RoleRepository.Insert(tmp);
            }
            role = _unitOfWork.RoleRepository.GetCondition(s => s.code.CompareTo("creator") == 0).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "creator";
                tmp.name = "creator";
                tmp.des = "creator";
                _unitOfWork.RoleRepository.Insert(tmp);
            }
            role = _unitOfWork.RoleRepository.GetCondition(s => s.code.CompareTo("customer") == 0).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "customer";
                tmp.name = "customer";
                tmp.des = "customer";
                _unitOfWork.RoleRepository.Insert(tmp);
            }
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("initLevel")]
        public async Task<IActionResult> initLevel()
        {
            SqlLevel? level = _unitOfWork.LevelRepository.GetCondition(s => s.code.CompareTo("beginner") == 0 && s.isdeleted == false).FirstOrDefault();
            if (level == null)
            {
                SqlLevel tmp = new SqlLevel();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "beginner";
                tmp.name = "Beginner";
                tmp.des = "Beginner";
                _unitOfWork.LevelRepository.Insert(tmp);
            }
            level = _unitOfWork.LevelRepository.GetCondition(s => s.code.CompareTo("intermediate") == 0 && s.isdeleted == false).FirstOrDefault();
            if (level == null)
            {
                SqlLevel tmp = new SqlLevel();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "intermediate";
                tmp.name = "Intermediate";
                tmp.des = "Intermediate";
                _unitOfWork.LevelRepository.Insert(tmp);
            }
            level = _unitOfWork.LevelRepository.GetCondition(s => s.code.CompareTo("expert") == 0 && s.isdeleted == false).FirstOrDefault();
            if (level == null)
            {
                SqlLevel tmp = new SqlLevel();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "expert";
                tmp.name = "Expert";
                tmp.des = "Expert";
                _unitOfWork.LevelRepository.Insert(tmp);
            }
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("initCategory")]
        public async Task<IActionResult> initCategory()
        {
            SqlCategory? category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("frontend") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "frontend";
                tmp.name = "Frontend";
                tmp.des = "Frontend development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("backend") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "backend";
                tmp.name = "Backend";
                tmp.des = "Backend development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("fullstack") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "fullstack";
                tmp.name = "Fullstack";
                tmp.des = "Fullstack development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("mobile") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "mobile";
                tmp.name = "Mobile";
                tmp.des = "Mobile development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("data") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "data";
                tmp.name = "Data";
                tmp.des = "Data development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("ai") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "ai";
                tmp.name = "AI";
                tmp.des = "AI development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("ml") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "ml";
                tmp.name = "Machine Learning";
                tmp.des = "Machine Learning development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            category = _unitOfWork.CategoryRepository.GetCondition(s => s.code.CompareTo("game") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "game";
                tmp.name = "Game";
                tmp.des = "Game development";
                _unitOfWork.CategoryRepository.Insert(tmp);
            }
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}
