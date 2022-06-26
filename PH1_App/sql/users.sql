/*
    users.sql
    --------------
    Tạo role và user. Phân quyền cho user
*/

ALTER SESSION SET "_ORACLE_SCRIPT"=true;

-- Cấp bậc nhân viên
CREATE ROLE GIAMDOCSO;
CREATE ROLE GIAMDOCCSYT;

-- Vai trò nhân viên
CREATE ROLE BENHNHAN;
CREATE ROLE THANHTRA;
CREATE ROLE COSOYTE;
CREATE ROLE YBACSI;
CREATE ROLE NGHIENCUU;
CREATE ROLE NHANVIEN;

-- Tạo user
-- User vai trò DBA
CREATE USER "900001" IDENTIFIED BY "lbcphat123";
CREATE USER "900002" IDENTIFIED BY "nhkhoi123";
CREATE USER "900003" IDENTIFIED BY "nsbao123";
CREATE USER "900004" IDENTIFIED BY "pstung123";

-- User cấp bậc Giám đốc sở
CREATE USER giamdocso1 IDENTIFIED BY "gds1gds1";

-- User cấp bậc Giám đốc CSYT
CREATE USER giamdoccsyt1 IDENTIFIED BY "csyt1csyt1";

-- User nhân viên Y/Bác sĩ
CREATE USER ybs123 IDENTIFIED BY "ybs123123";
CREATE USER "100001" IDENTIFIED BY "3411745902";