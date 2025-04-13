using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SymbolsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SymbolsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Symbol>>> Get()
    {
        try
        {
            var symbols = await _unitOfWork.Symbols.GetAllAsync();
            return _mapper.Map<List<Symbol>>(symbols);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the symbols. Please try again later.", Details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Symbol>> Get(int id)
    {
        try
        {
            var symbol = await _unitOfWork.Symbols.GetByIdAsync(id);

            if (symbol is null)
                return NotFound();

            return _mapper.Map<Symbol>(symbol);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the symbols. Please try again later.", Details = ex.Message });
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Symbol>> Post(Symbol oSymbol)
    {
        try
        {
            var symbol = _mapper.Map<Symbol>(oSymbol);
            _unitOfWork.Symbols.Add(symbol);
            await _unitOfWork.SaveAsync();

            if (symbol is null)
                return BadRequest();

            oSymbol.Id = symbol.Id;
            return CreatedAtAction(nameof(Post), new { id = oSymbol.Id }, oSymbol);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the symbols. Please try again later.", Details = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Symbol>> Put([FromBody] Symbol oSymbol)
    {
        try
        {
            if (oSymbol is null)
                return NotFound();

            var symbol = _mapper.Map<Symbol>(oSymbol);
            _unitOfWork.Symbols.Update(symbol);
            await _unitOfWork.SaveAsync();
            return oSymbol;
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the symbols. Please try again later.", Details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var symbol = await _unitOfWork.Symbols.GetByIdAsync(id);

            if (symbol is null)
                return NotFound();

            _unitOfWork.Symbols.Remove(symbol);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "There was an issue retrieving the symbols. Please try again later.", Details = ex.Message });
        }
    }
}
