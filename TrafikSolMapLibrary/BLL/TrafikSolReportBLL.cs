using TrafikSolMapLibrary.DLL;
using TrafikSolMapLibrary.CBE;
using System.Collections.ObjectModel;

namespace TrafikSolMapLibrary.BLL
{
    public class TrafikSolReportBLL
    {

        TrafikSolReportDLL RetrieveDLL = new TrafikSolReportDLL();
        public async Task<ObservableCollection<TrafikSolMapCBE>> RetreiveProjectDetailsOC(DateTime startDate, DateTime endDate)
        {
            return await Task.Run(() => RetrieveDLL.RetrieveProjectDetailsReport(startDate, endDate));

        }
    }
}
