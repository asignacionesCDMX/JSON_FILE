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

spool C:\PROM_BAJIO.txt
select  
        PPACCT as CUENTA,
        ppentry AS FE_PROMESA,
        PPDUE as FECHA,
        ppamt  AS MONTO        
from RCVRY.PTPSCHED where ppacct in 
(select dmacct from RCVRY.delqmst where dmacctg='1' and dmcompany='486'  and dmstatus is null);

spool off

EXIT
quit