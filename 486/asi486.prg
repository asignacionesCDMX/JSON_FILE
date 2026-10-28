*IF MESSAGEBOX("ES ASIGNACION, DE LO CONTRARIO CANCELA",1)=1 THEN 
*ENDIF
SET CENTURY on
SET SAFETY OFF
SET DATE AMERICAN
SET HOURS TO 24

MESSAGEBOX("GENERANDO ARCHIVOS SCBSDOS|Y|SCBTEL",0,"486|BANCO BAJIO|",100)

************************ASIGNACION***********************
*********************************************************
*!*	** PODRA CAMBIAR LA RUTA


USE O:\DAT\GPO1\486\DAT
UPDATE o:\DAT\gpo1\486\dat SET direcc3=TRIM('0'+TRIM(DIRECC3)) where LEN(TRIM(DIRECC3))=4
UPDATE o:\DAT\gpo1\486\dat SET PVS='' WHERE PVS LIKE '%/%' OR pvs like '%-%' &&BORRADO DE PVS POR INGRESADO DE FECHAS ABYYL 12/11/22
UPDATE o:\DAT\gpo1\486\dat SET PVS=''  WHERE ISDIGIT (PVS)=.F. &&peticion de aem 
COPY TO O:\PRG\MEXGPO1\asi486\GPO1
CLOSE ALL

*!*	****************quita las cuentas que esten en megacable
*!*	USE O:\DAT\GPO1\471\DAT
*!*	RECALL all
*!*	DELETE FROM O:\DAT\GPO1\471\DAT WHERE cuenta in (sele cuenta FROM O:\DAT\GPO1\486\DAT)
*!*	COPY TO c:\dul471 FOR DELETED()
*!*	PACK
*!*	CLOSE TABLES

	 SELECT TIPO,COUNT(*) FROM O:\DAT\GPO1\486\DAT GROUP BY TIPO

CLOSE TABLES 

** ELIMINAR CTAS EN BLANCO 
USE O:\PRG\MEXGPO1\asi486\GPO1
RECALL ALL
DELETE FOR EMPTY(CUENTA)
PACK
CLOSE ALL

** ACOMPLETAR 0+DIRECC3
SELECT 1
USE O:\PRG\MEXGPO1\asi486\GPO1
SET FILTER TO LEN(ALLTRIM(DIRECC3))=4
REPLACE DIRECC3 WITH "0"+ALLTRIM(DIRECC3) ALL
SET FILTER TO
REPLACE DIRECC4 WITH STRTRAN(DIRECC4,"\","") ALL
CLOSE ALL

SELECT 1
USE O:\PRG\MEXGPO1\asi486\GPO1

SELECT 2
USE O:\PRG\MEXGPO1\ASI486\DATC
ZAP

SELECT 1
GO TOP

DO WHILE !EOF()
 
     IF GPO1.pag_min<0.00
     	     ws11 = "-"+RIGHT("00000000000000"+ALLTRIM(STR(((GPO1.pag_min)*-1),13,2)),14) 
     	   ELSE
     	     ws22 = RIGHT("000000000000000"+ALLTRIM(STR((GPO1.pag_min),13,2)),15) 
   ENDIF
   
    IF GPO1.saldo1<0.00
     	     wsdo1 = "-"+RIGHT("00000000000000"+ALLTRIM(STR(((GPO1.saldo1)*-1),13,2)),14) 
     	   ELSE
     	     wsdo2 = RIGHT("000000000000000"+ALLTRIM(STR((GPO1.saldo1),13,2)),15) 
   ENDIF
	 IF GPO1.saldo2<0.00
     	     ws2 = "-"+RIGHT("00000000000000"+ALLTRIM(STR(((GPO1.saldo2)*-1),13,2)),14) 
     	   ELSE
     	     wsd22= RIGHT("000000000000000"+ALLTRIM(STR((GPO1.saldo2),13,2)),15) 
   ENDIF
 IF GPO1.saldo3<0.00
     	     ws3 = "-"+RIGHT("00000000000000"+ALLTRIM(STR(((GPO1.saldo3)*-1),13,2)),14) 
     	   ELSE
     	     ws33 = RIGHT("000000000000000"+ALLTRIM(STR((GPO1.saldo3),13,2)),15) 
   ENDIF

   

  SELECT 2
   APPEND BLANK 
   REPLACE DMACCTG    WITH "1"
   REPLACE CUENTA     WITH ALLTRIM("486-"+ALLTRIM(GPO1.folio))
*!*	   REPLACE CUENTA     WITH ALLTRIM(GPO1.cuenta)
 *  REPLACE u1asigdte  WITH SUBSTR(DTOC(GPO1.FE_REC),1,2)+SUBSTR(DTOC(GPO1.FE_REC),4,2)+"20"+SUBSTR(DTOC(GPO1.FE_REC),7,2)  &&&04082022
    REPLACE u1asigdte  WITH SUBSTR(DTOC(GPO1.FE_REC),1,2)+SUBSTR(DTOC(GPO1.FE_REC),4,2)+SUBSTR(DTOC(GPO1.FE_REC),7,4)  
*   REPLACE u1diasmact WITH ALLTRIM(GPO1.pvs)&&& prueba
   *REPLACE u1diasmact WITH RIGHT("000"+ALLTRIM(GPO1.PVS),3)
   REPLACE dmcurbal   WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.sdo_act,13,2)),15)
