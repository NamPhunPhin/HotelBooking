drop table Hotels

go 

use TT_Hotel

go

CREATE TABLE Users
(
	user_id int PRIMARY KEY IDENTITY,
	role_type_id int,
	merchant_id int,
	last_name nvarchar(255),
	first_name nvarchar(255),
	contact_number varchar(20),
	address nvarchar(255),
	email nvarchar(255),
	password nvarchar(155),
	coin money,
	created timestamp
)

ALTER TABLE Users
ADD CONSTRAINT fk_role_type_id
FOREIGN KEY (role_type_id) REFERENCES RoleTypes (role_type_id);

ALTER TABLE Users
ADD CONSTRAINT fk_merchant_id
FOREIGN KEY (merchant_id) REFERENCES Merchants(merchant_id);


go

CREATE TABLE WishList
(
	wishlist_id int PRIMARY KEY IDENTITY,
	user_id  int,
	room_id int,
	created timestamp
)


ALTER TABLE WishList
ADD CONSTRAINT fk_User_Id
FOREIGN KEY (user_id) REFERENCES Users (user_id);

ALTER TABLE WishList
ADD CONSTRAINT constraint_name
FOREIGN KEY (room_id) REFERENCES Rooms (room_id);

go

CREATE TABLE RoleTypes
(
	role_type_id int PRIMARY KEY IDENTITY,
	name Nvarchar,
	created timestamp
)

go

CREATE TABLE RoleDetails
(
	role_details_id int PRIMARY KEY IDENTITY,
	role_type_id int,
	role_function_id int,
	created timestamp
)


ALTER TABLE RoleDetails
ADD CONSTRAINT fk_role_type_id_2
FOREIGN KEY (role_type_id) REFERENCES RoleTypes (role_type_id);


ALTER TABLE RoleDetails
ADD CONSTRAINT fk_role_function_id
FOREIGN KEY (role_function_id) REFERENCES RoleFunctions (role_function_id);

go

CREATE TABLE RoleFunctions
(
	role_function_id int PRIMARY KEY IDENTITY,
	name nvarchar(255),
	created timestamp
)


go

CREATE TABLE Contacts
(
	contact_id int PRIMARY KEY IDENTITY,
	last_name nvarchar(255),
	first_name nvarchar(255),
	email nvarchar(255),
	message ntext,
	created timestamp
)

go

CREATE TABLE Merchants
(
	merchant_id int PRIMARY KEY IDENTITY,
	name nvarchar(255),
	contact_number varchar(20),
	email nvarchar(255),
	address nvarchar(255),
	created timestamp
)

go

CREATE TABLE Orders
(
	order_id int PRIMARY KEY IDENTITY,
	fullname nvarchar(255),
	contact_number varchar(20),
	email nvarchar(255),
	address nvarchar(255),
	total_cost money,
	status int,
	created timestamp
)

go

CREATE TABLE OrderDetails
(
	order_details_id int PRIMARY KEY IDENTITY,
	room_id  int,
	order_id int,
	check_in date,
	check_out date,
	price money,
	created timestamp
)

ALTER TABLE OrderDetails
ADD CONSTRAINT fk_order_id
FOREIGN KEY (order_id) REFERENCES Orders (order_id);

ALTER TABLE OrderDetails
ADD CONSTRAINT fk_room_id
FOREIGN KEY (room_id) REFERENCES Rooms (room_id);



go

CREATE TABLE Hotels
(
	hotel_id int primary key IDENTITY,
	merchant_id int,
	country_id  int,
	city_id int,
	name Nvarchar(255),
	address Nvarchar(255),
	description ntext,
	rating decimal,
	distance_citycenter decimal,
	views int,
	created timestamp,
)

drop table Hotels

ALTER TABLE Hotels
ADD CONSTRAINT fk_merchant_id_2
FOREIGN KEY (merchant_id) REFERENCES Merchants (merchant_id);

ALTER TABLE Hotels
ADD CONSTRAINT fk_country_id
FOREIGN KEY (country_id) REFERENCES countries (country_id);


ALTER TABLE Hotels
ADD CONSTRAINT fk_city_id
FOREIGN KEY (city_id) REFERENCES Cities (city_id);
go

