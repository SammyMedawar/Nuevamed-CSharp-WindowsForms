/*create table Login(
Username nvarchar(25),
Password varchar(6),
primary key (Username),
);
create table Admin(
SSNA int,
Username nvarchar(25),
Name nvarchar(50),
Email nvarchar(50),
Extension int,
PhoneNumber int,
Picture nvarchar(300),
primary key (SSNA),
);

create table Doctor(
SSND int,
Username nvarchar(25),
Name nvarchar(25),
OfficeHours nvarchar(50),
Extension int,
Picture nvarchar(300),
primary key(SSND),
);

create table Receptionist(
SSNR int,
Username nvarchar(25),
SSNA int,
Name nvarchar(25),
Email nvarchar(50),
OfficeHours nvarchar(50),
Phonenumber int,
Picture nvarchar(300),
primary key (SSNR),
);

create table Patient(
SSNP int,
Name nvarchar(25),
Gender char(1),
Age int,
Status bit,
Phonenumber int,
primary key (SSNP),
);
create table ManagesP(
SSNR int,
SSNP int,
--edit add remove
primary key (SSNR,SSNP),
);
create table Appointment(
IDA int,
SSNP int,
SSNR int,
Officenumber int,
Datetimes datetime,
primary key (IDA),
);
create table MedicalRecord(
IDM int,
SSNP int,
primary key (IDM),
);
create table Setup(
SSNR int,
IDM int,
--eidt add remove
primary key (SSNR,IDM),
);
create table ViewMR(
IDM int,
SSND int,
primary key (IDM,SSND),
);
create table Checks(
SSND int,
AppID int,
primary key (SSND,AppID),
);
create table Diagnosis(
ID int,
IDM int,
Name nvarchar(25),
StartDate date,
EndDate date,
Status bit,
FamilyHistory text,
primary key (ID),
);
create table Allergies(
ID int,
IDM int,
Source text,
primary key (ID),
);
create table Medications(
ID int,
IDM int,
Name nvarchar (25),
StartDate time,
EndDate time,
primary key(ID),
);
*/


alter table Admin
add constraint Login_Admin_Username
foreign key (Username) references Login (Username);

alter table Doctor
add constraint Login_Doctor_Username
foreign key (Username) references Login (Username);

alter table Receptionist
add constraint Login_Receptionist_Username
foreign key (Username) references Login (Username);

alter table Receptionist
add constraint Admin_Receptionist_SSNA
foreign key (SSNA) references Admin (SSNA);

alter table ManagesP
add constraint Receptionist_ManagesP_SSNR
foreign key (SSNR) references Receptionist (SSNR);

alter table ManagesP
add constraint Patient_ManagesP_SSNP
foreign key (SSNP) references Patient (SSNP);

alter table Appointment
add constraint Patient_Appointment_SSNP
foreign key (SSNP) references Patient (SSNP);

alter table Appointment
add constraint Receptionist_Appointment_SSNR
foreign key (SSNR) references Receptionist (SSNR);

alter table MedicalRecord
add constraint Patient_MedicalRecord_SSNP
foreign key (SSNP) references Patient (SSNP);

alter table Setup
add constraint Receptionist_Setup_SSNR
foreign key (SSNR) references Receptionist (SSNR);

alter table Setup
add constraint MedicalRecord_Setup_IDM
foreign key (IDM) references MedicalRecord (IDM);

alter table ViewMR
add constraint MedicalRecord_ViewMR_IDM
foreign key (IDM) references MedicalRecord (IDM);

alter table ViewMR
add constraint Doctor_ViewMR_SSND
foreign key (SSND) references Doctor (SSND);

alter table Checks
add constraint Doctor_Checks_SSND
foreign key (SSND) references Doctor (SSND);

alter table Checks
add constraint Appointment_Checks_IDA
foreign key (AppID) references Appointment (IDA);

alter table Diagnosis
add constraint MedicalRecord_Diagnosis_IDM
foreign key (IDM) references MedicalRecord (IDM);

alter table Allergies
add constraint MedicalRecord_Allergies_IDM
foreign key (IDM) references MedicalRecord (IDM);

alter table Medications
add constraint MedicalRecord_Medications_IDM
foreign key (IDM) references MedicalRecord (IDM);

/*
insert into Login values ('Admin' , '12Ot344');
insert into Login values ('Oto' , '12Ot342' );
insert into Login values ('Cardio' , '12Ca347' );
insert into Login values ('Optha' , '12Op345' );
insert into Login values ('Recep' , '12Re348' );
*/