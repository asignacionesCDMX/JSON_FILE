SET SAFETY OFF
SET CENTURY ON
SET DATE AMERICAN
SET HOURS TO 24

STORE DTOC(date()) TO f
STORE SUBS(f,7,4) TO aa   &&& año
STORE SUBS(f,4,2) TO dd	  &&& dia
STORE SUBS(f,1,2) TO mmy  &&& mes	
DO CASE
   CASE mmy ='01'
        mes='ENE'
   CASE mmy ='02'
        mes='FEB'
   CASE mmy ='03'
        mes='MAR'
   CASE mmy ='04'
        mes='ABR'
   CASE mmy ='05'
        mes='MAY'
   CASE mmy ='06'
        mes='JUN'
   CASE mmy ='07'
        mes='JUL'
   CASE mmy ='08'
        mes='AGO'
   CASE mmy ='09'
        mes='SEP'
   CASE mmy ='10'
        mes='OCT'
   CASE mmy ='11'
        mes='NOV'
   CASE mmy ='12'
        mes='DIC'
ENDCASE

DI = DIRECTORY("C:\ORIGINALES\GPO1\486\ARCHIVOS_ORIGINALES\&aa\&mes\&dd")
IF DI = .F.
	MKDIR C:\ORIGINALES\GPO1\486\ARCHIVOS_ORIGINALES\&aa\&mes\&dd
ELSE
	MESSAGEBOX('YA EXISTE EL DIRECTORIO',0,1000)
ENDIF

RENAME "C:\LAYOUT ASIGNACION CONSUMO "+dd+mmy+aa+".xlsx" TO "C:\LAYOUT_ASIGNACION_CONSUMO_.xlsx"
RENAME "C:\LAYOUT ASIGNACION TDC "+dd+mmy+aa+".xlsx" TO "C:\LAYOUT_ASIGNACION_TDC_.xlsx"
RENAME "C:\LAYOUT HIPOTECARIO_"+dd+mmy+aa+".xlsx" TO "C:\LAYOUT_ASIGNACION_HIPOTECARIO_.xlsx"

*****Encriptado
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
		.ArchivoZip='c:\LAYOUT_ASIGNACION_CONSUMO_.zip'	&& Ruta y nombre del archivo ZIP
			.ArchivosIncluir='c:\LAYOUT_ASIGNACION_CONSUMO_.xlsx'	&& Archivos a inlcuir 
	    .Contraseña='Sertec_'+MMY+AAAA	&& Proteger el zip con una contraseña, Opcional
		*.Comentario='Mi Comentario'	&& Comentario del ZIP
		?'---------------------'
		?'Comprimiendo archivo ZIP '
		?.Comprimir()	&& Crear el zip y mostrar en pantalla la cantidad e archivos procesoados 
		?'---------------------'
	ENDWITH 
	
*!* CREAR UN ARCHIVO ZIP
	WITH oZip
		.ArchivoZip='c:\LAYOUT_ASIGNACION_TDC_.ZIP'	&& Ruta y nombre del archivo ZIP
			.ArchivosIncluir='c:\LAYOUT_ASIGNACION_TDC_.xlsx'	&& Archivos a inlcuir 
	    .Contraseña='Sertec_'+MMY+AAAA	&& Proteger el zip con una contraseña, Opcional
		*.Comentario='Mi Comentario'	&& Comentario del ZIP
		?'---------------------'
		?'Comprimiendo archivo ZIP '
		?.Comprimir()	&& Crear el zip y mostrar en pantalla la cantidad e archivos procesoados 
		?'---------------------'
	ENDWITH 

*!* CREAR UN ARCHIVO ZIP
	WITH oZip
		.ArchivoZip='c:\LAYOUT_ASIGNACION_HIPOTECARIO_.ZIP'	&& Ruta y nombre del archivo ZIP
			.ArchivosIncluir='c:\LAYOUT_ASIGNACION_HIPOTECARIO_.xlsx'	&& Archivos a inlcuir 
	    .Contraseña='Sertec_'+MMY+AAAA	&& Proteger el zip con una contraseña, Opcional
		*.Comentario='Mi Comentario'	&& Comentario del ZIP
		?'---------------------'
		?'Comprimiendo archivo ZIP '
		?.Comprimir()	&& Crear el zip y mostrar en pantalla la cantidad e archivos procesoados 
		?'---------------------'
	ENDWITH 


IF FILE('C:\LAYOUT_ASIGNACION_CONSUMO_.zip')=.t.
	!COPY C:\LAYOUT_ASIGNACION_CONSUMO_.zip C:\ORIGINALES\GPO1\486\&aa\&mes\&dd\LAYOUT_ASIGNACION_CONSUMO_.zip
ELSE 
    MESSAGEBOX('No se crea respaldo CONSUMO')
ENDIF

IF FILE('C:\LAYOUT_ASIGNACION_HIPOTECARIO_.zip')=.t.
	!COPY C:\LAYOUT_ASIGNACION_HIPOTECARIO_.zip C:\ORIGINALES\GPO1\486\&aa\&mes\&dd\LAYOUT_ASIGNACION_HIPOTECARIO_.zip
ELSE 
    MESSAGEBOX('No se crea respaldo HIPOTECARIO')
ENDIF

IF FILE('C:\LAYOUT_ASIGNACION_TDC_.zip')=.t.
	!COPY C:\LAYOUT_ASIGNACION_TDC_.zip C:\ORIGINALES\GPO1\486\&aa\&mes\&dd\LAYOUT_ASIGNACION_TDC_.zip
ELSE 
    MESSAGEBOX('No se crea respaldo TDC')
ENDIF

