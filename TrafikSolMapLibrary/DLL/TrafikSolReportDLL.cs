using Npgsql;
using System.Collections.ObjectModel;
using System.Data;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DBF;

namespace TrafikSolMapLibrary.DLL
{
    public class TrafikSolReportDLL
    {
        public ObservableCollection<TrafikSolMapCBE> RetrieveProjectDetailsReport(DateTime startDate, DateTime endDate)
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> icons = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.projectdetailsreport(@start_date, @end_date)", connection))
                    {
                        command.Parameters.AddWithValue("@start_date", startDate);
                        command.Parameters.AddWithValue("@end_date", endDate);

                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            icons = ConvertDataTableToCollection(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return icons;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertDataTableToCollection(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> mapIcon = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrafikSolMapCBE mapIcons = new TrafikSolMapCBE();
                    //mapIcons.SrNo = i + 1;

                    if (dt.Rows[i]["TSubSystemMID"] != DBNull.Value)
                        mapIcons.TSubSystemMID = Convert.ToInt32(dt.Rows[i]["TSubSystemMID"].ToString());

                    if (dt.Rows[i]["SubSysID"] != DBNull.Value)
                        mapIcons.SubSysID = Convert.ToInt32(dt.Rows[i]["SubSysID"].ToString());

                    if (dt.Rows[i]["Details"] != DBNull.Value)
                        mapIcons.Details = dt.Rows[i]["Details"].ToString();

                    if (dt.Rows[i]["Location"] != DBNull.Value)
                        mapIcons.Location = dt.Rows[i]["Location"].ToString();

                    if (dt.Rows[i]["IPAddress"] != DBNull.Value)
                        mapIcons.IPAddress = dt.Rows[i]["IPAddress"].ToString();

                    if (dt.Rows[i]["Latitude"] != DBNull.Value)
                        mapIcons.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);

                    if (dt.Rows[i]["Longitude"] != DBNull.Value)
                        mapIcons.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);

                    if (dt.Rows[i]["Address"] != DBNull.Value)
                        mapIcons.Address = dt.Rows[i]["Address"].ToString();

                    if (dt.Rows[i]["Alive"] != DBNull.Value)
                        mapIcons.Alive = (Convert.ToInt32(dt.Rows[i]["Alive"].ToString()) == 1 ? true : false);

                    if (dt.Rows[i]["VendorID"] != DBNull.Value)
                        mapIcons.VendorID = Convert.ToInt32(dt.Rows[i]["VendorID"].ToString());

                    if (dt.Rows[i]["Vendor"] != DBNull.Value)
                        mapIcons.Vendor = dt.Rows[i]["Vendor"].ToString();

                    if (dt.Rows[i]["SerialNo"] != DBNull.Value)
                        mapIcons.SerialNo = dt.Rows[i]["SerialNo"].ToString();

                    if (dt.Rows[i]["Model"] != DBNull.Value)
                        mapIcons.Model = dt.Rows[i]["Model"].ToString();

                    if (dt.Rows[i]["Verified"] != DBNull.Value)
                        mapIcons.Verified = (Convert.ToInt32(dt.Rows[i]["Verified"].ToString()) == 1 ? true : false);

                    if (dt.Rows[i]["ProjectID"] != DBNull.Value)
                        mapIcons.ProjectID = Convert.ToInt32(dt.Rows[i]["ProjectID"].ToString());

                    if (dt.Rows[i]["SystemID"] != DBNull.Value)
                        mapIcons.SystemID = Convert.ToInt32(dt.Rows[i]["SystemID"].ToString());

                    if (dt.Rows[i]["RecordInsertedBy"] != DBNull.Value)
                        mapIcons.RecordInsertedBy = dt.Rows[i]["RecordInsertedBy"].ToString();

                    if (dt.Rows[i]["RecordInsertedDate"] != DBNull.Value)
                        mapIcons.RecordInsertedDate = (DateTime)dt.Rows[i]["RecordInsertedDate"];

                    if (dt.Rows[i]["SubsystemInstallationDate"] != DBNull.Value)
                        mapIcons.SubsystemInstallationDate = (DateTime)dt.Rows[i]["SubsystemInstallationDate"];

                    if (dt.Rows[i]["WarrantyStartDate"] != DBNull.Value)
                        mapIcons.WarrantyStartDate = (DateTime)dt.Rows[i]["WarrantyStartDate"];

                    if (dt.Rows[i]["WarrantyEndDate"] != DBNull.Value)
                        mapIcons.WarrantyEndDate = (DateTime)dt.Rows[i]["WarrantyEndDate"];

                    if (dt.Rows[i]["ProjectTypeID"] != DBNull.Value)
                        mapIcons.ProjectTypeID = Convert.ToInt32(dt.Rows[i]["ProjectTypeID"].ToString());

                    if (dt.Rows[i]["ProjectTypeName"] != DBNull.Value)
                        mapIcons.ProjectTypeName = dt.Rows[i]["ProjectTypeName"].ToString();

                    if (dt.Rows[i]["ProjectName"] != DBNull.Value)
                        mapIcons.ProjectName = dt.Rows[i]["ProjectName"].ToString();

                    if (dt.Rows[i]["SubsystemName"] != DBNull.Value)
                        mapIcons.SubsystemName = dt.Rows[i]["SubsystemName"].ToString();

                    if (dt.Rows[i]["SubsystemType"] != DBNull.Value)
                        mapIcons.SubsystemType = dt.Rows[i]["SubsystemType"].ToString();


                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception ex)
            {
            }
            return mapIcon;
        }
    }
}
