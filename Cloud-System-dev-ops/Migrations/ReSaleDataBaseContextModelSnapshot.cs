// <auto-generated />
using System;
using Cloud_System_dev_ops.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cloud_System_dev_ops.Migrations
{
    [DbContext(typeof(ReSaleDataBaseContext))]
    partial class ReSaleDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cloud_System_dev_ops.Models.ReSaleModel", b =>
                {
                    b.Property<int>("ReSaleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<double>("CurrentPrice");

                    b.Property<int>("ProductId");

                    b.HasKey("ReSaleId");

                    b.ToTable("ReSale");
                });
#pragma warning restore 612, 618
        }
    }
}
