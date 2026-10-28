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
spool O:\PRG\GPO1\486\MAIL\bade.txt

Select 
	dmacctg As Grupo, 
	dmacct  As Cuenta, 
	dmssnum As Cliente
 from RCVRY.Delqmst, rcvry.Lio Where Dmacct=Cuenta; 

spool off

EXIT
quit

