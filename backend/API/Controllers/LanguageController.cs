using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LanguageController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LanguageController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas los lenguajes
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Language>>> Get()
    {
        try
        {
            var languages = await _unitOfWork.Languages.GetAllAsync();
            return _mapper.Map<List<Language>>(languages);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: obtener un lenguaje por su ID
    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Language>> Get(int id)
    {
        try
        {
            var language = await _unitOfWork.Languages.GetByIdAsync(id);
            if (language == null)
                return NotFound();

            return _mapper.Map<Language>(language);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: agregar un lenguaje
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Language>> Post(Language oLanguage)
    {
        try
        {
            var language = _mapper.Map<Language>(oLanguage);
            _unitOfWork.Languages.Add(language);
            await _unitOfWork.SaveAsync();
            if (language == null)
            {
                return BadRequest();
            }
            oLanguage.Id = language.Id;
            return CreatedAtAction(nameof(Post), new { id = oLanguage.Id }, oLanguage);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: actualizar un lenguaje
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Language>> Put([FromBody] Language oLanguage)
    {
        try
        {
            if (oLanguage == null)
                return NotFound();

            var language = _mapper.Map<Language>(oLanguage);
            _unitOfWork.Languages.Update(language);
            await _unitOfWork.SaveAsync();
            return oLanguage;
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: eliminar un lenguaje
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var language = await _unitOfWork.Languages.GetByIdAsync(id);
            if (language == null)
                return NotFound();

            _unitOfWork.Languages.Remove(language);
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