*   REPLACE u1pagmin   WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.GASTOS,13,2)),15)
  * REPLACE dmamtdlq   WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.CAPITAL,13,2)),15)
     REPLACE dmamtdlq   WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.sdo_vdo,13,2)),15)   &&& por diana bedolla : REQ 2020-023980  03032020

   *REPLACE dmopndt    WITH SUBSTR(DTOC(DATE()),1,2)+SUBSTR(DTOC(DATE()),4,2)+"20"+SUBSTR(DTOC(DATE()),7,2)
   REPLACE dmname      WITH ALLTRIM(GPO1.nombre1)
   REPLACE dmaddr1     WITH ALLTRIM(GPO1.direcc1)
   REPLACE dmaddr2     WITH UPPER(ALLTRIM(GPO1.direcc2))
   REPLACE dmcity      WITH UPPER(ALLTRIM(GPO1.direcc4))
   REPLACE dmzip       WITH ALLTRIM(GPO1.direcc3)
   REPLACE dmphone     WITH ALLTRIM(GPO1.gestor1)  &&&
   *REPLACE u1ext2      WITH "00000"
   *REPLACE dmcphone    WITH ALLTRIM(GPO1.tel3)
   *REPLACE dmstate     WITH ALLTRIM(GPO1.edo)
*   REPLACE u1corte     WITH RIGHT("00"+ALLTRIM(GPO1.CICLO),2)
   *REPLACE u1mesven    WITH ALLTRIM(GPO1.mes_vdo)
   *REPLACE u1fedev     WITH SUBSTR(DTOC(GPO1.FE_REG),1,2)+SUBSTR(DTOC(GPO1.FE_REG),4,2)+"20"+SUBSTR(DTOC(GPO1.FE_REG),7,2)
   REPLACE u1fedev     WITH SUBSTR(DTOC(GPO1.FE_REG),1,2)+SUBSTR(DTOC(GPO1.FE_REG),4,2)+SUBSTR(DTOC(GPO1.FE_REG),7,4)
   REPLACE u1estratg1  WITH ALLTRIM(GPO1.tipo)
   *REPLACE u1estratg3  WITH ALLTRIM(GPO1.nombre2)
   *REPLACE u1producto  WITH ALLTRIM(GPO1.GESTOR1)
   REPLACE u1ftecar    WITH "BANCO BAJIO"
   REPLACE u1folio     WITH ALLTRIM(GPO1.folio)
   *REPLACE u1rfc       WITH ALLTRIM(GPO1.nombre2)
   REPLACE u1estratg4  WITH ALLTRIM(GPO1.RIESGO) &&&etiqueta prime, 22/05/2020 por osiris, kevin/riesgo
   *REPLACE u1estratg4  WITH "FE_CAS="+ALLTRIM(GPO1.RIESGO)
   REPLACE dmssnum     WITH ALLTRIM(GPO1.CUENTA)
   
