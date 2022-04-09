/*
   Lab02 HW2.2
    -  ATBMCQ-06
   Document: https://docs.google.com/document/d/1pzWyulV0_Ibj7nCG4PcFci_rV8pTeczsTLt2OhgO-UQ/edit?usp=sharing
*/

--CAU 1 ---------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_Cau1_ThuNhapNV_19120261
as  
    c6 SYS_REFCURSOR;
BEGIN

  OPEN c6 FOR
  SELECT e.ename, e.sal* 12 + nvl(comm, 0) as income from EMP_19120114 e where e.job_ != 'PRESIDENT';
  DBMS_SQL.RETURN_RESULT(c6);
END;
/

/* Test
exec sp_cau1_thunhapnv_19120261;
*/

-- CAU 2 ---------------------------------------------------
create or replace PROCEDURE sp_CauTrucBangEMP_19120261
is
  c1 SYS_REFCURSOR;
BEGIN 
    OPEN c1 FOR
    
    SELECT
        column_name "Name",
        nullable "Null?",
        concat(concat(concat(data_type,'('),data_length),')') "Type"
    FROM user_tab_columns
    WHERE table_name='EMP_19120114';
    
    DBMS_SQL.RETURN_RESULT(c1);
END; 
/

/* Test
exec sp_CauTrucBangEMP_19120261;
*/

-- CAU 3 ---------------------------------------------------

create or replace PROCEDURE sp_SalHireDate_19120172
AS
BEGIN
    EXECUTE IMMEDIATE 'ALTER TABLE EMP_19120114 RENAME COLUMN SAL TO SALARY';
    EXECUTE IMMEDIATE 'ALTER TABLE EMP_19120114 RENAME COLUMN HIREDATE TO DATE_HIRED';

END;
/

-- CAU 4 ---------------------------------------------------
create or replace PROCEDURE sp_DanhSachNVLuong_19120172
AS
TYPE XX IS RECORD 
(
    V_EMPTNO EMP_19120114.EMPNO%TYPE,
    V_ENAME EMP_19120114.ENAME%TYPE,
    V_JOB EMP_19120114.JOB_%TYPE,
    V_MGR EMP_19120114.MGR%TYPE,
    V_HIREDATE EMP_19120114.HIREDATE%TYPE,
    V_SAL EMP_19120114.SAL%TYPE,
    V_COMM EMP_19120114.COMM%TYPE,
    V_DEPTNO EMP_19120114.DEPTNO%TYPE    
);
TYPE VAR IS TABLE OF XX INDEX BY PLS_INTEGER;
VAR1 VAR;
BEGIN
    SELECT EMPNO, ENAME, JOB_, MGR, HIREDATE, SAL, COMM, DEPTNO
    BULK COLLECT INTO VAR1
    FROM EMP_19120114
    WHERE SAL >= 1000 AND SAL <= 2000;
FOR I IN 1..VAR1.COUNT
LOOP
 DBMS_OUTPUT.PUT_LINE ( VAR1(I).V_EMPTNO || '  ' ||
                        VAR1(I).V_ENAME ||  '  ' || 
                        VAR1 (I).V_MGR ||   '  ' ||
                        VAR1(I).V_JOB ||     '  '||
                        VAR1(I).V_HIREDATE || '  ' ||
                        VAR1(I).V_SAL || '  ' ||
                        VAR1(I).V_COMM || '  ' ||
                        VAR1(I).V_DEPTNO);
END LOOP;
END;
/

-- CAU 5 ---------------------------------------------------
create or replace PROCEDURE sp_DanhSachNV_THLL_19120172
AS
TYPE XX IS RECORD 
(
    V_EMPTNO EMP_19120114.EMPNO%TYPE,
    V_ENAME EMP_19120114.ENAME%TYPE,
    V_JOB EMP_19120114.JOB_%TYPE,
    V_MGR EMP_19120114.MGR%TYPE,
    V_HIREDATE EMP_19120114.HIREDATE%TYPE,
    V_SAL EMP_19120114.SAL%TYPE,
    V_COMM EMP_19120114.COMM%TYPE,
    V_DEPTNO EMP_19120114.DEPTNO%TYPE    
);
TYPE VAR IS TABLE OF XX INDEX BY PLS_INTEGER;
VAR1 VAR;
BEGIN
    SELECT EMPNO, ENAME, JOB_, MGR, HIREDATE, SAL, COMM, DEPTNO
    BULK COLLECT INTO VAR1
    FROM EMP_19120114
    WHERE ENAME LIKE '%TH%' AND ENAME LIKE '%LL%'; 
