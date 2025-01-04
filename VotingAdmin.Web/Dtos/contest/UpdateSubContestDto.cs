using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Build.Framework;
using System;
using VotingAdmin.Web.Models.Contest;

namespace VotingAdmin.Web.Dtos.contest
{
    public class UpdateSubContestDto
    {
        [Required]
        public long ContestId { get; set; }
        [Required]
        public long SubContestId { get; set; }
        [Required]
        public string SubContestName { get; set; }
        public string SubContestDesc { get; set; }
        public IFormFile BannerImg { get; set; }
        public string BannerImgPath { get; set; }
        public bool IsActive { get; set; }
    }
}
