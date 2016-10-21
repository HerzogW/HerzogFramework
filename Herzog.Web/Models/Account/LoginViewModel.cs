﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Herzog.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "请输入‘{0}’")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入‘{0}’")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住密码?")]
        public bool RememberMe { get; set; }
    }
}