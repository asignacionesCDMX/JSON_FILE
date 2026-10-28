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

/*TELEFONOS DE AMEX*/
spool on
spool O:\PRG\GPO1\486\tel.txt
select dmcompany as cliente, dmadl1 as folio,phacct as cuenta, phareacode as lada, phphone as tel,phstatus as st_tel, phcollid as gestor, phstreason as razon, TO_CHAR(PHDATE,'MM/DD/YY HH24:MI:SS') as FE_ACT
from delqmst,phone 
where dmacctg='1' and DMCOMPANY='486' AND DMACCT IN (SELECT CUENTA FROM BANA)
and dmacctg=phacctg and dmacct=phacct;

spool off

EXIT
quit
