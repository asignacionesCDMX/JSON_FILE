UPDATE RCVRY.RPT_LOG_CYBER_REG SET STATUS=1, ETAPA='INICIA ACTUALIZACION ADDRESS 486', ACTIVADO=SYSDATE  where id_proc=416;                                                    
INSERT INTO RCVRY.rpt_log_cyber VALUES(416,1,SYSDATE,'PRODUCCION','ACTUALIZANDO ADDRESS G1 486');                                                      
COMMIT;                                                                                                                                               
EXIT