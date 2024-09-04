using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafikSolMapLibrary.CBE;
using TrafikSolMapLibrary.DLL;

namespace TrafikSolMapLibrary.BLL
{
    public class TrafikSolMapBLL
    {
        TrafikSolMapDLL RetrieveDLL = new TrafikSolMapDLL();
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveTSubSystemMasterDetailsOC()
        {
            return await Task.Run(() => RetrieveDLL.RetrieveTSubsystemMasterDetails());
           
        }
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveTPositionMasterDetailsOC()
        {
            return await Task.Run(() => RetrieveDLL.RetrieveTPositionMasterDetails());

        }
    }
}
