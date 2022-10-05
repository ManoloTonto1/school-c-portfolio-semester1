﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using admin;

#nullable disable

namespace admin.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("admin.Attractie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attracties");
                });

            modelBuilder.Entity("admin.GastInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LaatsteBezochteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GastInfo");
                });

            modelBuilder.Entity("admin.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers", (string)null);
                });

            modelBuilder.Entity("admin.OnderHoud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Probleem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("attractieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("attractieId");

                    b.ToTable("OnderHouden");
                });

            modelBuilder.Entity("admin.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("attractieId")
                        .HasColumnType("int");

                    b.Property<int>("gastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("attractieId");

                    b.HasIndex("gastId");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("OnderhoudenTeCoordineren", b =>
                {
                    b.Property<int>("coordinatorenId")
                        .HasColumnType("int");

                    b.Property<int>("onderhoudenTeCoordinerenId")
                        .HasColumnType("int");

                    b.HasKey("coordinatorenId", "onderhoudenTeCoordinerenId");

                    b.HasIndex("onderhoudenTeCoordinerenId");

                    b.ToTable("OnderhoudenTeCoordineren");
                });

            modelBuilder.Entity("OnderhoudenTeDoen", b =>
                {
                    b.Property<int>("medewerkersId")
                        .HasColumnType("int");

                    b.Property<int>("onderhoudenTeDoenId")
                        .HasColumnType("int");

                    b.HasKey("medewerkersId", "onderhoudenTeDoenId");

                    b.HasIndex("onderhoudenTeDoenId");

                    b.ToTable("OnderhoudenTeDoen");
                });

            modelBuilder.Entity("admin.Gast", b =>
                {
                    b.HasBaseType("admin.Gebruiker");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<DateTime>("EersteBezoek")
                        .HasColumnType("datetime2");

                    b.Property<int>("FavAttractieID")
                        .HasColumnType("int");

                    b.Property<int?>("FavoriteAttractieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("begeleiderId")
                        .HasColumnType("int");

                    b.Property<int>("gastInfoID")
                        .HasColumnType("int");

                    b.Property<bool>("isBegeleider")
                        .HasColumnType("bit");

                    b.HasIndex("FavoriteAttractieId");

                    b.HasIndex("begeleiderId");

                    b.HasIndex("gastInfoID")
                        .IsUnique()
                        .HasFilter("[gastInfoID] IS NOT NULL");

                    b.ToTable("Gasten", (string)null);
                });

            modelBuilder.Entity("admin.Medewerker", b =>
                {
                    b.HasBaseType("admin.Gebruiker");

                    b.ToTable("Medewerkers", (string)null);
                });

            modelBuilder.Entity("admin.GastInfo", b =>
                {
                    b.OwnsOne("admin.Coordinate", "coordinate", b1 =>
                        {
                            b1.Property<int>("GastInfoId")
                                .HasColumnType("int");

                            b1.Property<int>("X")
                                .HasColumnType("int");

                            b1.Property<int>("Y")
                                .HasColumnType("int");

                            b1.HasKey("GastInfoId");

                            b1.ToTable("GastInfo");

                            b1.WithOwner()
                                .HasForeignKey("GastInfoId");
                        });

                    b.Navigation("coordinate");
                });

            modelBuilder.Entity("admin.OnderHoud", b =>
                {
                    b.HasOne("admin.Attractie", "attractieOmTeOnderhouden")
                        .WithMany("onderHouden")
                        .HasForeignKey("attractieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("admin.DateTimeBereik", "datumonderhoud", b1 =>
                        {
                            b1.Property<int>("OnderHoudId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.HasKey("OnderHoudId");

                            b1.ToTable("OnderHouden");

                            b1.WithOwner()
                                .HasForeignKey("OnderHoudId");
                        });

                    b.Navigation("attractieOmTeOnderhouden");

                    b.Navigation("datumonderhoud");
                });

            modelBuilder.Entity("admin.Reservering", b =>
                {
                    b.HasOne("admin.Attractie", "attractie")
                        .WithMany("reserveringen")
                        .HasForeignKey("attractieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("admin.Gast", "gast")
                        .WithMany("reserveringen")
                        .HasForeignKey("gastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("admin.DateTimeBereik", "datumReserveering", b1 =>
                        {
                            b1.Property<int>("ReserveringId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.HasKey("ReserveringId");

                            b1.ToTable("Reserveringen");

                            b1.WithOwner()
                                .HasForeignKey("ReserveringId");
                        });

                    b.Navigation("attractie");

                    b.Navigation("datumReserveering")
                        .IsRequired();

                    b.Navigation("gast");
                });

            modelBuilder.Entity("OnderhoudenTeCoordineren", b =>
                {
                    b.HasOne("admin.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("coordinatorenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("admin.OnderHoud", null)
                        .WithMany()
                        .HasForeignKey("onderhoudenTeCoordinerenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnderhoudenTeDoen", b =>
                {
                    b.HasOne("admin.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("medewerkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("admin.OnderHoud", null)
                        .WithMany()
                        .HasForeignKey("onderhoudenTeDoenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("admin.Gast", b =>
                {
                    b.HasOne("admin.Attractie", "FavoriteAttractie")
                        .WithMany("gastenFav")
                        .HasForeignKey("FavoriteAttractieId");

                    b.HasOne("admin.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("admin.Gast", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("admin.Gast", "begeleider")
                        .WithMany()
                        .HasForeignKey("begeleiderId");

                    b.HasOne("admin.GastInfo", "info")
                        .WithOne("gast")
                        .HasForeignKey("admin.Gast", "gastInfoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FavoriteAttractie");

                    b.Navigation("begeleider");

                    b.Navigation("info");
                });

            modelBuilder.Entity("admin.Medewerker", b =>
                {
                    b.HasOne("admin.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("admin.Medewerker", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("admin.Attractie", b =>
                {
                    b.Navigation("gastenFav");

                    b.Navigation("onderHouden");

                    b.Navigation("reserveringen");
                });

            modelBuilder.Entity("admin.GastInfo", b =>
                {
                    b.Navigation("gast")
                        .IsRequired();
                });

            modelBuilder.Entity("admin.Gast", b =>
                {
                    b.Navigation("reserveringen");
                });
#pragma warning restore 612, 618
        }
    }
}
