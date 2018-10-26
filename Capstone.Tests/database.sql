-- Delete All of the Data
DELETE FROM reservation;
DELETE FROM [site];
DELETE FROM campground;
DELETE FROM park;

-- RESEED ID to 0
dbcc CHECKIDENT('park', RESEED, 0);
dbcc CHECKIDENT('campground', RESEED, 0);
dbcc CHECKIDENT('site', RESEED, 0);
dbcc CHECKIDENT('reservation', RESEED, 0);

-- INSERT Fake Data
INSERT INTO park (name, location, establish_date, area, visitors, description)VALUES ('Testpark', 'Smep', '10/22/1990', 10, 5, 'I ate fries here');
DECLARE @parkId int =(SELECT @@IDENTITY);
INSERT INTO campground (park_id, name, open_from_mm, open_to_mm, daily_fee) VALUES (@parkId, 'Testcampground', 10, 12, 5);
DECLARE @campgroundId int =(SELECT @@IDENTITY);
INSERT INTO [site] (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (@campgroundId, 1, 7, 0, 20, 0);

select * from campground