SET SAFETY OFF
SET CENTURY ON
SET DATE AMERICAN
ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyberdti" + ";DSN='';Trusted_Connection=no")
sqlselect = "update flags_cyber2 set horaI=getdate(),estatus='Procesando' where identifica='ABB1';"
SQLEXEC(ConHnd2,sqlselect)
CLOSE TABLES
SQLDISCONNECT(ConHnd2)

*!*	USE O:\ASIGNA\ASIGNACION
*!*	SELECT CLIENTE, PROCESO FROM O:\ASIGNA\ASIGNACION WHERE CLIENTE='486' AND PROCESO='ASIG' INTO CURSOR P
*!*	COUNT TO W
*!*	IF W=0 THEN
*!*		INSERT INTO O:\ASIGNA\ASIGNACION
*!*	ENDIF
*!*	UPDATE O:\ASIGNA\ASIGNACION SET CLIENTE='486', PROCESO='ASIG', HR_INICIO=TIME()
*!*	CLOSE TABLES
MESSAGEBOX('ASIGNACION CON BASE MAESTRA',10,1000)

DO O:\PRG\GPO1\486\bases\asig_bases

CLOSE TABLES
USE O:\DAT\GPO1\486\hipotecario
ZAP
CLOSE TABLES 
USE o:\dat\gpo1\486\tdc486_2
ZAP
CLOSE TABLES 
USE O:\DAT\GPO1\486\consumo486_2
ZAP
CLOSE TABLES 
USE o:\dat\gpo1\486\tdc486_2_cambio
ZAP
CLOSE TABLES
USE O:\DAT\GPO1\486\consumo486_2_cambio
zap

CLOSE TABLES 


*------------------------------ TDC ---------------------
	
	**USE O:\DAT\GPO1\486\TDC1 exclusive
*!*		USE O:\DAT\GPO1\486\tdc_486

IF FILE('c:\tdc.CSV')=.t.
		USE o:\dat\gpo1\486\tdc486_2_cambio
	ZAP	
*!*		APPEND FROM C:\TDC csv
	APPEND FROM O:\PRG\GPO1\486\bases\layout_tdc
    DELETE FOR CUENTA='NUM'
     DELETE FOR CUENTA='CUENTA'
    DELETE FOR EMPTY(cuenta)
    
    **REPLACE SEGMENTO WITH 'TDC' ALL
*!*	    REPLACE TIPO WITH 'TDC' ALL
    PACK
    BROWSE
    CLOSE TABLES 
    
    USE o:\dat\gpo1\486\tdc486_2_cambio
    replace segmento2 WITH 'TDC' ALL

*!*	    UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  cuentaa=RIGHT(ALLTRIM(cuenta),4)
*!*	    BROWSE
*!*	    REPLACE cuentaaaa WITH alltrim(cuentaa) +alltrim(rfc) ALL
*!*	    BROWSE
*!*	    REPLACE CUENTA WITH cuentaaaa ALL
*!*	    BROWSE
    REPLACE DES_PROD WITH CUENTA ALL
    
    
    UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  GARAN='GARANTIZADA' WHERE GARAN='1'
    UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  GARAN=' ' WHERE GARAN='0'
    

	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='VIG' WHERE VAL(TRAMO) between  1  AND 29 
	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='VEN' WHERE VAL(TRAMO) between  30  AND 59 
	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='VEN' WHERE VAL(TRAMO) between  60  AND 89 
	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='CAS' WHERE enfoque LIKE '%LIQUIDACION%' AND TRAMO='90+'
    UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='VEN' WHERE enfoque LIKE '% %' AND TRAMO='90+'
    UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='VEN' WHERE enfoque LIKE '%CONTENCION%' AND TRAMO='90+'
   	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='CAS' WHERE TRAMO='CASTIGADA'
   	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET  estatus2='REE' WHERE TRAMO='0' AND segmento in('BCOB','BOPE','FALL')

**ACFVM**
	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET etiqueta1='MORA 1' WHERE etiqueta1='COSECHA 1'  &&&REQ 2023-067064 DIANA 13/07/2023
   	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET etiqueta1='MORA 2' WHERE etiqueta1='COSECHA 2'  &&&REQ 2023-067064 DIANA 13/07/2023
   	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET etiqueta1='MORA 3' WHERE etiqueta1='COSECHA 3'  &&&REQ 2023-067064 DIANA 13/07/2023
*********
   	
   	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET saldo3=saldo2/3
   	
   	UPDATE o:\dat\gpo1\486\tdc486_2_cambio SET tipo='TDC'
   	REPLACE tipo WITH alltrim(tipo)+'_'+alltrim(estatus2) ALL
   	SELECT TIPO,COUNT(*) FROM o:\dat\gpo1\486\tdc486_2_cambio GROUP BY TIPO
	BROWSE
   
    CLOSE TABLES
  	
ENDIF

IF FILE('c:\consumo.CSV')=.t.


*------------------------------ CONSUMO -----------------------
	
	
USE O:\DAT\GPO1\486\consumo486_2_cambio EXCLUSIVE
	ZAP
	*APPEND FROM C:\CONSUMO csv
	APPEND FROM O:\PRG\GPO1\486\bases\layout_consumo

    DELETE FOR CUENTA='CREDITO'
    DELETE FOR CUENTA='CUENTA'

    DELETE FOR EMPTY(cuenta)
	pack
	REPLACE SEGMENTO2 WITH 'CONSUMO' ALL
  
 
    
    CLOSE TABLES 
