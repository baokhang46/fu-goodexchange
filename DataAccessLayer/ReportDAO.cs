using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ReportDAO
    {
        public static Report GetReportById(int reportId)
        {
            using var db = new FugoodExchangeContext();
            return db.Reports
                     .Include(r => r.Buyer)
                     .Include(r => r.Seller)
                     .FirstOrDefault(r => r.ReportId == reportId);
        }

        public static List<Report> GetAllReports()
        {
            try
            {
                using var db = new FugoodExchangeContext();
                return db.Reports
                         .Include(r => r.Buyer)
                         .Include(r => r.Seller)
                         .ToList();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while retrieving reports.", e);
            }
        }

        public static void CreateReport(Report report)
        {
            try
            {
                using var context = new FugoodExchangeContext();
                context.Reports.Add(report);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while creating the report.", e);
            }
        }

        public static void UpdateReport(Report report)
        {
            try
            {
                using var context = new FugoodExchangeContext();
                context.Entry(report).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while updating the report.", e);
            }
        }

        public static void DeactivateReport(int reportId)
        {
            try
            {
                using var context = new FugoodExchangeContext();
                var report = context.Reports.SingleOrDefault(r => r.ReportId == reportId);
                if (report != null)
                {
                    report.Status = "Inactive";
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while deactivating the report.", e);
            }
        }

        public static void ActivateReport(int reportId)
        {
            try
            {
                using var context = new FugoodExchangeContext();
                var report = context.Reports.SingleOrDefault(r => r.ReportId == reportId);
                if (report != null)
                {
                    report.Status = "Active";
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while activating the report.", e);
            }
        }
    }
}
