using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VotingApp.Areas.Admin.Models;

public class VoteModel
{

    [Key]
    [ValidateNever]
    public int voteId { get; set; }


    [Required(ErrorMessage = "Please enter a subject")]
    public string votingSubject { get; set; }


    [Required(ErrorMessage = "Please enter a question")]
    public string votingQuestion { get; set; }

    public List<VoteOptionModel> voteOptions { get; set; } = new List<VoteOptionModel>();

}
