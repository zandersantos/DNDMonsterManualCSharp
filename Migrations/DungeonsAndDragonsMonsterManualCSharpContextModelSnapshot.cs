﻿// <auto-generated />
using DungeonsAndDragonsMonsterManualCSharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DungeonsAndDragonsMonsterManualCSharp.Migrations
{
    [DbContext(typeof(DungeonsAndDragonsMonsterManualCSharpContext))]
    partial class DungeonsAndDragonsMonsterManualCSharpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmourClass")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HitDice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HitPoints")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Monster");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.MonsterAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("DamageDice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DamageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterAction");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.MonsterImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterImage");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.MonsterSense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int>("SenseId")
                        .HasColumnType("int");

                    b.Property<string>("SenseRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId");

                    b.HasIndex("SenseId");

                    b.ToTable("MonsterSense");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.Sense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SenseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sense");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.MonsterAction", b =>
                {
                    b.HasOne("DungeonsAndDragonsMonsterManualCSharp.Models.Action", "Action")
                        .WithMany("MonsterAction")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DungeonsAndDragonsMonsterManualCSharp.Models.Monster", "Monster")
                        .WithMany("MonsterAction")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.MonsterImage", b =>
                {
                    b.HasOne("DungeonsAndDragonsMonsterManualCSharp.Models.Monster", "Monster")
                        .WithMany("MonsterImage")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.MonsterSense", b =>
                {
                    b.HasOne("DungeonsAndDragonsMonsterManualCSharp.Models.Monster", "Monster")
                        .WithMany("MonsterSense")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DungeonsAndDragonsMonsterManualCSharp.Models.Sense", "Sense")
                        .WithMany("MonsterSense")
                        .HasForeignKey("SenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");

                    b.Navigation("Sense");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.Action", b =>
                {
                    b.Navigation("MonsterAction");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.Monster", b =>
                {
                    b.Navigation("MonsterAction");

                    b.Navigation("MonsterImage");

                    b.Navigation("MonsterSense");
                });

            modelBuilder.Entity("DungeonsAndDragonsMonsterManualCSharp.Models.Sense", b =>
                {
                    b.Navigation("MonsterSense");
                });
#pragma warning restore 612, 618
        }
    }
}
