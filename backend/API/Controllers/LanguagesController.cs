using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class LanguagesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LanguagesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
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
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Language>> Get(int id)
    {
        try
        {
            var language = await _unitOfWork.Languages.GetByIdAsync(id);

            if (language is null)
                return NotFound();

            return _mapper.Map<Language>(language);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Language>> Post(Language oLanguage)
    {
        try
        {
            var language = _mapper.Map<Language>(oLanguage);
            _unitOfWork.Languages.Add(language);
            await _unitOfWork.SaveAsync();

            if (language is null)
                return BadRequest();

            oLanguage.Id = language.Id;
            return CreatedAtAction(nameof(Post), new { id = oLanguage.Id }, oLanguage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Language>> Put([FromBody] Language oLanguage)
    {
        try
        {
            if (oLanguage is null)
                return NotFound();

            var language = _mapper.Map<Language>(oLanguage);
            _unitOfWork.Languages.Update(language);
            await _unitOfWork.SaveAsync();
            return oLanguage;
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var language = await _unitOfWork.Languages.GetByIdAsync(id);

            if (language is null)
                return NotFound();

            _unitOfWork.Languages.Remove(language);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
        }
    }
}