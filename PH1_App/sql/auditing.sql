-- **************
-- Standard audit
-- **************

alter system set audit_trail=DB scope=spfile;

-- alter system set audit_file_dest='C:/app/MyPC/product/21c/audit/xe' scope=spfile;

/*
show parameter audit;

select * from nhanvien;
select username from dba_users;
*/

-- Audit dành cho các DBA
audit all privileges by "900001";
audit all privileges by "900002";
audit all privileges by "900003";
audit all privileges by "900004";

-- Audit dành cho Giám đốc sở
audit system grant by giamdocso1;
audit delete on "900001".THONGBAO by access;
audit insert, update, delete on "900001".NHANVIEN by access;
audit insert, update, delete on "900001".CSYT by access;

-- Audit dành cho Giám đốc CSYT
audit system grant by giamdoccsyt1;
audit insert, update, delete on "900001".NHANVIEN by access;


-- ****************
--       FGA
-- ****************

BEGIN
    DBMS_FGA.ADD_POLICY (
    object_schema => '900001',
    object_name => 'NHANVIEN',
    policy_name => 'FGA_NHANVIEN_GIAMDOCSO',
    audit_condition => 'CAPBAC IN (''Giám đốc sở'', ''Giám đốc cơ sở y tế'') ',
    audit_column => 'CAPBAC',
    enable => TRUE,
    statement_types => 'INSERT, UPDATE, DELETE',
    audit_trail => DBMS_FGA.DB + DBMS_FGA.EXTENDED);
END;
/





-- Kiểm tra audit
select user_name, AUDIT_OPTION, SUCCESS, FAILURE
from dba_stmt_audit_opts
order by user_name;

select username, TO_CHAR(timestamp, 'dd/mm/yyyy hh:mi:ss'), action_name, obj_name, terminal
from DBA_AUDIT_TRAIL
where username = 'GIAMDOCSO1';
