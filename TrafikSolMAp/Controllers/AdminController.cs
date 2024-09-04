using Microsoft.AspNetCore.Mvc;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.BLL;
using Microsoft.CodeAnalysis;
using TrafikSolMapLibrary.DLL;
using AspNetCore.Reporting;

namespace TrafikSolMAP.Controllers
{
    public class AdminController : Controller

    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        TrafikSolAdminBLL TrafikSolDetails = new TrafikSolAdminBLL();
        TrafikSolAdminDLL TrafikSolFilter = new TrafikSolAdminDLL();
        TrafikSolMapDLL TrafikSolSubsystem = new TrafikSolMapDLL();
        TrafikSolMapBLL TrafikSolSubsystemDetails = new TrafikSolMapBLL();

        //project
        public async Task<IActionResult> Project(TrafikSolMapCBE model)
        {
            
            model.ProjectTypeCollection = await TrafikSolDetails.RetreiveProjectTypeOC();
            model.ProjectDetailsCollection = await TrafikSolDetails.RetreiveProjectDetailsOC();
            return View(model);
        }
        public JsonResult TrafikSolEditProject(int ProjectID, TrafikSolMapCBE model)
        {
            var projectDetails =  TrafikSolFilter.ProjectDetails()
               .Where(p => p.ProjectID == ProjectID).ToList();

            return Json(projectDetails);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateProjectDetails(TrafikSolMapCBE model)
        {
            if (model.ProjectID == 0)
            {
              await TrafikSolDetails.InsertProjectDetailsOC(model);
            }
            else
            {
               await TrafikSolDetails.UpdateProjectDetailsOC(model);
            }
            return RedirectToAction("Project");
        }
        
        public JsonResult SelectProjectName(int projectTypeId, TrafikSolMapCBE model)
        {
            var projectDetails = TrafikSolFilter.ProjectDetails()
              .Where(p => p.ProjectTypeID == projectTypeId)
                .ToList();

            return Json(projectDetails);
        }
        public async Task<IActionResult> ProjectReportDownload(TrafikSolMapCBE model)
        {
            try
            {
                model.ProjectDetailsCollection = await TrafikSolDetails.RetreiveProjectDetailsOC();
                string mintype = "";
                int extension = 1;
                var fileName = "projectpdf.rdlc";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Report", fileName);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("ProjectDataSet", model.ProjectDetailsCollection);
                var result = localReport.Execute(RenderType.Pdf, extension, null, mintype);
                return File(result.MainStream, "application/pdf", "ProjectDetails.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while generating the project report.");
            }
        }
        //vendor
        public async Task<IActionResult> Vendor(TrafikSolMapCBE model)
        {
            model.SubsystemDetailsCollection = await TrafikSolDetails.RetreiveSubsystemDetailsOC();
            model.TSubsystemVendorCollection = await TrafikSolDetails.RetreiveVendorDetailsOC();
            return View(model);
        }
        public JsonResult TrafikSolEditVendor(int VID, TrafikSolMapCBE model)
        {
            var vendorDetails = TrafikSolFilter.VendorDetails()
                 .Where(p => p.VID == VID)
                .ToList();

            return Json(vendorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateVendorDetails(TrafikSolMapCBE model)
        {
            if (model.VID == 0)
            {
                await TrafikSolDetails.InsertVendorDetailsOC(model);
            }
            else
            {
                await TrafikSolDetails.UpdateVendorDetailsOC(model);
            }
            return RedirectToAction("Vendor");
        }
        public JsonResult SelectVendorName(int subSysID, TrafikSolMapCBE model)
        {
            var vendorDetails = TrafikSolFilter.VendorDetails()
                .Where(p => p.SubSysID == subSysID)
                .ToList();

            return Json(vendorDetails);
        }
        public async Task<IActionResult> VendorReportDownload(TrafikSolMapCBE model)
        {
            try
            {
                model.TSubsystemVendorCollection = await TrafikSolDetails.RetreiveVendorDetailsOC();
                string mintype = "";
                int extension = 1;
                var fileName = "VendorDetails.rdlc";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Report", fileName);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("VendorDataSet", model.TSubsystemVendorCollection);
                var result = localReport.Execute(RenderType.Pdf, extension, null, mintype);
                return File(result.MainStream, "application/pdf", "VendorDetails.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while generating the project report.");
            }
        }
        //subsystem
        public async Task<IActionResult> Subsystem(TrafikSolMapCBE model)
        {
            model.ProjectTypeCollection = await TrafikSolDetails.RetreiveProjectTypeOC();
            model.ProjectDetailsCollection = await TrafikSolDetails.RetreiveProjectDetailsOC();
            model.SubsystemTypeCollection = await TrafikSolDetails.RetreiveSubsystemTypeOC();
            model.SubsystemDetailsCollection = await TrafikSolDetails.RetreiveSubsystemDetailsOC();
            model.TSubsystemVendorCollection = await TrafikSolDetails.RetreiveVendorDetailsOC();
            model.TSubSystemMasterDetailsBECollection = await TrafikSolSubsystemDetails.RetreiveTSubSystemMasterDetailsOC();
            return View(model);
        }
        public JsonResult TrafikSolEditSubsystem(int TSubSystemMID, TrafikSolMapCBE model)
        {
            var subsystemDetails = TrafikSolSubsystem.RetrieveTSubsystemMasterDetails()
                .Where(p => p.TSubSystemMID == TSubSystemMID)
                .ToList();

            return Json(subsystemDetails);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateSubsystemDetails(TrafikSolMapCBE model)
        {
            await TrafikSolDetails.InsertPreviousTSubsystemMasterDetailsOC(model);

            if (model.TSubSystemMID == 0)
            {
                await TrafikSolDetails.InsertTSubsystemMasterDetailsOC(model);
            }
            else
            {
                await TrafikSolDetails.UpdateTSubsystemMasterDetailsOC(model);
            }
            return RedirectToAction("Subsystem");
        }

        public JsonResult SelectSubsystemName(int subSystemTypeId, TrafikSolMapCBE model)
        {
            var subsystemDetails = TrafikSolFilter.SubsystemDetails()
               .Where(p => p.SystemID == subSystemTypeId)
                .ToList();

            return Json(subsystemDetails);
        }
        public async Task<IActionResult> SubsystemReportDownload(TrafikSolMapCBE model)
        {
            try
            {
                model.TSubSystemMasterDetailsBECollection = await TrafikSolSubsystemDetails.RetreiveTSubSystemMasterDetailsOC();
                string mintype = "";
                int extension = 1;
                var fileName = "SubsystemDetails.rdlc";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Report", fileName);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("SubsystemDataSet", model.TSubSystemMasterDetailsBECollection);
                var result = localReport.Execute(RenderType.Pdf, extension, null, mintype);
                return File(result.MainStream, "application/pdf", "SubsystemDetails.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while generating the project report.");
            }
        }
        //verification
        public async Task<IActionResult> Verification(TrafikSolMapCBE model)
        {
            model.ProjectTypeCollection = await TrafikSolDetails.RetreiveProjectTypeOC();
            model.ProjectDetailsCollection = await TrafikSolDetails.RetreiveProjectDetailsOC();
            model.SubsystemTypeCollection = await TrafikSolDetails.RetreiveSubsystemTypeOC();
            model.SubsystemDetailsCollection = await TrafikSolDetails.RetreiveSubsystemDetailsOC();
            model.TSubsystemVendorCollection = await TrafikSolDetails.RetreiveVendorDetailsOC();
            model.TSubSystemMasterDetailsBECollection = await TrafikSolSubsystemDetails.RetreiveTSubSystemMasterDetailsOC();
            return View(model);
        }
        public async Task<IActionResult> VerifyTSubSystemMasterDetails(TrafikSolMapCBE model)
        {
            await TrafikSolDetails.VerifyTSubsystemMasterDetailsOC(model);
            return RedirectToAction("Verification");
        }
        public async Task<IActionResult> VerificationReportDownload(TrafikSolMapCBE model)
        {
            try
            {
                model.TSubSystemMasterDetailsBECollection = await TrafikSolSubsystemDetails.RetreiveTSubSystemMasterDetailsOC();
                string mintype = "";
                int extension = 1;
                var fileName = "VerificationDetails.rdlc";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Report", fileName);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("SubsystemDataSet", model.TSubSystemMasterDetailsBECollection);
                var result = localReport.Execute(RenderType.Pdf, extension, null, mintype);
                return File(result.MainStream, "application/pdf", "VerificationDetails.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while generating the project report.");
            }
        }
    }
}
