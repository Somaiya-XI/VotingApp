using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VotingApp.Areas.Admin.Models;

public class VoteResultModel
{
    [Key]
    [ValidateNever]
    public int resultId { get; set; }
    public int optionId { get; set; }
    public int jobId { get; set; }
    public JobModel jobObj { get; set; } = new JobModel();
    public VoteOptionModel optionObj { get; set; } = new VoteOptionModel();
}