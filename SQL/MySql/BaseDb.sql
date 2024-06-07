

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for base_branch_info
-- ----------------------------
DROP TABLE IF EXISTS `base_branch_info`;
CREATE TABLE `base_branch_info`  (
  `BranchID` int(11) NOT NULL AUTO_INCREMENT,
  `SystemID` int(11) NULL DEFAULT NULL,
  `bItemID` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bName` varchar(250) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bLinkMan` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bTel` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bFax` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bEmail` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bNote` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `bAppendTime` datetime(0) NULL DEFAULT NULL,
  `bState` tinyint(1) NULL DEFAULT NULL,
  PRIMARY KEY (`BranchID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 14 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_branch_info
-- ----------------------------

INSERT INTO `base_branch_info` VALUES (3, 3, '3', 'ZSN', '知数能', '陈淦', '', '', '', '', '2024-06-01 10:20:40', 1);

-- ----------------------------
-- Table structure for base_code_index_info
-- ----------------------------



DROP TABLE IF EXISTS `base_code_index_info`;
CREATE TABLE `base_code_index_info`  (
  `CodeIndexID` int(11) NOT NULL AUTO_INCREMENT,
  `SystemID` int(11) NULL DEFAULT NULL,
  `CodeType` int(11) NULL DEFAULT NULL,
  `CodeIndex` int(11) NULL DEFAULT NULL,
  `cUpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`CodeIndexID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Records of base_code_index_info
-- ----------------------------
INSERT INTO `base_code_index_info` VALUES (1, 0, 100, 13, '2020-05-22 14:28:56');
INSERT INTO `base_code_index_info` VALUES (2, 0, 101, 11, '2020-05-21 14:58:45');
INSERT INTO `base_code_index_info` VALUES (3, 0, 105, 10, '2020-05-22 10:33:16');
INSERT INTO `base_code_index_info` VALUES (4, 0, 102, 2, '2020-05-25 15:22:16');

-- ----------------------------
-- Table structure for base_department_info
-- ----------------------------
DROP TABLE IF EXISTS `base_department_info`;
CREATE TABLE `base_department_info`  (
  `DepartmentID` int(11) NOT NULL AUTO_INCREMENT,
  `SystemID` int(11) NULL DEFAULT NULL,
  `BranchID` int(11) NULL DEFAULT NULL,
  `dItemID` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `dName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `dDirector` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `dNote` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `dState` tinyint(1) NULL DEFAULT NULL,
  `dAppendTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`DepartmentID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 12 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_department_info
-- ----------------------------
INSERT INTO `base_department_info` VALUES (11, 0, 3, '11', '研发部', NULL, NULL, 1, '2020-05-21 14:58:45');

-- ----------------------------
-- Table structure for base_dictionary_info
-- ----------------------------
DROP TABLE IF EXISTS `base_dictionary_info`;
CREATE TABLE `base_dictionary_info`  (
  `DicId` int(11) NOT NULL AUTO_INCREMENT,
  `DicName` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `DicTitle` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `DicValue` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `DicRemark` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Status` tinyint(1) NULL DEFAULT NULL,
  `Sort` int(11) NULL DEFAULT NULL,
  `Pid` int(11) NULL DEFAULT NULL,
  `Cid` int(11) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`DicId`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1006 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_dictionary_info
-- ----------------------------
INSERT INTO `base_dictionary_info` VALUES (1, '后台菜单', 'AdminMenu', '', '', 1, 1, 0, 0, '2020-05-20 17:30:52', '2020-05-21 15:04:56');
INSERT INTO `base_dictionary_info` VALUES (2, '组织机构', NULL, 'OrganizationManagement', NULL, 1, 0, 1, 0, '2020-05-20 15:37:46', '2020-05-28 10:58:47');
INSERT INTO `base_dictionary_info` VALUES (3, '系统设置', NULL, 'SystemManagement', NULL, 1, 0, 1, 0, '2020-05-20 15:38:16', '2020-05-28 10:58:43');
INSERT INTO `base_dictionary_info` VALUES (4, '分支机构', 'Branch', 'Branch/BranchList', NULL, 1, 0, 2, 0, '2020-05-20 16:37:55', '2020-05-28 11:04:18');
INSERT INTO `base_dictionary_info` VALUES (5, '部门管理', 'Department', 'Department/DepartmentList', NULL, 1, 0, 2, 0, '2020-05-20 16:38:11', '2020-05-28 11:04:07');
INSERT INTO `base_dictionary_info` VALUES (6, '岗位管理', 'JobPosition', 'JobPosition/JobPositionList', NULL, 1, 0, 2, 0, '2020-05-20 16:39:34', '2020-05-28 11:03:56');
INSERT INTO `base_dictionary_info` VALUES (7, '人员管理', 'Employee', 'Employee/EmployeeList', NULL, 1, 0, 2, 0, '2020-05-20 16:39:57', '2020-05-28 11:03:41');
INSERT INTO `base_dictionary_info` VALUES (8, '操作账户', 'UserAccount', 'UserAccount/UserAccountList', NULL, 1, 0, 2, 0, '2020-05-20 16:40:16', '2020-05-28 11:03:23');
INSERT INTO `base_dictionary_info` VALUES (9, '字典管理', 'Dictionary', 'Dictionary/DictionaryList', NULL, 1, 0, 3, 0, '2020-05-20 16:41:08', '2020-05-28 11:02:48');
INSERT INTO `base_dictionary_info` VALUES (10, '地区管理', 'Area', 'Area/AreaList', NULL, 0, 0, 3, 0, '2020-05-20 16:41:27', '2020-05-28 11:02:39');
INSERT INTO `base_dictionary_info` VALUES (11, '权限管理', 'Permission', 'Permission/PermissionList', NULL, 1, 0, 3, 0, '2020-05-20 16:43:00', '2020-05-28 11:02:29');
INSERT INTO `base_dictionary_info` VALUES (1001, '系统日志', NULL, 'SystemLog', NULL, 1, 0, 1, 0, '2020-06-04 17:02:59', '2020-06-04 17:09:19');
INSERT INTO `base_dictionary_info` VALUES (1002, '日志等级', NULL, '/SystemLog/LogLevelList', NULL, 1, 0, 1001, 0, '2020-06-04 17:10:21', '2020-06-04 17:45:47');
INSERT INTO `base_dictionary_info` VALUES (1003, '日志记录', NULL, '/SystemLog/LogRecordList', NULL, 1, 0, 1001, 0, '2020-06-04 17:11:04', '2020-06-04 17:11:04');
INSERT INTO `base_dictionary_info` VALUES (1004, '日志锚点', NULL, '/SystemLog/LogTypeList', NULL, 1, 0, 1001, 0, '2020-06-04 17:11:40', '2020-06-04 17:11:40');
INSERT INTO `base_dictionary_info` VALUES (1005, '日志锚点分类', NULL, '/SystemLog/LogTypeClassList', NULL, 1, 0, 1001, 0, '2020-06-04 17:12:05', '2020-06-04 17:12:05');

-- ----------------------------
-- Table structure for base_employee_info
-- ----------------------------
DROP TABLE IF EXISTS `base_employee_info`;
CREATE TABLE `base_employee_info`  (
  `EmployeeID` int(11) NOT NULL AUTO_INCREMENT,
  `SystemID` int(11) NULL DEFAULT NULL,
  `BranchID` int(11) NULL DEFAULT NULL,
  `UserID` int(11) NULL DEFAULT NULL,
  `eItemID` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eSex` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eMarry` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eBirthday` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `DepartmentID` int(11) NULL DEFAULT NULL,
  `JobPositionID` int(11) NULL DEFAULT NULL,
  `JPName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `IsManager` tinyint(1) NULL DEFAULT NULL,
  `IsCheckManager` tinyint(1) NULL DEFAULT NULL,
  `IsSelf` tinyint(1) NULL DEFAULT NULL,
  `eEntry` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eEmail` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eTel` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eQQ` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `eMob` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `ePhotoImage` longblob NULL,
  `eState` tinyint(1) NULL DEFAULT NULL,
  `eAppendTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`EmployeeID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_employee_info
-- ----------------------------
INSERT INTO `base_employee_info` VALUES (1, 0, 3, 0, '1', '测试', '男', '未婚', '1992-03-12', 11, 10, '测试', 1, 1, 1, '2016-03-01', '11111111@qq.com', '8937122544', '332934295', '18084730922', NULL, 1, '2020-05-25 15:24:04');

-- ----------------------------
-- Table structure for base_job_position_info
-- ----------------------------
DROP TABLE IF EXISTS `base_job_position_info`;
CREATE TABLE `base_job_position_info`  (
  `JobPositionID` int(11) NOT NULL AUTO_INCREMENT,
  `SystemID` int(11) NULL DEFAULT NULL,
  `BranchID` int(11) NULL DEFAULT NULL,
  `BranchName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `DepartmentID` int(11) NULL DEFAULT NULL,
  `DepartmentName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `JPItemID` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `JPName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `JPPermissions` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `JobLevel` int(11) NULL DEFAULT NULL,
  `JPRemark` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `JState` tinyint(1) NULL DEFAULT NULL,
  `JPAppendTime` datetime(0) NULL DEFAULT NULL,
  `JPUpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`JobPositionID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 11 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_job_position_info
-- ----------------------------
INSERT INTO `base_job_position_info` VALUES (10, 0, 3, '达塔科技', 11, '研发部', '10', '测试', '4,6,34,35,37,38,36,7,39,40,41,42,43,8,44,45,46,47,48,9,49,50,53,10,12,24,25,26,27,28,29,15,17,19,20,23,21,58,59,74,60,61,62,63,64,65,66,67,68,69,70,71,72,73', 0, '', 1, '2020-05-22 10:33:16', '2020-06-04 17:46:36');

-- ----------------------------
-- Table structure for base_permission_info
-- ----------------------------
DROP TABLE IF EXISTS `base_permission_info`;
CREATE TABLE `base_permission_info`  (
  `PermissionID` int(11) NOT NULL AUTO_INCREMENT,
  `ParentID` int(11) NULL DEFAULT NULL,
  `PermissionName` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `PermissionValue` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NULL DEFAULT NULL,
  `IsUse` tinyint(1) NULL DEFAULT NULL,
  `pAppendTime` datetime(0) NULL DEFAULT NULL,
  `pUpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`PermissionID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 75 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_permission_info
-- ----------------------------
INSERT INTO `base_permission_info` VALUES (4, 0, '组织机构', 'OrganizationManagement', 0, 1, '2020-05-26 17:04:04', '2020-05-28 10:49:45');
INSERT INTO `base_permission_info` VALUES (5, 4, '分支机构', 'Branch', 0, 1, '2020-05-26 17:04:17', '2020-05-28 11:06:37');
INSERT INTO `base_permission_info` VALUES (6, 4, '部门管理', 'Department', 0, 1, '2020-05-26 17:04:25', '2020-05-28 11:06:27');
INSERT INTO `base_permission_info` VALUES (7, 4, '岗位管理', 'JobPosition', 0, 1, '2020-05-26 17:04:36', '2020-05-28 11:06:19');
INSERT INTO `base_permission_info` VALUES (8, 4, '人员管理', 'Employee', 0, 1, '2020-05-26 17:04:46', '2020-05-28 11:06:09');
INSERT INTO `base_permission_info` VALUES (9, 4, '操作账户', 'UserAccount', 0, 1, '2020-05-26 17:04:54', '2020-05-28 11:06:01');
INSERT INTO `base_permission_info` VALUES (10, 0, '系统设置', 'SystemManagement', 0, 1, '2020-05-26 17:16:11', '2020-05-28 10:49:28');
INSERT INTO `base_permission_info` VALUES (17, 15, '查看页面', '/Permission/PermissionEdit', 0, 1, '2020-05-26 17:18:36', '2020-05-27 16:59:22');
INSERT INTO `base_permission_info` VALUES (19, 15, '编辑', '/Permission/PermissionSave', 0, 1, '2020-05-26 17:19:21', '2020-05-27 16:58:46');
INSERT INTO `base_permission_info` VALUES (20, 15, '删除', '/Permission/PermissionDel', 0, 1, '2020-05-26 17:19:27', '2020-05-27 16:58:01');
INSERT INTO `base_permission_info` VALUES (23, 15, '查看列表', '/Permission/PermissionList', 0, 1, '2020-05-27 16:59:44', '2020-05-27 16:59:44');
INSERT INTO `base_permission_info` VALUES (24, 12, '查看列表', '/Dictionary/DictionaryList', 0, 1, '2020-05-27 17:00:10', '2020-05-27 17:00:10');
INSERT INTO `base_permission_info` VALUES (25, 12, '查看详情页', '/Dictionary/DictionaryEdit', 0, 1, '2020-05-27 17:00:28', '2020-05-27 17:00:28');
INSERT INTO `base_permission_info` VALUES (26, 12, '编辑', '/Dictionary/DictionarySave', 0, 1, '2020-05-27 17:00:57', '2020-05-27 17:00:57');
INSERT INTO `base_permission_info` VALUES (27, 12, '排序', '/Dictionary/DictionarySort', 0, 1, '2020-05-27 17:01:08', '2020-05-27 17:01:08');
INSERT INTO `base_permission_info` VALUES (28, 12, '状态开关', '/Dictionary/DictionaryStatus', 0, 1, '2020-05-27 17:01:24', '2020-05-27 17:01:24');
INSERT INTO `base_permission_info` VALUES (29, 12, '删除', '/Dictionary/DictionaryDel', 0, 1, '2020-05-27 17:01:43', '2020-05-27 17:01:43');
INSERT INTO `base_permission_info` VALUES (30, 5, '查看详情', '/Branch/BranchEdit', 0, 1, '2020-05-27 17:02:25', '2020-05-27 17:02:25');
INSERT INTO `base_permission_info` VALUES (31, 5, '编辑', '/Branch/BranchSave', 0, 1, '2020-05-27 17:03:51', '2020-05-27 17:03:51');
INSERT INTO `base_permission_info` VALUES (32, 5, '删除', '/Branch/BranchDel', 0, 1, '2020-05-27 17:04:03', '2020-05-27 17:04:03');
INSERT INTO `base_permission_info` VALUES (33, 5, '状态开关', '/Branch/BranchStatus', 0, 1, '2020-05-27 17:04:12', '2020-05-27 17:04:12');
INSERT INTO `base_permission_info` VALUES (34, 6, '查看列表', '/Department/DepartmentList', 0, 1, '2020-05-27 17:04:30', '2020-05-27 17:04:30');
INSERT INTO `base_permission_info` VALUES (35, 6, '查看详情', '/Department/DepartmentEdit', 0, 1, '2020-05-27 17:04:45', '2020-05-27 17:04:45');
INSERT INTO `base_permission_info` VALUES (37, 6, '删除', '/Department/DepartmentDel', 0, 1, '2020-05-27 17:05:14', '2020-05-27 17:05:14');
INSERT INTO `base_permission_info` VALUES (38, 6, '状态开关', '/Department/DepartmentStatus', 0, 1, '2020-05-27 17:05:25', '2020-05-27 17:05:25');
INSERT INTO `base_permission_info` VALUES (39, 7, '查看列表', '/JobPosition/JobPositionList', 0, 1, '2020-05-27 17:05:43', '2020-05-27 17:05:43');
INSERT INTO `base_permission_info` VALUES (40, 7, '查看详情', '/JobPosition/JobPositionEdit', 0, 1, '2020-05-27 17:05:55', '2020-05-27 17:05:55');
INSERT INTO `base_permission_info` VALUES (41, 7, '编辑', '/JobPosition/JobPositionSave', 0, 1, '2020-05-27 17:06:05', '2020-05-27 17:06:05');
INSERT INTO `base_permission_info` VALUES (42, 7, '删除', '/JobPosition/JobPositionDel', 0, 1, '2020-05-27 17:06:15', '2020-05-27 17:06:15');
INSERT INTO `base_permission_info` VALUES (12, 10, '字典管理', 'Dictionary', 0, 1, '2020-05-26 17:16:28', '2020-05-28 11:05:35');
INSERT INTO `base_permission_info` VALUES (15, 10, '权限管理', 'Permission', 0, 1, '2020-05-26 17:18:16', '2020-05-28 11:05:22');
INSERT INTO `base_permission_info` VALUES (21, 15, '状态开关', '/Permission/PermissionStatus', 0, 1, '2020-05-27 15:49:20', '2020-05-27 16:57:50');
INSERT INTO `base_permission_info` VALUES (22, 5, '查看列表', '/Branch/BranchList', 0, 1, '2020-05-27 16:35:02', '2020-05-27 16:35:02');
INSERT INTO `base_permission_info` VALUES (36, 6, '编辑', '/Department/DepartmentSave', 0, 1, '2020-05-27 17:05:04', '2020-05-27 17:05:04');
INSERT INTO `base_permission_info` VALUES (43, 7, '状态开关', '/JobPosition/JobPositionStatus', 0, 1, '2020-05-27 17:06:26', '2020-05-27 17:06:26');
INSERT INTO `base_permission_info` VALUES (44, 8, '查看列表', '/Employee/EmployeeList', 0, 1, '2020-05-27 17:06:52', '2020-05-27 17:06:52');
INSERT INTO `base_permission_info` VALUES (45, 8, '查看详情', '/Employee/EmployeeEdit', 0, 1, '2020-05-27 17:07:04', '2020-05-27 17:07:04');
INSERT INTO `base_permission_info` VALUES (46, 8, '编辑', '/Employee/EmployeeSave', 0, 1, '2020-05-27 17:07:18', '2020-05-27 17:07:18');
INSERT INTO `base_permission_info` VALUES (47, 8, '删除', '/Employee/EmployeeDel', 0, 1, '2020-05-27 17:07:27', '2020-05-27 17:07:27');
INSERT INTO `base_permission_info` VALUES (48, 8, '状态开关', '/Employee/EmployeeStatus', 0, 1, '2020-05-27 17:07:36', '2020-05-27 17:07:36');
INSERT INTO `base_permission_info` VALUES (49, 9, '查看列表', '/UserAccount/UserAccountList', 0, 1, '2020-05-27 17:08:02', '2020-05-27 17:08:02');
INSERT INTO `base_permission_info` VALUES (50, 9, '查看详情', '/UserAccount/UserAccountEdit', 0, 1, '2020-05-27 17:08:14', '2020-05-27 17:08:14');
INSERT INTO `base_permission_info` VALUES (51, 9, '编辑', '/UserAccount/UserAccountSave', 0, 1, '2020-05-27 17:08:24', '2020-05-27 17:08:24');
INSERT INTO `base_permission_info` VALUES (52, 9, '删除', '/UserAccount/UserAccountDel', 0, 1, '2020-05-27 17:08:34', '2020-05-27 17:08:34');
INSERT INTO `base_permission_info` VALUES (53, 9, '状态开关', '/UserAccount/UserAccountStatus', 0, 1, '2020-05-27 17:08:44', '2020-05-27 17:08:44');
INSERT INTO `base_permission_info` VALUES (58, 0, '系统日志', 'SystemLog', 0, 1, '2020-06-04 17:22:30', '2020-06-04 17:22:30');
INSERT INTO `base_permission_info` VALUES (59, 58, 'LogLevelList', '/SystemLog/LogLevelList', 0, 1, '2020-06-04 17:30:43', '2020-06-04 17:31:07');
INSERT INTO `base_permission_info` VALUES (74, 58, 'LogTypeClassDel', '/SystemLog/LogTypeClassDel', 0, 1, '2020-06-04 17:37:43', '2020-06-04 17:37:43');
INSERT INTO `base_permission_info` VALUES (60, 58, 'LogLevelEdit', '/SystemLog/LogLevelEdit', 0, 1, '2020-06-04 17:32:09', '2020-06-04 17:32:09');
INSERT INTO `base_permission_info` VALUES (61, 58, 'LogLevelSave', '/SystemLog/LogLevelSave', 0, 1, '2020-06-04 17:32:19', '2020-06-04 17:32:19');
INSERT INTO `base_permission_info` VALUES (62, 58, 'LogLevelDel', '/SystemLog/LogLevelDel', 0, 1, '2020-06-04 17:32:35', '2020-06-04 17:32:35');
INSERT INTO `base_permission_info` VALUES (63, 58, 'LogLevelStatus', '/SystemLog/LogLevelStatus', 0, 1, '2020-06-04 17:32:50', '2020-06-04 17:32:50');
INSERT INTO `base_permission_info` VALUES (64, 58, 'LogRecordList', '/SystemLog/LogRecordList', 0, 1, '2020-06-04 17:33:03', '2020-06-04 17:33:03');
INSERT INTO `base_permission_info` VALUES (65, 58, 'LogRecordDel', '/SystemLog/LogRecordDel', 0, 1, '2020-06-04 17:33:14', '2020-06-04 17:33:14');
INSERT INTO `base_permission_info` VALUES (66, 58, 'LogTypeList', '/SystemLog/LogTypeList', 0, 1, '2020-06-04 17:35:38', '2020-06-04 17:35:38');
INSERT INTO `base_permission_info` VALUES (67, 58, 'LogTypeEdit', '/SystemLog/LogTypeEdit', 0, 1, '2020-06-04 17:35:54', '2020-06-04 17:35:54');
INSERT INTO `base_permission_info` VALUES (68, 58, 'LogTypeSave', '/SystemLog/LogTypeSave', 0, 1, '2020-06-04 17:36:11', '2020-06-04 17:36:11');
INSERT INTO `base_permission_info` VALUES (69, 58, 'LogTypeDel', '/SystemLog/LogTypeDel', 0, 1, '2020-06-04 17:36:33', '2020-06-04 17:36:33');
INSERT INTO `base_permission_info` VALUES (70, 58, 'LogTypeStatus', '/SystemLog/LogTypeStatus', 0, 1, '2020-06-04 17:36:46', '2020-06-04 17:36:46');
INSERT INTO `base_permission_info` VALUES (71, 58, 'LogTypeClassList', '/SystemLog/LogTypeClassList', 0, 1, '2020-06-04 17:37:02', '2020-06-04 17:37:02');
INSERT INTO `base_permission_info` VALUES (72, 58, 'LogTypeClassEdit', '/SystemLog/LogTypeClassEdit', 0, 1, '2020-06-04 17:37:13', '2020-06-04 17:37:13');
INSERT INTO `base_permission_info` VALUES (73, 58, 'LogTypeClassSave', '/SystemLog/LogTypeClassSave', 0, 1, '2020-06-04 17:37:22', '2020-06-04 17:37:22');

-- ----------------------------
-- Table structure for base_user_info
-- ----------------------------
DROP TABLE IF EXISTS `base_user_info`;
CREATE TABLE `base_user_info`  (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `SystemID` int(11) NULL DEFAULT NULL,
  `BranchID` int(11) NULL DEFAULT NULL,
  `DepartmentID` int(11) NULL DEFAULT NULL,
  `EmployeeID` int(11) NULL DEFAULT NULL,
  `uName` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `uPWD` char(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `uCode` char(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `uAppendTime` datetime(0) NULL DEFAULT NULL,
  `uUpAppendTime` datetime(0) NULL DEFAULT NULL,
  `uLastIP` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `uType` int(11) NULL DEFAULT NULL,
  `uState` tinyint(1) NULL DEFAULT NULL,
  `olTime` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`UserID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of base_user_info
-- ----------------------------
INSERT INTO `base_user_info` VALUES (4, 0, 3, 11, 1, 'chengan', 'e10adc3949ba59abbe56e057f20f883e', '', '2020-05-25 18:04:12', '2020-06-05 01:08:50', '127.0.0.1', 0, 1, 3);

-- ----------------------------
-- Procedure structure for CommonPagenation
-- ----------------------------
DROP PROCEDURE IF EXISTS `CommonPagenation`;
delimiter ;;
CREATE PROCEDURE `CommonPagenation`(IN tableName VARCHAR ( 255 ),
	IN showFName VARCHAR ( 500 ),
	IN selectWhere VARCHAR ( 500 ),
	IN selectOrder VARCHAR ( 200 ),
	IN pageNo INT,
	IN pageSize INT)
BEGIN
	
	SET @startrow = ( pageNo - 1 ) * pageSize;
	
	SET @pagesize = pageSize;
	
	SET @rowindex = 0;
	
	SET @strsql = CONCAT(
		'select SQL_CALC_FOUND_ROWS ',
		showFName,
		' from ',
		tableName,
		CASE
				IFNULL( selectWhere, '' ) 
				WHEN '' THEN
				'' ELSE CONCAT ( ' where ', selectWhere ) 
			END,
		CASE
				IFNULL( selectOrder, '' ) 
				WHEN '' THEN
				'' ELSE CONCAT( ' order by ', selectOrder ) 
			END,
			' limit ',
			@startRow,
			',',
			@pagesize 
		);
	
	SET @countsql = "SELECT FOUND_ROWS()";
	PREPARE strsql 
	FROM
		@strsql;
	EXECUTE strsql;
	PREPARE countsql 
	FROM
		@countsql;
	EXECUTE countsql;

END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
