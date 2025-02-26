using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/goverments")] // Usamos el plural en la ruta para seguir la convención RESTful
public class GovermentController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GovermentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas los gobiernos
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Goverment>>> Get()
    {
        try
        {
            var goverments = await _unitOfWork.Goverments.GetAllAsync();
            return _mapper.Map<List<Goverment>>(goverments);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: obtener un gobierno por su ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Goverment>> Get(int id)
    {
        try
        {
            var goverment = await _unitOfWork.Goverments.GetByIdAsync(id);
            if (goverment == null)
                return NotFound();

            return _mapper.Map<Goverment>(goverment);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: agregar un gobierno
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Goverment>> Post(Goverment oGoverment)
    {
        try
        {
            var goverment = _mapper.Map<Goverment>(oGoverment);
            _unitOfWork.Goverments.Add(goverment);
            await _unitOfWork.SaveAsync();
            if (goverment == null)
            {
                return BadRequest();
            }
            oGoverment.Id = goverment.Id;
            return CreatedAtAction(nameof(Post), new { id = oGoverment.Id }, oGoverment);
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: actualizar un gobierno
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Goverment>> Put([FromBody] Goverment oGoverment)
    {
        try
        {
            if (oGoverment == null)
                return NotFound();

            var goverment = _mapper.Map<Goverment>(oGoverment);
            _unitOfWork.Goverments.Update(goverment);
            await _unitOfWork.SaveAsync();
            return oGoverment;
        }
        catch (Exception ex)
        {
            // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    // Método existente: eliminar un gobierno
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var goverment = await _unitOfWork.Goverments.GetByIdAsync(id);
            if (goverment == null)
                return NotFound();

            _unitOfWork.Goverments.Remove(goverment);
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