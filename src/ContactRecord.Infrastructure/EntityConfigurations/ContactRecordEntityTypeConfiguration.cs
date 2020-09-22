using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactRecord.Infrastructure.EntityConfigurations
{
    internal class ContactRecordEntityTypeConfiguration : IEntityTypeConfiguration<ContactRecord.Core.Entities.ContactRecord>
    {
        public void Configure(EntityTypeBuilder<ContactRecord.Core.Entities.ContactRecord> builder)
        {
            builder.ToTable("ContactRecord", ContactRecordContext.DEFAULT_SCHEMA);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .UseHiLo("contact_record_hilo", ContactRecordContext.DEFAULT_SCHEMA)
               .IsRequired();

            builder.HasAlternateKey(c => c.Email);

            builder.OwnsOne(c => c.Address, a => { a.WithOwner(); });

            builder.OwnsOne(c => c.PhoneNumber, p => { p.WithOwner(); });
        }
    }
}