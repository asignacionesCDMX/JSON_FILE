/*SET heading off*/
/*SET linesize 32767*/
SET linesize 800
SET colsep "|"
SET pagesize 0
SET newpage none
SET feedback off
SET termout off
SET recsep off
SET sqlprompt ""
SET TRIMSPOOL ON
SET echo off


spool off

/*TELEFONOS DE BANCO BAJIO*/
spool on
spool o:\prg\gpo1\486\gescar\tel486.txt

select dmcompany as cliente,phacct as cuenta, phareacode as lada, phphone as tel,phstatus as st_tel, phcollid as gestor, phstreason as razon, phdate as fecha1
from RCVRY.delqmst,RCVRY.phone 
where dmacctg='1' and phstatus='A' AND DMACCT IN (SELECT CUENTA FROM RCVRY.bana)
and dmacctg=phacctg and dmacct=phacct;

spool off

EXIT
quit
