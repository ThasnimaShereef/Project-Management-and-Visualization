using Microsoft.AspNetCore.Mvc;
using TrafikSolMapLibrary.BLL;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DLL;

namespace TrafikSolMAP.Controllers
{
  
    public class MapController : Controller
    {
        TrafikSolMapBLL TrafikSolSubsystemDetails = new TrafikSolMapBLL();
        TrafikSolAdminBLL TrafikSolDetails = new TrafikSolAdminBLL();
        TrafikSolAdminDLL TrafikSolFilter = new TrafikSolAdminDLL();
        TrafikSolMapDLL TrafikSolMapDetails = new TrafikSolMapDLL();


        public async Task<IActionResult> Index(TrafikSolMapCBE model)
         {
            model.TSubSystemMasterDetailsBECollection =  await TrafikSolSubsystemDetails.RetreiveTSubSystemMasterDetailsOC();
            model.TPositionMasterCollection = await TrafikSolSubsystemDetails.RetreiveTPositionMasterDetailsOC();
            model.ProjectTypeCollection = await TrafikSolDetails.RetreiveProjectTypeOC();
            model.SubsystemTypeCollection = await TrafikSolDetails.RetreiveSubsystemTypeOC();
            return View(model);
        }

        public JsonResult ProjectDetailsDropdown(List<int> projectTypeIds, TrafikSolMapCBE model)
        {
            var projectDetails = TrafikSolFilter.ProjectDetails()
                .Where(p => projectTypeIds.Contains(p.ProjectTypeID))
                .ToList();

            return Json(projectDetails);
        }

        public JsonResult SubsystemDetailsDropdown(List<int> subSystemTypeIds, TrafikSolMapCBE model)
        {
           
            var subsystemDetails = TrafikSolFilter.SubsystemDetails()
                .Where(p => subSystemTypeIds.Contains(p.SystemID))
                .ToList();

            return Json(subsystemDetails);
        }
        public JsonResult SelectedTSubsystemMasterDetails(List<int> projectIds, List<int> subsystemIds)
        {
            var filteredProjects = TrafikSolMapDetails.RetrieveTSubsystemMasterDetails()
                .Where(p => projectIds.Contains(p.ProjectID) && subsystemIds.Contains(p.SubSysID))
                .ToList();

            return Json(filteredProjects);
        }
        public JsonResult SelectedTPositionMasterDetails(List<int> projectIds)
        {
            var filteredRoute = TrafikSolMapDetails.RetrieveTPositionMasterDetails()
                .Where(p => projectIds.Contains(p.ProjectID))
                .ToList();

            return Json(filteredRoute);
        }
    }
}
