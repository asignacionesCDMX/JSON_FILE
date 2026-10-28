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
spool j:\BAJ_TEL_HIG.TXT 

Select 
	phacct As CUENTA,
	phareacode As LADA, 
	phphone  As TEL, 
 	TO_CHAR(Phstatdt,'DD/MM/YYYY HH24:MI:SS') as Ori,
 	Phstcollid As Origen
 	from PHONE Where PHACCTG='4' AND TRUNC(PHDATE)=trunc(sysdate) AND PHSTCOLLID in ('HOSK','HOHI');

spool off

EXIT
quit
