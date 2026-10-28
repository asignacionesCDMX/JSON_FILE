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
spool O:\PRG\GPO1\486\MAIL\baad.txt

Select 
	Adacctg As Grupo, 
	Adacct  As Cuenta, 
 	Adssnum As Cliente,
 	Adaddr1 As Correo
  from RCVRY.Address, rcvry.Lio Where ADACCT=Cuenta AND ADTYPE='3'; 

spool off

EXIT
quit
