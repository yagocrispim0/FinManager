// <auto-generated />
using System;
using FinManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinManager.Migrations
{
    [DbContext(typeof(FinManagerContext))]
    [Migration("20230124211955_Update_3")]
    partial class Update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FinManager.Models.Doer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doer");
                });

            modelBuilder.Entity("FinManager.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoerId");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("FinManager.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoerId");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("FinManager.Models.Expense", b =>
                {
                    b.HasOne("FinManager.Models.Doer", "Doer")
                        .WithMany("ExpenseList")
                        .HasForeignKey("DoerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doer");
                });

            modelBuilder.Entity("FinManager.Models.Income", b =>
                {
                    b.HasOne("FinManager.Models.Doer", "Doer")
                        .WithMany("IncomeList")
                        .HasForeignKey("DoerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doer");
                });

            modelBuilder.Entity("FinManager.Models.Doer", b =>
                {
                    b.Navigation("ExpenseList");

                    b.Navigation("IncomeList");
                });
#pragma warning restore 612, 618
        }
    }
}
