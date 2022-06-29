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
    FROM "900001".NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    
    IF (MA_CSYT != '') THEN 
		this_month := TO_NUMBER(to_char(sysdate,'mm'));
		this_day := TO_NUMBER(TO_CHAR(SYSDATE,'dd'));
		RETURN 'MACSYT = ' || ma_csyt || ' AND TO_NUMBER(TO_CHAR(NGAY,''mm'')) = ' || this_month || ' AND TO_NUMBER(TO_CHAR(NGAY, ''dd'')) BETWEEN 5 AND 27';
	ELSE
		RETURN ' 1 ';
	END IF;
END;

BEGIN
DBMS_RLS.ADD_POLICY(
    object_name => 'HSBA',
    policy_name => 'TC3A',
    policy_function => 'CSYT_INS_DEL_HSBA',
    statement_types => 'INSERT, DELETE',
    update_check => true
);
END;
/

/*
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema => '"900001"',
    object_name => 'HSBA',
    policy_name => 'TC3A'
);
END;
/

disconnect;
connect "100003"/"3289123577";
INSERT INTO "900001".HSBA(MAHSBA, MABN, NGAY, CHANDOAN, MABS, MAKHOA, MACSYT, KETLUAN)
    VALUES(944129582, 82719202, sysdate, 'Có khối u lành tính tại thực quản', 100003, 9282155, 92762622, 'Khỏe mạnh');

disconnect;
connect "100003"/"3289123577";
select * from "900001".HSBA;
DELETE FROM "900001".HSBA
WHERE MAHSBA = 944129582

*/

