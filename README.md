# # Assignment: Course Sign-up System

Candidato: **Fábio Sarmento Pereira**

Prova Tecnica : **Analista Desenvolvedor .NET**. 




# Características

**Domain Model Design accessible**

**Banco de Dados SQL-Server - Cloud Azure**

**Api´s REST**





# Métodos


**Course** : Consulta e Cadastro de Cursos                  

**SignUpToCourse** : Inscricao de Alunos                             

**Statistics** : Consulta Estatisticas de Idade dos alunos   


# Modelo de Dados

CREATE TABLE **Student** ( StudentId int identity , 
                       Email varchar(20) , 
					   StudentName varchar(50) , 
					   DateOfBirth Datetime , 
					   Constraint Constraint_name Primary Key(StudentId)) ;
					   
CREATE TABLE **Course** (
							 CourseId int identity,
							 CourseName varchar(50),
							 Capacity int NULL,
							 NumberOfStudents int NULL ,
							 Constraint PKCourse Primary Key(CourseId)) ;					   
					   

CREATE TABLE **SignUPToCourse** ( 
                                 SignUPId int identity ,
					          	 	   CourseId int , 
                                 StudentId int ,
							            Constraint PKSignUP Primary Key(SignUPId),
							            Constraint FKStudent Foreign Key (StudentId) REFERENCES Student(StudentId) ,
							            Constraint FKCourse Foreign Key (CourseId) REFERENCES Course(CourseId) 
							           ) ;
   
