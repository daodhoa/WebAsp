using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReMake.Models
{
    public class User
    {
        public string email { get; set; }
        public string pw { get; set; }
        public void Validate()
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email không được để trống!");
            }
            if (string.IsNullOrEmpty(pw))
            {
                throw new Exception("Password không được để trống!");
            }

        }
    }
}