FOR I IN 1..VAR1.COUNT
LOOP
 DBMS_OUTPUT.PUT_LINE ( VAR1(I).V_EMPTNO || '  ' ||
                        VAR1(I).V_ENAME ||  '  ' || 
                        VAR1 (I).V_MGR ||   '  ' ||
                        VAR1(I).V_JOB ||     '  '||
                        VAR1(I).V_HIREDATE || '  ' ||
                        VAR1(I).V_SAL || '       ' ||
                        VAR1(I).V_COMM || '        ' ||
                        VAR1(I).V_DEPTNO);
END LOOP;
END;
/

-- CAU 6 ---------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_DanhSachNV_vao1983_19120423 
(
    v_ename OUT EMP_19120114.ename%type,
    v_deptno OUT EMP_19120114.deptno%type,
    v_hiredate OUT EMP_19120114.hiredate%type
)
IS
BEGIN
    SELECT ename, deptno, hiredate
    INTO v_ename, v_deptno, v_hiredate
    FROM EMP_19120114
    WHERE EXTRACT(YEAR FROM hiredate) = 1983;   
END;
/

/* Test
SET SERVEROUTPUT ON;
DECLARE 
        d_ename VARCHAR2(10);
        d_deptno NUMBER;
        d_hiredate DATE;
BEGIN
    sp_DanhSachNV_vao1983_19120423 (d_ename,d_deptno,d_hiredate);
    DBMS_OUTPUT.put_line ('EMPLOYEE NAME:'||d_ename);
    DBMS_OUTPUT.put_line ('DEPARTMENT NO:'||d_deptno);
    DBMS_OUTPUT.put_line ('HIRE DATE:'||d_hiredate);
END;
*/

-- CAU 7 ---------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_DanhSachNV_Luongtang15_19120423
AS
    CURSOR C3 IS SELECT EMP_19120114.ename, EMP_19120114.deptno, EMP_19120114.sal*1.25 FROM EMP_19120114;
    l_ename VARCHAR2(10);
    l_deptno NUMBER;
    l_sal NUMBER;
BEGIN
    OPEN C3;
    DBMS_OUTPUT.PUT_LINE('ENAME DEPTNO  1.25*SAL');
    LOOP
        FETCH C3 INTO L_ename, l_deptno, l_sal;
        EXIT WHEN C3%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE(l_ename||' '||l_deptno||'  '||l_sal);
    END LOOP;
    CLOSE C3;
END;
/

/* Test
EXECUTE sp_DanhSachNV_Luongtang15_19120423;
*/

-- CAU 8 ---------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_HienThi_19120423
AS
    CURSOR C2 IS SELECT EMP_19120114.ename, EMP_19120114.job_ FROM EMP_19120114;
    t_ename VARCHAR2(10);
    t_job VARCHAR2(9);
BEGIN
    OPEN C2;
    DBMS_OUTPUT.PUT_LINE('EMPLOYEES');
    LOOP
        FETCH C2 INTO t_ename, t_job;
        EXIT WHEN C2%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE(t_ename||' ('||t_job||')');
    END LOOP;
    CLOSE C2;
END;
/

/* Test
EXECUTE sp_HienThi_19120423;
*/

-- CAU 9 ---------------------------------------------------
create or replace procedure sp_DanhSachNV20_Hienthi_19120114
AS
  c1 SYS_REFCURSOR;  
BEGIN
    OPEN c1 FOR
    
    SELECT e.ENAME, TO_CHAR(e.HIREDATE, 'month, DDSPTH YYYY') as DATE_HIRED
    FROM EMP_19120114 e
    WHERE e.DEPTNO = 20;
    
    DBMS_SQL.RETURN_RESULT(c1);

END;
/

/* Test
EXEC sp_DanhSachNV20_Hienthi_19120114;
*/

-- CAU 10 ---------------------------------------------------
create or replace procedure sp_DanhSachNhanVienLuong_19120114
(
    max_SAL out NUMBER,
    min_SAL out NUMBER,
    avg_SAL out NUMBER
)
IS    
BEGIN
    
    SELECT MAX(e.SAL), MIN(e.SAL), AVG(e.SAL)
    INTO max_SAL, min_SAL, avg_SAL
    FROM EMP_19120114 e;
    
END;
/

<<<<<<< Updated upstream
/* Test
=======
SET SERVEROUTPUT ON

>>>>>>> Stashed changes
DECLARE
    max_SAL NUMBER;
    min_SAL NUMBER;
    avg_SAL NUMBER;
BEGIN
    sp_DanhSachNhanVienLuong_19120114(max_SAL, min_SAL, avg_SAL);
    dbms_output.put_line('MAX SAL: ' || max_SAL);
    dbms_output.put_line('MIN SAL: ' || min_SAL);
    dbms_output.put_line('AVG SAL: ' || avg_SAL);
END;
*/