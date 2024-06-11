using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReportRepository : IReportRepository
    {
        public void ActivateReport(int reportId)
            => ReportDAO.ActivateReport(reportId);

        public void CreateReport(Report report)
            => ReportDAO.CreateReport(report);

        public void DeactivateReport(int reportId)
            => ReportDAO.DeactivateReport(reportId);
        

        public List<Report> GetAllReports()
            => ReportDAO.GetAllReports();
       

        public Report GetReportById(int reportId)
            => ReportDAO.GetReportById(reportId);
       

        public void UpdateReport(Report report)
            => ReportDAO.UpdateReport(report);
       
    }
}
