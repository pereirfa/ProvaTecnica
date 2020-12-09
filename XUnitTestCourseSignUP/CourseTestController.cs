using System;
using System.Collections.Generic;
using System.Text;
using CourseSignUP.AppServices;
using CourseSignUP.Controllers;
using CourseSignUP.Interfaces;
using CourseSignUP.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xunit; 

namespace XUnitTestCourseSignUP
{
    public class CourseTestController
    {
        CoursesController _controller;
        ICoursesAppService _service;

        private readonly IConfiguration _configuration;
        private Microsoft.Extensions.Logging.ILogger _LoggerFactory;

        public CourseTestController()
        {
            _service = new CourseTestAppService(_configuration, _LoggerFactory);
        }


        [Theory]
        [InlineData("SGU")]
        public void GetCourse_WhenCalled_ReturnsOkResult(string Id)
        {
            var valorEsperado = new List<CourseDto>();
            valorEsperado.Add(new CourseDto()
            {
                Id = "SGU",
                Capacity = 1500,
                NumberOfStudents = 33
            });
 
             // Act
            var okResult = _service.GetCourse(Id) ; 
            
            // Assert
            Assert.Equal(valorEsperado, okResult);
        }



    }
}
