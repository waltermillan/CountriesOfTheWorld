using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class AnthemsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnthemsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

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
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Anthem>> Get(int id)
    {
        try
        {
            var anthem = await _unitOfWork.Anthems.GetByIdAsync(id);

            if (anthem is null)
                return NotFound();

            return _mapper.Map<Anthem>(anthem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

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

            if (anthem is null)
                return BadRequest();

            oAnthem.Id = anthem.Id;
            return CreatedAtAction(nameof(Post), new { id = oAnthem.Id }, oAnthem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Anthem>> Put([FromBody] Anthem oAnthem)
    {
        try
        {
            if (oAnthem is null)
                return NotFound();

            var anthem = _mapper.Map<Anthem>(oAnthem);
            _unitOfWork.Anthems.Update(anthem);
            await _unitOfWork.SaveAsync();
            return oAnthem;
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var anthem = await _unitOfWork.Anthems.GetByIdAsync(id);

            if (anthem is null)
                return NotFound();

            _unitOfWork.Anthems.Remove(anthem);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the anthems. Please try again later.", Details = ex.Message });
        }
    }
}