using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.MenuAggregate;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureDinnerTable(builder);
            ConfigureMenuReviewsTable(builder);

        }

        private void ConfigureDinnerTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.MenuDinnerId, db =>
            {
                db.ToTable("MenuDinnerIds");
                db.WithOwner().HasForeignKey("MenuId");
                db.HasKey("Id");
                db.Property(x => x.Value)
                .ValueGeneratedNever()
                .HasColumnName("MenuDinnerId");
               
            });
            //builder.Metadata.FindNavigation(nameof(Menu.MenuDinnerId))!
              //  .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuReviewsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.MenuReviewIds, db =>
            {
                db.ToTable("MenuReviewIds");
                db.WithOwner().HasForeignKey("MenuId");
                db.HasKey("Id");
                db.Property(x => x.Value)
                .ValueGeneratedNever()
                .HasColumnName("MenuReviewId");

            });
            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.MenuSections, sb =>
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey("Id", "MenuId");
                sb.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("MenuSectionId")
                .HasConversion(
                    to => to.Value,
                    from => MenuSectionId.Create(from));

                sb.Property(x => x.Name).HasMaxLength(100);
                sb.Property(x=>x.Description).HasMaxLength(100);
                configureMenuItems(sb);
                sb.Navigation(x => x.Items).Metadata.SetField("_Items");
                sb.Navigation(x => x.Items).UsePropertyAccessMode(PropertyAccessMode.Field);

            });
            
            builder.Metadata.FindNavigation(nameof(Menu.MenuSections))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
            
        }

        private void configureMenuItems(OwnedNavigationBuilder<Menu, MenuSection> sb)
        {
            sb.OwnsMany(x => x.Items, itemBuilder =>
            {
                itemBuilder.ToTable("MenuItems");
                itemBuilder.WithOwner().HasForeignKey("MenuSectionId","MenuId");
                itemBuilder.HasKey("Id", "MenuSectionId", "MenuId");
                itemBuilder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("MenuItemId")
                .HasConversion(
                    to => to.Value,
                    from => MenuItemId.Create(from)
                    );

                itemBuilder.Property(x => x.Name).HasMaxLength(100);
                itemBuilder.Property(x => x.Description).HasMaxLength(100);
            });
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value)
                );
            builder.Property(x => x.Name)
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .HasMaxLength(100);
            builder.OwnsOne(x => x.AverageRating);

            builder.Property(x => x.HostId)
                .HasConversion(
                    to => to.Value,
                    from => HostId.Create(from)
                );
        }
    }
}
