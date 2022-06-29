-------------------FIRST-----------------------------------------------
EXEC LBACSYS.CONFIGURE_OLS; -- This procedure registers Oracle Label Security.
EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS; -- This procedure enables it.
-----------------SECOND-----------------------------------
ALTER USER LBACSYS ACCOUNT UNLOCK IDENTIFIED BY 'abc123';

GRANT LBAC_DBA TO "900001";