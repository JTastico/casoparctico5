using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Casopractico.Models;

public partial class ConsultoriaDbContext : DbContext
{
    public ConsultoriaDbContext()
    {
    }

    public ConsultoriaDbContext(DbContextOptions<ConsultoriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<Interaccione> Interacciones { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=consultoria_db;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.GastoId).HasName("PRIMARY");

            entity.ToTable("gastos");

            entity.HasIndex(e => e.TareaId, "tarea_id");

            entity.Property(e => e.GastoId)
                .HasColumnType("int(11)")
                .HasColumnName("gasto_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaGasto).HasColumnName("fecha_gasto");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.TareaId)
                .HasColumnType("int(11)")
                .HasColumnName("tarea_id");

            entity.HasOne(d => d.Tarea).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.TareaId)
                .HasConstraintName("gastos_ibfk_1");
        });

        modelBuilder.Entity<Interaccione>(entity =>
        {
            entity.HasKey(e => e.InteraccionId).HasName("PRIMARY");

            entity.ToTable("interacciones");

            entity.HasIndex(e => e.ProyectoId, "proyecto_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.InteraccionId)
                .HasColumnType("int(11)")
                .HasColumnName("interaccion_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.ProyectoId)
                .HasColumnType("int(11)")
                .HasColumnName("proyecto_id");
            entity.Property(e => e.Resumen)
                .HasColumnType("text")
                .HasColumnName("resumen");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('Llamada','Correo','Reunión')")
                .HasColumnName("tipo");
            entity.Property(e => e.UsuarioId)
                .HasComment("El empleado que participó")
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("interacciones_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("interacciones_ibfk_2");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PersonaId).HasName("PRIMARY");

            entity.ToTable("personas");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.PersonaId)
                .HasColumnType("int(11)")
                .HasColumnName("persona_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo)
                .HasComment("Diferencia el tipo de persona")
                .HasColumnType("enum('Empleado','Cliente')")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.ProyectoId).HasName("PRIMARY");

            entity.ToTable("proyectos");

            entity.HasIndex(e => e.PersonaClienteId, "persona_cliente_id");

            entity.HasIndex(e => e.ResponsableId, "responsable_id");

            entity.Property(e => e.ProyectoId)
                .HasColumnType("int(11)")
                .HasColumnName("proyecto_id");
            entity.Property(e => e.Estado)
                .HasColumnType("enum('Planificado','En Progreso','Completado','Cancelado')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFinEstimada).HasColumnName("fecha_fin_estimada");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(255)
                .HasColumnName("nombre_proyecto");
            entity.Property(e => e.Objetivos)
                .HasColumnType("text")
                .HasColumnName("objetivos");
            entity.Property(e => e.PersonaClienteId)
                .HasComment("Referencia directa a la tabla Personas")
                .HasColumnType("int(11)")
                .HasColumnName("persona_cliente_id");
            entity.Property(e => e.PresupuestoEstimado)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("presupuesto_estimado");
            entity.Property(e => e.ResponsableId)
                .HasComment("FK a la tabla Usuarios para el Project Manager")
                .HasColumnType("int(11)")
                .HasColumnName("responsable_id");

            entity.HasOne(d => d.PersonaCliente).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.PersonaClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_1");

            entity.HasOne(d => d.Responsable).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.ResponsableId)
                .HasConstraintName("proyectos_ibfk_2");

            entity.HasMany(d => d.Usuarios).WithMany(p => p.ProyectosNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "ProyectoUsuario",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("proyecto_usuarios_ibfk_2"),
                    l => l.HasOne<Proyecto>().WithMany()
                        .HasForeignKey("ProyectoId")
                        .HasConstraintName("proyecto_usuarios_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProyectoId", "UsuarioId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("proyecto_usuarios");
                        j.HasIndex(new[] { "UsuarioId" }, "usuario_id");
                        j.IndexerProperty<int>("ProyectoId")
                            .HasColumnType("int(11)")
                            .HasColumnName("proyecto_id");
                        j.IndexerProperty<int>("UsuarioId")
                            .HasColumnType("int(11)")
                            .HasColumnName("usuario_id");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.NombreRol, "nombre_rol").IsUnique();

            entity.Property(e => e.RolId)
                .HasColumnType("int(11)")
                .HasColumnName("rol_id");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .HasComment("Ej: Administrador, Gestor de Proyecto, Consultor")
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PRIMARY");

            entity.ToTable("tareas");

            entity.HasIndex(e => e.AsignadoAId, "asignado_a_id");

            entity.HasIndex(e => e.ProyectoId, "proyecto_id");

            entity.Property(e => e.TareaId)
                .HasColumnType("int(11)")
                .HasColumnName("tarea_id");
            entity.Property(e => e.AsignadoAId)
                .HasColumnType("int(11)")
                .HasColumnName("asignado_a_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasColumnType("enum('Pendiente','En Progreso','Completada')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaLimite).HasColumnName("fecha_limite");
            entity.Property(e => e.ProyectoId)
                .HasColumnType("int(11)")
                .HasColumnName("proyecto_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");

            entity.HasOne(d => d.AsignadoA).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.AsignadoAId)
                .HasConstraintName("tareas_ibfk_2");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("tareas_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.PersonaId, "persona_id").IsUnique();

            entity.HasIndex(e => e.RolId, "rol_id");

            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.ContrasenaHash)
                .HasMaxLength(255)
                .HasComment("Contraseña encriptada")
                .HasColumnName("contrasena_hash");
            entity.Property(e => e.PersonaId)
                .HasColumnType("int(11)")
                .HasColumnName("persona_id");
            entity.Property(e => e.RolId)
                .HasColumnType("int(11)")
                .HasColumnName("rol_id");

            entity.HasOne(d => d.Persona).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.PersonaId)
                .HasConstraintName("usuarios_ibfk_1");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
