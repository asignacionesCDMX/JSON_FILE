CLOSE ALL
SET CENTURY ON
SET SAFETY OFF
SET HOURS TO 24
SET CENTURY ON

*!*		STORE 'c:\CONS.xlsb' to consumo
*!*		STORE 'c:\TDC.xlsb' to tdc

*!*	STORE 'c:\SERTEC_Saldos_tdc.xlsb' TO saldo
*!*	STORE 'c:\SERTEC_Saldos_Cons.xlsb' TO consumo
*!*	STORE 'c:\SERTEC_Pagos.xlsb' TO pago
*!*	STORE 'c:\SERTEC_Saldos_Hip.xlsb' TO hipot

*!*	CD c:\zip
*!*	SET SAFETY OFF
*!*	SET CENTURY on
*!*	SET DATE AMERICAN
*!*	SET CENTURY ON
*!*		SET DATE AMERICAN
*!*		FECHA=DATE()
*!*		MMY=SUBSTR(DTOC(FECHA),1,2)
*!*		DIA=SUBSTR(DTOC(FECHA),4,2)
*!*		AAAA=SUBSTR(DTOC(FECHA),7,4)

*!*		STORE ALLTRIM(STR(MONTH(DATE()))) TO MEST
*!*		STORE ALLTRIM(STR(YEAR(DATE()))) TO YYY

*!*		IF LEN(MEST)=1
*!*		MEST='0'+MEST
*!*		ENDIF

*!*		****************ENCRIPTA ARCHIVOS
*!*		SET CENTURY ON
*!*		SET DATE AMERICAN
*!*		
*!*		SET PATH TO FULLPATH(CURDIR())
*!*		SET CLASSLIB TO 'zip.vcx' ADDITIVE 
*!*		*!* Creamos el objeto
*!*		oZip=CREATEOBJECT('Zip.Zip')
*!*		
*!*		*!* CREAR UN ARCHIVO ZIP
*!*		WITH oZip
*!*			.ArchivoZip='c:\ACTUALIZACION_DE_PAGOS.zip'	&& Ruta y nombre del archivo ZIP
*!*				.ArchivosIncluir='&consumo|&saldo|&pago|&hipot'	&& Archivos a inlcuir 
*!*		    .Contraseña='Sertec_'+MMY+AAAA	&& Proteger el zip con una contraseña, Opcional
*!*			*.Comentario='Mi Comentario'	&& Comentario del ZIP
*!*			?'---------------------'
*!*			?'Comprimiendo archivo ZIP '
*!*			?.Comprimir()	&& Crear el zip y mostrar en pantalla la cantidad e archivos procesoados 
*!*			?'---------------------'
*!*		ENDWITH 

STORE DTOC(date()) TO f
STORE SUBS(f,7,4) TO aa   && año
STORE SUBS(f,4,2) TO dd	  && dia
STORE SUBS(f,1,2) TO mmy  && mes

DO CASE
   CASE mmy ='01'
        mes='ENERO'
   CASE mmy ='02'
        mes='FEBRERO'
   CASE mmy ='03'
        mes='MARZO'
   CASE mmy ='04'
        mes='ABRIL'
   CASE mmy ='05'
        mes='MAYO'
   CASE mmy ='06'
        mes='JUNIO'
   CASE mmy ='07'
        mes='JULIO'
   CASE mmy ='08'
        mes='AGOSTO'
   CASE mmy ='09'
        mes='SEPTIEMBRE'
   CASE mmy ='10'
        mes='OCTUBRE'
   CASE mmy ='11'
        mes='NOVIEMBRE'
   CASE mmy ='12'
        mes='DICIEMBRE'
ENDCASE

*!*	?"C:\ACTUALIZACION_DE_PAGOS.zip"

