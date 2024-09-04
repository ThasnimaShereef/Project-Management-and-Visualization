using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DBF;
using Npgsql;
using System.Data;


namespace TrafikSolMapLibrary.DLL
{
    public class TrafikSolMapDLL
    {
        public ObservableCollection<TrafikSolMapCBE> RetrieveTSubsystemMasterDetails()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> icons = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.tsubsystemmasterdetails()", connection))
                    {
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

                    if (dt.Rows[i]["TrafikID"] != DBNull.Value)
                        mapIcons.TrafikID = Convert.ToInt32(dt.Rows[i]["TrafikID"].ToString());

                    if (dt.Rows[i]["TSubSystemMID"] != DBNull.Value)
                        mapIcons.TSubSystemMID = Convert.ToInt32(dt.Rows[i]["TSubSystemMID"].ToString());

                    if (dt.Rows[i]["SubSysID"] != DBNull.Value)
                        mapIcons.SubSysID = Convert.ToInt32(dt.Rows[i]["SubSysID"].ToString());

                    if (dt.Rows[i]["Details"] != DBNull.Value)
                        mapIcons.Details = dt.Rows[i]["Details"].ToString();

                    if (dt.Rows[i]["ShortDetails"] != DBNull.Value)
                        mapIcons.ShortDetails = dt.Rows[i]["ShortDetails"].ToString();

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

                    if (dt.Rows[i]["VID"] != DBNull.Value)
                        mapIcons.VID = Convert.ToInt32(dt.Rows[i]["VID"].ToString());

                    if (dt.Rows[i]["VendorDesc"] != DBNull.Value)
                        mapIcons.VendorDesc = dt.Rows[i]["VendorDesc"].ToString();

                    if (dt.Rows[i]["SystemImage"] != DBNull.Value)
                        mapIcons.SystemImage = dt.Rows[i]["SystemImage"].ToString();

                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception)
            {
            }
            return mapIcon;
        }
        public ObservableCollection<TrafikSolMapCBE> RetrieveTPositionMasterDetails()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> icons = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.tpositionmaster()", connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            icons = ConvertPositionCollection(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally { dt = null; }
            return icons;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertPositionCollection(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> position = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrafikSolMapCBE routePosition = new TrafikSolMapCBE();


                    if (dt.Rows[i]["Latitude"] != DBNull.Value)
                        routePosition.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);

                    if (dt.Rows[i]["Longitude"] != DBNull.Value)
                        routePosition.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);

                    if (dt.Rows[i]["Position"] != DBNull.Value)
                        routePosition.Position = Convert.ToDouble(dt.Rows[i]["Position"]);

                    if (dt.Rows[i]["TrafikID"] != DBNull.Value)
                        routePosition.TrafikID = Convert.ToInt32(dt.Rows[i]["TrafikID"].ToString());

                    if (dt.Rows[i]["PositionID"] != DBNull.Value)
                        routePosition.PositionID = Convert.ToInt32(dt.Rows[i]["PositionID"].ToString());

                    if (dt.Rows[i]["ProjectID"] != DBNull.Value)
                        routePosition.ProjectID = Convert.ToInt32(dt.Rows[i]["ProjectID"].ToString());

                    if (dt.Rows[i]["PointType"] != DBNull.Value)
                        routePosition.PointType = Convert.ToInt32(dt.Rows[i]["PointType"].ToString());

                    if (dt.Rows[i]["Alive"] != DBNull.Value)
                        routePosition.Alive = (Convert.ToInt32(dt.Rows[i]["Alive"].ToString()) == 1 ? true : false);

                    if (dt.Rows[i]["Address"] != DBNull.Value)
                        routePosition.Address = dt.Rows[i]["Address"].ToString();

                    position.Add(routePosition);
                }
            }
            catch (Exception)
            {
            }
            return position;
        }
    }
}
