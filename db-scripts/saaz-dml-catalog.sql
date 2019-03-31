--select
SELECT * FROM CATALOGTYPE;
SELECT * FROM CATALOGBRAND;
SELECT * FROM CATALOGCATEGORY;
SELECT * FROM CATALOGSUBCATEGORY;

--insert
INSERT INTO CATALOGTYPE (TYPENAME, CREATEDATE, CREATEBY) VALUES ('Product',GETDATE(),'zaheer');
INSERT INTO CATALOGTYPE (TYPENAME, CREATEDATE, CREATEBY) VALUES ('Service',GETDATE(),'zaheer');
GO

INSERT INTO CATALOGBRAND (BRANDNAME, CREATEDATE, CREATEBY) VALUES ('Vault',GETDATE(),'zaheer');
INSERT INTO CATALOGBRAND (BRANDNAME, CREATEDATE, CREATEBY) VALUES ('Fender',GETDATE(),'zaheer');
INSERT INTO CATALOGBRAND (BRANDNAME, CREATEDATE, CREATEBY) VALUES ('Yamaha',GETDATE(),'zaheer');
INSERT INTO CATALOGBRAND (BRANDNAME, CREATEDATE, CREATEBY) VALUES ('Jbl',GETDATE(),'zaheer');
INSERT INTO CATALOGBRAND (BRANDNAME, CREATEDATE, CREATEBY) VALUES ('Ibanez',GETDATE(),'zaheer');
GO

INSERT INTO CATALOGCATEGORY(CATEGORYNAME, CREATEDATE, CREATEBY) VALUES ('Guitars',GETDATE(),'zaheer');
BEGIN    
	DECLARE @catid INT = (SELECT ID FROM CATALOGCATEGORY WHERE CATEGORYNAME = 'Guitars');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Acoustic',GETDATE(),'zaheer');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Electric',GETDATE(),'zaheer');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Classical',GETDATE(),'zaheer');
END

INSERT INTO CATALOGCATEGORY(CATEGORYNAME, CREATEDATE, CREATEBY) VALUES ('Drums',GETDATE(),'zaheer');
BEGIN    
	SET @catid = (SELECT ID FROM CATALOGCATEGORY WHERE CATEGORYNAME = 'Drums');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Acoustic',GETDATE(),'zaheer');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Electronic',GETDATE(),'zaheer');
END

INSERT INTO CATALOGCATEGORY(CATEGORYNAME, CREATEDATE, CREATEBY) VALUES ('Keyboards & Pianos',GETDATE(),'zaheer');
INSERT INTO CATALOGCATEGORY(CATEGORYNAME, CREATEDATE, CREATEBY) VALUES ('Amplifiers',GETDATE(),'zaheer');

INSERT INTO CATALOGCATEGORY(CATEGORYNAME, CREATEDATE, CREATEBY) VALUES ('DJ Gear',GETDATE(),'zaheer');
BEGIN    
	SET @catid = (SELECT ID FROM CATALOGCATEGORY WHERE CATEGORYNAME = 'DJ Gear');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Controllers & Interfaces',GETDATE(),'zaheer');
	INSERT INTO CATALOGSUBCATEGORY(CATEGORYID, SUBCATEGORYNAME, CREATEDATE, CREATEBY) VALUES (@catid,'Software',GETDATE(),'zaheer');
END
GO