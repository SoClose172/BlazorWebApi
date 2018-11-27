CREATE TABLE HomeWork
(
	HomeWorkId int IDENTITY(1,1) NOT NULL PRIMARY KEY,       
    Name varchar(20) NOT NULL,        
    Block varchar(20) NOT NULL,        
    Rating varchar(20) NOT NULL,        
    Comment varchar(20) NOT NULL
)
