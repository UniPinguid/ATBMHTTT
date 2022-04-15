create or replace procedure sp_dropif (t_name IN NVARCHAR2)
as
begin
  EXECUTE IMMEDIATE 'DROP TABLE ' || t_name || ' CASCADE CONSTRAINTS';
EXCEPTION
   WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
end;
/
exec sp_dropif('HSBA');
exec sp_dropif('HSBA_DV');
exec sp_dropif('BENHNHAN');
exec sp_dropif('CSYT');
exec sp_dropif('NHANVIEN');
/
create table HSBA(
MAHSBA number not null,
MABN number,
NGAY date,
CHANDOAN NVARCHAR2(100),
MABS number,
MAKHOA number,
MACSYT number,
KETLUAN NVARCHAR2(100),
primary key(MAHSBA)
);

create table HSBA_DV(
MAHSBA number not null,
MADV number not null,
NGAY date not null,
MAKTV number,
KETQUA NVARCHAR2(100)
);

create table BENHNHAN(
MABN number not null,
MACSYT number,
TENBN NVARCHAR2(25),
CMND NVARCHAR2(10),
NGAYSINH DATE,
SONHA NUMBER,
TENDUONG NVARCHAR2(25),
QUANHUYEN NVARCHAR2(25),
TINHTP NVARCHAR2(20),
TIENSUBENH NVARCHAR2(100),
TIENSUBENHGD NVARCHAR2(200),
DIUNGTHUOC NVARCHAR2(200),
PRIMARY KEY(MABN)
);

CREATE TABLE CSYT(
MACSYT NUMBER not null,
TENCSYT NVARCHAR2(25),
DCCSYT NVARCHAR2(50),
SDTCSYT NVARCHAR2(10),
PRIMARY KEY (MACSYT)
);

CREATE TABLE NHANVIEN(
MANV NUMBER not null,
HOTEN NVARCHAR2(25),
PHAI NVARCHAR2(5),
NGAYSINH DATE,
CMND NVARCHAR2(10),
QUEQUAN NVARCHAR2(20),
SODT NVARCHAR2(10),
CSYT NUMBER,
VAITRO NVARCHAR2(15),
CHUYENKHOA NVARCHAR2(15),
PRIMARY KEY(MANV)
);

alter table HSBA
add constraint FK_MABS_MANV foreign key (MABS) REFERENCES NHANVIEN(MANV);

ALTER TABLE HSBA
ADD CONSTRAINT FK_MABN_MABN foreign key (MABN) REFERENCES BENHNHAN(MABN);

ALTER TABLE HSBA_DV
ADD CONSTRAINT FK_HSBA_HSBA FOREIGN KEY (MAHSBA) REFERENCES HSBA(MAHSBA);

ALTER TABLE HSBA_DV
ADD CONSTRAINT PK_MAHS_MADV_NGAY PRIMARY KEY(MAHSBA, MADV, NGAY);

ALTER TABLE HSBA_DV
ADD CONSTRAINT FK_MAKTV_MANV FOREIGN KEY (MAKTV) REFERENCES NHANVIEN(MANV);

ALTER TABLE BENHNHAN
ADD CONSTRAINT FK_MACSYT_MACSYT FOREIGN KEY (MACSYT) REFERENCES CSYT(MACSYT);

ALTER TABLE NHANVIEN
ADD CONSTRAINT FK_CSYT_MACSYT FOREIGN KEY (CSYT) REFERENCES CSYT(MACSYT);

ALTER TABLE NHANVIEN
ADD CONSTRAINT CHECK_VAITRO CHECK (VAITRO IN (N'Y sĩ/bác sĩ', N'Nghiên cứu',N'Thanh tra', N'Cơ sở y tế'));


alter session set "_ORACLE_SCRIPT"=true;
CREATE ROLE BENHNHAN;
CREATE ROLE THANHTRA;
CREATE ROLE COSOYTE;
CREATE ROLE YBACSI;
CREATE ROLE NGHIENCUU;
CREATE ROLE NHANVIEN;

CREATE USER "900001" IDENTIFIED BY "lbcphat123";
CREATE USER "900002" IDENTIFIED BY "nhkhoi123";
CREATE USER "900003" IDENTIFIED BY "nsbao123";
CREATE USER "900004" IDENTIFIED BY "pstung123";

GRANT DBA TO "900001";
GRANT DBA TO "900002";
GRANT DBA TO "900003";
GRANT DBA TO "900004";



alter session set "_ORACLE_SCRIPT"=false;