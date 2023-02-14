using Microsoft.EntityFrameworkCore;

namespace Contrado.Models
{
    public class FileParameters
    {
        public int? Consignment_number { get; set; }
        public string? Service_level { get; set; }
        public string? Manifest_date { get; set; }
        public string? Collection_depot { get; set; }
        public string? Collection_town { get; set; }
        public string? Collection_postcode { get; set; }
        public string? Collection_date { get; set; }
        public string? Hub { get; set; }
        public string? Delivery_depot { get; set; }
        public string? Delivery_town { get; set; }
        public string? Delivery_postcode { get; set; }
        public string? Delivery_date { get; set; }
        public string? Delivery_time_from { get; set; }
        public string? Delivery_time_to { get; set; }
        public int? Total_weight { get; set; }
        public string? Surcharges { get; set; }
        public int? Full_pallets { get; set; }
        public int? Half_pallets { get; set; }
        public int? Quarter_pallets { get; set; }
        public int? Micro_pallets { get; set; }
        public int? Total_pallets { get; set; }
        public bool Valid_consignment { get; set; }
    }

    //public class ConsignmentParameterContext : DbContext
    //{
    //    public DbSet<FileParameters> ConsignmentTable { get; set; }
    //}
}
