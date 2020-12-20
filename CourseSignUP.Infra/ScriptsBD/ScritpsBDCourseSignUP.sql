

CREATE TABLE Student ( StudentId int identity , 
                       Email varchar(20) , 
					   StudentName varchar(50) , 
					   DateOfBirth Datetime , 
					   Constraint Constraint_name Primary Key(StudentId)) ;
					   
CREATE TABLE Course(
							 CourseId int identity,
							 CourseName varchar(50),
							 Capacity int NULL,
							 NumberOfStudents int NULL ,
							 Constraint PKCourse Primary Key(CourseId)) ;					   
					   

CREATE TABLE SignUPToCourse ( 
                              SignUPId int identity ,
							  CourseId int , 
                              StudentId int ,
							  Constraint PKSignUP Primary Key(SignUPId),
							  Constraint FKStudent Foreign Key (StudentId) REFERENCES Student(StudentId) ,
							  Constraint FKCourse Foreign Key (CourseId) REFERENCES Course(CourseId) 
							  ) ;
							  
Insert into dbo.Course ( CourseName , Capacity , NumberOfStudents ) values ( 'Informatica' , 20 , 0 ) ;
Insert into dbo.Course ( CourseName , Capacity , NumberOfStudents ) values ( 'Engenharia' , 10 , 0 ) ;
Insert into dbo.Course ( CourseName , Capacity , NumberOfStudents ) values ( 'Medicina' , 100 , 0 ) ;

insert into dbo.Student (  Email ,StudentName ,DateOfBirth ) values ( 'teste1@gmail.com' , 'Joao da Silva' ,  '01/04/1976' ) ;
insert into dbo.Student (  Email ,StudentName ,DateOfBirth ) values (  'teste2@gmail.com' , 'Pedro da Silva' , '01/04/1976' ) ;
insert into dbo.Student (  Email ,StudentName ,DateOfBirth ) values (  'teste3@gmail.com' , 'Maria da Silva' , '01/04/1996' ) ;
insert into dbo.Student (  Email ,StudentName ,DateOfBirth ) values (  'teste6@gmail.com' , 'Pablo da Silva' , '01/04/2005' ) ;

insert into dbo.SignUPToCourse ( CourseId , StudentId ) values ( 1 , 1 );
insert into dbo.SignUPToCourse ( CourseId , StudentId ) values ( 1 , 2 );
insert into dbo.SignUPToCourse ( CourseId , StudentId ) values ( 1 , 4 );
insert into dbo.SignUPToCourse ( CourseId , StudentId ) values ( 2 , 3 );
insert into dbo.SignUPToCourse ( CourseId , StudentId ) values ( 3 , 1 );
insert into dbo.SignUPToCourse ( CourseId , StudentId ) values ( 3 , 2 );	

commit ;								  