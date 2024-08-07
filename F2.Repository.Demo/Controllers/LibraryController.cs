﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using F2.Repository.Demo.Mapper.Dto;
using F2.Repository.Demo.Repositories;

namespace F2.Repository.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public LibraryController(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<AuthorDto> Get()
        {
            var dto = _authorRepository.GetAuthorsAndBooks<AuthorDto>();

            return Ok(dto);
        }
    }
}