Create database EquimarFacturacion;
GO
Use EquimarFacturacion
GO

create table cancelacionesnotasdecredito(IDACUSE int not null identity(100, 1) primary key,
						Nota int foreign key references NotaCredito(IDNotaCredito),
						AcuseRecibo varchar(max));

GO

alter procedure cancelanotadecreditocfdi
@notacredito int, @acuserecibo varchar(max) as
if EXISTS(select * from cancelacionesnotasdecredito where Nota=@notacredito)
update NotaCredito set NumeroProgresivo=0 where IDNotaCredito=@notacredito
else
update NotaCredito set NumeroProgresivo=0 where IDNotaCredito=@notacredito
insert into cancelacionesnotasdecredito values(@notacredito, @acuserecibo)
GO		
select * from notasdecreditocanceladas
alter view notasdecreditocanceladas
as
select NotaCredito.IDNotaCredito as 'ID',
		NotaCredito.Folio,
		NotaCredito.Fecha,
		NotaCredito.Concepto,
		NotaCredito.Subtotal,
		NotaCredito.Iva,
		NotaCredito.Total,
		NotaCredito.ConceptoT as 'Monto en letras',
		NotaCredito.Descuento,
		NotaCredito.MotivoDescuento,
		NotaCredito.PorcentajeDescuento,
		NotaCredito.Moneda,
		NotaCredito.TipoDeCambio,
		NotaCredito.FechaTipoCambio,
		NotaCredito.UUID,
		NotaCredito.NumeroProgresivo
from NotaCredito


alter procedure notascreditocanceladas
as
select * from notasdecreditocanceladas where NumeroProgresivo=0
GO





create table CuentaPAC(IDCuentaPAC int not null identity(100, 1) primary key,
						Nombre varchar(max),
						Usuario varchar(max),
						Cuenta varchar(max),
						Contraseña varchar(max))
						GO


create procedure modificadatospac
@idcuenta int, @nombre varchar(max), @Usuario varchar(max), @cuenta varchar(max), @contraseña varchar(max) as
update CuentaPAC set Nombre=@nombre, Usuario=@Usuario, Cuenta=@cuenta, Contraseña=@contraseña where IDCuentaPAC=@idcuenta
GO

create procedure eliminadatospac
@idcuenta int as
delete from CuentaPAC where IDCuentaPAC=@idcuenta
GO

create procedure devuelvedatospac
as
select IDCuentaPAC as 'ID',
		Nombre,
		Usuario,
		Cuenta,
		Contraseña
from CuentaPAC
GO


create procedure devuelvedatospacNOMBRE
@Nombre varchar(max) as
select 	Usuario,
		Cuenta,
		Contraseña
from CuentaPAC
where Nombre=@Nombre
GO
















alter table Clientes add calle varchar(max);
alter table Clientes add NumExt varchar(max);
alter table Clientes add NumInt varchar(max);
alter table Clientes add Colonia varchar(max);
alter table Clientes add Localidad varchar(max);
alter table Clientes add ReferenciasDir varchar(max);
alter table Clientes add Estado varchar(max);
alter table Clientes add Pais varchar(max);
alter table Clientes add Email varchar(max);
alter table Clientes add CodigoPostal varchar(max);
alter table Clientes add PaisExtranjero varchar(max);
alter table Clientes add EstadoExtranjero varchar(max);

alter procedure devuelveclientenombre
@nombre varchar(max) as
select * from vistaclientes where Nombre=@nombre
GO
				
Alter view vistaclientes
as
Select Clientes.IDCliente,
		Clientes.Nombre,
		Navieras.Nombre as 'Naviera',
		Clientes.Poblacion as 'Municipio',
		Clientes.Telefono,
		Clientes.RFC,
		Clientes.Contacto,
		Clientes.Moneda,
		Clientes.Nacionalidad as 'Razon Social',
		Clientes.Naviera as 'IDNaviera',
		Clientes.calle,
		Clientes.NumExt,
		Clientes.NumInt,
		Clientes.Colonia,
		Clientes.Localidad,
		Clientes.ReferenciasDir,
		Clientes.Estado,
		Clientes.Pais,
		Clientes.Email,
		Clientes.CodigoPostal, 
		Clientes.EstadoExtranjero,
		Clientes.PaisExtranjero
from Clientes,
		Navieras
where Clientes.Naviera=Navieras.IDNaviera
GO		

