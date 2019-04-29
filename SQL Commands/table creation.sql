drop table if exists Listing;
drop table if exists Host;
drop table if exists Located_at;
drop table if exists Review;
drop table if exists Receives;
drop table if exists Score;
drop table if exists Policy;
drop table if exists Has;
drop table if exists Price;
drop table if exists Incurs;
drop table if exists House_Details;
drop table if exists Amenities;
drop table if exists Contains;

CREATE TABLE Listing
	(
	 listing_id INTEGER(10) NOT NULL,
	 listing_url VARCHAR(255),
 	 listing_name 	VARCHAR(255) NOT NULL,
	 summary VARCHAR(255),
	 space VARCHAR(255),
	 listing_description VARCHAR(255),
	 neighborhood_overview VARCHAR(255),
	 notes VARCHAR(255),
	 transit VARCHAR(255),
	 access VARCHAR(255),
	 interaction VARCHAR(255),
	 house_rules VARCHAR(255),
	 picture_url VARCHAR(255),
	 PRIMARY KEY(listing_id),
	 UNIQUE(listing_url),
	 UNIQUE(picture_url)
	);

CREATE TABLE Host 
	(
	 host_id INTEGER(10) NOT NULL,
	 host_url VARCHAR(255) NOT NULL,
	 host_name VARCHAR(255) NOT NULL,
	 host_since DATE,
  	 host_about VARCHAR(255),
	 host_response_rate FLOAT(10),
	 host_response_time VARCHAR(255),
	 host_thumbnail_url VARCHAR(255),
	 host_neighborhood VARCHAR(255),
	 host_verifications VARCHAR(255),
	 PRIMARY KEY(host_id),
	 UNIQUE(host_url)
	);

CREATE TABLE Own_by
	(
	 host_id INTEGER(10),
	 listing_id INTEGER(10),
	 PRIMARY KEY(host_id),
	 FOREIGN KEY(listing_id) REFERENCES Listing(listing_id)
	);


CREATE TABLE Venue
	(
	 venue_id INTEGER(10) NOT NULL,
	 neighborhood VARCHAR(255) ,
	 city VARCHAR(255),
	 country_code VARCHAR(255),
	 latitude DOUBLE,
	 longtitude DOUBLE,
	 PRIMARY KEY(venue_id)
	);


CREATE TABLE Located_at
	(
	 venue_id INTEGER(10),
	 listing_id INTEGER(10),
	 PRIMARY KEY(venue_id),
	 FOREIGN KEY(listing_id) REFERENCES Listing(listing_id)
	);


CREATE TABLE Review
	(
	review_id INTEGER(10) NOT NULL,
	reveiw_date DATE NOT NULL,
	reviewer_id INTEGER(10) NOT NULL,
	reviewer_name VARCHAR(255) NOT NULL,
	comments VARCHAR(255)
	);


CREATE TABLE Receives
	(
	listing_id INTEGER(10),
	review_id INTEGER(10),
	PRIMARY KEY(listing_id, review_id),
	FOREIGN KEY(listing_id) REFERENCES Listing(listing_id)
	);


CREATE TABLE Score
	(
	score_id INTEGER(10),
	review_scores_accuracy INTEGER(10) NOT NULL,
	review_scores_clean INTEGER(10) NOT NULL,
	reciew_scores_checkin INTEGER(10) NOT NULL,
	review_scores_communication INTEGER(10) NOT NULL,
	review_scores_location INTEGER(10) NOT NULL,
	review_scores_value INTEGER(10) NOT NULL
	);


CREATE TABLE Policy
	(
	policy_id INTEGER(10) NOT NULL,
    listing_id integer(1) not null,
	is_business_travel_ready varchar(1),
	cancellation_policy integer(1),
	require_guest_profile_picture varchar(1),
	require_guest_phone_verification varchar(1),
	PRIMARY KEY(policy_id, listing_id)
	);

CREATE TABLE Has
	(
	policy_id INTEGER(10),
	listing_id INTEGER(10),
    PRIMARY KEY(policy_id),
    FOREIGN KEY(listing_id) REFERENCES Listing(listing_id)
	);

CREATE TABLE Price
	(
	price_id INTEGER(10),
    listing_id INTEGER(10),
	price FLOAT(10),
	weekly_price FLOAT(10),
	monthly_price FLOAT(10),
	security_deposit FLOAT(10),
	cleaning_fee FLOAT(10),
	guests_included INTEGER(10),
	extra_people INTEGER(10),
	PRIMARY KEY(price_id)
    foreign key(listing_id) references listing(listing_id)
	);

CREATE TABLE Incurs
	(
	price_id INTEGER(10),
	listing_id INTEGER(10),
	PRIMARY KEY(price_id),
	FOREIGN KEY(listing_id) REFERENCES Listing(listing_id)
	);

CREATE TABLE House_Details
	(
	detail_id INTEGER(10) NOT NULL,
	listing_id INTEGER(10) NOT NULL,
	property_type INTEGER(10),
	room_type INTEGER(10),
	accommodates INTEGER(10),
	bathrooms INTEGER(10),
	bedrooms INTEGER(10),
	beds INTEGER(10),
	bed_type INTEGER(10),
	square_feet INTEGER(10),
	PRIMARY KEY(detail_id),
    foreign key(listing_id) references listing(listing_id)
	);


CREATE TABLE Amenities
	(
	amenity_id INTEGER(10),
	amenity_name varchar(255),
	PRIMARY KEY(amenity_id)
	);


CREATE TABLE Contains
	(
	listing_id INTEGER(10),
	amenity_id INTEGER(10),
	PRIMARY KEY(amenity_id),
	FOREIGN KEY(listing_id) REFERENCES Listing(listing_id)
	);
    
    CREATE TABLE City
	(
	city_id INTEGER(10),
	city_name text,
	PRIMARY KEY(city_id)
	);
    
    CREATE TABLE Country
	(
	country_id INTEGER(10),
	country_name text,
	PRIMARY KEY(country_id)
	);