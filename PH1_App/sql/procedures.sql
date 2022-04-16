alter session set "_ORACLE_SCRIPT"=true;

GRANT CREATE USER TO system;
GRANT DROP USER TO system;

CREATE OR REPLACE PROCEDURE createUser (user_name IN VARCHAR2, user_passwd IN VARCHAR2)
IS
BEGIN

    execute immediate 'CREATE USER ' || user_name || ' IDENTIFIED BY ' || user_passwd || ' DEFAULT TABLESPACE SYSTEM ACCOUNT UNLOCK';
    execute immediate 'GRANT CREATE SESSION TO ' || user_name;
    
END;

declare
    m_username VARCHAR2(32) := 'unipinguid';
    m_password VARCHAR2(32) := 'testtest';
begin
    createUser(m_username, m_password);
end;
/

CREATE OR REPLACE PROCEDURE dropUser (user_name IN VARCHAR2)
IS
BEGIN

    execute immediate 'DROP USER ' || user_name;
    
END;

declare
    m_username VARCHAR2(32) DEFAULT 'unipinguid';
begin
    dropUser(m_username);
end;
/

alter session set "_ORACLE_SCRIPT"=false;
