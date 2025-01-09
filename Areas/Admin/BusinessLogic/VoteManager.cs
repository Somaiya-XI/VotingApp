using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Areas.Admin.Models;

using VotingApp.Data;

namespace VotingApp.Areas.Admin.BusinessLogic
{
    public class VoteManager
    {
        public List<VoteModel> GetAll()
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                return context.tbVotes.ToList();
            }
            catch { return new List<VoteModel>(); }
        }
        public VoteModel GetById(int id)
        {
            try
            {
                VotingAppContext context = new VotingAppContext();
                return context.tbVotes.FirstOrDefault(e => e.voteId == id);
            }
            catch { return new VoteModel(); }
        }

        public bool Save(VoteModel vote)
        {
            try
            {
                using (VotingAppContext context = new VotingAppContext())
                {
                    // Handle new vote
                    if (vote.voteId == 0)
                    {
                        // Add the Vote to the context
                        context.tbVotes.Add(vote);
                    }
                    else
                    {
                        // Update existing vote
                        context.Entry(vote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    // Save changes to the database
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving vote: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var vote = GetById(id);
                VotingAppContext context = new VotingAppContext();
                context.tbVotes.Remove(vote);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}

