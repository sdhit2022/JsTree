﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tree.Context;

#nullable disable

namespace Tree.Migrations
{
    [DbContext(typeof(TreeContext))]
    [Migration("20240608053305_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tree.Models.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<bool>("IsGood")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Tree.Models.RelAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FkAttributeId")
                        .HasColumnType("int");

                    b.Property<int?>("FkAttributeParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FkAttributeId");

                    b.HasIndex("FkAttributeParentId");

                    b.ToTable("RelAttributes");
                });

            modelBuilder.Entity("Tree.Models.RelAttribute", b =>
                {
                    b.HasOne("Tree.Models.Attribute", "Attribute")
                        .WithMany("Children")
                        .HasForeignKey("FkAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tree.Models.Attribute", "AttributeParent")
                        .WithMany("Parents")
                        .HasForeignKey("FkAttributeParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Attribute");

                    b.Navigation("AttributeParent");
                });

            modelBuilder.Entity("Tree.Models.Attribute", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });
#pragma warning restore 612, 618
        }
    }
}