*!*	    rePLACE tramo WITH tramo2 ALL
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET RIESGO=CUENTA
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET NOMBRE2=RFC
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='NOMINA' WHERE ESTRA3 LIKE '%ADELANTO DE NÓMINA%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='AUTO' WHERE ESTRA3 like '%AUTO%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='AUTO PPF' WHERE ESTRA3 like '%AUTO PAGOS FIJOS%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='AUTO REE' WHERE ESTRA3 like '%AUTO REESTRUCTURADO%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='NOMINA REE' WHERE ESTRA3='NÓMINA REESTRUCTURADA'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='NOMINA REV' WHERE ESTRA3='NÓMINA REVOLVENTE'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='NOMINA REV' WHERE ESTRA3='NÓMINA REVOLVENTE RENOVADA'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='PERSONAL' WHERE ESTRA3 like '%PERSONAL%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='PERSONAL PPF' WHERE ESTRA3='PERSONAL PAGOS FIJOS'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='PERSONAL REE' WHERE ESTRA3='PERSONAL REESTRUCTURADO'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  ESTRA3='RS TDC' WHERE ESTRA3='RS TDC'
    
    
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  TIPO='NOMINA' WHERE TIPO LIKE '%ANTICIPO NÓMINA%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  TIPO='AUTO' WHERE TIPO like '%AUTO%'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  TIPO='NOMINA' WHERE TIPO='NÓMINA'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  TIPO='NOMINA' WHERE TIPO='NOMINA'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  TIPO='PERS' WHERE TIPO='PERSONAL'
    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  TIPO='PERS' WHERE TIPO='RS TDC'
    
  
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='VIG' WHERE VAL(TRAMO) between  1  AND 29 
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='VEN' WHERE VAL(TRAMO)  between  30  AND 59 
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='VEN' WHERE VAL(TRAMO)  between  60  AND 89 
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='VEN' WHERE TRAMO='90+' AND ENFOQUE LIKE '%CONTENCIÓN%'
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='VEN' WHERE TRAMO='90+' AND ENFOQUE LIKE '%CONTENCION%'
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='VEN' WHERE TRAMO=' ' AND ENFOQUE LIKE '%CONTENCION%'
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='CAS' WHERE TRAMO='90+' AND ENFOQUE='LIQUIDACIÓN'
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='CAS' WHERE TRAMO='90+' AND ENFOQUE='LIQUIDACION'
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='REE' WHERE TRAMO='0' AND SEGMENTO='PAGO SOSTENIDO'  
*!*	    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  estatus2='CAS' WHERE TRAMO like '%CASTIGADA%'

&&&  CAMBIO APLICA A PARTIR DEL 12/04/2021 SOLICITA DIANA REQ 2022-035011 
	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  segmento='VIG' WHERE SEGMENTO='VIGENTE'
	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  segmento='VEN' WHERE SEGMENTO='VENCIDA'
	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  segmento='CAS' WHERE SEGMENTO='CASTIGADA'
	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET  segmento='REE' WHERE SEGMENTO='PAGO SOSTENIDO'

**ACFVM**
	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET etiqueta1='MORA 1' WHERE etiqueta1='COSECHA 1' 
   	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET etiqueta1='MORA 2' WHERE etiqueta1='COSECHA 2'  &&&REQ 2023-067064 DIANA 13/07/2023
   	UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET etiqueta1='MORA 3' WHERE etiqueta1='COSECHA 3'  &&&REQ 2023-067064 DIANA 13/07/2023
*********

    UPDATE O:\DAT\GPO1\486\consumo486_2_cambio SET saldo3=saldo2/3
   
   CLOSE TABLES
   
   USE O:\DAT\GPO1\486\consumo486_2_cambio
*!*	   REPLACE tipo WITH alltrim(tipo)+'_'+alltrim(estatus2) ALL 
   REPLACE tipo WITH alltrim(tipo)+'_'+alltrim(segmento) ALL 
   

 	BROWSE
	 SELECT TIPO,COUNT(*) FROM O:\DAT\GPO1\486\consumo486_2_cambio GROUP BY TIPO
 	
 	CLOSE TABLES 
 
 endif
 	*------------------------------HIPOTECARIOCONSUMO -----------------------
 
 IF FILE('c:\hipotecario.CSV')=.t.
	
 	USE O:\DAT\GPO1\486\hipotecario
	ZAP	
	APPEND FROM C:\hipotecario csv
	*APPEND FROM O:\PRG\GPO1\486\bases\layout_hipo

    DELETE FOR CUENTA='CREDITO'
    DELETE FOR EMPTY(cuenta)
    DELETE FOR CUENTA='CUENTA'

	pack
    BROWSE
       replace segmento2 WITH 'HIPOTECARIO' ALL

