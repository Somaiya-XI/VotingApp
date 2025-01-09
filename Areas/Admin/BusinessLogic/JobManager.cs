using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Areas.Admin.Models;
using VotingApp.Data;

namespace VotingApp.Areas.Admin.BusinessLogic
{
    public class JobManager
    {
        // GetAllJobs
        //GetJobById
        //CreateJob
        //UpdateJob
        //DeleteJob
        public List<JobModel> GetAll()
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                return context.tbJobs.ToList();
            }
            catch { return new List<JobModel>(); }
        }
        public JobModel GetById(int id)
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                return context.tbJobs.FirstOrDefault(e => e.jobId == id);
            }
            catch { return new JobModel(); }
        }
        public bool Save(JobModel job)
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                if (job.jobId == 0)
                {
                    context.tbJobs.Add(job);
                }
                else
                {
                    context.Entry(job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Delete(int id)
        {
            try
            {
                var job = GetById(id);
                VotingAppContext context = new VotingAppContext();
                context.tbJobs.Remove(job);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