*   REPLACE u1dmorasig  WITH RIGHT("000"+ALLTRIM(GPO1.PVS),3)
  * REPLACE u1dmorasig  WITH ALLTRIM(GPO1.PVS)
   REPLACE u1email     WITH ALLTRIM(GPO1.DES_PROD)
*!*	   REPLACE u1actasig  WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.SALDO1,13,2)),15)
*!*	   REPLACE u1vdoasig  WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.Saldo2,13,2)),15)   
*!*	   REPLACE u1minasig  WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.SALDO3,13,2)),15)
   
   REPLACE u1actasig  WITH IIF((GPO1.saldo1)<0.00, wsdo1,wsdo2)
   REPLACE u1vdoasig  WITH IIF((GPO1.saldo2)<0.00, ws2,wsd22) 
   REPLACE u1minasig  WITH IIF((GPO1.saldo3)<0.00, ws3,ws33)
   
    REPLACE u1pagmin WITH IIF((GPO1.pag_min)<0.00, ws11,ws22)
    

   REPLACE dmcompany   WITH ALLTRIM(GPO1.cliente)
   *REPLACE dmdlqdt     WITH SUBSTR(DTOC(DATE()),1,2)+SUBSTR(DTOC(DATE()),4,2)+"20"+SUBSTR(DTOC(DATE()),7,2)
   *REPLACE dmacumint   WITH RIGHT("000000000000000"+ALLTRIM(STR(GPO1.saldo3,13,2)),15)
   REPLACE DMADL1      WITH ALLTRIM(GPO1.folio)
   **************************** CÓDIGO: REQ 2016-094403*****************
   *REPLACE u1uso1 WITH ALLTRIM(gpo1.saldo1)
   REPLACE u1uso1 WITH ALLTRIM(STR((gpo1.saldo1),13,2))
   REPLACE u1uso2 WITH ALLTRIM(STR((gpo1.saldo2),13,2))
   REPLACE u1uso3 WITH ALLTRIM(STR((gpo1.saldo3),13,2))
   *REPLACE u1uso1 WITH ALLTRIM(GPO1.DES_PROD)
   REPLACE u1producto  WITH ALLTRIM(GPO1.nombre2)   &&&&&leyenda
   ***********************
   *REPLACE u1uso1       WITH 'CABL '+ALLTRIM(STR((GPO1.ADEU_CABLE),13,2))
   *REPLACE u1uso2       WITH 'PREM '+ALLTRIM(STR((GPO1.ADEU_PREM),13,2))
   *REPLACE u1uso3       WITH 'INTE '+ALLTRIM(STR((GPO1.ADEU_INT),13,2))
   *REPLACE u1uso4       WITH 'TELE '+ALLTRIM(STR((GPO1.MENSUALIDA),13,2))
   *REPLACE u1uso5       WITH 'CADI '+ALLTRIM(STR((GPO1.CON_ADI),13,2))
   *REPLACE u1uso6       WITH 'EQPO '+ALLTRIM(STR((GPO1.ADEU_EQUIP),13,2))
   REPLACE u1status     WITH ALLTRIM(GPO1.sub_cte)
   REPLACE dmptscor		WITH ALLTRIM(gpo1.sub_cte)   &&REQ 2019-019668 x yolanda
   REPLACE u1programa   WITH ALLTRIM(GPO1.segmento)&&REQ 2020-011266 X OSIRIS FAVILA LO REALIZA KEVIN SOLIS
