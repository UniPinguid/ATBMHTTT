--TC#3:
--A
CREATE OR REPLACE FUNCTION CSYT_INS_DEL_HSBA(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    Ma_CSYT NUMBER;
    this_month NUMBER;
    this_day NUMBER;
BEGIN
    SELECT MACSYT
    INTO Ma_CSYT
    FROM CSYT
    WHERE MACSYT = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    
	IF (MA_CSYT != '') THEN 
		this_month := TO_NUMBER(to_char(sysdate,'mm'));
		this_day := TO_NUMBER(TO_CHAR(SYSDATE,'dd'));
		RETURN 'MACSYT = ' || ma_csyt || ' AND TO_NUMBER(TO_CHAR(NGAY,''mm'')) = ' || this_month || ' AND TO_NUMBER(TO_CHAR(NGAY, ''dd'')) BETWEEN 5 AND 27';
	ELSE
		RETURN ' 1 ';
	END IF;
END;
EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'HSBA',policy_name => 'TC3A',policy_function => 'CSYT_INS_DEL_HSBA',statement_types => 'delete');
EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'HSBA',policy_name => 'TC3B',policy_function => 'CSYT_INS_DEL_HSBA',statement_types => 'insert');
-----------------------------------------------------------------------------------------------------------------------
--B
CREATE OR REPLACE FUNCTION CSYT_INS_DEL_HSBA_DV(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    Ma_CSYT NUMBER;
    this_month NUMBER;
    this_day NUMBER;
    table_link VARCHAR2(500);
BEGIN
    SELECT MACSYT
    INTO Ma_CSYT
    FROM CSYT
    WHERE MACSYT = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
	
	IF (Ma_CSYT != '') THEN
		table_link := 'MAHSBA IN (SELECT hs.MAHSBA FROM HSBA hs WHERE ' || ' hs.MACSYT = ' || ma_csyt || ')';
		this_month := TO_NUMBER(to_char(sysdate,'mm'));
		this_day := TO_NUMBER(TO_CHAR(SYSDATE,'dd'));
		RETURN table_link || ' AND TO_NUMBER(TO_CHAR(NGAY,''mm'')) = ' || this_month || ' AND TO_NUMBER(TO_CHAR(NGAY, ''dd'')) BETWEEN 5 AND 27';
	ELSE
		RETURN ' 1 ';
	END IF;
END;

EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'HSBA_DV',policy_name => 'TC3B',policy_function => 'CSYT_INS_DEL_HSBA_DV',statement_types => 'insert, delete');
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TC#5:
CREATE OR REPLACE FUNCTION NGHIENCUU_XEM_HSBA(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    MaChuyenKhoa NUMBER;
    DieuKien_Khoa VARCHAR2(500);
    DieuKien_CSYT VARCHAR2(500);
	vai_tro VARCHAR2(30);
BEGIN
    SELECT emp.CSYT, emp.chuyenkhoa, emp.VAITRO
    INTO MaCSYT, MaChuyenKhoa, vai_tro
    FROM NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    
    IF vai_tro = N'Nghiên cứu' THEN
		DieuKien_Khoa := ' MAKHOA =  ' || machuyenkhoa || ' ';
		dieukien_csyt := ' MACSYT = ' || macsyt || ' ';
		RETURN DieuKien_Khoa || ' AND ' || dieukien_csyt;
	ELSE
		RETURN ' 1 ';
	END IF;
END;
---------------------------------------
EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'HSBA',policy_name => 'TC51',policy_function => 'YBS_XEM_HSBA');
CREATE OR REPLACE FUNCTION NGHIENCUU_XEM_HSBA_DV(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    MaChuyenKhoa NUMBER;
	dieuKien VARCHAR2(500);
    DieuKien_Khoa VARCHAR2(500);
    DieuKien_CSYT VARCHAR2(500);
    vai_tro VARCHAR(30);
BEGIN
    SELECT emp.CSYT, emp.chuyenkhoa, emp.VAITRO
    INTO MaCSYT, MaChuyenKhoa, vai_tro
    FROM NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
	
	IF vai_tro = N'Nghiên cứu' THEN
		dieuKien := 'MAHSBA IN (SELECT hs.MAHSBA FROM HSBA hs WHERE ';
		DieuKien_Khoa := ' hs.MAKHOA =  ' || machuyenkhoa || ' ';
		dieukien_csyt := ' hs.MACSYT = ' || macsyt || ' ';
	
		RETURN dieuKien || dieuKien_Khoa || ' AND ' || dieukien_csyt || ')';
	ELSE
		RETURN ' 1 ';
	END IF;
END;
---------------------------------------
EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'HSBA_DV', policy_name => 'TC52', policy_function => 'NGHIENCUU_XEM_HSBA_DV');
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TC#6:
CREATE OR REPLACE FUNCTION NHANVIEN_XEM_THONGTIN(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    vai_tro VARCHAR2(500);
    dieukien VARCHAR2(500);
BEGIN
    SELECT emp.vaitro
    INTO vai_tro
    FROM NHANVIEN emp
    WHERE emp.manv = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
        
        IF (vai_tro NOT LIKE '%thanh tra%' AND vai_tro NOT LIKE '%dba%')
        THEN
            RETURN ' MANV = TO_NUMBER(SYS_CONTEXT(''userenv'', ''SESSION_USER''))';
        ELSE
            RETURN ' 1 ';
        END IF;
    
END;
-------------------------------------
CREATE OR REPLACE FUNCTION BENHNHAN_XEM_THONGTIN(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    dieukien VARCHAR2(500);
BEGIN
    dieukien := ' MABN = TO_NUMBER(SYS_CONTEXT(''userenv'', ''SESSION_USER''))';
    RETURN dieukien;
END;
-------
EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'NHANVIEN', policy_name => 'TC6_NHANVIEN', policy_function => 'NHANVIEN_XEM_THONGTIN');
-------
EXECUTE DBMS_RLS.ADD_POLICY(object_name => 'BENHNHAN', policy_name => 'TC6_NGUOIDUNG', policy_function => 'NGUOIDUNG_XEM_THONGTIN');