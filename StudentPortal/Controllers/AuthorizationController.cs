using Entities.AuthenticationModels;
using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.StudentModels;
using Entities.DBModels.UserModels;
using StudentPortal.Models;
using System.Diagnostics;
using static StudentPortal.Models.PortalEnum;

namespace StudentPortal.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationManager _authManager;

        public AuthorizationController(
                IMapper mapper,
                IUnitOfWork unitOfWork,
                IAuthenticationManager authManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authManager = authManager;
        }

        public async Task<IActionResult> Login()
        {
            try
            {
                string refreshToken = Request.Cookies[HeadersConstants.SetRefresh];

                if (!string.IsNullOrWhiteSpace(refreshToken))
                {
                    UserAuthenticatedDto auth = await _authManager.Authenticate(refreshToken, IpAddress());

                    RemoveCookies();

                    SetToken(auth.Token);
                    SetRefresh(auth.RefreshToken);

                    return Request.Headers.Referer.Any()
                        ? Redirect(Request.Headers.Referer)
                        : RedirectToAction("Success", new { success = SuccessEnum.Login });
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            RemoveCookies();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserForAuthenticationDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                UserAuthenticatedDto auth = await _authManager.Authenticate(model, IpAddress());

                RemoveCookies();

                SetToken(auth.Token);
                SetRefresh(auth.RefreshToken);

                return RedirectToAction("Success", new { success = SuccessEnum.Login });
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            return View(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(StudentCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                User user = _mapper.Map<User>(model);
                user.Student = _mapper.Map<Student>(model);

                await _unitOfWork.User.CreateUser(user);
                await _unitOfWork.Save();

                UserAuthenticatedDto auth = await _authManager.Authenticate(new UserForAuthenticationDto
                {
                    UserName = model.UserName,
                    Password = model.Password,
                }, IpAddress());

                RemoveCookies();

                SetToken(auth.Token);
                SetRefresh(auth.RefreshToken);

                return RedirectToAction("Success", new { success = SuccessEnum.Signup });
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            return View(model);
        }

        [Authorize]
        public IActionResult EditProfile()
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[HeadersConstants.User];

            StudentModel student = _unitOfWork.Student.GetStudentById(auth.Fk_Student);

            return View(_mapper.Map<StudentEditModel>(student));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(StudentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[HeadersConstants.User];

                User user = await _unitOfWork.User.FindById(auth.Id, trackChanges: true);
                Student student = await _unitOfWork.Student.FindStudentbyId(auth.Fk_Student, trackChanges: true);

                _ = _mapper.Map(model, user);
                _ = _mapper.Map(model, student);

                await _unitOfWork.Save();

                return RedirectToAction("Success", new { success = SuccessEnum.EditProfile });
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            return View(model);
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[HeadersConstants.User];

                await _unitOfWork.User.ChangePassword(auth.Id, model);
                await _unitOfWork.Save();

                return RedirectToAction("Success", new { success = SuccessEnum.ChangePassword });
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Success(SuccessEnum success)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[HeadersConstants.User];

            ViewData["FullName"] = auth.FullName;

            return View(success);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            try
            {
                string refresh = Request.Cookies[HeadersConstants.SetRefresh];

                if (!string.IsNullOrWhiteSpace(refresh))
                {
                    await _authManager.RevokeToken(refresh, IpAddress());
                }

                RemoveCookies();
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            return RedirectToAction(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Helper Methods
        private void SetToken(TokenResponse response)
        {
            CookieOptions option = new()
            {
                Expires = response.Expires,
            };
            Response.Cookies.Append(HeadersConstants.AuthorizationToken, response.RefreshToken, option);
        }

        private void SetRefresh(TokenResponse response)
        {
            CookieOptions option = new()
            {
                Expires = response.Expires,
            };
            Response.Cookies.Append(HeadersConstants.SetRefresh, response.RefreshToken, option);
        }

        private void RemoveCookies()
        {
            foreach (string cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
        }

        private string IpAddress()
        {
            // get source ip address for the current request
            return Request.Headers.ContainsKey("x-Forwarded-For")
                ? (string)Request.Headers["x-Forwarded-For"]
                : HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}