*************************MENSAJE DE PAGOS NO ACTUALIZADOS***************************


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
    	 .To = "erika.ramos@sertec.com.mx;administrativo.mc4@sertec.com.mx;administrativo.mc5@sertec.com.mx;supervisor.mc4@sertec.com.mx;supervisorbackoffice.mc@sertec.com.mx"
    	 .Bcc = "asignaciones.cdmx1@sertec.com.mx;asignaciones3@sertec.com.mx;asig.cdmx@sertec.com.mx"

*!*	    *-- Tema o asunto
    .Subject = "Los pagos de la Boveda no estan actualizados" + DTOC(DATE())
    *-- DATOS ADJUNTOS
    SET HOURS TO 24
    SET DATE AMERICAN
   


    *-- Formato HTML
    

.HTMLBody =[<html><body background="j:\TOCAYO\IMAGE\F1.jpg"><font face = "Book Antiqua"><font size = 4.0><p><b>Se realiza asignación BANCO BAJIO. Favor de revisar y confirmar misma vía.<BR></font></b></p>]+;
			  [<p><b>Saludos.</b>]+;
   			  [<BR><BR><p><font face = "Book Antiqua"><font color="1C3D7B"><font size = 3.0><B>Asignaciones |]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> Especialista ]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 3.0> SERTEC |]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0> Mexico D.F. |]+;
   			  [<font face = "Book Antiqua"><font color="1C3D5B"><font size = 2.0> Tel. ]+;
   			  [<font face = "Book Antiqua"><font color="255BBF"><font size = 2.0>(0155)5276 8513 |]+;
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

MESSAGEBOX("SE HAN ENVIADO CORREOS.",0,"BIEN HECHO")





