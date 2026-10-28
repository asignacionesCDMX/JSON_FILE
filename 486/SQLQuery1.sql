--select * from [BD_EXT].[dbo].[Cat_dat_layout_dinamico] order by id
--SI LLEGA UN ARCHIVO CON OTRA ESTRUCTURA SE DEBE ACTUALIZAR LA TABLA [BD_EXT].[dbo].[Cat_dat_layout_dinamico]

UPDATE [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
SET  [Campos_normalizados]=LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE( [Campos_normalizados],CHAR(160), ''), CHAR(9), ''), CHAR(10), ''), CHAR(13), '')))

DECLARE @Nombre_archivo VARCHAR(100), @i INT,@total INT,
@Fecha DATE,@sql NVARCHAR(MAX),@Archivo VARCHAR(255),@Fecha_str VARCHAR(10),@Exists int,
@Carga_A INT,@Ruta VARCHAR(255),@campos VARCHAR(4000),@campos_2 VARCHAR(4000),@FirstColumn BIT = 1,
@tipo_bulk VARCHAR(10),@contador INT

SET @contador=0
SET @i=1
SET @total=(SELECT COUNT(*) FROM(SELECT DISTINCT Archivo FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico] WHERE Activo=1)a )--obtine numero total de archivos
PRINT @total

WHILE @i<=@total
BEGIN
SET @Nombre_archivo=(
SELECT Archivo 
FROM(
	SELECT Archivo,ROW_NUMBER() OVER(ORDER BY Archivo)linea
	FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
	WHERE Activo=1
	GROUP BY Archivo) a
WHERE linea=@i------------------itera para los diferentes archivos
)
PRINT @Nombre_archivo

SET @tipo_bulk=(
	SELECT DISTINCT Tipo_archivo
	FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
	WHERE Archivo=@Nombre_archivo) 
PRINT @Nombre_archivo


SET @Fecha=DATEADD(DAY,0,GETDATE())
SET @Fecha_str=right('0'+cast(day(@fecha)as varchar(2)),2)+'-'+right('0'+cast(month(@fecha)as varchar(2)),2)+'-'+cast(year(@fecha) as varchar(4))
SET @Ruta='\\192.168.50.13\Q\cyber\C_526\'
SET @Archivo=@Ruta+@Nombre_archivo+@Fecha_str+'.'+@tipo_bulk--'.txt'
PRINT @Archivo

DELETE FROM [BD_EXT].[dbo].[bitacora]
WHERE Proceso like '%DAT_DINAMICO%' AND CAST(fecha AS DATE)=@FECHA
INSERT INTO [BD_EXT].[dbo].[bitacora] (Proceso,Fecha,Tabla)
SELECT 'DAT_DINAMICO',GETDATE(),'[BD_EXT].[dbo].[raw_rem_ext_TEST]'
--SE ELIMINA ESTA PARTE YA QUE NO IMPORTA SI YA FUE CARGADO O NO

/*SET @Carga_A=( SELECT IIF(estado='CORRECTO',1,0)--SI YA SE CARGO @Carga_A=1
FROM(select *,ROW_NUMBER()OVER (PARTITION BY Archivo ORDER BY FECHA DESC)linea 
FROM [BD_EXT].[dbo].[bitacora] WHERE Archivo LIKE 'LAYOUT_A_%' AND CAST(Fecha AS DATE)=@Fecha)a
WHERE linea=1)

PRINT @Carga_A*/

EXEC Master.dbo.xp_fileexist 
		 @archivo, 
		 @Exists OUT; 
		 print @exists

