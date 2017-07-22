--Type (FIRST)

INSERT INTO type (type_name)
VALUES ('Big');

INSERT INTO type (type_name)
VALUES ('Little');

INSERT INTO type (type_name)
VALUES ('Parent');

INSERT INTO type (type_name)
VALUES ('Admin');



--User Account 

INSERT INTO user_account (user_name, type_id, first_name, last_name)
VALUES ('T_Tiger', 1, 'Tony', 'Tiger');

INSERT INTO user_account (user_name, type_id, first_name, last_name)
VALUES ('C_Cubb', 2, 'Corey', 'Cubb');

INSERT INTO user_account (user_name, type_id, first_name, last_name)
VALUES ('B_Cubb', 3, 'Brenda', 'Cubb');

INSERT INTO user_account (user_name, type_id, first_name, last_name)
VALUES ('ADMIN_1', 4, 'Jannice', 'Glass');

INSERT INTO user_account (user_name, type_id, first_name, last_name)
VALUES ('L_Brock', 5, 'Larry', 'Brock');


--Addresses

INSERT INTO user_address (street_line_1, city, state, zip)
VALUES ('123 Easy Street', 'Cape Girardeau', 'MO', 63701);

INSERT INTO user_address (street_line_1, city, state, zip)
VALUES ('456 East Street', 'Cape Girardeau', 'MO', 63701);

INSERT INTO user_address (street_line_1, city, state, zip)
VALUES ('456 Easy Street', 'Cape Girardeau', 'MO', 63701);

INSERT INTO user_address (street_line_1, street_line_2, city, state, zip)
VALUES ('1610 N. Kingshighway', 'Suite 305', 'Cape Girardeau', 'MO', 63701);

INSERT INTO user_address (street_line_1, city, state, zip)
VALUES ('777 Sunny Ln', 'Cape Girardeau', 'MO', 63701);


--Contact Info

INSERT INTO contact_info (phone_number, address_id, user_id, email)
VALUES (3145551234, 1, 1, 'Ttiger@gmail.com');

INSERT INTO contact_info (phone_number, address_id, user_id, email)
VALUES (5575445085, 2, 2, 'Bcubb@gmail.com');

INSERT INTO contact_info (phone_number, address_id, user_id, email)
VALUES (5575445085, 3, 3, 'Bcubb@gmail.com');

INSERT INTO contact_info (phone_number, address_id, user_id, email)
VALUES (5733390184, 4, 4, 'Jglass@bigbrosANDsisters.com');

INSERT INTO contact_info (phone_number, address_id, user_id, email)
VALUES (5557890123, 5, 5, 'Lbrock@gmail.com');


--Interest Table 

INSERT INTO interest (interest)
VALUES ('Sports');

INSERT INTO interest (interest)
VALUES ('Movies');

INSERT INTO interest (interest)
VALUES ('Art');

INSERT INTO interest (interest)
VALUES ('Science');

INSERT INTO interest (interest)
VALUES ('Computers');

INSERT INTO interest (interest)
VALUES ('Books');

INSERT INTO interest (interest)
VALUES ('Games');


--interest user map
--Big & Little

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (1, 1);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (1, 3);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (1, 5);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (2, 1);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (2, 3);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (2, 5);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (5, 2);

INSERT INTO interest_user_map (user_ID, interest_id)
VALUES (5, 4);


