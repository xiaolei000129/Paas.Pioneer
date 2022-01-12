/*
 Navicat Premium Data Transfer

 Source Server         : www.haosay.com
 Source Server Type    : MySQL
 Source Server Version : 80023
 Source Host           : www.haosay.com:3306
 Source Schema         : Com.Morning.Application.Abp

 Target Server Type    : MySQL
 Target Server Version : 80023
 File Encoding         : 65001

 Date: 11/01/2022 23:34:25
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for AbpBackgroundJobs
-- ----------------------------
DROP TABLE IF EXISTS `AbpBackgroundJobs`;
CREATE TABLE `AbpBackgroundJobs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `JobName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `JobArgs` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TryCount` smallint NOT NULL DEFAULT 0,
  `CreationTime` datetime(6) NOT NULL,
  `NextTryTime` datetime(6) NOT NULL,
  `LastTryTime` datetime(6) NULL DEFAULT NULL,
  `IsAbandoned` tinyint(1) NOT NULL DEFAULT 0,
  `Priority` tinyint UNSIGNED NOT NULL DEFAULT 15,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBackgroundJobs_IsAbandoned_NextTryTime`(`IsAbandoned`, `NextTryTime`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of AbpBackgroundJobs
-- ----------------------------

-- ----------------------------
-- Table structure for AbpEntityChanges
-- ----------------------------
DROP TABLE IF EXISTS `AbpEntityChanges`;
CREATE TABLE `AbpEntityChanges`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `AuditLogId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ChangeTime` datetime(6) NOT NULL,
  `ChangeType` tinyint UNSIGNED NOT NULL,
  `EntityTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `EntityId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EntityTypeFullName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpEntityChanges_AuditLogId`(`AuditLogId`) USING BTREE,
  INDEX `IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId`(`TenantId`, `EntityTypeFullName`, `EntityId`) USING BTREE,
  CONSTRAINT `FK_AbpEntityChanges_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `AbpAuditLogs` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of AbpEntityChanges
-- ----------------------------

-- ----------------------------
-- Table structure for AbpEntityPropertyChanges
-- ----------------------------
DROP TABLE IF EXISTS `AbpEntityPropertyChanges`;
CREATE TABLE `AbpEntityPropertyChanges`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `EntityChangeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `NewValue` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `OriginalValue` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `PropertyName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PropertyTypeFullName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpEntityPropertyChanges_EntityChangeId`(`EntityChangeId`) USING BTREE,
  CONSTRAINT `FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId` FOREIGN KEY (`EntityChangeId`) REFERENCES `AbpEntityChanges` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of AbpEntityPropertyChanges
-- ----------------------------

-- ----------------------------
-- Table structure for AbpTenantConnectionStrings
-- ----------------------------
DROP TABLE IF EXISTS `AbpTenantConnectionStrings`;
CREATE TABLE `AbpTenantConnectionStrings`  (
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`TenantId`, `Name`) USING BTREE,
  CONSTRAINT `FK_AbpTenantConnectionStrings_AbpTenants_TenantId` FOREIGN KEY (`TenantId`) REFERENCES `AbpTenants` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of AbpTenantConnectionStrings
-- ----------------------------

-- ----------------------------
-- Table structure for AbpTenants
-- ----------------------------
DROP TABLE IF EXISTS `AbpTenants`;
CREATE TABLE `AbpTenants`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `LastModificationTime` datetime(6) NULL DEFAULT NULL,
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `DeletionTime` datetime(6) NULL DEFAULT NULL,
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `TenantType` int NULL DEFAULT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Enabled` tinyint(1) NULL DEFAULT NULL,
  `Phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `RealName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpTenants_Name`(`Name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of AbpTenants
-- ----------------------------
INSERT INTO `AbpTenants` VALUES ('39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '晨曦', '{}', NULL, '2021-09-03 16:31:52.000000', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-03 13:56:51.000000', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-03 13:57:13.000000', '808fa030-49d5-408b-82a6-5835de3209e4', 1, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', 'morning', '晨曦集团', '1173514237@qq.com', 1, '17674705062', '段丛磊');
INSERT INTO `AbpTenants` VALUES ('3a015be9-e1d8-1fab-3e24-ef879c72abae', '晨曦子公司', '{}', 'ea7ccf30e3f74442a2b1fe76c0f35ce3', '2022-01-11 23:23:52.679993', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-11 23:23:52.901692', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', 0, NULL, NULL, '3a015be9-e28d-cde7-5f69-db8cd286e924', 2, '3a015be9-e27c-ad59-1a55-c1303e1b9671', '', '', '', 1, '17674705063', '段晨曦');

-- ----------------------------
-- Table structure for Ad_Api
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Api`;
CREATE TABLE `Ad_Api`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '所属模块',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '接口命名',
  `Label` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '接口名称',
  `Path` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '接口地址',
  `HttpMethods` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '接口提交方法',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '说明',
  `Sort` int NOT NULL COMMENT '排序',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_ParentId`(`ParentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '接口管理' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Api
-- ----------------------------
INSERT INTO `Ad_Api` VALUES ('00ed22d7-5bc6-4ab1-a154-384247ce8616', 'e5f8423f-5426-4050-b8c5-ef5fa0420eae', NULL, '新增员工', '/api/personnel/employee/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.535335', NULL, NULL, '2021-10-01 10:52:02.535345');
INSERT INTO `Ad_Api` VALUES ('020fe65e-377e-4924-998c-0d6029cad87a', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '修改权限点', '/api/admin/permission/updatedot', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.456307', NULL, NULL, '2021-10-01 10:52:00.456318');
INSERT INTO `Ad_Api` VALUES ('04426df7-b6bb-4be5-86ed-a6319cdcfa06', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '查询分页租户', '/api/admin/tenant/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.264878', NULL, NULL, '2022-01-08 22:16:48.400295');
INSERT INTO `Ad_Api` VALUES ('061fc36f-f9c3-4469-895f-a3c2f5074a3d', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询单条接口', '/api/admin/permission/getapi', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.048276', NULL, NULL, '2021-10-01 10:52:00.048287');
INSERT INTO `Ad_Api` VALUES ('078c2998-72f8-4133-ade2-35547688e412', '60c18863-7bf7-4419-abdc-65a4ea69cc92', NULL, '查询单条数据字典类型', '/api/admin/dictionarytype/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:03.118873', NULL, NULL, '2021-10-01 10:52:03.118892');
INSERT INTO `Ad_Api` VALUES ('07ba61ad-5e76-4435-8550-4e1424527817', '8c5d7505-cd2a-44ac-8eac-f5b95dce490d', NULL, '查询组织架构列表', '/api/personnel/organization/getlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.825995', NULL, NULL, '2021-10-01 10:52:02.826006');
INSERT INTO `Ad_Api` VALUES ('0974bc06-8cd9-4965-82a6-146917d01631', '97d13342-a183-48c9-9aad-d768f1d7bb4f', NULL, '批量删除数据字典', '/api/admin/dictionary/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:51:59.892856', NULL, NULL, '2021-10-01 10:51:59.892880');
INSERT INTO `Ad_Api` VALUES ('1262e0e5-7ab5-47d9-b927-019eda94ec7a', '548507e7-72f9-4f88-b023-6822199036ef', NULL, '查询分页操作日志', '/api/admin/oprationlog/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.687233', NULL, NULL, '2022-01-08 22:16:48.400389');
INSERT INTO `Ad_Api` VALUES ('1757ebf0-c50e-4eb8-a1cc-0a11d4be5228', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询租户权限', '/api/admin/permission/gettenantpermissionlist', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.527025', NULL, NULL, '2021-10-01 10:52:00.527035');
INSERT INTO `Ad_Api` VALUES ('183fbfe7-bd06-4512-9d04-476cae7698cf', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '修改菜单', '/api/admin/document/updatemenu', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.974092', NULL, NULL, '2021-10-01 10:52:01.974103');
INSERT INTO `Ad_Api` VALUES ('19865940-b8ed-468f-aadc-84ee488db2b6', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询单条分组', '/api/admin/permission/getgroup', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.985593', NULL, NULL, '2021-10-01 10:51:59.985605');
INSERT INTO `Ad_Api` VALUES ('1bd7d2e1-1e59-4b64-af30-069f70117c9f', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '修改菜单', '/api/admin/permission/updatemenu', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.271418', NULL, NULL, '2021-10-01 10:52:00.271429');
INSERT INTO `Ad_Api` VALUES ('1da4bd1b-d719-40f2-a81d-2b2944d7d1a8', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '查询分页用户', '/api/admin/user/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.925323', NULL, NULL, '2022-01-08 22:16:48.400404');
INSERT INTO `Ad_Api` VALUES ('1dd8908d-9f2d-410c-a1c8-9f55c612be71', 'e5f8423f-5426-4050-b8c5-ef5fa0420eae', NULL, '查询分页员工', '/api/personnel/employee/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.505609', NULL, NULL, '2022-01-08 22:16:48.400413');
INSERT INTO `Ad_Api` VALUES ('25737e4c-6f7c-4bca-b117-39e72d649c02', '97d13342-a183-48c9-9aad-d768f1d7bb4f', NULL, '修改数据字典', '/api/admin/dictionary/update', 'put', '', 0, 1, 0, '2021-10-01 10:51:59.832532', NULL, NULL, '2021-10-01 10:51:59.832543');
INSERT INTO `Ad_Api` VALUES ('2927ec16-55d1-4fc4-a010-58e2e8f2864a', 'babb93f4-36b5-4465-9077-a2e5ef002f6c', NULL, '查询单条角色', '/api/admin/role/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.651242', NULL, NULL, '2021-10-01 10:52:00.651256');
INSERT INTO `Ad_Api` VALUES ('2a7ec0d0-25d0-47ee-bf27-78f7d0417db3', 'babb93f4-36b5-4465-9077-a2e5ef002f6c', NULL, '查询分页角色', '/api/admin/role/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.681071', NULL, NULL, '2022-01-08 22:16:48.400423');
INSERT INTO `Ad_Api` VALUES ('2e4e28cb-da84-47cb-9960-5ee45d333a4e', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '查询文档图片列表', '/api/admin/document/getimagelist', 'get', '', 0, 1, 0, '2021-10-01 10:52:02.138500', NULL, NULL, '2021-10-01 10:52:02.138510');
INSERT INTO `Ad_Api` VALUES ('2ff24eb6-2d91-4fa4-9a65-3617f9344cec', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '修改视图', '/api/admin/view/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.368604', NULL, NULL, '2021-10-01 10:52:01.368614');
INSERT INTO `Ad_Api` VALUES ('301bf5a0-e0a3-4da4-9d92-0c81529e232e', '60c18863-7bf7-4419-abdc-65a4ea69cc92', NULL, '删除数据字典类型', '/api/admin/dictionarytype/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:03.247098', NULL, NULL, '2021-10-01 10:52:03.247108');
INSERT INTO `Ad_Api` VALUES ('302b004e-d697-4ee4-9305-05f9ce2654b8', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '删除权限', '/api/admin/permission/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:00.332444', NULL, NULL, '2021-10-01 10:52:00.332467');
INSERT INTO `Ad_Api` VALUES ('305a4077-fd0d-48d8-9ba4-db24b6c4ad0e', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '删除视图', '/api/admin/view/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:01.398392', NULL, NULL, '2021-10-01 10:52:01.398402');
INSERT INTO `Ad_Api` VALUES ('308e95f4-f135-4076-beb3-3d23e2ce4813', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '修改分组', '/api/admin/document/updategroup', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.943712', NULL, NULL, '2021-10-01 10:52:01.943722');
INSERT INTO `Ad_Api` VALUES ('31924c96-bb7d-4165-9ef6-86fc6e0ef292', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '查询分页视图', '/api/admin/view/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.296754', NULL, NULL, '2022-01-08 22:16:48.400432');
INSERT INTO `Ad_Api` VALUES ('339a1b2e-6e88-4d6f-9fc1-185e7eb4e30e', '97d13342-a183-48c9-9aad-d768f1d7bb4f', NULL, '新增数据字典', '/api/admin/dictionary/add', 'post', '', 0, 1, 0, '2021-10-01 10:51:59.802239', NULL, NULL, '2021-10-01 10:51:59.802270');
INSERT INTO `Ad_Api` VALUES ('3649fb59-5172-435e-837e-cada13cacd17', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '查询精简文档列表', '/api/admin/document/getplainlist', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.841465', NULL, NULL, '2021-10-01 10:52:01.841478');
INSERT INTO `Ad_Api` VALUES ('3a0156a7-fb3f-15c3-7e27-e7a4f90e18e5', '00000000-0000-0000-0000-000000000000', NULL, '低代码管理', 'low-code-table', '', '', 0, 1, 0, '2022-01-10 22:53:47.852545', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:01:56.071172');
INSERT INTO `Ad_Api` VALUES ('3a0156a9-bd27-0a8f-5442-2e40b85a26af', '3a0156a7-fb3f-15c3-7e27-e7a4f90e18e5', NULL, '添加', '/api/admin/low-code-table/add', 'post', '', 0, 1, 0, '2022-01-10 22:55:43.012366', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:01:48.209063');
INSERT INTO `Ad_Api` VALUES ('3a0156aa-516c-23d9-cdfc-863d4b597382', '3a0156a7-fb3f-15c3-7e27-e7a4f90e18e5', NULL, '修改', '/api/admin/low-code-table/update', 'put', '', 0, 1, 0, '2022-01-10 22:56:20.970179', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:01:39.323870');
INSERT INTO `Ad_Api` VALUES ('3a0156aa-cda4-5a6b-16e1-6839379a3cf3', '3a0156a7-fb3f-15c3-7e27-e7a4f90e18e5', NULL, '删除', '/api/admin/low-code-table/delete', 'delete', '', 0, 1, 0, '2022-01-10 22:56:52.767645', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:01:30.658395');
INSERT INTO `Ad_Api` VALUES ('3a0156ab-63dd-d207-5924-720fc0613c84', '3a0156a7-fb3f-15c3-7e27-e7a4f90e18e5', NULL, '生成代码', '/api/admin/low-code-table/generate', 'post', '', 0, 1, 0, '2022-01-10 22:57:31.232054', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:09:56.033007');
INSERT INTO `Ad_Api` VALUES ('3a0156ae-9c37-fe75-5b8e-aec72c9b7042', '3a0156a7-fb3f-15c3-7e27-e7a4f90e18e5', NULL, '查询列表', '/api/admin/low-code-table/get-page-list', 'get', '', 0, 1, 0, '2022-01-10 23:01:02.258895', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_Api` VALUES ('3a4fc478-f25d-4744-85ae-d30f65a9dcd6', '71e74ada-8891-4971-b512-01a8f66b7dfb', NULL, '获取密钥', '/api/admin/auth/getpasswordencryptkey', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.579794', NULL, NULL, '2021-10-01 10:51:59.579822');
INSERT INTO `Ad_Api` VALUES ('3bff34bc-2b81-4c8d-a4ec-953e125d9d41', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '删除租户', '/api/admin/tenant/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:02.354985', NULL, NULL, '2021-10-01 10:52:02.354996');
INSERT INTO `Ad_Api` VALUES ('3df46b91-dbd7-4f49-af4e-03add9c0ce04', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '批量删除用户', '/api/admin/user/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.051471', NULL, NULL, '2021-10-01 10:52:01.051485');
INSERT INTO `Ad_Api` VALUES ('3eadb5b9-c142-4080-8b87-5dc707fff499', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '同步接口', '/api/admin/api/sync', 'post', '支持新增和修改接口\r\n根据接口是否存在自动禁用和启用api', 0, 1, 0, '2021-10-01 10:51:59.480759', NULL, NULL, '2021-10-01 10:51:59.480786');
INSERT INTO `Ad_Api` VALUES ('4365a324-21d4-4fbc-a374-79d90b1fa253', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询单条权限点', '/api/admin/permission/getdot', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.395706', NULL, NULL, '2021-10-01 10:52:00.395718');
INSERT INTO `Ad_Api` VALUES ('4621eee7-f2f2-462a-be6d-98795e75744d', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '新增用户', '/api/admin/user/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.956507', NULL, NULL, '2021-10-01 10:52:00.956517');
INSERT INTO `Ad_Api` VALUES ('48bafa86-7008-4a56-99c7-a6baddc1a6f6', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '上传文档图片', '/api/admin/document/uploadimage', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.105892', NULL, NULL, '2021-10-01 10:52:02.105903');
INSERT INTO `Ad_Api` VALUES ('4bf21d67-a0cf-4fcf-8d22-61cfe8b26ffd', 'babb93f4-36b5-4465-9077-a2e5ef002f6c', NULL, '批量删除角色', '/api/admin/role/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.803275', NULL, NULL, '2021-10-01 10:52:00.803290');
INSERT INTO `Ad_Api` VALUES ('4f0942d0-88cb-4699-a486-9c83eb262c36', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '同步视图', '/api/admin/view/sync', 'post', '支持新增和修改视图\r\n根据视图是否存在自动禁用和启用视图', 0, 1, 0, '2021-10-01 10:52:01.461350', NULL, NULL, '2021-10-01 10:52:01.461360');
INSERT INTO `Ad_Api` VALUES ('50b6e85f-b35d-468a-a057-ce5fe7d159ea', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '修改接口', '/api/admin/api/update', 'put', '', 0, 1, 0, '2021-10-01 10:51:59.389946', NULL, NULL, '2021-10-01 10:51:59.389967');
INSERT INTO `Ad_Api` VALUES ('548507e7-72f9-4f88-b023-6822199036ef', '00000000-0000-0000-0000-000000000000', NULL, '操作日志管理', 'oprationlog', NULL, '', 0, 1, 0, '2021-10-01 10:52:01.656600', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-10 17:06:33.171810');
INSERT INTO `Ad_Api` VALUES ('57235f10-dcd1-4bbd-b9da-ebd132fe64a8', '872661d8-3c40-433e-9508-d7fcb68291ce', NULL, '修改职位', '/api/personnel/position/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.986582', NULL, NULL, '2021-10-01 10:52:02.986593');
INSERT INTO `Ad_Api` VALUES ('5f62f723-7259-4a26-99cc-30ea0b92259e', 'babb93f4-36b5-4465-9077-a2e5ef002f6c', NULL, '删除角色', '/api/admin/role/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:00.774401', NULL, NULL, '2021-10-01 10:52:00.774411');
INSERT INTO `Ad_Api` VALUES ('5f65bc4c-7982-4451-9f91-5f4b05b8f00d', 'd3c87b82-1eba-4fe9-9485-7c8dd295bf6b', NULL, '获取缓存列表', '/api/admin/cache/list', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.525179', NULL, NULL, '2021-10-01 10:52:01.525192');
INSERT INTO `Ad_Api` VALUES ('60c18863-7bf7-4419-abdc-65a4ea69cc92', '00000000-0000-0000-0000-000000000000', NULL, '数据字典类型', 'dictionarytype', NULL, '', 0, 1, 0, '2021-10-01 10:52:03.081381', NULL, NULL, '2021-10-01 10:52:03.081391');
INSERT INTO `Ad_Api` VALUES ('60d70eaf-3cba-4c7a-b1c7-8f6e1a63d891', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '修改分组', '/api/admin/permission/updategroup', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.242385', NULL, NULL, '2021-10-01 10:52:00.242396');
INSERT INTO `Ad_Api` VALUES ('634e23f6-9195-4b49-baf7-24343575ef31', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '批量删除视图', '/api/admin/view/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.431786', NULL, NULL, '2021-10-01 10:52:01.431796');
INSERT INTO `Ad_Api` VALUES ('66813d2c-b903-430c-b674-86b973b4f84d', 'e5f8423f-5426-4050-b8c5-ef5fa0420eae', NULL, '修改员工', '/api/personnel/employee/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.567009', NULL, NULL, '2021-10-01 10:52:02.567019');
INSERT INTO `Ad_Api` VALUES ('67553d2a-023a-4492-96bd-7749fafb54a4', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '查询单条用户', '/api/admin/user/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.896116', NULL, NULL, '2021-10-01 10:52:00.896133');
INSERT INTO `Ad_Api` VALUES ('67f0cbb4-68fe-4e28-a895-fc3d296dee93', '60c18863-7bf7-4419-abdc-65a4ea69cc92', NULL, '查询分页数据字典类型', '/api/admin/dictionarytype/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:03.149403', NULL, NULL, '2022-01-08 22:16:48.400640');
INSERT INTO `Ad_Api` VALUES ('6bcbba6d-4b65-4793-8aa9-d5deaa96abdc', 'babb93f4-36b5-4465-9077-a2e5ef002f6c', NULL, '新增角色', '/api/admin/role/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.711999', NULL, NULL, '2021-10-01 10:52:00.712010');
INSERT INTO `Ad_Api` VALUES ('6d56a6d3-79fb-4ee8-8a24-8f07e157130d', '872661d8-3c40-433e-9508-d7fcb68291ce', NULL, '新增职位', '/api/personnel/position/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.956386', NULL, NULL, '2021-10-01 10:52:02.956410');
INSERT INTO `Ad_Api` VALUES ('70238d9a-5642-4188-b447-d7c3ac4b2d5b', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '查询全部接口', '/api/admin/api/getlist', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.299029', NULL, NULL, '2021-10-01 10:51:59.299046');
INSERT INTO `Ad_Api` VALUES ('70b8d13b-fe23-4919-8bf8-9664dc10ad07', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询权限列表', '/api/admin/permission/getlist', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.955555', NULL, NULL, '2021-10-01 10:51:59.955569');
INSERT INTO `Ad_Api` VALUES ('71938296-f8c3-4951-925f-a270720f5f7d', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '批量删除接口', '/api/admin/api/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:51:59.450052', NULL, NULL, '2021-10-01 10:51:59.450075');
INSERT INTO `Ad_Api` VALUES ('71e74ada-8891-4971-b512-01a8f66b7dfb', '00000000-0000-0000-0000-000000000000', NULL, '授权管理', 'auth', NULL, '', 0, 1, 0, '2021-10-01 10:51:59.519076', NULL, NULL, '2021-10-01 10:51:59.519096');
INSERT INTO `Ad_Api` VALUES ('733fb180-8bfc-4ed4-988b-8a50d7a96728', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '查询全部视图', '/api/admin/view/getlist', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.267220', NULL, NULL, '2021-10-01 10:52:01.267239');
INSERT INTO `Ad_Api` VALUES ('73d76aae-865a-42c0-b8f1-aaa13826f034', '97d13342-a183-48c9-9aad-d768f1d7bb4f', NULL, '查询单条数据字典', '/api/admin/dictionary/get', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.743326', NULL, NULL, '2021-10-01 10:51:59.743339');
INSERT INTO `Ad_Api` VALUES ('7588a542-8c9f-46e0-b8d3-c631d92205e7', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '更新用户基本信息', '/api/admin/user/updatebasic', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.114808', NULL, NULL, '2021-10-01 10:52:01.114819');
INSERT INTO `Ad_Api` VALUES ('76252108-08f8-45e6-b2d1-54dca158df2c', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '新增菜单', '/api/admin/permission/addmenu', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.177904', NULL, NULL, '2021-10-01 10:52:00.177914');
INSERT INTO `Ad_Api` VALUES ('79a5cdee-b373-4c50-8115-aa4c10f0be49', '872661d8-3c40-433e-9508-d7fcb68291ce', NULL, '删除职位', '/api/personnel/position/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:03.016244', NULL, NULL, '2021-10-01 10:52:03.016254');
INSERT INTO `Ad_Api` VALUES ('7b1219aa-cb7d-4a35-9303-d3dc3ccc7d5e', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询角色权限-权限列表', '/api/admin/permission/getpermissionlist', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.077861', NULL, NULL, '2021-10-01 10:52:00.077871');
INSERT INTO `Ad_Api` VALUES ('7be49db6-3509-4caa-ac50-a86b4413b873', '71e74ada-8891-4971-b512-01a8f66b7dfb', NULL, '刷新Token', '/api/admin/auth/refresh', 'get', '以旧换新', 0, 1, 0, '2021-10-01 10:51:59.677101', NULL, NULL, '2021-10-01 10:51:59.677128');
INSERT INTO `Ad_Api` VALUES ('82709669-1aba-4551-ae88-2a7bf262531c', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '查询单条视图', '/api/admin/view/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.234703', NULL, NULL, '2021-10-01 10:52:01.234714');
INSERT INTO `Ad_Api` VALUES ('872661d8-3c40-433e-9508-d7fcb68291ce', '00000000-0000-0000-0000-000000000000', NULL, '职位管理', 'position', NULL, '', 0, 1, 0, '2021-10-01 10:52:02.855260', NULL, NULL, '2021-10-01 10:52:02.855271');
INSERT INTO `Ad_Api` VALUES ('882a9452-343a-4fef-9286-4e6bcea59533', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '更新用户密码', '/api/admin/user/changepassword', 'put', '', 0, 1, 0, '2021-10-01 10:52:01.084526', NULL, NULL, '2021-10-01 10:52:01.084536');
INSERT INTO `Ad_Api` VALUES ('8af617bb-3149-49af-9a30-7b73589d42f7', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '新增接口', '/api/admin/api/add', 'post', '', 0, 1, 0, '2021-10-01 10:51:59.359788', NULL, NULL, '2021-10-01 10:51:59.359805');
INSERT INTO `Ad_Api` VALUES ('8c5d7505-cd2a-44ac-8eac-f5b95dce490d', '00000000-0000-0000-0000-000000000000', NULL, '组织架构', 'organization', NULL, '', 0, 1, 0, '2021-10-01 10:52:02.669657', NULL, NULL, '2021-10-01 10:52:02.669667');
INSERT INTO `Ad_Api` VALUES ('8e98c628-c4f3-424e-be38-65d3f90738d5', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '查询分页接口', '/api/admin/api/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:51:59.328492', NULL, NULL, '2022-01-08 22:16:48.400658');
INSERT INTO `Ad_Api` VALUES ('8f6055a5-f2a5-49e7-9ec9-071f6ec7e42b', '872661d8-3c40-433e-9508-d7fcb68291ce', NULL, '查询单条职位', '/api/personnel/position/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:02.884834', NULL, NULL, '2021-10-01 10:52:02.884848');
INSERT INTO `Ad_Api` VALUES ('90cb4e31-8b78-43a6-960a-a49caf136b04', '8c5d7505-cd2a-44ac-8eac-f5b95dce490d', NULL, '查询单条组织架构', '/api/personnel/organization/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:02.698294', NULL, NULL, '2021-10-01 10:52:02.698308');
INSERT INTO `Ad_Api` VALUES ('91e5090e-2387-4043-aaf4-79312e54a44b', '00000000-0000-0000-0000-000000000000', NULL, '登录日志管理', 'loginlog', NULL, '', 0, 1, 0, '2021-10-01 10:52:01.592689', NULL, NULL, '2021-10-01 10:52:01.592699');
INSERT INTO `Ad_Api` VALUES ('9716eebe-2538-4244-a294-337a7206abe8', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '保存角色权限', '/api/admin/permission/assign', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.364993', NULL, NULL, '2021-10-01 10:52:00.365003');
INSERT INTO `Ad_Api` VALUES ('97d13342-a183-48c9-9aad-d768f1d7bb4f', '00000000-0000-0000-0000-000000000000', NULL, '数据字典', 'dictionary', NULL, '', 0, 1, 0, '2021-10-01 10:51:59.707927', NULL, NULL, '2021-10-01 10:51:59.707938');
INSERT INTO `Ad_Api` VALUES ('986ed499-87e9-481d-a239-21100cce2b23', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询单条菜单', '/api/admin/permission/getmenu', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.018421', NULL, NULL, '2021-10-01 10:52:00.018436');
INSERT INTO `Ad_Api` VALUES ('9c386c8e-1f49-4fe8-95c7-22fdce2cb1b8', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '新增权限点', '/api/admin/permission/adddot', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.425120', NULL, NULL, '2021-10-01 10:52:00.425136');
INSERT INTO `Ad_Api` VALUES ('9f355887-f9ed-4db3-a377-a30ed5c27dcc', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '查询单条菜单', '/api/admin/document/getmenu', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.812073', NULL, NULL, '2021-10-01 10:52:01.812083');
INSERT INTO `Ad_Api` VALUES ('9f551226-207e-4339-b427-46d2589760b6', '60c18863-7bf7-4419-abdc-65a4ea69cc92', NULL, '新增数据字典类型', '/api/admin/dictionarytype/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:03.185299', NULL, NULL, '2021-10-01 10:52:03.185323');
INSERT INTO `Ad_Api` VALUES ('a113e800-995b-4899-b2a9-8a0ad7364098', '60c18863-7bf7-4419-abdc-65a4ea69cc92', NULL, '修改数据字典类型', '/api/admin/dictionarytype/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:03.217229', NULL, NULL, '2021-10-01 10:52:03.217239');
INSERT INTO `Ad_Api` VALUES ('a178abf8-a2d4-4a0e-99e6-d01e8e34e03a', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '新增分组', '/api/admin/permission/addgroup', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.148848', NULL, NULL, '2021-10-01 10:52:00.148858');
INSERT INTO `Ad_Api` VALUES ('a2b70a0a-dee9-471d-b377-af9aa378241c', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '修改租户', '/api/admin/tenant/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.325152', NULL, NULL, '2021-10-01 10:52:02.325163');
INSERT INTO `Ad_Api` VALUES ('a5cb60b6-1e86-4cb8-afc2-be7cff494708', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '删除图片', '/api/admin/document/deleteimage', 'delete', '', 0, 1, 0, '2021-10-01 10:52:02.169544', NULL, NULL, '2021-10-01 10:52:02.169554');
INSERT INTO `Ad_Api` VALUES ('a837d1da-6d79-463e-af00-ce0a9e840c18', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '修改用户', '/api/admin/user/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.990912', NULL, NULL, '2021-10-01 10:52:00.990922');
INSERT INTO `Ad_Api` VALUES ('a9ad8b51-d982-43f7-b360-894a9ca30fc0', 'c392bcda-4b9a-4c96-87f7-9fec23de74e2', NULL, '新增视图', '/api/admin/view/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.330093', NULL, NULL, '2021-10-01 10:52:01.330117');
INSERT INTO `Ad_Api` VALUES ('a9c8bbd1-344d-4410-99ca-f320b62c217c', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '彻底删除权限', '/api/admin/permission/delete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:00.591503', NULL, NULL, '2021-10-01 10:52:00.591517');
INSERT INTO `Ad_Api` VALUES ('ab3ef110-1c26-4111-9a58-be1b7a328b18', 'e5f8423f-5426-4050-b8c5-ef5fa0420eae', NULL, '查询单条员工', '/api/personnel/employee/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:02.476109', NULL, NULL, '2021-10-01 10:52:02.476120');
INSERT INTO `Ad_Api` VALUES ('af3ebca8-3e7c-466c-96dd-97309faae49d', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '查询单条租户', '/api/admin/tenant/get', 'get', '', 0, 1, 0, '2021-10-01 10:52:02.234551', NULL, NULL, '2021-10-01 10:52:02.234562');
INSERT INTO `Ad_Api` VALUES ('b03964e8-3bb7-4399-8a2e-4fecc0f3c8db', '60c18863-7bf7-4419-abdc-65a4ea69cc92', NULL, '批量删除数据字典类型', '/api/admin/dictionarytype/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:03.277234', NULL, NULL, '2021-10-01 10:52:03.277245');
INSERT INTO `Ad_Api` VALUES ('b11bcb9d-7651-422a-8225-dd70bf8d0382', '71e74ada-8891-4971-b512-01a8f66b7dfb', NULL, '查询用户信息', '/api/admin/auth/getuserinfo', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.610869', NULL, NULL, '2021-10-01 10:51:59.610893');
INSERT INTO `Ad_Api` VALUES ('b13ad071-d755-4ac1-ad71-4d698fb6f90a', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '查询单条接口', '/api/admin/api/get', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.268913', NULL, NULL, '2021-10-01 10:51:59.268938');
INSERT INTO `Ad_Api` VALUES ('b21c4f99-f88e-4c1b-947a-ab86e538ea9f', '00000000-0000-0000-0000-000000000000', NULL, '文档管理', 'document', NULL, '', 0, 1, 0, '2021-10-01 10:52:01.720854', NULL, NULL, '2021-10-01 10:52:01.720865');
INSERT INTO `Ad_Api` VALUES ('b4119693-01d8-4746-bee3-0da5043a9b4d', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '新增租户', '/api/admin/tenant/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.293903', NULL, NULL, '2021-10-01 10:52:02.293913');
INSERT INTO `Ad_Api` VALUES ('babb93f4-36b5-4465-9077-a2e5ef002f6c', '00000000-0000-0000-0000-000000000000', NULL, '角色管理', 'role', NULL, '', 0, 1, 0, '2021-10-01 10:52:00.621087', NULL, NULL, '2021-10-01 10:52:00.621115');
INSERT INTO `Ad_Api` VALUES ('bd0cd1e8-0b19-429f-8208-80ac08c0629a', '97d13342-a183-48c9-9aad-d768f1d7bb4f', NULL, '查询分页数据字典', '/api/admin/dictionary/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:51:59.772636', NULL, NULL, '2022-01-08 22:16:48.400676');
INSERT INTO `Ad_Api` VALUES ('bf27d5d0-5931-4688-a11c-92e985d8d60e', 'd43f7937-8e12-4ebc-9d44-41102025a16d', NULL, '删除接口', '/api/admin/api/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:51:59.419484', NULL, NULL, '2021-10-01 10:51:59.419508');
INSERT INTO `Ad_Api` VALUES ('bfb41958-5eeb-4560-94f3-0fa8ebda7711', '8c5d7505-cd2a-44ac-8eac-f5b95dce490d', NULL, '新增组织架构', '/api/personnel/organization/add', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.727797', NULL, NULL, '2021-10-01 10:52:02.727847');
INSERT INTO `Ad_Api` VALUES ('c392bcda-4b9a-4c96-87f7-9fec23de74e2', '00000000-0000-0000-0000-000000000000', NULL, '视图管理', 'view', NULL, '', 0, 1, 0, '2021-10-01 10:52:01.205132', NULL, NULL, '2021-10-01 10:52:01.205143');
INSERT INTO `Ad_Api` VALUES ('c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', '00000000-0000-0000-0000-000000000000', NULL, '权限管理', 'permission', NULL, '', 0, 1, 0, '2021-10-01 10:51:59.921362', NULL, NULL, '2021-10-01 10:51:59.921375');
INSERT INTO `Ad_Api` VALUES ('c697fc88-8a35-4f34-a55c-87a8d8b5e319', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '新增菜单', '/api/admin/document/addmenu', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.899676', NULL, NULL, '2021-10-01 10:52:01.899695');
INSERT INTO `Ad_Api` VALUES ('c7545b9d-998e-4fcc-8fea-14b8e67f575a', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '查询用户基本信息', '/api/admin/user/getbasic', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.865822', NULL, NULL, '2021-10-01 10:52:00.865843');
INSERT INTO `Ad_Api` VALUES ('c75acab7-418a-4be5-a61c-0544469b3319', '8c5d7505-cd2a-44ac-8eac-f5b95dce490d', NULL, '修改组织架构', '/api/personnel/organization/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.761871', NULL, NULL, '2021-10-01 10:52:02.761882');
INSERT INTO `Ad_Api` VALUES ('c77b7c4f-005e-47f4-964f-d3bc596b8e3d', 'e5f8423f-5426-4050-b8c5-ef5fa0420eae', NULL, '删除员工', '/api/personnel/employee/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:02.596169', NULL, NULL, '2021-10-01 10:52:02.596179');
INSERT INTO `Ad_Api` VALUES ('c8536738-4cb6-4469-ab1e-1a98bd4dd35f', '8c5d7505-cd2a-44ac-8eac-f5b95dce490d', NULL, '删除组织架构', '/api/personnel/organization/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:02.791031', NULL, NULL, '2021-10-01 10:52:02.791042');
INSERT INTO `Ad_Api` VALUES ('c856c25f-5ca0-4be9-a36f-aeda33c38a6f', '872661d8-3c40-433e-9508-d7fcb68291ce', NULL, '查询分页职位', '/api/personnel/position/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:02.923683', NULL, NULL, '2022-01-08 22:16:48.400695');
INSERT INTO `Ad_Api` VALUES ('c9a0da34-f852-4f1c-8bd3-403f9e352d48', 'd3c87b82-1eba-4fe9-9485-7c8dd295bf6b', NULL, '清除缓存', '/api/admin/cache/clear', 'delete', '', 0, 1, 0, '2021-10-01 10:52:01.556714', NULL, NULL, '2021-10-01 10:52:01.556752');
INSERT INTO `Ad_Api` VALUES ('ca2d9ffb-352c-4ebb-bc4f-2ce647c48267', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '删除文档', '/api/admin/document/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:02.007346', NULL, NULL, '2021-10-01 10:52:02.007370');
INSERT INTO `Ad_Api` VALUES ('cbb16bef-825f-4401-be19-7808ff401847', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '查询角色权限', '/api/admin/permission/getrolepermissionlist', 'get', '', 0, 1, 0, '2021-10-01 10:52:00.115744', NULL, NULL, '2021-10-01 10:52:00.115767');
INSERT INTO `Ad_Api` VALUES ('cc98d127-555d-46ae-94b0-5bc2e93e99bf', 'babb93f4-36b5-4465-9077-a2e5ef002f6c', NULL, '修改角色', '/api/admin/role/update', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.741350', NULL, NULL, '2021-10-01 10:52:00.741364');
INSERT INTO `Ad_Api` VALUES ('cd1b0ef3-0126-4af4-91c4-711942c27866', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '彻底删除租户', '/api/admin/tenant/delete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:02.416803', NULL, NULL, '2021-10-01 10:52:02.416813');
INSERT INTO `Ad_Api` VALUES ('cddddc6e-d709-4032-a6a9-101b6740c9bd', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '查询单条文档内容', '/api/admin/document/getcontent', 'get', '', 0, 1, 0, '2021-10-01 10:52:02.039615', NULL, NULL, '2021-10-01 10:52:02.039625');
INSERT INTO `Ad_Api` VALUES ('cfed5368-63bf-47d0-a7d2-ddd72835c35b', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '保存租户权限', '/api/admin/permission/savetenantpermissions', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.559247', NULL, NULL, '2021-10-01 10:52:00.559264');
INSERT INTO `Ad_Api` VALUES ('d32ff286-eb19-4201-ab9c-a66c8ee4aea5', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '查询文档列表', '/api/admin/document/getlist', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.751851', NULL, NULL, '2021-10-01 10:52:01.751862');
INSERT INTO `Ad_Api` VALUES ('d365470b-a235-46ac-adff-82b345c31236', '71e74ada-8891-4971-b512-01a8f66b7dfb', NULL, '用户登录', '/api/admin/auth/login', 'post', '根据登录信息生成Token', 0, 1, 0, '2021-10-01 10:51:59.646769', NULL, NULL, '2021-10-01 10:51:59.646790');
INSERT INTO `Ad_Api` VALUES ('d3c87b82-1eba-4fe9-9485-7c8dd295bf6b', '00000000-0000-0000-0000-000000000000', NULL, '缓存管理', 'cache', NULL, '', 0, 1, 0, '2021-10-01 10:52:01.495030', NULL, NULL, '2021-10-01 10:52:01.495051');
INSERT INTO `Ad_Api` VALUES ('d3e4bda3-1b1e-4616-ba8a-b1b9a98a4eb0', '872661d8-3c40-433e-9508-d7fcb68291ce', NULL, '批量删除职位', '/api/personnel/position/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:03.051494', NULL, NULL, '2021-10-01 10:52:03.051505');
INSERT INTO `Ad_Api` VALUES ('d3fe2cd2-da05-4638-bc47-554841f9f481', '71e74ada-8891-4971-b512-01a8f66b7dfb', NULL, '获取验证码', '/api/admin/auth/getverifycode', 'get', '', 0, 1, 0, '2021-10-01 10:51:59.548981', NULL, NULL, '2021-10-01 10:51:59.549007');
INSERT INTO `Ad_Api` VALUES ('d43f7937-8e12-4ebc-9d44-41102025a16d', '00000000-0000-0000-0000-000000000000', NULL, '接口管理', 'api', NULL, '', 0, 1, 0, '2021-10-01 10:51:59.184826', NULL, NULL, '2021-10-01 10:51:59.186592');
INSERT INTO `Ad_Api` VALUES ('d4dee739-3d12-4d97-b573-90bd6de26a11', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '查询下拉数据', '/api/admin/user/getselect', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.173989', NULL, NULL, '2021-10-01 10:52:01.173999');
INSERT INTO `Ad_Api` VALUES ('d7f7b699-4e11-44be-98b2-59ccee1f4c27', 'dbee7ef3-3951-48c4-be25-44022e31b952', NULL, '批量删除租户', '/api/admin/tenant/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.385152', NULL, NULL, '2021-10-01 10:52:02.385166');
INSERT INTO `Ad_Api` VALUES ('d8570c9d-a664-421a-8009-a772d3825cce', '91e5090e-2387-4043-aaf4-79312e54a44b', NULL, '查询分页登录日志', '/api/admin/loginlog/getpagelistlist', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.624733', NULL, NULL, '2022-01-08 22:16:48.400715');
INSERT INTO `Ad_Api` VALUES ('dbee7ef3-3951-48c4-be25-44022e31b952', '00000000-0000-0000-0000-000000000000', NULL, '租户管理', 'tenant', NULL, '', 0, 1, 0, '2021-10-01 10:52:02.201610', NULL, NULL, '2021-10-01 10:52:02.201621');
INSERT INTO `Ad_Api` VALUES ('dda1e605-ecf7-4ac9-bfe1-c6342a59b02f', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '修改接口', '/api/admin/permission/updateapi', 'put', '', 0, 1, 0, '2021-10-01 10:52:00.300441', NULL, NULL, '2021-10-01 10:52:00.300452');
INSERT INTO `Ad_Api` VALUES ('df32cec7-1fe1-4615-aaa3-46094c61c9a0', '00000000-0000-0000-0000-000000000000', NULL, '管理员管理', 'user', NULL, '', 0, 1, 0, '2021-10-01 10:52:00.832423', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:09:28.108409');
INSERT INTO `Ad_Api` VALUES ('e00cb111-3e60-410c-a29b-1dc268d9cf6b', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '上传头像', '/api/admin/user/avatarupload', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.143932', NULL, NULL, '2021-10-01 10:52:01.143944');
INSERT INTO `Ad_Api` VALUES ('e154676c-fe94-4181-ac97-520338c018ab', 'c5cfb50e-55cb-4f58-b4dd-20e466b41fdb', NULL, '新增接口', '/api/admin/permission/addapi', 'post', '', 0, 1, 0, '2021-10-01 10:52:00.211159', NULL, NULL, '2021-10-01 10:52:00.211170');
INSERT INTO `Ad_Api` VALUES ('e48ad490-8b29-497a-a2b6-202d78dbc269', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '新增分组', '/api/admin/document/addgroup', 'post', '', 0, 1, 0, '2021-10-01 10:52:01.870932', NULL, NULL, '2021-10-01 10:52:01.870944');
INSERT INTO `Ad_Api` VALUES ('e4e476de-a2a5-47b9-9b24-973affde9df7', 'df32cec7-1fe1-4615-aaa3-46094c61c9a0', NULL, '删除用户', '/api/admin/user/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:52:01.022088', NULL, NULL, '2021-10-01 10:52:01.022100');
INSERT INTO `Ad_Api` VALUES ('e5f8423f-5426-4050-b8c5-ef5fa0420eae', '00000000-0000-0000-0000-000000000000', NULL, '员工管理', 'employee', NULL, '', 0, 1, 0, '2021-10-01 10:52:02.446627', NULL, NULL, '2021-10-01 10:52:02.446641');
INSERT INTO `Ad_Api` VALUES ('e778f118-a923-4f81-a685-e191fcec5fca', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '修改文档内容', '/api/admin/document/updatecontent', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.076486', NULL, NULL, '2021-10-01 10:52:02.076502');
INSERT INTO `Ad_Api` VALUES ('e7fd7121-2e9b-45ee-ac83-3a8ea099d051', 'e5f8423f-5426-4050-b8c5-ef5fa0420eae', NULL, '批量删除员工', '/api/personnel/employee/batchsoftdelete', 'put', '', 0, 1, 0, '2021-10-01 10:52:02.636986', NULL, NULL, '2021-10-01 10:52:02.636997');
INSERT INTO `Ad_Api` VALUES ('ecad4e11-9441-4c68-93ea-419c00afe06a', '97d13342-a183-48c9-9aad-d768f1d7bb4f', NULL, '删除数据字典', '/api/admin/dictionary/softdelete', 'delete', '', 0, 1, 0, '2021-10-01 10:51:59.862491', NULL, NULL, '2021-10-01 10:51:59.862507');
INSERT INTO `Ad_Api` VALUES ('fba9235f-a8b8-4181-a845-989e748b06ba', 'b21c4f99-f88e-4c1b-947a-ab86e538ea9f', NULL, '查询单条分组', '/api/admin/document/getgroup', 'get', '', 0, 1, 0, '2021-10-01 10:52:01.782240', NULL, NULL, '2021-10-01 10:52:01.782263');

-- ----------------------------
-- Table structure for Ad_Dictionary
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Dictionary`;
CREATE TABLE `Ad_Dictionary`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `DictionaryTypeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '字典类型Id',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '文章标题',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '字典编码',
  `Value` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '字典值',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Sort` int NOT NULL COMMENT '排序',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_Code`(`Code`) USING BTREE,
  INDEX `IDX_DictionaryTypeId`(`DictionaryTypeId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '数据字典' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Dictionary
-- ----------------------------

-- ----------------------------
-- Table structure for Ad_Dictionary_Type
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Dictionary_Type`;
CREATE TABLE `Ad_Dictionary_Type`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '文章标题',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '编码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Sort` int NOT NULL COMMENT '排序',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_Code1`(`Code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '数据字典类型' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Dictionary_Type
-- ----------------------------

-- ----------------------------
-- Table structure for Ad_Document
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Document`;
CREATE TABLE `Ad_Document`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '父级节点',
  `Label` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `Type` int NOT NULL COMMENT '类型',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '命名',
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '内容',
  `Html` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT 'Html',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Opened` tinyint(1) NULL DEFAULT NULL COMMENT '打开组',
  `Sort` int NOT NULL DEFAULT 0 COMMENT '排序',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_ParentId1`(`ParentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '文档表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Document
-- ----------------------------

-- ----------------------------
-- Table structure for Ad_Document_Image
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Document_Image`;
CREATE TABLE `Ad_Document_Image`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `DocumentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '文档Id',
  `Url` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '文档Id',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_DocumentId`(`DocumentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '文档图片表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Document_Image
-- ----------------------------

-- ----------------------------
-- Table structure for Ad_Login_Log
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Login_Log`;
CREATE TABLE `Ad_Login_Log`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `NickName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '昵称',
  `IP` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT 'IP',
  `Browser` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '浏览器',
  `Os` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作系统',
  `Device` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '设备',
  `BrowserInfo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '浏览器信息',
  `ElapsedMilliseconds` bigint NOT NULL COMMENT '耗时（毫秒）',
  `Status` tinyint(1) NOT NULL COMMENT '操作状态',
  `Msg` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作消息',
  `Result` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '操作结果',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '登录日志表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Login_Log
-- ----------------------------
INSERT INTO `Ad_Login_Log` VALUES ('3a01519e-75ad-4a12-1543-dc1857685ba0', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 2039, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-09 23:25:17.650482', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a015685-f1f9-4b9a-39c9-9a7bfe01f70a', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 2087, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 22:16:37.157441', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a015697-1a29-0176-0a89-64b223e8f82b', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 238, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 22:35:21.513496', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a0156a4-e3d8-84dd-d97f-93698c1897b0', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 280, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 22:50:25.132952', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a0156b5-3bf6-79d0-a2a9-194bb8757191', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 240, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:08:16.247069', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a0156b6-f730-6846-0bf8-27d26ee6bf2d', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 269, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:10:09.712455', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a015b7a-4fac-751d-5c2e-b5955aa78299', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 2740, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-11 13:22:00.820297', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a015beb-82ac-7086-c2b7-a17c4e8e3587', '段晨曦', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 281, 1, '操作成功', NULL, 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:25:39.391860', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a015bef-436b-b9d7-32d5-a093c1c95946', '段段', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 231, 1, '操作成功', NULL, 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:29:45.323524', NULL, NULL, NULL);
INSERT INTO `Ad_Login_Log` VALUES ('3a015bef-71b7-a63f-0e4e-88075f27b622', '平台用户', '127.0.0.1', 'Chrome', 'Windows', '', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36', 232, 1, '操作成功', NULL, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-11 23:29:57.175706', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for Ad_LowCodeTable
-- ----------------------------
DROP TABLE IF EXISTS `Ad_LowCodeTable`;
CREATE TABLE `Ad_LowCodeTable`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `LowCodeTableName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '表名',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `FunctionModule` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所属功能模块（业务场景）',
  `MenuParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '所属节点（菜单父级Id）',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `MenuName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '菜单名称',
  `Taxon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '代码类名',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '低代码表格' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_LowCodeTable
-- ----------------------------
INSERT INTO `Ad_LowCodeTable` VALUES ('3a0156b5-b124-4fea-7a3b-1998a87bb0b7', 'Ad_ApiEntity', 'Api', 'Api', '00000000-0000-0000-0000-000000000000', 0, '2022-01-10 23:08:46.255732', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', 'Api', 'Api');

-- ----------------------------
-- Table structure for Ad_LowCodeTableConfig
-- ----------------------------
DROP TABLE IF EXISTS `Ad_LowCodeTableConfig`;
CREATE TABLE `Ad_LowCodeTableConfig`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `LowCodeTableId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'LowCodeTableId,父Id',
  `IsNullable` tinyint(1) NOT NULL COMMENT '是否为可空类型',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `QueryType` int NOT NULL DEFAULT 0 COMMENT '查询方式',
  `IsWebAdd` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否需要前端添加',
  `IsWebSelect` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否需要前端查询',
  `IsWebUpdate` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否需要前端修改',
  `InputType` int NOT NULL DEFAULT 0 COMMENT '输入类型',
  `ColumnName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '字段名',
  `IsWebShow` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否需要前端显示',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_LowCodeTableId`(`LowCodeTableId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '低代码表格配置' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_LowCodeTableConfig
-- ----------------------------

-- ----------------------------
-- Table structure for Ad_Permission
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Permission`;
CREATE TABLE `Ad_Permission`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '父级节点',
  `Label` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '权限名称',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '权限编码',
  `Type` int NOT NULL COMMENT '权限类型',
  `ViewId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '视图',
  `Path` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '菜单访问地址',
  `Icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '图标',
  `Hidden` tinyint(1) NOT NULL COMMENT '隐藏',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Closable` tinyint(1) NOT NULL DEFAULT 0 COMMENT '可关闭',
  `Opened` tinyint(1) NOT NULL DEFAULT 0 COMMENT '打开组',
  `NewWindow` tinyint(1) NOT NULL DEFAULT 0 COMMENT '打开新窗口',
  `External` tinyint(1) NOT NULL DEFAULT 0 COMMENT '链接外显',
  `Sort` int NOT NULL DEFAULT 0 COMMENT '排序',
  `Description` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_ParentId2`(`ParentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '权限表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Permission
-- ----------------------------
INSERT INTO `Ad_Permission` VALUES ('001e7b5b-dfe7-48fc-9ffe-9bbd627acef4', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '查询', 'api:admin:tenant:getpage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.199312', NULL, NULL, '2021-10-01 11:17:27.199325');
INSERT INTO `Ad_Permission` VALUES ('03258db8-67e1-4b72-a85e-bf142dacf043', 'dea906df-7bc1-4995-ad65-6d46b29cec37', '查询', 'api:personnel:employee:getpage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.664765', NULL, NULL, '2021-10-01 11:17:28.664775');
INSERT INTO `Ad_Permission` VALUES ('04cb1793-0bd8-4d75-8c06-288194ddb8e1', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', '更新日志', NULL, 2, '7fe57892-2f9e-4a6a-843e-7b048241abfc', '/', 'el-icon-notebook-2', 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:25.579146', NULL, NULL, '2021-10-01 11:17:25.579166');
INSERT INTO `Ad_Permission` VALUES ('0c0e1df7-3782-473b-a324-468e9fd83b98', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '新增菜单', 'api:admin:document:addmenu', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 6, NULL, 0, '2021-10-01 11:17:27.963556', NULL, NULL, '2021-10-01 11:17:27.963564');
INSERT INTO `Ad_Permission` VALUES ('0c46425c-a46f-4088-9c72-94b58ae62ca3', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '上传图片', 'api:admin:document:uploadimage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 14, NULL, 0, '2021-10-01 11:17:28.158801', NULL, NULL, '2021-10-01 11:17:28.158811');
INSERT INTO `Ad_Permission` VALUES ('1784e0c4-4d49-4b20-ba4d-f65009403e15', '841af2f7-b4ef-44ca-a1ba-81908c29a113', '修改', 'api:personnel:position:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.377840', NULL, NULL, '2021-10-01 11:17:28.377848');
INSERT INTO `Ad_Permission` VALUES ('1a65682d-8fa8-4557-81ab-25224889a154', '90244a22-cfa3-44de-ae65-c3124a35c6bf', '批量删除', 'api:admin:role:batchsoftdelete', 3, NULL, ' ', '', 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:26.028229', NULL, NULL, '2021-10-01 11:17:26.028239');
INSERT INTO `Ad_Permission` VALUES ('1ca033c8-2570-451a-93c4-6b94220a44a0', '841af2f7-b4ef-44ca-a1ba-81908c29a113', '查询', 'api:personnel:position:getpage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.312448', NULL, NULL, '2021-10-01 11:17:28.312456');
INSERT INTO `Ad_Permission` VALUES ('1d4ecde9-082c-40fd-84cd-8bf87626a747', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '新增接口', 'api:admin:permission:addapi', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:26.731190', NULL, NULL, '2021-10-01 11:17:26.731198');
INSERT INTO `Ad_Permission` VALUES ('1f18ab4d-dd40-4aa4-9528-ae8a7e1bb65a', '90244a22-cfa3-44de-ae65-c3124a35c6bf', '修改', 'api:admin:role:update', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:25.958113', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 22:47:40.442882');
INSERT INTO `Ad_Permission` VALUES ('20b40852-60e9-4862-8069-bb44ceaf859c', '00000000-0000-0000-0000-000000000000', '个人管理', NULL, 1, NULL, '', 'el-icon-s-custom', 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:25.351589', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:40:36.978162');
INSERT INTO `Ad_Permission` VALUES ('26210b10-be46-44b6-9d1d-9e8eb1343174', 'ee8af740-7253-401a-b811-fd62a85620a9', '查询', 'api:admin:cache:list', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.104451', NULL, NULL, '2021-10-01 11:17:27.104460');
INSERT INTO `Ad_Permission` VALUES ('268b006b-80b9-4bed-89b9-230e55536790', 'a315efd7-1968-4d6a-b0e7-fd546470557f', '部门管理', NULL, 2, '68cba127-8932-4c0e-b5d5-f6e18c877c8b', '/personnel/organization', '', 0, 1, 1, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.471640', NULL, NULL, '2021-10-01 11:17:28.471651');
INSERT INTO `Ad_Permission` VALUES ('296469a4-2793-484f-8bc8-a5287ab1efe1', 'b1784be9-9646-4c1a-92ca-5f059916333e', '数据字典', NULL, 2, 'a541e567-8852-4101-9569-26e459abcbb5', '/admin/dictionary/index', '', 0, 1, 1, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:27.449481', NULL, NULL, '2021-10-01 11:17:27.449490');
INSERT INTO `Ad_Permission` VALUES ('29fd319a-b73e-406c-a646-78be18c8da62', '841af2f7-b4ef-44ca-a1ba-81908c29a113', '新增', 'api:personnel:position:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.347785', NULL, NULL, '2021-10-01 11:17:28.347793');
INSERT INTO `Ad_Permission` VALUES ('2f35c37a-3eeb-49e2-811b-025eba5dc2b7', '8461d2ca-db06-4d93-808b-9246641869a1', '同步', 'api:admin:view:sync', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 6, NULL, 0, '2021-10-01 11:17:26.502785', NULL, NULL, '2021-10-01 11:17:26.502816');
INSERT INTO `Ad_Permission` VALUES ('31ebfd6b-8cab-4850-baf7-7f778264e03a', 'f3026862-6fd7-4fae-bda4-eafced533d03', '操作日志', NULL, 2, 'cde4e051-58cc-4e59-81cc-5a269821c2bc', '/admin/opration-log', '', 0, 1, 1, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:27.740384', NULL, NULL, '2021-10-01 11:17:27.740392');
INSERT INTO `Ad_Permission` VALUES ('33580d92-7f92-4b5f-a3f2-84f5750895eb', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '查询图片', 'api:admin:document:getimagelist', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 12, NULL, 0, '2021-10-01 11:17:28.191694', NULL, NULL, '2021-10-01 11:17:28.191719');
INSERT INTO `Ad_Permission` VALUES ('359e254e-1c03-471a-9f77-67f01d6f3de2', '69afce87-c278-4f26-97ad-09588dd94757', '查询', 'api:admin:api:getlist', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:26.091089', NULL, NULL, '2021-10-01 11:17:26.091137');
INSERT INTO `Ad_Permission` VALUES ('39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 'dea906df-7bc1-4995-ad65-6d46b29cec37', '删除', 'api:personnel:employee:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.754723', NULL, NULL, '2021-10-01 11:17:28.754732');
INSERT INTO `Ad_Permission` VALUES ('3a0156b2-4356-2635-bb52-2d0a6f30afbe', 'b1784be9-9646-4c1a-92ca-5f059916333e', '低代码管理', NULL, 2, '3a0156a5-ca71-7681-9482-6223fc23882a', '/admin/low-code/index', '', 0, 1, 1, 0, 0, 0, 0, '', 0, '2022-01-10 23:05:01.671192', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_Permission` VALUES ('3a0156b3-68df-63a9-a473-2e03b046653a', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', '添加', 'api:admin:low-code-table:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, '', 0, '2022-01-10 23:06:16.794729', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_Permission` VALUES ('3a0156b4-367c-0eec-9545-b882b323fba7', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', '修改', 'api:admin:low-code-table:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, '', 0, '2022-01-10 23:07:09.431957', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_Permission` VALUES ('3a0156b4-6fbc-5aa3-fea1-538fcf3b198c', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', '删除', 'api:admin:low-code-table:delete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, '', 0, '2022-01-10 23:07:24.088905', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_Permission` VALUES ('3a0156b4-acf4-f9e9-67e5-097019a5ac6f', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', '生成代码', 'api:admin:low-code-table:generate', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, '', 0, '2022-01-10 23:07:39.760373', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 23:10:39.326209');
INSERT INTO `Ad_Permission` VALUES ('3a0156b4-e876-773a-f543-8a3e7cd08988', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', '查询列表', 'api:admin:low-code-table:get-page-list', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, '', 0, '2022-01-10 23:07:54.994865', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_Permission` VALUES ('4175b221-53d4-44d2-9d5a-a450d8b66625', '69afce87-c278-4f26-97ad-09588dd94757', '新增', 'api:admin:api:add', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:26.123640', NULL, NULL, '2021-10-01 11:17:26.140789');
INSERT INTO `Ad_Permission` VALUES ('451f1861-f4d2-4133-ae08-e0270055ff95', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '新增分组', 'api:admin:permission:addgroup', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:26.662079', NULL, NULL, '2021-10-01 11:17:26.662089');
INSERT INTO `Ad_Permission` VALUES ('45843eed-89e0-4298-b26b-ab379e4dac0a', '31ebfd6b-8cab-4850-baf7-7f778264e03a', '查询', 'api:admin:oprationlog:getpage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.773829', NULL, NULL, '2021-10-01 11:17:27.773837');
INSERT INTO `Ad_Permission` VALUES ('4b78adeb-7446-4c17-a6c1-479c12574e68', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', '权限管理', NULL, 1, NULL, '', 'fa fa-sitemap', 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:25.609748', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:41:34.794571');
INSERT INTO `Ad_Permission` VALUES ('4c002c85-569e-4677-9c3a-d8cc1cc0579c', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '修改', 'api:admin:tenant:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:27.258017', NULL, NULL, '2021-10-01 11:17:27.258026');
INSERT INTO `Ad_Permission` VALUES ('4cadb843-aa60-4370-a6a8-78a1ae56c545', '268b006b-80b9-4bed-89b9-230e55536790', '新增', 'api:personnel:organization:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.538024', NULL, NULL, '2021-10-01 11:17:28.538032');
INSERT INTO `Ad_Permission` VALUES ('50ab2705-1b52-458a-9091-29610fcc8b50', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '批量删除', 'api:admin:tenant:batchsoftdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:27.321108', NULL, NULL, '2021-10-01 11:17:27.321117');
INSERT INTO `Ad_Permission` VALUES ('56fd5d2d-fcda-4961-88a6-10b46c08ea53', 'dea906df-7bc1-4995-ad65-6d46b29cec37', '修改', 'api:personnel:employee:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.724852', NULL, NULL, '2021-10-01 11:17:28.724861');
INSERT INTO `Ad_Permission` VALUES ('5d161428-85aa-4964-9f22-2884814b9df4', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '修改菜单', 'api:admin:permission:updatemenu', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 6, NULL, 0, '2021-10-01 11:17:26.790838', NULL, NULL, '2021-10-01 11:17:26.790848');
INSERT INTO `Ad_Permission` VALUES ('5e4a9cb4-ca3c-452c-8b66-0af587d79934', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '删除图片', 'api:admin:document:deleteimage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 13, NULL, 0, '2021-10-01 11:17:28.220969', NULL, NULL, '2021-10-01 11:17:28.220981');
INSERT INTO `Ad_Permission` VALUES ('5f00b624-8eee-4185-b63b-f71c488e49a0', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '新增分组', 'api:admin:document:addgroup', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:27.933356', NULL, NULL, '2021-10-01 11:17:27.933364');
INSERT INTO `Ad_Permission` VALUES ('5fb50010-de89-421b-b4ae-cc436bf6c6df', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '新增权限点', 'api:admin:permission:adddot', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:26.887538', NULL, NULL, '2021-10-01 11:17:26.887549');
INSERT INTO `Ad_Permission` VALUES ('6102e52c-e75f-4622-8757-6fb3fe69f5bb', '4b78adeb-7446-4c17-a6c1-479c12574e68', '角色权限', NULL, 2, 'ac23e6c0-6794-4e48-9888-f851f0482476', '/admin/role-permisson', NULL, 0, 1, 1, 0, 0, 0, 6, NULL, 0, '2021-10-01 11:17:26.980778', NULL, NULL, '2021-10-01 11:17:26.980790');
INSERT INTO `Ad_Permission` VALUES ('632edcd7-adf1-46c6-924b-80dfa6afbee7', '4b78adeb-7446-4c17-a6c1-479c12574e68', '租户管理', NULL, 2, '493a978a-ef3b-40b9-ad9b-c2e6421f6156', '/admin/tenant', '', 0, 1, 1, 0, 0, 0, 8, NULL, 0, '2021-10-01 11:17:27.168981', NULL, NULL, '2021-10-01 11:17:27.168991');
INSERT INTO `Ad_Permission` VALUES ('69afce87-c278-4f26-97ad-09588dd94757', '4b78adeb-7446-4c17-a6c1-479c12574e68', '接口管理', NULL, 2, 'eae826a2-dc69-4671-a8d4-c78c18396378', '/admin/api', NULL, 0, 1, 1, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:26.060045', NULL, NULL, '2021-10-01 11:17:26.060054');
INSERT INTO `Ad_Permission` VALUES ('6af2f3c1-03a3-4011-aaab-3c79613874e5', '4b78adeb-7446-4c17-a6c1-479c12574e68', '用户管理', NULL, 2, '87a486b9-960c-4aea-b1c6-8ddb039028e1', '/admin/user', NULL, 0, 1, 1, 0, 0, 1, 1, NULL, 0, '2021-10-01 11:17:25.645359', NULL, NULL, '2021-10-01 11:17:25.645377');
INSERT INTO `Ad_Permission` VALUES ('6b4d15e3-96d0-45b8-924c-8630bba431b7', '8461d2ca-db06-4d93-808b-9246641869a1', '批量删除', 'api:admin:view:batchsoftdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:26.468438', NULL, NULL, '2021-10-01 11:17:26.468447');
INSERT INTO `Ad_Permission` VALUES ('6bb9562d-0203-48b2-b959-3419fb043892', '6af2f3c1-03a3-4011-aaab-3c79613874e5', '批量删除', 'api:admin:user:batchsoftdelete', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:25.814589', NULL, NULL, '2021-10-01 11:17:25.814635');
INSERT INTO `Ad_Permission` VALUES ('6d75765e-8ab8-44dd-a0f3-018bacee0803', 'e8b3762f-2540-40e0-8160-62e388b06af1', '文档管理', NULL, 2, 'eec2cbc9-23ee-47cf-a7e9-b3a69b14b897', '/admin/document', 'el-icon-notebook-2', 0, 1, 1, 0, 0, 1, 0, NULL, 0, '2021-10-01 11:17:27.900748', NULL, NULL, '2021-10-01 11:17:27.900756');
INSERT INTO `Ad_Permission` VALUES ('72912d72-56cc-46ab-9f0b-54c0fc8861c9', '8461d2ca-db06-4d93-808b-9246641869a1', '删除', 'api:admin:view:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:26.433404', NULL, NULL, '2021-10-01 11:17:26.433427');
INSERT INTO `Ad_Permission` VALUES ('7c956386-d014-4721-b9d0-b3cdf9b41bc1', '6102e52c-e75f-4622-8757-6fb3fe69f5bb', '保存', 'api:admin:permission:assign', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:27.042680', NULL, NULL, '2021-10-01 11:17:27.042688');
INSERT INTO `Ad_Permission` VALUES ('7d4533f9-e1c5-429e-83bb-1a062656d1eb', 'ee8af740-7253-401a-b811-fd62a85620a9', '清除缓存', 'api:admin:cache:clear', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:27.134755', NULL, NULL, '2021-10-01 11:17:27.134763');
INSERT INTO `Ad_Permission` VALUES ('7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', '6af2f3c1-03a3-4011-aaab-3c79613874e5', '修改', 'api:admin:user:update', 3, NULL, '', NULL, 0, 1, 1, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:25.750737', NULL, NULL, '2021-10-01 11:17:25.750755');
INSERT INTO `Ad_Permission` VALUES ('7dc79249-4232-4d8c-a181-d9a7d2c2e805', '6af2f3c1-03a3-4011-aaab-3c79613874e5', '新增', 'api:admin:user:add', 3, NULL, '', NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:25.717239', NULL, NULL, '2021-10-01 11:17:25.717254');
INSERT INTO `Ad_Permission` VALUES ('7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', '296469a4-2793-484f-8bc8-a5287ab1efe1', '批量删除', 'api:admin:dictionary:batchsoftdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:27.583924', NULL, NULL, '2021-10-01 11:17:27.583937');
INSERT INTO `Ad_Permission` VALUES ('805dbab1-769c-4fce-a626-36c6abd6b219', '268b006b-80b9-4bed-89b9-230e55536790', '删除', 'api:personnel:organization:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.597080', NULL, NULL, '2021-10-01 11:17:28.597089');
INSERT INTO `Ad_Permission` VALUES ('83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '删除文档', 'api:admin:document:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 9, NULL, 0, '2021-10-01 11:17:28.062276', NULL, NULL, '2021-10-01 11:17:28.062298');
INSERT INTO `Ad_Permission` VALUES ('841af2f7-b4ef-44ca-a1ba-81908c29a113', 'a315efd7-1968-4d6a-b0e7-fd546470557f', '岗位管理', NULL, 2, '7f267227-fb2c-420b-8928-d8862fc9f098', '/personnel/position', '', 0, 1, 1, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.282422', NULL, NULL, '2021-10-01 11:17:28.282431');
INSERT INTO `Ad_Permission` VALUES ('8461d2ca-db06-4d93-808b-9246641869a1', '4b78adeb-7446-4c17-a6c1-479c12574e68', '视图管理', NULL, 2, 'e1f0ff14-ab77-425a-962e-74fdcfea5e18', '/admin/view', '', 0, 1, 1, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:26.293384', NULL, NULL, '2021-10-01 11:17:26.293394');
INSERT INTO `Ad_Permission` VALUES ('85d93df9-c52f-4dd0-91fa-8d38552618c4', '4b78adeb-7446-4c17-a6c1-479c12574e68', '权限管理', NULL, 2, '70ae8835-4841-40ac-9e9f-56a2eb4d6bcc', '/admin/permission', NULL, 0, 1, 1, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:26.532558', NULL, NULL, '2021-10-01 11:17:26.532567');
INSERT INTO `Ad_Permission` VALUES ('883d5091-9e35-43b5-aa48-fac931edaa78', '6af2f3c1-03a3-4011-aaab-3c79613874e5', '删除', 'api:admin:user:softdelete', 3, NULL, '', NULL, 0, 1, 1, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:25.780931', NULL, NULL, '2021-10-01 11:17:25.780950');
INSERT INTO `Ad_Permission` VALUES ('888eab40-58d6-487f-b3ba-b29c6b395561', '841af2f7-b4ef-44ca-a1ba-81908c29a113', '删除', 'api:personnel:position:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.408069', NULL, NULL, '2021-10-01 11:17:28.408077');
INSERT INTO `Ad_Permission` VALUES ('894bb503-3111-47c7-8593-b9089f51c704', '296469a4-2793-484f-8bc8-a5287ab1efe1', '修改', 'api:admin:dictionary:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:27.513392', NULL, NULL, '2021-10-01 11:17:27.513401');
INSERT INTO `Ad_Permission` VALUES ('894e7dac-f116-4054-bb31-45a55bd479ac', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', '查询基本信息', 'api:admin:user:getbasic', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:25.453830', NULL, NULL, '2021-10-01 11:17:25.453845');
INSERT INTO `Ad_Permission` VALUES ('8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', '20b40852-60e9-4862-8069-bb44ceaf859c', '个人设置', NULL, 2, '1a391e49-074a-4d65-b980-6564334bf609', '/account/settings', 'el-icon-setting', 0, 1, 1, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:25.423837', NULL, NULL, '2021-10-01 11:17:25.423858');
INSERT INTO `Ad_Permission` VALUES ('90244a22-cfa3-44de-ae65-c3124a35c6bf', '4b78adeb-7446-4c17-a6c1-479c12574e68', '角色管理', NULL, 2, '9082f57f-7c5a-4bcd-a356-bb92a1252d7e', '/admin/role', '', 0, 1, 1, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:25.852315', NULL, NULL, '2021-10-01 11:17:25.852334');
INSERT INTO `Ad_Permission` VALUES ('90ad8b53-75ce-470d-8e5d-8a507cb21832', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '删除', 'api:admin:permission:softdelete', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 8, NULL, 0, '2021-10-01 11:17:26.853090', NULL, NULL, '2021-10-01 11:17:26.853099');
INSERT INTO `Ad_Permission` VALUES ('913a485c-0770-4fa5-83c9-fa523e3c2815', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '删除', 'api:admin:tenant:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:27.291820', NULL, NULL, '2021-10-01 11:17:27.291828');
INSERT INTO `Ad_Permission` VALUES ('93c50be8-9d46-4a6d-84aa-29407b25cd05', '8461d2ca-db06-4d93-808b-9246641869a1', '修改', 'api:admin:view:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:26.402676', NULL, NULL, '2021-10-01 11:17:26.402684');
INSERT INTO `Ad_Permission` VALUES ('95da157a-52c3-40f3-b6a6-de70d99a793e', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '修改接口', 'api:admin:permission:updateapi', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 7, NULL, 0, '2021-10-01 11:17:26.820743', NULL, NULL, '2021-10-01 11:17:26.820752');
INSERT INTO `Ad_Permission` VALUES ('979f2b81-5d74-45d4-88df-ba3a57e13fca', '90244a22-cfa3-44de-ae65-c3124a35c6bf', '删除', 'api:admin:role:softdelete', 3, NULL, ' ', NULL, 0, 1, 1, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:25.991839', NULL, NULL, '2021-10-01 11:17:25.991857');
INSERT INTO `Ad_Permission` VALUES ('983cb8c2-994c-4642-b84a-bace084e4382', '6af2f3c1-03a3-4011-aaab-3c79613874e5', '查询', 'api:admin:user:getpage', 3, NULL, '', NULL, 0, 1, 1, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:25.680171', NULL, NULL, '2021-10-01 11:17:25.680190');
INSERT INTO `Ad_Permission` VALUES ('996dbc69-8e6b-42d2-b488-6f0c31f6fb8f', '69afce87-c278-4f26-97ad-09588dd94757', '批量删除', 'api:admin:api:batchsoftdelete', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:26.232800', NULL, NULL, '2021-10-01 11:17:26.232809');
INSERT INTO `Ad_Permission` VALUES ('99e98331-f83a-463e-9b37-23d1d428fb44', '69afce87-c278-4f26-97ad-09588dd94757', '同步', 'api:admin:api:sync', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 6, NULL, 0, '2021-10-01 11:17:26.261955', NULL, NULL, '2021-10-01 11:17:26.261964');
INSERT INTO `Ad_Permission` VALUES ('9a20843a-cb44-4d6d-a6bb-1a1cbc4cec15', '69afce87-c278-4f26-97ad-09588dd94757', '修改', 'api:admin:api:update', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:26.171303', NULL, NULL, '2021-10-01 11:17:26.171312');
INSERT INTO `Ad_Permission` VALUES ('9dacac88-a65d-42ef-8afa-c127377433f7', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '修改权限点', 'api:admin:permission:updatedot', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:26.920920', NULL, NULL, '2021-10-01 11:17:26.920929');
INSERT INTO `Ad_Permission` VALUES ('a315efd7-1968-4d6a-b0e7-fd546470557f', '00000000-0000-0000-0000-000000000000', '人事管理', NULL, 1, NULL, NULL, 'el-icon-user-solid', 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:28.251480', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:40:22.520031');
INSERT INTO `Ad_Permission` VALUES ('a5cec4b3-e414-4937-b339-4ceea83bdae2', '268b006b-80b9-4bed-89b9-230e55536790', '查询', 'api:personnel:organization:getlist', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.501814', NULL, NULL, '2021-10-01 11:17:28.501823');
INSERT INTO `Ad_Permission` VALUES ('a6ba585b-6a1d-4fd5-bae6-d87d875eb00b', '8461d2ca-db06-4d93-808b-9246641869a1', '查询', 'api:admin:view:getlist', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:26.322508', NULL, NULL, '2021-10-01 11:17:26.322517');
INSERT INTO `Ad_Permission` VALUES ('ac3e944c-46e4-41d6-b2bd-74b35b044bed', '69afce87-c278-4f26-97ad-09588dd94757', '删除', 'api:admin:api:softdelete', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:26.202439', NULL, NULL, '2021-10-01 11:17:26.202447');
INSERT INTO `Ad_Permission` VALUES ('b008bbfc-be32-4be4-af14-df8f6b39e72d', '268b006b-80b9-4bed-89b9-230e55536790', '修改', 'api:personnel:organization:update', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.567319', NULL, NULL, '2021-10-01 11:17:28.567329');
INSERT INTO `Ad_Permission` VALUES ('b1784be9-9646-4c1a-92ca-5f059916333e', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', '系统配置', NULL, 1, NULL, '', 'el-icon-s-platform', 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:27.418652', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:41:26.372185');
INSERT INTO `Ad_Permission` VALUES ('b2832de9-0b0a-485f-8c96-023d830f9a72', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '修改菜单', 'api:admin:document:updatemenu', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 8, NULL, 0, '2021-10-01 11:17:28.031006', NULL, NULL, '2021-10-01 11:17:28.031016');
INSERT INTO `Ad_Permission` VALUES ('b6704ad3-51d5-4b4e-b4b7-580f83197ad7', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '修改分组', 'api:admin:document:updategroup', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 7, NULL, 0, '2021-10-01 11:17:27.994112', NULL, NULL, '2021-10-01 11:17:27.994136');
INSERT INTO `Ad_Permission` VALUES ('b9a8c740-49d3-4dcb-8840-500ea0e21634', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '查询文档', 'api:admin:document:getlist', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:28.095907', NULL, NULL, '2021-10-01 11:17:28.095916');
INSERT INTO `Ad_Permission` VALUES ('b9b07aef-dd95-4b58-a8bd-ec0a32c06887', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '彻底删除', 'api:admin:tenant:delete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 8, NULL, 0, '2021-10-01 11:17:27.389185', NULL, NULL, '2021-10-01 11:17:27.389194');
INSERT INTO `Ad_Permission` VALUES ('bb8263f1-0068-489b-b9b4-3cba60f19d0f', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '查询', 'api:admin:permission:getlist', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:26.630081', NULL, NULL, '2021-10-01 11:17:26.630103');
INSERT INTO `Ad_Permission` VALUES ('bbad7070-c296-41e0-bfb5-8386356b4d0e', '841af2f7-b4ef-44ca-a1ba-81908c29a113', '批量删除', 'api:personnel:position:batchsoftdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.440967', NULL, NULL, '2021-10-01 11:17:28.440976');
INSERT INTO `Ad_Permission` VALUES ('bdb4c143-e275-450e-94c0-6a9ad846b383', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', '更新基本信息', 'api:admin:user:updatebasic', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:25.482475', NULL, NULL, '2021-10-01 11:17:25.482512');
INSERT INTO `Ad_Permission` VALUES ('bf7600d8-8c5b-41e2-b4ee-54d775557c17', '296469a4-2793-484f-8bc8-a5287ab1efe1', '查询', 'api:admin:dictionary:getpage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.480176', NULL, NULL, '2021-10-01 11:17:27.480185');
INSERT INTO `Ad_Permission` VALUES ('c4b50a17-35db-4b1c-b970-066979de63b1', '6d75765e-8ab8-44dd-a0f3-018bacee0803', '修改文档', 'api:admin:document:updatecontent', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 11, NULL, 0, '2021-10-01 11:17:28.128853', NULL, NULL, '2021-10-01 11:17:28.128875');
INSERT INTO `Ad_Permission` VALUES ('c4eb7338-f37d-4672-bb4a-f312b7935c65', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '设置权限', 'api:admin:permission:savetenantpermissions', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 7, NULL, 0, '2021-10-01 11:17:27.353559', NULL, NULL, '2021-10-01 11:17:27.353568');
INSERT INTO `Ad_Permission` VALUES ('c54f241c-2175-45bd-b9c8-42733c6af1c0', '8461d2ca-db06-4d93-808b-9246641869a1', '新增', 'api:admin:view:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:26.364165', NULL, NULL, '2021-10-01 11:17:26.364184');
INSERT INTO `Ad_Permission` VALUES ('c8243893-eb45-4d12-a473-407543bfdb7d', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '修改分组', 'api:admin:permission:updategroup', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 5, NULL, 0, '2021-10-01 11:17:26.760492', NULL, NULL, '2021-10-01 11:17:26.760505');
INSERT INTO `Ad_Permission` VALUES ('cd9aa62d-f131-4433-adef-2c8619f252e6', 'dea906df-7bc1-4995-ad65-6d46b29cec37', '新增', 'api:personnel:employee:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.694443', NULL, NULL, '2021-10-01 11:17:28.694451');
INSERT INTO `Ad_Permission` VALUES ('cdfe6be5-ef45-4640-8cf1-b719c3b894c8', '6102e52c-e75f-4622-8757-6fb3fe69f5bb', '查询', 'api:admin:role-permisson:list', 3, NULL, '', '', 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.012759', NULL, NULL, '2021-10-01 11:17:27.012768');
INSERT INTO `Ad_Permission` VALUES ('ce697a88-0fdc-4f8d-b26e-46468b28b7b0', '90244a22-cfa3-44de-ae65-c3124a35c6bf', '查询', 'api:admin:role:getpage', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:25.887558', NULL, NULL, '2021-10-01 11:17:25.887580');
INSERT INTO `Ad_Permission` VALUES ('d7311924-1c4a-4092-bfd2-a6c66f272f4f', 'dea906df-7bc1-4995-ad65-6d46b29cec37', '批量删除', 'api:personnel:employee:batchsoftdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.799622', NULL, NULL, '2021-10-01 11:17:28.799631');
INSERT INTO `Ad_Permission` VALUES ('dbf51323-2c4a-4996-8f16-b2a2d760db29', 'df21ad15-cdf2-48ca-8081-d4f8ce971c7f', '查询', 'api:admin:loginlog:getpage', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.709406', NULL, NULL, '2021-10-01 11:17:27.709414');
INSERT INTO `Ad_Permission` VALUES ('dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', '296469a4-2793-484f-8bc8-a5287ab1efe1', '删除', 'api:admin:dictionary:softdelete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:27.554551', NULL, NULL, '2021-10-01 11:17:27.554561');
INSERT INTO `Ad_Permission` VALUES ('ddc75f36-425e-44e4-a525-03c5580506c3', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '新增菜单', 'api:admin:permission:addmenu', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:26.694267', NULL, NULL, '2021-10-01 11:17:26.694287');
INSERT INTO `Ad_Permission` VALUES ('dea906df-7bc1-4995-ad65-6d46b29cec37', 'a315efd7-1968-4d6a-b0e7-fd546470557f', '员工管理', NULL, 2, '2ac46948-f51b-47da-a5d3-36786c2a350c', '/personnel/employee', '', 0, 1, 1, 0, 0, 0, 0, NULL, 0, '2021-10-01 11:17:28.629094', NULL, NULL, '2021-10-01 11:17:28.629104');
INSERT INTO `Ad_Permission` VALUES ('df21ad15-cdf2-48ca-8081-d4f8ce971c7f', 'f3026862-6fd7-4fae-bda4-eafced533d03', '登录日志', NULL, 2, '8a29606d-92ed-47f4-b93a-ce86fdefd4ec', '/admin/login-log', '', 0, 1, 1, 0, 0, 0, 1, NULL, 0, '2021-10-01 11:17:27.676593', NULL, NULL, '2021-10-01 11:17:27.676603');
INSERT INTO `Ad_Permission` VALUES ('e190106b-a741-44be-b115-61ad46d6254f', '90244a22-cfa3-44de-ae65-c3124a35c6bf', '新增', 'api:admin:role:add', 3, NULL, ' ', NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:25.921105', NULL, NULL, '2021-10-01 11:17:25.921146');
INSERT INTO `Ad_Permission` VALUES ('e2031d9f-0c2e-4249-802f-924c1cf21424', '632edcd7-adf1-46c6-924b-80dfa6afbee7', '新增', 'api:admin:tenant:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:27.228069', NULL, NULL, '2021-10-01 11:17:27.228085');
INSERT INTO `Ad_Permission` VALUES ('e4d7bdf6-4412-4a0d-9dd6-900b2abaa01e', '85d93df9-c52f-4dd0-91fa-8d38552618c4', '彻底删除', 'api:admin:permission:delete', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 7, NULL, 0, '2021-10-01 11:17:26.951150', NULL, NULL, '2021-10-01 11:17:26.951158');
INSERT INTO `Ad_Permission` VALUES ('e8b3762f-2540-40e0-8160-62e388b06af1', '00000000-0000-0000-0000-000000000000', '帮助文档', NULL, 1, NULL, NULL, 'el-icon-question', 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:27.805320', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:40:42.356521');
INSERT INTO `Ad_Permission` VALUES ('ee8af740-7253-401a-b811-fd62a85620a9', '4b78adeb-7446-4c17-a6c1-479c12574e68', '缓存管理', NULL, 2, 'dcaf48b9-628f-41cb-b6cd-1d1e1bd9af93', '/admin/cache', '', 0, 1, 1, 0, 0, 0, 7, NULL, 0, '2021-10-01 11:17:27.074518', NULL, NULL, '2021-10-01 11:17:27.074527');
INSERT INTO `Ad_Permission` VALUES ('f3026862-6fd7-4fae-bda4-eafced533d03', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', '日志管理', NULL, 1, NULL, NULL, 'el-icon-notebook-2', 0, 1, 0, 0, 0, 0, 4, NULL, 0, '2021-10-01 11:17:27.645966', NULL, NULL, '2021-10-01 11:17:27.645974');
INSERT INTO `Ad_Permission` VALUES ('f60f1676-262f-4c1b-9ce7-e858cecf3270', '00000000-0000-0000-0000-000000000000', '平台管理', NULL, 1, NULL, NULL, 'el-icon-s-platform', 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:25.543755', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-04 18:40:29.203409');
INSERT INTO `Ad_Permission` VALUES ('fd117c03-4be9-434a-b22f-d1d1b1e81af8', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', '更新密码', 'api:admin:user:changepassword', 3, NULL, ' ', '', 0, 1, 0, 0, 0, 0, 3, NULL, 0, '2021-10-01 11:17:25.512476', NULL, NULL, '2021-10-01 11:17:25.512507');
INSERT INTO `Ad_Permission` VALUES ('fe42b8d9-429a-4082-a8d6-7f5667d0af61', '296469a4-2793-484f-8bc8-a5287ab1efe1', '新增', 'api:admin:dictionary:add', 3, NULL, NULL, NULL, 0, 1, 0, 0, 0, 0, 2, NULL, 0, '2021-10-01 11:17:27.615911', NULL, NULL, '2021-10-01 11:17:27.615919');

-- ----------------------------
-- Table structure for Ad_Permission_Api
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Permission_Api`;
CREATE TABLE `Ad_Permission_Api`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `PermissionId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '权限Id',
  `ApiId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '接口Id',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_ApiId`(`ApiId`) USING BTREE,
  INDEX `IDX_PermissionId`(`PermissionId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '权限接口表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Permission_Api
-- ----------------------------
INSERT INTO `Ad_Permission_Api` VALUES ('0304bf1c-7033-4c5e-a8eb-941f86b1467a', '883d5091-9e35-43b5-aa48-fac931edaa78', 'e4e476de-a2a5-47b9-9b24-973affde9df7', 0, '2021-10-01 11:19:24.401464', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('0325f006-2434-4183-8547-90b3bb38db4b', '93c50be8-9d46-4a6d-84aa-29407b25cd05', '2ff24eb6-2d91-4fa4-9a65-3617f9344cec', 0, '2021-10-01 11:19:25.095752', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('0474713e-1341-4ab6-8d64-7662e26cb132', '83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', 'ca2d9ffb-352c-4ebb-bc4f-2ce647c48267', 0, '2021-10-01 11:19:26.644865', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('082b5954-daeb-46b0-b397-c9d830ac7348', 'b2832de9-0b0a-485f-8c96-023d830f9a72', '9f355887-f9ed-4db3-a377-a30ed5c27dcc', 0, '2021-10-01 11:19:26.581854', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('08c2eeb8-46b5-40f0-8139-70a3849e9f5a', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 'd32ff286-eb19-4201-ab9c-a66c8ee4aea5', 0, '2021-10-01 11:19:26.771235', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('09e21524-cfd1-4707-8bb3-5fddea00d219', '99e98331-f83a-463e-9b37-23d1d428fb44', '3eadb5b9-c142-4080-8b87-5dc707fff499', 0, '2021-10-01 11:19:24.965958', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('12aa4e08-02d3-4ad5-a9b6-fe0da111c0b4', '894e7dac-f116-4054-bb31-45a55bd479ac', 'c7545b9d-998e-4fcc-8fea-14b8e67f575a', 0, '2021-10-01 11:19:26.334235', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('18cfc296-5cf7-4fe0-8a72-11777d7a29af', '888eab40-58d6-487f-b3ba-b29c6b395561', '79a5cdee-b373-4c50-8115-aa4c10f0be49', 0, '2021-10-01 11:19:27.522562', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('1ae05bfe-c651-43ce-a728-06e299b2f649', 'bdb4c143-e275-450e-94c0-6a9ad846b383', '7588a542-8c9f-46e0-b8d3-c631d92205e7', 0, '2021-10-01 11:19:26.271061', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('219e2eab-6dbc-46c8-a83b-74899317d181', 'e2031d9f-0c2e-4249-802f-924c1cf21424', 'b4119693-01d8-4746-bee3-0da5043a9b4d', 0, '2021-10-01 11:19:25.933686', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('240d666b-c448-406e-92a4-d63eac229cce', '7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', 'b03964e8-3bb7-4399-8a2e-4fecc0f3c8db', 0, '2021-10-01 11:19:27.144343', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('2413ca7c-93b3-491d-a4e7-627e0fb89c5b', 'dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', 'ecad4e11-9441-4c68-93ea-419c00afe06a', 0, '2021-10-01 11:19:27.043529', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('250ed8c1-9834-48ba-a7d0-56531e2711b9', '894bb503-3111-47c7-8593-b9089f51c704', 'a113e800-995b-4899-b2a9-8a0ad7364098', 0, '2021-10-01 11:19:26.953260', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('25c6e9a9-1bb9-4490-80b1-4c2763ce7e58', '2f35c37a-3eeb-49e2-811b-025eba5dc2b7', '4f0942d0-88cb-4699-a486-9c83eb262c36', 0, '2021-10-01 11:19:25.189137', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('2879e414-d3c5-49fa-a061-7211ad00d711', '7dc79249-4232-4d8c-a181-d9a7d2c2e805', '4621eee7-f2f2-462a-be6d-98795e75744d', 0, '2021-10-01 11:19:27.743367', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('2c8185dd-8f9f-4fa8-845d-70bb6c592fc1', '26210b10-be46-44b6-9d1d-9e8eb1343174', '5f65bc4c-7982-4451-9f91-5f4b05b8f00d', 0, '2021-10-01 11:19:25.774766', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('2d70abcf-7f07-45e8-a62b-9bd92a8a6dac', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', 'cbb16bef-825f-4401-be19-7808ff401847', 0, '2021-10-01 11:19:25.665853', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('314eb086-8fe6-42da-9186-80d68b5d7b17', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 'cddddc6e-d709-4032-a6a9-101b6740c9bd', 0, '2021-10-01 11:19:26.803606', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('34ef0934-955e-4ffe-80fd-ee839eb46355', '359e254e-1c03-471a-9f77-67f01d6f3de2', '70238d9a-5642-4188-b447-d7c3ac4b2d5b', 0, '2021-10-01 11:19:24.772853', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('364b1308-da67-472e-bd68-a53fe05552f0', 'c4b50a17-35db-4b1c-b970-066979de63b1', 'cddddc6e-d709-4032-a6a9-101b6740c9bd', 0, '2021-10-01 11:19:26.674777', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('36d56591-1386-4025-8bb9-bead8ea8e4bd', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', '66813d2c-b903-430c-b674-86b973b4f84d', 0, '2021-10-01 11:19:27.652566', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156a2-6f40-4342-0aa3-cfe3afb5162d', '1f18ab4d-dd40-4aa4-9528-ae8a7e1bb65a', 'cc98d127-555d-46ae-94b0-5bc2e93e99bf', 0, '2022-01-10 22:47:44.207517', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156b2-d806-1e9f-1f6c-1f01395bb37f', '3a0156b2-d789-57cf-c872-a846fae0ecb5', '3a0156a9-bd27-0a8f-5442-2e40b85a26af', 0, '2022-01-10 23:05:39.590695', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156b3-695b-0c7c-1e3e-c01a2d03748d', '3a0156b3-68df-63a9-a473-2e03b046653a', '3a0156a9-bd27-0a8f-5442-2e40b85a26af', 0, '2022-01-10 23:06:16.795136', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156b4-36f8-11c3-f4db-6b7595d423bb', '3a0156b4-367c-0eec-9545-b882b323fba7', '3a0156aa-516c-23d9-cdfc-863d4b597382', 0, '2022-01-10 23:07:09.432246', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156b4-7039-3b9a-49ed-f2354c13d51e', '3a0156b4-6fbc-5aa3-fea1-538fcf3b198c', '3a0156aa-cda4-5a6b-16e1-6839379a3cf3', 0, '2022-01-10 23:07:24.089197', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156b4-e8f3-66c5-6c6f-b6cb691fb164', '3a0156b4-e876-773a-f543-8a3e7cd08988', '3a0156ae-9c37-fe75-5b8e-aec72c9b7042', 0, '2022-01-10 23:07:54.995187', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3a0156b7-6b26-dea8-cad2-bc052baeb684', '3a0156b4-acf4-f9e9-67e5-097019a5ac6f', '3a0156ab-63dd-d207-5924-720fc0613c84', 0, '2022-01-10 23:10:39.398955', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Permission_Api` VALUES ('3ad7d868-8bd6-4af8-b5ac-e961924e0d15', '90ad8b53-75ce-470d-8e5d-8a507cb21832', '302b004e-d697-4ee4-9305-05f9ce2654b8', 0, '2021-10-01 11:19:25.404431', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('43ee9a84-98a1-4b64-9b55-9ae556e4892c', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', '90cb4e31-8b78-43a6-960a-a49caf136b04', 0, '2021-10-01 11:19:27.298144', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('4b0d5e9b-2d7c-41e2-94db-d576be9f998a', '29fd319a-b73e-406c-a646-78be18c8da62', '6d56a6d3-79fb-4ee8-8a24-8f07e157130d', 0, '2021-10-01 11:19:27.430248', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('4b4b77ea-b378-4249-b736-b334c7728469', '50ab2705-1b52-458a-9091-29610fcc8b50', 'd7f7b699-4e11-44be-98b2-59ccee1f4c27', 0, '2021-10-01 11:19:26.000122', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('4c0d7458-4970-4d5b-a867-66f05b51d0d2', '5d161428-85aa-4964-9f22-2884814b9df4', '1bd7d2e1-1e59-4b64-af30-069f70117c9f', 0, '2021-10-01 11:19:25.481421', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('58a21f11-8f1c-415d-a1f6-570e090eb484', '7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', '0974bc06-8cd9-4965-82a6-146917d01631', 0, '2021-10-01 11:19:27.106657', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('58c04b06-43f9-4bd3-889b-6b619dd9ea3b', '9dacac88-a65d-42ef-8afa-c127377433f7', '020fe65e-377e-4924-998c-0d6029cad87a', 0, '2021-10-01 11:19:25.248899', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('593c3527-3ece-4df8-8428-b6de42a2eb8d', '5fb50010-de89-421b-b4ae-cc436bf6c6df', '9c386c8e-1f49-4fe8-95c7-22fdce2cb1b8', 0, '2021-10-01 11:19:25.281542', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5a6584bc-c777-4510-95d8-70eb75d0cf77', '4cadb843-aa60-4370-a6a8-78a1ae56c545', 'bfb41958-5eeb-4560-94f3-0fa8ebda7711', 0, '2021-10-01 11:19:27.266602', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5a68eb38-8d14-4656-a0cb-e186df793ccc', '6b4d15e3-96d0-45b8-924c-8630bba431b7', '634e23f6-9195-4b49-baf7-24343575ef31', 0, '2021-10-01 11:19:25.158884', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5b53070b-99d7-4186-b5ea-3ca1b525b594', '7dc79249-4232-4d8c-a181-d9a7d2c2e805', 'd4dee739-3d12-4d97-b573-90bd6de26a11', 0, '2021-10-01 11:19:27.776712', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5bd1e7fd-6545-4552-a061-cf8cac89dd08', '805dbab1-769c-4fce-a626-36c6abd6b219', 'c8536738-4cb6-4469-ab1e-1a98bd4dd35f', 0, '2021-10-01 11:19:27.365940', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5daa5fe7-7910-467c-883a-63310b17611e', '9a20843a-cb44-4d6d-a6bb-1a1cbc4cec15', 'b13ad071-d755-4ac1-ad71-4d698fb6f90a', 0, '2021-10-01 11:19:24.834524', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5ef7030b-cffe-4cf4-b36f-f1fa608fbc96', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', '2a7ec0d0-25d0-47ee-bf27-78f7d0417db3', 0, '2021-10-01 11:19:25.736385', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('5f27c6b9-90c5-4da4-9f7c-6b43aa19ae56', 'e4d7bdf6-4412-4a0d-9dd6-900b2abaa01e', 'a9c8bbd1-344d-4410-99ca-f320b62c217c', 0, '2021-10-01 11:19:26.832898', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('600dc249-ded0-47d0-b2a7-7ea6411879d8', '1a65682d-8fa8-4557-81ab-25224889a154', '4bf21d67-a0cf-4fcf-8d22-61cfe8b26ffd', 0, '2021-10-01 11:19:24.673193', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('63f7e938-1dd2-4e67-aa4f-908a6d8edae4', '001e7b5b-dfe7-48fc-9ffe-9bbd627acef4', '04426df7-b6bb-4be5-86ed-a6319cdcfa06', 0, '2021-10-01 11:19:25.904293', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('645bbc12-e951-49cd-b3b6-dd03f064f6f3', 'dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', '301bf5a0-e0a3-4da4-9d92-0c81529e232e', 0, '2021-10-01 11:19:27.077437', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('67f80126-46be-49a1-b8ac-0d02f07ae5f0', 'fe42b8d9-429a-4082-a8d6-7f5667d0af61', '9f551226-207e-4339-b427-46d2589760b6', 0, '2021-10-01 11:19:27.205649', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('6a926a17-2489-4e2b-a860-9d08d6177339', 'c4eb7338-f37d-4672-bb4a-f312b7935c65', '1757ebf0-c50e-4eb8-a1cc-0a11d4be5228', 0, '2021-10-01 11:19:26.060204', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('6b4ac280-50d9-4eff-8012-b86c3714c96c', '979f2b81-5d74-45d4-88df-ba3a57e13fca', '5f62f723-7259-4a26-99cc-30ea0b92259e', 0, '2021-10-01 11:19:24.638927', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('70766825-0df8-41bb-9d74-d04eeccfc0c2', '1784e0c4-4d49-4b20-ba4d-f65009403e15', '57235f10-dcd1-4bbd-b9da-ebd132fe64a8', 0, '2021-10-01 11:19:27.491220', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('717cb6ba-54a9-4a7a-a688-3db5ba04c4ae', 'a5cec4b3-e414-4937-b339-4ceea83bdae2', '07ba61ad-5e76-4435-8550-4e1424527817', 0, '2021-10-01 11:19:27.236137', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('724d1741-dc0a-437c-bbd2-064b239ca938', '0c46425c-a46f-4088-9c72-94b58ae62ca3', '48bafa86-7008-4a56-99c7-a6baddc1a6f6', 0, '2021-10-01 11:19:26.395552', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('77b6a822-5032-4993-b9c2-b686e8cc2e27', '4c002c85-569e-4677-9c3a-d8cc1cc0579c', 'a2b70a0a-dee9-471d-b377-af9aa378241c', 0, '2021-10-01 11:19:26.151745', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('79797e46-71ba-4dce-8156-2d90e8bb6b4b', '983cb8c2-994c-4642-b84a-bace084e4382', '1da4bd1b-d719-40f2-a81d-2b2944d7d1a8', 0, '2021-10-01 11:19:26.740803', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('7b57d339-9440-47ae-b9e2-4820d71767bf', 'bdb4c143-e275-450e-94c0-6a9ad846b383', 'c7545b9d-998e-4fcc-8fea-14b8e67f575a', 0, '2021-10-01 11:19:26.242099', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('7c9743a3-95ab-4e30-a256-699bee096292', 'bf7600d8-8c5b-41e2-b4ee-54d775557c17', '67f0cbb4-68fe-4e28-a895-fc3d296dee93', 0, '2021-10-01 11:19:27.013741', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('7cea4dd1-1d1f-4627-85f2-b05e3d00a39c', '5f00b624-8eee-4185-b63b-f71c488e49a0', 'e48ad490-8b29-497a-a2b6-202d78dbc269', 0, '2021-10-01 11:19:26.459180', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('7ddf3ecc-0121-40bd-8127-13e46b388aa1', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', 'ab3ef110-1c26-4111-9a58-be1b7a328b18', 0, '2021-10-01 11:19:27.622411', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('7f79505c-eb13-4429-aeb7-2dacd2d99b31', '72912d72-56cc-46ab-9f0b-54c0fc8861c9', '305a4077-fd0d-48d8-9ba4-db24b6c4ad0e', 0, '2021-10-01 11:19:25.126158', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('80861f9f-250f-4999-a6aa-5cf080e384cc', 'bbad7070-c296-41e0-bfb5-8386356b4d0e', 'd3e4bda3-1b1e-4616-ba8a-b1b9a98a4eb0', 0, '2021-10-01 11:19:27.808808', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('81a07cd6-24f7-4500-bb32-b54680e06a59', 'fe42b8d9-429a-4082-a8d6-7f5667d0af61', '339a1b2e-6e88-4d6f-9fc1-185e7eb4e30e', 0, '2021-10-01 11:19:27.174483', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('84bc3910-f0f0-4f80-b543-39759b290579', '7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', '67553d2a-023a-4492-96bd-7749fafb54a4', 0, '2021-10-01 11:19:24.499537', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('8545ca26-4525-4d23-bc28-3acc3a322c00', 'c4b50a17-35db-4b1c-b970-066979de63b1', 'e778f118-a923-4f81-a685-e191fcec5fca', 0, '2021-10-01 11:19:26.704432', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('856d8877-3ee8-4f58-b2fb-29b1bd33b6e1', '913a485c-0770-4fa5-83c9-fa523e3c2815', '3bff34bc-2b81-4c8d-a4ec-953e125d9d41', 0, '2021-10-01 11:19:25.966488', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('86ffac68-f8e4-4a39-951d-8b2a700fc05c', 'a6ba585b-6a1d-4fd5-bae6-d87d875eb00b', '733fb180-8bfc-4ed4-988b-8a50d7a96728', 0, '2021-10-01 11:19:24.995809', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('87de6482-9468-4034-ac59-ffa392d713db', 'b9b07aef-dd95-4b58-a8bd-ec0a32c06887', 'cd1b0ef3-0126-4af4-91c4-711942c27866', 0, '2021-10-01 11:19:26.031143', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('881f8845-daf1-4863-b72a-b9fe0ca458ff', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', '2a7ec0d0-25d0-47ee-bf27-78f7d0417db3', 0, '2021-10-01 11:19:25.872085', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('8b9da279-ee08-4ad6-b692-85a606a889cd', '5e4a9cb4-ca3c-452c-8b66-0af587d79934', 'a5cb60b6-1e86-4cb8-afc2-be7cff494708', 0, '2021-10-01 11:19:26.365884', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('8ce42bb3-e8ee-4415-a98b-815bd4d45488', '1784e0c4-4d49-4b20-ba4d-f65009403e15', '8f6055a5-f2a5-49e7-9ec9-071f6ec7e42b', 0, '2021-10-01 11:19:27.460417', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('8e788c5b-15dc-4d20-9bdb-829ae5d3a200', '39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 'c77b7c4f-005e-47f4-964f-d3bc596b8e3d', 0, '2021-10-01 11:19:27.682531', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('90f06f58-2848-494b-b853-b8c450318710', 'c8243893-eb45-4d12-a473-407543bfdb7d', '60d70eaf-3cba-4c7a-b1c7-8f6e1a63d891', 0, '2021-10-01 11:19:25.542022', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('9154ff12-d8ac-4fb1-a60a-27be10a3a93b', 'dbf51323-2c4a-4996-8f16-b2a2d760db29', 'd8570c9d-a664-421a-8009-a772d3825cce', 0, '2021-10-01 11:19:26.182165', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('91b428b5-0a67-4775-a30a-30da39c21fdb', 'cd9aa62d-f131-4433-adef-2c8619f252e6', '00ed22d7-5bc6-4ab1-a154-384247ce8616', 0, '2021-10-01 11:19:27.592078', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('9210d972-be7a-447f-a43d-c997c2bba6e2', '894bb503-3111-47c7-8593-b9089f51c704', '73d76aae-865a-42c0-b8f1-aaa13826f034', 0, '2021-10-01 11:19:26.861810', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('951ce6be-d379-4e77-9592-ee569a776abb', '894bb503-3111-47c7-8593-b9089f51c704', '25737e4c-6f7c-4bca-b117-39e72d649c02', 0, '2021-10-01 11:19:26.890756', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('99477676-59de-4e83-9e90-89f46fef46e2', 'd7311924-1c4a-4092-bfd2-a6c66f272f4f', 'e7fd7121-2e9b-45ee-ac83-3a8ea099d051', 0, '2021-10-01 11:19:27.713075', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('9bf19791-8d97-4068-95da-cc5c68018b34', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', 'cbb16bef-825f-4401-be19-7808ff401847', 0, '2021-10-01 11:19:25.835448', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('9c0c1a67-e37c-43e8-8c03-5c3d1ba0368c', '1ca033c8-2570-451a-93c4-6b94220a44a0', 'c856c25f-5ca0-4be9-a36f-aeda33c38a6f', 0, '2021-10-01 11:19:27.400215', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('9e381083-85f1-44f4-a742-6329016b55da', 'c54f241c-2175-45bd-b9c8-42733c6af1c0', 'a9ad8b51-d982-43f7-b360-894a9ca30fc0', 0, '2021-10-01 11:19:25.025354', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('a1ab455e-71b2-4a96-a051-2366af3d780e', '9dacac88-a65d-42ef-8afa-c127377433f7', '4365a324-21d4-4fbc-a374-79d90b1fa253', 0, '2021-10-01 11:19:25.219435', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('a4484511-f296-4ef0-9d5d-873e4d37bb13', 'fd117c03-4be9-434a-b22f-d1d1b1e81af8', '882a9452-343a-4fef-9286-4e6bcea59533', 0, '2021-10-01 11:19:26.302760', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('a467e587-9595-4995-bd0f-fecc473c1446', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', 'fba9235f-a8b8-4181-a845-989e748b06ba', 0, '2021-10-01 11:19:26.522655', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('a513634e-4507-423c-8e6a-940c0ad5b4fe', '4c002c85-569e-4677-9c3a-d8cc1cc0579c', 'af3ebca8-3e7c-466c-96dd-97309faae49d', 0, '2021-10-01 11:19:26.122209', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('a963e2d2-f0f4-4a5d-8418-f3f38aa1d571', '33580d92-7f92-4b5f-a3f2-84f5750895eb', '2e4e28cb-da84-47cb-9960-5ee45d333a4e', 0, '2021-10-01 11:19:26.429344', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('acda383f-7ca1-4300-8a80-9fc695db3b7a', '7d4533f9-e1c5-429e-83bb-1a062656d1eb', '5f65bc4c-7982-4451-9f91-5f4b05b8f00d', 0, '2021-10-01 11:19:25.572174', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('adc4bc2d-de95-49f8-b142-23e205947400', '996dbc69-8e6b-42d2-b488-6f0c31f6fb8f', '71938296-f8c3-4951-925f-a270720f5f7d', 0, '2021-10-01 11:19:24.931201', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('b2a12b3a-fd2a-472b-8321-e0e60252e362', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', '308e95f4-f135-4076-beb3-3d23e2ce4813', 0, '2021-10-01 11:19:26.551266', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('b2d64ea5-8ab6-488c-b5b8-4987627f6b78', 'b2832de9-0b0a-485f-8c96-023d830f9a72', '183fbfe7-bd06-4512-9d04-476cae7698cf', 0, '2021-10-01 11:19:26.612575', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('b3a354c7-ea6c-4a13-b0cc-9fdb9e5eb2f6', 'e190106b-a741-44be-b115-61ad46d6254f', '6bcbba6d-4b65-4793-8aa9-d5deaa96abdc', 0, '2021-10-01 11:19:24.600145', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('b9f4479f-a723-4bde-bbb9-9d6202c856db', '7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', 'a837d1da-6d79-463e-af00-ce0a9e840c18', 0, '2021-10-01 11:19:24.535183', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('bb3da80f-6a0c-40d0-88a7-70527be948c7', 'ddc75f36-425e-44e4-a525-03c5580506c3', '76252108-08f8-45e6-b2d1-54dca158df2c', 0, '2021-10-01 11:19:25.340264', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('c9ae89eb-7690-4f7f-a1cb-e40644bf1306', '894bb503-3111-47c7-8593-b9089f51c704', '078c2998-72f8-4133-ade2-35547688e412', 0, '2021-10-01 11:19:26.923926', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('cb9859d9-4eec-45b8-bc00-65f83fe4173a', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', 'c75acab7-418a-4be5-a61c-0544469b3319', 0, '2021-10-01 11:19:27.334645', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('cbb136a1-c1a8-4a10-9fe6-da9c496319ca', '5d161428-85aa-4964-9f22-2884814b9df4', '986ed499-87e9-481d-a239-21100cce2b23', 0, '2021-10-01 11:19:25.442827', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('cd6441f6-008c-49fe-ba98-a5e375486f23', 'ac3e944c-46e4-41d6-b2bd-74b35b044bed', 'bf27d5d0-5931-4688-a11c-92e985d8d60e', 0, '2021-10-01 11:19:24.900607', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('ce38aa59-3f76-455c-b086-b093b8abb1ac', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', '9716eebe-2538-4244-a294-337a7206abe8', 0, '2021-10-01 11:19:25.703877', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('d1a4b89e-636c-4be2-913f-1b509d9782d7', '451f1861-f4d2-4133-ae08-e0270055ff95', 'a178abf8-a2d4-4a0e-99e6-d01e8e34e03a', 0, '2021-10-01 11:19:25.370300', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('d1f29308-39fa-4067-a234-ce79ca3bebf2', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', '7b1219aa-cb7d-4a35-9303-d3dc3ccc7d5e', 0, '2021-10-01 11:19:25.636533', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('d51f69de-0112-4961-8723-88cdbb7a1d25', '93c50be8-9d46-4a6d-84aa-29407b25cd05', '82709669-1aba-4551-ae88-2a7bf262531c', 0, '2021-10-01 11:19:25.057287', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('d727db27-dc62-4fd4-b989-abe01578ad6e', '7d4533f9-e1c5-429e-83bb-1a062656d1eb', 'c9a0da34-f852-4f1c-8bd3-403f9e352d48', 0, '2021-10-01 11:19:25.601471', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('d8ed36e8-7bae-49d1-8384-b41495feec7f', 'c8243893-eb45-4d12-a473-407543bfdb7d', '19865940-b8ed-468f-aadc-84ee488db2b6', 0, '2021-10-01 11:19:25.511214', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('de566df9-5a55-4727-b154-b2081142316f', '9a20843a-cb44-4d6d-a6bb-1a1cbc4cec15', '50b6e85f-b35d-468a-a057-ce5fe7d159ea', 0, '2021-10-01 11:19:24.866505', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('e4167e90-7fca-47ba-bfd3-c4a5157429b5', '6bb9562d-0203-48b2-b959-3419fb043892', '3df46b91-dbd7-4f49-af4e-03add9c0ce04', 0, '2021-10-01 11:19:24.460691', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('eb585555-c834-4b60-832d-3a312aceb2e0', '45843eed-89e0-4298-b26b-ab379e4dac0a', '1262e0e5-7ab5-47d9-b927-019eda94ec7a', 0, '2021-10-01 11:19:26.212188', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('eb61ebc4-04c3-4e47-9d76-1a068a660ea5', 'ce697a88-0fdc-4f8d-b26e-46468b28b7b0', '2a7ec0d0-25d0-47ee-bf27-78f7d0417db3', 0, '2021-10-01 11:19:24.568965', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('ee100d93-3193-487a-bd4e-bb893f137551', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', '7b1219aa-cb7d-4a35-9303-d3dc3ccc7d5e', 0, '2021-10-01 11:19:25.806652', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('efb6b206-7541-4ce9-b26e-2552433b3c5e', '03258db8-67e1-4b72-a85e-bf142dacf043', '1dd8908d-9f2d-410c-a1c8-9f55c612be71', 0, '2021-10-01 11:19:27.562932', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('f229b356-b88a-4256-aa78-4e9df2872ca5', 'bf7600d8-8c5b-41e2-b4ee-54d775557c17', 'bd0cd1e8-0b19-429f-8208-80ac08c0629a', 0, '2021-10-01 11:19:26.982477', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('f2b3f7a3-6dfa-4d35-a7bb-27d26088d507', 'c4eb7338-f37d-4672-bb4a-f312b7935c65', 'cfed5368-63bf-47d0-a7d2-ddd72835c35b', 0, '2021-10-01 11:19:26.092061', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('f5091412-20a3-4498-815f-082e001247ae', '4175b221-53d4-44d2-9d5a-a450d8b66625', '8af617bb-3149-49af-9a30-7b73589d42f7', 0, '2021-10-01 11:19:24.804387', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('f5d872a9-3fdd-40cc-8c3c-99ed4bcd4c52', '0c0e1df7-3782-473b-a324-468e9fd83b98', 'c697fc88-8a35-4f34-a55c-87a8d8b5e319', 0, '2021-10-01 11:19:26.492157', NULL);
INSERT INTO `Ad_Permission_Api` VALUES ('fc97f14a-b06d-4f58-937e-2f6ec19d1310', 'bb8263f1-0068-489b-b9b4-3cba60f19d0f', '70b8d13b-fe23-4919-8bf8-9664dc10ad07', 0, '2021-10-01 11:19:25.311046', NULL);

-- ----------------------------
-- Table structure for Ad_Role
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Role`;
CREATE TABLE `Ad_Role`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '编码',
  `Description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '说明',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Sort` int NOT NULL COMMENT '排序',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '角色表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Role
-- ----------------------------
INSERT INTO `Ad_Role` VALUES ('3a015be9-e28d-cde7-5f69-db8cd286e924', '平台管理员', 'admin', NULL, 1, 0, 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:23:52.858356', NULL, NULL, NULL);
INSERT INTO `Ad_Role` VALUES ('3a015bed-f20f-d862-e1cc-8832f841a68e', '资讯管理员', 'information_admin', '', 1, 0, 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:28:19.082461', '3a015be9-e27c-ad59-1a55-c1303e1b9671', NULL, NULL);
INSERT INTO `Ad_Role` VALUES ('808fa030-49d5-408b-82a6-5835de3209e4', '平台管理员', 'plat_admin', '1', 1, 0, 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-09-28 18:49:34.391702', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-02 15:46:59.056902');

-- ----------------------------
-- Table structure for Ad_Role_Permission
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Role_Permission`;
CREATE TABLE `Ad_Role_Permission`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '角色Id',
  `PermissionId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '权限Id',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_PermissionId1`(`PermissionId`) USING BTREE,
  INDEX `IDX_RoleId`(`RoleId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '角色权限表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Role_Permission
-- ----------------------------
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-02b1-0f35-a08ff204521e', '808fa030-49d5-408b-82a6-5835de3209e4', '1ca033c8-2570-451a-93c4-6b94220a44a0', 0, '2022-01-10 22:49:19.246136', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-0a66-2d50-f4b4f6d43cee', '808fa030-49d5-408b-82a6-5835de3209e4', 'bbad7070-c296-41e0-bfb5-8386356b4d0e', 0, '2022-01-10 22:49:19.246212', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-24a6-0188-5d89bb8e3d80', '808fa030-49d5-408b-82a6-5835de3209e4', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', 0, '2022-01-10 22:49:19.246290', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-2c46-4eec-7a437816308f', '808fa030-49d5-408b-82a6-5835de3209e4', 'd7311924-1c4a-4092-bfd2-a6c66f272f4f', 0, '2022-01-10 22:49:19.246347', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-6c06-eedd-b38291a0d83f', '808fa030-49d5-408b-82a6-5835de3209e4', '979f2b81-5d74-45d4-88df-ba3a57e13fca', 0, '2022-01-10 22:49:19.246405', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-6c3c-ad6c-81dca4c46854', '808fa030-49d5-408b-82a6-5835de3209e4', '1784e0c4-4d49-4b20-ba4d-f65009403e15', 0, '2022-01-10 22:49:19.246111', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-74bc-7858-4d007e682061', '808fa030-49d5-408b-82a6-5835de3209e4', 'dea906df-7bc1-4995-ad65-6d46b29cec37', 0, '2022-01-10 22:49:19.245991', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-8342-ccaa-39855855f03c', '808fa030-49d5-408b-82a6-5835de3209e4', '29fd319a-b73e-406c-a646-78be18c8da62', 0, '2022-01-10 22:49:19.246160', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-871b-3a50-c09aa6e3af75', '808fa030-49d5-408b-82a6-5835de3209e4', '39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 0, '2022-01-10 22:49:19.246264', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-8cfc-3743-772ec700109e', '808fa030-49d5-408b-82a6-5835de3209e4', '841af2f7-b4ef-44ca-a1ba-81908c29a113', 0, '2022-01-10 22:49:19.245960', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-8e8e-aadf-43c80e1935ca', '808fa030-49d5-408b-82a6-5835de3209e4', '268b006b-80b9-4bed-89b9-230e55536790', 0, '2022-01-10 22:49:19.244491', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-96ad-1db3-b2b42b3f2ef1', '808fa030-49d5-408b-82a6-5835de3209e4', '03258db8-67e1-4b72-a85e-bf142dacf043', 0, '2022-01-10 22:49:19.246238', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-a361-822a-ec3f167aaa43', '808fa030-49d5-408b-82a6-5835de3209e4', '888eab40-58d6-487f-b3ba-b29c6b395561', 0, '2022-01-10 22:49:19.246184', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-af13-5e96-9757a0438c8d', '808fa030-49d5-408b-82a6-5835de3209e4', '4cadb843-aa60-4370-a6a8-78a1ae56c545', 0, '2022-01-10 22:49:19.246015', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-b599-5bd1-71fead4ebe17', '808fa030-49d5-408b-82a6-5835de3209e4', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', 0, '2022-01-10 22:49:19.246087', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-b60a-61f0-7a6ea0476049', '808fa030-49d5-408b-82a6-5835de3209e4', '1f18ab4d-dd40-4aa4-9528-ae8a7e1bb65a', 0, '2022-01-10 22:49:19.246376', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-c6ad-4645-72fde8b2926b', '808fa030-49d5-408b-82a6-5835de3209e4', '805dbab1-769c-4fce-a626-36c6abd6b219', 0, '2022-01-10 22:49:19.246037', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-d145-701f-45430c817ca9', '808fa030-49d5-408b-82a6-5835de3209e4', 'a5cec4b3-e414-4937-b339-4ceea83bdae2', 0, '2022-01-10 22:49:19.246061', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-f6e8-e066-ddd97996262c', '808fa030-49d5-408b-82a6-5835de3209e4', 'a315efd7-1968-4d6a-b0e7-fd546470557f', 0, '2022-01-10 22:49:19.238671', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-fa89-7274-24348692628a', '808fa030-49d5-408b-82a6-5835de3209e4', '1a65682d-8fa8-4557-81ab-25224889a154', 0, '2022-01-10 22:49:19.246435', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156a3-e26d-fe88-030d-e2c0e1d573f5', '808fa030-49d5-408b-82a6-5835de3209e4', 'cd9aa62d-f131-4433-adef-2c8619f252e6', 0, '2022-01-10 22:49:19.246317', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156b5-16b2-22d0-3082-f21dd82c1f3e', '808fa030-49d5-408b-82a6-5835de3209e4', '3a0156b4-e876-773a-f543-8a3e7cd08988', 0, '2022-01-10 23:08:06.706659', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156b5-16b2-a75c-6ede-b8cbcf1e18e7', '808fa030-49d5-408b-82a6-5835de3209e4', '3a0156b4-acf4-f9e9-67e5-097019a5ac6f', 0, '2022-01-10 23:08:06.706640', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156b5-16b2-c02f-4d91-b5f0a6c1e0e5', '808fa030-49d5-408b-82a6-5835de3209e4', '3a0156b3-68df-63a9-a473-2e03b046653a', 0, '2022-01-10 23:08:06.706567', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156b5-16b2-cd84-0f87-c4663299bc3c', '808fa030-49d5-408b-82a6-5835de3209e4', '3a0156b4-6fbc-5aa3-fea1-538fcf3b198c', 0, '2022-01-10 23:08:06.706620', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156b5-16b2-e4bd-fe9e-b2ceb372a029', '808fa030-49d5-408b-82a6-5835de3209e4', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', 0, '2022-01-10 23:08:06.706484', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a0156b5-16b2-f22d-7b04-85c93f1440b3', '808fa030-49d5-408b-82a6-5835de3209e4', '3a0156b4-367c-0eec-9545-b882b323fba7', 0, '2022-01-10 23:08:06.706600', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-0138-10a7-6dee27314e2c', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'fe42b8d9-429a-4082-a8d6-7f5667d0af61', 0, '2022-01-11 23:24:49.987759', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-0172-84b9-ae71ab0685e9', '3a015be9-e28d-cde7-5f69-db8cd286e924', '883d5091-9e35-43b5-aa48-fac931edaa78', 0, '2022-01-11 23:24:49.986751', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-0b5b-d991-04846f798c55', '3a015be9-e28d-cde7-5f69-db8cd286e924', '20b40852-60e9-4862-8069-bb44ceaf859c', 0, '2022-01-11 23:24:49.928117', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-0cc5-6473-1c286112deca', '3a015be9-e28d-cde7-5f69-db8cd286e924', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', 0, '2022-01-11 23:24:49.987140', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-0fbd-bed4-48d985b8bc10', '3a015be9-e28d-cde7-5f69-db8cd286e924', '3a0156b4-e876-773a-f543-8a3e7cd08988', 0, '2022-01-11 23:24:49.988348', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-134e-8416-c8023f29996e', '3a015be9-e28d-cde7-5f69-db8cd286e924', '983cb8c2-994c-4642-b84a-bace084e4382', 0, '2022-01-11 23:24:49.928836', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-14a5-2023-f79555120df2', '3a015be9-e28d-cde7-5f69-db8cd286e924', '894e7dac-f116-4054-bb31-45a55bd479ac', 0, '2022-01-11 23:24:49.988531', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-170a-8be2-66559159a8d4', '3a015be9-e28d-cde7-5f69-db8cd286e924', '39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 0, '2022-01-11 23:24:49.928659', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-17c3-59cb-de8ea8a1feee', '3a015be9-e28d-cde7-5f69-db8cd286e924', '4cadb843-aa60-4370-a6a8-78a1ae56c545', 0, '2022-01-11 23:24:49.928258', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-192e-a46f-8d055fe3d64a', '3a015be9-e28d-cde7-5f69-db8cd286e924', '31ebfd6b-8cab-4850-baf7-7f778264e03a', 0, '2022-01-11 23:24:49.928083', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-1d06-d816-5fdf73e7c3e7', '3a015be9-e28d-cde7-5f69-db8cd286e924', '83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', 0, '2022-01-11 23:24:49.989216', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-1d1c-1516-0c3d7785b033', '3a015be9-e28d-cde7-5f69-db8cd286e924', '894bb503-3111-47c7-8593-b9089f51c704', 0, '2022-01-11 23:24:49.987934', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-1e13-3fc0-d40daecc9cc2', '3a015be9-e28d-cde7-5f69-db8cd286e924', '1ca033c8-2570-451a-93c4-6b94220a44a0', 0, '2022-01-11 23:24:49.928449', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-2661-38c5-3c6f2d5c6827', '3a015be9-e28d-cde7-5f69-db8cd286e924', '7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', 0, '2022-01-11 23:24:49.988052', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-2bde-83b7-5d35d75c822f', '3a015be9-e28d-cde7-5f69-db8cd286e924', '03258db8-67e1-4b72-a85e-bf142dacf043', 0, '2022-01-11 23:24:49.928616', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-2c6f-040d-b321f1b17f2c', '3a015be9-e28d-cde7-5f69-db8cd286e924', '6d75765e-8ab8-44dd-a0f3-018bacee0803', 0, '2022-01-11 23:24:49.928222', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-317e-8302-b995d346e95c', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'df21ad15-cdf2-48ca-8081-d4f8ce971c7f', 0, '2022-01-11 23:24:49.928049', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-3c71-8c79-cbd6189e6a43', '3a015be9-e28d-cde7-5f69-db8cd286e924', '7dc79249-4232-4d8c-a181-d9a7d2c2e805', 0, '2022-01-11 23:24:49.986599', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-3e84-72e2-d745961f2d8c', '3a015be9-e28d-cde7-5f69-db8cd286e924', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', 0, '2022-01-11 23:24:49.927961', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-418b-f4d4-69f35f43ceb6', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'dea906df-7bc1-4995-ad65-6d46b29cec37', 0, '2022-01-11 23:24:49.927598', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-44e6-dca5-e729a1c7d791', '3a015be9-e28d-cde7-5f69-db8cd286e924', '7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', 0, '2022-01-11 23:24:49.986699', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-511a-e029-f7dfab9052ac', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'dbf51323-2c4a-4996-8f16-b2a2d760db29', 0, '2022-01-11 23:24:49.988408', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-527d-72e8-1f124dbfae7d', '3a015be9-e28d-cde7-5f69-db8cd286e924', '45843eed-89e0-4298-b26b-ab379e4dac0a', 0, '2022-01-11 23:24:49.988469', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-5570-a5b0-6cbc3bde9a69', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', 0, '2022-01-11 23:24:49.927650', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-572d-b4f1-000808f85d70', '3a015be9-e28d-cde7-5f69-db8cd286e924', '296469a4-2793-484f-8bc8-a5287ab1efe1', 0, '2022-01-11 23:24:49.927929', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-580e-a4df-5818f11f2a13', '3a015be9-e28d-cde7-5f69-db8cd286e924', '26210b10-be46-44b6-9d1d-9e8eb1343174', 0, '2022-01-11 23:24:49.987195', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-613f-ae77-bcd769dce066', '3a015be9-e28d-cde7-5f69-db8cd286e924', '3a0156b4-367c-0eec-9545-b882b323fba7', 0, '2022-01-11 23:24:49.988169', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-6545-f720-3690974a8521', '3a015be9-e28d-cde7-5f69-db8cd286e924', '04cb1793-0bd8-4d75-8c06-288194ddb8e1', 0, '2022-01-11 23:24:49.927735', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-6ee8-f7e5-aff9223d11a7', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'bbad7070-c296-41e0-bfb5-8386356b4d0e', 0, '2022-01-11 23:24:49.928574', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-7238-b15e-1d2b54a64ded', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'd7311924-1c4a-4092-bfd2-a6c66f272f4f', 0, '2022-01-11 23:24:49.928792', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-7426-4ba9-a273461c98e4', '3a015be9-e28d-cde7-5f69-db8cd286e924', '1f18ab4d-dd40-4aa4-9528-ae8a7e1bb65a', 0, '2022-01-11 23:24:49.986941', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-78dd-3501-0baf0e061a29', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'ee8af740-7253-401a-b811-fd62a85620a9', 0, '2022-01-11 23:24:49.927835', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-7e54-d301-b67899ab5b7c', '3a015be9-e28d-cde7-5f69-db8cd286e924', '1784e0c4-4d49-4b20-ba4d-f65009403e15', 0, '2022-01-11 23:24:49.928409', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-8368-c9b1-9aba151ea970', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'c4b50a17-35db-4b1c-b970-066979de63b1', 0, '2022-01-11 23:24:49.989312', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-854b-fd06-c1647b86bc87', '3a015be9-e28d-cde7-5f69-db8cd286e924', '3a0156b3-68df-63a9-a473-2e03b046653a', 0, '2022-01-11 23:24:49.988111', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-85fa-f98d-90d54ab57b13', '3a015be9-e28d-cde7-5f69-db8cd286e924', '0c0e1df7-3782-473b-a324-468e9fd83b98', 0, '2022-01-11 23:24:49.988917', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-87f4-53c7-05c7f563cec7', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'bf7600d8-8c5b-41e2-b4ee-54d775557c17', 0, '2022-01-11 23:24:49.987670', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-8a2c-133b-c3c706f221a7', '3a015be9-e28d-cde7-5f69-db8cd286e924', '29fd319a-b73e-406c-a646-78be18c8da62', 0, '2022-01-11 23:24:49.928488', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-8e85-168d-ff8eb2a3bc32', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', 0, '2022-01-11 23:24:49.989009', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-9c73-fa43-be36fe2de0b6', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', 0, '2022-01-11 23:24:49.928371', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-9dd8-bfbc-a04149da4551', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'b2832de9-0b0a-485f-8c96-023d830f9a72', 0, '2022-01-11 23:24:49.989114', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a05e-c333-330537f732a3', '3a015be9-e28d-cde7-5f69-db8cd286e924', '5e4a9cb4-ca3c-452c-8b66-0af587d79934', 0, '2022-01-11 23:24:49.989524', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a15b-ba56-a178a5c2d301', '3a015be9-e28d-cde7-5f69-db8cd286e924', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', 0, '2022-01-11 23:24:49.928152', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a1ca-35ac-9542b33e7002', '3a015be9-e28d-cde7-5f69-db8cd286e924', '805dbab1-769c-4fce-a626-36c6abd6b219', 0, '2022-01-11 23:24:49.928295', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a2fb-6f4f-4bfa8fa068d1', '3a015be9-e28d-cde7-5f69-db8cd286e924', '979f2b81-5d74-45d4-88df-ba3a57e13fca', 0, '2022-01-11 23:24:49.986988', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a57e-d562-3632533c1099', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'a315efd7-1968-4d6a-b0e7-fd546470557f', 0, '2022-01-11 23:24:49.927322', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a8cc-a8e4-50bc49acebca', '3a015be9-e28d-cde7-5f69-db8cd286e924', '6af2f3c1-03a3-4011-aaab-3c79613874e5', 0, '2022-01-11 23:24:49.927625', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-a9d2-b10f-a16863f79d70', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'bdb4c143-e275-450e-94c0-6a9ad846b383', 0, '2022-01-11 23:24:49.988593', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-aa21-31f3-b56eec1f7de8', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'fd117c03-4be9-434a-b22f-d1d1b1e81af8', 0, '2022-01-11 23:24:49.988656', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-ad1a-c3d6-8e9bf6ea37cd', '3a015be9-e28d-cde7-5f69-db8cd286e924', '6102e52c-e75f-4622-8757-6fb3fe69f5bb', 0, '2022-01-11 23:24:49.927794', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-b4d2-5074-37773b594b91', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'cd9aa62d-f131-4433-adef-2c8619f252e6', 0, '2022-01-11 23:24:49.928748', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-bd56-42c8-8ecb6b1b04c1', '3a015be9-e28d-cde7-5f69-db8cd286e924', '0c46425c-a46f-4088-9c72-94b58ae62ca3', 0, '2022-01-11 23:24:49.989635', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-bdaf-d2c4-ec8a1ddc6b9b', '3a015be9-e28d-cde7-5f69-db8cd286e924', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', 0, '2022-01-11 23:24:49.928702', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-be1a-ab72-c8f4ae1a2fbb', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 0, '2022-01-11 23:24:49.988719', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-be6e-cbba-3e73124d660c', '3a015be9-e28d-cde7-5f69-db8cd286e924', '5f00b624-8eee-4185-b63b-f71c488e49a0', 0, '2022-01-11 23:24:49.988818', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-c010-4f5e-e9dd2095afb4', '3a015be9-e28d-cde7-5f69-db8cd286e924', '4b78adeb-7446-4c17-a6c1-479c12574e68', 0, '2022-01-11 23:24:49.927691', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-c0a6-6454-2fbe5ada3b14', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'ce697a88-0fdc-4f8d-b26e-46468b28b7b0', 0, '2022-01-11 23:24:49.986845', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-caea-f558-574ee36a44b6', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'e8b3762f-2540-40e0-8160-62e388b06af1', 0, '2022-01-11 23:24:49.928187', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-cf2b-bd8f-ace3b6fadd59', '3a015be9-e28d-cde7-5f69-db8cd286e924', '3a0156b4-6fbc-5aa3-fea1-538fcf3b198c', 0, '2022-01-11 23:24:49.988228', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-dc67-20ac-2fc75c75f8fd', '3a015be9-e28d-cde7-5f69-db8cd286e924', '6bb9562d-0203-48b2-b959-3419fb043892', 0, '2022-01-11 23:24:49.986797', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-e2f6-991f-640d2917b5e7', '3a015be9-e28d-cde7-5f69-db8cd286e924', '888eab40-58d6-487f-b3ba-b29c6b395561', 0, '2022-01-11 23:24:49.928530', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-e37a-c4d2-c5f9f237958f', '3a015be9-e28d-cde7-5f69-db8cd286e924', '90244a22-cfa3-44de-ae65-c3124a35c6bf', 0, '2022-01-11 23:24:49.927765', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-e903-8300-16be78a14ac7', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', 0, '2022-01-11 23:24:49.987994', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-ec35-9898-f63d758a0039', '3a015be9-e28d-cde7-5f69-db8cd286e924', '33580d92-7f92-4b5f-a3f2-84f5750895eb', 0, '2022-01-11 23:24:49.989418', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-f0c0-57c9-c17e6a375eaf', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'a5cec4b3-e414-4937-b339-4ceea83bdae2', 0, '2022-01-11 23:24:49.928332', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-f230-9fae-a39788d7b631', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'f3026862-6fd7-4fae-bda4-eafced533d03', 0, '2022-01-11 23:24:49.928015', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-f612-81fa-2831843ef8b2', '3a015be9-e28d-cde7-5f69-db8cd286e924', '1a65682d-8fa8-4557-81ab-25224889a154', 0, '2022-01-11 23:24:49.987037', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-f7b1-8fb3-3ee2c3e56473', '3a015be9-e28d-cde7-5f69-db8cd286e924', '841af2f7-b4ef-44ca-a1ba-81908c29a113', 0, '2022-01-11 23:24:49.927570', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-fafc-094e-9ddc98adccb9', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', 0, '2022-01-11 23:24:49.987086', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-fc17-51d1-6ed06154358d', '3a015be9-e28d-cde7-5f69-db8cd286e924', '268b006b-80b9-4bed-89b9-230e55536790', 0, '2022-01-11 23:24:49.927509', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-fd2c-dba3-e4a4517e4f13', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'b1784be9-9646-4c1a-92ca-5f059916333e', 0, '2022-01-11 23:24:49.927898', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-fdef-ffc9-f184cac7b4af', '3a015be9-e28d-cde7-5f69-db8cd286e924', 'e190106b-a741-44be-b115-61ad46d6254f', 0, '2022-01-11 23:24:49.986893', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-fe5e-1fdc-20194c926d03', '3a015be9-e28d-cde7-5f69-db8cd286e924', '3a0156b4-acf4-f9e9-67e5-097019a5ac6f', 0, '2022-01-11 23:24:49.988287', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bea-c180-ffdc-5769-1bb7b80c982c', '3a015be9-e28d-cde7-5f69-db8cd286e924', '7d4533f9-e1c5-429e-83bb-1a062656d1eb', 0, '2022-01-11 23:24:49.987246', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-1734-e7a8-91234fb2b14e', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'dea906df-7bc1-4995-ad65-6d46b29cec37', 0, '2022-01-11 23:29:20.282488', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-1c2e-4d5f-1ae71164a788', '3a015bed-f20f-d862-e1cc-8832f841a68e', '1ca033c8-2570-451a-93c4-6b94220a44a0', 0, '2022-01-11 23:29:20.282679', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-1eb7-ebd1-9a740f60280f', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'e8b3762f-2540-40e0-8160-62e388b06af1', 0, '2022-01-11 23:29:20.282548', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-247e-6859-c81aabbde13f', '3a015bed-f20f-d862-e1cc-8832f841a68e', '4cadb843-aa60-4370-a6a8-78a1ae56c545', 0, '2022-01-11 23:29:20.282807', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-2c6b-1f23-15c6abf41ec1', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'cd9aa62d-f131-4433-adef-2c8619f252e6', 0, '2022-01-11 23:29:20.282601', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-35ac-e830-0aa8f21728a5', '3a015bed-f20f-d862-e1cc-8832f841a68e', '0c0e1df7-3782-473b-a324-468e9fd83b98', 0, '2022-01-11 23:29:20.282926', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-51cd-c32f-cf42f2a09f2b', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', 0, '2022-01-11 23:29:20.282951', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-53e5-3931-9596548088d2', '3a015bed-f20f-d862-e1cc-8832f841a68e', '03258db8-67e1-4b72-a85e-bf142dacf043', 0, '2022-01-11 23:29:20.282640', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-56ce-5bfd-95891e027b97', '3a015bed-f20f-d862-e1cc-8832f841a68e', '29fd319a-b73e-406c-a646-78be18c8da62', 0, '2022-01-11 23:29:20.282740', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-5bcd-5120-34c0e30dd3ce', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'a5cec4b3-e414-4937-b339-4ceea83bdae2', 0, '2022-01-11 23:29:20.282854', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-6ad9-1a15-48d5811c741a', '3a015bed-f20f-d862-e1cc-8832f841a68e', '39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 0, '2022-01-11 23:29:20.282583', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-6c52-92b8-5cc426a50f07', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'b2832de9-0b0a-485f-8c96-023d830f9a72', 0, '2022-01-11 23:29:20.282978', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-6dcb-0eb3-cc3a56c5cb77', '3a015bed-f20f-d862-e1cc-8832f841a68e', '83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', 0, '2022-01-11 23:29:20.283004', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-717f-1342-0b504f1aa1ad', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'a315efd7-1968-4d6a-b0e7-fd546470557f', 0, '2022-01-11 23:29:20.282418', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-856c-d878-baff92af02e1', '3a015bed-f20f-d862-e1cc-8832f841a68e', '6d75765e-8ab8-44dd-a0f3-018bacee0803', 0, '2022-01-11 23:29:20.282566', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-9831-8005-d4f518acda40', '3a015bed-f20f-d862-e1cc-8832f841a68e', '33580d92-7f92-4b5f-a3f2-84f5750895eb', 0, '2022-01-11 23:29:20.283059', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-9a9d-3c22-a657c9f7f6c7', '3a015bed-f20f-d862-e1cc-8832f841a68e', '5f00b624-8eee-4185-b63b-f71c488e49a0', 0, '2022-01-11 23:29:20.282901', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-9acb-ea9b-571932d10571', '3a015bed-f20f-d862-e1cc-8832f841a68e', '888eab40-58d6-487f-b3ba-b29c6b395561', 0, '2022-01-11 23:29:20.282699', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-a130-5594-df6146630b37', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', 0, '2022-01-11 23:29:20.282784', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-ae00-6b0a-79290dbb32fa', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'd7311924-1c4a-4092-bfd2-a6c66f272f4f', 0, '2022-01-11 23:29:20.282659', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-bba7-3f72-dd31333d50cf', '3a015bed-f20f-d862-e1cc-8832f841a68e', '0c46425c-a46f-4088-9c72-94b58ae62ca3', 0, '2022-01-11 23:29:20.283115', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-c331-b74c-dd4490cc14d1', '3a015bed-f20f-d862-e1cc-8832f841a68e', '1784e0c4-4d49-4b20-ba4d-f65009403e15', 0, '2022-01-11 23:29:20.282720', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-cf49-f6a0-4bfc3968120a', '3a015bed-f20f-d862-e1cc-8832f841a68e', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', 0, '2022-01-11 23:29:20.282620', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-d243-6deb-8da046afaab1', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'bbad7070-c296-41e0-bfb5-8386356b4d0e', 0, '2022-01-11 23:29:20.282762', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-d8c7-8d7a-372ce72eb757', '3a015bed-f20f-d862-e1cc-8832f841a68e', '268b006b-80b9-4bed-89b9-230e55536790', 0, '2022-01-11 23:29:20.282532', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-dcec-363c-a679034ce8d8', '3a015bed-f20f-d862-e1cc-8832f841a68e', '5e4a9cb4-ca3c-452c-8b66-0af587d79934', 0, '2022-01-11 23:29:20.283087', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-e16f-be14-2e2c334b4045', '3a015bed-f20f-d862-e1cc-8832f841a68e', '805dbab1-769c-4fce-a626-36c6abd6b219', 0, '2022-01-11 23:29:20.282830', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-e570-0657-fb23e88f966f', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'c4b50a17-35db-4b1c-b970-066979de63b1', 0, '2022-01-11 23:29:20.283031', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-f1a4-8ff1-9bf0ddd63446', '3a015bed-f20f-d862-e1cc-8832f841a68e', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 0, '2022-01-11 23:29:20.282877', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('3a015bee-e19a-f1fa-7295-f7196039c7d5', '3a015bed-f20f-d862-e1cc-8832f841a68e', '841af2f7-b4ef-44ca-a1ba-81908c29a113', 0, '2022-01-11 23:29:20.282515', '3a015be9-e27c-ad59-1a55-c1303e1b9671');
INSERT INTO `Ad_Role_Permission` VALUES ('5312065f-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '001e7b5b-dfe7-48fc-9ffe-9bbd627acef4', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53120d9a-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '04cb1793-0bd8-4d75-8c06-288194ddb8e1', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53120e02-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '0c0e1df7-3782-473b-a324-468e9fd83b98', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53120e62-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '0c46425c-a46f-4088-9c72-94b58ae62ca3', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53120fbe-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '1d4ecde9-082c-40fd-84cd-8bf87626a747', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121070-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '20b40852-60e9-4862-8069-bb44ceaf859c', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531210c1-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '26210b10-be46-44b6-9d1d-9e8eb1343174', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531211ba-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '296469a4-2793-484f-8bc8-a5287ab1efe1', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312128b-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '2f35c37a-3eeb-49e2-811b-025eba5dc2b7', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531212dc-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '31ebfd6b-8cab-4850-baf7-7f778264e03a', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312133a-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '33580d92-7f92-4b5f-a3f2-84f5750895eb', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312138c-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '359e254e-1c03-471a-9f77-67f01d6f3de2', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312142b-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '4175b221-53d4-44d2-9d5a-a450d8b66625', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121480-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '451f1861-f4d2-4133-ae08-e0270055ff95', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531214ce-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '45843eed-89e0-4298-b26b-ab379e4dac0a', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312151a-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '47210210-2a2f-413b-bbd7-5fe864226bd5', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312156e-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '4b78adeb-7446-4c17-a6c1-479c12574e68', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531215be-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '4c002c85-569e-4677-9c3a-d8cc1cc0579c', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121668-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '4f0623dd-daf4-43c5-8cc1-a4660978c0c2', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531216b5-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '50ab2705-1b52-458a-9091-29610fcc8b50', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121752-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '5d161428-85aa-4964-9f22-2884814b9df4', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312179d-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '5e4a9cb4-ca3c-452c-8b66-0af587d79934', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531217f3-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '5f00b624-8eee-4185-b63b-f71c488e49a0', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121843-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '5fb50010-de89-421b-b4ae-cc436bf6c6df', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531218a2-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '6102e52c-e75f-4622-8757-6fb3fe69f5bb', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531218f3-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '632edcd7-adf1-46c6-924b-80dfa6afbee7', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121963-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '69afce87-c278-4f26-97ad-09588dd94757', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531219dc-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '6af2f3c1-03a3-4011-aaab-3c79613874e5', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121a49-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '6b4d15e3-96d0-45b8-924c-8630bba431b7', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121aad-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '6bb9562d-0203-48b2-b959-3419fb043892', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121b0c-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '6d75765e-8ab8-44dd-a0f3-018bacee0803', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121bf8-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '72912d72-56cc-46ab-9f0b-54c0fc8861c9', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121c59-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121ca7-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '7d4533f9-e1c5-429e-83bb-1a062656d1eb', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121cf5-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121d41-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '7dc79249-4232-4d8c-a181-d9a7d2c2e805', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121d91-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121e33-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121eca-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '8461d2ca-db06-4d93-808b-9246641869a1', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53121f19-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '85d93df9-c52f-4dd0-91fa-8d38552618c4', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531221ca-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '883d5091-9e35-43b5-aa48-fac931edaa78', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122291-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '894bb503-3111-47c7-8593-b9089f51c704', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531222df-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '894e7dac-f116-4054-bb31-45a55bd479ac', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312232c-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122376-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '90244a22-cfa3-44de-ae65-c3124a35c6bf', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531223c0-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '90ad8b53-75ce-470d-8e5d-8a507cb21832', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122411-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '913a485c-0770-4fa5-83c9-fa523e3c2815', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122464-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '93c50be8-9d46-4a6d-84aa-29407b25cd05', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531224b1-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '95da157a-52c3-40f3-b6a6-de70d99a793e', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122551-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '983cb8c2-994c-4642-b84a-bace084e4382', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312259e-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '996dbc69-8e6b-42d2-b488-6f0c31f6fb8f', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531225e9-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '99e98331-f83a-463e-9b37-23d1d428fb44', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122632-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '9a20843a-cb44-4d6d-a6bb-1a1cbc4cec15', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312267c-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', '9dacac88-a65d-42ef-8afa-c127377433f7', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312279e-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'a6ba585b-6a1d-4fd5-bae6-d87d875eb00b', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531227e8-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'ac3e944c-46e4-41d6-b2bd-74b35b044bed', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312287e-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'b1784be9-9646-4c1a-92ca-5f059916333e', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531228c9-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'b2832de9-0b0a-485f-8c96-023d830f9a72', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122915-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('5312296a-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531229b4-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'b9b07aef-dd95-4b58-a8bd-ec0a32c06887', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531229ff-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'bb8263f1-0068-489b-b9b4-3cba60f19d0f', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122a95-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'bdb4c143-e275-450e-94c0-6a9ad846b383', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122adf-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'bf7600d8-8c5b-41e2-b4ee-54d775557c17', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122b27-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'c4b50a17-35db-4b1c-b970-066979de63b1', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122b72-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'c4eb7338-f37d-4672-bb4a-f312b7935c65', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122bc2-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'c54f241c-2175-45bd-b9c8-42733c6af1c0', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122c0d-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'c8243893-eb45-4d12-a473-407543bfdb7d', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122ca0-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122ceb-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'ce697a88-0fdc-4f8d-b26e-46468b28b7b0', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122d83-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'dbf51323-2c4a-4996-8f16-b2a2d760db29', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122dcf-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122e1a-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'ddc75f36-425e-44e4-a525-03c5580506c3', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122eb2-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'df21ad15-cdf2-48ca-8081-d4f8ce971c7f', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122efd-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'e190106b-a741-44be-b115-61ad46d6254f', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122f49-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'e2031d9f-0c2e-4249-802f-924c1cf21424', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122f95-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'e4d7bdf6-4412-4a0d-9dd6-900b2abaa01e', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53122fdf-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'e8b3762f-2540-40e0-8160-62e388b06af1', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53123029-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'ee8af740-7253-401a-b811-fd62a85620a9', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53123076-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'f3026862-6fd7-4fae-bda4-eafced533d03', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53123124-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('53123179-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'fd117c03-4be9-434a-b22f-d1d1b1e81af8', 0, '2021-10-01 18:28:31.000000', NULL);
INSERT INTO `Ad_Role_Permission` VALUES ('531231c4-22a2-11ec-adaf-0242ac110002', '808fa030-49d5-408b-82a6-5835de3209e4', 'fe42b8d9-429a-4082-a8d6-7f5667d0af61', 0, '2021-10-01 18:28:31.000000', NULL);

-- ----------------------------
-- Table structure for Ad_Tenant_Permission
-- ----------------------------
DROP TABLE IF EXISTS `Ad_Tenant_Permission`;
CREATE TABLE `Ad_Tenant_Permission`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `PermissionId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '权限Id',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_PermissionId2`(`PermissionId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '租户权限表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_Tenant_Permission
-- ----------------------------
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-0131-7925-d42144709dbd', '1f18ab4d-dd40-4aa4-9528-ae8a7e1bb65a', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892889', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-036e-f770-bf79a9b9c0a6', 'dbf51323-2c4a-4996-8f16-b2a2d760db29', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894077', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-0ac6-f390-b4808bd1b207', 'bdb4c143-e275-450e-94c0-6a9ad846b383', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894249', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-13aa-7075-6989e5d14c4a', 'd7311924-1c4a-4092-bfd2-a6c66f272f4f', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892527', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-1bd1-0c6e-a9759de304fb', 'dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893694', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-1c52-288e-e8bba42002bb', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893019', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-1e88-903c-8f7abee3e0e3', 'e8b3762f-2540-40e0-8160-62e388b06af1', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891994', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-1f2f-fdbe-5b9b2e9122d4', '7d4533f9-e1c5-429e-83bb-1a062656d1eb', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893154', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-216b-155d-2cafbad9f67a', 'fe42b8d9-429a-4082-a8d6-7f5667d0af61', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893590', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-2248-7860-40e6454562b4', '1a65682d-8fa8-4557-81ab-25224889a154', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892976', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-24c9-ac15-2f6e2dcff93c', '04cb1793-0bd8-4d75-8c06-288194ddb8e1', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891652', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-2722-bb30-36d5b5e5d4bd', 'a315efd7-1968-4d6a-b0e7-fd546470557f', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.889854', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-28a4-e5c8-df02ec08ef39', 'b1784be9-9646-4c1a-92ca-5f059916333e', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891776', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-2d12-b7e0-68b085bb5d99', '3a0156b2-4356-2635-bb52-2d0a6f30afbe', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891826', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-2d44-e75b-15f1d8ca8ba9', '983cb8c2-994c-4642-b84a-bace084e4382', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892566', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-303b-cc58-5224d1ed9fb0', '268b006b-80b9-4bed-89b9-230e55536790', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.889986', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-349b-1580-1d964b48b00c', 'df21ad15-cdf2-48ca-8081-d4f8ce971c7f', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891886', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-35e8-6ab9-ad37c405ce3c', '296469a4-2793-484f-8bc8-a5287ab1efe1', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891800', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-383b-5f2b-80948973cbd5', '45843eed-89e0-4298-b26b-ab379e4dac0a', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894134', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-4083-9fb8-5508747ca476', '3a0156b4-367c-0eec-9545-b882b323fba7', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893856', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-43c3-c5a0-fcb7f4effa77', '5f00b624-8eee-4185-b63b-f71c488e49a0', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894427', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-43d6-7fc0-3c02d474dc32', '33580d92-7f92-4b5f-a3f2-84f5750895eb', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894800', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-43eb-7637-b90768169508', '883d5091-9e35-43b5-aa48-fac931edaa78', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892684', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-4446-a742-250dd4aeb990', '39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892417', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-4fcc-1048-fafdd6795511', '0c0e1df7-3782-473b-a324-468e9fd83b98', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894487', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-504d-a668-f7013de5ef25', '979f2b81-5d74-45d4-88df-ba3a57e13fca', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892932', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-540d-8f94-aad7aee43735', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892145', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-5529-7675-2895b2eeccdd', '894e7dac-f116-4054-bb31-45a55bd479ac', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894191', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-578b-84bc-803283a0ceb6', '6102e52c-e75f-4622-8757-6fb3fe69f5bb', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891695', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-5a93-7038-250e49b2aaf5', '7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893748', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-66d1-9b15-621d4e378cec', '31ebfd6b-8cab-4850-baf7-7f778264e03a', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891914', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-6a43-996b-6ccb5a38f7d4', 'fd117c03-4be9-434a-b22f-d1d1b1e81af8', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894307', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-6c86-e5e3-f639c96a4c89', '4b78adeb-7446-4c17-a6c1-479c12574e68', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891632', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-7290-542e-5507480a138a', '7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892645', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-73c9-fc38-1efdc2a3bc08', 'cd9aa62d-f131-4433-adef-2c8619f252e6', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892491', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-763c-fabc-86b22edac65c', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894548', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-7bab-bf5b-7b4abec68f50', '1784e0c4-4d49-4b20-ba4d-f65009403e15', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892176', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-7daa-fdde-abf8030f78f4', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892453', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-7dc2-1b72-3fd9b8f969ba', '0c46425c-a46f-4088-9c72-94b58ae62ca3', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894929', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-7e43-5254-abd112b35613', '7dc79249-4232-4d8c-a181-d9a7d2c2e805', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892606', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-9064-78f5-c3f6e14d6c6e', '3a0156b4-acf4-f9e9-67e5-097019a5ac6f', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893966', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-926d-0320-313856514829', '20b40852-60e9-4862-8069-bb44ceaf859c', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891941', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-981d-3a07-d234be65016c', '1ca033c8-2570-451a-93c4-6b94220a44a0', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892208', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-9c01-379d-baddfee5fe62', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891612', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-9f44-d7cf-a2d52ab82f2f', '5e4a9cb4-ca3c-452c-8b66-0af587d79934', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894864', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a122-5c12-c34cf5241a28', '4cadb843-aa60-4370-a6a8-78a1ae56c545', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892053', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a1f4-83b6-5d45eaf56eb5', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893064', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a2e0-2778-730c64500903', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891968', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a3b2-c951-2c02bf7fff89', '888eab40-58d6-487f-b3ba-b29c6b395561', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892304', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a5b3-145e-7f5cf0206d77', '805dbab1-769c-4fce-a626-36c6abd6b219', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892083', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a670-b790-8fe66deae3dd', 'bf7600d8-8c5b-41e2-b4ee-54d775557c17', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893539', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-a7e2-b0d5-04f29597e098', '3a0156b4-e876-773a-f543-8a3e7cd08988', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894022', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-ae32-3849-3198b7856d75', 'c4b50a17-35db-4b1c-b970-066979de63b1', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894736', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-b369-48fd-33e0bd586666', '83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894671', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-b3e5-594e-f1db5a0b92e7', '26210b10-be46-44b6-9d1d-9e8eb1343174', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893108', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-b626-2d3b-ad417efd56e7', '6bb9562d-0203-48b2-b959-3419fb043892', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892745', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-b7b2-ba0a-5f2c3e1ab670', '29fd319a-b73e-406c-a646-78be18c8da62', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892241', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-bc27-5d6e-b90f3a2201ef', '3a0156b3-68df-63a9-a473-2e03b046653a', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893802', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-c09f-3b9a-cec4a4aeb090', '03258db8-67e1-4b72-a85e-bf142dacf043', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892381', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-c126-8d9b-a58d8c64596b', '90244a22-cfa3-44de-ae65-c3124a35c6bf', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891673', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-c79d-0c9a-add039f3c92d', 'dea906df-7bc1-4995-ad65-6d46b29cec37', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891569', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-c809-3283-e262bdad0ab6', 'f3026862-6fd7-4fae-bda4-eafced533d03', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891858', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-cea6-2a2f-707484bd861c', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894366', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-cf80-38dc-cbbbda420a3a', 'a5cec4b3-e414-4937-b339-4ceea83bdae2', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892114', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-d0fe-5b1b-4b83ae3207b5', 'b2832de9-0b0a-485f-8c96-023d830f9a72', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.894610', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-d845-7d9a-0627ee241fec', '6d75765e-8ab8-44dd-a0f3-018bacee0803', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892023', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-dc2f-737f-81c0b8f70bf0', 'ee8af740-7253-401a-b811-fd62a85620a9', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891719', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-dda3-c2af-7a0c2929b41f', '894bb503-3111-47c7-8593-b9089f51c704', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893641', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-e2f4-f07c-afba63b3a1f9', '6af2f3c1-03a3-4011-aaab-3c79613874e5', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891589', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-eaa1-26b3-361224e28d41', 'bbad7070-c296-41e0-bfb5-8386356b4d0e', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892345', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-ec10-aa95-13604954711c', '3a0156b4-6fbc-5aa3-fea1-538fcf3b198c', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.893910', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-f423-bb29-e994fcfca75d', 'e190106b-a741-44be-b115-61ad46d6254f', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892845', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-f894-2d1e-0cb66e865e58', 'ce697a88-0fdc-4f8d-b26e-46468b28b7b0', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.892793', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('3a015bea-c158-feb2-824a-26726cc95c76', '841af2f7-b4ef-44ca-a1ba-81908c29a113', 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:24:49.891537', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326010-22a2-11ec-adaf-0242ac110002', '001e7b5b-dfe7-48fc-9ffe-9bbd627acef4', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32662e-22a2-11ec-adaf-0242ac110002', '03258db8-67e1-4b72-a85e-bf142dacf043', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326788-22a2-11ec-adaf-0242ac110002', '04cb1793-0bd8-4d75-8c06-288194ddb8e1', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3267ec-22a2-11ec-adaf-0242ac110002', '0c0e1df7-3782-473b-a324-468e9fd83b98', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326843-22a2-11ec-adaf-0242ac110002', '0c46425c-a46f-4088-9c72-94b58ae62ca3', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3268a0-22a2-11ec-adaf-0242ac110002', '1784e0c4-4d49-4b20-ba4d-f65009403e15', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3268f9-22a2-11ec-adaf-0242ac110002', '1a65682d-8fa8-4557-81ab-25224889a154', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32694c-22a2-11ec-adaf-0242ac110002', '1ca033c8-2570-451a-93c4-6b94220a44a0', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3269a4-22a2-11ec-adaf-0242ac110002', '1d4ecde9-082c-40fd-84cd-8bf87626a747', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326a04-22a2-11ec-adaf-0242ac110002', '1f18ab4d-dd40-4aa4-9528-ae8a7e1bb65a', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326a56-22a2-11ec-adaf-0242ac110002', '20b40852-60e9-4862-8069-bb44ceaf859c', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326aca-22a2-11ec-adaf-0242ac110002', '26210b10-be46-44b6-9d1d-9e8eb1343174', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326b1f-22a2-11ec-adaf-0242ac110002', '268b006b-80b9-4bed-89b9-230e55536790', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326b6c-22a2-11ec-adaf-0242ac110002', '296469a4-2793-484f-8bc8-a5287ab1efe1', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326bbd-22a2-11ec-adaf-0242ac110002', '29fd319a-b73e-406c-a646-78be18c8da62', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326c08-22a2-11ec-adaf-0242ac110002', '2f35c37a-3eeb-49e2-811b-025eba5dc2b7', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326c56-22a2-11ec-adaf-0242ac110002', '31ebfd6b-8cab-4850-baf7-7f778264e03a', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326caf-22a2-11ec-adaf-0242ac110002', '33580d92-7f92-4b5f-a3f2-84f5750895eb', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326cfe-22a2-11ec-adaf-0242ac110002', '359e254e-1c03-471a-9f77-67f01d6f3de2', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326d4a-22a2-11ec-adaf-0242ac110002', '39353fd8-19f2-4156-9fbb-f38bd4cf3c27', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326d99-22a2-11ec-adaf-0242ac110002', '4175b221-53d4-44d2-9d5a-a450d8b66625', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326de9-22a2-11ec-adaf-0242ac110002', '451f1861-f4d2-4133-ae08-e0270055ff95', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326e3b-22a2-11ec-adaf-0242ac110002', '45843eed-89e0-4298-b26b-ab379e4dac0a', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326e85-22a2-11ec-adaf-0242ac110002', '47210210-2a2f-413b-bbd7-5fe864226bd5', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326ed2-22a2-11ec-adaf-0242ac110002', '4b78adeb-7446-4c17-a6c1-479c12574e68', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326f24-22a2-11ec-adaf-0242ac110002', '4c002c85-569e-4677-9c3a-d8cc1cc0579c', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326f79-22a2-11ec-adaf-0242ac110002', '4cadb843-aa60-4370-a6a8-78a1ae56c545', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e326fc7-22a2-11ec-adaf-0242ac110002', '4f0623dd-daf4-43c5-8cc1-a4660978c0c2', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327018-22a2-11ec-adaf-0242ac110002', '50ab2705-1b52-458a-9091-29610fcc8b50', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327067-22a2-11ec-adaf-0242ac110002', '56fd5d2d-fcda-4961-88a6-10b46c08ea53', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3270b4-22a2-11ec-adaf-0242ac110002', '5d161428-85aa-4964-9f22-2884814b9df4', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3270fe-22a2-11ec-adaf-0242ac110002', '5e4a9cb4-ca3c-452c-8b66-0af587d79934', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327148-22a2-11ec-adaf-0242ac110002', '5f00b624-8eee-4185-b63b-f71c488e49a0', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327192-22a2-11ec-adaf-0242ac110002', '5fb50010-de89-421b-b4ae-cc436bf6c6df', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3271f7-22a2-11ec-adaf-0242ac110002', '6102e52c-e75f-4622-8757-6fb3fe69f5bb', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327246-22a2-11ec-adaf-0242ac110002', '632edcd7-adf1-46c6-924b-80dfa6afbee7', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327292-22a2-11ec-adaf-0242ac110002', '69afce87-c278-4f26-97ad-09588dd94757', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3272de-22a2-11ec-adaf-0242ac110002', '6af2f3c1-03a3-4011-aaab-3c79613874e5', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327328-22a2-11ec-adaf-0242ac110002', '6b4d15e3-96d0-45b8-924c-8630bba431b7', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327371-22a2-11ec-adaf-0242ac110002', '6bb9562d-0203-48b2-b959-3419fb043892', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32747f-22a2-11ec-adaf-0242ac110002', '6d75765e-8ab8-44dd-a0f3-018bacee0803', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3274cd-22a2-11ec-adaf-0242ac110002', '72912d72-56cc-46ab-9f0b-54c0fc8861c9', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327515-22a2-11ec-adaf-0242ac110002', '7c956386-d014-4721-b9d0-b3cdf9b41bc1', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32755f-22a2-11ec-adaf-0242ac110002', '7d4533f9-e1c5-429e-83bb-1a062656d1eb', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3275af-22a2-11ec-adaf-0242ac110002', '7dc02a9c-3d48-4397-b1b4-b4d4e7a43e71', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3275fa-22a2-11ec-adaf-0242ac110002', '7dc79249-4232-4d8c-a181-d9a7d2c2e805', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327642-22a2-11ec-adaf-0242ac110002', '7f27e8e3-a7b6-42bc-a4d8-d308caca3b49', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327691-22a2-11ec-adaf-0242ac110002', '805dbab1-769c-4fce-a626-36c6abd6b219', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3276db-22a2-11ec-adaf-0242ac110002', '83e04ddf-3c42-4bdc-8ef2-fc4470957dbf', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327727-22a2-11ec-adaf-0242ac110002', '841af2f7-b4ef-44ca-a1ba-81908c29a113', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327777-22a2-11ec-adaf-0242ac110002', '8461d2ca-db06-4d93-808b-9246641869a1', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3277cb-22a2-11ec-adaf-0242ac110002', '85d93df9-c52f-4dd0-91fa-8d38552618c4', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327837-22a2-11ec-adaf-0242ac110002', '883d5091-9e35-43b5-aa48-fac931edaa78', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327886-22a2-11ec-adaf-0242ac110002', '888eab40-58d6-487f-b3ba-b29c6b395561', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3278d0-22a2-11ec-adaf-0242ac110002', '894bb503-3111-47c7-8593-b9089f51c704', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32791a-22a2-11ec-adaf-0242ac110002', '894e7dac-f116-4054-bb31-45a55bd479ac', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327965-22a2-11ec-adaf-0242ac110002', '8a7ebd33-7bad-4b8a-aa3d-1f78983d3c5a', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3279af-22a2-11ec-adaf-0242ac110002', '90244a22-cfa3-44de-ae65-c3124a35c6bf', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3279f7-22a2-11ec-adaf-0242ac110002', '90ad8b53-75ce-470d-8e5d-8a507cb21832', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327a40-22a2-11ec-adaf-0242ac110002', '913a485c-0770-4fa5-83c9-fa523e3c2815', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327a8d-22a2-11ec-adaf-0242ac110002', '93c50be8-9d46-4a6d-84aa-29407b25cd05', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327ad7-22a2-11ec-adaf-0242ac110002', '95da157a-52c3-40f3-b6a6-de70d99a793e', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327b24-22a2-11ec-adaf-0242ac110002', '979f2b81-5d74-45d4-88df-ba3a57e13fca', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327b6d-22a2-11ec-adaf-0242ac110002', '983cb8c2-994c-4642-b84a-bace084e4382', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327bbc-22a2-11ec-adaf-0242ac110002', '996dbc69-8e6b-42d2-b488-6f0c31f6fb8f', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327c07-22a2-11ec-adaf-0242ac110002', '99e98331-f83a-463e-9b37-23d1d428fb44', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327c4f-22a2-11ec-adaf-0242ac110002', '9a20843a-cb44-4d6d-a6bb-1a1cbc4cec15', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327c98-22a2-11ec-adaf-0242ac110002', '9dacac88-a65d-42ef-8afa-c127377433f7', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327d14-22a2-11ec-adaf-0242ac110002', 'a315efd7-1968-4d6a-b0e7-fd546470557f', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327d63-22a2-11ec-adaf-0242ac110002', 'a5cec4b3-e414-4937-b339-4ceea83bdae2', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327dac-22a2-11ec-adaf-0242ac110002', 'a6ba585b-6a1d-4fd5-bae6-d87d875eb00b', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327df5-22a2-11ec-adaf-0242ac110002', 'ac3e944c-46e4-41d6-b2bd-74b35b044bed', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327e44-22a2-11ec-adaf-0242ac110002', 'b008bbfc-be32-4be4-af14-df8f6b39e72d', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327e8f-22a2-11ec-adaf-0242ac110002', 'b1784be9-9646-4c1a-92ca-5f059916333e', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327ed8-22a2-11ec-adaf-0242ac110002', 'b2832de9-0b0a-485f-8c96-023d830f9a72', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327f1f-22a2-11ec-adaf-0242ac110002', 'b6704ad3-51d5-4b4e-b4b7-580f83197ad7', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327f6f-22a2-11ec-adaf-0242ac110002', 'b9a8c740-49d3-4dcb-8840-500ea0e21634', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e327fba-22a2-11ec-adaf-0242ac110002', 'b9b07aef-dd95-4b58-a8bd-ec0a32c06887', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328002-22a2-11ec-adaf-0242ac110002', 'bb8263f1-0068-489b-b9b4-3cba60f19d0f', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32804c-22a2-11ec-adaf-0242ac110002', 'bbad7070-c296-41e0-bfb5-8386356b4d0e', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328098-22a2-11ec-adaf-0242ac110002', 'bdb4c143-e275-450e-94c0-6a9ad846b383', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3280e0-22a2-11ec-adaf-0242ac110002', 'bf7600d8-8c5b-41e2-b4ee-54d775557c17', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328129-22a2-11ec-adaf-0242ac110002', 'c4b50a17-35db-4b1c-b970-066979de63b1', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328171-22a2-11ec-adaf-0242ac110002', 'c4eb7338-f37d-4672-bb4a-f312b7935c65', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3281bd-22a2-11ec-adaf-0242ac110002', 'c54f241c-2175-45bd-b9c8-42733c6af1c0', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328206-22a2-11ec-adaf-0242ac110002', 'c8243893-eb45-4d12-a473-407543bfdb7d', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32824f-22a2-11ec-adaf-0242ac110002', 'cd9aa62d-f131-4433-adef-2c8619f252e6', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328298-22a2-11ec-adaf-0242ac110002', 'cdfe6be5-ef45-4640-8cf1-b719c3b894c8', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3282e4-22a2-11ec-adaf-0242ac110002', 'ce697a88-0fdc-4f8d-b26e-46468b28b7b0', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32832e-22a2-11ec-adaf-0242ac110002', 'd7311924-1c4a-4092-bfd2-a6c66f272f4f', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328376-22a2-11ec-adaf-0242ac110002', 'dbf51323-2c4a-4996-8f16-b2a2d760db29', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3283be-22a2-11ec-adaf-0242ac110002', 'dc6cb7d8-17ae-46a2-9f5f-0fc9e42cbdc2', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328409-22a2-11ec-adaf-0242ac110002', 'ddc75f36-425e-44e4-a525-03c5580506c3', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328452-22a2-11ec-adaf-0242ac110002', 'dea906df-7bc1-4995-ad65-6d46b29cec37', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32849c-22a2-11ec-adaf-0242ac110002', 'df21ad15-cdf2-48ca-8081-d4f8ce971c7f', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3284e4-22a2-11ec-adaf-0242ac110002', 'e190106b-a741-44be-b115-61ad46d6254f', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32852f-22a2-11ec-adaf-0242ac110002', 'e2031d9f-0c2e-4249-802f-924c1cf21424', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32857a-22a2-11ec-adaf-0242ac110002', 'e4d7bdf6-4412-4a0d-9dd6-900b2abaa01e', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3285c3-22a2-11ec-adaf-0242ac110002', 'e8b3762f-2540-40e0-8160-62e388b06af1', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32860c-22a2-11ec-adaf-0242ac110002', 'ee8af740-7253-401a-b811-fd62a85620a9', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e328656-22a2-11ec-adaf-0242ac110002', 'f3026862-6fd7-4fae-bda4-eafced533d03', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3286a5-22a2-11ec-adaf-0242ac110002', 'f60f1676-262f-4c1b-9ce7-e858cecf3270', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e3286f0-22a2-11ec-adaf-0242ac110002', 'fd117c03-4be9-434a-b22f-d1d1b1e81af8', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);
INSERT INTO `Ad_Tenant_Permission` VALUES ('7e32873a-22a2-11ec-adaf-0242ac110002', 'fe42b8d9-429a-4082-a8d6-7f5667d0af61', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-10-01 18:29:43.000000', NULL);

-- ----------------------------
-- Table structure for Ad_User
-- ----------------------------
DROP TABLE IF EXISTS `Ad_User`;
CREATE TABLE `Ad_User`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '账号',
  `Password` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '密码',
  `NickName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '昵称',
  `Avatar` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '头像',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  `Enabled` tinyint(1) NOT NULL DEFAULT 0 COMMENT '启用',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_User
-- ----------------------------
INSERT INTO `Ad_User` VALUES ('39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', 'user', 'E1ADC3949BA59ABBE56E057F2F883E', '平台用户', 'http://localhost:9099/upload/admin/avatar/2022-01-02/39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4/1477530745105944576.png', 'fasda', 0, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-09-25 16:39:58.000000', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-02 14:43:29.396297', 1);
INSERT INTO `Ad_User` VALUES ('3a015be9-e27c-ad59-1a55-c1303e1b9671', 'morning', 'E1ADC3949BA59ABBE56E057F2F883E', '段晨曦', NULL, NULL, 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:23:52.843919', NULL, NULL, NULL, 1);
INSERT INTO `Ad_User` VALUES ('3a015bee-771e-a652-825e-b6315b3e129d', '17674705062', 'E1ADC3949BA59ABBE56E057F2F883E', '段段', NULL, NULL, 0, '3a015be9-e1d8-1fab-3e24-ef879c72abae', '2022-01-11 23:28:53.145728', '3a015be9-e27c-ad59-1a55-c1303e1b9671', NULL, NULL, 1);

-- ----------------------------
-- Table structure for Ad_User_Role
-- ----------------------------
DROP TABLE IF EXISTS `Ad_User_Role`;
CREATE TABLE `Ad_User_Role`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '角色Id',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_RoleId1`(`RoleId`) USING BTREE,
  INDEX `IDX_UserId1`(`UserId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户角色表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_User_Role
-- ----------------------------
INSERT INTO `Ad_User_Role` VALUES ('3a002f1f-b20c-48ca-dba4-98dfcfddc623', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '808fa030-49d5-408b-82a6-5835de3209e4', 0, '2021-11-14 13:36:59.368054', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_User_Role` VALUES ('3a015be9-e29b-6188-568b-f1172b5dff90', '3a015be9-e27c-ad59-1a55-c1303e1b9671', '3a015be9-e28d-cde7-5f69-db8cd286e924', 0, '2022-01-11 23:23:52.865508', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4');
INSERT INTO `Ad_User_Role` VALUES ('3a015bee-779b-9c08-dedc-c641c0c10bc3', '3a015bee-771e-a652-825e-b6315b3e129d', '3a015bed-f20f-d862-e1cc-8832f841a68e', 0, '2022-01-11 23:28:53.147316', '3a015be9-e27c-ad59-1a55-c1303e1b9671');

-- ----------------------------
-- Table structure for Ad_View
-- ----------------------------
DROP TABLE IF EXISTS `Ad_View`;
CREATE TABLE `Ad_View`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '所属节点',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '视图命名',
  `Label` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '视图名称',
  `Path` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '视图路径',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '说明',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Cache` tinyint(1) NOT NULL COMMENT '缓存',
  `Sort` int NOT NULL COMMENT '排序',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_ParentId4`(`ParentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '视图管理表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Ad_View
-- ----------------------------
INSERT INTO `Ad_View` VALUES ('1a391e49-074a-4d65-b980-6564334bf609', '1c4b43c4-6764-4d96-9573-751336ccf7ee', 'Settins', '个人设置', 'account/settings', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.062370', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257529');
INSERT INTO `Ad_View` VALUES ('1c4b43c4-6764-4d96-9573-751336ccf7ee', '71bc8841-64cf-426f-95c6-4ff263189038', NULL, '个人管理', NULL, NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.031946', NULL, NULL, '2021-10-07 21:25:43.031962');
INSERT INTO `Ad_View` VALUES ('25d5d70c-60c3-458e-9cd4-d15e937c2e10', '71bc8841-64cf-426f-95c6-4ff263189038', NULL, '系统配置', NULL, NULL, 1, 1, 0, 0, '2021-10-07 21:25:42.996482', NULL, NULL, '2021-10-07 21:25:42.996497');
INSERT INTO `Ad_View` VALUES ('2ac46948-f51b-47da-a5d3-36786c2a350c', '8e9019de-08eb-4224-804c-e5c38c60dd7e', 'Employee', '员工管理', 'personnel/employee', '', 1, 1, 0, 0, '2021-10-07 21:25:43.561241', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257542');
INSERT INTO `Ad_View` VALUES ('3a01568d-1638-af39-d621-c83d64d70aa3', '00000000-0000-0000-0000-000000000000', '', '人事管理', '', '', 1, 1, 0, 0, '2022-01-10 22:24:25.280914', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_View` VALUES ('3a01568d-72a2-ff53-1a12-da797d3e784c', '3a01568d-1638-af39-d621-c83d64d70aa3', 'Position', '岗位管理', 'personnel/position', '', 1, 1, 0, 0, '2022-01-10 22:24:48.931473', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_View` VALUES ('3a01568d-b928-45da-7445-3d478c29cc7a', '3a01568d-1638-af39-d621-c83d64d70aa3', 'Organization', '部门管理', 'personnel/organization', '', 1, 1, 0, 0, '2022-01-10 22:25:06.979178', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_View` VALUES ('3a01568d-f415-2186-e2b5-0b368724ef56', '3a01568d-1638-af39-d621-c83d64d70aa3', 'Employee', '员工管理', 'personnel/employee', '', 1, 1, 0, 0, '2022-01-10 22:25:22.064984', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', NULL, NULL);
INSERT INTO `Ad_View` VALUES ('3a0156a5-ca71-7681-9482-6223fc23882a', '25d5d70c-60c3-458e-9cd4-d15e937c2e10', 'LowCodeTable', '低代码管理', 'admin/low-code/index', '低代码管理', 1, 1, 0, 0, '2022-01-10 22:51:24.270498', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2022-01-10 22:53:05.471454');
INSERT INTO `Ad_View` VALUES ('493a978a-ef3b-40b9-ad9b-c2e6421f6156', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'Tenant', '租户管理', 'admin/tenant', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.312349', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257564');
INSERT INTO `Ad_View` VALUES ('68cba127-8932-4c0e-b5d5-f6e18c877c8b', '8e9019de-08eb-4224-804c-e5c38c60dd7e', 'Organization', '部门管理', 'personnel/organization', '', 1, 1, 0, 0, '2021-10-07 21:25:43.444275', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257567');
INSERT INTO `Ad_View` VALUES ('70ae8835-4841-40ac-9e9f-56a2eb4d6bcc', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'Permission', '权限管理', 'admin/permission', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.227847', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257570');
INSERT INTO `Ad_View` VALUES ('71bc8841-64cf-426f-95c6-4ff263189038', '00000000-0000-0000-0000-000000000000', NULL, '平台管理', NULL, NULL, 1, 1, 0, 0, '2021-10-07 21:25:42.893546', NULL, NULL, '2021-10-07 21:25:42.893927');
INSERT INTO `Ad_View` VALUES ('7f267227-fb2c-420b-8928-d8862fc9f098', '8e9019de-08eb-4224-804c-e5c38c60dd7e', 'Position', '岗位管理', 'personnel/position', '', 1, 1, 0, 0, '2021-10-07 21:25:43.473028', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257576');
INSERT INTO `Ad_View` VALUES ('7fe57892-2f9e-4a6a-843e-7b048241abfc', '71bc8841-64cf-426f-95c6-4ff263189038', 'Home', '首页', 'admin/home', NULL, 1, 1, 0, 0, '2021-10-07 21:25:42.967238', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257581');
INSERT INTO `Ad_View` VALUES ('87a486b9-960c-4aea-b1c6-8ddb039028e1', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'User', '用户管理', 'admin/user', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.118467', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-27 23:45:48.842806');
INSERT INTO `Ad_View` VALUES ('8a29606d-92ed-47f4-b93a-ce86fdefd4ec', 'bd9b9042-d28e-4a38-8448-ef893387fbf4', 'LoginLog', '登录日志', 'admin/login-log', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.391672', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257587');
INSERT INTO `Ad_View` VALUES ('8e9019de-08eb-4224-804c-e5c38c60dd7e', '00000000-0000-0000-0000-000000000000', '', '人事管理', '', '', 1, 1, 0, 0, '2021-10-07 21:25:43.506568', NULL, NULL, '2021-10-07 21:25:43.506578');
INSERT INTO `Ad_View` VALUES ('9082f57f-7c5a-4bcd-a356-bb92a1252d7e', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'Role', '角色管理', 'admin/role', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.146324', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257589');
INSERT INTO `Ad_View` VALUES ('a541e567-8852-4101-9569-26e459abcbb5', '25d5d70c-60c3-458e-9cd4-d15e937c2e10', 'Dictionary', '数据字典', 'admin/dictionary/index', '数据字典', 1, 1, 0, 0, '2021-10-07 21:25:43.531721', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257592');
INSERT INTO `Ad_View` VALUES ('ac23e6c0-6794-4e48-9888-f851f0482476', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'RolePermission', '角色权限', 'admin/role-permission', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.257237', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257595');
INSERT INTO `Ad_View` VALUES ('bd9b9042-d28e-4a38-8448-ef893387fbf4', '71bc8841-64cf-426f-95c6-4ff263189038', NULL, '日志管理', NULL, '', 1, 1, 0, 0, '2021-10-07 21:25:43.337455', NULL, NULL, '2021-10-07 21:25:43.337467');
INSERT INTO `Ad_View` VALUES ('cde4e051-58cc-4e59-81cc-5a269821c2bc', 'bd9b9042-d28e-4a38-8448-ef893387fbf4', 'OprationLog', '操作日志', 'admin/opration-log', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.365655', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257597');
INSERT INTO `Ad_View` VALUES ('dcaf48b9-628f-41cb-b6cd-1d1e1bd9af93', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'Cache', '缓存管理', 'admin/cache', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.283299', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257600');
INSERT INTO `Ad_View` VALUES ('df912fd3-364d-415c-b036-2cf0a77c2f4c', '71bc8841-64cf-426f-95c6-4ff263189038', NULL, '权限管理', NULL, '', 1, 1, 0, 0, '2021-10-07 21:25:43.091789', NULL, NULL, '2021-10-07 21:25:43.091804');
INSERT INTO `Ad_View` VALUES ('e1f0ff14-ab77-425a-962e-74fdcfea5e18', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'AdminView', '视图管理', 'admin/view', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.199767', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257603');
INSERT INTO `Ad_View` VALUES ('eae826a2-dc69-4671-a8d4-c78c18396378', 'df912fd3-364d-415c-b036-2cf0a77c2f4c', 'Api', '接口管理', 'admin/api', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.173255', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257605');
INSERT INTO `Ad_View` VALUES ('eec2cbc9-23ee-47cf-a7e9-b3a69b14b897', '71bc8841-64cf-426f-95c6-4ff263189038', 'Document', '文档管理', 'admin/document', NULL, 1, 1, 0, 0, '2021-10-07 21:25:43.416440', NULL, '39fe9de4-4d5c-ced0-8dca-be0cecf1b5f4', '2021-12-17 15:59:31.257608');

-- ----------------------------
-- Table structure for Pe_Employee
-- ----------------------------
DROP TABLE IF EXISTS `Pe_Employee`;
CREATE TABLE `Pe_Employee`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000' COMMENT '用户Id',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '姓名',
  `NickName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '昵称',
  `Sex` int NOT NULL DEFAULT 0 COMMENT '性别',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '工号',
  `OrganizationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '主属部门Id',
  `PrimaryEmployeeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '主管Id',
  `PositionId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '职位Id',
  `Phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '手机号',
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮箱',
  `EntryTime` datetime NULL DEFAULT NULL COMMENT '入职时间',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_OrganizationId`(`OrganizationId`) USING BTREE,
  INDEX `IDX_PositionId`(`PositionId`) USING BTREE,
  INDEX `IDX_PrimaryEmployeeId`(`PrimaryEmployeeId`) USING BTREE,
  INDEX `IDX_UserId`(`UserId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '员工表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Pe_Employee
-- ----------------------------

-- ----------------------------
-- Table structure for Pe_Organization
-- ----------------------------
DROP TABLE IF EXISTS `Pe_Organization`;
CREATE TABLE `Pe_Organization`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '编码',
  `Value` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '值',
  `PrimaryEmployeeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '主管Id',
  `EmployeeCount` int NOT NULL COMMENT '员工人数',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Sort` int NOT NULL COMMENT '排序',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000' COMMENT '父级',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IDX_PrimaryEmployeeId1`(`PrimaryEmployeeId`) USING BTREE,
  INDEX `IDX_ParentId3`(`ParentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '组织架构表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Pe_Organization
-- ----------------------------

-- ----------------------------
-- Table structure for Pe_Position
-- ----------------------------
DROP TABLE IF EXISTS `Pe_Position`;
CREATE TABLE `Pe_Position`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名称',
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '编码',
  `Description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '说明',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `Sort` int NOT NULL COMMENT '排序',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否删除',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '职位表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of Pe_Position
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
