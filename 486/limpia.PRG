CLOSE ALL
SET SAFETY OFF
SET TALK ON
*FOR CC=1 TO 3

FOR CC=1 TO 16
STORE ALLTRIM(STR(CC)) TO BB
UPDATE O:\LAYOUT\GPO1\486\LAYOUT1 SET LAYOUT1.tel&BB= ' '

ENDFOR
CLOSE DATABASES


*UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel1 = ' ', LAYOUT1.tel2 = ' ', LAYOUT1.tel3 = ' ' ,LAYOUT1.tel4 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,
*FOR TT=1 TO 3

FOR TT=1 TO 16
	STORE ALLTRIM(STR(TT)) TO HH
	
	UPDATE O:\LAYOUT\GPO1\486\LAYOUT1 SET LAYOUT1.tel&HH=telpas.tel_1 from o:\DAT\GPO1\486\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele=''+HH+''

ENDFOR
CLOSE DATABASES



*!*	FOR CC=1 TO 14
*!*	STORE ALLTRIM(STR(CC)) TO BB
*!*	UPDATE O:\CLIENTES\397\DAT SET DAT.tel&BB= ' '

*!*	ENDFOR
*!*	CLOSE DATABASES


*!*	*UPDATE O:\CLIENTES\397\DAT SET LAYOUT1.tel1 = ' ', LAYOUT1.tel2 = ' ', LAYOUT1.tel3 = ' ' ,LAYOUT1.tel4 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,LAYOUT1.tel3 = ' ' ,

*!*	FOR TT=1 TO 14
*!*		STORE ALLTRIM(STR(TT)) TO HH
*!*		
*!*		UPDATE O:\CLIENTES\397\DAT SET DAT.tel&HH=telpas.tel_1 from o:\clientes\397\telpas WHERE DAT.cuenta=telpas.cuenta AND telpas.tele=''+HH+''

*!*	ENDFOR
*!*	CLOSE DATABASES


*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel2=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='2'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel3=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='3'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel4=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='4'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel5=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='5'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel6=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='6'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel7=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='7'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel8=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='8'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel9=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='9'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel10=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='10'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel11=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='2'

*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel12=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='3'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel13=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='K'
*!*	UPDATE O:\CLIENTES\397\LAYOUT1 SET LAYOUT1.tel14=telpas.tel_1 from o:\clientes\397\telpas WHERE LAYOUT1.cuenta=telpas.cuenta AND telpas.tele='A'


*!*	UPDATE O:\CLIENTES\397\dat SET dat.tel1 = ' ', dat.tel2 = ' ', dat.tel3 = ' '
*!*	UPDATE dat SET dat.tel1=telpas.tel_1 from o:\clientes\397\telpas WHERE dat.cuenta=telpas.cuenta AND telpas.tele='H' and dat.fe_rec=DATE()
*!*	UPDATE dat SET dat.tel2=telpas.tel_1 from o:\clientes\397\telpas WHERE dat.cuenta=telpas.cuenta AND telpas.tele='T' and dat.fe_rec=DATE()
*!*	UPDATE dat SET dat.tel3=telpas.tel_1 from o:\clientes\397\telpas WHERE dat.cuenta=telpas.cuenta AND telpas.tele='O' and dat.fe_rec=DATE()

CLOSE TABLES 