alter procedure reportefacturas
@idfactura int as
Select Facturas.IDFactura as 'ID',
		Clientes.Nombre,
		Clientes.Poblacion as 'Municipio',
		Clientes.RFC,
		Clientes.Nacionalidad as 'Razon Social',
		Clientes.calle,
		Clientes.NumExt,
		Clientes.Colonia,
		Clientes.Localidad,
		Clientes.Estado,
		Clientes.Pais,
		Clientes.CodigoPostal, 
		Clientes.EstadoExtranjero,
		Clientes.PaisExtranjero,
		Facturas.Fecha,
		Facturas.Remolcadores,
		Facturas.Moneda,
		Facturas.Subtotal,
		Facturas.Iva,
		Facturas.Total,
		formaDePago,
		metodoDePago,
		descuento,
		motivodescuento,
		tipodecambio,
		fechatipodecambio,
		LugarExpedicion,
		Facturas.TotalLetras,
		Facturas.Agencia,
		Facturas.NumCuenta,
		Facturas.Fecha,
		Facturas.Remolcadores,
		Facturas.Moneda,
		Facturas.Subtotal,
		Facturas.Iva,
		Facturas.Total,
		Facturas.TotalLetras,
		viajefactura.Viaje
from Facturas,
		Clientes,
		viajefactura
where Facturas.ClienteFactura=Clientes.IDCliente and Facturas.IDFactura=@idfactura and viajefactura.Factura=Facturas.IDFactura
GO

						
alter procedure modificaclientes
@idcliente int, @Naviera int, @Nombre varchar(max),	@Direccion varchar(max),
@Poblacion varchar(max), @Telefono varchar(max), @RFC varchar(max), @Contacto varchar(max), @Moneda Varchar(max), @Nacionalidad varchar(max),
@calle varchar(max), @Numeroext varchar(max),
@Numint varchar(max),
@colonia varchar(max), @Localidad varchar(max), @ReferenciasDir varchar(max), @estado varchar(max), @pais varchar(max), @email varchar(max), @codigopostal varchar(max), @estadoextranjero varchar(max), @paisextranjero varchar(max)
as
update Clientes set Naviera=@Naviera,
						Nombre=@Nombre,
						Direccion=@Direccion,
						Poblacion=@Poblacion,
						Telefono=@Telefono,
						RFC=@RFC,
						Contacto=@Contacto,
						Moneda=@Moneda,
						Nacionalidad=@Nacionalidad,
						calle=@calle,
						NumExt=@Numeroext,
						NumInt=@Numint,
						Colonia=@colonia,
						Localidad=@Localidad,
						ReferenciasDir=@ReferenciasDir,
						Estado=@estado,
						Pais=@pais,
						Email=@email,
						CodigoPostal=@codigopostal, 
						EstadoExtranjero=@estadoextranjero,
						PaisExtranjero=@paisextranjero
where IDCliente=@idcliente
GO















create table cancelacionesfacturas(IDACUSE int not null identity(100, 1) primary key,
						Factura int foreign key references Facturas(IDFactura),
						AcuseRecibo varchar(max));

alter procedure cancelafactura
@idfactura int, @acuserecibo varchar(max) as
if EXISTS(select * from cancelacionesfacturas where Factura=@idfactura)
update Facturas set Cancelada=1 where IDFactura=@idfactura
else
update Facturas set Cancelada=1 where IDFactura=@idfactura
insert into cancelacionesfacturas values(@idfactura, @acuserecibo)
GO



alter procedure ingresa_actualizafac
@idfactura int, @factura varchar(max), @folio varchar(max) as
if EXISTS(select * from numerofactura where Factura=@idfactura)
UPDATE numerofactura set FacturaT=@folio where Factura=@idfactura
else
insert into numerofactura values(@idfactura, @factura)
update Facturas set ClaveCFDI=@factura where IDFactura=@idfactura
if EXISTS(select * from numerofactura where Factura=@idfactura)
update Facturas set ClaveCFDI=@factura where IDFactura=@idfactura
GO

alter table Facturas add ClaveCFDI varchar(max);						
alter table Facturas add formaDePago varchar(max);						
alter table Facturas add metodoDePago varchar(max);						
alter table Facturas add descuento varchar(max);						
alter table Facturas add porcentajeDescuento varchar(max);						
alter table Facturas add motivodescuento varchar(max);						
alter table Facturas add tipodecambio varchar(max);						
alter table Facturas add fechatipodecambio varchar(max);						
alter table Facturas add totalImpuestosretenidos varchar(max);						
alter table Facturas add totalimpuestostrasladados varchar(max);
alter table Facturas add LugarExpedicion varchar(max);

