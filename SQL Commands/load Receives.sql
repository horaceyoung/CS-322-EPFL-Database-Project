LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/MergedReview.csv'
INTO TABLE receives 
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(listing_id, review_id)