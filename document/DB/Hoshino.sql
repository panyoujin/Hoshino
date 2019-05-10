/*
SQLyog Ultimate v11.42 (64 bit)
MySQL - 5.7.26 : Database - hoshino_dev
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hoshino_dev` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `hoshino_dev`;

/*Table structure for table `b_appointment_consultation` */

DROP TABLE IF EXISTS `b_appointment_consultation`;

CREATE TABLE `b_appointment_consultation` (
  `AC_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Company` varchar(256) NOT NULL COMMENT '公司名称',
  `Contacts` varchar(50) NOT NULL COMMENT '联系人',
  `Phone` varchar(20) NOT NULL COMMENT '电话',
  `Email` varchar(256) NOT NULL COMMENT '电子邮箱',
  `Matter` varchar(256) NOT NULL COMMENT '事项',
  `Material` varchar(256) NOT NULL COMMENT '资料',
  `AC_Status` int(1) NOT NULL DEFAULT '0' COMMENT '未处理',
  `Processing_Result` varchar(256) DEFAULT NULL COMMENT '处理结果',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`AC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='预约询价记录';

/*Data for the table `b_appointment_consultation` */

/*Table structure for table `b_banner_resources` */

DROP TABLE IF EXISTS `b_banner_resources`;

CREATE TABLE `b_banner_resources` (
  `Banner_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Banner_Name_CH` varchar(50) NOT NULL COMMENT 'Banner名称简体',
  `Banner_Name_HK` varchar(50) NOT NULL COMMENT 'Banner名称繁体',
  `Banner_URL` varchar(256) NOT NULL COMMENT 'BannerURL，通过后缀判断是视频还是图片',
  `Banner_Type` varchar(10) NOT NULL DEFAULT 'image' COMMENT 'Banner类型：image 图片 video 视频',
  `Banner_Location` varchar(10) NOT NULL DEFAULT 'Index' COMMENT 'Banner类型： Index 首页',
  `Banner_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `Banner_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`Banner_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Banner';

/*Data for the table `b_banner_resources` */

/*Table structure for table `b_category` */

DROP TABLE IF EXISTS `b_category`;

CREATE TABLE `b_category` (
  `Category_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Parent_Category_ID` int(5) DEFAULT NULL COMMENT '父级分类 0 第一级',
  `Category_Name_CH` varchar(50) NOT NULL COMMENT '分类名称简体',
  `Category_Name_HK` varchar(50) NOT NULL COMMENT '分类名称繁体',
  `Category_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `Category_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`Category_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='产品类型';

/*Data for the table `b_category` */

/*Table structure for table `b_contact` */

DROP TABLE IF EXISTS `b_contact`;

CREATE TABLE `b_contact` (
  `Contact_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Company` varchar(256) DEFAULT NULL COMMENT '公司名称',
  `Contacts` varchar(50) DEFAULT NULL COMMENT '联系人',
  `Phone` varchar(20) DEFAULT NULL COMMENT '电话',
  `Email` varchar(256) DEFAULT NULL COMMENT '电子邮箱',
  `Matter` varchar(256) DEFAULT NULL COMMENT '事项',
  `Wechat` varchar(256) DEFAULT NULL COMMENT '微信',
  `WhatsApp` varchar(256) DEFAULT NULL COMMENT 'WhatsApp',
  `AC_Status` int(1) NOT NULL DEFAULT '0' COMMENT '0 未处理,1 已处理',
  `Processing_Result` varchar(256) DEFAULT NULL COMMENT '处理结果',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`Contact_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='联系我们';

/*Data for the table `b_contact` */

/*Table structure for table `b_product` */

DROP TABLE IF EXISTS `b_product`;

CREATE TABLE `b_product` (
  `Product_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Category_ID` int(5) NOT NULL COMMENT '所属分类',
  `Product_Name_CH` varchar(50) NOT NULL COMMENT '产品名称简体',
  `Product_Name_HK` varchar(50) NOT NULL COMMENT '产品名称繁体',
  `Product_New` int(1) DEFAULT '1' COMMENT '1:最新; 0:非最新',
  `Product_Hot` int(1) DEFAULT '1' COMMENT '1:热门; 0:非热门',
  `Product_Recommend` int(1) DEFAULT '1' COMMENT '1:推荐; 0:非推荐',
  `Product_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `Product_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`Product_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='产品基础信息';

/*Data for the table `b_product` */

/*Table structure for table `b_product_attribute` */

DROP TABLE IF EXISTS `b_product_attribute`;

CREATE TABLE `b_product_attribute` (
  `P_Attribute_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Product_ID` int(5) NOT NULL,
  `P_Attribute_Name_CH` varchar(50) NOT NULL COMMENT '属性名称简体',
  `P_Attribute_Name_HK` varchar(50) NOT NULL COMMENT '属性名称繁体',
  `P_Attribute_Value_CH` varchar(256) NOT NULL COMMENT '属性值简体',
  `P_Attribute_Value_EN` varchar(256) NOT NULL COMMENT '属性值繁体',
  `P_Attribute_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `P_Attribute_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`P_Attribute_ID`),
  KEY `index1` (`Product_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='产品属性';

/*Data for the table `b_product_attribute` */

/*Table structure for table `b_product_resources` */

DROP TABLE IF EXISTS `b_product_resources`;

CREATE TABLE `b_product_resources` (
  `P_Resources_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Product_ID` int(5) NOT NULL,
  `P_Resources_Name_CH` varchar(50) NOT NULL COMMENT '资源名称简体',
  `P_Resources_Name_HK` varchar(50) NOT NULL COMMENT '资源名称繁体',
  `P_Resources_URL` varchar(256) NOT NULL COMMENT '资源URL，通过后缀判断是视频还是图片',
  `P_Resources_Type` varchar(10) NOT NULL DEFAULT 'image' COMMENT '资源类型：image 图片 video 视频',
  `P_Resources_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `P_Resources_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`P_Resources_ID`),
  KEY `index1` (`Product_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='产品资源';

/*Data for the table `b_product_resources` */

/*Table structure for table `b_rel_product` */

DROP TABLE IF EXISTS `b_rel_product`;

CREATE TABLE `b_rel_product` (
  `P_Relevant_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Source_Product_ID` int(5) NOT NULL,
  `Rel_Product_ID` int(5) NOT NULL,
  `P_Relevant_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `P_Relevant_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`P_Relevant_ID`),
  KEY `index1` (`Source_Product_ID`,`Rel_Product_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='相关产品';

/*Data for the table `b_rel_product` */

/*Table structure for table `b_video_resources` */

DROP TABLE IF EXISTS `b_video_resources`;

CREATE TABLE `b_video_resources` (
  `Video_ID` int(5) NOT NULL AUTO_INCREMENT,
  `Video_Name_CH` varchar(50) NOT NULL COMMENT 'Video名称简体',
  `Video_Name_HK` varchar(50) NOT NULL COMMENT 'Video名称繁体',
  `Video_URL` varchar(256) NOT NULL COMMENT 'Video URL',
  `Video_Location` varchar(10) NOT NULL DEFAULT 'Index' COMMENT 'Video 位置： Index 首页',
  `Video_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `Video_Seq` int(11) NOT NULL DEFAULT '0' COMMENT '排序：倒序',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`Video_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Video';

/*Data for the table `b_video_resources` */

/*Table structure for table `log_info` */

DROP TABLE IF EXISTS `log_info`;

CREATE TABLE `log_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `chain_id` varchar(64) NOT NULL,
  `content` varchar(500) DEFAULT NULL,
  `interface_name` varchar(200) DEFAULT NULL,
  `type` int(2) DEFAULT NULL,
  `creation_time` datetime DEFAULT NULL,
  `ip` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `log_info` */

/*Table structure for table `sys_log` */

DROP TABLE IF EXISTS `sys_log`;

CREATE TABLE `sys_log` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Table_Name` varchar(100) NOT NULL COMMENT '被操作的表名',
  `Primary_Key` varchar(100) NOT NULL COMMENT '对应的主键值',
  `Log_Type` varchar(1) NOT NULL DEFAULT 'I' COMMENT '操作类型 I:插入 U:修改 D:删除',
  `Old_Content` text COMMENT '操作前内容',
  `New_Content` text COMMENT '操作后内容',
  `Describe` varchar(256) DEFAULT NULL COMMENT '描述',
  `User_Id` varchar(50) DEFAULT NULL,
  `User_Name` varchar(50) DEFAULT NULL,
  `Create_Time` timestamp NULL DEFAULT NULL,
  `Send_Type` int(1) DEFAULT '0' COMMENT '发送类型 0:不需要发送 1:发送给创建人 2:发送给相关人员',
  `Send_Status` int(1) DEFAULT '0' COMMENT '发送状态 0:未发送 1:已发送 -1:发送失败',
  `Send_Time` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='sys功能操作记录表，主要用于朔源';

/*Data for the table `sys_log` */

/*Table structure for table `sys_user` */

DROP TABLE IF EXISTS `sys_user`;

CREATE TABLE `sys_user` (
  `User_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_Account` varchar(100) NOT NULL COMMENT '帐号',
  `Password` varchar(100) NOT NULL COMMENT '密码 帐号+密码+随机码 MDS',
  `User_Name` varchar(100) NOT NULL COMMENT '用户名',
  `User_Status` int(1) DEFAULT '1' COMMENT '1:有效; 0:无效',
  `Create_Time` datetime DEFAULT NULL,
  `Create_UserId` varchar(50) NOT NULL COMMENT '用户ID',
  `Create_User` varchar(50) NOT NULL COMMENT '用户名称：操作时的用户名',
  `Update_Time` datetime DEFAULT NULL,
  `Update_UserId` varchar(50) DEFAULT NULL COMMENT '用户ID',
  `Update_User` varchar(50) DEFAULT NULL COMMENT '用户名称：操作时的用户名',
  PRIMARY KEY (`User_ID`),
  UNIQUE KEY `unique` (`User_Account`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

/*Data for the table `sys_user` */

/* Trigger structure for table `b_appointment_consultation` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_appointment_consultation_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_appointment_consultation_insert_after` AFTER INSERT ON `b_appointment_consultation` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_appointment_consultation',new.AC_ID,'I',''
      ,CONCAT('{"AC_ID":"',IFNULL(new.AC_ID,''),'", ','"Company":"',IFNULL(new.Company,''),'", ','"Contacts":"',IFNULL(new.Contacts,''),'", ','"Phone":"',IFNULL(new.Phone,''),'", ','"Email":"',IFNULL(new.Email,''),'", ','"Matter":"',IFNULL(new.Matter,''),'", ','"Material":"',IFNULL(new.Material,''),'", ','"AC_Status":"',IFNULL(new.AC_Status,''),'", ','"Processing_Result":"',IFNULL(new.Processing_Result,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.AC_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_appointment_consultation` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_appointment_consultation_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_appointment_consultation_update_after` AFTER UPDATE ON `b_appointment_consultation` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_appointment_consultation',new.AC_ID,'U'
      ,CONCAT('{"AC_ID":"',IFNULL(old.AC_ID,''),'", ','"Company":"',IFNULL(old.Company,''),'", ','"Contacts":"',IFNULL(old.Contacts,''),'", ','"Phone":"',IFNULL(old.Phone,''),'", ','"Email":"',IFNULL(old.Email,''),'", ','"Matter":"',IFNULL(old.Matter,''),'", ','"Material":"',IFNULL(old.Material,''),'", ','"AC_Status":"',IFNULL(old.AC_Status,''),'", ','"Processing_Result":"',IFNULL(old.Processing_Result,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"AC_ID":"',IFNULL(new.AC_ID,''),'", ','"Company":"',IFNULL(new.Company,''),'", ','"Contacts":"',IFNULL(new.Contacts,''),'", ','"Phone":"',IFNULL(new.Phone,''),'", ','"Email":"',IFNULL(new.Email,''),'", ','"Matter":"',IFNULL(new.Matter,''),'", ','"Material":"',IFNULL(new.Material,''),'", ','"AC_Status":"',IFNULL(new.AC_Status,''),'", ','"Processing_Result":"',IFNULL(new.Processing_Result,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.AC_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_appointment_consultation` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_appointment_consultation_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_appointment_consultation_delete_after` AFTER DELETE ON `b_appointment_consultation` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_appointment_consultation',old.AC_ID,'D'
      ,CONCAT('{"AC_ID":"',IFNULL(old.AC_ID,''),'", ','"Company":"',IFNULL(old.Company,''),'", ','"Contacts":"',IFNULL(old.Contacts,''),'", ','"Phone":"',IFNULL(old.Phone,''),'", ','"Email":"',IFNULL(old.Email,''),'", ','"Matter":"',IFNULL(old.Matter,''),'", ','"Material":"',IFNULL(old.Material,''),'", ','"AC_Status":"',IFNULL(old.AC_Status,''),'", ','"Processing_Result":"',IFNULL(old.Processing_Result,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.AC_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_banner_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_banner_resources_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_banner_resources_insert_after` AFTER INSERT ON `b_banner_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_banner_resources',new.Banner_ID,'I',''
      ,CONCAT('{"Banner_ID":"',IFNULL(new.Banner_ID,''),'", ','"Banner_Name_CH":"',IFNULL(new.Banner_Name_CH,''),'", ','"Banner_Name_HK":"',IFNULL(new.Banner_Name_HK,''),'", ','"Banner_URL":"',IFNULL(new.Banner_URL,''),'", ','"Banner_Type":"',IFNULL(new.Banner_Type,''),'", ','"Banner_Location":"',IFNULL(new.Banner_Location,''),'", ','"Banner_Status":"',IFNULL(new.Banner_Status,''),'", ','"Banner_Seq":"',IFNULL(new.Banner_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.Banner_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_banner_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_banner_resources_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_banner_resources_update_after` AFTER UPDATE ON `b_banner_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_banner_resources',new.Banner_ID,'U'
      ,CONCAT('{"Banner_ID":"',IFNULL(old.Banner_ID,''),'", ','"Banner_Name_CH":"',IFNULL(old.Banner_Name_CH,''),'", ','"Banner_Name_HK":"',IFNULL(old.Banner_Name_HK,''),'", ','"Banner_URL":"',IFNULL(old.Banner_URL,''),'", ','"Banner_Type":"',IFNULL(old.Banner_Type,''),'", ','"Banner_Location":"',IFNULL(old.Banner_Location,''),'", ','"Banner_Status":"',IFNULL(old.Banner_Status,''),'", ','"Banner_Seq":"',IFNULL(old.Banner_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"Banner_ID":"',IFNULL(new.Banner_ID,''),'", ','"Banner_Name_CH":"',IFNULL(new.Banner_Name_CH,''),'", ','"Banner_Name_HK":"',IFNULL(new.Banner_Name_HK,''),'", ','"Banner_URL":"',IFNULL(new.Banner_URL,''),'", ','"Banner_Type":"',IFNULL(new.Banner_Type,''),'", ','"Banner_Location":"',IFNULL(new.Banner_Location,''),'", ','"Banner_Status":"',IFNULL(new.Banner_Status,''),'", ','"Banner_Seq":"',IFNULL(new.Banner_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.Banner_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_banner_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_banner_resources_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_banner_resources_delete_after` AFTER DELETE ON `b_banner_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_banner_resources',old.Banner_ID,'D'
      ,CONCAT('{"Banner_ID":"',IFNULL(old.Banner_ID,''),'", ','"Banner_Name_CH":"',IFNULL(old.Banner_Name_CH,''),'", ','"Banner_Name_HK":"',IFNULL(old.Banner_Name_HK,''),'", ','"Banner_URL":"',IFNULL(old.Banner_URL,''),'", ','"Banner_Type":"',IFNULL(old.Banner_Type,''),'", ','"Banner_Location":"',IFNULL(old.Banner_Location,''),'", ','"Banner_Status":"',IFNULL(old.Banner_Status,''),'", ','"Banner_Seq":"',IFNULL(old.Banner_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.Banner_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_category` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_category_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_category_insert_after` AFTER INSERT ON `b_category` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_category',new.Category_ID,'I',''
      ,CONCAT('{"Category_ID":"',IFNULL(new.Category_ID,''),'", ','"Parent_Category_ID":"',IFNULL(new.Parent_Category_ID,''),'", ','"Category_Name_CH":"',IFNULL(new.Category_Name_CH,''),'", ','"Category_Name_HK":"',IFNULL(new.Category_Name_HK,''),'", ','"Category_Status":"',IFNULL(new.Category_Status,''),'", ','"Category_Seq":"',IFNULL(new.Category_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.Category_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_category` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_category_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_category_update_after` AFTER UPDATE ON `b_category` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_category',new.Category_ID,'U'
      ,CONCAT('{"Category_ID":"',IFNULL(old.Category_ID,''),'", ','"Parent_Category_ID":"',IFNULL(old.Parent_Category_ID,''),'", ','"Category_Name_CH":"',IFNULL(old.Category_Name_CH,''),'", ','"Category_Name_HK":"',IFNULL(old.Category_Name_HK,''),'", ','"Category_Status":"',IFNULL(old.Category_Status,''),'", ','"Category_Seq":"',IFNULL(old.Category_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"Category_ID":"',IFNULL(new.Category_ID,''),'", ','"Parent_Category_ID":"',IFNULL(new.Parent_Category_ID,''),'", ','"Category_Name_CH":"',IFNULL(new.Category_Name_CH,''),'", ','"Category_Name_HK":"',IFNULL(new.Category_Name_HK,''),'", ','"Category_Status":"',IFNULL(new.Category_Status,''),'", ','"Category_Seq":"',IFNULL(new.Category_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.Category_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_category` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_category_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_category_delete_after` AFTER DELETE ON `b_category` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_category',old.Category_ID,'D'
      ,CONCAT('{"Category_ID":"',IFNULL(old.Category_ID,''),'", ','"Parent_Category_ID":"',IFNULL(old.Parent_Category_ID,''),'", ','"Category_Name_CH":"',IFNULL(old.Category_Name_CH,''),'", ','"Category_Name_HK":"',IFNULL(old.Category_Name_HK,''),'", ','"Category_Status":"',IFNULL(old.Category_Status,''),'", ','"Category_Seq":"',IFNULL(old.Category_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.Category_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_contact` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_contact_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_contact_insert_after` AFTER INSERT ON `b_contact` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_contact',new.Contact_ID,'I',''
      ,CONCAT('{"Contact_ID":"',IFNULL(new.Contact_ID,''),'", ','"Company":"',IFNULL(new.Company,''),'", ','"Contacts":"',IFNULL(new.Contacts,''),'", ','"Phone":"',IFNULL(new.Phone,''),'", ','"Email":"',IFNULL(new.Email,''),'", ','"Matter":"',IFNULL(new.Matter,''),'", ','"Wechat":"',IFNULL(new.Wechat,''),'", ','"WhatsApp":"',IFNULL(new.WhatsApp,''),'", ','"AC_Status":"',IFNULL(new.AC_Status,''),'", ','"Processing_Result":"',IFNULL(new.Processing_Result,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.Contact_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_contact` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_contact_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_contact_update_after` AFTER UPDATE ON `b_contact` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_contact',new.Contact_ID,'U'
      ,CONCAT('{"Contact_ID":"',IFNULL(old.Contact_ID,''),'", ','"Company":"',IFNULL(old.Company,''),'", ','"Contacts":"',IFNULL(old.Contacts,''),'", ','"Phone":"',IFNULL(old.Phone,''),'", ','"Email":"',IFNULL(old.Email,''),'", ','"Matter":"',IFNULL(old.Matter,''),'", ','"Wechat":"',IFNULL(old.Wechat,''),'", ','"WhatsApp":"',IFNULL(old.WhatsApp,''),'", ','"AC_Status":"',IFNULL(old.AC_Status,''),'", ','"Processing_Result":"',IFNULL(old.Processing_Result,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"Contact_ID":"',IFNULL(new.Contact_ID,''),'", ','"Company":"',IFNULL(new.Company,''),'", ','"Contacts":"',IFNULL(new.Contacts,''),'", ','"Phone":"',IFNULL(new.Phone,''),'", ','"Email":"',IFNULL(new.Email,''),'", ','"Matter":"',IFNULL(new.Matter,''),'", ','"Wechat":"',IFNULL(new.Wechat,''),'", ','"WhatsApp":"',IFNULL(new.WhatsApp,''),'", ','"AC_Status":"',IFNULL(new.AC_Status,''),'", ','"Processing_Result":"',IFNULL(new.Processing_Result,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.Contact_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_contact` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_contact_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_contact_delete_after` AFTER DELETE ON `b_contact` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_contact',old.Contact_ID,'D'
      ,CONCAT('{"Contact_ID":"',IFNULL(old.Contact_ID,''),'", ','"Company":"',IFNULL(old.Company,''),'", ','"Contacts":"',IFNULL(old.Contacts,''),'", ','"Phone":"',IFNULL(old.Phone,''),'", ','"Email":"',IFNULL(old.Email,''),'", ','"Matter":"',IFNULL(old.Matter,''),'", ','"Wechat":"',IFNULL(old.Wechat,''),'", ','"WhatsApp":"',IFNULL(old.WhatsApp,''),'", ','"AC_Status":"',IFNULL(old.AC_Status,''),'", ','"Processing_Result":"',IFNULL(old.Processing_Result,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.Contact_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_insert_after` AFTER INSERT ON `b_product` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product',new.Product_ID,'I',''
      ,CONCAT('{"Product_ID":"',IFNULL(new.Product_ID,''),'", ','"Category_ID":"',IFNULL(new.Category_ID,''),'", ','"Product_Name_CH":"',IFNULL(new.Product_Name_CH,''),'", ','"Product_Name_HK":"',IFNULL(new.Product_Name_HK,''),'", ','"Product_New":"',IFNULL(new.Product_New,''),'", ','"Product_Hot":"',IFNULL(new.Product_Hot,''),'", ','"Product_Recommend":"',IFNULL(new.Product_Recommend,''),'", ','"Product_Status":"',IFNULL(new.Product_Status,''),'", ','"Product_Seq":"',IFNULL(new.Product_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.Product_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_update_after` AFTER UPDATE ON `b_product` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product',new.Product_ID,'U'
      ,CONCAT('{"Product_ID":"',IFNULL(old.Product_ID,''),'", ','"Category_ID":"',IFNULL(old.Category_ID,''),'", ','"Product_Name_CH":"',IFNULL(old.Product_Name_CH,''),'", ','"Product_Name_HK":"',IFNULL(old.Product_Name_HK,''),'", ','"Product_New":"',IFNULL(old.Product_New,''),'", ','"Product_Hot":"',IFNULL(old.Product_Hot,''),'", ','"Product_Recommend":"',IFNULL(old.Product_Recommend,''),'", ','"Product_Status":"',IFNULL(old.Product_Status,''),'", ','"Product_Seq":"',IFNULL(old.Product_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"Product_ID":"',IFNULL(new.Product_ID,''),'", ','"Category_ID":"',IFNULL(new.Category_ID,''),'", ','"Product_Name_CH":"',IFNULL(new.Product_Name_CH,''),'", ','"Product_Name_HK":"',IFNULL(new.Product_Name_HK,''),'", ','"Product_New":"',IFNULL(new.Product_New,''),'", ','"Product_Hot":"',IFNULL(new.Product_Hot,''),'", ','"Product_Recommend":"',IFNULL(new.Product_Recommend,''),'", ','"Product_Status":"',IFNULL(new.Product_Status,''),'", ','"Product_Seq":"',IFNULL(new.Product_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.Product_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_delete_after` AFTER DELETE ON `b_product` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product',old.Product_ID,'D'
      ,CONCAT('{"Product_ID":"',IFNULL(old.Product_ID,''),'", ','"Category_ID":"',IFNULL(old.Category_ID,''),'", ','"Product_Name_CH":"',IFNULL(old.Product_Name_CH,''),'", ','"Product_Name_HK":"',IFNULL(old.Product_Name_HK,''),'", ','"Product_New":"',IFNULL(old.Product_New,''),'", ','"Product_Hot":"',IFNULL(old.Product_Hot,''),'", ','"Product_Recommend":"',IFNULL(old.Product_Recommend,''),'", ','"Product_Status":"',IFNULL(old.Product_Status,''),'", ','"Product_Seq":"',IFNULL(old.Product_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.Product_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product_attribute` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_attribute_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_attribute_insert_after` AFTER INSERT ON `b_product_attribute` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product_attribute',new.P_Attribute_ID,'I',''
      ,CONCAT('{"P_Attribute_ID":"',IFNULL(new.P_Attribute_ID,''),'", ','"Product_ID":"',IFNULL(new.Product_ID,''),'", ','"P_Attribute_Name_CH":"',IFNULL(new.P_Attribute_Name_CH,''),'", ','"P_Attribute_Name_HK":"',IFNULL(new.P_Attribute_Name_HK,''),'", ','"P_Attribute_Value_CH":"',IFNULL(new.P_Attribute_Value_CH,''),'", ','"P_Attribute_Value_EN":"',IFNULL(new.P_Attribute_Value_EN,''),'", ','"P_Attribute_Status":"',IFNULL(new.P_Attribute_Status,''),'", ','"P_Attribute_Seq":"',IFNULL(new.P_Attribute_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.P_Attribute_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product_attribute` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_attribute_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_attribute_update_after` AFTER UPDATE ON `b_product_attribute` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product_attribute',new.P_Attribute_ID,'U'
      ,CONCAT('{"P_Attribute_ID":"',IFNULL(old.P_Attribute_ID,''),'", ','"Product_ID":"',IFNULL(old.Product_ID,''),'", ','"P_Attribute_Name_CH":"',IFNULL(old.P_Attribute_Name_CH,''),'", ','"P_Attribute_Name_HK":"',IFNULL(old.P_Attribute_Name_HK,''),'", ','"P_Attribute_Value_CH":"',IFNULL(old.P_Attribute_Value_CH,''),'", ','"P_Attribute_Value_EN":"',IFNULL(old.P_Attribute_Value_EN,''),'", ','"P_Attribute_Status":"',IFNULL(old.P_Attribute_Status,''),'", ','"P_Attribute_Seq":"',IFNULL(old.P_Attribute_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"P_Attribute_ID":"',IFNULL(new.P_Attribute_ID,''),'", ','"Product_ID":"',IFNULL(new.Product_ID,''),'", ','"P_Attribute_Name_CH":"',IFNULL(new.P_Attribute_Name_CH,''),'", ','"P_Attribute_Name_HK":"',IFNULL(new.P_Attribute_Name_HK,''),'", ','"P_Attribute_Value_CH":"',IFNULL(new.P_Attribute_Value_CH,''),'", ','"P_Attribute_Value_EN":"',IFNULL(new.P_Attribute_Value_EN,''),'", ','"P_Attribute_Status":"',IFNULL(new.P_Attribute_Status,''),'", ','"P_Attribute_Seq":"',IFNULL(new.P_Attribute_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.P_Attribute_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product_attribute` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_attribute_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_attribute_delete_after` AFTER DELETE ON `b_product_attribute` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product_attribute',old.P_Attribute_ID,'D'
      ,CONCAT('{"P_Attribute_ID":"',IFNULL(old.P_Attribute_ID,''),'", ','"Product_ID":"',IFNULL(old.Product_ID,''),'", ','"P_Attribute_Name_CH":"',IFNULL(old.P_Attribute_Name_CH,''),'", ','"P_Attribute_Name_HK":"',IFNULL(old.P_Attribute_Name_HK,''),'", ','"P_Attribute_Value_CH":"',IFNULL(old.P_Attribute_Value_CH,''),'", ','"P_Attribute_Value_EN":"',IFNULL(old.P_Attribute_Value_EN,''),'", ','"P_Attribute_Status":"',IFNULL(old.P_Attribute_Status,''),'", ','"P_Attribute_Seq":"',IFNULL(old.P_Attribute_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.P_Attribute_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_resources_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_resources_insert_after` AFTER INSERT ON `b_product_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product_resources',new.P_Resources_ID,'I',''
      ,CONCAT('{"P_Resources_ID":"',IFNULL(new.P_Resources_ID,''),'", ','"Product_ID":"',IFNULL(new.Product_ID,''),'", ','"P_Resources_Name_CH":"',IFNULL(new.P_Resources_Name_CH,''),'", ','"P_Resources_Name_HK":"',IFNULL(new.P_Resources_Name_HK,''),'", ','"P_Resources_URL":"',IFNULL(new.P_Resources_URL,''),'", ','"P_Resources_Type":"',IFNULL(new.P_Resources_Type,''),'", ','"P_Resources_Status":"',IFNULL(new.P_Resources_Status,''),'", ','"P_Resources_Seq":"',IFNULL(new.P_Resources_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.P_Resources_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_resources_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_resources_update_after` AFTER UPDATE ON `b_product_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product_resources',new.P_Resources_ID,'U'
      ,CONCAT('{"P_Resources_ID":"',IFNULL(old.P_Resources_ID,''),'", ','"Product_ID":"',IFNULL(old.Product_ID,''),'", ','"P_Resources_Name_CH":"',IFNULL(old.P_Resources_Name_CH,''),'", ','"P_Resources_Name_HK":"',IFNULL(old.P_Resources_Name_HK,''),'", ','"P_Resources_URL":"',IFNULL(old.P_Resources_URL,''),'", ','"P_Resources_Type":"',IFNULL(old.P_Resources_Type,''),'", ','"P_Resources_Status":"',IFNULL(old.P_Resources_Status,''),'", ','"P_Resources_Seq":"',IFNULL(old.P_Resources_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"P_Resources_ID":"',IFNULL(new.P_Resources_ID,''),'", ','"Product_ID":"',IFNULL(new.Product_ID,''),'", ','"P_Resources_Name_CH":"',IFNULL(new.P_Resources_Name_CH,''),'", ','"P_Resources_Name_HK":"',IFNULL(new.P_Resources_Name_HK,''),'", ','"P_Resources_URL":"',IFNULL(new.P_Resources_URL,''),'", ','"P_Resources_Type":"',IFNULL(new.P_Resources_Type,''),'", ','"P_Resources_Status":"',IFNULL(new.P_Resources_Status,''),'", ','"P_Resources_Seq":"',IFNULL(new.P_Resources_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.P_Resources_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_product_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_product_resources_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_product_resources_delete_after` AFTER DELETE ON `b_product_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_product_resources',old.P_Resources_ID,'D'
      ,CONCAT('{"P_Resources_ID":"',IFNULL(old.P_Resources_ID,''),'", ','"Product_ID":"',IFNULL(old.Product_ID,''),'", ','"P_Resources_Name_CH":"',IFNULL(old.P_Resources_Name_CH,''),'", ','"P_Resources_Name_HK":"',IFNULL(old.P_Resources_Name_HK,''),'", ','"P_Resources_URL":"',IFNULL(old.P_Resources_URL,''),'", ','"P_Resources_Type":"',IFNULL(old.P_Resources_Type,''),'", ','"P_Resources_Status":"',IFNULL(old.P_Resources_Status,''),'", ','"P_Resources_Seq":"',IFNULL(old.P_Resources_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.P_Resources_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_rel_product` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_rel_product_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_rel_product_insert_after` AFTER INSERT ON `b_rel_product` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_rel_product',new.P_Relevant_ID,'I',''
      ,CONCAT('{"P_Relevant_ID":"',IFNULL(new.P_Relevant_ID,''),'", ','"Source_Product_ID":"',IFNULL(new.Source_Product_ID,''),'", ','"Rel_Product_ID":"',IFNULL(new.Rel_Product_ID,''),'", ','"P_Relevant_Status":"',IFNULL(new.P_Relevant_Status,''),'", ','"P_Relevant_Seq":"',IFNULL(new.P_Relevant_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.P_Relevant_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_rel_product` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_rel_product_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_rel_product_update_after` AFTER UPDATE ON `b_rel_product` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_rel_product',new.P_Relevant_ID,'U'
      ,CONCAT('{"P_Relevant_ID":"',IFNULL(old.P_Relevant_ID,''),'", ','"Source_Product_ID":"',IFNULL(old.Source_Product_ID,''),'", ','"Rel_Product_ID":"',IFNULL(old.Rel_Product_ID,''),'", ','"P_Relevant_Status":"',IFNULL(old.P_Relevant_Status,''),'", ','"P_Relevant_Seq":"',IFNULL(old.P_Relevant_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"P_Relevant_ID":"',IFNULL(new.P_Relevant_ID,''),'", ','"Source_Product_ID":"',IFNULL(new.Source_Product_ID,''),'", ','"Rel_Product_ID":"',IFNULL(new.Rel_Product_ID,''),'", ','"P_Relevant_Status":"',IFNULL(new.P_Relevant_Status,''),'", ','"P_Relevant_Seq":"',IFNULL(new.P_Relevant_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.P_Relevant_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_rel_product` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_rel_product_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_rel_product_delete_after` AFTER DELETE ON `b_rel_product` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_rel_product',old.P_Relevant_ID,'D'
      ,CONCAT('{"P_Relevant_ID":"',IFNULL(old.P_Relevant_ID,''),'", ','"Source_Product_ID":"',IFNULL(old.Source_Product_ID,''),'", ','"Rel_Product_ID":"',IFNULL(old.Rel_Product_ID,''),'", ','"P_Relevant_Status":"',IFNULL(old.P_Relevant_Status,''),'", ','"P_Relevant_Seq":"',IFNULL(old.P_Relevant_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.P_Relevant_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_video_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_video_resources_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_video_resources_insert_after` AFTER INSERT ON `b_video_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_video_resources',new.Video_ID,'I',''
      ,CONCAT('{"Video_ID":"',IFNULL(new.Video_ID,''),'", ','"Video_Name_CH":"',IFNULL(new.Video_Name_CH,''),'", ','"Video_Name_HK":"',IFNULL(new.Video_Name_HK,''),'", ','"Video_URL":"',IFNULL(new.Video_URL,''),'", ','"Video_Location":"',IFNULL(new.Video_Location,''),'", ','"Video_Status":"',IFNULL(new.Video_Status,''),'", ','"Video_Seq":"',IFNULL(new.Video_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.Video_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_video_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_video_resources_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_video_resources_update_after` AFTER UPDATE ON `b_video_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_video_resources',new.Video_ID,'U'
      ,CONCAT('{"Video_ID":"',IFNULL(old.Video_ID,''),'", ','"Video_Name_CH":"',IFNULL(old.Video_Name_CH,''),'", ','"Video_Name_HK":"',IFNULL(old.Video_Name_HK,''),'", ','"Video_URL":"',IFNULL(old.Video_URL,''),'", ','"Video_Location":"',IFNULL(old.Video_Location,''),'", ','"Video_Status":"',IFNULL(old.Video_Status,''),'", ','"Video_Seq":"',IFNULL(old.Video_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"Video_ID":"',IFNULL(new.Video_ID,''),'", ','"Video_Name_CH":"',IFNULL(new.Video_Name_CH,''),'", ','"Video_Name_HK":"',IFNULL(new.Video_Name_HK,''),'", ','"Video_URL":"',IFNULL(new.Video_URL,''),'", ','"Video_Location":"',IFNULL(new.Video_Location,''),'", ','"Video_Status":"',IFNULL(new.Video_Status,''),'", ','"Video_Seq":"',IFNULL(new.Video_Seq,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.Video_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `b_video_resources` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_b_video_resources_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_b_video_resources_delete_after` AFTER DELETE ON `b_video_resources` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('b_video_resources',old.Video_ID,'D'
      ,CONCAT('{"Video_ID":"',IFNULL(old.Video_ID,''),'", ','"Video_Name_CH":"',IFNULL(old.Video_Name_CH,''),'", ','"Video_Name_HK":"',IFNULL(old.Video_Name_HK,''),'", ','"Video_URL":"',IFNULL(old.Video_URL,''),'", ','"Video_Location":"',IFNULL(old.Video_Location,''),'", ','"Video_Status":"',IFNULL(old.Video_Status,''),'", ','"Video_Seq":"',IFNULL(old.Video_Seq,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.Video_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `sys_user` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_sys_user_insert_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_sys_user_insert_after` AFTER INSERT ON `sys_user` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('sys_user',new.User_ID,'I',''
      ,CONCAT('{"User_ID":"',IFNULL(new.User_ID,''),'", ','"User_Account":"',IFNULL(new.User_Account,''),'", ','"Password":"',IFNULL(new.Password,''),'", ','"User_Name":"',IFNULL(new.User_Name,''),'", ','"User_Status":"',IFNULL(new.User_Status,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('新增:',new.User_ID),new.Create_UserId,new.Create_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `sys_user` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_sys_user_update_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_sys_user_update_after` AFTER UPDATE ON `sys_user` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('sys_user',new.User_ID,'U'
      ,CONCAT('{"User_ID":"',IFNULL(old.User_ID,''),'", ','"User_Account":"',IFNULL(old.User_Account,''),'", ','"Password":"',IFNULL(old.Password,''),'", ','"User_Name":"',IFNULL(old.User_Name,''),'", ','"User_Status":"',IFNULL(old.User_Status,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,CONCAT('{"User_ID":"',IFNULL(new.User_ID,''),'", ','"User_Account":"',IFNULL(new.User_Account,''),'", ','"Password":"',IFNULL(new.Password,''),'", ','"User_Name":"',IFNULL(new.User_Name,''),'", ','"User_Status":"',IFNULL(new.User_Status,''),'", ','"Create_Time":"',IFNULL(new.Create_Time,''),'", ','"Create_UserId":"',IFNULL(new.Create_UserId,''),'", ','"Create_User":"',IFNULL(new.Create_User,''),'", ','"Update_Time":"',IFNULL(new.Update_Time,''),'", ','"Update_UserId":"',IFNULL(new.Update_UserId,''),'", ','"Update_User":"',IFNULL(new.Update_User,''),'"}')
      ,CONCAT('修改:',new.User_ID),new.Update_UserId,new.Update_User,0);
    END */$$


DELIMITER ;

/* Trigger structure for table `sys_user` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trigger_sys_user_delete_after` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'%' */ /*!50003 TRIGGER `trigger_sys_user_delete_after` AFTER DELETE ON `sys_user` FOR EACH ROW BEGIN
      CALL `insert_sys_log`('sys_user',old.User_ID,'D'
      ,CONCAT('{"User_ID":"',IFNULL(old.User_ID,''),'", ','"User_Account":"',IFNULL(old.User_Account,''),'", ','"Password":"',IFNULL(old.Password,''),'", ','"User_Name":"',IFNULL(old.User_Name,''),'", ','"User_Status":"',IFNULL(old.User_Status,''),'", ','"Create_Time":"',IFNULL(old.Create_Time,''),'", ','"Create_UserId":"',IFNULL(old.Create_UserId,''),'", ','"Create_User":"',IFNULL(old.Create_User,''),'", ','"Update_Time":"',IFNULL(old.Update_Time,''),'", ','"Update_UserId":"',IFNULL(old.Update_UserId,''),'", ','"Update_User":"',IFNULL(old.Update_User,''),'"}')
      ,''
      ,CONCAT('删除:',old.User_ID),old.Update_User,0);
    END */$$


DELIMITER ;

/* Procedure structure for procedure `insert_sys_log` */

/*!50003 DROP PROCEDURE IF EXISTS  `insert_sys_log` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `insert_sys_log`(Table_Name VARCHAR(100),Primary_Key VARCHAR(100),Log_Type VARCHAR(1),Old_Content TEXT,New_Content TEXT,de VARCHAR(256),User_Id VARCHAR(50),User_Name VARCHAR(50),Send_Type INT(1))
BEGIN
	INSERT INTO `sys_log`(`Table_Name`,`Primary_Key`,`Log_Type`,`Old_Content`,`New_Content`,`Describe`,`User_Id`,`User_Name`,`Create_Time`,`Send_Type`)
	VALUE(Table_Name,Primary_Key,Log_Type,Old_Content,New_Content,de,User_Id,User_Name,NOW(),Send_Type);
    END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
