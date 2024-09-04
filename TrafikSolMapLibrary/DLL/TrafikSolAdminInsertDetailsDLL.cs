using Npgsql;
using System.Data;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DBF;

namespace TrafikSolMapLibrary.DLL
{
    public class TrafikSolAdminInsertDetailsDLL
    {
        public async Task<string?> InsertTSubsystemVendorDetails(TrafikSolMapCBE model)

        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();

                    string commandText = "insert_tsubsystemvendor";
                    using (var command = new NpgsqlCommand(commandText, connection))

                    {
                        command.CommandType = CommandType.StoredProcedure;
 
                        command.Parameters.AddWithValue("p_subsysid", NpgsqlTypes.NpgsqlDbType.Integer, (object)model.SubSysID ?? DBNull.Value);
                        command.Parameters.AddWithValue("p_vendordesc", NpgsqlTypes.NpgsqlDbType.Text, model.VendorDesc ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("p_alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);
                        command.Parameters.AddWithValue("p_recordinsertedby", NpgsqlTypes.NpgsqlDbType.Text, model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("p_recordinserteddate", NpgsqlTypes.NpgsqlDbType.Timestamp, (object)model.RecordInsertedDate ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        // updating database values on changing icon position  
        public async Task<string?> UpdateTSubsystemVendorDetails(TrafikSolMapCBE model)
        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))

                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT public.update_vendordetails(@vid, @subsysid, @vendordesc, @recordinsertedby, @recordinserteddate, @alive)", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("vid", model.VID);
                        command.Parameters.AddWithValue("subsysid", model.SubSysID);
                        command.Parameters.AddWithValue("vendordesc", model.VendorDesc ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("recordinsertedby", model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("recordinserteddate", (object)model.RecordInsertedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<string?>InsertProjectDetails(TrafikSolMapCBE model)

        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                     connection.Open();

                    string commandText = "public.insertprojectdata";
                    using (var command = new NpgsqlCommand(commandText, connection))

                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("projecttypeid", model.ProjectTypeID);
                        command.Parameters.AddWithValue("projectname", model.ProjectName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("recordinsertedby", model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("recordinserteddate", (object)model.RecordInsertedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);
                        command.Parameters.AddWithValue("contactperson", model.ContactPerson ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("emailid", model.EmailID ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("contactno1", (object)(long)model.ContactNo1 ?? DBNull.Value);
                        command.Parameters.AddWithValue("contactno2", (object)(long)model.ContactNo2 ?? DBNull.Value);
                        command.Parameters.AddWithValue("landlineno", (object)(long)model.LandlineNo ?? DBNull.Value);
                        command.Parameters.AddWithValue("gstno", model.GstNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("countryid", (object)model.CountryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("stateid", (object)model.StateID ?? DBNull.Value);
                        command.Parameters.AddWithValue("cityid", (object)model.CityID ?? DBNull.Value);
                        command.Parameters.AddWithValue("landmark", (object)model.Landmark ?? DBNull.Value);
                        command.Parameters.AddWithValue("permanentaddress", model.PermanentAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("permanentpincode", (object)model.PermanentPincode ?? DBNull.Value);
                        command.Parameters.AddWithValue("billingaddress", model.BillingAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("billingpincode", (object)model.BillingPincode ?? DBNull.Value);

                         command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<string?> UpdateProjectDetails(TrafikSolMapCBE model)
        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))

                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT public.update_projectdetails(@projectid, @projecttypeid, " +
                        "@projectname, @recordinsertedby, @recordinserteddate, @contactperson, @emailid, @contactno1, @contactno2," +
                        "@landlineno, @gstno, @countryid, @stateid, @cityid, @landmark, @permanentaddress, @permanentpincode," +
                        "@billingaddress, @billingpincode, @alive)", connection))
                    {
                        command.Parameters.AddWithValue("projectid", model.ProjectID);
                        command.Parameters.AddWithValue("projecttypeid", model.ProjectTypeID);
                        command.Parameters.AddWithValue("projectname", model.ProjectName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("recordinsertedby", model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("recordinserteddate", (object)model.RecordInsertedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("contactperson", model.ContactPerson ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("emailid", model.EmailID ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("contactno1", (object)(long)model.ContactNo1 ?? DBNull.Value);
                        command.Parameters.AddWithValue("contactno2", (object)(long)model.ContactNo2 ?? DBNull.Value);
                        command.Parameters.AddWithValue("landlineno", (object)(long)model.LandlineNo ?? DBNull.Value);
                        command.Parameters.AddWithValue("gstno", model.GstNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("countryid", (object)model.CountryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("stateid", (object)model.StateID ?? DBNull.Value);
                        command.Parameters.AddWithValue("cityid", (object)model.CityID ?? DBNull.Value);
                        command.Parameters.AddWithValue("landmark", (object)model.Landmark ?? DBNull.Value);
                        command.Parameters.AddWithValue("permanentaddress", model.PermanentAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("permanentpincode", (object)model.PermanentPincode ?? DBNull.Value);
                        command.Parameters.AddWithValue("billingaddress", model.BillingAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("billingpincode", (object)model.BillingPincode ?? DBNull.Value);
                        command.Parameters.AddWithValue("alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<string?> InsertTSubsystemMasterDetails(TrafikSolMapCBE model)

        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();

                    string commandText = "public.insertsubsystemdata";
                    using (var command = new NpgsqlCommand(commandText, connection))

                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("s_subsysid", model.SubSysID);
                        command.Parameters.AddWithValue("s_details", model.Details ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_shortdetails", model.ShortDetails ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_location", model.Location ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_ipaddress", model.IPAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_latitude", NpgsqlTypes.NpgsqlDbType.Numeric, (object)model.Latitude ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_longitude", NpgsqlTypes.NpgsqlDbType.Numeric, (object)model.Longitude ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_address", model.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_vendorid", (object)model.VendorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_model", model.VendorModel ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_vendor", model.VendorDesc ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_serialno", model.SerialNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_projectid", (object)model.ProjectID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_systemid", (object)model.SubSystemTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_recordinsertedby", model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_recordinserteddate", (object)model.RecordInsertedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_installationdate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.SubsystemInstallationDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_warrantystartdate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.WarrantyStartDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_warrantyenddate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.WarrantyEndDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<string?> InsertPreviousTSubsystemMasterDetails(TrafikSolMapCBE model)

        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))
                {
                    connection.Open();

                    string commandText = "public.insert_previoussubsystemdata";
                    using (var command = new NpgsqlCommand(commandText, connection))

                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("s_subsysid", model.SubSysID);
                        command.Parameters.AddWithValue("s_details", model.Details ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_shortdetails", model.ShortDetails ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_location", model.Location ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_ipaddress", model.IPAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_latitude", NpgsqlTypes.NpgsqlDbType.Numeric, (object)model.Latitude ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_longitude", NpgsqlTypes.NpgsqlDbType.Numeric, (object)model.Longitude ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_address", model.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_vendorid", (object)model.VendorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_model", model.VendorModel ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_vendor", model.VendorDesc ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_serialno", model.SerialNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_projectid", (object)model.ProjectID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_systemid", (object)model.SubSystemTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_recordinsertedby", model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_recordinserteddate", (object)model.RecordInsertedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_installationdate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.SubsystemInstallationDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_warrantystartdate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.WarrantyStartDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_warrantyenddate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.WarrantyEndDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<string?> UpdateTSubsystemMasterDetails(TrafikSolMapCBE model)
        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))

                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT public.update_subsystemdetails(@s_tsubsystemmid, @s_subsysid, @s_details, " +
                        "@s_shortdetails, @s_location, @s_ipaddress, @s_longitude, @s_latitude, @s_address, @s_vendorid, @s_model," +
                        "@s_vendor, @s_serialno, @s_projectid, @s_systemid, @s_recordinsertedby, @s_recordinserteddate, @s_installationdate," +
                        "@s_warrantystartdate, @s_warrantyenddate, @s_alive)", connection))
                    {
                        command.Parameters.AddWithValue("s_tsubsystemmid", model.TSubSystemMID);
                        command.Parameters.AddWithValue("s_subsysid", NpgsqlTypes.NpgsqlDbType.Integer, model.SubSysID);
                        command.Parameters.AddWithValue("s_details", NpgsqlTypes.NpgsqlDbType.Text, model.Details ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_shortdetails", NpgsqlTypes.NpgsqlDbType.Text, model.ShortDetails ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_location", NpgsqlTypes.NpgsqlDbType.Text, model.Location ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_ipaddress", NpgsqlTypes.NpgsqlDbType.Text, model.IPAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_longitude", NpgsqlTypes.NpgsqlDbType.Numeric, (object)model.Longitude ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_latitude", NpgsqlTypes.NpgsqlDbType.Numeric, (object)model.Latitude ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_address", NpgsqlTypes.NpgsqlDbType.Text, model.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_vendorid", NpgsqlTypes.NpgsqlDbType.Integer, (object)model.VendorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_model", NpgsqlTypes.NpgsqlDbType.Text, model.VendorModel ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_vendor", NpgsqlTypes.NpgsqlDbType.Text, model.VendorDesc ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_serialno", NpgsqlTypes.NpgsqlDbType.Text, model.SerialNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_projectid", NpgsqlTypes.NpgsqlDbType.Integer, (object)model.ProjectID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_systemid", NpgsqlTypes.NpgsqlDbType.Integer, (object)model.SubSystemTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_recordinsertedby", NpgsqlTypes.NpgsqlDbType.Text, model.RecordInsertedBy ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("s_recordinserteddate", NpgsqlTypes.NpgsqlDbType.Timestamp, (object)model.RecordInsertedDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_installationdate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.SubsystemInstallationDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_warrantystartdate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.WarrantyStartDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_warrantyenddate", NpgsqlTypes.NpgsqlDbType.Date, (object)model.WarrantyEndDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("s_alive", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Alive ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<string?> VerifyTSubsystemMasterDetails(TrafikSolMapCBE model)
        {
            try
            {
                using (var connection = new NpgsqlConnection(TrafikSolMapDBF.ConnectionString()))

                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT public.verify_subsystemdetails(@s_tsubsystemmid, @s_verified)", connection))
                    {
                        command.Parameters.AddWithValue("s_tsubsystemmid", model.TSubSystemMID);
                        command.Parameters.AddWithValue("s_verified", NpgsqlTypes.NpgsqlDbType.Bit, (object)model.Verified ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
