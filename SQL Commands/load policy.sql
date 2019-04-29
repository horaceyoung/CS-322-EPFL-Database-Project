LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Table_Policy.csv'
INTO TABLE policy
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(policy_id, is_business_travel_ready, cancellation_policy, require_guest_profile_picture, require_guest_phone_verification, listing_id)