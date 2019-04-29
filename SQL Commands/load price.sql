LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Table_Price.csv'
INTO TABLE price
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(price_id, price, weekly_price, monthly_price, security_deposit, cleaning_fee, guests_included, extra_people, listing_id)