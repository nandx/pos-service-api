using Microsoft.EntityFrameworkCore;

namespace pos_service_api.Models;

public partial class PosDbContext : DbContext
{ 

    public PosDbContext()
    {
    }

    public PosDbContext(DbContextOptions<PosDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<TblDetailCutoffThnBln> TblDetailCutoffThnBlns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
    //    }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDetailCutoffThnBln>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TBL_DETAIL_CUTOFF_THN_BLN_PK");

            entity.ToTable("TBL_DETAIL_CUTOFF_THN_BLN");

            entity.HasIndex(e => new { e.Thn, e.Bln, e.SegmenProduk, e.KodeProduk, e.IdMember }, "TBL_DETAIL_CUTOFF_THN_BLN_IDX_INCLUDE_SALDO");

            entity.HasIndex(e => new { e.Thn, e.Bln, e.NomorSpa }, "TBL_DETAIL_CUTOFF_THN_BLN_INDEXING_VIEW");

            entity.HasIndex(e => new { e.SegmenProduk, e.KodeProduk, e.NamaProduk, e.Bln, e.Thn }, "TBL_DETAIL_CUTOFF_THN_BLN_SEGMEN_PRODUK_IDX");

            entity.HasIndex(e => e.Stapeg, "TBL_DETAIL_CUTOFF_THN_BLN_STAPEG_IDX");

            entity.HasIndex(e => new { e.Thn, e.Bln, e.KodeProduk, e.NamaProduk }, "TBL_DETAIL_CUTOFF_THN_BLN_THN_IDX");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AkhirAsuransi)
                .HasColumnType("datetime")
                .HasColumnName("AKHIR_ASURANSI");
            entity.Property(e => e.AkumulasiPremi).HasColumnName("AKUMULASI_PREMI");
            entity.Property(e => e.AkumulasiPremiForecast).HasColumnName("AKUMULASI_PREMI_FORECAST");
            entity.Property(e => e.BalanceAdjustment).HasColumnName("BALANCE_ADJUSTMENT");
            entity.Property(e => e.BalanceAdjustmentForecast).HasColumnName("BALANCE_ADJUSTMENT_FORECAST");
            entity.Property(e => e.Bln).HasColumnName("BLN");
            entity.Property(e => e.BlnSaldo).HasColumnName("BLN_SALDO");
            entity.Property(e => e.Bpa1).HasColumnName("BPA1");
            entity.Property(e => e.Bpa1Forecast).HasColumnName("BPA1_FORECAST");
            entity.Property(e => e.Bpa2).HasColumnName("BPA2");
            entity.Property(e => e.Bpa2Forecast).HasColumnName("BPA2_FORECAST");
            entity.Property(e => e.Bpd1).HasColumnName("BPD1");
            entity.Property(e => e.Bpd1Forecast).HasColumnName("BPD1_FORECAST");
            entity.Property(e => e.Bpd2).HasColumnName("BPD2");
            entity.Property(e => e.Bpd2Forecast).HasColumnName("BPD2_FORECAST");
            entity.Property(e => e.CaraBayarPremi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CARA_BAYAR_PREMI");
            entity.Property(e => e.Coi).HasColumnName("COI");
            entity.Property(e => e.CoiForecast).HasColumnName("COI_FORECAST");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATE_AT");
            entity.Property(e => e.Deposit).HasColumnName("DEPOSIT");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Entryby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ENTRYBY");
            entity.Property(e => e.ExtraPremi).HasColumnName("EXTRA_PREMI");
            entity.Property(e => e.Gapok).HasColumnName("GAPOK");
            entity.Property(e => e.Gapok2003).HasColumnName("GAPOK2003");
            entity.Property(e => e.Gapok97).HasColumnName("GAPOK97");
            entity.Property(e => e.GapokAwal).HasColumnName("GAPOK_AWAL");
            entity.Property(e => e.IdDistributionChannelPemasaran).HasColumnName("ID_DISTRIBUTION_CHANNEL_PEMASARAN");
            entity.Property(e => e.IdMember).HasColumnName("ID_MEMBER");
            entity.Property(e => e.Inv).HasColumnName("INV");
            entity.Property(e => e.InvForecast).HasColumnName("INV_FORECAST");
            entity.Property(e => e.Jabatan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JABATAN");
            entity.Property(e => e.JenisKelamin)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("JENIS_KELAMIN");
            entity.Property(e => e.JenisKredit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JENIS_KREDIT");
            entity.Property(e => e.JumlahAnak).HasColumnName("JUMLAH_ANAK");
            entity.Property(e => e.JumlahIstri).HasColumnName("JUMLAH_ISTRI");
            entity.Property(e => e.KdPangkat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KD_PANGKAT");
            entity.Property(e => e.KodeAgen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KODE_AGEN");
            entity.Property(e => e.KodeCabang)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KODE_CABANG");
            entity.Property(e => e.KodeJiwa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KODE_JIWA");
            entity.Property(e => e.KodeProduk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KODE_PRODUK");
            entity.Property(e => e.Komisi).HasColumnName("KOMISI");
            entity.Property(e => e.KomisiForecast).HasColumnName("KOMISI_FORECAST");
            entity.Property(e => e.MasaAsuransiBln).HasColumnName("MASA_ASURANSI_BLN");
            entity.Property(e => e.MasaAsuransiThn).HasColumnName("MASA_ASURANSI_THN");
            entity.Property(e => e.MasaBayarPremi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MASA_BAYAR_PREMI");
            entity.Property(e => e.MulaiAsuransi)
                .HasColumnType("datetime")
                .HasColumnName("MULAI_ASURANSI");
            entity.Property(e => e.NamaAgen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAMA_AGEN");
            entity.Property(e => e.NamaAnak1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_ANAK1");
            entity.Property(e => e.NamaAnak2)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_ANAK2");
            entity.Property(e => e.NamaBank)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_BANK");
            entity.Property(e => e.NamaCabang)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAMA_CABANG");
            entity.Property(e => e.NamaDistributionChannelPemasaran)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAMA_DISTRIBUTION_CHANNEL_PEMASARAN");
            entity.Property(e => e.NamaInstansiBusb)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_INSTANSI_BUSB");
            entity.Property(e => e.NamaPemegangPolis)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_PEMEGANG_POLIS");
            entity.Property(e => e.NamaPemilikRekening)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_PEMILIK_REKENING");
            entity.Property(e => e.NamaProduk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAMA_PRODUK");
            entity.Property(e => e.NamaTertanggung)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAMA_TERTANGGUNG");
            entity.Property(e => e.Nik)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NIK");
            entity.Property(e => e.Nip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NIP");
            entity.Property(e => e.NmStapeg)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NM_STAPEG");
            entity.Property(e => e.NoPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NO_PHONE");
            entity.Property(e => e.NomorPolis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMOR_POLIS");
            entity.Property(e => e.NomorRekBank)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMOR_REK_BANK");
            entity.Property(e => e.NomorSpa).HasColumnName("NOMOR_SPA");
            entity.Property(e => e.Notas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOTAS");
            entity.Property(e => e.Pekerjaan).HasColumnName("PEKERJAAN");
            entity.Property(e => e.PksNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PKS_NO");
            entity.Property(e => e.Premi1).HasColumnName("PREMI1");
            entity.Property(e => e.Premi2).HasColumnName("PREMI2");
            entity.Property(e => e.PremiDasar).HasColumnName("PREMI_DASAR");
            entity.Property(e => e.PremiForecast).HasColumnName("PREMI_FORECAST");
            entity.Property(e => e.PremiRider).HasColumnName("PREMI_RIDER");
            entity.Property(e => e.PremiSaldo).HasColumnName("PREMI_SALDO");
            entity.Property(e => e.PremiumAdjustment).HasColumnName("PREMIUM_ADJUSTMENT");
            entity.Property(e => e.PremiumAdjustmentForecast).HasColumnName("PREMIUM_ADJUSTMENT_FORECAST");
            entity.Property(e => e.PremiumReceivableDate)
                .HasColumnType("datetime")
                .HasColumnName("PREMIUM_RECEIVABLE_DATE");
            entity.Property(e => e.PremiumReceivableDateForecast)
                .HasColumnType("datetime")
                .HasColumnName("PREMIUM_RECEIVABLE_DATE_FORECAST");
            entity.Property(e => e.SaldoAkhir).HasColumnName("SALDO_AKHIR");
            entity.Property(e => e.SaldoAkhirForecast).HasColumnName("SALDO_AKHIR_FORECAST");
            entity.Property(e => e.SaldoAwal).HasColumnName("SALDO_AWAL");
            entity.Property(e => e.SaldoAwalForecast).HasColumnName("SALDO_AWAL_FORECAST");
            entity.Property(e => e.SaldoForecast).HasColumnName("SALDO_FORECAST");
            entity.Property(e => e.SaldoPiutangInvoice).HasColumnName("SALDO_PIUTANG_INVOICE");
            entity.Property(e => e.SegmenProduk)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SEGMEN_PRODUK");
            entity.Property(e => e.Stapeg).HasColumnName("STAPEG");
            entity.Property(e => e.StatusPerkawinan)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STATUS_PERKAWINAN");
            entity.Property(e => e.TglLahirAnak1)
                .HasColumnType("datetime")
                .HasColumnName("TGL_LAHIR_ANAK1");
            entity.Property(e => e.TglLahirAnak2)
                .HasColumnType("datetime")
                .HasColumnName("TGL_LAHIR_ANAK2");
            entity.Property(e => e.TglLahirPemegangPolis)
                .HasColumnType("datetime")
                .HasColumnName("TGL_LAHIR_PEMEGANG_POLIS");
            entity.Property(e => e.TglLahirTertanggung)
                .HasColumnType("datetime")
                .HasColumnName("TGL_LAHIR_TERTANGGUNG");
            entity.Property(e => e.TglSaldo)
                .HasColumnType("datetime")
                .HasColumnName("TGL_SALDO");
            entity.Property(e => e.TglSaldoForecast)
                .HasColumnType("datetime")
                .HasColumnName("TGL_SALDO_FORECAST");
            entity.Property(e => e.Thn).HasColumnName("THN");
            entity.Property(e => e.ThnSaldo).HasColumnName("THN_SALDO");
            entity.Property(e => e.ThpKlaim).HasColumnName("THP_KLAIM");
            entity.Property(e => e.ThpPremi).HasColumnName("THP_PREMI");
            entity.Property(e => e.TmtJob)
                .HasColumnType("datetime")
                .HasColumnName("TMT_JOB");
            entity.Property(e => e.TopUp).HasColumnName("TOP_UP");
            entity.Property(e => e.TopUpForecast).HasColumnName("TOP_UP_FORECAST");
            entity.Property(e => e.TopupAdjustment).HasColumnName("TOPUP_ADJUSTMENT");
            entity.Property(e => e.TopupAdjustmentForecast).HasColumnName("TOPUP_ADJUSTMENT_FORECAST");
            entity.Property(e => e.TopupReceivableDate)
                .HasColumnType("datetime")
                .HasColumnName("TOPUP_RECEIVABLE_DATE");
            entity.Property(e => e.TopupReceivableDateForecast)
                .HasColumnType("datetime")
                .HasColumnName("TOPUP_RECEIVABLE_DATE_FORECAST");
            entity.Property(e => e.Tunjangan).HasColumnName("TUNJANGAN");
            entity.Property(e => e.UpAnak1).HasColumnName("UP_ANAK1");
            entity.Property(e => e.UpAnak2).HasColumnName("UP_ANAK2");
            entity.Property(e => e.UpDasar).HasColumnName("UP_DASAR");
            entity.Property(e => e.UpRider).HasColumnName("UP_RIDER");
            entity.Property(e => e.UpTotal).HasColumnName("UP_TOTAL");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
            entity.Property(e => e.UsiaAnak1).HasColumnName("USIA_ANAK1");
            entity.Property(e => e.UsiaAnak2).HasColumnName("USIA_ANAK2");
            entity.Property(e => e.UsiaBup).HasColumnName("USIA_BUP");
            entity.Property(e => e.UsiaMasukTertanggung).HasColumnName("USIA_MASUK_TERTANGGUNG");
            entity.Property(e => e.VirtualAccount)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VIRTUAL_ACCOUNT");
            entity.Property(e => e.Withdraw).HasColumnName("WITHDRAW");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