*!*	   REPLACE u1estratg3   WITH ALLTRIM(GPO1.TIPO)&&REQ 2020-011266 X OSIRIS FAVILA LO REALIZA KEVIN SOLIS
   REPLACE u1estratg2   WITH ALLTRIM(GPO1.tramo)
   REPLACE dmbphone    WITH ALLTRIM(GPO1.SEG)   &&&&REQ 2020-046027  PPOR OSIRIS GPE
   REPLACE u1estratg3   WITH ALLTRIM(GPO1.estra3)
   replace u1arcod1 WITH  ALLTRIM(GPO1.PVS)  &&&REQ 2021-106372 solicito diana 
   replace dmcphone WITH  ALLTRIM(GPO1.garan) &&&&REQ 2021-024042 DIANA ROX
   replace u1arcod3 WITH ALLTRIM(GPO1.REE) &&REQ 2021-119270 DIANA ROX 
   replace u1arcod2 WITH ALLTRIM(GPO1.ETIQUETA) &&REQ 2021-109712 DIANA
   replace dmp2 WITH ALLTRIM(GPO1.ETIQUETA5) &&&REQ 2023-067064 DIANA 13/07/2023
   replace dmphone WITH ALLTRIM(GPO1.ETIQUETA1) &&&REQ 2023-067064 DIANA 13/07/2023

 
   wedo = SPACE(5)
   DO CASE
     CASE dmzip >= "01000" .and. dmzip <= "19999" 
          wedo = "CDMX"
     CASE dmzip >= "20000" .and. dmzip <= "20999" 
          wedo = "AGS"
     CASE dmzip >= "21000" .and. dmzip <= "22999" 
          wedo = "BC"
     CASE dmzip >= "23000" .and. dmzip <= "23999" 
          wedo = "BCS"
     CASE dmzip >= "24000" .and. dmzip <= "24999" 
          wedo = "CAM"
     CASE dmzip >= "25000" .and. dmzip <= "27999" 
          wedo = "COAH"
     CASE dmzip >= "28000" .and. dmzip <= "28999" 
          wedo = "COL"
     CASE dmzip >= "29000" .and. dmzip <= "30999" 
          wedo = "CHIS"
     CASE dmzip >= "31000" .and. dmzip <= "33999" 
          wedo = "CHIH"
     CASE dmzip >= "34000" .and. dmzip <= "35999" 
          wedo = "DGO"
     CASE dmzip >= "36000" .and. dmzip <= "38999" 
          wedo = "GTO"
     CASE dmzip >= "39000" .and. dmzip <= "41999" 
          wedo = "GRO"
     CASE dmzip >= "42000" .and. dmzip <= "43999" 
          wedo = "HGO"
     CASE dmzip >= "44000" .and. dmzip <= "49999" 
          wedo = "JAL"
     CASE dmzip >= "50000" .and. dmzip <= "57999" 
          wedo = "MEX"
     CASE dmzip >= "58000" .and. dmzip <= "61999" 
          wedo = "MICH"
     CASE dmzip >= "62000" .and. dmzip <= "62999" 
          wedo = "MOR"
     CASE dmzip >= "63000" .and. dmzip <= "63999" 
          wedo = "NAY"
     CASE dmzip >= "64000" .and. dmzip <= "67999" 
          wedo = "NL"
     CASE dmzip >= "68000" .and. dmzip <= "71999" 
          wedo = "OAX"
     CASE dmzip >= "72000" .and. dmzip <= "75999" 
          wedo = "PUE"
     CASE dmzip >= "76000" .and. dmzip <= "76999" 
          wedo = "QRO"
     CASE dmzip >= "77000" .and. dmzip <= "77999" 
          wedo = "QROO"
     CASE dmzip >= "78000" .and. dmzip <= "79999" 
          wedo = "SLP"
     CASE dmzip >= "80000" .and. dmzip <= "82999" 
          wedo = "SIN"
     CASE dmzip >= "83000" .and. dmzip <= "85999" 
          wedo = "SON"
     CASE dmzip >= "86000" .and. dmzip <= "86999" 
          wedo = "TAB"
     CASE dmzip >= "87000" .and. dmzip <= "89999" 
          wedo = "TAMP"
     CASE dmzip >= "90000" .and. dmzip <= "90999" 
          wedo = "TLAX"
     CASE dmzip >= "91000" .and. dmzip <= "96999" 
          wedo = "VER"
     CASE dmzip >= "97000" .and. dmzip <= "97999" 
          wedo = "YUC"
     CASE dmzip >= "98000" .and. dmzip <= "99999" 
          wedo = "ZAC"
   ENDCASE
   REPLACE DMSTATE    WITH wedo
   SELECT 1
   SKIP
ENDDO 
CLOSE ALL

** Actualiza DMSSNUM
*!*	SELECT 1
*!*	USE DATC
*!*	REPLACE DMSSNUM WITH ALLTRIM(CUENTA) FOR EMPTY(dmssnum)
*!*	CLOSE TABLES 

