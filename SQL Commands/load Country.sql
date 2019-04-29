LOAD DATA INFILE  
'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Table_Host.csv'
INTO TABLE host
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(host_id, host_url, host_name, host_since, host_about, host_response_rate, host_response_time, host_thumbnail_url, host_neighborhood, host_verifications)