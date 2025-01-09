using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Areas.Admin.Models;
using VotingApp.Data;

namespace VotingApp.Areas.Admin.BusinessLogic
{
    public class VoteOptionManager
    {
        public List<VoteOptionModel> GetAll()
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                return context.tbVoteOptions.ToList();
            }
            catch { return new List<VoteOptionModel>(); }
        }

        public VoteOptionModel GetById(int id)
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                return context.tbVoteOptions.FirstOrDefault(e => e.optionId == id);
            }
            catch { return new VoteOptionModel(); }
        }

        public bool Save(VoteOptionModel option)
        {
            try
            {

                using (VotingAppContext context = new VotingAppContext())
                {
                    if (option.optionId == 0)
                    {
                        context.tbVoteOptions.Add(option);
                    }
                    else
                    {
                        context.Entry(option).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving vote options: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var option = GetById(id);
                VotingAppContext context = new VotingAppContext();
                context.tbVoteOptions.Remove(option);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}