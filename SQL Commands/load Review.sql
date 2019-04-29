LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/MergedReview.csv'
INTO TABLE Review  
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(@dummy, review_id, review_date, reviewer_id, reviewer_name, comments)