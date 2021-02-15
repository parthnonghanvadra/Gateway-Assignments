using AutoMapper;
using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository
{
    public class autoMapperConfig
    {
        public static Mapper CustomerToDbCustomerMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Customer, Database.Customer>();
        }));

        public static Mapper VehicleToDbVehicleMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Vehicle, Database.Vehicle>();
        }));

        public static Mapper DbVehicleToVehicleMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Database.Vehicle, Vehicle>();
        }));

        public static Mapper DbDealerToDealerMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Database.Dealer, Dealer>();
        }));

        public static Mapper DbManufacturerToManufacturerMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Database.Manufacturer, Manufacturer>();
        }));

        public static Mapper AppointmentToDbAppointment = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Appointment, Database.Appointment>();
        }));

        public static Mapper DbAppointmentToAppointment = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Database.Appointment, Appointment>();
        }));

        public static Mapper DbServiceToService = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Service, Service>();
        }));

    }
}
