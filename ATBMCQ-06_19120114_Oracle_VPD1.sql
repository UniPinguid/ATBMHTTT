-- ATBMCQ-06
-- Thành viên:
--   19120114 - Lê Bảo Chấn Phát
--   19120172 - Nguyễn Sơn Bão
--   19120261 - Nguyễn Hữu Khôi
--   19120423 - Phạm Sơn Tùng

CREATE TABLE EMPHOLIDAY
(
    EmpNo NUMBER(5),
    EName VARCHAR2(60),
    Holiday DATE
);
/

INSERT INTO EMPHOLIDAY(EmpNo, EName, Holiday) VALUES (1, 'Hann', TO_DATE('2/1/2019', 'dd/mm/yyyy'));
/
INSERT INTO EMPHOLIDAY(EmpNo, EName, Holiday) VALUES (2, 'Annu', TO_DATE('12/5/2019', 'dd/mm/yyyy'));
/
INSERT INTO EMPHOLIDAY(EmpNo, EName, Holiday) VALUES (3, 'Theota', TO_DATE('26/8/2018', 'dd/mm/yyyy'));
/

-- c
-- Function
CREATE OR REPLACE FUNCTION upcomingHolidays (
    p_chema IN VARCHAR2,
    p_object IN VARCHAR2)
RETURN VARCHAR2
AS
BEGIN
    RETURN 'Holiday > trunc(sysdate)'
END;