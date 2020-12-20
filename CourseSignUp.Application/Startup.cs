using Api.CrossCutting.DependencyInjection;
using AutoMapper;
using CourseSignUp.Application.Model;
using CourseSignUp.Application.Validators;
using CourseSignUp.Domain.Entities;
using CourseSignUp.Services.Commands.Course;
using CourseSignUp.Services.Commands.SignUpToCourse;
using CourseSignUp.Services.Commands.Statistics;
using CourseSignUp.Services.Commands.Student;
using CourseSignUp.Services.Handler.Course;
using CourseSignUp.Services.Handler.SignUpToCourse;
using CourseSignUp.Services.Handler.Statistics;
using CourseSignUp.Services.Handler.Student;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CourseSignUp.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Course Sign Up",
                        Version = "v1",
                        Description = "Course Registration API",
                        Contact = new OpenApiContact
                        {
                            Name = "Fábio Sarmento Pereira",
                            Url = new Uri("https://github.com/pereirfa")
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(typeof(Startup));
            
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCourseCommand, Course>, CourseCommandHandler>();
            services.AddTransient<IRequestHandler<GetByIdCourseQuery, Course>, CourseCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllCourseQuery, IEnumerable<Course>>, CourseCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCourseCommand, bool>, CourseCommandHandler>();

            services.AddTransient<IRequestHandler<CreateSignUpToCourseCommand, bool >, SignUpToCourseCommandHandler>();
            services.AddTransient<IRequestHandler<GetByIdSignUpToCourseQuery, SignUpToCourse>, SignUpToCourseCommandHandler>();

            services.AddTransient<IRequestHandler<GetAllStatisticsQuery, IEnumerable<Statistics>>, StatisticsCommandHandler>();
            services.AddTransient<IRequestHandler<GetByIdStatisticsQuery, Statistics>, StatisticsCommandHandler>();

            services.AddTransient<IRequestHandler<CreateStudentCommand, bool>, StudentCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteStudentCommand, bool>, StudentCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>, StudentCommandHandler>();
            services.AddTransient<IRequestHandler<GetByIdStudentQuery, Student>, StudentCommandHandler>();

            services.AddTransient<IValidator<CourseModel>, CourseValidator>();
            services.AddTransient<IValidator<SignUpToCourseModel>, SignUpToCourseValidator>();
            services.AddTransient<IValidator<StudentModel>, StudentValidator>();


            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CourseValidator>());
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SignUpToCourseValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Course Sign Up");
            });
        }
    }
}
