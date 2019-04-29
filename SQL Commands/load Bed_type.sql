LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/merged_listing_cleaned_BedType.csv'
INTO TABLE bed_type
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(bed_id, bed_type)