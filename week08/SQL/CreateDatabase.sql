DROP DATABASE HackCompany;


CREATE DATABASE HackCompany
ON 
( NAME = HackCompany_dat,
    FILENAME = 'F:\Dropbox\Programming\HackBulgaria\Database\HackCompanydat.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5 )
LOG ON
( NAME = HackCompany_log,
    FILENAME = 'F:\Dropbox\Programming\HackBulgaria\Database\HackCompanylog.ldf',
    SIZE = 5MB,
    MAXSIZE = 25MB,
    FILEGROWTH = 5MB ) ;
GO