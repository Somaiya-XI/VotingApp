using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VotingApp.Areas.Admin.Models;

public class JobModel
{
    [Key]
    [ValidateNever]
    public int jobId { get; set; }
    public string jobName { get; set; }


}