*!*	act = DIRECTORY('\\192.168.90.45\CYBER\CONFIDENCIAL\ASIGNACIONES\GPO1\486\ARCHIVOS_ORIGINALES\&aa\&mes\&dd\')

*!*	IF act = .F.
*!*		MKDIR('\\192.168.90.45\CYBER\CONFIDENCIAL\ASIGNACIONES\GPO1\486\ARCHIVOS_ORIGINALES\&aa\&mes\&dd\')
*!*		?'\\192.168.90.45\CYBER\CONFIDENCIAL\ASIGNACIONES\GPO1\486\ARCHIVOS_ORIGINALES\&aa\&mes\&dd\'
*!*	ENDIF

*!*		
*!*		IF FILE("C:\ACTUALIZACION_DE_PAGOS.zip")=.t. &&Si existe archivo, entra 
*!*		!COPY C:\ACTUALIZACION_DE_PAGOS.zip \\192.168.90.45\CYBER\CONFIDENCIAL\ASIGNACIONES\GPO1\486\ARCHIVOS_ORIGINALES\&aa\&mes\&dd\ACTUALIZACION_DE_PAGOS.zip &&Copia archivo .extensión a otro destino

*!*	ELSE
*!*	    MESSAGEBOX('No se crea respaldo')
*!*	endif

USE o:\asigna\asignaciones
UPDATE o:\asigna\asignaciones SET HR_INICIO=TIME(), HR_FIN='', FECHA=DATE() WHERE CLIENTE='486' AND PROCESO='ACT'
CLOSE TABLES

*-----------BITACORA------------*
	USE O:\DAT\GPO1\486\bitact
	ZAP
	INSERT INTO O:\DAT\GPO1\486\bitact (fecha,PRO) VALUES (DATE(),'ACT')
	US= INPUTBOX('INGRESA TUS CLAVES')
	REPLACE USUARIO WITH US
	ll= INPUTBOX('INGRESA HORA QUE LLEGO LA ASIGNACION HH:MM:SS','FORMATO HH:MM:SS')
	REPLACE llego WITH ll

	CLOSE TABLES


	CD o:\prg\gpo1\486
	DO respaldo2
	CLOSE TABLES
	
	
	CD o:\dat\gpo1\486
	USE dat
	COPY TO c:\dat_ant486
	CLOSE TABLES 
	
	use o:\dat\gpo1\486\pagos486
	ZAP
	use o:\dat\gpo1\486\act_tdc
	ZAP
	use o:\dat\gpo1\486\act_cons
	ZAP
	USE o:\dat\gpo1\486\act_hip
    ZAP
    CLOSE TABLES
    
IF FILE ("C:\SERTEC_Pagos.CSV")
	MESSAGEBOX('BASE DE PAGOS',40,10)
	use o:\dat\gpo1\486\pagos486
	ZAP
	APPEND FROM c:\SERTEC_Pagos csv
	
	*REPLACE fe WITH SUBSTR(fecha2,4,2)+'/'+SUBSTR(fecha2,1,2)+'/'+SUBSTR(fecha2,9,2) all
	REPLACE fe WITH SUBSTR(fecha2,6,2)+'/'+SUBSTR(fecha2,9,2)+'/'+SUBSTR(fecha2,1,4) all

    UPDATE pagos486 SET fecha=CTOD(fe)
    
    LOCATE FOR pagos486.FECHA = DATE()-1
	IF FOUND()
		MESSAGEBOX("LOS PAGOS SI ESTAN ACTUALIZADOS",10,200)
	ELSE 
		MESSAGEBOX("LOS PAGOS NO ESTAN ACTUALIZADOS",60,200)
		
		IF MESSAGEBOX("DESEAS MANDAR CORREO DE AVISO",1)=1 THEN
			DO O:\PRG\GPO1\486\mail_pagos
		ENDIF
	ENDIF

	CLOSE TABLES 
ENDIF	

IF FILE ("C:\SERTEC_Saldos_tdc.CSV")
	MESSAGEBOX('ACTUALIZACION TDC',40,10)
	use o:\dat\gpo1\486\act_tdc
	APPEND FROM c:\SERTEC_Saldos_tdc csv
	CLOSE TABLES 
ENDIF

IF FILE ("C:\SERTEC_Saldos_Cons.CSV")
	MESSAGEBOX('ACTUALIZACION CONSUMO',40,10)
	use o:\dat\gpo1\486\act_cons
	APPEND FROM c:\SERTEC_Saldos_Cons csv
	CLOSE TABLES 
ENDIF

IF FILE ("C:\SERTEC_Saldos_Hip.CSV")
	MESSAGEBOX('ACTUALIZACION HIPOTECARIO',40,10)
    USE o:\dat\gpo1\486\act_hip
    APPEND FROM C:\SERTEC_Saldos_Hip csv
ENDIF
**************
*!*	MESSAGEBOX('NECESITAS -DES_PROD /	SDO_ACT /	 PAGOS /	SEGMENTO_ACT-')


******TDC
MESSAGEBOX('tdc')
CD O:\PRG\GPO1\486
USE tdc
ZAP
SET DEFAULT TO c:\
*!*	APPEND FROM TDC486 CSV
APPEND FROM o:\dat\gpo1\486\act_tdc
BROWSE
CLOSE TABLES

CD O:\PRG\GPO1\486
USE tdc
update tdc SET tdc.des_prod=DAT.des_prod from O:\DAT\GPO1\486\DAT WHERE tdc.riesgo=DAT.riesgo
update tdc SET tdc.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE tdc.riesgo2=DAT.riesgo
*
update tdc SET tdc.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE tdc.DES_PROD=DAT.DES_PROD
*
update tdc SET tdc.SEGMENTO='TDC'
*update tdc SET tdc.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE tdc.riesgo1=DAT.riesgo
*UPDATE tdc SET FECHA=CTOD(SUBSTR(fECHA1,4,2)+'/'+SUBSTR(fECHA1,1,2)+'/'+SUBSTR(fECHA1,7,4))
REPLACE fe WITH SUBSTR(fecha2,4,2)+'/'+SUBSTR(fecha2,1,2)+'/'+SUBSTR(fecha2,9,2) all
UPDATE tdc SET fecha=CTOD(fe)

BROWSE
SELECT cuenta ;
FROM O:\PRG\GPO1\486\TDC ;
WHERE !EMPTY(cuenta) ;
  AND (ALLTRIM(seg) IN ('CERR','NORM') OR seg = '0' OR seg = '-' OR sdo_act <= 0) ;
INTO TABLE C:\DEVOLUCION

CLOSE TABLES


*****HIPOTECARIO
MESSAGEBOX('hipotecario')

CD O:\PRG\GPO1\486
USE HIP
ZAP
*!*	SET DEFAULT TO c:\
*!*	APPEND FROM HIP486 CSV
APPEND FROM o:\dat\gpo1\486\act_hip
BROWSE
CLOSE TABLES

CD O:\PRG\GPO1\486
USE hip
*!*	update hip SET hip.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE hip.des_prod2=DAT.des_prod
update hip SET hip.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE hip.des_prod2=DAT.CUENTA &&&&&REQ 2021-083154 LO SOLICITA DULCE&&&
update hip SET hip.SEGMENTO='HIPOTECARIO'
REPLACE fe WITH SUBSTR(fecha2,4,2)+'/'+SUBSTR(fecha2,1,2)+'/'+SUBSTR(fecha2,9,2) all
UPDATE hip SET fecha=CTOD(fe)

browse
CLOSE TABLES

******CONSUMO
MESSAGEBOX('consumo')
CD O:\PRG\GPO1\486
USE CONSUMO
ZAP
SET DEFAULT TO c:\
*APPEND FROM CONS486 csv
APPEND FROM o:\dat\gpo1\486\act_cons
BROWSE

CLOSE TABLES


CD O:\PRG\GPO1\486
USE consumo
*update consumo SET consumo.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE consumo.des_prod2=DAT.des_prod
UPDATE CONSUMO SET CUENTA=''
update consumo SET consumo.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE consumo.des_prod2=DAT.riesgo
update consumo SET consumo.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE consumo.des_prod2=DAT.cuenta &&& REQ 2021-082501 citlali** cambiaron el desprod por cuenta ISI
update consumo  SET consumo .SEGMENTO='CONSUMO'
REPLACE fe WITH SUBSTR(fecha2,4,2)+'/'+SUBSTR(fecha2,1,2)+'/'+SUBSTR(fecha2,9,2) all
UPDATE consumo SET fecha=CTOD(fe)
browse
CLOSE TABLES

****acfvm retiro cons ****
update consumo SET consumo.cuenta=DAT.cuenta from O:\DAT\GPO1\486\DAT WHERE consumo.des_prod=DAT.des_prod
SELECT cuenta ;
FROM O:\PRG\GPO1\486\CONSUMO ;
WHERE !EMPTY(cuenta) ;
  AND (seg = '0' OR seg = '-' OR sdo_act <= 0) ;
INTO CURSOR cur_temp

USE IN DAT
USE "O:\DAT\GPO1\486\DAT" IN 0 SHARED ALIAS dat_origen 

	SELECT CUENTA FROM dat_origen ;
			WHERE Sdo_act <= 0 AND CUENTA NOT IN (SELECT CUENTA FROM C:\DEVOLUCION);
			INTO CURSOR rt_tmp	
USE IN DEVOLUCION
USE C:\DEVOLUCION IN 0 EXCLUSIVE
		SELECT DEVOLUCION
		APPEND FROM DBF('rt_tmp')
		APPEND FROM DBF('cur_temp')
		BROW
		USE IN dat_origen 
		USE IN rt_tmp
		USE IN cur_temp
		USE IN DEVOLUCION
		
	
	
	
*********** ACTUALIZACION
UPDATE O:\DAT\GPO1\486\bitact SET i_as=TIME()
CLOSE TABLES

CD o:\dat\gpo1\486
USE saldos
ZAP
APPEND FROM O:\PRG\GPO1\486\TDC
APPEND FROM O:\PRG\GPO1\486\HIP
APPEND FROM O:\PRG\GPO1\486\CONSUMO
DELETE FOR des_prod='  '
PACK

UPDATE saldos SET  pvs='0' WHERE pvs='#N/D' 
UPDATE saldos SET  pvs='0' WHERE EMPTY(pvs)  
UPDATE saldos SET  seg='' WHERE seg='#N/D'
COPY TO O:\DAT\GPO1\486\SALDOSINI FIELDS DES_PROD, SDO_ACT FOR !EMPTY(cuenta)
CLOSE TABLES

SELECT DES_PROD2, RIESGO, DES_PROD, MONTO, SDO_ACT FROM O:\DAT\GPO1\486\SALDOS WHERE STR(MONTO) LIKE '%-%' INTO CURSOR NG
COUNT TO NEG

IF NEG<>0

	COPY TO C:\PAGOS_NEGATIVOS
	CLOSE TABLES
	MESSAGEBOX('HAY PAGOS NEGATIVOS REVISALOS EN "C:\PAGOS_NEGATIVOS" E INFORMALE AL CLIENTE',16)
	MESSAGEBOX('SE CANCELARA EL PROCESO HASTA QUE TE MANDEN LA CORRECCION CORRE DE NUEVO.')

ELSE

	*!*	CD o:\dat\gpo1\486
	*!*	USE saldos
	*!*	ZAP
	*!*	SET DEFAULT TO c:\
	*!*	APPEND FROM ? csv
	*!*	DELETE FOR des_prod='  '
	*!*	pack
	*!*	BROWSE
	*!*	CLOSE TABLES



	update saldos SET saldos.folio=DAT.folio from O:\DAT\GPO1\486\DAT WHERE SALDOS.DES_PROD=DAT.DES_PROD 


		update O:\DAT\GPO1\486\DAT SET DAT.SDO_ACT=saldos.SDO_ACT, DAT.SEG=saldos.SEG from O:\DAT\GPO1\486\saldos WHERE DAT.des_prod=saldos.des_prod 

		update saldos SET observa1='DAT' WHERE des_prod IN(SELECT des_prod FROM O:\DAT\GPO1\486\DAT)
		update saldos SET saldos.CUENTA=DAT.CUENTA from O:\DAT\GPO1\486\DAT WHERE SALDOS.DES_PROD=dat.des_prod 
		update saldos SET saldos.folio=DAT.folio from O:\DAT\GPO1\486\DAT WHERE SALDOS.DES_PROD=DAT.DES_PROD 
		update saldos SET cuenta2='486-'+ALLTRIM(folio) &&&cuenta en cyber
	*!*		BROWSE
		CLOSE TABLES
		
		
		
		CD o:\dat\gpo1\486
	    USE saldos
	    DELETE FOR observa1=' '
	    DELETE FOR seg='#N/A'
	    PACK
		COPY TO c:\saldos.xls foxplus
		CLOSE TABLES 
		
		CD o:\dat\gpo1\486
	    USE saldos
		UPDATE SALDOS SET sdo_act1=RIGHT("000000000000000"+ALLTRIM(STR((sdo_act),13,2)),15)
	*!*		REPLACE qry WITH "update delqmst set DMCURBAL='"+sdo_act1+"' ,dmbphone='"+ALLTRIM(SEG)+"' Where dmacctg='1' And dmacct='"+ALLTRIM(cuenta2)+"';" ALL
		REPLACE qry WITH "update RCVRY.delqmst set DMCURBAL='"+sdo_act1+"' ,dmbphone='"+ALLTRIM(SEG)+"' Where dmacctg='1' And dmacct='"+ALLTRIM(cuenta2)+"';" ALL &&&&& REQ 2021-108685 solcita diana aplica 25/10/2021 rox
		APPEND BLANK
		REPLACE qry WITH "commit;"
		APPEND BLANK
		REPLACE qry WITH "exit;"
		COPY TO o:\dat\gpo1\486\act486.sql FIELDS qry SDF 
		CLOSE TABLES
		
		update O:\DAT\GPO1\486\DAT SET DAT.sdo_act=saldos.sdo_act, DAT.SEG=saldos.SEG from O:\DAT\GPO1\486\saldos WHERE DAT.des_prod=saldos.des_prod
		update O:\DAT\GPO1\486\DAT SET DAT.PVS=saldos.PVS  from O:\DAT\GPO1\486\saldos WHERE DAT.des_prod=saldos.des_prod AND saldos.SEGMENTO!='TDC'

		CLOSE TABLES
		
		
		
	    	MESSAGEBOX('pago minimo y saldo vencido')
			USE o:\dat\gpo1\486\pagomi
			ZAP
	*!*			SET DEFAULT TO c:\
			APPEND FROM o:\dat\gpo1\486\saldos
	*!*			DELETE FOR EMPTY(des_prod)
	*!*			PACK
	*!*			CD o:\dat\gpo1\486
	*!*	    	USE saldos

	*!*			update o:\dat\gpo1\486\pagomi SET pagomi.CUENTA=DAT.CUENTA from O:\DAT\GPO1\486\DAT WHERE pagomi.DES_PROD=dat.des_prod 
	*!*			update o:\dat\gpo1\486\pagomi  SET pagomi .folio=DAT.folio,pagomi.cuenta2='486-'+ALLTRIM(dat.folio) from O:\DAT\GPO1\486\DAT WHERE pagomi.DES_PROD=DAT.DES_PROD 
			REPLACE qry WITH "update RCVRY.delqmst set dmamtdlq='"+RIGHT("000000000000000"+ALLTRIM(STR((SDO_VDO),13,2)),15)+"' Where dmacct='"+ALLTRIM(cuenta2)+"';" ALL   &&& REQ 2020-023980 

			DELETE FOR EMPTY(cuenta)
			pack
			APPEND BLANK
			REPLACE qry WITH "commit;"
			APPEND BLANK
			REPLACE qry WITH "exit;"
			COPY TO o:\dat\gpo1\486\min486.sql FIELDS qry SDF 
			
			REPLACE qry WITH "update RCVRY.uda1 set u1pagmin='"+RIGHT("000000000000000"+ALLTRIM(STR((pag_min),13,2)),15)+"' Where u1acct='"+ALLTRIM(cuenta2)+"';" ALL
			REPLACE qry WITH "commit;"
			APPEND BLANK
			REPLACE qry WITH "exit;"
			COPY TO o:\dat\gpo1\486\pvs486.sql FIELDS qry SDF 
			
			CLOSE TABLES
			update O:\DAT\GPO1\486\DAT SET DAT.pag_min=pagomi.pag_min, DAT.sdo_vdo=pagomi.sdo_vdo  from O:\DAT\GPO1\486\pagomi WHERE DAT.des_prod=pagomi.des_prod 
			CLOSE TABLES
			


		
		ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyber" + ";DSN='';Trusted_Connection=no")
		sqlselect = "select * from reg_serv;"
		SQLEXEC(ConHnd2,sqlselect)
		COPY TO o:\dat\gpo1\486\reg_serv
		CLOSE TABLES
		SQLDISCONNECT(ConHnd2)

		****ASIGNA A CADA UNA DE LAS VARIABLES LA INFORMACION PARA LA CONEXION DE LAS BASE DE DATOS
		ALTER table o:\dat\gpo1\486\reg_serv ADD COLUMN qry c(100)
		ALTER table o:\dat\gpo1\486\reg_serv ADD COLUMN qry2 c(100)
		UPDATE o:\dat\gpo1\486\reg_serv SET qry=ALLTRIM(campo1)+" "+ALLTRIM(campo2)+"/"+ALLTRIM(campo3)+"@"+alltrim(campo4)+"/"+ALLTRIM(campo5)+" @"
		UPDATE o:\dat\gpo1\486\reg_serv SET qry2="sqlldr"+" "+ALLTRIM(campo2)+"/"+ALLTRIM(campo3)+"@"+alltrim(campo4)+"/"+ALLTRIM(campo5)+" control="
		CLOSE tables


		use o:\dat\gpo1\486\reg_serv
		LOCATE FOR campo2='SACASIG'
		STORE qry TO mex
		me5=mex+"o:\dat\gpo1\486\pvs486.sql"
		me3=mex+"o:\dat\gpo1\486\act486.sql"
		me4=mex+"o:\dat\gpo1\486\min486.sql"
		RUN &me3
		RUN &me4
		RUN &me5
		CLOSE ALL




			CD o:\prg\gpo1\486
			DO resdat
			
		
		
		
	*!*		IF MESSAGEBOX('ACTUALIZA ARCHIVO DE SALDOS','AVISO!!!!',1)=1 THEN
	*!*		 	CD O:\prg\MEXGPO1\ASI486
	*!*		 	DO ASI486
	*!*	 	endif
	*!*			
        ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyber" + ";DSN='';Trusted_Connection=no")
		sqlselect = "select * from reg_serv;"
		SQLEXEC(ConHnd2,sqlselect)
		COPY TO O:\PRG\GPO1\486\PAGOS\reg_serv
		CLOSE TABLES
		SQLDISCONNECT(ConHnd2)

		****ASIGNA A CADA UNA DE LAS VARIABLES LA INFORMACION PARA LA CONEXION DE LAS BASE DE DATOS
		ALTER table O:\PRG\GPO1\486\PAGOS\reg_serv ADD COLUMN qry c(100)
		ALTER table O:\PRG\GPO1\486\PAGOS\reg_serv ADD COLUMN qry2 c(100)
		UPDATE O:\PRG\GPO1\486\PAGOS\reg_serv SET qry=ALLTRIM(campo1)+" "+ALLTRIM(campo2)+"/"+ALLTRIM(campo3)+"@"+alltrim(campo4)+"/"+ALLTRIM(campo5)+" @"
		UPDATE O:\PRG\GPO1\486\PAGOS\reg_serv SET qry2="sqlldr"+" "+ALLTRIM(campo2)+"/"+ALLTRIM(campo3)+"@"+alltrim(campo4)+"/"+ALLTRIM(campo5)+" control="
		CLOSE tables
					
		IF MESSAGEBOX('AHORA CORRE PAGOS Y ARRIBALOS A CYBER',1)=1 THEN
			CD O:\PRG\GPO1\486\PAGOS
			DO PAGOS
			CLOSE TABLES
		ENDIF	
		
		MESSAGEBOX('CONTINUA SI YA SUBISTE PAGOS',16)
		
			&&VALIDACION DE ARRIBO DE PAGOS JOSEPH 23/08/22
			USE o:\dat\gpo1\486\reg_serv
			LOCATE FOR campo2='SACASIG'
			STORE qry TO MEX
			CLOSE TABLES
			BAJ1=MEX+"O:\PRG\GPO1\486\PAGOS\baj.sql"
			RUN &BAJ1
			USE O:\PRG\GPO1\486\PAGOS\PAG_ARR
			ZAP
			APPEND FROM O:\PRG\GPO1\486\PAGOS\BAJPAG.TXT TYPE DELIMITED WITH CHARACTER "|"
			CLOSE TABLES
			
			USE C:\SCBPAG_ARR
			COUNT TO ARRI
			CLOSE TABLES
			USE O:\PRG\GPO1\486\PAGOS\PAG_ARR
			COUNT TO BAJAS
			CLOSE TABLES
			
			IF ARRI<>BAJAS THEN
				MESSAGEBOX('LOS PAGOS NO CUADRAN REVISA',16)
				SELECT * FROM C:\SCBPAG_ARR WHERE CUENTA2 NOT IN (SELECT CUENTA FROM O:\PRG\GPO1\486\PAGOS\PAG_ARR)
				COPY TO C:\NO_SUBIERON486 FOXP
				MESSAGEBOX('¿YA REVISASTE LOS PAGOS? (C:\NO_SUBIERON486) CONTINUA')
				CLOSE TABLES
			ENDIF
			
		SELECT cuenta,sdo_act FROM o:\dat\gpo1\486\dat WHERE  cuenta in(SELECT cuenta FROM O:\DAT\GPO1\486\saldos)
		COPY TO c:\vista486
		CLOSE TABLES
			
		SELECT * FROM c:\vista486 WHERE ALLTRIM(CUENTA)+str(sdo_act) IN (SELECT ALLTRIM(CUENTA)+str(sdo_act) FROM c:\dat_ant486)
		COPY TO c:\igual486
		CLOSE TABLES
		
		
		SELECT cuenta,sdo_act FROM O:\DAT\GPO1\486\saldos WHERE cuenta NOT in(SELECT cuenta FROM c:\igual486)
		COPY TO c:\saldo_real
		CLOSE TABLES
		
		USE c:\saldo_real
		ALTER TABLE "c:\saldo_real.DBF" ADD saldo2 NUMERIC(20)
		update c:\saldo_real SET saldo_real.saldo2=dat_ant486.SDO_ACT from c:\dat_ant486 WHERE saldo_real.cuenta=dat_ant486.cuenta
		COPY TO c:\verifica.xls foxplus
		CLOSE TABLES 
		
		
		CD O:\PRG\GPO1\486
		DO estructura
		
		CLOSE TABLES
		

		MESSAGEBOX("CORREN SALDOS DEL 486")
		USE O:\DAT\GPO1\486\bitact
		UPDATE O:\DAT\GPO1\486\bitact SET I_SA=TIME()
		CLOSE TABLES
		
		CD o:\prg\mexgpo1\asi486
		DO asi486
		
		SELECT a.des_prod as DES_dat, b.des_prod as DES_INI, a.sdo_act as sdo_dat, b.sdo_act as sdo_INI FROM O:\dat\gpo1\486\dat a, O:\dat\gpo1\486\SALDOSINI b WHERE a.des_prod=b.des_prod  AND a.sdo_act<>b.sdo_act INTO CURSOR j
		COPY TO C:\SALDOSMAL
		COUNT TO SALMAL
		CLOSE TABLES
		
		IF SALMAL<>0
			MESSAGEBOX('HAY SALDOS QUE NO SE ACTUALIZARON REVISALOS',16)
			USE C:\SALDOSMAL
			BROWSE
			CLOSE TABLES
			MESSAGEBOX('¿YA REVISASTE LOS SALDOS?',16)
		ENDIF
		
		USE O:\DAT\GPO1\486\bitact
		UPDATE O:\DAT\GPO1\486\bitact SET F_SA=TIME()
		CLOSE TABLES
		
		MESSAGEBOX("YA ESTAN LOS SALDOS, SOLICITA ARRIBO A CYBER Y DA ENTER","GRUPO 1")
			
			UPDATE O:\DAT\GPO1\486\bitact SET SOL_CON=TIME()
			CLOSE tables
			MESSAGEBOX("YA TE AUTORIZARON EL ARRIBO A CYBER, CONTINUA")
			UPDATE O:\DAT\GPO1\486\bitact SET INI_CON=TIME()
			CLOSE tables

			UPDATE O:\DAT\GPO1\486\bitact SET F_AS=TIME()
			CLOSE TABLES
		
			
		IF MESSAGEBOX('DEVOLUCION pagos 486',1)=1 THEN &&REQ 2021-028883 APLICA 22/03/2021 SOLICITA GARFIAS ----ROX
			
*!*				USE C:\DEVOLUCION486
*!*				BROWSE
*!*				DELETE FOR cuenta=' '
*!*				PACK
*!*				BROWSE
*!*				CLOSE TABLES 
*!*				
*!*				USE O:\DAT\GPO1\486\devolucionpagos486
*!*				ZAP
*!*				APPEND FROM C:\DEVOLUCION486
*!*				UPDATE O:\DAT\GPO1\486\devolucionpagos486 SET  devolucionpagos486.cuenta=DEVOLUCION486.des_prod from c:\DEVOLUCION486 WHERE devolucionpagos486.des_prod=DEVOLUCION486.des_prod
*!*				BROWSE
*!*				COPY TO C:\DEVOLUCION
*!*				CLOSE TABLES

*******************Nuevo proceso solicitado por IVON GONZALEZ BARRIGA REQ 2025-099547 el día 25/11/2025			
			SELECT FOLIO FROM O:\DAT\GPO1\486\DAT WHERE CUENTA IN (SELECT CUENTA FROM C:\DEVOLUCION)
			COPY TO C:\RETIROS_PAG_486.xls FOXP
            CLOSE TABLES
*******************Zipeado de retiros			
			CD c:\zip
SET SAFETY OFF
SET CENTURY on
SET DATE AMERICAN
SET CENTURY ON
	SET DATE AMERICAN
	FECHA=DATE()
	MMY=SUBSTR(DTOC(FECHA),1,2)
	DIA=SUBSTR(DTOC(FECHA),4,2)
	AAAA=SUBSTR(DTOC(FECHA),7,4)

	STORE ALLTRIM(STR(MONTH(DATE()))) TO MEST
	STORE ALLTRIM(STR(YEAR(DATE()))) TO YYY

	IF LEN(MEST)=1
	MEST='0'+MEST
	ENDIF
	****************ENCRIPTA ARCHIVOS
	SET CENTURY ON
	SET DATE AMERICAN
	
	SET PATH TO FULLPATH(CURDIR())
	SET CLASSLIB TO 'zip.vcx' ADDITIVE 
	*!* Creamos el objeto
	oZip=CREATEOBJECT('Zip.Zip')
	
	*!* CREAR UN ARCHIVO ZIP
	WITH oZip
		.ArchivoZip="c:\RETIROS_PAG_486_"+STRTRAN(DTOC(DATE()),"/","")+STRTRAN(TIME(),":","")+".ZIP"	&& Ruta y nombre del archivo ZIP
			.ArchivosIncluir='c:\RETIROS_PAG_486.xls'	&& Archivos a inlcuir 
	    .Contraseña='*Bajio'+MMY+AAAA	&& Proteger el zip con una contraseña, Opcional
		*.Comentario='Mi Comentario'	&& Comentario del ZIP
		?'---------------------'
		?'Comprimiendo archivo ZIP '
		?.Comprimir()	&& Crear el zip y mostrar en pantalla la cantidad e archivos procesoados 
		?'---------------------'
	ENDWITH 
*************************Envio de correo retiros
	SET CENTURY ON
	SET DATE AMERICAN
	FECHA=DATE()
	MMY=SUBSTR(DTOC(FECHA),1,2)
	DIA=SUBSTR(DTOC(FECHA),4,2)
	AAAA=SUBSTR(DTOC(FECHA),7,4)

	STORE ALLTRIM(STR(MONTH(DATE()))) TO MEST
	STORE ALLTRIM(STR(YEAR(DATE()))) TO YYY

	IF LEN(MEST)=1
	MEST='0'+MEST
	ENDIF
	
SET DATE LONG 
LOCAL loCfg, loMsg, lcFile, loErr
TRY
  loCfg = CREATEOBJECT("CDO.Configuration")
  WITH loCfg.Fields
  .Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "192.168.50.7"
  .Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
  .Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
  .Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "Asignaciones<asig.486.cdmx@sertec.com.mx>"
    .Update
  ENDWITH
  loMsg = CREATEOBJECT ("CDO.Message")
  WITH loMsg
    .Configuration = loCfg
    *-- Remitenete y destinatarios
    .From = "Asignaciones<asig.486.cdmx@sertec.com.mx>"
     	
    	.To = "soluciones.486@sertec.com.mx;supervisor.mc@sertec.com.mx;supervisor.mc3@sertec.com.mx;supervisorbackoffice.mc@sertec.com.mx;soluciones_banbajio@sertec.com.mx"
	    .bcc ="asignaciones3@sertec.com.mx;asig.cdmx@sertec.com.mx,asignaciones.cdmx1@sertec.com.mx"
	      
*!*	    *-- Tema o asunto
    .Subject = "Retiros actualizacion, " + DTOC(DATE())
    *-- DATOS ADJUNTOS
    SET HOURS TO 24
    SET DATE AMERICAN
    STORE "C:\RETIROS_PAG_486_"+STRTRAN(DTOC(DATE()),"/","")+STRTRAN(TIME(),":","")+".zip" to lcFile
    ?lcFile
    .AddAttachment(lcFile)
     
    *-- Formato HTML
    

.HTMLBody =[<html><body background="C:\TOCAYO\IMAGE\F1.jpg"><font face = "Book Antiqua"><font size = 3.0><p><b>Se comparte archivo retiro por actualizacion, FAVOR DE REVISAR.</b></p>]+;
			  [<p><b>Saludos.</b></p>]+;
   			  [<BR><BR><p><font face = "Book Antiqua"><font color="1C3D7B"><font size = 3.0><B>Especialista Asignaciones |]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> TI ]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 3.0> SERTEC |]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> CDMX |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Tel. ]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0>(0155)7099 0104 |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Ext.]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> 1416 |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Email:]+;
   			  [<font face = "Book Antiqua"><font color="Mediumblue"><font size = 2.0> asig.486.cdmx@sertec.com.mx</u></font></p></body></html>]+;  
   			  [<p><font size = 1.0><font color="255BBF">"Este correo, así como los archivos adjuntos que pueda contener, es confidencial y únicamente para la persona o entidad a la que fue dirigido. Si usted lo recibe por error, destrúyalo de inmediato""This Email]+;
   			  [and any files transmitted with it, are confidential and intended solely for the individual or entity to whom they are addressed. If you have received this Email in error, destroy it immediately" Consulte nuestro sitio de internet ]+;
   			  [en www.sertec.com.mx para conocer nuestro Aviso de Privacidad.</p>]

    *-- Envio el mensaje
    .Send()
  ENDWITH
CATCH TO loErr 
  MESSAGEBOX("No se pudo enviar el mensaje" + CHR(13) + ;
    "Error: " + TRANSFORM(loErr.ErrorNo) + CHR(13) + ;
    "Mensaje: " + loErr.Message , 16, "Error")
FINALLY
  loMsg = NULL
  loCfg = NULL
ENDTRY 
CLOSE ALL 

	MESSAGEBOX("SE ENVIO CORREO DE AVISO RETIROS_486.",48,1000)
***************************************************************Termina proceso de envio para retiros 
		
		IF MESSAGEBOX('DEVOLUCION "REVISA QUE TENGAS EL ARCHIVO EN C:\DEVOLUCION',1)=1 THEN &&REQ 2021-028883 APLICA 22/03/2021 SOLICITA GARFIAS ----ROX
			CD O:\prg\GPO1\486
	    	DO PROG15
	    	
	    	CLOSE TABLES
	    	
	    	
	    	
	    	
	    	IF MESSAGEBOX("NOTIFICACION PARA OPERACION",1)=1 then &&&rox
	    	CD O:\PRG\GPO1\486
	    	DO correo_486noti
		 	endif
	 	endif
		endif

	MESSAGEBOX('SOLICITA TU DAT Y DA ENTER E INGRESA A QUIEN SOLICITAS DAT',16)
	UPDATE O:\DAT\GPO1\486\bitact SET S_DA=TIME(),FIN_CON=TIME()
	CLOSE TABLES
	USE O:\DAT\GPO1\486\bitact
	USU= INPUTBOX('INGRESA A QUIEN SOLICITAS DAT')
	REPLACE USU_PRO WITH USU
	CLOSE TABLES


	IF  MESSAGEBOX("DESEAS ENVIAR CORREO?",1)= 1 THEN
		CD O:\PRG\GPO1\486
		DO correo

		UPDATE O:\DAT\GPO1\486\bitact SET f_sa=TIME(), F_DA=TIME()
		CLOSE TABLES
	ENDIF

	USE O:\DAT\GPO1\486\bitact
	CO= INPUTBOX('INGRESA TUS COMENTARIOS')
	REPLACE COMEN WITH CO
	CLOSE TABLES		


	UPDATE O:\DAT\GPO1\486\bitact SET fec=SUBSTR(DTOC(FECHA),7,4)+'-'+SUBSTR(DTOC(FECHA),1,2)+'-'+SUBSTR(DTOC(FECHA),4,2)
	CLOSE TABLES


	SELECT '1','486',FEC,I_AS,F_AS,I_SA,S_DA,F_DA,f_sa,USUARIO,COMEN,PRO,llego,sol_con,ini_con,fin_con,usu_pro FROM O:\DAT\GPO1\486\bitact INTO CURSOR EX
	COPY TO c:\BI486AC TYPE DELIMITED WITH "" WITH CHARACTER "®"
	CLOSE TABLES
	RUN bcp asignaciones..tiempos in C:\BI486AC.txt -c -t® -r\n -k -Usa -Pcyber_2012 -S192.168.50.53 -e carga_error.txt
	*ENDIF

	***oracle

	UPDATE O:\DAT\GPO1\486\bitact SET qry="INSERT INTO RCVRY.asig VALUES('1','486','"+ALLTRIM(fec)+"','"+ALLTRIM(llego)+"','"+ALLTRIM(i_as)+"','"+ALLTRIM(f_as)+"','"+ALLTRIM(i_sa)+"','"+ALLTRIM(sol_con)+"','"+ALLTRIM(ini_con)+"','"+ALLTRIM(s_da)+"','"+ALLTRIM(f_da)+"','"+ALLTRIM(fin_con)+"','"+ALLTRIM(usuario)+"','"
	UPDATE O:\DAT\GPO1\486\bitact SET qry1=+ALLTRIM(comen)+"','"+ALLTRIM(pro)+"','"+ALLTRIM(usu_pro)+"','"+ALLTRIM(fin_con)+"','"+(sELECT ALLTRIM(STR(COUNT(*))) FROM o:\dat\gpo1\486\saldos)+"','"+ALLTRIM(dat_exp)+"');"

	CLOSE TABLES
	USE O:\DAT\GPO1\486\bitact
	GO top
	SKIP
	DELETE REST
	pack
	APPEND BLANK
	REPLACE qry WITH "commit;"
	APPEND BLANK
	REPLACE qry WITH "exit"
	COPY TO c:\bitac486ac.sql FIELDS qry,qry1  SDF
	CLOSE TABLES
	**********
	USE O:\DAT\GPO1\486\reg_serv
	lOCATE FOR campo2='SACASIG'
	STORE qry TO de
	BOR=de+"C:\bitac486ac.sql"
	RUN &bor
	CLOSE TABLES
			
	USE o:\asigna\asignaciones
	UPDATE o:\asigna\asignaciones SET HR_FIN=TIME() WHERE CLIENTE='486' AND PROCESO='ACT'
	CLOSE TABLES		

			
	CLOSE ALL
ENDIF
