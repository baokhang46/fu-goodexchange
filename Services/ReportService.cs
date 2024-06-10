using BussinessObject.Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService()
        {
            _reportRepository = new ReportRepository();
        }

        public void ActivateReport(int reportId)
        {
           _reportRepository.ActivateReport(reportId);
        }

        public void CreateReport(Report report)
        {
            _reportRepository.CreateReport(report);
        }

        public void DeactivateReport(int reportId)
        {
           _reportRepository.DeactivateReport(reportId);
        }

        public List<Report> GetAllReports()
        {
            return _reportRepository.GetAllReports();
        }

        public Report GetReportById(int reportId)
        {
          return  _reportRepository.GetReportById(reportId);
        }

        public void UpdateReport(Report report)
        {
           _reportRepository.UpdateReport(report);
        }
    }
}
