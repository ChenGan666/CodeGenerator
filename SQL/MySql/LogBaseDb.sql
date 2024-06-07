

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for log_level
-- ----------------------------
DROP TABLE IF EXISTS `log_level`;
CREATE TABLE `log_level`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `LevelName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `LevelRemarks` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Status` tinyint(1) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of log_level
-- ----------------------------
INSERT INTO `log_level` VALUES (1, 'ERROR', '引起系统错误的问题', 1, '2020-05-25 23:28:13', '2020-05-25 23:28:13');
INSERT INTO `log_level` VALUES (2, 'WARN', '可疑的错误', 1, '2020-05-25 23:30:03', '2020-05-25 23:30:03');
INSERT INTO `log_level` VALUES (3, 'INFO', '正常信息', 1, '2020-05-25 23:30:11', '2020-05-25 23:30:11');
INSERT INTO `log_level` VALUES (4, 'DEBUG', 'Debug信息', 1, '2020-05-25 23:31:07', '2020-05-25 23:31:07');
INSERT INTO `log_level` VALUES (5, 'CUSTOM', '自定义信息', 1, '2020-06-02 01:14:00', '2020-06-02 01:14:00');

-- ----------------------------
-- Table structure for log_record
-- ----------------------------
DROP TABLE IF EXISTS `log_record`;
CREATE TABLE `log_record`  (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TypeId` int(11) NULL DEFAULT NULL,
  `LevelId` int(11) NULL DEFAULT NULL,
  `LogDetail` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `LogRemarks` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `LogUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `LogCreatorId` int(11) NULL DEFAULT NULL,
  `LogCreatorIP` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `OperateTime` datetime(0) NULL DEFAULT NULL,
  `DateCode` int(11) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 26 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for log_type
-- ----------------------------
DROP TABLE IF EXISTS `log_type`;
CREATE TABLE `log_type`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TypeName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `TypeRemarks` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `ClassId` int(11) NULL DEFAULT NULL,
  `LevelId` int(11) NULL DEFAULT NULL,
  `Status` tinyint(1) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of log_type
-- ----------------------------
INSERT INTO `log_type` VALUES (1, '系统错误', NULL, 1, 1, 1, '2020-06-03 23:40:00', '2020-06-03 23:40:00');
INSERT INTO `log_type` VALUES (2, '请求SQL记录', NULL, 1, 3, 1, '2020-06-04 00:06:54', '2020-06-04 00:06:54');

-- ----------------------------
-- Table structure for log_type_class
-- ----------------------------
DROP TABLE IF EXISTS `log_type_class`;
CREATE TABLE `log_type_class`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `ClassRemarks` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `ParentId` int(11) NULL DEFAULT NULL,
  `RootId` int(11) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of log_type_class
-- ----------------------------
INSERT INTO `log_type_class` VALUES (1, '系统默认', NULL, 0, 1, '2020-06-03 23:38:50', '2020-06-03 23:38:50');

-- ----------------------------
-- Procedure structure for CommonPagenation
-- ----------------------------
DROP PROCEDURE IF EXISTS `CommonPagenation`;
delimiter ;;
CREATE PROCEDURE `CommonPagenation`(in tableName varchar(255), 
in showFName varchar(500), 
in selectWhere varchar(500) , 
in selectOrder varchar(200), 
in pageNo int , 
in pageSize int)
begin
  set @startrow=(pageNo-1)*pageSize;
  set @pagesize = pageSize;
  set @rowindex=0;
  set @strsql = CONCAT(
                'select SQL_CALC_FOUND_ROWS ', showFName , ' from ',tableName,
                case 
                  IFNULL(selectWhere,'')
                  when '' 
                  then ''
                  else CONCAT (' where ',selectWhere)
                end,
                case
                  IFNULL(selectOrder,'')
                  WHEN ''
                  then ''
                  ELSE CONCAT(' order by ', selectOrder) 
              END,  
              ' limit ',
              @startRow,
              ',',
              @pagesize
            ) ;
	set @countsql = "SELECT FOUND_ROWS()";
	PREPARE strsql FROM @strsql ;
	EXECUTE strsql ;	 
    PREPARE countsql FROM @countsql ;
    EXECUTE countsql ;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
