-- Create a table for bands
CREATE TABLE "Bands"
(
  "Id" SERIAL PRIMARY KEY,
  "Name" TEXT NOT NULL,
  "CountryOfOrigin" TEXT NOT NULL,
  "NumberOfMembers" INT,
  "Website" TEXT,
  "Style" TEXT NOT NULL,
  "IsSigned" BOOLEAN,
  "ContactName" TEXT,
  "ContactPhoneNumber" VARCHAR(20)
);

-- Create a table for albums
CREATE TABLE "Albums"
(
  "Id" SERIAL PRIMARY KEY,
  "Title" TEXT NOT NULL,
  "IsExplicit" BOOLEAN,
  "ReleaseDate" TIMESTAMP,
  "BandId" INT REFERENCES "Bands" ("Id")
);

-- Add a band
INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('The Beatles', 'United Kingdom', 4, 'https://www.thebeatles.com/', 'Rock', 'false', 'Brian Epstein', '+44 1234 123451');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('The Rolling Stones', 'United Kingdom', 4, 'https://rollingstones.com', 'Rock', 'true', 'Andrew Loog Oldham', '+44 1234 123452');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Carly Rae Jepsen', 'Canada', 1, 'https://www.carlyraemusic.com/', 'Pop', 'true', 'Scooter Braun', '+1 123 456 7890');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Sigur Ros', 'Iceland', 4, 'https://sigurros.com/', 'Experimental', 'true', 'John Best', '+354 123 456 7891');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Queen', 'United Kingdom', 4, 'http://www.queenonline.com/', 'Rock', 'false', 'Jim Beach', '+44 1234 123453');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('The Magnetic Fields', 'USA', 5, 'http://www.houseoftomorrow.com/', 'Rock', 'true', 'Andrew Loog Oldham', '+44 1234 123454');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('The Killers', 'USA', 4, 'http://thekillersmusic.com/', 'Alternative Rock', 'true', 'Robert Reynolds', '+1 123 456 7892');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Tatusro Yamashita', 'Japan', 1, 'https://tatsuro.co.jp/', 'City Pop', 'true', null, '+81 123 456 7893');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Mariya Takeuchi', 'Japan', 1, 'https://www.mariyat.co.jp/', 'City Pop', 'true', null, '+81 123 456 7894');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Houndmouth', 'USA', 3, 'https://www.houndmouth.com/', 'Alternative Country', 'true', 'Jason Gwin', '+1 123 456 7895');

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('John Denver', 'USA', 1, 'https://johndenver.com/website', 'Country', 'false', 'Jerry Weintraub', '+1 123 456 7896');

-- View all bands
SELECT * 
FROM "Bands";

-- Add an album for a band
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('White Album', 'false', '11/22/1968', 1);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Let It Be', 'false', '05/08/1970', 1);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Abbey Road', 'false', '11/26/1969', 1);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Sticky Fingers', 'false', '04/23/1971', 2);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Let It Bleed', 'false', '12/05/1969', 2);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Some Girls', 'false', '06/09/1978', 2);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Emotion', 'false', '06/24/2015', 3);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Dedicated', 'false', '05/17/2019', 3);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Valtari', 'false', '05/23/2012', 4);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Ágætis Byrjun', 'false', '06/12/1999', 4);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('A Night at the Opera', 'false', '11/21/1975', 5);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('69 Love Songs', 'false', '09/07/1999', 6);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Hot Fuss', 'false', '09/07/1999', 7);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('For You', 'false', '01/21/1982', 8);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Ride On Time', 'false', '09/19/1980', 8);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Variety', 'false', '04/25/1984', 9);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Little Neon Limelight', 'false', '03/16/2015', 10);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Poems, Prayers & Promises', 'false', '04/06/1971', 11);

-- Let a band go
UPDATE "Bands"
SET "IsSigned" = 'false'
WHERE "IsSigned" = 'true'
AND "Name" = 'Insert Band Name Here';

-- Resign a band
UPDATE "Bands"
SET "IsSigned" = 'true'
WHERE "IsSigned" = 'false'
AND "Name" = 'Insert Band Name Here';

-- Given a band's name view all of their albums
SELECT *
FROM "Albums"
JOIN "Bands" ON "Albums"."BandId" = "Bands"."Id"
Where "Bands"."Name" = 'Insert Band Name Here';

-- View all albums ordered by release date
SELECT *
FROM "Albums"
ORDER BY "ReleaseDate";

-- View all bands that are signed
SELECT * 
FROM "Bands"
WHERE "IsSigned" = 'true';

-- View all bands that are not signed 
SELECT * 
FROM "Bands"
WHERE "IsSigned" = 'false';

-- Views all bands and their albums
SELECT "Bands".*, "Albums".*
FROM "Albums"
JOIN "Bands" ON "Albums"."BandId" = "Bands"."Id"