IF @Exists=1 --AND @Carga_A=1 

	BEGIN TRY

		PRINT 'EXISTE EL ARCHIVO '+CAST(@i AS VARCHAR(10))

	/*******************PRIMER CONSTRUCTOR, CREA UNA TABLA STAGING DEPENDIENDO LA ESTRUCTURA DEL ARCHIVO******************/
		--------------------------SE CARGA EL ARCHIVO EN CRUDO, TODO COMO VARCHAR

	DROP TABLE IF EXISTS [BD_EXT].[dbo].[Staging_dinamico]

	SET @campos=(
	SELECT STRING_AGG( [Campos_normalizados],' VARCHAR(255),')
	WITHIN GROUP(ORDER BY orden_archivo ) ordenados
    FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
    WHERE ARCHIVO=@Nombre_archivo AND Campos_archivo IS NOT NULL)

	SET @SQL='CREATE TABLE [BD_EXT].[dbo].[Staging_dinamico]( '+@campos+' VARCHAR(255))'
	PRINT @SQL
	EXEC(@SQL)

	IF (@tipo_bulk='txt')
	BEGIN
		SET @sql='BULK INSERT  [BD_EXT].[dbo].[Staging_dinamico] FROM '''+@Archivo+''' 
							WITH (
							FIRSTROW = 2,
							FIELDTERMINATOR = '','',
							ROWTERMINATOR = ''0x0a'',
							TABLOCK
							);'
		PRINT @sql
		EXEC(@sql)
	END
	IF (@tipo_bulk='csv')
	BEGIN
		SET @sql='BULK INSERT  [BD_EXT].[dbo].[Staging_dinamico] FROM '''+@Archivo+''' 
							WITH (
                            FORMAT = ''CSV'',
                            FIELDQUOTE = ''"'',
                            FIRSTROW = 2,
                            FIELDTERMINATOR = '','',
                            ROWTERMINATOR = ''0x0a'',
                            CODEPAGE = ''ACP'',
                            TABLOCK
						)'
		PRINT @sql
		EXEC(@sql)
	END

	/*************************SEGUNDO CONSTRUCTOR, UNIFICA TODOS LOS ARCHIVOS Y LIMPIA CAMPOS**********************/
	IF(@i=1)
	BEGIN
		DROP TABLE IF EXISTS [BD_EXT].[dbo].[raw_rem_ext_TEST]
	
		SET @campos=(
		SELECT STRING_AGG(CONCAT([Campos_normalizados],' ',tipo,''),' ,')
		WITHIN GROUP(ORDER BY orden_dat ) ordenados--------------------IMPORTANTE
		FROM (
			SELECT  DISTINCT [Campos_normalizados],Orden_dat,Tipo
			FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
			WHERE Activo=1
		)a)
		SET @SQL='CREATE TABLE [BD_EXT].[dbo].[raw_rem_ext_TEST]( '+@campos+' )'
		PRINT @SQL
		EXEC(@SQL)
	END
	SET @campos=(
	SELECT STRING_AGG([Campos_normalizados],' ,')----------
	WITHIN GROUP(ORDER BY orden_dat ) ordenados
    FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
    WHERE ARCHIVO=@Nombre_archivo)

	SET @campos_2=(
	SELECT STRING_AGG([Transformacion],' ,')----------
	WITHIN GROUP(ORDER BY orden_archivo ) ordenados
    FROM [BD_EXT].[dbo].[Cat_dat_layout_dinamico]
    WHERE ARCHIVO=@Nombre_archivo)

	SET @SQL='INSERT INTO [BD_EXT].[dbo].[raw_rem_ext_TEST]('+@campos+') SELECT '+@campos_2+' FROM [BD_EXT].[dbo].[Staging_dinamico]'
	PRINT @SQL
	EXEC(@SQL)

	UPDATE [BD_EXT].[dbo].[bitacora] 
	SET Archivo=CAST(@i AS VARCHAR(10)),
		Registros=(SELECT COUNT(*) FROM [BD_EXT].[dbo].[raw_rem_ext_TEST]),
		Estado='CORRECTO'
	WHERE Proceso like '%DAT_DINAMICO%' AND CAST(fecha AS DATE)=@FECHA

	END TRY
	BEGIN CATCH

		UPDATE [BD_EXT].[dbo].[bitacora] 
		SET Estado='ERROR'
		WHERE Proceso like '%DAT_DINAMICO%' AND CAST(fecha AS DATE)=@FECHA

		EXEC msdb.dbo.sp_update_schedule 
			 @schedule_id = 38, 
			 @enabled = 0;
		EXEC msdb.dbo.sp_stop_job 
			 N'DAT_526_V4';
	
	END CATCH
	ELSE
	BEGIN
		SET @contador=@contador+1--CUENTA ARCHIVOS QUE FALTAN
	END
SET @i=@i+1
END

PRINT 'CONTADOR '+CAST(@CONTADOR AS VARCHAR(10))
SET @i=(@i-1)-@contador--total de archivos menos archivos que faltan

IF(@i<>@total)
BEGIN 
		UPDATE [BD_EXT].[dbo].[bitacora]--SELECT * FROM [BD_EXT].[dbo].[bitacora] ORDER BY ID
		SET Archivo=CAST(@i AS VARCHAR(10)),
		Registros=(SELECT COUNT(*) FROM [BD_EXT].[dbo].[raw_rem_ext_TEST]),
		Estado='FALTAN ARCHIVOS'
		WHERE Proceso like '%DAT_DINAMICO%' AND CAST(fecha AS DATE)=@FECHA

		EXEC msdb.dbo.sp_update_schedule 
			 @schedule_id = 38, 
			 @enabled = 1;
		IF(@i=0)--NINGUN ARCHIVO SE CARGO
		BEGIN 
			 EXEC msdb.dbo.sp_stop_job 
			 N'DAT_526_V4';
		END
END