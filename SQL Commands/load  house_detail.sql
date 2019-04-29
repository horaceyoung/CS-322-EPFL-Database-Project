LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Table_House_Details.csv'
INTO TABLE house_details
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(detail_id, property_type, room_type, accommodates, bathrooms, bedrooms, beds, bed_type, square_feet, listing_id)