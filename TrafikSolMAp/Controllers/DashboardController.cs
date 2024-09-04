using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Data;

namespace TrafikSolMap.Controllers
{
    public class DashboardController : Controller
    {
       // TrafikViewVidsTransactionBLL TrafikViewVIDS1 = new TrafikViewVidsTransactionBLL();
        public IActionResult DashboardView()
        {

            //var vidstopfivecol = await TrafikViewVIDS1.RetreiveVIDSDetailsOC(null, null, 5);
            return View();
        }

        //public async Task<ObservableCollection<TrafikViewVidsTransactionCBE>> RetreiveVIDSDetailsOC(DateTime? dtFrom = null, DateTime? dtToDate = null, int ProcessType = 1)
        //{
        //    return await Task.Run(() => TrafikViewVIDS.RetreiveVIDSDetailsOC(dtFrom, dtToDate, ProcessType));
        //}




        //public ObservableCollection<TrafikViewVidsTransactionCBE> RetreiveVIDSReportSummary(DateTime FromDate, DateTime ToDate, int VCID, int AlertID)
        //{
        //    DataTable dt = new DataTable();
        //    ObservableCollection<TrafikViewVidsTransactionCBE> TVVidsTrans = new ObservableCollection<TrafikViewVidsTransactionCBE>();
        //    try
        //    {

        //        //DataTable dsRetreiveERSReport = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(ProcedureName.TrafikView_Retreive_VIDS, TrafikVIEW_Library.DBF.DBConnection.ContectionString());
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@FromDate", FromDate);
        //        da.SelectCommand.Parameters.AddWithValue("@ToDate", ToDate);
        //        da.SelectCommand.Parameters.AddWithValue("@AlertID ", AlertID);
        //        da.SelectCommand.Parameters.AddWithValue("@ProcessType", 2);
        //        da.Fill(dt);
        //        //dt = dt.Tables[0];
        //        TVVidsTrans = ConvertDataTableToCollectionrRptSummary(dt);
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return TVVidsTrans;
        //}

        ///// <summary>
        ///// This method use for convert data into collection
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public ObservableCollection<TrafikViewVidsTransactionCBE> ConvertDataTableToCollectionrRptSummary(DataTable dt)
        //{
        //    ObservableCollection<TrafikViewVidsTransactionCBE> VidsTransactionManagement = new ObservableCollection<TrafikViewVidsTransactionCBE>();
        //    try
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            CBE.TrafikViewVidsTransactionCBE VidsTransactionReport = new CBE.TrafikViewVidsTransactionCBE();

        //            if (dt.Rows[i]["GrandTotal"] != DBNull.Value)
        //                VidsTransactionReport.GrandTotal = Convert.ToInt32(dt.Rows[i]["GrandTotal"].ToString());

        //            if (dt.Rows[i]["Details"] != DBNull.Value)
        //                VidsTransactionReport.Details = Convert.ToString(dt.Rows[i]["Details"].ToString());

        //            if (dt.Rows[i]["OVERSPEEDING"] != DBNull.Value)
        //                VidsTransactionReport.OVERSPEEDING = Convert.ToInt32(dt.Rows[i]["OVERSPEEDING"].ToString());

        //            if (dt.Rows[i]["SPEED_DROP"] != DBNull.Value)
        //                VidsTransactionReport.SPEED_DROP = Convert.ToInt32(dt.Rows[i]["SPEED_DROP"].ToString());

        //            if (dt.Rows[i]["CAMERA_TAMPERING"] != DBNull.Value)
        //                VidsTransactionReport.CAMERA_TAMPERING = Convert.ToInt32(dt.Rows[i]["CAMERA_TAMPERING"].ToString());

        //            if (dt.Rows[i]["CONGESTION_DETECTION"] != DBNull.Value)
        //                VidsTransactionReport.CONGESTION_DETECTION = Convert.ToInt32(dt.Rows[i]["CONGESTION_DETECTION"].ToString());

        //            if (dt.Rows[i]["ILLEGAL_PARKING"] != DBNull.Value)
        //                VidsTransactionReport.ILLEGAL_PARKING = Convert.ToInt32(dt.Rows[i]["ILLEGAL_PARKING"].ToString());

        //            if (dt.Rows[i]["TRIPWIRE"] != DBNull.Value)
        //                VidsTransactionReport.TRIPWIRE = Convert.ToInt32(dt.Rows[i]["TRIPWIRE"].ToString());

        //            if (dt.Rows[i]["WRONGWAY_DETECTION"] != DBNull.Value)
        //                VidsTransactionReport.WRONGWAY_DETECTION = Convert.ToInt32(dt.Rows[i]["WRONGWAY_DETECTION"].ToString());

        //            if (dt.Rows[i]["FOG_DETECT"] != DBNull.Value)
        //                VidsTransactionReport.FOG_DETECT = Convert.ToInt32(dt.Rows[i]["FOG_DETECT"].ToString());

        //            if (dt.Rows[i]["Other"] != DBNull.Value)
        //                VidsTransactionReport.Other = Convert.ToInt32(dt.Rows[i]["Other"].ToString());

        //            VidsTransactionManagement.Add(VidsTransactionReport);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return VidsTransactionManagement;
        //}

    }
}
