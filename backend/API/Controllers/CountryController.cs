using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/countries")] // Usamos el plural en la ruta para seguir la convención RESTful
public class CountryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas los paises
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        try
        {
            var countries = await _unitOfWork.Countries.GetAllAsync();
            return _mapper.Map<List<Country>>(countries);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: obtener un pais por su ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Country>> Get(int id)
    {
        try
        {
            var country = await _unitOfWork.Countries.GetByIdAsync(id);
            if (country == null)
                return NotFound();

            return _mapper.Map<Country>(country);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: agregar un pais
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(Country oCountry)
    {
        try
        {
            var country = _mapper.Map<Country>(oCountry);
            _unitOfWork.Countries.Add(country);
            await _unitOfWork.SaveAsync();
            if (country == null)
            {
                return BadRequest();
            }
            oCountry.Id = country.Id;
            return CreatedAtAction(nameof(Post), new { id = oCountry.Id }, oCountry);

        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: actualizar un pais
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Put([FromBody] Country oCountry)
    {
        try
        {
            if (oCountry == null)
                return NotFound();

            var country = _mapper.Map<Country>(oCountry);
            _unitOfWork.Countries.Update(country);
            await _unitOfWork.SaveAsync();
            return oCountry;
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: eliminar un pais
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var country = await _unitOfWork.Countries.GetByIdAsync(id);
            if (country == null)
                return NotFound();

            _unitOfWork.Countries.Remove(country);
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