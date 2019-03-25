using AutoMapper;
using StudentAALibrary;
using StudentAALibrary.Migrations;
using StudentAAWebApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace StudentAAWebAPINew
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new StudentAAContextInitializer());
            
           

            Mapper.Initialize(c => {    c.CreateMap<Lecturer, LecturerDTO>();
                c.CreateMap<Student, StudentDTO>();
                c.CreateMap<Attendance, AttendanceDTO>();
                c.CreateMap<Assessment, AssessmentDTO>();
                c.CreateMap<StudentGrade, StudentGradeDTO>();
                c.CreateMap<Module, ModuleDTO>();
            });
            //Mapper.Initialize(c => { c.CreateMap<Lecturer, LecturerDTO>().ForMember(d => d.FirstName, b=> b.MapFrom(s=> s.FName));});
        }
    }
}
