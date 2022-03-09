--cau 6
CREATE OR REPLACE PROCEDURE sp_DanhSachNV_vao1983_19120423 
(
    v_ename OUT EMP_19120423.ename%type,
    v_deptno OUT EMP_19120423.deptno%type,
    v_hiredate OUT EMP_19120423.hiredate%type
)
IS
BEGIN
    SELECT ename, deptno, hiredate
    INTO v_ename, v_deptno, v_hiredate
    FROM EMP_19120423
    WHERE EXTRACT(YEAR FROM hiredate) = 1983;
    
    
END;

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

--cau 7
CREATE OR REPLACE PROCEDURE sp_DanhSachNV_Luongtang15_19120423
AS
    CURSOR C3 IS SELECT emp_19120423.ename,emp_19120423.deptno, emp_19120423.sal*1.25 FROM EMP_19120423;
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

EXECUTE sp_DanhSachNV_Luongtang15_19120423;

--cau 8
CREATE OR REPLACE PROCEDURE sp_HienThi_19120423
AS
    CURSOR C2 IS SELECT emp_19120423.ename, emp_19120423.job FROM EMP_19120423;
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

EXECUTE sp_HienThi_19120423;

--cau 9
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

EXEC sp_DanhSachNV20_Hienthi_19120114;

--cau 10
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