CREATE TABLE HotelsServices
(
	hotels_services_id int primary key IDENTITY,
	service_id int,
	service_detail_id int,
	hotel_id int,
	created timestamp
)

ALTER TABLE HotelsServices
ADD CONSTRAINT fk_service_id_2
FOREIGN KEY (service_id) REFERENCES Services (service_id);

ALTER TABLE HotelsServices
ADD CONSTRAINT fk_service_detail_id_2
FOREIGN KEY (service_detail_id) REFERENCES ServiceDetails (service_detail_id);


ALTER TABLE HotelsServices
ADD CONSTRAINT fk_hotel_id_2
FOREIGN KEY (hotel_id) REFERENCES Hotels (hotel_id);
go

CREATE TABLE Services
(
	service_id int primary key IDENTITY,
	service_name Nvarchar(255),
	icon varchar(255),
	created timestamp
)


go

CREATE TABLE ServiceDetails
(
	service_detail_id int primary key IDENTITY,
	service_id int,
	service_detail_name Nvarchar(255),
	icon varchar(255),
	price money,
	created timestamp
)

ALTER TABLE ServiceDetails
ADD CONSTRAINT fk_service_id_4
FOREIGN KEY (service_id) REFERENCES Services (service_id);


go

CREATE TABLE ImagesHotel
(
	image_id int primary key IDENTITY,
	hotel_id int,
	image_name nvarchar(255),
	created timestamp
)

ALTER TABLE ImagesHotel
ADD CONSTRAINT fk_hotel_id_5_a
FOREIGN KEY (hotel_id) REFERENCES Hotels (hotel_id);


go

CREATE TABLE Countries
(
	country_id int primary key IDENTITY,
	name nvarchar(255),
	image_name nvarchar(255),
	created timestamp
)

go

CREATE TABLE Cities
(
	city_id int primary key IDENTITY,
	country_id int,
	name nvarchar(255),
	image_name nvarchar(255),
	created timestamp
)

ALTER TABLE Cities
ADD CONSTRAINT fk_country_id_1
FOREIGN KEY (country_id) REFERENCES Countries (country_id);

go


CREATE TABLE Rooms
(
	room_id int primary key IDENTITY,
	hotel_id int,
	room_type_id int,
	number_people int,
	created timestamp
)

ALTER TABLE Rooms
ADD CONSTRAINT fk_hotel_id_1
FOREIGN KEY (hotel_id) REFERENCES Hotels (hotel_id);
ALTER TABLE Rooms
ADD CONSTRAINT fk_room_type_id
FOREIGN KEY (room_type_id) REFERENCES RoomTypes (room_type_id);

go


CREATE TABLE RoomTypes
(
	room_type_id int primary key IDENTITY,
	name nvarchar(255),
	room_area float,
	number_bed int,
	smoking_allowed bit,
	created timestamp
)



go


CREATE TABLE ImagesRoom
(
	image_id int primary key IDENTITY,
	room_type_id int,
	image_name nvarchar(255),
	created timestamp
)
ALTER TABLE ImagesRoom
ADD CONSTRAINT fk_room_type_id_2
FOREIGN KEY (room_type_id) REFERENCES RoomTypes (room_type_id);
go


CREATE TABLE RoomAmenities
(
	room_amenities_id int primary key IDENTITY,
	room_type_id int,
	amenity_id int,
	created timestamp
)
ALTER TABLE RoomAmenities
ADD CONSTRAINT fk_room_type_id_3
FOREIGN KEY (room_type_id) REFERENCES RoomTypes (room_type_id);

ALTER TABLE RoomAmenities
ADD CONSTRAINT fk_amenity_id
FOREIGN KEY (amenity_id) REFERENCES Amenities (amenity_id);

go


CREATE TABLE Amenities
(
	amenity_id int primary key IDENTITY,
	name nvarchar(255),
	icon varchar(255),
	created timestamp
)




ALTER TABLE table_name
ADD CONSTRAINT constraint_name
FOREIGN KEY (column_name) REFERENCES referenced_table (referenced_column_name);