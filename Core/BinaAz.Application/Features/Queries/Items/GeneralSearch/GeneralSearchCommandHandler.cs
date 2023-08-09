using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH;
using BinaAz.Domain.Entities.TPH.Base;
using BinaAz.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Application.Features.Queries.Items.GeneralSearch;

public class GeneralSearchCommandHandler : IRequestHandler<GeneralSearchCommandRequest, List<ItemToListDto>>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public GeneralSearchCommandHandler(IRepository<Item> itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<List<ItemToListDto>> Handle(GeneralSearchCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.ItemNumber is not null)
        {
            var items = await _itemRepository.Table
                .Include(x=> x.City)
                .Where(x => x.ItemNumber == request.ItemNumber)
                .ToListAsync(cancellationToken);
            if (items is null)
                throw new ItemNotFoundException("Item not found");
            return _mapper.Map<List<ItemToListDto>>(items);
        }
        if (request.ApartmentType is not null)
        {
            if (request.ApartmentType == ApartmentType.NewBuilding)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City)
                    .OfType<NewBuilding>()
                    .Where(x => x.SaleOrRent == request.SaleOrRent);

                if (request.CountOfRoom is not null)
                {
                    List<int> rooms = new();
                    if (request.CountOfRoom.One)
                        rooms.Add(1);
                    if (request.CountOfRoom.Two)
                        rooms.Add(2);
                    if (request.CountOfRoom.Three)
                        rooms.Add(3);
                    if (request.CountOfRoom.Four)
                        rooms.Add(4);
                    if (request.CountOfRoom.FiveAndMore)
                        rooms.AddRange(new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
                    items = items.Where(x => rooms.Contains((int)x.CountOfRoom!));
                }

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.MinFloor == null || x.Floor >= request.MinFloor) &&
                        (request.MaxFloor == null || x.Floor <= request.MaxFloor) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.Repair == null || x.Repair == request.Repair) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth) &&
                        (request.MustNotBeFirst == null || x.Floor != 1) &&
                        (request.MustNotBeTop == null || x.Floor != x.CountOfFloor) &&
                        (request.OnlyTop == null || x.Floor == x.CountOfFloor)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            if (request.ApartmentType == ApartmentType.OldBuilding)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City).OfType<OldBuilding>().Where(x => x.SaleOrRent == request.SaleOrRent);

                if (request.CountOfRoom is not null)
                {
                    List<int> rooms = new();
                    if (request.CountOfRoom.One)
                        rooms.Add(1);
                    if (request.CountOfRoom.Two)
                        rooms.Add(2);
                    if (request.CountOfRoom.Three)
                        rooms.Add(3);
                    if (request.CountOfRoom.Four)
                        rooms.Add(4);
                    if (request.CountOfRoom.FiveAndMore)
                        rooms.AddRange(new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
                    items = items.Where(x => rooms.Contains((int)x.CountOfRoom!));
                }

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.MinFloor == null || x.Floor >= request.MinFloor) &&
                        (request.MaxFloor == null || x.Floor <= request.MaxFloor) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.Repair == null || x.Repair == request.Repair) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth) &&
                        (request.MustNotBeFirst == null || x.Floor != 1) &&
                        (request.MustNotBeTop == null || x.Floor != x.CountOfFloor) &&
                        (request.OnlyTop == null || x.Floor == x.CountOfFloor)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            if (request.ApartmentType == ApartmentType.GardenHouse)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City).OfType<GardenHouse>().Where(x => x.SaleOrRent == request.SaleOrRent);

                if (request.CountOfRoom is not null)
                {
                    List<int> rooms = new();
                    if (request.CountOfRoom.One)
                        rooms.Add(1);
                    if (request.CountOfRoom.Two)
                        rooms.Add(2);
                    if (request.CountOfRoom.Three)
                        rooms.Add(3);
                    if (request.CountOfRoom.Four)
                        rooms.Add(4);
                    if (request.CountOfRoom.FiveAndMore)
                        rooms.AddRange(new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
                    items = items.Where(x => rooms.Contains((int)x.CountOfRoom!));
                }

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.MinLandArea == null || x.PlotOfLand >= request.MinLandArea) &&
                        (request.MaxLandArea == null || x.PlotOfLand <= request.MaxLandArea) &&
                        (request.MinFloor == null || x.Floor >= request.MinFloor) &&
                        (request.MaxFloor == null || x.Floor <= request.MaxFloor) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.Repair == null || x.Repair == request.Repair) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth) &&
                        (request.MustNotBeFirst == null || x.Floor != 1) &&
                        (request.MustNotBeTop == null || x.Floor != x.CountOfFloor) &&
                        (request.OnlyTop == null || x.Floor == x.CountOfFloor)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            if (request.ApartmentType == ApartmentType.Office)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City).OfType<Office>().Where(x => x.SaleOrRent == request.SaleOrRent);

                if (request.CountOfRoom is not null)
                {
                    List<int> rooms = new();
                    if (request.CountOfRoom.One)
                        rooms.Add(1);
                    if (request.CountOfRoom.Two)
                        rooms.Add(2);
                    if (request.CountOfRoom.Three)
                        rooms.Add(3);
                    if (request.CountOfRoom.Four)
                        rooms.Add(4);
                    if (request.CountOfRoom.FiveAndMore)
                        rooms.AddRange(new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
                    items = items.Where(x => rooms.Contains((int)x.CountOfRoom!));
                }

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.Repair == null || x.Repair == request.Repair) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth) &&
                        (request.TypeOfOffice == null || x.TypeOfOffice == request.TypeOfOffice)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            if (request.ApartmentType == ApartmentType.Garage)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City).OfType<Garage>().Where(x => x.SaleOrRent == request.SaleOrRent);

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            if (request.ApartmentType == ApartmentType.Ground)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City).OfType<Ground>().Where(x => x.SaleOrRent == request.SaleOrRent);

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            if (request.ApartmentType == ApartmentType.Object)
            {
                var items = _itemRepository.Table
                    .Include(x=> x.City).OfType<Object>().Where(x => x.SaleOrRent == request.SaleOrRent);

                items = items.Where(
                    x =>
                        (request.MinPrice == null || x.Price >= request.MinPrice) &&
                        (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                        (request.MinArea == null || x.Area >= request.MinArea) &&
                        (request.MaxArea == null || x.Area <= request.MaxArea) &&
                        (request.CityId == null || x.CityId == request.CityId) &&
                        (request.Repair == null || x.Repair == request.Repair) &&
                        (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                        (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                        (request.Extract == null || x.Extract == request.Extract) &&
                        (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth)
                );
                return _mapper.Map<List<ItemToListDto>>(items);
            }

            throw new Exception("Search arguments are not correct");
        }
        else
        {
            var items = _itemRepository.Table
                .Include(x=> x.City).Where(x => x.SaleOrRent == request.SaleOrRent);

            if (request.CountOfRoom is not null)
            {
                List<int> rooms = new();
                if (request.CountOfRoom.One)
                    rooms.Add(1);
                if (request.CountOfRoom.Two)
                    rooms.Add(2);
                if (request.CountOfRoom.Three)
                    rooms.Add(3);
                if (request.CountOfRoom.Four)
                    rooms.Add(4);
                if (request.CountOfRoom.FiveAndMore)
                    rooms.AddRange(new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
                items = items.Where(x => rooms.Contains((int)x.CountOfRoom!));
            }

            items = items.Where(
                x =>
                    (request.MinPrice == null || x.Price >= request.MinPrice) &&
                    (request.MaxPrice == null || x.Price <= request.MaxPrice) &&
                    (request.MinArea == null || x.Area >= request.MinArea) &&
                    (request.MaxArea == null || x.Area <= request.MaxArea) &&
                    (request.MinFloor == null || x.Floor >= request.MinFloor) &&
                    (request.MaxFloor == null || x.Floor <= request.MaxFloor) &&
                    (request.CityId == null || x.CityId == request.CityId) &&
                    (request.Repair == null || x.Repair == request.Repair) &&
                    (request.SettlementId == null || x.SettlementId == request.SettlementId) &&
                    (request.Mortgage == null || x.Mortgage == request.Mortgage) &&
                    (request.Extract == null || x.Extract == request.Extract) &&
                    (request.DayOrMonth == null || x.DayOrMonth == request.DayOrMonth) &&
                    (request.MustNotBeFirst == null || x.Floor != 1) &&
                    (request.MustNotBeTop == null || x.Floor != x.CountOfFloor) &&
                    (request.OnlyTop == null || x.Floor == x.CountOfFloor)
            );
            return _mapper.Map<List<ItemToListDto>>(items);
        }
    }
}