****cuentas-bases
**UPDATE O:\PRG\MEXGPO1\asi486\DATC SET u1estratg2=SEGMENTA_CICLO.SEGMENTA from O:\PRG\MEXGPO1\asi486\SEGMENTA_CICLO WHERE datc.cuenta=SEGMENTA_CICLO.cuenta   &&&&&OSIRIS FAVILA Y DIANA BEDOLA  REQ 2020-008550 & REQ 2020-007796 apartir del 23/01/2020 ROX
*!*	UPDATE O:\PRG\MEXGPO1\asi486\DATC SET u1estratg3=clasificacion.clasifica from O:\PRG\MEXGPO1\asi486\clasificacion WHERE datc.dmssnum=clasificacion.cuenta   &&&&&OSIRIS FAVILA   REQ 2020-010041  apartir del 25/01/2020 ROX
*UPDATE O:\PRG\MEXGPO1\asi486\DATC SET dmp1=sub_pro.pro from O:\PRG\MEXGPO1\asi486\sub_pro WHERE datc.cuenta=sub_pro.cuenta   &&&&&OSIRIS FAVILA   REQ 2020-010041  apartir del 25/01/2020 ROX
UPDATE O:\PRG\MEXGPO1\asi486\DATC SET dmp2=eti.etiqueta from O:\PRG\MEXGPO1\asi486\eti WHERE datc.dmssnum=eti.cuenta   &&&&&OSIRIS FAVILA   REQ 2020-010041  apartir del 25/01/2020 ROX *** ETIQUETA5

UPDATE O:\PRG\MEXGPO1\asi486\DATC SET u1uso4=STATUS.ESTATUS from O:\PRG\MEXGPO1\asi486\STATUS WHERE datc.dmssnum=STATUS.cuenta  &&&REQ 2020-051277 diana perez  15/05/2020
UPDATE O:\PRG\MEXGPO1\asi486\DATC SET dmp1=dm1.etiqueta from O:\PRG\MEXGPO1\asi486\dm1 WHERE datc.dmssnum=dm1.cuenta  &&&osiris 25/05/2020 REQ 2020-054755   por  gp3
UPDATE O:\PRG\MEXGPO1\asi486\DATC SET U1EXT2=TOP.etiqueta from O:\PRG\MEXGPO1\asi486\top WHERE datc.cuenta=top.cuenta2  &&&YOLANDA 17/11/2020 REQ 2020-123954   por  gp3 CUENTAS TOP*** ETIQUETA6
**UPDATE O:\PRG\MEXGPO1\asi486\DATC SET dmcphone=garantizada.garan from O:\PRG\MEXGPO1\asi486\garantizada WHERE datc.dmssnum=garantizada.cuenta  &&&diana laura 05/03/2021 REQ 2021-024042 por rox
**UPDATE O:\PRG\MEXGPO1\asi486\DATC SET u1arcod2=covid.etiqueta from O:\PRG\MEXGPO1\asi486\covid WHERE datc.dmssnum=covid.cuenta  &&&diana laura 27/10/2021 REQ 2021-109712 por rox
UPDATE O:\PRG\MEXGPO1\asi486\DATC SET dmphone=eti486.mora from O:\PRG\MEXGPO1\asi486\eti486 WHERE datc.cuenta=eti486.cuenta2  &&&REQ 2020-051277 diana perez  15/05/2020  ETIQUETA1

SELECT u1asigdte, u1fedev ,COUNT(*) FROM datc GROUP BY u1asigdte , u1fedev 
     


**** CUENTA LAS CUENTAS ********
*!*	USE GPO1
*!*	SELECT NOMBRE1,COUNT(NOMBRE1) FROM DAT GROUP BY NOMBRE1;
*!*	INTO DBF O:\GRUPO1\ASI486\ASIGNACION\CONTEO
*!*	CLOSE ALL

*!*	USE CONTEO
*!*	ALTER TABLE CONTEO ALTER cnt_nombre Character(5)
*!*	CLOSE ALL

*!*	UPDATE DATC SET DATC.u1estratg4=CONTEO.cnt_NOMBRE FROM CONTEO WHERE DATC.dmname=CONTEO.NOMBRE1
*!*	CLOSE ALL

