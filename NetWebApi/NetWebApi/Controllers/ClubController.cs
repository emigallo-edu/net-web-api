﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Entities;
using NetWebApi.Middlewares;
using NetWebApi.Model;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AuditResponseFilter]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _repository;
        private readonly IMapper _mapper;

        public ClubController(IClubRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubDTO club)
        {
            await this._repository.InsertAsync(this._mapper.Map<Club>(club));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._repository.GetAllAsync();

            foreach (var item in result.Where(x => x.Stadium != null))
            {
                item.Stadium.Club = null;
            }

            return Ok(result);
        }

        [HttpGet("short")]
        public async Task<IActionResult> GetAllShort()
        {
            var result = await this._repository.GetAllShortAsync();
            return Ok(result);
        }

        [HttpPatch("name")]
        public async Task<IActionResult> ChangeName(ChangeClubNameDTO dto)
        {
            await this._repository.ChangeName(dto.Id, dto.Name);
            return Ok("El registro se modifico correctamente");
        }
    }
}