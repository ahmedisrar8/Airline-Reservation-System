create  table ars_users
(
uname varchar(50) primary key,
email varchar(100) unique,
name varchar(100),
pass varchar(100),
date datetime,
status char,
desg char
)
select * from ars_users

create table customer
(
sno int identity,
uname varchar(50) foreign key references ars_users(uname),
fname varchar(50),
lname varchar(50),
dob varchar(50),
mob varchar(50),
amob varchar(50)
)
create table wallet
(
wallet_id varchar(40) primary key,
uname varchar(50) foreign key references ars_users(uname),
balance bigint,
card_no varchar(20),
cvc varchar(20),
e_date varchar(20),
status char
)
create table ars_planes
(
plane_num varchar(100) primary key,
plane_model varchar(100),
b_capcity int,
e_cpacity int,
airport_code varchar(100) foreign key references ars_airport(airport_code),
date datetime,
status char
)
create table ars_prices
(
distance varchar(50),
price bigint
)
insert into ars_prices values('KHIISL',8350);
insert into ars_prices values('ISLLHR',6350);
create table ars_flights
(
sno int identity,
flight_num varchar(100) primary key,
d_date varchar(100),
d_time varchar(100),
a_date varchar(100),
a_time varchar(100),
price bigint,
d_airport_code varchar(100) foreign key references ars_airport(airport_code),
airport_code varchar(100) foreign key references ars_airport(airport_code),
plane_num varchar(100) foreign key references ars_planes(plane_num),
status varchar(50)
)
create table ars_airport
(
airport_code varchar(100) primary key,
airport_name varchar(100),
airport_city varchar(50),
airport_state varchar(50)
)
create table ars_ticket
(
sno int identity,
ticket_num varchar(100) primary key,
flight_num varchar(100) foreign key references ars_flights(flight_num),
uname varchar(50) foreign key references ars_users(uname),
Total_passengers int,
adults int,
child int,
infant int,
total bigint,
class varchar(50),
d_date varchar(50),
route varchar(100),
date datetime,
status varchar(50)
)
create table ars_flight_passenger
(
pass_no int identity,
ticket_num varchar(100) foreign key references ars_ticket(ticket_num),
pass_name varchar(100),
pass_dob varchar(50),
pass_mob varchar(50),
pass_amob varchar(50),
type varchar(50),
seats varchar(50)
)
insert into ars_airport values ('AR-KHI-001','Jinnah International Airport','Karachi','Sindh');
insert into ars_airport values ('AR-ISL-001','Benazir Bhutto International Airport','Rawalpind-Islamabad','Punjab');
insert into ars_airport values ('AR-LHR-001','Alama Iqbal International Airport','Lahore','Punjab');

insert into ars_planes values ('BAJ-001','Boeing 777-200LR',60,215,'AR-KHI-001',getdate(),'A');
insert into ars_planes values ('BAJ-002','Boeing 777-200LR',60,215,'AR-KHI-001',getdate(),'A');
insert into ars_planes values ('BAJ-003','Boeing 777-300ER',54,304,'AR-KHI-001',getdate(),'A');
insert into ars_planes values ('BAJ-004','Boeing 777-300ER',54,304,'AR-KHI-001',getdate(),'A');
insert into ars_planes values ('BAJ-005','Boeing 777-300ER',40,384,'AR-KHI-001',getdate(),'A');
insert into ars_planes values ('BAJ-006','Boeing 777-300ER',40,384,'AR-KHI-001',getdate(),'A');
insert into ars_planes values ('BAJ-007','ATR 72-500',12,58,'AR-ISL-001',getdate(),'A');
insert into ars_planes values ('BAJ-008','ATR 72-500',12,28,'AR-ISL-001',getdate(),'A');
