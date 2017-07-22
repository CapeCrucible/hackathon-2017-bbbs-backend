--Type (FIRST)

INSERT INTO UserTypes (UserTypeName)
VALUES ('Big');

INSERT INTO UserTypes (UserTypeName)
VALUES ('Little');

INSERT INTO UserTypes (UserTypeName)
VALUES ('Parent');

INSERT INTO UserTypes (UserTypeName)
VALUES ('Admin');



--User Account 

INSERT INTO UserAccounts (UserName, UserTypeId, FirstName, LastName)
VALUES ('T_Tiger', 1, 'Tony', 'Tiger');

INSERT INTO UserAccounts (UserName, UserTypeId, FirstName, LastName)
VALUES ('C_Cubb', 2, 'Corey', 'Cubb');

INSERT INTO UserAccounts (UserName, UserTypeId, FirstName, LastName)
VALUES ('B_Cubb', 3, 'Brenda', 'Cubb');

INSERT INTO UserAccounts (UserName, UserTypeId, FirstName, LastName)
VALUES ('ADMIN_1', 4, 'Jannice', 'Glass');

INSERT INTO UserAccounts (UserName, UserTypeId, FirstName, LastName)
VALUES ('L_Brock', 1, 'Larry', 'Brock');


--Addresses

INSERT INTO UserAddresses (StreetLine1, City, State, Zip)
VALUES ('123 Easy Street', 'Cape Girardeau', 'MO', '63701');

INSERT INTO UserAddresses (StreetLine1, City, State, Zip)
VALUES ('456 East Street', 'Cape Girardeau', 'MO', '63701');

INSERT INTO UserAddresses (StreetLine1, City, State, Zip)
VALUES ('456 Easy Street', 'Cape Girardeau', 'MO', '63701');

INSERT INTO UserAddresses (StreetLine1, StreetLine2, City, State, Zip)
VALUES ('1610 N. Kingshighway', 'Suite 305', 'Cape Girardeau', 'MO', '63701');

INSERT INTO UserAddresses (StreetLine1, City, State, Zip)
VALUES ('777 Sunny Ln', 'Cape Girardeau', 'MO', '63701');


--Contact Info

INSERT INTO ContactInfo (PhoneNumber, UserAddressId, UserAccountId, Email)
VALUES ('314-555-1234', 1, 1, 'Ttiger@gmail.com');

INSERT INTO ContactInfo (PhoneNumber, UserAddressId, UserAccountId, Email)
VALUES ('557-544-5085', 2, 2, 'Bcubb@gmail.com');

INSERT INTO ContactInfo (PhoneNumber, UserAddressId, UserAccountId, Email)
VALUES ('557-544-5085', 3, 3, 'Bcubb@gmail.com');

INSERT INTO ContactInfo (PhoneNumber, UserAddressId, UserAccountId, Email)
VALUES ('573-339-0184', 4, 4, 'Jglass@bigbrosANDsisters.com');

INSERT INTO ContactInfo (PhoneNumber, UserAddressId, UserAccountId, Email)
VALUES ('555-789-0123', 5, 5, 'Lbrock@gmail.com');


--Interest Table 

INSERT INTO Interests (InterestName)
VALUES ('Sports');

INSERT INTO Interests (InterestName)
VALUES ('Movies');

INSERT INTO Interests (InterestName)
VALUES ('Art');

INSERT INTO Interests (InterestName)
VALUES ('Science');

INSERT INTO Interests (InterestName)
VALUES ('Computers');

INSERT INTO Interests (InterestName)
VALUES ('Books');

INSERT INTO Interests (InterestName)
VALUES ('Games');


--interest user map
--Big & Little

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (1, 1);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (1, 3);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (1, 5);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (2, 1);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (2, 3);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (2, 5);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (5, 2);

INSERT INTO InterestUserMaps (UserAccountId, InterestId)
VALUES (5, 4);


