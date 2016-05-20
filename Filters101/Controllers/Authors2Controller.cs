﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Filters101.Models;
using Microsoft.AspNetCore.Mvc;
using Filters101.Filters;
using Filters101.Interfaces;

namespace Filters101.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class Authors2Controller : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public Authors2Controller(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/authors2
        [HttpGet]
        public async Task<List<Author>> Get()
        {
            return await _authorRepository.ListAsync();
        }

        // GET api/authors2/5
        [HttpGet("{id}")]
        [ValidateAuthorExists]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _authorRepository.GetByIdAsync(id));
        }

        // POST api/authors2
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Author author)
        {
            await _authorRepository.AddAsync(author);
            return Ok(author);
        }

        // PUT api/authors2/5
        [HttpPut("{id}")]
        [ValidateAuthorExists]
        public async Task<IActionResult> Put(int id, [FromBody]Author author)
        {
            await _authorRepository.UpdateAsync(author);
            return Ok();
        }

        // DELETE api/authors2/5
        [HttpDelete("{id}")]
        [ValidateAuthorExists]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorRepository.DeleteAsync(id);
            return Ok();
        }
    }
}