*!*	*!*	    REPLACE TRAMO3 WITH MORATORIO ALL
*!*	*!*	    
*!*	*!*	    UPDATE O:\DAT\GPO1\486\hipotecario SET  TRAMO3=RIGHT(ALLTRIM(TRAMO),2) 
*!*	*!*	    
*!*	*!*	    UPDATE O:\DAT\GPO1\486\hipotecario SET  TRAMO3='VEN' WHERE TRAMO3 <='60'
*!*	*!*	    UPDATE O:\DAT\GPO1\486\hipotecario SET  TRAMO3='VIG' WHERE TRAMO3 <='30'  
*!*	*!*	    UPDATE O:\DAT\GPO1\486\hipotecario SET  TRAMO3='CAS' WHERE TRAMO3 >='90'
*!*	*!*	    
*!*	*!*	    UPDATE O:\DAT\GPO1\486\hipotecario SET  TIPO='HIPO'
*!*	*!*	    REPLACE tipo WITH alltrim(tipo)+'_'+alltrim(TRAMO3) ALL
*!*	*!*	   
*!*	*!*	    UPDATE O:\DAT\GPO1\486\hipotecario SET TRAMO=fecha_retr WHERE ESTAtUS2 like '%COVID%'
*!*	*!*	    
*!*	*!*	    
*!*	*!*	*!*	    REPLACE SEGMENTO WITH 'CONSUMO' ALL
*!*	*!*	    PACK
*!*	*!*	    BROWSE
   UPDATE O:\DAT\GPO1\486\hipotecario SET  RIESGO=CUENTA &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET tipo='HIPO_CAS' WHERE SEGMENTO IN ('CAS','CASTIGA','CCAS')  &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET tipo='HIPO_VEN' WHERE SEGMENTO IN ('VENCIDA','VEN4','90+','VEN') &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET tipo='HIPO_VIG' WHERE SEGMENTO IN ('VIG','VEN3','60-89','VEN2','VIGENTE') &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET etiqueta1='MORA 1' WHERE MORA='COSECHA 1'  &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET etiqueta1='MORA 2' WHERE MORA='COSECHA 2'  &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET etiqueta1='MORA 3' WHERE MORA='COSECHA 3'  &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET etiqueta5='LIQ' WHERE ETIQUETA5 IN ('LIQUIDACION','LIQUIDACIÓN')  &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET etiqueta5='REG-LIQ' WHERE ETIQUETA5 IN ('REGULARIZACIÓN Y LIQUIDACIÓN','REGULARIZACION Y LIQUIDACION','LIQUIDACION Y REGULARIZACION','LIQUIDACIÓN Y REGULARIZACIÓN')  &&&REQ 2023-067064 DIANA 13/07/2023
   UPDATE O:\DAT\GPO1\486\hipotecario SET etiqueta5='REG' WHERE ETIQUETA5 IN ('REGULARIZACIÓN' ,'REGULARIZACION')  &&&REQ 2023-067064 DIANA 13/07/2023


*!*	   
   SELECT TIPO,COUNT(*) FROM O:\DAT\GPO1\486\hipotecario GROUP BY TIPO
   
*!*	   SELECT * FROM O:\DAT\GPO1\486\hipotecario WHERE tramo2='0' AND mora='0'
*!*	   COPY TO c:\DEVOLHIPO_486

   CLOSE TABLES 
   
endif    
 	************
    
    USE O:\LAYOUT\GPO1\486\LAYOUT1
    ZAP
    APPEND FROM o:\dat\gpo1\486\tdc486_2_cambio
    APPEND FROM O:\DAT\GPO1\486\consumo486_2_cambio
    APPEND FROM O:\DAT\GPO1\486\hipotecario   && APPEND FROM o:\dat\gpo1\486\tdc486_2
    &&APPEND FROM O:\DAT\GPO1\486\consumo486_2
   && APPEND FROM O:\DAT\GPO1\486\hipotecario
    UPDATE layout1 SET pvs='0' WHERE pvs='#N/D'  OR EMPTY(pvs)
    UPDATE layout1 SET pvs='0' WHERE pvs like '%/%'

       SELECT TIPO,COUNT(*) FROM O:\LAYOUT\GPO1\486\LAYOUT1 GROUP BY TIPO

    
	CLOSE TABLES
	
	
	
    USE O:\LAYOUT\GPO1\486\LAYOUT1
    
			SELECT CUENTA,etiqueta FROM O:\layout\GPO1\486\layout1 
			COPY TO C:\covid1
			CLOSE TABLES 
			USE O:\PRG\MEXGPO1\asi486\covid
			DELETE FROM O:\PRG\MEXGPO1\asi486\covid WHERE CUENTA IN(SELEC CUENTA FROM C:\covid1)
			COPY TO C:\mal-covid FOR DELETE()
			PACK
			CLOSE TABLES
			USE O:\PRG\MEXGPO1\asi486\covid
			APPEND FROM C:\covid1
			CLOSE TABLES 			
			
			 USE O:\LAYOUT\GPO1\486\LAYOUT1
    
			SELECT CUENTA,garan FROM O:\layout\GPO1\486\layout1 
			COPY TO C:\garaa
			CLOSE TABLES 
			USE O:\PRG\MEXGPO1\asi486\garantizada
			DELETE FROM O:\PRG\MEXGPO1\asi486\garantizada WHERE CUENTA IN(SELEC CUENTA FROM C:\garaa)
			COPY TO C:\mal-gara FOR DELETE()
			PACK
			CLOSE TABLES
			USE O:\PRG\MEXGPO1\asi486\garantizada
			APPEND FROM C:\garaa
			CLOSE TABLES 

******************************************************
*******************ACFVM*******************
USE O:\DAT\GPO1\486\DAT
	UPDATE DAT SET DAT.ETIQUETA1=MORA1.ETIQUETA1 FROM C:\MORA1 WHERE DAT.CUENTA=MORA1.CUENTA
	UPDATE DAT SET SALDO1=saldos_486.saldo1, saldo2=saldos_486.saldo2, saldo3=saldos_486.saldo3 FROM O:\PRG\GPO1\486\bases\saldos_486 WHERE DAT.CUENTA=saldos_486.CUENTA



*******************ACTUALIZA DATOS EN DAT
CD O:\DAT\GPO1\486\

FOR GG=1 TO 13
	STORE ALLTRIM(STR(GG)) TO LL
	UPDATE DAT SET DAT.TEL&LL=LAYOUT1.TEL&LL FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA
	CLOSE TABLES
ENDFOR
FOR GG=1 TO 2
	STORE ALLTRIM(STR(GG)) TO LL
	UPDATE DAT SET DAT.CORREO&LL=LAYOUT1.CORREO&LL FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA
	CLOSE TABLES
ENDFOR
FOR GG=1 TO 5
	STORE ALLTRIM(STR(GG)) TO LL
	UPDATE DAT SET DAT.DIRECC&LL=LAYOUT1.DIRECC&LL FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA
	CLOSE TABLES
