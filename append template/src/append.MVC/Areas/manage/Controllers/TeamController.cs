using append.business.Exceptions;
using append.business.Services.Interfaces;
using append.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace append.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }
        public async Task<IActionResult> Index()
        {
            var members=await _teamMemberService.GetAllAsync();
            return View(members);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if(!ModelState.IsValid)
            {
                return View(teamMember);
            }
            try
            {
                await _teamMemberService.CreateAsync(teamMember);
            }
            catch (MemberNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(teamMember);
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(teamMember);
            }
            catch(InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(teamMember);
            }
            
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var existmember=await _teamMemberService.GetByIdAsync(id);
            if (existmember == null)
            {
                return View("Error");
            }
            return View(existmember);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View(teamMember);
            }
            try
            {
                await _teamMemberService.UpdateAsync(teamMember);
            }
            catch (MemberNotFoundException ex)
            {
                return View("Error");
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(teamMember);
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(teamMember);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var existmember = await _teamMemberService.GetByIdAsync(id);
            if(existmember == null)
            {
                return View("Error");
            }
            return View(existmember);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TeamMember teamMember)
        {
           
            try
            {
                await _teamMemberService.Delete(teamMember.Id);
            }
            catch (MemberNotFoundException ex)
            {
                return View("Error");
            }
            catch(Exception )
            {
                throw;
            }

            return RedirectToAction("index");
        }
    }
}
