INSERT INTO RCVRY.rpt_log_cyber VALUES(416,2,SYSDATE,'PRODUCCION','FINALIZA PROCESO ACTUALIZACION ADDRESS G1 486'); 
UPDATE RCVRY.RPT_LOG_CYBER_REG SET STATUS=0, ETAPA='FINALIZA ACTUALIZACION ADDRESS G1 486' where id_proc=416;                                                  
COMMIT;                                                                                                                                               
EXIT