ENDFOR
	
	UPDATE DAT SET DAT.ESTADO=LAYOUT1.ESTADO FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA
	UPDATE DAT SET DAT.PVS=LAYOUT1.PVS FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA
	UPDATE DAT SET DAT.TRAMO=LAYOUT1.TRAMO FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA
*!*		UPDATE DAT SET DAT.FE_REC=LAYOUT1.FE_REC FROM O:\LAYOUT\GPO1\486\layout1 WHERE DAT.cuenta=layout1.CUENTA

	MESSAGEBOX('REVISA QUE SE HAYA ACTUALIZADO LA INFORMACION DEL DAT', 40,10)

CLOSE TABLES
MESSAGEBOX('CUENTAS YA EXISTENTES,VALIDA', 60,10)
SELECT ;
    SUM(IIF(!ISNULL(b.CUENTA), 1, 0)) AS existentes, ;
    SUM(IIF(ISNULL(b.CUENTA), 1, 0)) AS nuevos ;
FROM "O:\LAYOUT\GPO1\486\layout1" a ;
LEFT JOIN "O:\DAT\GPO1\486\DAT" b ;
    ON a.CUENTA = b.CUENTA ;
INTO CURSOR cur_resultado

SELECT cur_resultado
BROWSE

USE IN layout1 
USE IN dat 
MESSAGEBOX('SE ELIMINAN CUENTAS YA EXISTENTES DE LAYOUT', 60,10)
USE O:\LAYOUT\GPO1\486\layout1
DELETE FROM O:\LAYOUT\GPO1\486\layout1 WHERE CUENTA IN (SELECT CUENTA FROM O:\DAT\GPO1\486\DAT)




PACK
MESSAGEBOX('CUENTAS NUEVAS', 60,10)
brow
USE IN layout1 
USE IN dat 
****************************************ACFVM **************



*!*		UPDATE O:\LAYOUT\GPO1\486\LAYOUT1 SET tramo=tra486.tramo from c:\tra486 WHERE LAYOUT1.des_prod=tra486.des_prod
*!*		CLOSE TABLES
*!*		USE O:\LAYOUT\GPO1\486\LAYOUT1
*!*		BROWSE
*!*		CLOSE TABLES
*!*	MESSAGEBOX('revisa en el layout el tramo')


*********************************************************************************
ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyberdti" + ";DSN='';Trusted_Connection=no")
sqlselect = "update flags_cyber_his set horaI=getdate(),horaF='', estatus='Procesando' where proceso='Asignacion Banco Bajio';"
SQLEXEC(ConHnd2,sqlselect)
CLOSE TABLES
SQLDISCONNECT(ConHnd2)

ConHnd2 = SQLSTRINGCONNECT("uid=sa;pwd=cyber_2012;server=192.168.50.53" + "" + ";driver={SQL Server};database=" + "cyberdti" + ";DSN='';Trusted_Connection=no")
sqlselect = "INSERT INTO flags_cyber_COM (PROCESO,DESCRIPCION,HORA,ESTATUS,IDENTIFICA,CLIENTE,GRUPO,CARTERA,SUCURSAL) VALUES ('Asignacion Banco Bajio','Iniciar proceso',GETDATE(),'Inica Asig','AABPY','486','1','Banco Bajio','CDMX');"
SQLEXEC(ConHnd2,sqlselect)
CLOSE TABLES
SQLDISCONNECT(ConHnd2)   
   
    
**********************************************************************************
***************************EMPIEZA LA ASIGNACION**********************************
**********************************************************************************
SET CENTURY ON
SET SAFETY OFF
SET DATE AMERICAN

