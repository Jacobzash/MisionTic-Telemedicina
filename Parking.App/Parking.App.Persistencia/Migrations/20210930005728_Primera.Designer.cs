﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking.App.Persistencia;

namespace Parking.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210930005728_Primera")]
    partial class Primera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Parking.App.Dominio.Parqueadero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Espacio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Piso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransaccionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransaccionId");

                    b.ToTable("Parqueaderos");
                });

            modelBuilder.Entity("Parking.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_nacimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Parking.App.Dominio.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Estado_Reserva")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hora_Final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParqueaderoId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParqueaderoId");

                    b.HasIndex("PersonaId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Parking.App.Dominio.Transaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Hora_Final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora_Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("Parking.App.Dominio.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Parking.App.Dominio.Administrador", b =>
                {
                    b.HasBaseType("Parking.App.Dominio.Persona");

                    b.Property<int>("IdAdministrador")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("Parking.App.Dominio.Auxiliar", b =>
                {
                    b.HasBaseType("Parking.App.Dominio.Persona");

                    b.Property<int>("IdAuxiliar")
                        .HasColumnType("int");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Auxiliar");
                });

            modelBuilder.Entity("Parking.App.Dominio.Cliente", b =>
                {
                    b.HasBaseType("Parking.App.Dominio.Persona");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_Registro")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Parking.App.Dominio.Gerente", b =>
                {
                    b.HasBaseType("Parking.App.Dominio.Persona");

                    b.Property<int>("IdGerente")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Gerente");
                });

            modelBuilder.Entity("Parking.App.Dominio.Parqueadero", b =>
                {
                    b.HasOne("Parking.App.Dominio.Transaccion", "Transaccion")
                        .WithMany()
                        .HasForeignKey("TransaccionId");

                    b.Navigation("Transaccion");
                });

            modelBuilder.Entity("Parking.App.Dominio.Reserva", b =>
                {
                    b.HasOne("Parking.App.Dominio.Parqueadero", "Parqueadero")
                        .WithMany()
                        .HasForeignKey("ParqueaderoId");

                    b.HasOne("Parking.App.Dominio.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.HasOne("Parking.App.Dominio.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId");

                    b.Navigation("Parqueadero");

                    b.Navigation("Persona");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Parking.App.Dominio.Vehiculo", b =>
                {
                    b.HasOne("Parking.App.Dominio.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
