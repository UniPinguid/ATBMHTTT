/*
    procedures.sql
    
    Định nghĩa các procedure phục vụ hệ thống
*/

alter session set "_ORACLE_SCRIPT"=true;

GRANT CREATE USER TO system;
GRANT DROP USER TO system;

-- Tạo người dùng
CREATE OR REPLACE PROCEDURE createUser (user_name IN VARCHAR2, user_passwd IN VARCHAR2)
IS
BEGIN

    execute immediate 'CREATE USER ' || user_name || ' IDENTIFIED BY ' || user_passwd || ' DEFAULT TABLESPACE SYSTEM ACCOUNT UNLOCK';
    execute immediate 'GRANT CREATE SESSION TO ' || user_name;
    
END;

/*
declare
    m_username VARCHAR2(32) := 'unipinguid';
    m_password VARCHAR2(32) := 'testtest';
begin
    createUser(m_username, m_password);
end;
/
*/

-- Xóa người dùng
CREATE OR REPLACE PROCEDURE dropUser (user_name IN VARCHAR2)
IS
BEGIN

    execute immediate 'DROP USER ' || user_name;
    
END;

/* 
declare
    m_username VARCHAR2(32) DEFAULT 'unipinguid';
begin
    dropUser(m_username);
end;
/
*/

-- Tạo role
CREATE OR REPLACE PROCEDURE addRole (role_name in varchar2)
is
begin
execute immediate 'create role' || role_name;
end;
/

-- Xóa role
CREATE OR REPLACE PROCEDURE dropRole (role_name IN VARCHAR2)
IS
BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ' || role_name;         
END;        
/

/*declare 
    rolename varchar2(32) default 'benhnhan';
begin
    dropRole(rolename);
end;
*/

alter session set "_ORACLE_SCRIPT"=false;
