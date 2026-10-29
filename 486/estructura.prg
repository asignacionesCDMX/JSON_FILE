CLOSE ALL
SET CENTURY ON
SET SAFETY OFF

CD o:\prg\gpo1\486
DO respaldo2
CLOSE tables

	
	
USE o:\dat\gpo1\486\dat
	
	****TDC****
	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE segmento2='TDC' AND  VAL(TRAMO) between  60  AND 89 
	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE ETIQUETA='COVID' AND segmento2='TDC' AND VAL(TRAMO) between  1  AND 89 
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO ='90+' AND segmento2='TDC'
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO='CASTIGADA' AND segmento2='TDC'
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO=' ' AND segmento2='TDC'
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE GARAN='garantizada' AND segmento2='TDC'
	
	***NOMINA***
	
	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE TIPO LIKE '%NOMINA%' AND  VAL(TRAMO) between  1  AND 88
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%NOMINA%' AND  VAL(TRAMO)=> 89
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%NOMINA%' AND  TRAMO ='90+'
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%NOMINA%' AND  TRAMO='CASTIGADA'

*!*	   UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE VAL(PVS) between  1  AND 159	
*!*	   UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE VAL(PVS) between  160  AND 5000
*!*	   UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE SEG='CASTIGADA' AND VAL(PVS) between  1  AND 159
    
  	***AUTO***	
  	
	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE TIPO LIKE '%AUTO%' AND  VAL(TRAMO) between  60  AND 89 
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%AUTO%' AND  VAL(TRAMO)> 89
  	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE ETIQUETA='COVID' AND TIPO LIKE '%AUTO%' AND VAL(TRAMO) between  1  AND 89
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE ETIQUETA='COVID' AND TIPO LIKE '%AUTO%' AND VAL(TRAMO)> 89
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO ='90+' AND TIPO LIKE '%AUTO%'
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO='CASTIGADA' AND TIPO LIKE '%AUTO%'
	
*!*		UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%AUTO%' AND VAL(PVS) between  210  AND 5000
*!*		UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE SEG='CASTIGADA' AND TIPO LIKE '%AUTO%'
    
    ***PERSINALES***
    
	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE TIPO LIKE '%PERS%' AND  VAL(TRAMO) between  60  AND 89
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%PERS%' AND  VAL(TRAMO)> 89
	UPDATE o:\dat\gpo1\486\dat  SET  ree='REEST' WHERE ETIQUETA='COVID' AND TIPO LIKE '%PERS%' AND VAL(TRAMO) between  1  AND 89
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE ETIQUETA='COVID' AND TIPO LIKE '%PERS%' AND VAL(TRAMO)>89
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO ='90+' AND TIPO LIKE '%PERS%'
	UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TRAMO='CASTIGADA' AND TIPO LIKE '%PERS%'

*!*		UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE TIPO LIKE '%PERS%' AND VAL(PVS) between  150  AND 5000
*!*		UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE SEG='CASTIGADA' AND TIPO LIKE '%PERS%'

*!*		UPDATE o:\dat\gpo1\486\dat  SET  ree=' ' WHERE estra3 IN ('REESTRUCTURADO','RS TDC') 
   
   BROWSE FIELDS ree
   
   
CLOSE TABLES
		
		
CLOSE ALL