using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi.DTOs;
using PeliculasApi.Models;

namespace PeliculasApi.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var models = await context.Generos.ToListAsync();
            var dtos = mapper.Map<List<GeneroDTO>>(models);

            return dtos;
        }

        [HttpGet("{id:int}", Name = "getGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var model = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<GeneroDTO>(model);

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroPostDTO generoPostDTO)
        {
            var model = mapper.Map<Genero>(generoPostDTO);
            context.Add(model);
            await context.SaveChangesAsync();
            var generoDTO = mapper.Map<GeneroDTO>(model);

            return new CreatedAtRouteResult("getGenero", new { id = generoDTO.Id }, generoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroPostDTO generoPostDTO)
        {
            var model = mapper.Map<Genero>(generoPostDTO);
            model.Id = id;
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Generos.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            context.Remove(new Genero() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
