using FluentNHibernate.Mapping;

namespace pos_service_api.Models
{
    public class DatamovementPerproduct : IEntity
    {
        public virtual int BULAN { get; set; }
        public virtual int TAHUN { get; set; }
        public virtual string? PRODUCTCODE { get; set; }
        public virtual string? PRODUCTNAME { get; set; }
        public virtual int PENSIUN { get; set; }
        public virtual int MENINGGAL { get; set; }
        public virtual int KELUAR { get; set; }

    }

    public class DatamovementPerproductMap : ClassMap<DatamovementPerproduct>
    {
        public DatamovementPerproductMap()
        {
            Table("DATAMOVEMENT_PERPRODUCT");
            Id(x => x.ID).Column("ID").GeneratedBy.SequenceIdentity();
            Map(x => x.BULAN).Column("BULAN").Not.Nullable();
            Map(x => x.TAHUN).Column("TAHUN").Not.Nullable();
            Map(x => x.PRODUCTCODE).Column("PRODUCTCODE").Nullable();
            Map(x => x.PRODUCTNAME).Column("PRODUCTNAME").Nullable();
            Map(x => x.PENSIUN).Column("PENSIUN").Not.Nullable();
            Map(x => x.MENINGGAL).Column("MENINGGAL").Not.Nullable();
            Map(x => x.KELUAR).Column("KELUAR").Not.Nullable();
        }
    }
}
