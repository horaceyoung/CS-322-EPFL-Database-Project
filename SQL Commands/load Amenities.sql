LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/merged_listing_cleaned_cleaned_AmenitiesList.csv'
INTO TABLE amenities
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(amenity_id, amenity_name)