SET CENTURY on
SET SAFETY OFF
SET date AMERICAN
CLOSE TABLES

*************************************************************************************************		
*************************************gescar cuenta nuevas****************************************
*************************************************************************************************


MESSAGEBOX('GENERA GESCAR DE CUENTAS NUEVAS 486')

		USE o:\prg\gpo1\486\GESCAR\GESCAR_N.dbf
		ZAP
		APPEND from c:\GESCAR_NUEVAS
		DELETE ALL 
		INDEX on cuenta TO x uniqu
		RECALL all
		CLOSE INDEXES 
		DELETE FOR EMPTY(CUENTA)
		PACK
		CLOSE TABLES
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET GESCAR_N.cuenta2=dat.cuenta2 from o:\dat\gpo1\486\dat WHERE GESCAR_N.cuenta=dat.cuenta
		CLOSE TABLES 
		
		USE o:\prg\gpo1\486\GESCAR\GESCAR_N.dbf
		replace cuenta WITH cuenta2 ALL
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET ACCION='RS', RESULTADO='R1', ORIGEN='aaxrh',FECHA=DATE(),FF=DATETIME()+ 120
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET mm=TTOC(ff), hora=SUBSTR(mm,12,10) 
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET COMENTARIO="CUENTA NUEVA ASIGNADA."
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET  NUM=RECNO()
		
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET com1=SUBSTR(COMENTARIO,1,55),com2=SUBSTR(COMENTARIO,56,111),com3=SUBSTR(COMENTARIO,112,160)
		
		CLOSE TABLES 


		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET com1=SUBSTR(COMENTARIO,1,55),com2=SUBSTR(COMENTARIO,56,111),com3=SUBSTR(COMENTARIO,112,160)
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET  NUM=RECNO()
		CLOSE TABLES 

*endif			
	*****	
		USE o:\prg\gpo1\486\GESCAR\CYBGES
		ZAP
		FOR GES=1 TO 3
		STORE ALLTRIM(STR(GES)) TO LL
		INSERT INTO o:\prg\gpo1\486\GESCAR\CYBGES (CUENTA,ACCION,RESULTADO,FECHA,HORA,ORIGEN,NUM,COMENTARIO) SELECT CUENTA,ACCION,RESULTADO,FECHA,HORA,ORIGEN,NUM,COM&LL FROM  o:\prg\gpo1\486\GESCAR\GESCAR_N WHERE !EMPTY(COM&LL)
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
		 COPY TO C:\CYBDIRTEL44 FOXP
		 CLOSE TABLES
**********************************************
		 
		  USE C:\CYBDIRTEL44 &&(tabla con el layout de gescar)
		   GO TOP
		   STORE '.TXT' TO EXT1 &&(extencion)
		   STORE "C:\SCBACTH_486NU"+EXT1 TO RUTA1 &&(nombre y ruta del archivo)


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
		   
		   
		   
		   
*************************************************************************************************		
*************************************gescar reasignadas****************************************
*************************************************************************************************


MESSAGEBOX('GENERA GESCAR DE CUENTAS NUEVAS 486')

		USE o:\prg\gpo1\486\GESCAR\GESCAR_N.dbf
		ZAP
		APPEND from c:\GESCAR_REAS
		DELETE ALL 
		INDEX on cuenta TO x uniqu
		RECALL all
		CLOSE INDEXES 
		DELETE FOR EMPTY(CUENTA)
		PACK
		
		CLOSE TABLES
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET GESCAR_N.cuenta2=dat.cuenta2 from o:\dat\gpo1\486\dat WHERE GESCAR_N.cuenta=dat.cuenta
		CLOSE TABLES 
		
		USE o:\prg\gpo1\486\GESCAR\GESCAR_N.dbf
		replace cuenta WITH cuenta2 ALL
		
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET ACCION='RS', RESULTADO='R1', ORIGEN='aaxrh',FECHA=DATE(),FF=DATETIME()+ 120
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET mm=TTOC(ff), hora=SUBSTR(mm,12,10) 
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET COMENTARIO="CUENTA REASIGNADA."
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET  NUM=RECNO()
		
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET com1=SUBSTR(COMENTARIO,1,55),com2=SUBSTR(COMENTARIO,56,111),com3=SUBSTR(COMENTARIO,112,160)
		
		CLOSE TABLES 


		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET com1=SUBSTR(COMENTARIO,1,55),com2=SUBSTR(COMENTARIO,56,111),com3=SUBSTR(COMENTARIO,112,160)
		UPDATE o:\prg\gpo1\486\GESCAR\GESCAR_N SET  NUM=RECNO()
		CLOSE TABLES 

*endif			
	*****	
		USE o:\prg\gpo1\486\GESCAR\CYBGES
		ZAP
		FOR GES=1 TO 3
		STORE ALLTRIM(STR(GES)) TO LL
		INSERT INTO o:\prg\gpo1\486\GESCAR\CYBGES (CUENTA,ACCION,RESULTADO,FECHA,HORA,ORIGEN,NUM,COMENTARIO) SELECT CUENTA,ACCION,RESULTADO,FECHA,HORA,ORIGEN,NUM,COM&LL FROM  o:\prg\gpo1\486\GESCAR\GESCAR_N WHERE !EMPTY(COM&LL)
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
		 COPY TO C:\CYBDIRTEL45 FOXP
		 CLOSE TABLES
**********************************************
		 
		  USE C:\CYBDIRTEL45 &&(tabla con el layout de gescar)
		   GO TOP
		   STORE '.TXT' TO EXT1 &&(extencion)
		   STORE "C:\SCBACTH_486REA"+EXT1 TO RUTA1 &&(nombre y ruta del archivo)


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
		   
		   
		   
		   
