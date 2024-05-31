# FuelAccounting
***Скрипт для добавления начальных данных:***
```
--- Пользователи ---
INSERT INTO Users(Id, FirstName, LastName, Patronymic, Mail, [Login], [Password], UserType, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('8332F643-7441-48DE-B864-1239FE95FB89', 'Вячеслав', 'Николаев', 'Александрович', 'nikolay@mail.ru', 'Nikolay', '$2a$11$lsI2QrcHH5U8Xf8TkNmvfO7JOm1mumCZPMIeAM3RaN741I.67WDVq', 1, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Users(Id, FirstName, LastName, Patronymic, Mail, [Login], [Password], UserType, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('AC1A1D03-C2BF-410A-8A45-910F974326B5', 'Игорь', 'Вороненков', NULL, 'voron2004@gmail.com', 'Voron', '$2a$11$lsI2QrcHH5U8Xf8TkNmvfO7JOm1mumCZPMIeAM3RaN741I.67WDVq', 0, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Users(Id, FirstName, LastName, Patronymic, Mail, [Login], [Password], UserType, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('9DBD6F69-E6E4-49B9-8EA4-F4E1C7847B4A', 'Андрей', 'Кулиш', 'Максимович', 'andrmena2004@gmail.com', 'Admin', '$2a$11$lsI2QrcHH5U8Xf8TkNmvfO7JOm1mumCZPMIeAM3RaN741I.67WDVq', 2, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- Грузовики ---
INSERT INTO Trucks (Id, [Name], Number, Vin, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('109C154A-0F87-407A-9359-A863BA5546FB', 'Scania Konstantinidis R950', 'А001АА198', 'GFHNGB1740WC236961', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Trucks (Id, [Name], Number, Vin, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('AB9877A9-1545-4CDE-B1EF-E24A9FD125B3', 'Volvo H9', 'О888ОО198', 'ААРАРD1740WC236961', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Trucks (Id, [Name], Number, Vin, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('0968D976-4DCE-44D2-9BFE-F0405BFC66C9', 'Volvo H6', 'О888ОО98', 'JHLRD1740WC236961', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- Полуприцепы ---
INSERT INTO Trailers (Id, [Name], Number, Capacity, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('23F17DFA-EAED-4721-A748-31345303588B', 'Tanker 5000', 'ОО888898', 5000, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Trailers (Id, [Name], Number, Capacity, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('5BDCCAB7-5350-4FCE-B42C-818BDB53B7B1', 'Tanker 2000', 'ОО8888198', 2000, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Trailers (Id, [Name], Number, Capacity, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('41EF7A96-C8A5-4A6C-8AEA-BE9C0785AB3C', 'Tanker Super 10000', 'АА1234198', 10000, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- Поставщики ---
INSERT INTO Suppliers (Id, [Name], Inn, Phone, [Description], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('44A9014C-7706-431C-8C75-574E2141FD28', '"ООО Юг"', '8910846978', '7(904)-596-28-34', 'Топливо по низкой цене', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Suppliers (Id, [Name], Inn, Phone, [Description], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('14EF42A5-AD31-4FB9-A6A2-718BA97119C6', '"ООО Север"', '9287882679', '7(904)-104-94-38', 'Лучшие в СПБ', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Suppliers (Id, [Name], Inn, Phone, [Description], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('1D89364C-1AEA-4416-9000-881F1CCC1E59', '"ООО Резерв"', '0306461633', '7(902)-317-03-75', null, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- АЗС ---
INSERT INTO FuelStations (Id, [Name], [Address], [Description], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('F1AA04EF-D0A3-4B72-9553-2A415E1A7400', 'Лукойл', 'Земледельческая ул., 5АБ, Санкт-Петербург', null, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO FuelStations (Id, [Name], [Address], [Description], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('E20B514D-269B-41CC-9E7D-77D03411B03B', 'Газпромнефть', 'Полевая Сабировская ул., 56, Санкт-Петербург', 'Хороши собой', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO FuelStations (Id, [Name], [Address], [Description], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('4D616FBE-B499-4B5C-A5CE-DE536D056DE0', 'Газпромнефть', 'Планерная ул., 30, Санкт-Петербург', null, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- Водители ---
INSERT INTO Drivers (Id, FirstName, LastName, Patronymic, Phone, DriversLicense, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('7842A022-A8BB-4643-8521-0A9246156CF7', 'Олег', 'Олегов', 'Олегович', '7(936)-258-18-38', '33-33-333333', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Drivers (Id, FirstName, LastName, Patronymic, Phone, DriversLicense, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('5716A7C9-F4D8-400B-AAB7-A6E92CEE66A0', 'Сергей', 'Сергеев', 'Сергеевич', '7(900)-397-68-97', '11-11-111111', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Drivers (Id, FirstName, LastName, Patronymic, Phone, DriversLicense, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('D2381C3C-278B-4B5A-AE82-CB76CC9E91EE', 'Максим', 'Максимов', 'Максимович', '7(908)-614-74-46', '22-22-222222', SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- Топливо ---
INSERT INTO Fuels (Id, FuelType, Price, SupplierId, [Count], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('C95984BF-BBC2-41E5-93E8-4969DEFEA430', 0, 55.12, '44A9014C-7706-431C-8C75-574E2141FD28', 8000, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Fuels (Id, FuelType, Price, SupplierId, [Count], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('A9603E39-9C46-401C-8391-636F7A3C6E09', 4, 98, '1D89364C-1AEA-4416-9000-881F1CCC1E59', 4000, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO Fuels (Id, FuelType, Price, SupplierId, [Count], CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('974E7785-7064-4919-A8DC-E2B71E649874', 1, 54.67, '14EF42A5-AD31-4FB9-A6A2-718BA97119C6', 4000, SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);

--- Накладные ---
INSERT INTO FuelAccountingItems (Id, DriverId, TruckId, TrailerId, FuelId, [Count], FuelStationId, StartDate, EndDate, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('10EF9B25-7AA8-426A-BA13-995E76E7331A', '7842A022-A8BB-4643-8521-0A9246156CF7', '109C154A-0F87-407A-9359-A863BA5546FB', '41EF7A96-C8A5-4A6C-8AEA-BE9C0785AB3C', 'A9603E39-9C46-401C-8391-636F7A3C6E09', 
	5000, 'E20B514D-269B-41CC-9E7D-77D03411B03B', SYSDATETIMEOFFSET(), DATEADD(day, 2, SYSDATETIMEOFFSET()), SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO FuelAccountingItems (Id, DriverId, TruckId, TrailerId, FuelId, [Count], FuelStationId, StartDate, EndDate, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('C70A2D02-6930-4ED3-8954-AA6C36434A66', '5716A7C9-F4D8-400B-AAB7-A6E92CEE66A0', '0968D976-4DCE-44D2-9BFE-F0405BFC66C9', '5BDCCAB7-5350-4FCE-B42C-818BDB53B7B1', 'C95984BF-BBC2-41E5-93E8-4969DEFEA430', 
	2000, '4D616FBE-B499-4B5C-A5CE-DE536D056DE0', SYSDATETIMEOFFSET(), DATEADD(day, 5, SYSDATETIMEOFFSET()), SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
INSERT INTO FuelAccountingItems (Id, DriverId, TruckId, TrailerId, FuelId, [Count], FuelStationId, StartDate, EndDate, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, DeletedAt) 
	VALUES ('8C07AA8C-9156-4D88-9D71-D99FF2781E54', 'D2381C3C-278B-4B5A-AE82-CB76CC9E91EE', 'AB9877A9-1545-4CDE-B1EF-E24A9FD125B3', '23F17DFA-EAED-4721-A748-31345303588B', '974E7785-7064-4919-A8DC-E2B71E649874', 
	1000, 'F1AA04EF-D0A3-4B72-9553-2A415E1A7400', SYSDATETIMEOFFSET(), DATEADD(day, 10, SYSDATETIMEOFFSET()), SYSDATETIMEOFFSET(), 'Admin', SYSDATETIMEOFFSET(), 'Admin', null);
 ```
