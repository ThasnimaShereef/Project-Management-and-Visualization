using System.Collections.ObjectModel;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DLL;

namespace TrafikSolMapLibrary.BLL
{
    public class TrafikSolAdminBLL
    {
        TrafikSolAdminDLL RetrieveDLL = new TrafikSolAdminDLL();
        TrafikSolAdminInsertDetailsDLL InsertUpdateDLL = new TrafikSolAdminInsertDetailsDLL();

        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveProjectTypeOC()
        {
            return await Task.Run(() => RetrieveDLL.ProjectType());

        }
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveProjectDetailsOC()
        {
            return await Task.Run(() => RetrieveDLL.ProjectDetails());

        }
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveSubsystemTypeOC()
        {
            return await Task.Run(() => RetrieveDLL.SubsystemType());

        }
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveSubsystemDetailsOC()
        {
            return await Task.Run(() => RetrieveDLL.SubsystemDetails());

        }
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveVendorDetailsOC()
        {
            return await Task.Run(() => RetrieveDLL.VendorDetails());

        }
        public async Task<string> InsertVendorDetailsOC(TrafikSolMapCBE model)
        {
            return await InsertUpdateDLL.InsertTSubsystemVendorDetails(model);

        }
        public async Task<string> UpdateVendorDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.UpdateTSubsystemVendorDetails(model));

        }
        public async Task<string> InsertProjectDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.InsertProjectDetails(model));

        }
        public async Task<string>UpdateProjectDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.UpdateProjectDetails(model));

        }
        public async Task<string> InsertTSubsystemMasterDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.InsertTSubsystemMasterDetails(model));

        }
        public async Task<string> InsertPreviousTSubsystemMasterDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.InsertPreviousTSubsystemMasterDetails(model));

        }
        public async Task<string> UpdateTSubsystemMasterDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.UpdateTSubsystemMasterDetails(model));

        }
        public async Task<string> VerifyTSubsystemMasterDetailsOC(TrafikSolMapCBE model)
        {
            return await Task.Run(() => InsertUpdateDLL.VerifyTSubsystemMasterDetails(model));

        }
    }
}
