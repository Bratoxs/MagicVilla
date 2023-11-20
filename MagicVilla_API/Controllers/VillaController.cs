using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.DTO;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        //Constructor
        public VillaController(ILogger<VillaController> logger, IVillaRepositorio villaRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _mapper = mapper;
            _response = new();
        }

        //Consultar todos los registros o recurso
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //Documentar códigos de estado
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                _logger.LogInformation("Obtener las villas");
                IEnumerable<Villa> villaList = await _villaRepo.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<VillaDto>>(villaList);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
           
        }

        //Consultar un registro o recurso por id
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer Villa con Id " + id);
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villa = await _villaRepo.Obtener(v => v.Id == id);

                if (villa == null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Resultado = _mapper.Map<VillaDto>(villa);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        //Crear un registro o recurso
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearVilla([FromBody] VillaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _villaRepo.Obtener(v => v.Nombre.ToLower() == createDto.Nombre.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La Villa con ese nombre ya existe!");
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                Villa modelo = _mapper.Map<Villa>(createDto);

                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _villaRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = modelo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        //Eliminar un registro o recurso
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;

                    return BadRequest();
                }

                var villa = await _villaRepo.Obtener(v => v.Id == id);

                if (villa == null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;

                    return NotFound();
                }

                await _villaRepo.Remover(villa);
                _response.statusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return BadRequest(_response);
        }

        //Actualizar un registro o recurso
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }

                Villa modelo = _mapper.Map<Villa>(updateDto);

                await _villaRepo.Actualizar(modelo);
                _response.statusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return BadRequest(_response);
        }

        //Actualizar una propiedad de un registro o recurso
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            try
            {
                if (patchDto == null || id == 0)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;

                    return BadRequest();
                }

                var villa = await _villaRepo.Obtener(v => v.Id == id, tracked: false);

                VillaUpdateDto villaUpdateDto = _mapper.Map<VillaUpdateDto>(villa);

                if (villa == null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;

                    return BadRequest();
                }

                patchDto.ApplyTo(villaUpdateDto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Villa modelo = _mapper.Map<Villa>(villaUpdateDto);

                await _villaRepo.Actualizar(modelo);
                _response.statusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return BadRequest(_response);
        }

    }
}
