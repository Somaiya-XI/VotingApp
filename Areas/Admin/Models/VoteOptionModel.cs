using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VotingApp.Areas.Admin.Models;

public class VoteOptionModel
{

    [Key]
    [ValidateNever]
    public int optionId { get; set; }

    [Required(ErrorMessage = "Option is required, please enter a value.")]
    public string optionName { get; set; }

    [ValidateNever]
    public int voteId { get; set; }
    [ValidateNever]
    public VoteModel voteObj { get; set; } = new VoteModel();
    [ValidateNever]
    public List<VoteResultModel> lstResults { get; set; } = new List<VoteResultModel>();
}