-----------------------------------------------------------------------------------------------------------------------
--B
CREATE OR REPLACE FUNCTION CSYT_INS_DEL_HSBA_DV(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    this_month NUMBER;
    this_day NUMBER;
    table_link VARCHAR2(100);
BEGIN
    SELECT emp.CSYT
    INTO MaCSYT
    FROM "900001".NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
    IF (Ma_CSYT != '') THEN
		table_link := 'MAHSBA IN (SELECT hs.MAHSBA FROM "900001".HSBA hs WHERE ' || ' hs.MACSYT = ' || ma_csyt || ')';
		this_month := TO_NUMBER(to_char(sysdate,'mm'));
		this_day := TO_NUMBER(TO_CHAR(SYSDATE,'dd'));
		RETURN table_link || ' AND TO_NUMBER(TO_CHAR(NGAY,''mm'')) = ' || this_month || ' AND TO_NUMBER(TO_CHAR(NGAY, ''dd'')) BETWEEN 5 AND 27';
	ELSE
		RETURN ' 1 ';
	END IF;
END;
/

BEGIN
DBMS_RLS.ADD_POLICY(
    object_name => 'HSBA_DV',
    policy_name => 'TC3B',
    policy_function => 'CSYT_INS_DEL_HSBA_DV',
    statement_types => 'INSERT, DELETE',
    update_check => true
);
END;
/

/*
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema => '"900001"',
    object_name => 'HSBA_DV',
    policy_name => 'TC3B'
);
END;
/
*/
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TC#5:
CREATE OR REPLACE FUNCTION NGHIENCUU_XEM_HSBA(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    MaChuyenKhoa NUMBER;
    DieuKien_Khoa VARCHAR2(100);
    DieuKien_CSYT VARCHAR2(100);
    VAI_TRO VARCHAR2(100);
BEGIN
    SELECT emp.CSYT, emp.CHUYENKHOA, emp.VAITRO
    INTO MaCSYT, MaChuyenKhoa, VAI_TRO
    FROM "900001".NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
       
    IF VAI_TRO = N'Nghiên cứu' THEN
        DieuKien_Khoa := ' MAKHOA = ' || MaChuyenKhoa || ' ';
        DieuKien_CSYT := ' MACSYT = ' || MaCSYT || ' ';
        RETURN DieuKien_Khoa || ' AND ' || DieuKien_CSYT;
	ELSE
		RETURN ' 1=1 ';
	END IF;
END;
---------------------------------------
BEGIN
DBMS_RLS.ADD_POLICY(
    object_name => 'HSBA',
    policy_name => 'TC51',
    policy_function => 'NGHIENCUU_XEM_HSBA',
    statement_types => 'SELECT'
);
END;
/

/*
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema => '"900001"',
    object_name => 'HSBA',
    policy_name => 'TC51'
);
END;
/

disconnect;
connect "100001"/"3411745902";
select * from "900001".HSBA;

disconnect;
connect "100002"/"3911523982";
select * from "900001".HSBA;
*/


CREATE OR REPLACE FUNCTION NGHIENCUU_XEM_HSBA_DV(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    MaCSYT NUMBER;
    MaChuyenKhoa NUMBER;
	dieuKien VARCHAR2(100);
    DieuKien_Khoa VARCHAR2(50);
    DieuKien_CSYT VARCHAR2(50);
BEGIN
    SELECT emp.CSYT, emp.chuyenkhoa
    INTO MaCSYT, MaChuyenKhoa
    FROM "900001".NHANVIEN emp
    WHERE emp.MANV = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
	
    dieuKien := 'MAHSBA IN (SELECT hs.MAHSBA FROM "900001".HSBA hs WHERE ';
    DieuKien_Khoa := ' hs.MAKHOA =  ' || machuyenkhoa || ' ';
    dieukien_csyt := ' hs.MACSYT = ' || macsyt || ' ';
	
    RETURN dieuKien || dieuKien_Khoa || ' AND ' || dieukien_csyt || ')';
END;
---------------------------------------
BEGIN
DBMS_RLS.ADD_POLICY(
    object_name => 'HSBA_DV',
    policy_name => 'TC52',
    policy_function => 'NGHIENCUU_XEM_HSBA_DV'
);
END;
/

/*
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema => '"900001"',
    object_name => 'HSBA_DV',
    policy_name => 'TC52'
);
END;

disconnect;
connect "100002"/"3911523982";
select * from "900001".HSBA_DV;
/
*/

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--TC#6:
CREATE OR REPLACE FUNCTION NHANVIEN_XEM_THONGTIN(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    vai_tro VARCHAR2(50);
    DieuKien VARCHAR2(50);
BEGIN
    SELECT emp.VAITRO
    INTO vai_tro
    FROM "900001".NHANVIEN emp
    WHERE emp.manv = TO_NUMBER(SYS_CONTEXT('userenv', 'SESSION_USER'));
        
        IF (vai_tro NOT LIKE '%Thanh tra%' AND vai_tro NOT LIKE '%DBA%')
        THEN
            DieuKien := ' MANV = ' || 'TO_NUMBER(SYS_CONTEXT(''userenv'', ''SESSION_USER''))';
        ELSE
            DieuKien := ' 1 ';
        END IF;
    RETURN DieuKien;
END;
/
-------------------------------------
CREATE OR REPLACE FUNCTION BENHNHAN_XEM_THONGTIN(p_schema VARCHAR2, p_obj VARCHAR2)
RETURN VARCHAR2
AS
    dieukien VARCHAR2(100);
BEGIN
    dieukien := ' MABN = TO_NUMBER(SYS_CONTEXT(''userenv'', ''SESSION_USER''))';
    RETURN dieukien;
END;
-------
BEGIN
DBMS_RLS.ADD_POLICY(
    object_name => 'NHANVIEN',
    policy_name => 'TC6_NHANVIEN',
    policy_function => 'NHANVIEN_XEM_THONGTIN'
);
END;
/

/*
BEGIN
DBMS_RLS.DROP_POLICY(
    object_schema => '"900001"',
    object_name => 'NHANVIEN',
    policy_name => 'TC6_NHANVIEN'
);
END;
*/
-------
BEGIN
DBMS_RLS.ADD_POLICY(
    object_name => 'BENHNHAN',
    policy_name => 'TC6_BENHNHAN',
    policy_function => 'BENHNHAN_XEM_THONGTIN'
);
END;
/

select * from all_policies;