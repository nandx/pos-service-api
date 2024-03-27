namespace pos_service_api.Dto
{
    public class ReportCutoffTaspenSaveDto
    {

        public int TAHUN { get; set; }
        public int BULAN { get; set; }
        public string? SPANO { get; set; }
        public string? POLICYNO { get; set; }
        public string? PARTNERNAME { get; set; }
        public string? PRODUCTNAME { get; set; }
        public string? NOTAS { get; set; }
        public DateTime? TGLSALDO { get; set; }
        public Int64 IDMEMBER { get; set; }
        public string? NAMA { get; set; }
    }
}
