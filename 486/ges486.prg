SET SAFETY OFF
SET CENTURY ON
SET HOURS TO 24
SET DATE AMERICAN 

MESSAGEBOX('CONTINUA SI YA CARGASTE TELEFONOS,PARA GENERAR GESCAR',32)

!DEL J:\JUANJO\DIRTEL\sub_mst.TXT
SELECT ALLTRIM(CUENTA2)+"@@1@" FROM o:\layout\gpo1\486\layout1 INTO CURSOR A1 &&+ALLTRIM(TEXT1)
*SELECT ALLTRIM(CUENTA2)+"@@1@" FROM o:\dat\gpo1\486\dat INTO CURSOR A1 &&+ALLTRIM(TEXT1)

COPY TO o:\prg\gpo1\486\sub_mst.TXT SDF

&&&&&&&&&&INICIA DESCARGA DE INFORMACION&&&&&&&&&&&&&&&&&&
&&&&&BORRA LA BASE DE AMEX EN ORECLE&&&&&&&&&&&&&&&&&&&&&&
	USE O:\DAT\GPO1\486\reg_serv
	LOCATE FOR campo2='SACASIG'
	STORE qry TO mex
	mex1=mex+"o:\prg\gpo1\486\borra.sql"
	RUN &mex1
	CLOSE TABLES
	
&&&&&INSERTA A LA BASE DE AMEX EN ORACLE LAS CUENTAS DE ASIGNACION DEL DIA	
	USE O:\DAT\GPO1\486\reg_serv
	LOCATE FOR campo2='SACASIG'
	STORE qry2 TO mex
	mex2=mex+"o:\prg\gpo1\486\LOAD_ORACLE.CTL"
	RUN &mex2
	CLOSE TABLES
&&&&&&baja telefonos 	
	USE O:\DAT\GPO1\486\reg_serv
	LOCATE FOR campo2='SACASIG'
	STORE qry TO mex
	mex2=mex+"o:\prg\gpo1\486\TELS_486.sql"
	RUN &mex2
	CLOSE TABLES	
	USE o:\prg\gpo1\486\gescar\telefonos486
	ZAP
	APPEND FROM o:\prg\gpo1\486\gescar\tel486 DELIMITED WITH CHARACTER "|"
	REPLACE TCOMPLETO WITH ALLTRIM(LADA)+ALLTRIM(TEL) ALL
	BROWSE
	CLOSE TABLES
	
SELECT * FROM o:\layout\gpo1\486\layout1 WHERE cuenta2  not in(SELECT cuenta FROM  o:\prg\gpo1\486\gescar\telefonos486  )
	
*SELECT * FROM O:\prg\MEXGPO1\ASI486\TELSAN WHERE cuenta in(SELECT cuenta2 FROM  o:\layout\gpo1\486\layout1 where fe_asig=DATE())
COPY field cuenta2 TO C:\SINTEL486 FOXP


CLOSE TABLES

USE C:\SINTEL486
COUNT TO SNT
CLOSE TABLES
	 
IF SNT = 0 THEN 
MESSAGEBOX('NO HAY CUENTAS SIN TELEFONOS')

 ELSE 
 
MESSAGEBOX('GENERA GESCAR DE RETIRO DE CUENTAS 486')

		USE o:\prg\gpo1\486\GESCAR\gestion3.dbf
		ZAP
*		APPEND FROM O:\DAT\GPO1\486\486BAJ
		APPEND from C:\SINTEL486
		replace cuenta WITH cuenta2 all
		DELETE ALL 
		INDEX on cuenta TO x uniqu
		RECALL all
		CLOSE INDEXES 
		DELETE FOR EMPTY(CUENTA)
		PACK
		
		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET ACCION='RS', RESULTADO='R1', ORIGEN='zzasg',FECHA=DATE(),FF=DATETIME()+ 120
		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET mm=TTOC(ff), hora=SUBSTR(mm,12,10) 
		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET COMENTARIO="CUENTA SIN NUMERO TELEFONICO"
		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET  NUM=RECNO()
		
		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET com1=SUBSTR(COMENTARIO,1,55),com2=SUBSTR(COMENTARIO,56,111),com3=SUBSTR(COMENTARIO,112,160)
		
		CLOSE TABLES 


		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET com1=SUBSTR(COMENTARIO,1,55),com2=SUBSTR(COMENTARIO,56,111),com3=SUBSTR(COMENTARIO,112,160)
		UPDATE o:\prg\gpo1\486\GESCAR\gestion3 SET  NUM=RECNO()
		CLOSE TABLES 

