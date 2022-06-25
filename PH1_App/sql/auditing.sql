alter system set audit_trail=DB scope=spfile;

-- alter system set audit_file_dest='C:/app/MyPC/product/21c/audit/xe' scope=spfile;

/*
show parameter audit;

select * from nhanvien;
select username from dba_users;
*/

audit all privileges by "900001";
audit all privileges by "900002";
audit all privileges by "900003";
audit all privileges by "900004";

-- Kiểm tra audit
select user_name, AUDIT_OPTION, SUCCESS, FAILURE
from dba_stmt_audit_opts
order by user_name;

select username, timestamp, action_name
from DBA_AUDIT_TRAIL
where username = '900001';
