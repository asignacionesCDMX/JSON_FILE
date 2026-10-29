SET linesize 1200
SET colsep "|"
SET pagesize 0
SET newpage none
SET feedback off
SET termout off
SET recsep off
SET sqlprompt ""
SET TRIMSPOOL ON
SET echo off
/*SET verify off */

spool on
spool O:\PRG\GPO1\486\PAGOS\bajpag.txt

SELECT 
	pmacct as cuenta,
	pmamount as monto,
	pmedate as fecha
	FROM RCVRY.pmtfil WHERE PMACCTG='1' AND pmacct IN (SELECT DMACCT FROM RCVRY.delqmst WHERE DMCOMPANY='486') AND TRUNC(PMEDATE)=TRUNC(SYSDATE);  

spool off

EXIT
quit
