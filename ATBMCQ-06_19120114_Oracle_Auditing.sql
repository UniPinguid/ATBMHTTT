-- Nhóm ATBMCQ-06
-- Thành viên nhóm:
--    19120114 - Lê Bảo Chấn Phát
--    19120172 - Nguyễn Sơn Bão
--    19120261 - Nguyễn Hữu Khôi
--    19120423 - Phạm Sơn Tùng

-- Tạo user ACCMASTER
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
/

CREATE USER ACCMASTER IDENTIFIED BY "master";
/

GRANT CREATE SESSION TO ACCMASTER;
GRANT CREATE TABLE TO ACCMASTER;
COMMIT

-- Tạo bảng ACCOUNTS dưới schema ACCMASTER

-- Cài đặt chính sách câu 2

-- 
begin
    dbms_fga.add_policy (
        object_schema   => 'ACCMASTER',
        object_name     => 'ACCOUNTS',
        policy_name     => 'ACC_MAXBAL',
        audit_column    => 'ACCNO, BAL',
        audit_condition => 'BAL >= 20000',
        handler_schema  => 'ACCMASTER',
        handler_module  => 'FGA_SEND_MAIL'
        audit_column_opta   => dbms_fga.all_columns
    );
end;