alter table Facturas add Agencia varchar(max);

alter table Facturas add NumCuenta varchar(max);



alter view vistaFacturas
as
Select Facturas.IDFactura as 'ID',
		Facturas.Fecha,
		numerofactura.FacturaT as 'Factura',
		Clientes.Nombre as 'Cliente',
		Barcos.Nombre as 'Barco',
		Facturas.Remolcadores,
		Facturas.Moneda,
		Facturas.Subtotal,
		Facturas.Iva,
		Facturas.Total,
		ClaveCFDI,
		formaDePago,
		metodoDePago,
		descuento,
		porcentajeDescuento,
		motivodescuento,
		tipodecambio,
		fechatipodecambio,
		totalimpuestostrasladados,
		totalImpuestosretenidos,
		LugarExpedicion,
		Facturas.TotalLetras,
		Facturas.Agencia,
		Facturas.NumCuenta
from Facturas,
		Clientes,
		Barcos,
		numerofactura
where Facturas.ClienteFactura=Clientes.IDCliente and Facturas.Barco=Barcos.IDBarco and numerofactura.Factura=Facturas.IDFactura and Facturas.Cancelada=0
GO

							
alter procedure devuelveserviciosfacturadescuento
@idfactura int as
select IDFServicios as 'ID', Servicio, 
								Barco, 
								TRB, 
								Muelles,
								Fecha,
								Horario,
								TiempoTrancurrido,
								FacturasDetalle.Importe,
								facturasdetalledescuentos.Importe as 'Descuento'
from FacturasDetalle,
facturasdetalledescuentos
where Factura=@idfactura and facturasdetalledescuentos.FacDeta=FacturasDetalle.IDFServicios
GO



alter view vistaFacturasCanceladas
as
Select Facturas.IDFactura as 'ID',
		Facturas.Fecha,
		numerofactura.FacturaT as 'Factura',
		Clientes.Nombre as 'Cliente',
		Barcos.Nombre as 'Barco',
		Facturas.Remolcadores,
		Facturas.Moneda,
		Facturas.Subtotal,
		Facturas.Iva,
		Facturas.Total,
		ClaveCFDI,
		formaDePago,
		metodoDePago,
		descuento,
		porcentajeDescuento,
		motivodescuento,
		tipodecambio,
		fechatipodecambio,
		totalimpuestostrasladados,
		totalImpuestosretenidos,
		LugarExpedicion
from Facturas,
		Clientes,
		Barcos,
		numerofactura
where Facturas.ClienteFactura=Clientes.IDCliente and Facturas.Barco=Barcos.IDBarco and numerofactura.Factura=Facturas.IDFactura and Facturas.Cancelada=1
GO

		
alter procedure insertaFacturaparcial
@fecha datetime, @cliente int, @Barco int, @remolcador int as
insert into Facturas(Fecha, ClienteFactura, Barco, Remolcador) values(@fecha,  @cliente, @Barco, @remolcador)
GO




alter procedure actualizafacturaparcial
@idfactura int, @remolcadores varchar(max), @moneda varchar(max), @subtotal decimal(18, 2), @iva decimal(18, 2), @total decimal(18, 2), @totalletras varchar(max),
@clavecfdi varchar(max), @formadepago varchar(max), @metododepago varchar(max), @descuento varchar(max), @porcentajedescuento varchar(max), @motivodescuento varchar(max), @tippodecambio varchar(max),
@fechatipodecambio varchar(max), @totalimpuestosretenidos varchar(max), @totalimpuestostrasladados varchar(max), @lugarExpedicion varchar(max), @agencia varchar(max), @NumCuenta varchar(max) as
update Facturas set Remolcadores=@remolcadores, Moneda=@moneda, Subtotal=@subtotal, Iva=@iva, Total=@total, Cancelada=0, TotalLetras=@totalletras, FacturadaL=0,
ClaveCFDI=@clavecfdi, formadepago=@formadepago, metodoDePago=@metododepago, descuento=@descuento, porcentajeDescuento=@porcentajedescuento, motivodescuento=@motivodescuento, tipodecambio=@tippodecambio, fechatipodecambio=@fechatipodecambio,
totalImpuestosretenidos=@totalimpuestosretenidos, totalimpuestostrasladados=@totalimpuestostrasladados, LugarExpedicion=@lugarExpedicion, Agencia=@agencia, NumCuenta=@NumCuenta where IDFactura=@idfactura
GO





