using LumenWorks.Framework.IO.Csv;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;

namespace Contrado.Models
{
    public class UploadCsvFileRequest
    {
        public IFormFile File { get; set; }
    }

    public class UploadCsvFileResponse
    {
        public List<FileParameters> responseResult(UploadCsvFileRequest request, String path)
        {
            List<FileParameters> Consignment_details = new List<FileParameters>();
            DataTable table = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(path)), true))
            {
                table.Load(csvReader);
            }
            for(int i=0;i<table.Rows.Count;i++)
            {
                FileParameters rows = new FileParameters();
                rows.Consignment_number = table.Rows[i][0] != null ? Convert.ToInt32(table.Rows[i][0]) : null;
                rows.Service_level = table.Rows[i][1] != null ? Convert.ToString(table.Rows[i][1]) : null;
                rows.Manifest_date = table.Rows[i][2] != null ? Convert.ToString(table.Rows[i][2]) : null;
                rows.Collection_depot = table.Rows[i][3] != null ? Convert.ToString(table.Rows[i][3]) : null;
                rows.Collection_town = table.Rows[i][4] != null ? Convert.ToString(table.Rows[i][4]) : null;
                rows.Collection_postcode = table.Rows[i][5] != null ? Convert.ToString(table.Rows[i][5]) : null;
                rows.Collection_date = table.Rows[i][6] != null ? Convert.ToString(table.Rows[i][6]) : null;
                rows.Hub = table.Rows[i][7] != null ? Convert.ToString(table.Rows[i][7]) : null;
                rows.Delivery_depot = table.Rows[i][8] != null ? Convert.ToString(table.Rows[i][8]) : null;
                rows.Delivery_town = table.Rows[i][9] != null ? Convert.ToString(table.Rows[i][9]) : null;
                rows.Delivery_postcode = table.Rows[i][10] != null ? Convert.ToString(table.Rows[i][10]) : null;
                rows.Delivery_date = table.Rows[i][11] != null ? Convert.ToString(table.Rows[i][11]) : null;
                rows.Delivery_time_from = table.Rows[i][12] != null ? Convert.ToString(table.Rows[i][12]) : null;
                rows.Delivery_time_to = table.Rows[i][13] != null ? Convert.ToString(table.Rows[i][13]) : null;
                rows.Total_weight = table.Rows[i][14] != null ? Convert.ToInt32(table.Rows[i][14]) : null;
                rows.Surcharges = table.Rows[i][15] != null ? Convert.ToString(table.Rows[i][15]) : null;
                rows.Full_pallets = table.Rows[i][16] != null ? Convert.ToInt32(table.Rows[i][16]) : null;
                rows.Half_pallets = table.Rows[i][17] != null ? Convert.ToInt32(table.Rows[i][17]) : null;
                rows.Quarter_pallets = table.Rows[i][18] != null ? Convert.ToInt32(table.Rows[i][18]) : null;
                rows.Micro_pallets = table.Rows[i][19] != null ? Convert.ToInt32(table.Rows[i][19]) : null;
                rows.Total_pallets = rows.Full_pallets + rows.Half_pallets + rows.Quarter_pallets + rows.Micro_pallets;
                //table.Rows[i][20] != null ? Convert.ToInt32(table.Rows[i][20]) : null;
                //rows.Valid_consignment = table.Rows[i][21] != null ? Convert.ToBoolean(table.Rows[i][21]): false;
                Consignment_details.Add(rows);
            }

            foreach (var temp in Consignment_details)
            {
                if ((string.IsNullOrEmpty(temp.Consignment_number.ToString())==false) && (string.IsNullOrEmpty(temp.Collection_postcode.ToString())==false) && (string.IsNullOrEmpty(temp.Delivery_postcode.ToString()) == false) && (string.IsNullOrEmpty(temp.Delivery_town.ToString()) == false) && (string.IsNullOrEmpty(temp.Collection_town.ToString()) == false))
                {
                    int conLen = Convert.ToString(temp.Consignment_number).Length;
                    int colPostLen = Convert.ToString(temp.Collection_postcode).Length;
                    int delPostLen = Convert.ToString(temp.Delivery_postcode).Length;
                    if ((conLen > 7 && conLen < 15) && (colPostLen == 6) && (delPostLen == 6))
                    {
                        temp.Valid_consignment = true;
                    }
                    else
                    {
                        temp.Valid_consignment = false;
                    }
                }
                else
                {
                    temp.Valid_consignment = false;
                }

            }
            return Consignment_details;
        }
        
    }
}
