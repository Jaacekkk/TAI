﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using proj2_tutorialPL.Models;

namespace proj2_tutorialPL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<UserModel>_userManager;

		private readonly SignInManager<UserModel> _signInManager;

		public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}


	

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(Login userLoginData)
		{
			if (!ModelState.IsValid)
			{
				return View(userLoginData);
			}

			await _signInManager.PasswordSignInAsync(userLoginData.UserName,userLoginData.Password, false, false);//3 to czy jak wyjdzie z przegladarki to czy ma wylogowac
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(Register userRegisterData)
		{
			if(!ModelState.IsValid)
			{
				return View(userRegisterData);
			}

			var newUser = new UserModel
			{
				Email = userRegisterData.Email,
				UserName = userRegisterData.UserName
			};

			await _userManager.CreateAsync(newUser,userRegisterData.Password) ;

			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
        }
	}
}