alter table NotaCredito add Descuento decimal(18, 2);
alter table NotaCredito add MotivoDescuento varchar(max);
alter table NotaCredito add PorcentajeDescuento decimal(18, 2); 
alter table NotaCredito add Moneda varchar(max);
alter table NotaCredito add TipoDeCambio decimal(18, 2);
alter table NotaCredito add FechaTipoCambio datetime;
alter table NotaCredito add UUID varchar(max);
alter table NotaCredito add Folio varchar(max);
GO
create procedure actualizaNotaCreditocfdi
@id int, @UUID varchar(max), @folio varchar(max) as
update NotaCredito set UUID=@UUID, Folio=@folio where IDNotaCredito=@id
GO

alter procedure creanotacredito
@idfactura int as
insert into NotaCredito(Factura) values(@idfactura)
GO
exec devuelvenotasdecreditofactura 859
alter procedure devuelvenotasdecreditofactura
@idfactura int as
select NotaCredito.IDNotaCredito as 'ID',
		NotaCredito.Folio,
		NotaCredito.Fecha,
		NotaCredito.Concepto,
		NotaCredito.Subtotal,
		NotaCredito.Iva,
		NotaCredito.Total,
		NotaCredito.ConceptoT as 'Monto en letras',
		NotaCredito.Descuento,
		NotaCredito.MotivoDescuento,
		NotaCredito.PorcentajeDescuento,
		NotaCredito.Moneda,
		NotaCredito.TipoDeCambio,
		NotaCredito.FechaTipoCambio,
		NotaCredito.UUID
from NotaCredito
where NotaCredito.Factura=@idfactura and NumeroProgresivo>0 and NumeroProgresivo is not null
GO
	

create procedure devuelvenotasdecreditofacturacanceladas
@idfactura int as
select NotaCredito.IDNotaCredito as 'ID',
		NotaCredito.Folio,
		NotaCredito.Fecha,
		NotaCredito.Concepto,
		NotaCredito.Subtotal,
		NotaCredito.Iva,
		NotaCredito.Total,
		NotaCredito.ConceptoT as 'Monto en letras',
		NotaCredito.Descuento,
		NotaCredito.MotivoDescuento,
		NotaCredito.PorcentajeDescuento,
		NotaCredito.Moneda,
		NotaCredito.TipoDeCambio,
		NotaCredito.FechaTipoCambio,
		NotaCredito.UUID
from NotaCredito
where NotaCredito.Factura=@idfactura and NumeroProgresivo=0
GO
	
alter procedure actualizaNotaparcial
@factura int, @NumeroProgresivo decimal,
							@Fecha datetime,
							@Concepto varchar(max),
							@Subtotal decimal(18, 2),
							@Iva decimal(18, 2),
							@Total decimal(18, 2),
							@ConceptoT varchar(max),
							@Descuento decimal(18, 2),
							@MotivoDescuento varchar(max),
							@PorcentajeDescuento decimal(18, 2), 
							@Moneda varchar(max),
							@TipoDeCambio decimal(18, 2),
							@FechaTipoCambio datetime,
							@UUID varchar(max),
							@Folio varchar(max)			
as
Insert into NotaCredito values(@factura, @NumeroProgresivo, @Fecha, @Concepto, @Subtotal, @Iva, @Total, @ConceptoT, @Descuento,
							@MotivoDescuento,
							@PorcentajeDescuento, 
							@Moneda,
							@TipoDeCambio,
							@FechaTipoCambio,
							@UUID,
							@Folio)	
GO




































Create table Navieras(IDNaviera int not null identity(100, 1) primary key,
						Nombre varchar(max),
						Direccion varchar(max),
						Poblacion varchar(max),
						Telefono varchar(max),
						RFC varchar(max),
						Contacto varchar(max));
						GO

				
Create table Clientes(IDCliente int not null identity(100, 1) primary key,
						Naviera int foreign key references Navieras(IDNaviera),
						Nombre varchar(max),
						Direccion varchar(max),
						Poblacion varchar(max),
						Telefono varchar(max),
						RFC varchar(max),
						Contacto varchar(max),
						Moneda Varchar(max),
						Nacionalidad varchar(max));
						GO




create table Remolcadores(IDRemolcador int not null identity(100, 1) primary key,
							Nombre varchar(max),
							Caballaje varchar(max),
							Tamaño varchar(max));
							GO
						
							
