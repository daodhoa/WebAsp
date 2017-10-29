using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ReMake.Controllers
{
    [RoutePrefix("api/Hethongs")]
    public class HeThongController : ApiController
    {
        [Route("Dangnhap")]
        [HttpPost]
        public IHttpActionResult Dangnhap(Models.User _user)
        {
            try
            {
                //validate
                _user.Validate();
                //Khai bao class
                Models.DBConnection sql = new Models.DBConnection();
                DataTable tableUser = sql.DangNhapHeThong(_user.email, _user.pw);
                HttpContext.Current.Session.Add("email", _user.email); //copy skype paste
                return Ok(tableUser);
            }
            catch (Exception e)
            {
                var error = new HttpError();
                error.Message = e.Message;
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
            }

        }

        [Route("Doimatkhau")]
        [HttpPost]

        public IHttpActionResult Doimatkhau(string _oldpw, string _newpw, string _repw)
        {
            try
            {
               Models.DBConnection sql = new Models.DBConnection();
               sql.DoiMatKhau(HttpContext.Current.Session["email"].ToString(), _oldpw, _newpw, _repw);
                return Ok("Đổi mật khẩu thành công!");
            }
            catch (Exception ex)
            {

                var error = new HttpError();
                error.Message = ex.Message;
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
            }
        }
    }
}