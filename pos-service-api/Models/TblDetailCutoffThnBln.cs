using System;
using System.Collections.Generic;

namespace pos_service_api.Models;

public partial class TblDetailCutoffThnBln
{
    public long Id { get; set; }

    public int Thn { get; set; }

    public int Bln { get; set; }

    public string SegmenProduk { get; set; } = null!;

    public string KodeProduk { get; set; } = null!;

    public string NamaProduk { get; set; } = null!;

    public long? IdDistributionChannelPemasaran { get; set; }

    public string? NamaDistributionChannelPemasaran { get; set; }

    public string? NamaInstansiBusb { get; set; }

    public string? KodeCabang { get; set; }

    public string? NamaCabang { get; set; }

    public string? KodeAgen { get; set; }

    public string? NamaAgen { get; set; }

    public long? NomorSpa { get; set; }

    public string? NomorPolis { get; set; }

    public string? Notas { get; set; }

    public string? NamaPemegangPolis { get; set; }

    public DateTime? TglLahirPemegangPolis { get; set; }

    public long? IdMember { get; set; }

    public string? Nip { get; set; }

    public string? NamaTertanggung { get; set; }

    public string? Nik { get; set; }

    public string? JenisKelamin { get; set; }

    public DateTime? TglLahirTertanggung { get; set; }

    public long? Pekerjaan { get; set; }

    public string? Jabatan { get; set; }

    public string? KdPangkat { get; set; }

    public string? StatusPerkawinan { get; set; }

    public string? NoPhone { get; set; }

    public string? Email { get; set; }

    public DateTime? TmtJob { get; set; }

    public DateTime? MulaiAsuransi { get; set; }

    public int? MasaAsuransiBln { get; set; }

    public int? MasaAsuransiThn { get; set; }

    public int? UsiaMasukTertanggung { get; set; }

    public int? UsiaBup { get; set; }

    public DateTime? AkhirAsuransi { get; set; }

    public string? KodeJiwa { get; set; }

    public int? JumlahIstri { get; set; }

    public int? JumlahAnak { get; set; }

    public double? GapokAwal { get; set; }

    public double? Gapok { get; set; }

    public double? Tunjangan { get; set; }

    public double? Gapok97 { get; set; }

    public double? Gapok2003 { get; set; }

    public int? Stapeg { get; set; }

    public string? NmStapeg { get; set; }

    public double? ThpPremi { get; set; }

    public double? ThpKlaim { get; set; }

    public double? Premi1 { get; set; }

    public double? PremiDasar { get; set; }

    public double? Premi2 { get; set; }

    public double? PremiRider { get; set; }

    public double? ExtraPremi { get; set; }

    public double? TopUp { get; set; }

    public double? AkumulasiPremi { get; set; }

    public string? CaraBayarPremi { get; set; }

    public string? MasaBayarPremi { get; set; }

    public double? SaldoAwal { get; set; }

    public double? Bpa2 { get; set; }

    public double? Coi { get; set; }

    public double? Komisi { get; set; }

    public double? Bpa1 { get; set; }

    public double? Bpd1 { get; set; }

    public double? Inv { get; set; }

    public double? Bpd2 { get; set; }

    public double? SaldoAkhir { get; set; }

    public DateTime? TglSaldo { get; set; }

    public double? UpDasar { get; set; }

    public double? UpRider { get; set; }

    public double? UpTotal { get; set; }

    public string? JenisKredit { get; set; }

    public string? PksNo { get; set; }

    public string? NamaBank { get; set; }

    public string? NamaPemilikRekening { get; set; }

    public string? NomorRekBank { get; set; }

    public string? VirtualAccount { get; set; }

    public string? NamaAnak1 { get; set; }

    public DateTime? TglLahirAnak1 { get; set; }

    public int? UsiaAnak1 { get; set; }

    public double? UpAnak1 { get; set; }

    public string? NamaAnak2 { get; set; }

    public DateTime? TglLahirAnak2 { get; set; }

    public int? UsiaAnak2 { get; set; }

    public double? UpAnak2 { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateDate { get; set; }

    public double? SaldoAwalForecast { get; set; }

    public double? SaldoAkhirForecast { get; set; }

    public double? AkumulasiPremiForecast { get; set; }

    public DateTime? TglSaldoForecast { get; set; }

    public double? Bpa1Forecast { get; set; }

    public double? Bpa2Forecast { get; set; }

    public double? CoiForecast { get; set; }

    public double? KomisiForecast { get; set; }

    public double? Bpd1Forecast { get; set; }

    public double? Bpd2Forecast { get; set; }

    public double? InvForecast { get; set; }

    public string? Entryby { get; set; }

    public double? Withdraw { get; set; }

    public int? ThnSaldo { get; set; }

    public int? BlnSaldo { get; set; }

    public double? TopUpForecast { get; set; }

    public double? PremiForecast { get; set; }

    public double? PremiSaldo { get; set; }

    public double? Deposit { get; set; }

    public double? PremiumAdjustment { get; set; }

    public double? PremiumAdjustmentForecast { get; set; }

    public DateTime? PremiumReceivableDate { get; set; }

    public DateTime? PremiumReceivableDateForecast { get; set; }

    public DateTime? TopupReceivableDate { get; set; }

    public DateTime? TopupReceivableDateForecast { get; set; }

    public double? TopupAdjustment { get; set; }

    public double? TopupAdjustmentForecast { get; set; }

    public double? BalanceAdjustment { get; set; }

    public double? BalanceAdjustmentForecast { get; set; }

    public double? SaldoPiutangInvoice { get; set; }

    public double? SaldoForecast { get; set; }
}
