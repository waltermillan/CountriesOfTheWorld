using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ContinentController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContinentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas los continentes
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Continent>>> Get()
    {
        try
        {
            var continents = await _unitOfWork.Continents.GetAllAsync();
            return _mapper.Map<List<Continent>>(continents);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: obtener un continente por su ID
    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Continent>> Get(int id)
    {
        try
        {
            var continent = await _unitOfWork.Continents.GetByIdAsync(id);
            if (continent == null)
                return NotFound();

            return _mapper.Map<Continent>(continent);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: agregar un pais
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Continent>> Post(Continent oContinent)
    {
        try
        {
            var continent = _mapper.Map<Continent>(oContinent);
            _unitOfWork.Continents.Add(continent);
            await _unitOfWork.SaveAsync();
            if (continent == null)
            {
                return BadRequest();
            }
            oContinent.Id = continent.Id;
            return CreatedAtAction(nameof(Post), new { id = oContinent.Id }, oContinent);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: actualizar un continente
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Continent>> Put([FromBody] Continent oContinent)
    {
        try
        {
            if (oContinent == null)
                return NotFound();

            var continent = _mapper.Map<Continent>(oContinent);
            _unitOfWork.Continents.Update(continent);
            await _unitOfWork.SaveAsync();
            return oContinent;
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: eliminar un continente
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var continent = await _unitOfWork.Continents.GetByIdAsync(id);
            if (continent == null)
                return NotFound();

            _unitOfWork.Continents.Remove(continent);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }
}