alter session set "_ORACLE_SCRIPT"=true;

-- Phân quyền cho user DBA
GRANT SYSDBA TO "900001";

GRANT DBA TO "900001";
GRANT DBA TO "900002";
GRANT DBA TO "900003";
GRANT DBA TO "900004";

grant all privileges on HSBA to "900001" WITH GRANT OPTION;
grant all privileges on HSBA_DV to "900001" WITH GRANT OPTION;
grant all privileges on BENHNHAN to "900001" WITH GRANT OPTION;
grant all privileges on NHANVIEN to "900001" WITH GRANT OPTION;
grant all privileges on CSYT to "900001" WITH GRANT OPTION;

grant all privileges on HSBA to "900002" WITH GRANT OPTION;
grant all privileges on HSBA_DV to "900002" WITH GRANT OPTION;
grant all privileges on BENHNHAN to "900002" WITH GRANT OPTION;
grant all privileges on NHANVIEN to "900002" WITH GRANT OPTION;
grant all privileges on CSYT to "900002" WITH GRANT OPTION;

grant all privileges on HSBA to "900003" WITH GRANT OPTION;
grant all privileges on HSBA_DV to "900003" WITH GRANT OPTION;
grant all privileges on BENHNHAN to "900003" WITH GRANT OPTION;
grant all privileges on NHANVIEN to "900003" WITH GRANT OPTION;
grant all privileges on CSYT to "900003" WITH GRANT OPTION;

grant all privileges on HSBA to "900004" WITH GRANT OPTION;
grant all privileges on HSBA_DV to "900004" WITH GRANT OPTION;
grant all privileges on BENHNHAN to "900004" WITH GRANT OPTION;
grant all privileges on NHANVIEN to "900004" WITH GRANT OPTION;
grant all privileges on CSYT to "900004" WITH GRANT OPTION;

-- Phân quyền cho cấp bậc Giám đốc sở
grant create session to GIAMDOCSO;
grant select, insert, delete on "900001".THONGBAO to GIAMDOCSO;
grant insert, update, delete on "900001".NHANVIEN to GIAMDOCSO;
grant insert, update, delete on "900001".CSYT to GIAMDOCSO;

grant NHANVIEN to GIAMDOCSO with admin option;
grant NGHIENCUU to GIAMDOCSO with admin option;
grant YBACSI to GIAMDOCSO with admin option;
grant COSOYTE to GIAMDOCSO with admin option;
grant THANHTRA to GIAMDOCSO with admin option;
grant GIAMDOCCSYT to GIAMDOCSO with admin option;
-- grant GIAMDOCSO to giamdocso1 with admin option;

-- Phan quyền cho cấp bậc Giám đốc CSYT
grant create session to GIAMDOCCSYT;
grant insert, update, delete on "900001".NHANVIEN to GIAMDOCCSYT;

grant NHANVIEN to GIAMDOCCSYT with admin option;
grant NGHIENCUU to GIAMDOCCSYT with admin option;
grant YBACSI to GIAMDOCCSYT with admin option;
grant COSOYTE to GIAMDOCCSYT with admin option;
grant THANHTRA to GIAMDOCCSYT with admin option;

-- grant GIAMDOCCSYT to giamdoccsyt1 with admin option;

-- Phân quyền cho vai trò Thanh tra
grant create session to THANHTRA;
grant select on "900001".HSBA to THANHTRA;
grant select on "900001".HSBA_DV to THANHTRA;
grant select on "900001".CSYT to THANHTRA;
grant select on "900001".BENHNHAN to THANHTRA;
grant select on "900001".NHANVIEN to THANHTRA;

-- Phân quyền cho vai trò Cơ sở y tế
grant create session to COSOYTE;
grant select, insert, delete on "900001".HSBA to COSOYTE; -- Phải thêm select thì mới delete thực hiện được
grant select, insert, delete on "900001".HSBA_DV to COSOYTE; -- Phải thêm select thì mới delete thực hiện được

-- Phân quyền cho vai trò Y/Bác sĩ
grant create session to YBACSI;
grant select, insert on "900001".BENHNHAN to YBACSI;
grant select on "900001".HSBA to YBACSI;
grant select on "900001".HSBA_DV to YBACSI;

-- Phân quyền cho vai trò Nghiên cứu
grant create session to NGHIENCUU;
grant select, insert on "900001".HSBA to NGHIENCUU;
grant select, insert on "900001".HSBA_DV to NGHIENCUU;

-- Phân quyền cho vai trò Nhân viên
grant create session to NHANVIEN;
grant select, update on "900001".NHANVIEN to NHANVIEN;
grant select on "900001".THONGBAO to NHANVIEN;

-- Phân quyền cho vai trò Bệnh nhân
grant create session to BENHNHAN;
grant select, update on "900001".BENHNHAN to BENHNHAN;

-- Phân quyền cho người dùng
grant create session to "100001";
grant NHANVIEN to "100001";

grant create session to "100002";
grant NHANVIEN to "100002";
grant NGHIENCUU to "100002";

grant create session to "100003";
grant NHANVIEN to "100003";
grant COSOYTE to "100003";

select * from role_tab_privs where role = 'COSOYTE';