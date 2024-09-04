using Npgsql;
using System.Collections.ObjectModel;
using System.Data;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DBF;

namespace TrafikSolMapLibrary.DLL
{
    public class TrafikSolAdminDLL
    {
        public ObservableCollection<TrafikSolMapCBE> ProjectType()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> data = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.projecttype()", connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            data = ConvertDataTableToCollectionprojecttype(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return data;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertDataTableToCollectionprojecttype(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> mapIcon = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrafikSolMapCBE mapIcons = new TrafikSolMapCBE();

                    if (dt.Rows[i]["ProjectTypeID"] != DBNull.Value)
                        mapIcons.ProjectTypeID = Convert.ToInt32(dt.Rows[i]["ProjectTypeID"].ToString());

                    if (dt.Rows[i]["ProjectTypeName"] != DBNull.Value)
                        mapIcons.ProjectTypeName = dt.Rows[i]["ProjectTypeName"].ToString();

                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception)
            {
            }
            return mapIcon;
        }
        public ObservableCollection<TrafikSolMapCBE> ProjectDetails()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> data = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.projectdetails()", connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            data = ConvertDataTableToCollectionprojectdetails(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return data;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertDataTableToCollectionprojectdetails(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> mapIcon = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrafikSolMapCBE mapIcons = new TrafikSolMapCBE();
                    //mapIcons.SrNo= i + 1;

                    if (dt.Rows[i]["ProjectID"] != DBNull.Value)
                        mapIcons.ProjectID = Convert.ToInt32(dt.Rows[i]["ProjectID"].ToString());

                    if (dt.Rows[i]["ProjectTypeID"] != DBNull.Value)
                        mapIcons.ProjectTypeID = Convert.ToInt32(dt.Rows[i]["ProjectTypeID"].ToString());

                    if (dt.Rows[i]["ProjectName"] != DBNull.Value)
                        mapIcons.ProjectName = dt.Rows[i]["ProjectName"].ToString();

                    if (dt.Rows[i]["RecordInsertedBy"] != DBNull.Value)
                        mapIcons.RecordInsertedBy = dt.Rows[i]["RecordInsertedBy"].ToString();

                    if (dt.Rows[i]["RecordInsertedDate"] != DBNull.Value)
                        mapIcons.RecordInsertedDate = (DateTime)dt.Rows[i]["RecordInsertedDate"];

                    if (dt.Rows[i]["Alive"] != DBNull.Value)
                        mapIcons.Alive = (Convert.ToInt32(dt.Rows[i]["Alive"].ToString()) == 1 ? true : false);

                    if (dt.Rows[i]["ContactPerson"] != DBNull.Value)
                        mapIcons.ContactPerson = dt.Rows[i]["ContactPerson"].ToString();

                    if (dt.Rows[i]["EmailID"] != DBNull.Value)
                        mapIcons.EmailID = dt.Rows[i]["EmailID"].ToString();

                    if (dt.Rows[i]["ContactNo1"] != DBNull.Value)
                        mapIcons.ContactNo1 = Convert.ToInt64(dt.Rows[i]["ContactNo1"].ToString());

                    if (dt.Rows[i]["ContactNo2"] != DBNull.Value)
                        mapIcons.ContactNo2 = Convert.ToInt64(dt.Rows[i]["ContactNo2"].ToString());

                    if (dt.Rows[i]["LandlineNo"] != DBNull.Value)
                        mapIcons.LandlineNo = Convert.ToInt64(dt.Rows[i]["LandlineNo"].ToString());

                    if (dt.Rows[i]["GstNo"] != DBNull.Value)
                        mapIcons.GstNo = dt.Rows[i]["GstNo"].ToString();

                    if (dt.Rows[i]["CountryID"] != DBNull.Value)
                        mapIcons.CountryID = Convert.ToInt32(dt.Rows[i]["CountryID"].ToString());

                    if (dt.Rows[i]["StateID"] != DBNull.Value)
                        mapIcons.StateID = Convert.ToInt32(dt.Rows[i]["StateID"].ToString());

                    if (dt.Rows[i]["CityID"] != DBNull.Value)
                        mapIcons.CityID = Convert.ToInt32(dt.Rows[i]["CityID"].ToString());

                    if (dt.Rows[i]["Landmark"] != DBNull.Value)
                        mapIcons.Landmark = Convert.ToInt32(dt.Rows[i]["Landmark"].ToString());

                    if (dt.Rows[i]["PermanentAddress"] != DBNull.Value)
                        mapIcons.PermanentAddress = dt.Rows[i]["PermanentAddress"].ToString();

                    if (dt.Rows[i]["PermanentPincode"] != DBNull.Value)
                        mapIcons.PermanentPincode = Convert.ToInt32(dt.Rows[i]["PermanentPincode"].ToString());

                    if (dt.Rows[i]["BillingAddress"] != DBNull.Value)
                        mapIcons.BillingAddress = dt.Rows[i]["BillingAddress"].ToString();

                    if (dt.Rows[i]["BillingPincode"] != DBNull.Value)
                        mapIcons.BillingPincode = Convert.ToInt32(dt.Rows[i]["BillingPincode"].ToString());

                    if (dt.Rows[i]["ProjectTypeName"] != DBNull.Value)
                        mapIcons.ProjectTypeName = dt.Rows[i]["ProjectTypeName"].ToString();


                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception)
            {
            }
            return mapIcon;
        }
        public ObservableCollection<TrafikSolMapCBE> SubsystemType()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> data = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.subsystemtype()", connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            data = ConvertDataTableToCollectionSubsystemType(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return data;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertDataTableToCollectionSubsystemType(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> mapIcon = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrafikSolMapCBE mapIcons = new TrafikSolMapCBE();

                    if (dt.Rows[i]["SubSystemTypeID"] != DBNull.Value)
                        mapIcons.SubSystemTypeID = Convert.ToInt32(dt.Rows[i]["SubSystemTypeID"].ToString());

                    if (dt.Rows[i]["Details"] != DBNull.Value)
                        mapIcons.Details = dt.Rows[i]["Details"].ToString();

                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception)
            {
            }
            return mapIcon;
        }
        public ObservableCollection<TrafikSolMapCBE> SubsystemDetails()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> data = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.subsystemdetails()", connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            data = ConvertDataTableToCollectionSubsystemDetails(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return data;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertDataTableToCollectionSubsystemDetails(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> mapIcon = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrafikSolMapCBE mapIcons = new TrafikSolMapCBE();

                    if (dt.Rows[i]["SubSysID"] != DBNull.Value)
                        mapIcons.SubSysID = Convert.ToInt32(dt.Rows[i]["SubSysID"].ToString());

                    if (dt.Rows[i]["SystemID"] != DBNull.Value)
                        mapIcons.SystemID = Convert.ToInt32(dt.Rows[i]["SystemID"].ToString());

                    if (dt.Rows[i]["Details"] != DBNull.Value)
                        mapIcons.Details = dt.Rows[i]["Details"].ToString();

                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception)
            {
            }
            return mapIcon;
        }
        public ObservableCollection<TrafikSolMapCBE> VendorDetails()
        {
            DataTable? dt = new DataTable();

            ObservableCollection<TrafikSolMapCBE> data = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM public.vendordetails()", connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            // Fill the DataTable with the result of the function
                            adapter.Fill(dt);
                            data = ConvertDataTableToCollectionVendorDetails(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return data;
        }
        public ObservableCollection<TrafikSolMapCBE> ConvertDataTableToCollectionVendorDetails(DataTable dt)
        {
            ObservableCollection<TrafikSolMapCBE> mapIcon = new ObservableCollection<TrafikSolMapCBE>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TrafikSolMapCBE mapIcons = new TrafikSolMapCBE();


                    if (dt.Rows[i]["VID"] != DBNull.Value)
                        mapIcons.VID = Convert.ToInt32(dt.Rows[i]["VID"].ToString());

                    if (dt.Rows[i]["SubSysID"] != DBNull.Value)
                        mapIcons.SubSysID = Convert.ToInt32(dt.Rows[i]["SubSysID"].ToString());

                    if (dt.Rows[i]["VendorDesc"] != DBNull.Value)
                        mapIcons.VendorDesc = dt.Rows[i]["VendorDesc"].ToString();

                    if (dt.Rows[i]["VendorID"] != DBNull.Value)
                        mapIcons.VendorID = Convert.ToInt32(dt.Rows[i]["VendorID"].ToString());

                    if (dt.Rows[i]["RecordInsertedBy"] != DBNull.Value)
                        mapIcons.RecordInsertedBy = dt.Rows[i]["RecordInsertedBy"].ToString();

                    if (dt.Rows[i]["RecordInsertedDate"] != DBNull.Value)
                        mapIcons.RecordInsertedDate = (DateTime)dt.Rows[i]["RecordInsertedDate"];

                    if (dt.Rows[i]["Alive"] != DBNull.Value)
                        mapIcons.Alive = (Convert.ToInt32(dt.Rows[i]["Alive"].ToString()) == 1 ? true : false);

                    if (dt.Rows[i]["Details"] != DBNull.Value)
                        mapIcons.Details = dt.Rows[i]["Details"].ToString();

                    mapIcon.Add(mapIcons);
                }
            }
            catch (Exception)
            {
            }
            return mapIcon;
        }

    }
}