*!*	USE DATC
*!*	REPLACE u1estratg4 WITH 'CTA'+' '+ALLTRIM(u1estratg4) ALL
*!*	CLOSE ALL

**** ARCHIVO SALDOS TXT


CLOSE TABLES 

USE O:\prg\MEXGPO1\ASI486\DATC
DELETE ALL
INDEX on cuenta TO xh1 uniq
RECALL all
CLOSE INDEXES 
CLOSE tables


***QUITA CUENTAS DE GUERRERO
*!*	STORE DATE() TO hoy
*!*	?hoy
*!*	IF hoy<>DATE(2023,11,16)
*!*		MESSAGEBOX("Se quitan cuentas de guerrero")
*!*		DELETE FROM  O:\prg\MEXGPO1\ASI486\DATC WHERE DMSTATE='GRO'
*!*		CLOSE TABLES
*!*		USE  O:\prg\MEXGPO1\ASI486\DATC 
*!*		PACK
*!*		CLOSE TABLES 
*!*	ELSE 
*!*		MESSAGEBOX("ya no hay exclusion")

*!*	ENDIF
****************************************
CLEAR
SET SAFETY OFF

*!DEL *.TXT
*IF MESSAGEBOX("DESEAS CREAR LOS ARCHIVOS DE SALIDA SCBSDOS Y SCBTEL|RECUERDA QUE ANTES TENIAS QUE DESCOMETAR EL CLIENTE CORRECTO",1)=1 THEN
SELECT 1
*!*	USE SCBSDOS
*!*	ZAP
USE O:\prg\MEXGPO1\ASI486\DATC

REPLACE DMCURBAL WITH STRTRAN(DMCURBAL, "-","0") ALL
REPLACE U1PAGMIN WITH STRTRAN(U1PAGMIN, "-","0") ALL
REPLACE DMAMTDLQ WITH STRTRAN(DMAMTDLQ, "-","0") ALL
COPY TO O:\prg\MEXGPO1\ASI486\SCBSDOS SDF
CLOSE ALL

**** TELEFONOS
CD O:\PRG\MEXGPO1\asi486
DO TELBNX


**** ARCHIVO SALDOS Y TELEFONOS TXT*****
CLOSE ALL




SELECT 1
CD o:\prg\mexgpo1\asi486
USE SCBTEL1 EXCLUSIVE 
ZAP
APPEND FROM O:\prg\MEXGPO1\ASI486\TELSAN
COPY TO SCBTEL SDF

** SALDOS
*DO SSHS

** TELEFONOS
*DO SSHT


*IF MESSAGEBOX("SI ES ASIGNACIÓN DALE ACEPTAR, SI ES ACTUALIZACIÓN O RETIRO DALE CANCELAR", 1)= 1 THEN
*ENDIF 
*!*	SET CENTURY ON
*!*	CLOSE ALL

*!*	ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyberdti" + ";DSN='';Trusted_Connection=no")
*!*	sqlselect = "update flags_cyber2 set horaf=getdate(),estatus='Procesado' where identifica='ABB1';"
*!*	SQLEXEC(ConHnd2,sqlselect)

*!*	****************************************************************************************************
*!*	ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyberdti" + ";DSN='';Trusted_Connection=no")
*!*	sqlselect = "update flags_cyber_his set horaF=getdate(), estatus='Finalizando' where proceso='Asignacion Banco Bajio';"
*!*	SQLEXEC(ConHnd2,sqlselect)

*!*	ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyberdti" + ";DSN='';Trusted_Connection=no")
*!*	sqlselect = "INSERT INTO flags_cyber_COM (PROCESO,DESCRIPCION,HORA,ESTATUS,IDENTIFICA,CLIENTE,GRUPO,CARTERA,SUCURSAL) VALUES ('Asignacion Banco Bajio','Termina proceso',GETDATE(),'Termina Asig','AABPY','486','1','BANCO BAJIO','CDMX');"
*!*	SQLEXEC(ConHnd2,sqlselect)

***************************************************************************************************
*ENDIF

DO o:\prg\gpo1\486\resdat.prg
