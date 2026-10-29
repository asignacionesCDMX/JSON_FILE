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
spool O:\PRG\GPO1\486\PAGOS\bade.txt

Select 
	dmacctg As Grupo, 
	dmacct  As Cuenta, 
	dmssnum As cuenta3,
	dmadl1 As folio
 from RCVRY.Delqmst, Amex Where dmssnum=Cuenta AND DMACCTG='1' AND DMCOMPANY='486'; 

spool off

EXIT
quit

