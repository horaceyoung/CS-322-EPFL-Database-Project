LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Table_Listing.csv'
INTO TABLE listing
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(listing_id, listing_url, listing_name, summary, space, listing_description, neighborhood_overview, notes, transit, access, interaction, house_rules, picture_url)