*endif			
	*****	
		USE o:\prg\gpo1\486\GESCAR\CYBGES
		ZAP
		FOR GES=1 TO 3
		STORE ALLTRIM(STR(GES)) TO LL
		INSERT INTO o:\prg\gpo1\486\GESCAR\CYBGES (CUENTA,ACCION,RESULTADO,FECHA,HORA,ORIGEN,NUM,COMENTARIO) SELECT CUENTA,ACCION,RESULTADO,FECHA,HORA,ORIGEN,NUM,COM&LL FROM  o:\prg\gpo1\486\GESCAR\gestion3 WHERE !EMPTY(COM&LL)
		ENDFOR

		CLOSE TABLES
		
		
		*****UPDATE j:\liqUIDADAS\ajuste_anualidad SET SDO_ACT_DA=DAMEXGRAL.SDO_ACT FROM j:\DAMEXGRAL WHERE ajuste_anualidad.cuenta=DAMEXGRAL.CUENTA
		
		
		SET CENTURY on
		SET DATE AMERICAN
			
		USE o:\prg\gpo1\486\GESCAR\CYBGES
		SORT ON CUENTA,NUM TO P
		ZAP
		APPEND FROM P
		USE o:\prg\gpo1\486\GESCAR\CYBGES
		 GO TOP 
		 DO WHILE .NOT. EOF()
		   
		   store substr(DTOC(fecha),1,2) to me    && mes
		   store substr(DTOC(fecha),4,2) to di	 && dia
		   store substr(DTOC(fecha),7,4) to an	 && a¤o
		   
		     replace fecha1 with me+di+an
		    
		     **************************************************************************
		     SKIP
		 ENDDO
		 USE
		 

		 USE  o:\prg\gpo1\486\GESCAR\CYBGES
		  
		   INDEX ON CUENTA TO CUv
		   
		   GO TOP
		   DO WHILE .NOT. EOF()
		   
		    STORE CUENTA TO CU
		    STORE -1 TO MAS1
		    
		      DO WHILE CUENTA=CU
		      
		       IF CUENTA = CUENTA
		          STORE (MAS1+1) TO MAS1
		          REPLACE SECU1 WITH MAS1
		       ELSE
		          STORE 1 TO MAS
		       ENDIF
		      SKIP 
		     ENDDO
		   ENDDO
		 * USE

		 USE  o:\prg\gpo1\486\GESCAR\CYBGES
		   REPLACE SECU WITH '00' +RTRIM(LTRIM(STR(SECU1))) all 
		   REPLACE IDENTIFICA WITH '200' ALL
		   REPLACE GRUPO WITH '1' ALL
		   replace hora WITH time() all
		   USE

		***************************************************************************
		******************************************************************************

		 USE  o:\prg\gpo1\486\GESCAR\CYBGES
		 RECALL ALL
		 COPY TO C:\CYBDIRTEL4 FOXP
		 CLOSE TABLES
**********************************************
		 
		  USE C:\CYBDIRTEL4 &&(tabla con el layout de gescar)
		   GO TOP
		   STORE '.TXT' TO EXT1 &&(extencion)
		   STORE "C:\SCBACTH_SINTEL"+EXT1 TO RUTA1 &&(nombre y ruta del archivo)


		   IF FILE(RUTA1) 
		      GNERRFILE = FOPEN(RUTA1,'WR')
		   ELSE
		      GNERRFILE = FCREATE(RUTA1)
		   ENDIF
		   IF GNERRFILE < 0  
		      MSGBOX( 'Imposible abrir o crear archivo de resultados')
		   ELSE 
		      DO WHILE .NOT. EOF()
		         STORE IDENTIFICA+GRUPO+CUENTA+FECHA1+BLANCO+HORA+SECU+ACCION+RESULTADO+CARTA+ORIGEN+COMENTARIO TO SALVG1
		         FPUTS(GNERRFILE, SALVG1,119,CHR(10)) &&(aqui serian la suma de los campos)
		        SKIP
		      ENDDO
		      FCLOSE(GNERRFILE)
		      GNERRFILE=0
		      
		      MESSAGEBOX('SUBE EL GESCAR FUE GENERADO CON EL NOMBRE DE: '+RUTA1)
		   ENDIF
	
		   CLOSE TABLES
		

ENDIF

*!*	MESSAGEBOX('REVISA EL FORMATO DE LA FECHA')
*!*	USE C:\reg_serv
*!*		LOCATE FOR campo4='192.168.90.10'
*!*		STORE qry TO mex
*!*		mex3=mex+"c:\ACT_fECHA486.sql"
*!*		RUN c:\ACT_fECHA486.sql
*!*		RUN &mex3
*!*	CLOSE TABLES	
	
	
