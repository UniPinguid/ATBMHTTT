select sys_context('userenv', 'SESSION_USER') from dual;

--TC#3:
--A
CREATE OR REPLACE FUNCTION CSYT_INS_DEL_HSBA(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    this_month NUMBER;
    this_day NUMBER;
BEGIN
    SELECT emp.CSYT
    INTO MaCSYT
    FROM NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    
    this_month := TO_NUMBER(to_char(sysdate,'mm'));
    this_day := TO_NUMBER(TO_CHAR(SYSDATE,'dd'));
    RETURN 'MACSYT = ' || macsyt || ' AND TO_NUMBER(TO_CHAR(NGAY,''mm'')) = ' || this_month || ' AND TO_NUMBER(TO_CHAR(NGAY, ''dd'')) BETWEEN 5 AND 27';
END;

EXECUTE DBMS_RLS.ADD_POLICY(
    object_name => 'HSBA',
    policy_name => 'TC3A',
    policy_function => 'CSYT_INS_DEL_HSBA',
    statement_types => 'insert, delete'
);
-----------------------------------------------------------------------------------------------------------------------
--B
CREATE OR REPLACE FUNCTION CSYT_INS_DEL_HSBA_DV(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    this_month NUMBER;
    this_day NUMBER;
    table_link VARCHAR2;
BEGIN
    SELECT emp.CSYT
    INTO MaCSYT
    FROM NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    table_link := 'MAHSBA IN (SELECT hs.MAHSBA FROM HSBA hs WHERE ' || ' hs.MACSYT = ' || macsyt || ')';
    this_month := TO_NUMBER(to_char(sysdate,'mm'));
    this_day := TO_NUMBER(TO_CHAR(SYSDATE,'dd'));
    RETURN table_link || ' AND TO_NUMBER(TO_CHAR(NGAY,''mm'')) = ' || this_month || ' AND TO_NUMBER(TO_CHAR(NGAY, ''dd'')) BETWEEN 5 AND 27';
END;

EXECUTE DBMS_RLS.ADD_POLICY(
    object_name => 'HSBA_DV',
    policy_name => 'TC3B',
    policy_function => 'CSYT_INS_DEL_HSBA_DV',
    statement_types => 'insert, delete'
);
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TC#5:
CREATE VIEW DuLieu_Cho_NghienCuu
AS
SELECT *
FROM HSBA hs, HSBA_DV dv
WHERE hs.MAHSBA = dv.MAHSBA;
------------------------------------
CREATE OR REPLACE FUNCTION YBS_XEM_HSBA(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    MaChuyenKhoa NUMBER;
    DieuKien_Khoa VARCHAR2;
    DieuKien_CSYT VARCHAR2;
BEGIN
    SELECT emp.CSYT, emp.chuyenkhoa
    INTO MaCSYT, MaChuyenKhoa
    FROM NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    
    DieuKien_Khoa := ' MAKHOA =  ' || machuyenkhoa || ' ';
    dieukien_csyt := ' MACSYT = ' || macsyt || ' ';
    
    RETURN DieuKien_Khoa || ' AND ' || dieukien_csyt;
END;
---------------------------------------
EXECUTE DBMS_RLS.ADD_POLICY(
    object_name => 'DuLieu_Cho_NghienCuu',
    policy_name => 'TC5',
    policy_function => 'YBS_XEM_HSBA'
);
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TC#6:
CREATE OR REPLACE FUNCTION NHANVIEN_XEM_THONGTIN(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    vai_tro VARCHAR2;
    dieukien VARCHAR2;
BEGIN
    SELECT emp.vaitro
    INTO vai_tro
    FROM NHANVIEN emp
    WHERE emp.manv = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
        
        IF (vai_tro NOT LIKE '%thanh tra%' AND vai_tro NOT LIKE '%dba%')
        THEN
            dieukien := ' MANV = ' || user_name;
        ELSE:
            dieukien := ' 1 ';
        END IF;
    RETURN dieukien;
END;
-------------------------------------
CREATE OR REPLACE FUNCTION BENHNHAN_XEM_THONGTIN(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    dieukien VARCHAR2;
BEGIN
    dieukien := ' MANV = TO_NUMBER(SYS_CONTEXT(''userenv'', ''SESSION_USER''))';
    RETURN dieukien;
END;
-------
EXECUTE DBMS_RLS.ADD_POLICY(
    object_name => 'NHANVIEN',
    policy_name => 'TC6_NHANVIEN',
    policy_function => 'NHANVIEN_XEM_THONGTIN'
);
-------
EXECUTE DBMS_RLS.ADD_POLICY(
    object_name => 'NGUOIDUNG_XEM_THONGTIN',
    policy_name => 'TC6_NGUOIDUNG',
    policy_function => 'NGUOIDUNG_XEM_THONGTIN'
);