STORE TRIM(CLIENTE) TO CLI


DO CASE
   CASE CLI='131'
        COMEN='SANTANDER'
   CASE CLI='307'
        COMEN='GMC'
   CASE CLI='300'
        COMEN='INFONAVIT'
   CASE CLI='454'
        COMEN='INFONAVIT MULTI CANAL'          
   CASE CLI='391'
        COMEN='SOLUCIONES INFONAVIT'
   CASE CLI='462'
        COMEN='INFONAVIT PENSIONADOS'

   CASE CLI='395'
        COMEN='CONSUPAGO'
   CASE CLI='351'
        COMEN='NISSAN'
   CASE CLI ='370'
        COMEN='INFONAVIT JURIDICO'
   CASE CLI ='396'
        COMEN='AT&T'     
   CASE CLI ='397'
        COMEN='BANORTE'
   CASE CLI ='414'
        COMEN='FINAE'
   CASE CLI ='420'
        COMEN='BANAMEX DEFUNCION'
   CASE CLI ='424'
        COMEN='LIBERTAD'
   CASE CLI ='452'
        COMEN='CAMPAÑAS NISSAN'
   CASE CLI ='457'
        COMEN='SIPRESTO'
   CASE CLI ='458'
        COMEN='CREDISCOTIA'
   CASE CLI ='464'
        COMEN='KONFIO'
   CASE CLI ='469'
        COMEN='BANAMEX EX-EMPLEADOS'     
   CASE CLI ='346'
        COMEN='BANCOMER' 
   CASE CLI ='468'
        COMEN='CREDINISSAN'
   CASE CLI ='470'
        COMEN='BIENESTAR'
   CASE CLI ='471'
        COMEN='MEGACABLE'
   CASE CLI ='472'
        COMEN='BANCO AZTECA'
   CASE CLI ='473'
        COMEN='FICOHSA'    
   CASE CLI ='474'
        COMEN='CREDOMATIC' 
   CASE CLI ='475'
        COMEN='CONTINENTAL'           
   CASE CLI ='476'    
        COMEN='OCCIDENTAL'  
   CASE CLI ='477'    
        COMEN='GT477'  
   CASE CLI ='478'    
        COMEN='CHNGT'  
   CASE CLI ='479'    
        COMEN='CUENTAS DEBITO BANAMEX'      
   CASE CLI ='480'    
        COMEN='CFE'   
   CASE CLI ='483'    
        COMEN='YANBAL'  
   CASE CLI ='484'    
        COMEN='MONESIS LEGAL'              
        
   CASE CLI ='485'    
        COMEN='CREDITO FAMILIAR' 
       
   CASE CLI ='486'
   		COMEN='BANCO BAJIO'
         
   CASE CLI='487'        
        COMEN='BANTRAB' 
         
   CASE CLI ='488'    
        COMEN='TELCEL' 
          
   CASE CLI ='489'    
        COMEN='MONYVEO'      
        
     CASE CLI ='490'    
        COMEN='VOLKSWAGEN'      
        
     CASE CLI ='492'
        COMEN='BANAMEX PYME'

     CASE CLI ='494'
        COMEN='FINANCIERA AXI'
     
     CASE CLI ='495'
        COMEN='FINANCIERA AMIGA'
     
     CASE CLI ='412'
        COMEN='HSBC'

      CASE CLI ='425'
        COMEN='HIPOTECARIO BANAMEX'  
        
       CASE CLI ='497'
        COMEN='PENDULUM'   
        
       CASE CLI ='493'
        COMEN='LIVERPOOL'                 
         
        CASE CLI ='496'
        COMEN='TOTAL PLAY'  
        
        CASE CLI ='498'
        COMEN='INTRA BIENESTAR' 
                
        CASE CLI ='499'
        COMEN='SIEMPRE CRECIENDO'              
           
        CASE CLI ='502'
        COMEN='AUTOCOMBO'    
        
        CASE CLI ='503'
        COMEN='VW JURIDICO' 
     
        CASE CLI ='500'
        COMEN='CITI LEGAL' 

        CASE CLI ='505'
        COMEN='ARVATO' 
        
        CASE CLI ='507'
        COMEN='CITI DOMICILIACION' 
        
        CASE CLI ='510'
        COMEN='SCOTIABANK' 
        
        CASE CLI ='511'
        COMEN='FARABELLA' 
        
		CASE CLI ='506'
        COMEN='GM LEGAL'          
        
        CASE CLI ='211'
        COMEN='DEBIT BALANCE'   
        
        CASE CLI ='519'
        COMEN='NISSAN PE'   
        
        CASE CLI ='508'
        COMEN='SEGUROS BANAMEX'  
        
        CASE CLI ='520'
        COMEN='KAPITALIZER'  
        
        CASE CLI ='514'
        COMEN='AMEX LEGAL'  
        
        CASE CLI ='522'
        COMEN='KUBO'  
          CASE CLI ='523'
        COMEN='STORI'  
  
                           
ENDCASE  
STORE '&COMEN' TO CLIEN


SET DATE AMERICAN
SET HOURS TO 24
**********
**CORREO**
**********
SET DATE LONG 
LOCAL loCfg, loMsg, lcFile, loErr
TRY
  loCfg = CREATEOBJECT("CDO.Configuration")
  WITH loCfg.Fields
  .Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "192.168.50.7"
  .Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
  .Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
  .Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "Asignaciones<asignaciones3@sertec.com.mx>"

    .Update
  ENDWITH
  loMsg = CREATEOBJECT ("CDO.Message")
  WITH loMsg
    .Configuration = loCfg
    *-- Remitenete y destinatarios
    .From = "Asignaciones<asignaciones3@sertec.com.mx>"

	.To = "aem.control1@sertec.com.mx, supervisor.aem.cdmx2@sertec.com.mx,"+;
	  "supervisor.aem.cdmx3@sertec.com.mx, supervisor.aem.cdmx@sertec.com.mx, aem.control1@sertec.com.mx, aem.operativa1@sertec.com.mx,"+;
	  "aem.operativa2@sertec.com.mx, supervisor.aem.cdmx4@sertec.com.mx,aem.entregables1@sertec.com.mx,supervisor.aem.cdmx4@sertec.com.mx"	
    .Cc = "asignaciones3@sertec.com.mx,asignaciones.cdmx1@sertec.com.mx,asig.cdmx@sertec.com.mx"

    *-- Tema o asunto
    .Subject = "Devolucion del cliente "+CLIEN+" "+ DTOC(DATE())
    *-- DATOS ADJUNTOS
    SET HOURS TO 24
    SET DATE AMERICAN
.HTMLBody =[<html><body background="C:\TOCAYO\IMAGE\F1.jpg"><font face = "Papyrus,Monotype Corsiva"><font size = 4.5><p><b>ARCHIVO DE DEVOLUCION ACTUALIZADO, FAVOR DE VERIFICAR.</b></p><BR><p><b>SALUDOS.</p>]+;
   			  [<BR><BR><p><font face = "Book Antiqua"><font color="1C3D7B"><font size = 3.0><B>Asignaciones |]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> Especialista TI ]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 3.0> SERTEC |]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> Mexico D.F. |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Tel. ]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0>(0155)5276 8513 |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Ext.]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> 1416 |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Email:]+;
   			  [<font face = "Book Antiqua"><font color="Mediumblue"><font size = 2.0> asignaciones3@sertec.com.mx</u></font></p></body></html>]+;  
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
