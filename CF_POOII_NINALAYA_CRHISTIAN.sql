use Negocios
go

create or alter proc usp_select_categorias_ninalaya_crhistian
as
begin
	select 
		IdCategoria = IdCategoria,
		NomCategoria = NombreCategoria 
	from Categorias
end
go

create TABLE tb_herramienta 
(
  IdHer VARCHAR(7) PRIMARY KEY,
  DesHer VARCHAR(100),
  MedHer VARCHAR(50),
  Idcategoria INT,
  PreUni DECIMAL(10,2),
  Stock INT,
  FOREIGN KEY (idcategoria) REFERENCES categorias(IdCategoria)
)
go

INSERT INTO tb_herramienta (idHer, desHer, medHer, idcategoria, preUni, stock) VALUES
('H123456', 'Martillo', '15cm', 1, 29.99, 150),
('H234567', 'Taladro', '500W', 2, 89.99, 50),
('H345678', 'Destornillador', '10cm', 1, 9.99, 200)
GO

CREATE OR ALTER PROC usp_select_herramientas_ninalaya_crhistian
	@idcat int
AS
BEGIN
	SELECT 
		IdHerramienta = idHer,
		DesHerramienta = desHer,
		MedHerramienta = medHer,
		NomCategoria = cat.NombreCategoria,
		PreUni = preUni,
		Stock = stock
	FROM tb_herramienta as her inner join Categorias as cat on cat.IdCategoria=her.idcategoria
	where her.idcategoria= isnull(@idcat,her.idcategoria)
--exec usp_herramienta_x_categoria 1
END
GO

CREATE OR ALTER PROC usp_find_herramienta_ninalaya_crhistian
	@idher varchar(7)
AS
BEGIN
	SELECT top 1
		IdHerramienta = idHer,
		DesHerramienta = desHer,
		MedHerramienta = medHer,
		IdCategoria = idcategoria,
		PreUni = preUni,
		Stock = stock
	FROM tb_herramienta
	where idHer= @idher
END
--exec dbo.usp_find_herramienta_ninalaya_crhistian 'H234567'
GO


CREATE OR ALTER PROC usp_merge_herramienta_ninalaya_crhistian
    @idHer VARCHAR(7),
    @desHer VARCHAR(100),
    @medHer VARCHAR(50),
    @idcategoria INT,
    @preUni DECIMAL(10,2),
    @stock INT
AS
BEGIN
    MERGE INTO tb_herramienta
	using
		(select @idHer, @desHer, @medHer, @idcategoria, @preUni, @stock)
	source
		(_idHer, _desHer, _medHer, _idcategoria, _preUni, _stock)
	on 
		idher = source._idher
	when matched then
		update set			
			DesHer	= source._desHer, 
			MedHer	= source._medHer,
			Idcategoria	= source._idcategoria,
			PreUni	= source._preUni,
			Stock	= source._stock
	when not matched then
		insert values
		(_idHer, _desHer, _medHer, _idcategoria, _preUni, _stock);
END
GO

CREATE OR ALTER PROC usp_delete_herramienta_ninalaya_crhistian
	@idHer VARCHAR(7)
as
begin
	delete tb_herramienta where idHer=@idHer
end
go