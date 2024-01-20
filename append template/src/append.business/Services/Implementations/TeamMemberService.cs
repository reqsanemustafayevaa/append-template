using append.business.Exceptions;
using append.business.Extentions;
using append.business.Services.Interfaces;
using append.core.Models;
using append.core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.Services.Implementations
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IWebHostEnvironment _env;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository
                               ,IWebHostEnvironment env )
        {
            _teamMemberRepository = teamMemberRepository;
            _env = env;
        }
        public async Task CreateAsync(TeamMember teamMember)
        {
           if(teamMember == null)
            {
                throw new MemberNotFoundException();
            }
           if(teamMember.ImageFile!=null)
            {
                if(teamMember.ImageFile.ContentType!="image/png" && teamMember.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile","file must be .jpeg or png!");
                }
                if(teamMember.ImageFile.Length>1048576)
                {
                    throw new InvalidImageSizeException("ImageFile","file must be lower than 1mb");
                }
                teamMember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/members");
            }
           teamMember.Createdate= DateTime.UtcNow;
            teamMember.Updatedate= DateTime.UtcNow;
            teamMember.IsDeleted= false;
           await _teamMemberRepository.CreateAsync(teamMember);
           await _teamMemberRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var member = await _teamMemberRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (member == null)
            {
                throw new MemberNotFoundException();
            }
            Helper.DeleteFile(_env.WebRootPath, "uploads/members", member.ImageUrl);
            _teamMemberRepository.Delete(member);
            await _teamMemberRepository.CommitAsync();
        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _teamMemberRepository.GetAllAsync().ToListAsync();
        }

        public  Task<TeamMember> GetByIdAsync(int id)
        {
            var member =  _teamMemberRepository.GetByIdAsync(x => x.Id == id );
            if(member == null)
            {
                throw new MemberNotFoundException();
            }
            return member;
        }

        public async Task UpdateAsync(TeamMember teamMember)
        {
            if(teamMember==null)
            {
                throw new MemberNotFoundException();
            }
            var existmember=await _teamMemberRepository.GetByIdAsync(x=>x.Id == teamMember.Id );
            if (existmember == null)
            {
                throw new MemberNotFoundException();
            }
            if (teamMember.ImageFile != null)
            {
                if (teamMember.ImageFile.ContentType != "image/png" && teamMember.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "file must be .jpeg or png!");
                }
                if (teamMember.ImageFile.Length > 1048576)
                {
                    throw new InvalidImageSizeException("ImageFile", "file must be lower than 1mb");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/members", existmember.ImageUrl);
                existmember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/members");
            }
            existmember.FullName=teamMember.FullName;
            existmember.Profession=teamMember.Profession;
            existmember.Description=teamMember.Description;
            existmember.Updatedate = DateTime.UtcNow;
            existmember.IsDeleted=false;
            await _teamMemberRepository.CommitAsync();


        }
       
    }
}
