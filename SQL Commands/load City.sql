LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/merged_listing_cleaned_City.csv'
INTO TABLE city
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(city_id, city_name)