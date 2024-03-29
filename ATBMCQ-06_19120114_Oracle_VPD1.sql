-- ATBMCQ-06
-- Thành viên:
--   19120114 - Lê Bảo Chấn Phát
--   19120172 - Nguyễn Sơn Bão
--   19120261 - Nguyễn Hữu Khôi
--   19120423 - Phạm Sơn Tùng

CREATE TABLE EMPHOLIDAY
(
    EmpNo NUMBER(5),
    EName VARCHAR2(60),
    Holiday DATE
);
/

INSERT INTO EMPHOLIDAY(EmpNo, EName, Holiday) VALUES (1, 'Hann', TO_DATE('2/1/2019', 'dd/mm/yyyy'));
/
INSERT INTO EMPHOLIDAY(EmpNo, EName, Holiday) VALUES (2, 'Annu', TO_DATE('12/5/2019', 'dd/mm/yyyy'));
/
INSERT INTO EMPHOLIDAY(EmpNo, EName, Holiday) VALUES (3, 'Theota', TO_DATE('26/8/2018', 'dd/mm/yyyy'));
/
--Cau 2: tao user
alter session set "_ORACLE_SCRIPT"=true;

CREATE USER Hann IDENTIFIED BY abc123;
CREATE USER Annu IDENTIFIED BY abc123;
CREATE USER Theota IDENTIFIED BY abc123;

ALTER SESSION SET "_ORACLE_SCRIPT"=FALSE;

--Cau 3
--a
CREATE OR REPLACE FUNCTION Annu_information
(
    p_chema IN VARCHAR2,
    p_object IN VARCHAR2   
)
RETURN VARCHAR2
AS
BEGIN
    RETURN 'EmpNo = 2';
END;
/
--Policy
BEGIN DBMS_RLS.add_policy
(
    object_schema => 'SYS ',
    object_name => 'EMPHOLIDAY',
    policy_name => 'Holiday_Control',
    policy_function => 'Annu_information',
    statement_type => 'UPDATE',
    update_check => TRUE
);
END;
--b
--Function
CREATE OR REPLACE FUNCTION noTheota (
    p_schema IN VARCHAR2,
    p_object IN VARCHAR2)
RETURN VARCHAR2
AS
BEGIN
    RETURN 'USER != ''Theota''';
END;
/
--add chinh sach:
BEGIN DBMS_RLS.add_policy
(
    object_schema => 'SYS ',
    object_name => 'EMPHOLIDAY',
    policy_name => 'Holiday_Control',
    policy_function => 'noTheota'
);
END;
-- c
-- Function
CREATE OR REPLACE FUNCTION upcomingHolidays (
    p_chema IN VARCHAR2,
    p_object IN VARCHAR2)
RETURN VARCHAR2
AS
BEGIN
    RETURN 'Holiday > trunc(sysdate)'
END;
/

BEGIN DBMS_RLS.add_policy
(
    object_schema => 'SYS ',
    object_name => 'EMPHOLIDAY',
    policy_name => 'Holiday_Control',
    policy_function => 'upcomingHolidays',
    statement_type => 'INSERT,UPDATE, DELETE',
    update_check => TRUE
);
END;