create table Servicios(IDServicio int not null identity(100, 1) primary key,
						Nombre varchar(max),
						Descuento int);
						GO
						
						
create table Barcos(IDBarco int not null identity(100, 1) primary key,
					Nombre varchar(max),
					TRB int, 
					TipoCarga varchar(max));
					GO
					
						
create table RemolcadoresFacturas(IDRemolcadoresF int not null identity(100, 1) primary key,
									Remolcador1 int not null foreign key references Remolcadores(IDRemolcador),
									Remolcador2 int foreign key references Remolcadores(IDRemolcador),
									Remolcador3 int foreign key references Remolcadores(IDRemolcador));
									GO
					

Create table Facturas(IDFactura int not null identity(100, 1) primary key,
						Fecha datetime,
						ClienteFactura int not null foreign key references Clientes(IDCliente),
						Barco int not null foreign key references Barcos(IDBarco),
						Remolcador int not null foreign key references RemolcadoresFacturas(IDRemolcadoresF),
						Remolcadores varchar(max),
						Moneda varchar(max),
						Subtotal decimal(18, 2),
						Iva decimal(18, 2),
						Total decimal(18, 2),
						Cancelada int,
						TotalLetras varchar(max),
						FacturadaL int);
						GO
						
								

								
create procedure devuelveserviciosfactura
@idfactura int as
select IDFServicios as 'ID', Servicio, 
								Barco, 
								TRB, 
								Muelles,
								Fecha,
								Horario,
								TiempoTrancurrido,
								Importe
from FacturasDetalle
where Factura=@idfactura
GO

	
						
create table FacturasDetalle(IDFServicios int not null identity(100, 1) primary key,
								Factura int not null foreign key references Facturas(IDFactura),
								Servicio varchar(max),
								Barco varchar(max),
								TRB varchar(max),
								Muelles varchar(max),
								Fecha varchar(max),
								Horario varchar(max),
								TiempoTrancurrido varchar(max),
								Importe decimal(18, 2));
								GO
								
create table facturasdetalledescuentos(IDdescuentos int not null identity(100, 1) primary key,
										FacDeta int not null foreign key references FacturasDetalle(IDFServicios),
										Descuento varchar(max),
										Importe decimal(18, 2));
										GO

						
create table viajefactura(IDFServicios int not null identity(100, 1) primary key,
								Factura int not null foreign key references Facturas(IDFactura),
								Viaje varchar(max))
								GO




alter procedure notacreditoimpresion
@idfactura int as
select Clientes.Nombre,
		Clientes.Direccion,
		Clientes.Poblacion,
		Clientes.RFC,
		Facturas.IDFactura,
		numerofactura.FacturaT,
		NotaCredito.NumeroProgresivo
from Clientes,
		numerofactura,
		NotaCredito,
		Facturas
where Facturas.ClienteFactura=Clientes.IDCliente and numerofactura.Factura=@idfactura and NotaCredito.Factura=@idfactura and Facturas.IDFactura=@idfactura
GO

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
					
CREATE procedure numerodetallefac
as
select MAX(IDFServicios) from FacturasDetalle;
GO

alter procedure eliminaservicio
@idservicio int as
delete from facturasdetalledescuentos where FacDeta=@idservicio
delete from FacturasDetalle where IDFServicios=@idservicio
GO

alter procedure reporteservicios
@idfactura int as
select IDFServicios as 'ID', Servicio as 'Servicio:', 
								Barco as 'B/M:', 
								TRB as 'TRB:', 
								Muelles as 'Muelle:',
								Fecha as 'Fecha de movimiento:',
								Horario as 'Horario:',
								TiempoTrancurrido as 'Tiempo transcurrido:',
								FacturasDetalle.Importe,
								facturasdetalledescuentos.Descuento,
								facturasdetalledescuentos.Importe as 'Desc'
from FacturasDetalle,
		facturasdetalledescuentos
where facturasdetalledescuentos.FacDeta=FacturasDetalle.IDFServicios and FacturasDetalle.Factura=@idfactura
GO

							
---------------------------------------------------------------------------------------------------------------------por implementar----------------------------------------------------------------------------------------------
create table Tarifas(IDTarifas int not null identity(100, 1) primary key,
						Nombre varchar(max),
						Cuota_Basica1 decimal(18, 2),
						Cuotabasica2 decimal(18, 2),
						CuotaBasica3 decimal(18, 2),
						CuotaBasica4 decimal(18, 2),
						RemolcadorExtraP decimal(18, 2),
						RemolcadorExtraM decimal(18, 2),
						RemolcadorExtraG decimal(18, 2),
						ServicioContinuoA decimal(18, 2),
						ServicioContinuoB decimal(18, 2),
						ServicioContinuoC decimal(18, 2))
						GO
