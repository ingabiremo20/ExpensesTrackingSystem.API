﻿using AutoMapper;
using ExpensesTrackingSystem.API.Entities;
using ExpensesTrackingSystem.API.Helpers;
using ExpensesTrackingSystem.API.Models;
using ExpensesTrackingSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepository usersRepository,
            IMapper mapper)
        {
            _usersRepository = usersRepository ??
                throw new ArgumentNullException(nameof(usersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<UsersDto>> GetAllUsers()
        {
            var usersList = _usersRepository.GetAllUsers();
            //var users = new List<UsersDto>();
            
            //foreach (var user in usersList)
            //{
            //    users.Add(new UsersDto()
            //    {
            //        UserId=user.UserId,
            //        UserName=user.UserName,
            //        PassWord=user.PassWord,
            //        Name=$"{user.FirstName} {user.LastName}",
            //        Age=user.DateIOfBirth.GetCurrentAge(),
            //        Currencies=user.Currencies
            //    });
            //}
            return Ok(_mapper.Map<IEnumerable<UsersDto>>(usersList));

        }
        [HttpGet("{UserId}")]
        public IActionResult GetUser(int UserId)
        {
            var GetSingleUser = _usersRepository.GetUser(UserId);

            if (GetSingleUser == null)
            {
                return NotFound();
            }
            //var singleUser = _usersRepository.GetUser(UserId);
            return Ok(_mapper.Map<UsersDto>(GetSingleUser));
        }
    }
}