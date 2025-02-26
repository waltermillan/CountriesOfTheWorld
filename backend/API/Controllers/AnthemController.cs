using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/anthems")] // Usamos el plural en la ruta para seguir la convención RESTful
public class AnthemController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnthemController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas los himnos
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Anthem>>> Get()
    {
        try
        {
            var anthems = await _unitOfWork.Anthems.GetAllAsync();
            return _mapper.Map<List<Anthem>>(anthems);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: obtener un himno por su ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Anthem>> Get(int id)
    {
        try
        {
            var anthem = await _unitOfWork.Anthems.GetByIdAsync(id);
            if (anthem == null)
                return NotFound();

            return _mapper.Map<Anthem>(anthem);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: agregar un himno
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Anthem>> Post(Anthem oAnthem)
    {
        try
        {
            var anthem = _mapper.Map<Anthem>(oAnthem);
            _unitOfWork.Anthems.Add(anthem);
            await _unitOfWork.SaveAsync();
            if (anthem == null)
            {
                return BadRequest();
            }
            oAnthem.Id = anthem.Id;
            return CreatedAtAction(nameof(Post), new { id = oAnthem.Id }, oAnthem);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: actualizar un himno
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Anthem>> Put([FromBody] Anthem oAnthem)
    {
        try
        {
            if (oAnthem == null)
                return NotFound();

            var anthem = _mapper.Map<Anthem>(oAnthem);
            _unitOfWork.Anthems.Update(anthem);
            await _unitOfWork.SaveAsync();
            return oAnthem;
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: eliminar un himno
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var anthem = await _unitOfWork.Anthems.GetByIdAsync(id);
            if (anthem == null)
                return NotFound();

            _unitOfWork.Anthems.Remove(anthem);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }
}