alter table Tarifas add CuotaBasica5 decimal(18, 2)
create procedure modificatarifa
@idtarifa int, @Nombre varchar(max),
						@Cuota_Basica1 decimal(18, 2),
						@Cuotabasica2 decimal(18, 2),
						@CuotaBasica3 decimal(18, 2),
						@CuotaBasica4 decimal(18, 2),
						@RemolcadorExtraP decimal(18, 2),
						@RemolcadorExtraM decimal(18, 2),
						@RemolcadorExtraG decimal(18, 2),
						@ServicioContinuoA decimal(18, 2),
						@ServicioContinuoB decimal(18, 2),
						@ServicioContinuoC decimal(18, 2),
						@CuotaBasica5 decimal(18, 2)
as
update Tarifas set Nombre=@Nombre, Cuota_Basica1=@Cuota_Basica1, Cuotabasica2=@Cuotabasica2, Cuotabasica3=@Cuotabasica3, Cuotabasica4=@Cuotabasica4, RemolcadorExtraP=@RemolcadorExtraP, RemolcadorExtraG=@RemolcadorExtraG, RemolcadorExtraM=@RemolcadorExtraM, ServicioContinuoA=@ServicioContinuoA, ServicioContinuoB=@ServicioContinuoB, ServicioContinuoC=@ServicioContinuoC, CuotaBasica5=@CuotaBasica5
where IDTarifas=@idtarifa
GO

create procedure eliminatarifas
@idtarifa int as
delete from Tarifas where IDTarifas=@idtarifa
GO

create table numerofactura(idnumerofactura int not null identity(100, 1) primary key,
								Factura int not null foreign key references Facturas(IDFactura),
								FacturaT varchar(max))
GO


create table NotaCredito(IDNotaCredito int not null identity(100, 1) primary key,
							Factura int not null foreign key references Facturas(IDFactura),
							NumeroProgresivo decimal,
							Fecha datetime,
							Concepto varchar(max),
							Subtotal decimal(18, 2),
							Iva decimal(18, 2),
							Total decimal(18, 2),
							ConceptoT varchar(max))
							GO
					
							
create procedure devuelvenotadetalleimpresion
@idfactura int as
select * from NotaCredito where Factura=@idfactura
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
						
create procedure modificanavieras
@id int, @nombre varchar(max), @direccion varchar(max), @poblacion varchar(max), @Telefono varchar(max), @RFC varchar(max), @Contacto varchar(max) as
update Navieras set Nombre=@nombre, Direccion=@direccion, Poblacion=@poblacion, Telefono=@Telefono, RFC=@RFC, Contacto=@Contacto where IDNaviera=@id
GO

create procedure eliminanavieras
@idnaviera int as
delete from Navieras where IDNaviera=@idnaviera
GO

create procedure eliminaclientes
@idcliente int as
delete from Clientes where IDCliente=@idcliente
GO
							
create procedure modificaremolcador
@idremolcador int, @nombre varchar(max), @caballaje varchar(max), @tamaño varchar(max) as
update Remolcadores set Nombre=@nombre, Caballaje=@caballaje, Tamaño=@tamaño where IDRemolcador=@idremolcador;
GO

create procedure eliminaremolcador
@idremolcador int as
delete from Remolcadores where IDRemolcador=@idremolcador
GO
						
create procedure modificaservicios
@idservicio int, @nombre varchar(max), @descuento int as
update Servicios set Nombre=@nombre, Descuento=@descuento where IDServicio=@idservicio
GO

create procedure eliminaservicios
@idservicios int as
delete from Servicios where IDServicio=@idservicios
GO
					
create procedure modificabarcos
@idbarco int, @nombre varchar(max), @trb int, @tipocarga varchar(max) as
update Barcos set Nombre=@nombre, TRB=@trb, TipoCarga=@tipocarga where IDBarco=@idbarco
GO

create procedure eliminabarcos
@idbarco int as
delete from Barcos where IDBarco=@idbarco
GO
					
				

CREATE procedure numerofacturas
as
select MAX(IDFactura) from Facturas;
GO



CREATE procedure numeroremolcadoresf
as
select MAX(IDRemolcadoresF) from RemolcadoresFacturas;
GO


				