IF MESSAGEBOX('DESEAS CONTINUAR CON LA ASIGNACION',1)=1 THEN

	*-----------BITACORA------------*
	USE O:\DAT\GPO1\486\bitac
		ZAP
		INSERT INTO O:\DAT\GPO1\486\bitac (fecha,PRO) VALUES (DATE(),'ASI')
		US= INPUTBOX('INGRESA TUS CLAVES')
		REPLACE USUARIO WITH US
	ll= INPUTBOX('INGRESA HORA QUE LLEGO LA ASIGNACION HH:MM:SS','FORMATO HH:MM:SS')
		REPLACE llego WITH ll

		UPDATE O:\DAT\GPO1\486\bitac SET i_as=TIME()
		CLOSE TABLES


	CD O:\PRG\GPO1\486
	DO RESPALDO2

	**** CORRIGE DIRECC3 ****
	*************************
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.DIRECC3=ALLTRIM(CHRTRAN(DIRECC3, 'abcdefghijklmnopqrstuvwxyz', '  ')) 
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.DIRECC3=ALLTRIM(CHRTRAN(DIRECC3, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', '  '))
	CLOSE TABLES

	USE O:\layout\GPO1\486\layout1
	DELE ALL
	INDEX ON CUENTA TO CU UNIQ
	RECALL ALL
	USE O:\layout\GPO1\486\layout1
	PACK
	USE

	**** ALMACENA BASES ****
	************************

	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.FE_ASIG=DATE() WHERE EMPTY(FE_ASIG)
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.FE_REC=DATE() WHERE EMPTY(FE_REC)
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.FE_REG=FE_REC+30 WHERE EMPTY(FE_REG)
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.CLIENTE='486'
	CLOSE TABLES

	******* exclusion de cuentas 486   ---yolanda osornio 02/09/2020
	DELETE FROM O:\layout\GPO1\486\layout1 WHERE cuenta in (select cuenta FROM o:\prg\gpo1\486\exc486)
	PACK
	CLOSE TABLES 
	 
	************************************************************************
	USE O:\dat\GPO1\486\dat
	RECAL ALL
	USE
	**********BUSCA EN EL DAT
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.FOLIO=DAT.FOLIO,LAYOUT1.SUB_CTE='REA' FROM O:\dat\GPO1\486\dat WHERE LAYOUT1.CUENTA=DAT.CUENTA
	UPDATE O:\dat\GPO1\486\dat SET DAT.CLIENTE='DAT' FROM O:\layout\GPO1\486\layout1 WHERE LAYOUT1.CUENTA=DAT.CUENTA
	CLOSE TABLES

	**********BUSCA EN EL PURGA
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.FOLIO=PURGA.FOLIO,LAYOUT1.SUB_CTE='REA' FROM O:\historia\GPO1\486\purga WHERE LAYOUT1.CUENTA=PURGA.CUENTA AND EMPTY(layout1.folio)
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.DIRECC1 = ' ', LAYOUT1.DIRECC2 = ' ', LAYOUT1.DIRECC3 = ' ', LAYOUT1.DIRECC4 = ' ',edo=' ' FROM O:\asigna\dirmal WHERE LAYOUT1.CUENTA2=dirmal.CUENTA AND layout1.DIRECC1=dirmal.DIRECC1

	CLOSE TABLES

	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.SUB_CTE='NVA' WHERE LAYOUT1.SUB_CTE<>'REA'
	UPDATE O:\layout\GPO1\486\layout1 SET LAYOUT1.FOLIO=SPACE(10) WHERE LAYOUT1.SUB_CTE<>'REA'
	CLOSE TABLES

	USE O:\layout\GPO1\486\layout1
	COUNT FOR LAYOUT1.SUB_CTE='NVA' TO nuevas

	IF nuevas> 100
	    DO O:\PRG\GPO1\486\aem_alerta
	ENDIF
	USE IN layout1
	**********ASIGNACION DE FOLIOS NUEVOS
	SELECT 1
		USE O:\layout\GPO1\486\layout1
	SELECT 4
		USE O:\dat\GPO1\486\tab7
	SELECT 4
		GO BOTTOM
		STORE VAL(FOLIO) TO INI1
		STORE (VAL(FOLIO)+1) TO FINI
	SELECT 1
		STORE RECCOUNT() TO TOTREC
		GO TOP
		DO WHILE .NOT. EOF()
		    IF FOLIO=SPACE(10)
		        REPLACE FOLIO WITH STR(FINI,10,0), SUB_CTE WITH 'NVA'
		        STORE (FINI+1) TO FINI
		    ENDIF
		    SKIP
		ENDDO
		STORE (FINI-1) TO FINI
	SELECT 4
		IF FINI>INI1
		    APPEND BLANK
		    REPLACE FOLIO WITH STR(FINI,10,0)
		    REPLACE CLIENTE WITH '486'
		    REPLACE FE_CAPT WITH DATE()
		    REPLACE TIME WITH TIME()    
		ENDIF
	    CLOSE TABLES
	*********PEGADOS (PROGRAMA B)

	CD O:\PRG\GPO1\486
	DO OP9



	USE O:\dat\GPO1\486\dat
	APPEND FROM O:\layout\GPO1\486\layout1
	DELETE FOR CLIENTE='DAT'
	PACK
	USE

	USE O:\historia\GPO1\486\historia
	APPEND FROM O:\layout\GPO1\486\layout1
	CLOSE TABLES

	**** LLAMA PROGRAMA PARA CUENTAS NUEVAS ****
	********************************************
	*****///// REGISTRA TODAS LAS CUENTAS NUEVAS DE CADA CLIENTE AL DIA *****/////

	Close Tables
	** REALIZA UNA COPIA DE LAS CUENTAS NUEVAS
	USE O:\layout\GPO1\486\layout1
	COPY TO c:\NVAS FOR SUB_CTE='NVA' 
	COPY TO c:\REAS FOR SUB_CTE='REA' 
	***CUENTAS PARA GESCAR***REQ 2021-062065 SOLICITADO DIANA
	COPY TO c:\GESCAR_NUEVAS FOR SUB_CTE='NVA'
	COPY TO c:\GESCAR_REAS FOR SUB_CTE='REA' 

	** HACE UN CONTEO DE LA BASE DE LAS CUENTAS NUEVAS
	USE C:\NVAS
	COUNT TO TOT_CU
	USE

	** CONDICION SI EL TOTAL DE CTAS ES DIFERENTE DE 0
	IF TOT_CU<>0

	USE C:\NVAS
	STORE LTRIM(RTRIM(CLIENTE)) TO CLI
	SUM SDO_ACT TO SDO
	ENDIF


	** REGISTRA LAS CUENTAS NUEVAS DE CADA CLIENTE AL DIA EN LA BASE DE NUEVAS
	SELECT 2
	USE O:\dat\GPO1\486\TAB7
	GO BOTTOM 
	store recno() to REC
	STORE VAL(FOLIO) TO FA
	go REC-1
	store VAL(FOLIO)+1 to FD

	** PEGA UN REGISTRO NUEVO DE LAS CUENTAS NUEVAS DE CADA CLIENTE QUE LLEGAN AL DIA.
	*** REGISTRANDO EL NUMER DE CUENTAS NUEVAS, EL CLIENTE Y EL MONTO
	SELECT 3
	USE O:\ASIGNA\NUEVAS

	      SELECT 3
	         APPEND BLANK
	         REPLACE FOLIO_D WITH STR(FD)
	         REPLACE FOLIO_A WITH STR(FA)
	         REPLACE CLIENTE WITH '486'
	         REPLACE CUENTAS WITH STR(TOT_CU)
	         REPLACE MONTO WITH SDO
	         REPLACE FE_CAPT WITH DATE()
	         REPLACE HORA_CAPT WITH TIME()
	         BROWSE 

	CLOSE TABLES

	*!*	USE O:\layout\GPO1\486\layout1
	*!*	REPLACE CUENTA2 WITH ALLTRIM("486-"+ALLTRIM(folio)) ALL
	*!*	CLOSE TABLES.

	UPDATE O:\LAYOUT\gpo1\486\LAYOUT1 SET cuenta2='486-'+ALLTRIM(folio) &&actualiza la cuenta2 con la nueva cuenta
	CLOSE TABLES 

	SELECT * from O:\dat\gpo1\486\dat WHERE cuenta NOT in (SELECT cuenta FROM o:\layout\gpo1\486\layout1)
	COPY TO c:\dev486_completa foxp
	CLOSE tables

	UPDATE O:\dat\gpo1\486\dat SET cuenta2='486-'+ALLTRIM(folio) &&actualiza la cuenta2 con la nueva cuenta
	CLOSE TABLES


	***************RETIRO

	DO O:\PRG\GPO1\486\prog15

	***************************

	****etiquetas neftalí by kevs
	*!*	IF MESSAGEBOX('¿TE MANDARON A ETIQUETAR ESTRA1,ESTRA2,ESTRA3 Y ESTRA4?',1)=1 THEN
	*!*	CD o:\dat\gpo1\486\etiqueta486
	*!*	DO eti486
	*!*	CLOSE TABLES 
	*!*	ENDIF  
	***************************************************************************************************************************


	*!*	!DEL J:\JUANJO\DIRTEL\sub_mst.TXT
	*!*	SELECT ALLTRIM(CUENTA2)+"@@1@" FROM o:\layout\gpo1\486\layout1 INTO CURSOR A1 &&+ALLTRIM(TEXT1)
	*!*	COPY TO o:\prg\gpo1\486\sub_mst.TXT SDF
	*!*	&&&&&&&&&&INICIA DESCARGA DE INFORMACION&&&&&&&&&&&&&&&&&&
	*!*	&&&&&BORRA LA BASE DE AMEX EN ORECLE&&&&&&&&&&&&&&&&&&&&&&
	*!*		USE C:\reg_serv
	*!*		LOCATE FOR campo4='192.168.90.10'
	*!*		STORE qry TO mex
	*!*		mex1=mex+"o:\prg\gpo1\486\borra.sql"
	*!*		RUN &mex1
	*!*		CLOSE TABLES
	*!*	&&&&&INSERTA A LA BASE DE AMEX EN ORACLE LAS CUENTAS DE ASIGNACION DEL DIA	
	*!*		USE C:\reg_serv
	*!*		LOCATE FOR campo4='192.168.90.10'
	*!*		STORE qry2 TO mex
	*!*		mex2=mex+"o:\prg\gpo1\486\LOAD_ORACLE.CTL"
	*!*		RUN &mex2
	*!*		CLOSE TABLES

	******************************************************************************************************************************
	MESSAGEBOX("CORRERAN LOS SALDOS","GRUPO 1",30)
	USE O:\DAT\GPO1\486\bitac
	UPDATE O:\DAT\GPO1\486\bitac SET I_SA=TIME()
	CLOSE tables

	CD O:\PRG\MEXGPO1\ASI486
	DO ASI486

	USE O:\DAT\GPO1\486\bitac
	UPDATE O:\DAT\GPO1\486\bitac SET F_SA=TIME()
	CLOSE tables
	*ENDIF
	MESSAGEBOX('RECUERDA NO SUBIR TELEFONOS')
	MESSAGEBOX("YA ESTAN LOS SALDOS, SOLICITA ARRIBO A CYBER Y DA ENTER","GRUPO 1")
	UPDATE O:\DAT\GPO1\486\bitac SET SOL_CON=TIME()
	CLOSE tables
	MESSAGEBOX("YA TE AUTORIZACION EL ARRIBO A CYBER, DA ENTER")
	UPDATE O:\DAT\GPO1\486\bitac SET INI_CON=TIME()
	CLOSE tables

	MESSAGEBOX('SI YA SUBISTE SALDOS CONTINUA',16)
	CD O:\PRG\MEXGPO1\ASI486\ACT_PHONE
	DO ACT_PHONE
	MESSAGEBOX('YA PUEDES SUBIR TELEFONOS',48)
	*!*	IF MESSAGEBOX("DESEAS ENVIAR CORREO EXPRESS?",1)=1 THEN

	*!*	CD O:\PRG\GPO1\486
	*!*	DO correo_486
	*!*	ENDIF


	IF MESSAGEBOX('DESEAS BLANQUEAR EL STATUS X ASIGNACION, SI YA SUBISTE SALDOS',1)=1 THEN&&&&&&&&&&&&&&&&&& REQ 2020-029307//Erika Carmona Ramos |Gerente SERTEC //12/03/2020
		CD O:\PRG\mexgpo1\asi486
	    DO status
	ENDIF

	CLOSE TABLES

	*****************************************ACTUALIZAR FECHA DE TELEFONOS *******************************************************

	*!*	IF MESSAGEBOX("SI YA TERMINARON DE SUBIR LOS TELEFONOS CONTINUA, PARA ACTUALIZAR LA FECHA DE LOS TELEFONOS",1)=1 THEN

	*!*	CD O:\PRG\GPO1\486\ &&&ya no se actualiza tels procesos ya toma todo lo acivo sin importar la fecha
	*!*	DO tel486
	*!*	ENDIF
	******************************************************************************************************************************
	IF MESSAGEBOX("DESEAS PROCESAR CORREOS",1)=1 THEN

		CD O:\PRG\GPO1\486\mail
		DO email
	ENDIF


	*****GESCAR CUENTAS SIN TEL GPE REQ 2021-051126 YOLANDA
	CD O:\PRG\GPO1\486
	DO ges486
	CLOSE TABLES 
	**********************

	******REQ 2021-062065 DIANA LAURA APLICA APRTIR DE 22/06/2021  ROX
	IF MESSAGEBOX("DESEAS GENERAR EL GESCAR PARA CUENTAS NUEVAS Y REASIGNADAS",1)=1 THEN
	cd O:\PRG\GPO1\486\GESCAR
	 DO ges_nuevas_rea

	ENDIF

	MESSAGEBOX("TERMINASTE DE SUBIR A CYBER DA ENTER")
	UPDATE O:\DAT\GPO1\486\bitac SET FIN_CON=TIME()
	CLOSE tables
	MESSAGEBOX('SOLICITA TU DAT,DA ENTER E INGRESA A QUIEN SOLICITAS DAT',16)
	UPDATE O:\DAT\GPO1\486\bitac SET S_DA=TIME()
	CLOSE TABLES
	USE O:\DAT\GPO1\486\bitac
	USU= INPUTBOX('INGRESA A QUIEN SOLICITAS DAT')
	REPLACE USU_PRO WITH USU
	CLOSE TABLES

	IF MESSAGEBOX("DESEAS ENVIAR CORREO DE CONFIRMACION DE ASIGNACION A OPERACIÓN",1)=1 THEN
		CD O:\PRG\GPO1\486
		DO MAIL
	ENDIF

	UPDATE O:\DAT\GPO1\486\bitac SET F_DA=TIME()
	CLOSE TABLES

	IF MESSAGEBOX("DESEAS ENVIAR CORREO EXPRESS?",1)=1 THEN
		CD O:\PRG\GPO1\486
		DO correo_486
	ENDIF

	USE O:\DAT\GPO1\486\bitac
	CO= INPUTBOX('INGRESA TUS COMENTARIOS')
	REPLACE COMEN WITH CO
	CLOSE TABLES		


	UPDATE O:\DAT\GPO1\486\bitac SET fec=SUBSTR(DTOC(FECHA),7,4)+'-'+SUBSTR(DTOC(FECHA),1,2)+'-'+SUBSTR(DTOC(FECHA),4,2), F_AS=TIME()
	CLOSE TABLES


	SELECT '1','486',FEC,I_AS,F_AS,I_SA,S_DA,F_DA,f_sa,USUARIO,COMEN,PRO,llego,sol_con,ini_con,fin_con,usu_pro FROM O:\DAT\GPO1\486\bitac INTO CURSOR EX
	COPY TO c:\BI486 TYPE DELIMITED WITH "" WITH CHARACTER "®"
	CLOSE TABLES
	RUN bcp asignaciones..tiempos in C:\BI486.txt -c -t® -r\n -k -Usa -Pcyber_2012 -S192.168.50.53 -e carga_error.txt


	***oracle

	**UPDATE O:\DAT\GPO1\486\bitac SET qry="INSERT INTO asig VALUES('1','486','"+ALLTRIM(fec)+"','"+ALLTRIM(llego)+"','"+ALLTRIM(i_as)+"','"+ALLTRIM(f_as)+"','"+ALLTRIM(i_sa)+"','"+ALLTRIM(sol_con)+"','"+ALLTRIM(ini_con)+"','"+ALLTRIM(s_da)+"','"+ALLTRIM(f_da)+"','"+ALLTRIM(fin_con)+"','"+ALLTRIM(usuario)+"','"+ALLTRIM(comen)+"','"+ALLTRIM(pro)+"','"+ALLTRIM(usu_pro)+"','"+ALLTRIM(fin_con)+"');"
	  UPDATE O:\DAT\GPO1\486\bitac SET qry="INSERT INTO RCVRY.asig VALUES('1','486','"+ALLTRIM(fec)+"','"+ALLTRIM(llego)+"','"+ALLTRIM(i_as)+"','"+ALLTRIM(f_as)+"','"+ALLTRIM(i_sa)+"','"+ALLTRIM(sol_con)+"','"+ALLTRIM(ini_con)+"','"+ALLTRIM(s_da)+"','"+ALLTRIM(f_da)+"','"+ALLTRIM(fin_con)+"','"+ALLTRIM(usuario)+"','"
	  UPDATE O:\DAT\GPO1\486\bitac SET qry1=+ALLTRIM(comen)+"','"+ALLTRIM(pro)+"','"+ALLTRIM(usu_pro)+"','"+ALLTRIM(fin_con)+"','"+(sELECT ALLTRIM(STR(COUNT(*))) FROM O:\LAYOUT\GPO1\486\LAYOUT1)+"','"+ALLTRIM(dat_exp)+"');"


	CLOSE TABLES
	USE O:\DAT\GPO1\486\bitac
	APPEND BLANK
	REPLACE qry WITH "commit;"
	APPEND BLANK
	REPLACE qry WITH "exit"
	COPY TO c:\bitac486.sql FIELDS qry,qry1  SDF
	CLOSE TABLES
	**********
	USE O:\DAT\GPO1\486\reg_serv
	lOCATE FOR campo2='SACASIG'
	STORE qry TO de
	BOR=de+"C:\bitac486.sql"
	RUN &bor
	CLOSE TABLES

	*!*	USE O:\ASIGNA\ASIGNACION
	*!*	UPDATE O:\ASIGNA\ASIGNACION SET CLIENTE='486', PROCESO='ASIG', HR_INICIO=TIME()
	*!*	CLOSE TABLES

ENDIF



*!*	IF MESSAGEBOX("DESEAS ENVIAR CORREO EXPRESS?",1)=1 THEN

*!*	CD O:\PRG\GPO1\486
*!*	DO correo_486
*!*	ENDIF
