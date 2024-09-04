using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Collections.ObjectModel;
using TrafikSolMapLibrary.BLL;
using TrafikSolMapLibrary.CBE;


namespace TrafikSolMAP.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        TrafikSolAdminBLL TrafikSolDetails = new TrafikSolAdminBLL();
        TrafikSolReportBLL TrafikSolReportDetails = new TrafikSolReportBLL();
        public async Task<IActionResult> ProjectReport(TrafikSolMapCBE model)
        {
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            model.ProjectTypeCollection = await TrafikSolDetails.RetreiveProjectTypeOC();
            model.ProjectDetailsCollection = await TrafikSolDetails.RetreiveProjectDetailsOC();
            model.SubsystemTypeCollection = await TrafikSolDetails.RetreiveSubsystemTypeOC();
            model.SubsystemDetailsCollection = await TrafikSolDetails.RetreiveSubsystemDetailsOC();
            return View(model);
        }
        public async Task<IActionResult> ProjectReportgenerate(List<int> projectIds, List<int> subsystemIds, TrafikSolMapCBE model)
        {
            try
            {
                var StartDate = model.StartDate;
                var EndDate = model.EndDate;
                var ProjectReportCollection = await TrafikSolReportDetails.RetreiveProjectDetailsOC(Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));

                List<TrafikSolMapCBE> filteredCollection;

                if ((projectIds == null || projectIds.Count == 0) && (subsystemIds == null || subsystemIds.Count == 0))
                {
                    filteredCollection = ProjectReportCollection.ToList();
                }
                else
                {
                    filteredCollection = ProjectReportCollection
                        .Where(p => projectIds.Contains(p.ProjectID) && subsystemIds.Contains(p.SubSysID))
                        .ToList();
                }

                // Adding serial number
                for (int i = 0; i < filteredCollection.Count; i++)
                {
                    filteredCollection[i].SrNo = i + 1;
                }

                model.ProjectReportCollection = new System.Collections.ObjectModel.ObservableCollection<TrafikSolMapCBE>(filteredCollection);

                string mintype = "";
                int extension = 1;
                var fileName = "projectdetails.rdlc";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Report", fileName);
                LocalReport localReport = new LocalReport(path);

                Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            { "ProjectName", "Mupa" }
        };

                localReport.AddDataSource("DataSet1", model.ProjectReportCollection);
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mintype);
                return File(result.MainStream, "application/pdf");
        //        var StartDate = model.StartDate;
        //        var EndDate = model.EndDate;
        //        var ProjectReportCollection = await TrafikSolReportDetails.RetreiveProjectDetailsOC(Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));
        //        if (projectIds == null && subsystemIds == null)
        //        {
        //            model.ProjectReportCollection = ProjectReportCollection;
        //        }
        //        else
        //        {
        //            var filtercoll = ProjectReportCollection
        //            .Where(p => projectIds.Contains(p.ProjectID) && subsystemIds.Contains(p.SubSysID))
        //            .ToList();
        //            model.ProjectReportCollection = new System.Collections.ObjectModel.ObservableCollection<TrafikSolMapCBE>(filtercoll);
        //        }
        //        string mintype = "";
        //        int extension = 1;
        //        var fileName = "projectdetails.rdlc";
        //        var path = Path.Combine(_webHostEnvironment.WebRootPath, "Report", fileName);
        //        LocalReport localReport = new LocalReport(path);
        //        Dictionary<string, string> parameters = new Dictionary<string, string> {
        //    { "ProjectName", "Mupa" }
        //};
        //        //var data = "Mupa";
        //        //parameters.Add("ProjectName", data);
        //        localReport.AddDataSource("DataSet1", model.ProjectReportCollection);
        //        var result = localReport.Execute(RenderType.Pdf, extension, parameters, mintype);
        //        return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error while generating the project report.");
            }
        }
       
    }
}



//#region   AnprReport

//public IActionResult AnprReport(ANPRDetailsBE model)
//{
//    model.startDate = DateTime.Now.Date;
//    model.EndDate = DateTime.Now;
//    return View(model);
//}
//public IActionResult AnprReportgenrate(ANPRDetailsBE model)
//{
//    try
//    {
//        var StartDate = model.startDate;
//        var EndDate = model.EndDate;
//        AnprCollection = AnprBLL.RetreiveANPRDetails(Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate));
//        string mimtype = "";
//        int extension = 1;
//        var fileName = "AnprDetailsReort.rdlc";
//        var path = Path.Combine(_webHostEnvironment.WebRootPath, "RDLCReporting", fileName);
//        LocalReport localReport = new LocalReport(path);
//        var Rdata = GlobalObservationVar.trafikHeaderFooterReportBE.ToList();
//        Dictionary<string, string> parameters = new Dictionary<string, string>();
//        string CpmLogo = _webHostEnvironment.WebRootPath + @"/" + Rdata[0].CompanyLogo.ToString();
//        string NhiLogo = _webHostEnvironment.WebRootPath + @"/" + Rdata[0].Nhailogo.ToString();
//        var Clogo = System.IO.File.ReadAllBytes(CpmLogo);
//        var Nlogo = System.IO.File.ReadAllBytes(NhiLogo);
//        var logoBase64 = Convert.ToBase64String(Clogo);
//        var logoBase641 = Convert.ToBase64String(Nlogo);
//        parameters.Add("Sdate", model.startDate.ToString("dd-MM-yyyy:hh:m:s"));
//        parameters.Add("Edate", model.EndDate.ToString("dd-MM-yyyy:hh:m:s"));
//        parameters.Add("logo", logoBase64);
//        parameters.Add("logo1", logoBase641);
//        parameters.Add("CompanyName", Rdata[0].CompanyName);
//        parameters.Add("AboutComp", Rdata[0].AboutCompany);
//        parameters.Add("BillingPhNo", Rdata[0].BillingPhoneNo);
//        parameters.Add("OfficeAdd", Rdata[0].OfficeAddress);
//        parameters.Add("PrintedBy", ConfigurationData.UserID);
//        parameters.Add("PrintedDate", DateTime.Now.ToString("yyyy-MM-dd"));
//        localReport.AddDataSource("DataSet1", AnprCollection);
//        var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//        return File(result.MainStream, "application/pdf");
//    }
//    catch
//    {
//        return View("../Shared/Error");

//    }
//}

//#endregion