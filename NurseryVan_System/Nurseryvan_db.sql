-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2018-10-07 09:53:37
-- --------------------------------------
-- Server version 5.7.20-log MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of subtbl_cart
-- 

DROP TABLE IF EXISTS `subtbl_cart`;
CREATE TABLE IF NOT EXISTS `subtbl_cart` (
  `cart_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `product_name` varchar(45) DEFAULT NULL,
  `QTY` int(11) DEFAULT NULL,
  `total_price` decimal(10,2) DEFAULT NULL,
  `Cash` decimal(10,2) DEFAULT NULL,
  `Change_Amount` decimal(10,2) DEFAULT NULL,
  `Vat` decimal(10,2) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `time` varchar(45) DEFAULT NULL,
  `Description` longtext,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `sub_total` decimal(10,2) DEFAULT NULL,
  `discount` decimal(10,2) DEFAULT NULL,
  `discountgiven` decimal(10,2) DEFAULT NULL,
  `discountname` varchar(45) DEFAULT NULL,
  `minus` varchar(45) DEFAULT NULL,
  `original_price` varchar(45) DEFAULT NULL,
  `sub_price` varchar(45) DEFAULT NULL,
  `original_vat` varchar(45) DEFAULT NULL,
  `percentage` varchar(45) DEFAULT NULL,
  `unit_price` decimal(10,2) DEFAULT NULL,
  `dateortime` varchar(45) DEFAULT NULL,
  `expiry_date` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`cart_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table subtbl_cart
-- 

/*!40000 ALTER TABLE `subtbl_cart` DISABLE KEYS */;

/*!40000 ALTER TABLE `subtbl_cart` ENABLE KEYS */;

-- 
-- Definition of tbl_cart
-- 

DROP TABLE IF EXISTS `tbl_cart`;
CREATE TABLE IF NOT EXISTS `tbl_cart` (
  `cart_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `sales_invoice_no` int(11) DEFAULT NULL,
  `sold_qty` int(11) DEFAULT NULL,
  `total_due` decimal(10,2) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `date_sold` varchar(45) DEFAULT NULL,
  `voided` varchar(45) DEFAULT NULL,
  `payment` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`cart_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_cart
-- 

/*!40000 ALTER TABLE `tbl_cart` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_cart` ENABLE KEYS */;

-- 
-- Definition of tbl_customers
-- 

DROP TABLE IF EXISTS `tbl_customers`;
CREATE TABLE IF NOT EXISTS `tbl_customers` (
  `customer_id` int(11) NOT NULL,
  `trans_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `order_ref` int(11) DEFAULT NULL,
  `customer_name` varchar(45) DEFAULT NULL,
  `contact_no` varchar(45) DEFAULT NULL,
  `address` longtext,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_customers
-- 

/*!40000 ALTER TABLE `tbl_customers` DISABLE KEYS */;
INSERT INTO `tbl_customers`(`customer_id`,`trans_id`,`product_id`,`order_ref`,`customer_name`,`contact_no`,`address`) VALUES
(1,1,7,28525,'Renz','09177596518','Makati City'),
(2,1,9,32515,'Henry','',''),
(3,3,16,2024,'Meshie','',''),
(4,1,11,2438,'Ariel','','');
/*!40000 ALTER TABLE `tbl_customers` ENABLE KEYS */;

-- 
-- Definition of tbl_login
-- 

DROP TABLE IF EXISTS `tbl_login`;
CREATE TABLE IF NOT EXISTS `tbl_login` (
  `login_id` int(11) NOT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` longtext,
  `user_type` varchar(45) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `street` longtext,
  `barangay` longtext,
  `city` varchar(50) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `email_address` varchar(45) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `birthdate` varchar(45) DEFAULT NULL,
  `security_question` longtext,
  `answer` varchar(50) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`login_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_login
-- 

/*!40000 ALTER TABLE `tbl_login` DISABLE KEYS */;
INSERT INTO `tbl_login`(`login_id`,`firstname`,`lastname`,`username`,`password`,`user_type`,`gender`,`street`,`barangay`,`city`,`contact`,`email_address`,`age`,`birthdate`,`security_question`,`answer`,`status`) VALUES
(1,'Elixer','Macafe','Elixer','elixer','Manager','Male','139-P 14th Avenue','East Rembo ','Makati City','09287309548','elixer.macafe21@gmail.com',22,'1996-06-21','What is your dream job?','I.T Specialist Programmer','Active'),
(2,'Rexile','Macafe','Rexile','elixer','Staff','Male','139-P 14th Avenue','East Rembo','Makati City','09287309548','elixer.macafe21@gmail.com',22,'1996-06-21','What is your favourite food?','White Chocolate','Active'),
(3,'Cindy','Pua','Cindy','1234567','Staff','Female','Mckinley Venice','Fort Bonifacio','Taguig City','09102626010','cindy.pua@yahoo.com',28,'1990-03-28','What is your favourite pet name?','Dog','Active'),
(4,'Fe','Campaner','Fe','April0781','Staff','Female','Guihulngan St.','Sandayao','Makati city','09054941475','rafolsfe81@gmail.com',28,'1990-04-07','What is your favourite food?','Adobo','Active'),
(5,'Tell','Ilao','Tell','damnyou','Staff','Female','139-P','14th','Makati city','09282565499','tell@yahoo.com',22,'1996-04-07','Who is your crush?','Mr.E','Active'),
(6,'Christian','Marcial','Christian','123456','Staff','Male','Euroflats Yakal St','Comembo','Makati','09474404348','christianmarcialsti@gmail.com',26,'1992-01-30','What is the name of your bestfriend childhood?','Jenny','Active'),
(7,'Kelvin','Bituin','Kelvin','123456','Staff','Male','Fdfdsf','Fdgfdg','Fdgdf','09282565499','dfd@gmail.com',26,'1992-04-07','Who is your crush?','Macmod','Active'),
(8,'Camille','Oja','Camille','ojaoja','Staff','Female','Block 88 lot 30','Rizal','Makati City','09282565499','camille@facebook.com',21,'1997-05-30','What is your favourite food?','Biscuit','Active'),
(9,'Judith','Galope','Judith','Galope','Staff','Female','Gk zonta','Pinagsama','Taguig','09499292519','judithgalope92@gmail.com',19,'1998-12-07','What is the name of your bestfriend childhood?','Ej','Active');
/*!40000 ALTER TABLE `tbl_login` ENABLE KEYS */;

-- 
-- Definition of tbl_loginhistory
-- 

DROP TABLE IF EXISTS `tbl_loginhistory`;
CREATE TABLE IF NOT EXISTS `tbl_loginhistory` (
  `login_id` int(11) NOT NULL,
  `username` varchar(45) DEFAULT NULL,
  `time_in` varchar(45) DEFAULT NULL,
  `time_out` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`login_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_loginhistory
-- 

/*!40000 ALTER TABLE `tbl_loginhistory` DISABLE KEYS */;
INSERT INTO `tbl_loginhistory`(`login_id`,`username`,`time_in`,`time_out`,`date`) VALUES
(1,'Elixer','1:04 AM','1:07 AM','Sabado, Oktubre 6, 2018'),
(2,'Rexile','1:07 AM','1:13 AM','Sabado, Oktubre 6, 2018'),
(3,'Elixer','1:13 AM','1:17 AM','Sabado, Oktubre 6, 2018'),
(4,'Rexile','6:07 PM','6:10 PM','Sabado, Oktubre 6, 2018'),
(5,'Elixer','6:10 PM','6:12 PM','Sabado, Oktubre 6, 2018');
/*!40000 ALTER TABLE `tbl_loginhistory` ENABLE KEYS */;

-- 
-- Definition of tbl_nurseryvan
-- 

DROP TABLE IF EXISTS `tbl_nurseryvan`;
CREATE TABLE IF NOT EXISTS `tbl_nurseryvan` (
  `History` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_nurseryvan
-- 

/*!40000 ALTER TABLE `tbl_nurseryvan` DISABLE KEYS */;
INSERT INTO `tbl_nurseryvan`(`History`) VALUES
('dsdgsdfsdfdfsdfsdffs'),
('University Parkway \nFort Bonifacio Global City\nTaguig City\n\nNursery Van Complete Mommy Bundle ensures that you have all you need to take care of your little one! Complete with Cycles Powder Detergent, Cradle Baby Bottle & Nipple Cleanser, Pigeon Wipes, MamyPoko Extra Dry, and Cycles Sensitive diaper cream!\n\nIt is back-to-school season! Make sure the kiddos are protected from mosquitoes and the viruses that they carry! Be sure that the kids always have these mosquito repellent patches in their backpacks.\n\nMade from Citronella and totally DEET-Free, Bite Block Naturals and Cycles Sensitive patches keeps those pesky mosquitoes away!'),
('University Parkway \nFort Bonifacio Global City\nTaguig City\n\nNursery Van Complete Mommy Bundle ensures that you have all you need to take care of your little one! Complete with Cycles Powder Detergent, Cradle Baby Bottle & Nipple Cleanser, Pigeon Wipes, MamyPoko Extra Dry, and Cycles Sensitive diaper cream!\n\nIt is back-to-school season! Make sure the kiddos are protected from mosquitoes and the viruses that they carry! Be sure that the kids always have these mosquito repellent patches in their backpacks.\n\nMade from Citronella and totally DEET-Free, Bite Block Naturals and Cycles Sensitive patches keeps those pesky mosquitoes away! ('),
('University Parkway \nFort Bonifacio Global City\nTaguig City\n\nNursery Van Complete Mommy Bundle ensures that you have all you need to take care of your little one! Complete with Cycles Powder Detergent, Cradle Baby Bottle & Nipple Cleanser, Pigeon Wipes, MamyPoko Extra Dry, and Cycles Sensitive diaper cream!\n\nIt is back-to-school season! Make sure the kiddos are protected from mosquitoes and the viruses that they carry! Be sure that the kids always have these mosquito repellent patches in their backpacks.\n\nMade from Citronella and totally DEET-Free, Bite Block Naturals and Cycles Sensitive patches keeps those pesky mosquitoes away! '),
(NULL),
('@ghjghj');
/*!40000 ALTER TABLE `tbl_nurseryvan` ENABLE KEYS */;

-- 
-- Definition of tbl_order
-- 

DROP TABLE IF EXISTS `tbl_order`;
CREATE TABLE IF NOT EXISTS `tbl_order` (
  `order_id` int(11) NOT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `total_due` decimal(10,2) DEFAULT NULL,
  `quantity_receive` int(11) DEFAULT NULL,
  `damage_product` int(11) DEFAULT NULL,
  `date_ordered` varchar(45) DEFAULT NULL,
  `date_expected` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_order
-- 

/*!40000 ALTER TABLE `tbl_order` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_order` ENABLE KEYS */;

-- 
-- Definition of tbl_product
-- 

DROP TABLE IF EXISTS `tbl_product`;
CREATE TABLE IF NOT EXISTS `tbl_product` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(45) DEFAULT NULL,
  `product_price` decimal(10,2) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `total_price` decimal(10,2) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  `vat` decimal(10,2) DEFAULT NULL,
  `Description` longtext,
  `supplier_name` varchar(50) DEFAULT NULL,
  `date_added` varchar(45) DEFAULT NULL,
  `date_updated` varchar(45) DEFAULT NULL,
  `max_quantity` int(11) DEFAULT NULL,
  `asq` int(11) DEFAULT NULL,
  `critical` int(11) DEFAULT NULL,
  `Category` longtext,
  `Reason` longtext,
  `production_date` varchar(45) DEFAULT NULL,
  `expiry_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_product
-- 

/*!40000 ALTER TABLE `tbl_product` DISABLE KEYS */;
INSERT INTO `tbl_product`(`product_id`,`product_name`,`product_price`,`quantity`,`total_price`,`stock`,`vat`,`Description`,`supplier_name`,`date_added`,`date_updated`,`max_quantity`,`asq`,`critical`,`Category`,`Reason`,`production_date`,`expiry_date`) VALUES
(1,'Cradle Baby Bottle Cleanser 700mL Bottle',298.00,0,0.00,5070,0.00,'Non-toxic and super safe, Cradle Bottle and Nipple Cleanser is especially made from natural ingredients for washing the babies ..','Nursery Van',NULL,'27/09/2018 5:40:17 PM',0,5,3,'Liquid','700 expired of product','2018-10-03','2018-12-28'),
(2,'Cradle Baby Bottle Cleanser 500mL Refill',239.00,0,0.00,1176,0.00,'Even with thorough rinsing, ordinary dishwashing cleaners leave chemicals that may be harmful to your baby','Nursery Van',NULL,'23/09/2018 2:11:39 PM',NULL,NULL,NULL,'Liquid','','2018-10-03','2019-11-04'),
(3,'Cradle Baby Bottle Cleanser 200mL Travel Size',132.00,0,0.00,1156,0.00,'Cradle is the most trusted brand by meticulous moms','Nursery Van',NULL,'24/09/2018 12:37:55 AM',NULL,NULL,NULL,'Liquid','',NULL,NULL),
(4,'Cradle Toy & Surface Cleaner 500mL',232.00,0,0.00,993,0.00,'Say goodbye to grimy nursing bottles, baby accessories and sippy cups.','Nursery Van',NULL,NULL,0,1,1,'Powder','','2018-10-03','2018-12-01'),
(5,'Dairy Queen (Ice Cream)',100.00,0,0.00,2814,0.00,'Best','DQ',NULL,'27/09/2018 5:40:09 PM',0,1,1,'Tasty','','2018-10-03','2019-11-04'),
(6,'Spaghetti(Jollibee)',50.00,0,0.00,4258,0.00,'Best','Jollibee',NULL,'27/09/2018 10:27:19 PM',9,3,6,'Sweet','','2018-10-03','2019-11-04'),
(7,'Milk Coffee',99.00,0,0.00,3292,0.00,'Best','Starbucks',NULL,'02/10/2018 7:19:39 AM',0,2,1,'Fresh','','2018-10-03','2019-11-04'),
(8,'Noodles',69.00,0,0.00,990,0.00,'Good','North Park',NULL,'02/10/2018 7:40:34 AM',6,4,5,'Smooth','',NULL,NULL),
(9,'French Fries',35.00,0,0.00,2089,0.00,'Good','Jollibee',NULL,'27/09/2018 5:40:18 PM',0,1,1,'ertet',NULL,NULL,NULL),
(10,'Hershey',50.00,0,0.00,2036,0.00,'Best','Starbucks',NULL,'24/09/2018 12:38:06 AM',0,2,1,'Sweet','',NULL,NULL),
(11,'Burger',50.00,0,0.00,1958,0.00,'Best','Jollibee','22/09/2018 11:23:44 PM','24/09/2018 12:38:11 AM',0,4,2,'dfgfg',NULL,NULL,NULL),
(12,'Noodles',10.00,0,0.00,0,0.00,'Good','North Park','23/09/2018 11:14:02 AM',NULL,NULL,NULL,NULL,'Tasty','',NULL,NULL),
(13,'Adobo',99.00,0,0.00,1969,0.00,'Manok','Magnolia','24/09/2018 11:17:55 AM','24/09/2018 11:24:57 AM',18,6,12,'Dfgd','','2018-10-05','2018-12-06'),
(14,'Tissue',12.00,0,0.00,0,0.00,'Better','Supermarket','26/09/2018 11:00:47 PM',NULL,NULL,NULL,NULL,'fdgdg',NULL,NULL,NULL),
(15,'Banana Split',89.00,0,0.00,90,0.00,'Best','Starbucks','27/09/2018 8:28:53 AM','02/10/2018 7:19:36 AM',0,1,1,'Better','DAMAGE FROM bite rat.',NULL,NULL),
(16,'Coke',10.00,0,0.00,65,0.00,'Best','Jollibee','27/09/2018 8:30:48 AM','27/09/2018 8:40:13 AM',0,3,2,'Best',NULL,NULL,NULL),
(17,'Sprite',100.00,0,0.00,2,0.00,'Best','Supermarket','27/09/2018 8:33:21 AM','02/10/2018 7:40:41 AM',NULL,NULL,NULL,'Good',NULL,NULL,NULL),
(18,'Shoes',3000.00,0,0.00,11,0.00,'Best','Puma','27/09/2018 5:44:31 PM','02/10/2018 8:01:17 AM',0,1,1,'Best',NULL,NULL,NULL),
(19,'Strawberry',45.00,0,0.00,0,0.00,'sweet','Starbucks','27/09/2018 9:34:32 PM',NULL,NULL,NULL,NULL,'Good',NULL,NULL,NULL),
(20,'Mango',50.00,0,0.00,0,0.00,'good',NULL,'27/09/2018 9:38:33 PM',NULL,NULL,NULL,NULL,'Creamy',NULL,NULL,NULL),
(21,'Pizza',50.00,0,0.00,0,0.00,'taste',NULL,'27/09/2018 10:14:35 PM',NULL,NULL,NULL,NULL,'Good',NULL,NULL,NULL),
(22,'Ice Cream',25.00,0,0.00,67,0.00,'fdgdfgdfgf','DQ','28/09/2018 11:26:16 AM','28/09/2018 11:28:14 AM',0,5,3,'Sweet',NULL,NULL,NULL),
(23,'Alcohol Lamp',99.00,0,0.00,4,0.00,'Ok nmn.','Science Laboratory','02/10/2018 9:57:14 AM','02/10/2018 10:01:33 AM',NULL,NULL,NULL,'Apparatus',NULL,NULL,NULL),
(24,'Nivea',90.00,0,0.00,0,0.00,'NIveammm','Nivea','02/10/2018 3:06:25 PM','02/10/2018 3:09:39 PM',NULL,NULL,NULL,'Liquid',NULL,NULL,NULL),
(25,'Alcohol',49.00,0,0.00,0,0.00,'Good',NULL,'03/10/2018 4:19:09 PM',NULL,NULL,NULL,NULL,'Liquid',NULL,'2018-10-03','2019-10-03'),
(26,'Bench',59.00,0,0.00,51,0.00,'soft and good.','Nivea','03/10/2018 9:15:13 PM','03/10/2018 10:02:14 PM',0,60,30,'Soft','','2018-10-03','2019-10-04');
/*!40000 ALTER TABLE `tbl_product` ENABLE KEYS */;

-- 
-- Definition of tbl_supplierinfo
-- 

DROP TABLE IF EXISTS `tbl_supplierinfo`;
CREATE TABLE IF NOT EXISTS `tbl_supplierinfo` (
  `supplier_id` int(11) NOT NULL,
  `contact_person` varchar(45) DEFAULT NULL,
  `company` varchar(45) DEFAULT NULL,
  `street` varchar(45) DEFAULT NULL,
  `barangay` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `telephone` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`supplier_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_supplierinfo
-- 

/*!40000 ALTER TABLE `tbl_supplierinfo` DISABLE KEYS */;
INSERT INTO `tbl_supplierinfo`(`supplier_id`,`contact_person`,`company`,`street`,`barangay`,`city`,`contact`,`email`,`telephone`) VALUES
(1,'Elixer Macafe','Nursery Van','139-P 14th ave.','East Rembo','Makati City','09287309548','elixer.macafe21@gmail.com','(46)846-7789'),
(4,'Rexile Macafe','Starbucks','139-P 14th ','East Rembo','Makati City','09287309548','rexile.macafe@gmail.com',NULL),
(5,'Cindy Pua','North Park','Mckinley Venice','Fort Bonifacio','Taguig City','09282565499','cindy@gmail.com',NULL),
(6,'Kim','Magnolia','Palar ','Comembo','Makati','09185699082','fe@yahoo.com','(02)729-8990'),
(7,'Chris','Supermarket','Dfsdf','Dgdfg','Dgdfg','09282565499','chris@gmail.com','(46)846-7789'),
(8,'Judith','Puma','Dsdsfd','Sdfdsf','Dsfsdf','09282565499','judith@gmail.com','(46)846-7789'),
(9,'Judith Dalope','Science Laboratory','1dsfsdf','Sdvfdgfd','Ddfgdg','09282565499','judith@yahoo.com','(02)729-4925'),
(10,'Mark Fuentes','Nivea','139-P 14th','East Rembo','Makati City','09282565499','mark.fuentes@gmail.com','(02)779-4925');
/*!40000 ALTER TABLE `tbl_supplierinfo` ENABLE KEYS */;

-- 
-- Definition of tbl_transactionrecord
-- 

DROP TABLE IF EXISTS `tbl_transactionrecord`;
CREATE TABLE IF NOT EXISTS `tbl_transactionrecord` (
  `trans_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `product_name` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `discount` varchar(45) DEFAULT NULL,
  `discountgiven` varchar(45) DEFAULT NULL,
  `dateortime` varchar(45) DEFAULT NULL,
  `vat` decimal(10,2) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `time` varchar(45) DEFAULT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `remove` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table tbl_transactionrecord
-- 

/*!40000 ALTER TABLE `tbl_transactionrecord` DISABLE KEYS */;
INSERT INTO `tbl_transactionrecord`(`trans_id`,`product_id`,`product_name`,`description`,`price`,`quantity`,`amount`,`status`,`discount`,`discountgiven`,`dateortime`,`vat`,`stock`,`date`,`time`,`customer_id`,`remove`) VALUES
(1,7,'Milk Coffee','Best',99.00,3,297.00,'Sold','','','10/6/2018 1:08:13 AM',31.82,3292,'2018-10-06','1:08 AM',1,'No'),
(1,8,'Noodles',NULL,NULL,2,NULL,'Voided',NULL,NULL,'10/6/2018 1:09:31 AM',NULL,NULL,NULL,NULL,NULL,NULL),
(1,9,'French Fries','Good',35.00,2,70.00,'Sold','','','10/6/2018 1:09:52 AM',7.50,2089,'2018-10-06','1:09 AM',2,'No'),
(3,16,'Coke','Best',10.00,5,50.00,'Sold','','','10/6/2018 1:11:22 AM',5.36,65,'2018-10-06','1:11 AM',3,'No'),
(2,15,'Banana Split','Best',89.00,5,445.00,'Sold','','','10/6/2018 1:11:17 AM',47.68,90,'2018-10-06','1:11 AM',3,'No'),
(1,26,'Bench','soft and good.',59.00,5,295.00,'Sold','','','10/6/2018 1:11:02 AM',31.61,51,'2018-10-06','1:11 AM',3,'No'),
(1,11,'Burger','Best',50.00,7,350.00,'Sold','','','10/6/2018 6:09:04 PM',37.50,1958,'2018-10-06','6:09 PM',4,'No');
/*!40000 ALTER TABLE `tbl_transactionrecord` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2018-10-07 09:53:39
-- Total time: 0:0:0:1:638 (d:h:m:s:ms)
