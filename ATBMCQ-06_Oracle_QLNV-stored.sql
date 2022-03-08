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