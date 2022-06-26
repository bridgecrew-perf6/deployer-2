﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using data;
using data.DataModels;
using data.Models;

#nullable disable

namespace data.Migrations
{
    [DbContext(typeof(DeployerContext))]
    partial class DeployerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("data.DataModels.ApplicationDTO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("Organization")
                        .HasColumnType("uuid")
                        .HasColumnName("org");

                    b.Property<Guid?>("PipelineVersionId")
                        .HasColumnType("uuid")
                        .HasColumnName("pipeline");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("source");

                    b.Property<ApplicationVariables>("Variables")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("variables");

                    b.HasKey("ID");

                    b.HasIndex("Organization");

                    b.HasIndex("PipelineVersionId");

                    b.ToTable("application");
                });

            modelBuilder.Entity("data.DataModels.ConfigDTO", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("text")
                        .HasColumnName("key");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Key");

                    b.ToTable("config");
                });

            modelBuilder.Entity("data.DataModels.JobDTO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uuid")
                        .HasColumnName("application");

                    b.Property<Pipeline>("Code")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("code");

                    b.Property<Guid?>("PipelineVersionId")
                        .HasColumnType("uuid")
                        .HasColumnName("pipeline");

                    b.Property<string>("SourceReference")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("source_reference");

                    b.Property<JobState>("State")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("job_state");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("PipelineVersionId");

                    b.ToTable("job");
                });

            modelBuilder.Entity("data.DataModels.OrganizationDTO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("organization");
                });

            modelBuilder.Entity("data.DataModels.PipelineDTO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("Organization")
                        .HasColumnType("uuid")
                        .HasColumnName("org");

                    b.HasKey("ID");

                    b.HasIndex("Organization");

                    b.ToTable("pipeline");
                });

            modelBuilder.Entity("data.DataModels.PipelineVersionDTO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Pipeline>("Code")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("code");

                    b.Property<PipelineVersionFiles>("Files")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("files");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("PipelineId")
                        .HasColumnType("uuid")
                        .HasColumnName("pipeline");

                    b.Property<string>("YAML")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("yaml");

                    b.HasKey("ID");

                    b.HasIndex("PipelineId");

                    b.ToTable("pipeline_version");
                });

            modelBuilder.Entity("data.DataModels.ApplicationDTO", b =>
                {
                    b.HasOne("data.DataModels.OrganizationDTO", null)
                        .WithMany()
                        .HasForeignKey("Organization")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("data.DataModels.PipelineVersionDTO", null)
                        .WithMany()
                        .HasForeignKey("PipelineVersionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("data.DataModels.JobDTO", b =>
                {
                    b.HasOne("data.DataModels.ApplicationDTO", null)
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data.DataModels.PipelineVersionDTO", null)
                        .WithMany()
                        .HasForeignKey("PipelineVersionId");
                });

            modelBuilder.Entity("data.DataModels.PipelineDTO", b =>
                {
                    b.HasOne("data.DataModels.OrganizationDTO", null)
                        .WithMany()
                        .HasForeignKey("Organization")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("data.DataModels.PipelineVersionDTO", b =>
                {
                    b.HasOne("data.DataModels.PipelineDTO", null)
                        .WithMany()
                        .HasForeignKey("PipelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
