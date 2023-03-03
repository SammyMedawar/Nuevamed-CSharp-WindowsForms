/*
insert into Appointment values (01 , 20210166 , 2017 , 103 , '2007-05-08 12:35');
insert into Appointment values (02 , 20210188 , 2017 , 102 , '2015-05-08 12:35');
insert into Appointment values (03 , 20201458 , 2017 , 101 , '2011-07-25 12:35');
insert into Appointment values (04 , 20178451 , 2017 , 103 , '2008-06-18 12:35');

insert into MedicalRecord values (2300 , 20210188);
insert into MedicalRecord values (2500 , 20210166);
insert into MedicalRecord values (2600 , 20201458);
insert into MedicalRecord values (2100 , 20178451);

insert into Setup values (2017 , 2300);
insert into Setup values (2017 , 2500);
insert into Setup values (2017 , 2600);
insert into Setup values (2017 , 2100);

insert into ViewMR values (2300 , 2019);
insert into ViewMR values (2500 , 2020);
insert into ViewMR values (2600 , 2019);
insert into ViewMR values (2100 , 2018);

insert into Checks values (2020 , 01);
insert into Checks values (2019 , 02);
insert into Checks values (2019 , 03);
insert into Checks values (2020 , 04);

insert into Diagnosis (ID,IDM,Name,StartDate,EndDate,Status)values (5544 , 2300 , 'cancer' , '2019-4-1' , '2020-9-2', 0  );

insert into Diagnosis (ID,IDM,Name,StartDate,Status,FamilyHistory)values (6556 , 2100 , 'Asthma' ,'2006-5-20', 1 , 'Mother is a Carrier'   );

insert into Diagnosis values (8932 , 2500 , 'Hypermetropia' ,'2018-01-08' , '2020-05-20', 0 ,'Carried by the Father' );

insert into Receptionist values (2017 , 'Recep' , 20210000 , 'Naser' , 'Nas@gmail.com' , 'MTWRFS 8a.m --> 9p.m' , 71254865 ,'ReceptionistNaser.jpg' );

insert into Allergies values (11 , 2100 , 'Drug');
insert into Allergies values (34 , 2500 , 'Pollen');
insert into Allergies values (19 , 2300 , 'Dust');

insert into Medications values (1982 , 2100 , 'Aries' , '2018-12-4' , '2019-5-20');
insert into Medications values (1354 , 2500 , 'Allegra' , '2019-11-6' , '2020-08-26');
insert into Medications values (1267 , 2300 , 'Benadryl' , '2016-4-12' , '2017-12-12');


update Medications set StartDate='2018-12-4' , EndDate='2019-5-20' where ID = 1982 ;
update Medications set StartDate='2016-4-12' , EndDate='2020-08-26' where ID = 1267 ;
update Medications set StartDate='2019-11-6' , EndDate='2020-08-26' where ID = 1354 ;
*/
select *  from Admin

select * from Diagnosis 
select * from Allergies


select * from MedicalRecord

select * from Medications
