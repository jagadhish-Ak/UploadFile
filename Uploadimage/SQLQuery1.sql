create table Image
(
	ImageId int identity primary key,
	Title varchar(30),
	ImagePath varchar(50)

)
select * from Image

create table filedb
(
	FileId int identity primary key,
	Title varchar(30),
	FilePath varchar(30)
)

select * from filedb