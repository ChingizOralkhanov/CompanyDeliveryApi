using AutoMapper;
using Company.Delivery.Core;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    private readonly IMapper _mapper;
    private readonly DeliveryDbContext _context;

    public WaybillService(DeliveryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var waybill = await _context.Waybills
            .Include(w => w.Items)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (waybill == null)
        {
            throw new EntityNotFoundException();
        }

        return _mapper.Map<WaybillDto>(waybill);
    }

    public async Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        var waybill = _mapper.Map<Waybill>(data);
        await _context.Waybills.AddAsync(waybill, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<WaybillDto>(waybill);
    }

    public async Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        var waybill = await _context.Waybills
            .Include(w => w.Items)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (waybill == null)
        {
            throw new EntityNotFoundException();
        }

        _mapper.Map(data, waybill);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<WaybillDto>(waybill);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var waybill = await _context.Waybills
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (waybill == null)
        {
            throw new EntityNotFoundException();
        }
        _context.Waybills.Remove(waybill);
        await _context.SaveChangesAsync(cancellationToken);
    }
}