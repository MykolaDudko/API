using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Profiles;

public class CustomerPickUpBranchProfile : Profile
{
    public CustomerPickUpBranchProfile()
    {
        CreateMap<CustomerPickUpBranchModel, CustomerPickUpBranchResponse>()
            .ForMember(i => i.Lat, i => i.MapFrom(i => i.Location.Coordinate.Y))
             .ForMember(i => i.Lng, i => i.MapFrom(i => i.Location.Coordinate.X));

        CreateMap<CustomerPickUpBranchResponse, CustomerPickUpBranchModel>().ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.Lat, i.Lng)));

        CreateMap<CustomerPickUpBranchModel, CustomerPickUpBranchModel>();

        CreateMap<Position, CustomerPickUpBranchModel>()
            .ForMember(p => p.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.lat, i.lng)));

        CreateMap<Machine, CustomerPickUpBranchModel>()
            .ForMember(p => p.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.position.lat, i.position.lng)))
            .ForMember(p => p.City, i => i.MapFrom(i => i.address.town))
            .ForMember(p => p.Street, i => i.MapFrom(i => i.address.street))
            .ForMember(p => p.Photo, i => i.MapFrom(i => i.photo_small))
            .ForMember(p => p.CarrierBranchId, i => i.MapFrom(i => i.name))
            .ForMember(p => p.Position, i => i.MapFrom(i => i.location_description))
            .ForMember(p => p.Street, i => i.MapFrom(i => i.address.street))
            .ForMember(p => p.ZipCode, i => i.MapFrom(i => i.address.postal_code));

        CreateMap<Address, CustomerPickUpBranchModel>();

        CreateMap<RowCP, CustomerPickUpBranchModel>().ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.PSC))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.PSC))
            .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.Lat, i.Lng)));

        CreateMap<Den, WorkHoursModel>().ForMember(i => i.TimeFrom, i => i.MapFrom(i => i.od_do.od)).
            ForMember(i => i.TimeTo, i => i.MapFrom(i => i.od_do.@do));

        CreateMap<RowBalikovna, CustomerPickUpBranchModel>()
            .ForMember(i => i.Description, i => i.MapFrom(i => i.POPIS))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.PSC))
             .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.Lat, i.Lng)))
            .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.PSC));

        //CreateMap<DenBalikovna, WorkHoursModel>().ForMember(i => i.TimeFrom, i => i.MapFrom(i => i.OdDo.TimeFrom)).
        //    ForMember(i => i.TimeTo, i => i.MapFrom(i => i.OdDo.TimeTo));

        CreateMap<Point, CustomerPickUpBranchModel>()
            .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.coordinates.Lat, i.coordinates.Lng)))
            .ForMember(i => i.CardPayment, i => i.MapFrom(i => i.payment == "Cash only" ? false : true))
            .ForMember(i => i.Street, i => i.MapFrom(i => i.street))
            .ForMember(i => i.City, i => i.MapFrom(i => i.city))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.zip))
            .ForMember(i => i.CountryCode, i => i.MapFrom(i => i.country))
            .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.code));

        CreateMap<Item, CustomerPickUpBranchModel>().ForMember(i => i.CardPayment, i => i.MapFrom(i => i.cardpayment_allowed == 1 ? true : false))
            .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.latitude, i.longitude)))
            .ForMember(i => i.Id, i => i.Ignore())
            .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.id))
            .ForMember(i => i.Street, i => i.MapFrom(i => i.street))
            .ForMember(i => i.City, i => i.MapFrom(i => i.city))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.postcode))
            .ForMember(i => i.Phone, i => i.MapFrom(i => i.phone))
            .ForMember(i => i.Email, i => i.MapFrom(i => i.email))
            .ForMember(i => i.Url, i => i.MapFrom(i => i.homepage))
            .ForMember(i => i.WorkHours, i => i.MapFrom(i => i.hours))
            .ForMember(i => i.Photo, i => i.MapFrom(i => i.photo));


        CreateMap<Hour, WorkHoursModel>().ForMember(i => i.Day, i => i.MapFrom(i => i.day))
            .ForMember(i => i.TimeFrom, i => i.MapFrom(i => i.openMorning))
            .ForMember(i => i.TimeTo, i => i.MapFrom(i => i.closeAfternoon));

        CreateMap<AccessPointDetailModel, CustomerPickUpBranchModel>().
        ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.Gps.Latitude, i.Gps.Longitude)))
        .ForMember(i => i.WorkHours, i => i.MapFrom(i => i.OpenHours.WorkHours))
        .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.Code))
        .ForMember(i => i.Position, i => i.MapFrom(i => i.KtmNote));

        CreateMap<Branch, CustomerPickUpBranchModel>().ForMember(i => i.CardPayment, i => i.MapFrom(i => i.CreditCardPayment == "yes" ? true : false)).
            ForMember(i => i.WorkHours, i => i.MapFrom(i => i.OpeningHours.Regular.workHours))
            .ForMember(i => i.Description, i => i.MapFrom(i => i.Status.Description))
            .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.CarrierBranchId))
            .ForMember(i => i.Position, i => i.MapFrom(i => i.Place))
            .ForMember(i => i.Street, i => i.MapFrom(i => i.Street))
            .ForMember(i => i.City, i => i.MapFrom(i => i.City))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.Zip))
            .ForMember(i => i.CountryCode, i => i.MapFrom(i => i.Country))
             .ForMember(i => i.Url, i => i.MapFrom(i => i.Url))
                .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.Lat, i.Lng)))
             .ForMember(i => i.Photo, i => i.MapFrom(i => i.Photos.Photo.FirstOrDefault().Normal));
        CreateMap<Workday, WorkHoursModel>();

        CreateMap<Place, CustomerPickUpBranchModel>()
            .ForMember(i => i.WorkHours, i => i.MapFrom(i => i.WorkDays.Workday))
            .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.gpsLat, i.gpsLong)))
            .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.CarrierBranchId))
            .ForMember(i => i.Position, i => i.MapFrom(i => i.description))
            .ForMember(i => i.Street, i => i.MapFrom(i => i.address))
            .ForMember(i => i.City, i => i.MapFrom(i => i.city))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.virtualzip));


        CreateMap<HourUlozenka, WorkHoursModel>().ForMember(i => i.TimeTo, i => i.MapFrom(i => i.close))
            .ForMember(i => i.TimeFrom, i => i.MapFrom(i => i.open));

        CreateMap<DestinationUlozenka, CustomerPickUpBranchModel>().ForMember(i => i.Photo, i => i.MapFrom(i => i._links.picture.href))
            .ForMember(i => i.Position, i => i.MapFrom(i => i.navigation.general))
            .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.CarrierBranchId))
            .ForMember(i => i.CustomerPickUpBranchName2, i => i.MapFrom(i => i.shortcut))
            .ForMember(i => i.CustomerPickUpBranchName, i => i.MapFrom(i => i.name))
            .ForMember(i => i.Street, i => i.MapFrom(i => i.street))
            .ForMember(i => i.City, i => i.MapFrom(i => i.town))
            .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.zip))
            .ForMember(i => i.CountryCode, i => i.MapFrom(i => i.country))
            .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.gps.latitude, i.gps.longitude)))
            .ForMember(i => i.CardPayment, i => i.MapFrom(i => i.card_payment == 1 ? true : false))
            .ForMember(i => i.Url, i => i.MapFrom(i => i._links.website.href));

        CreateMap<WedoBranche, CustomerPickUpBranchModel>().ForMember(i => i.City, i => i.MapFrom(i => i.Address.town))
             .ForMember(i => i.Street, i => i.MapFrom(i => i.Address.street))
              .ForMember(i => i.CustomerPickUpBranchName, i => i.MapFrom(i => i.name))
              .ForMember(i => i.CarrierBranchId, i => i.MapFrom(i => i.code))
               .ForMember(i => i.Position, i => i.MapFrom(i => i.location_description))
                  .ForMember(i => i.CardPayment, i => i.MapFrom(i => i.credit_card_payment))
             .ForMember(i => i.Phone, i => i.MapFrom(i => i.contacts.phone))
             .ForMember(i => i.Email, i => i.MapFrom(i => i.contacts.email))
             .ForMember(i => i.ZipCode, i => i.MapFrom(i => i.Address.postal_code))
             .ForMember(i => i.Location, i => i.MapFrom(i => new NetTopologySuite.Geometries.Point(i.position.lat, i.position.lng)));

        CreateMap<WeekDayWedo, WorkHoursModel>().ForMember(i => i.TimeFrom, i => i.MapFrom(i => i.from))
            .ForMember(i => i.TimeTo, i => i.MapFrom(i => i.to));

    }
}
