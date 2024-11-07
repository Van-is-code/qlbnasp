using Microsoft.AspNetCore.Mvc;
using Asp.Net_MvcWeb_Pj3.Aptech.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Asp.Net_MvcWeb_Pj3.Aptech.Controllers
{
    public class AdminPatientController : Controller
    {
        private readonly DataContext _context;

        public AdminPatientController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var patients = _context.Patients.Include(p => p.Publisher).ToList();
            return View("PatientIndex", patients);
        }

        [HttpGet]
        [Route("/admin/Patient/index")]
        public IActionResult PatientIndex()
        {
            var patients = _context.Patients.Include(p => p.Publisher).ToList();
            return View("PatientIndex", patients);
        }

        [HttpGet]
        [Route("/admin/Patient/add")]
        public IActionResult PatientAdd()
        {
            ViewData["publisherList"] = _context.Publishers.ToList();
            return View();
        }

        [HttpPost]
        [Route("/admin/Patient/add")]
        public IActionResult PatientAdd(Patient patient)
        {
            // Debug gỡ lỗi trên màn hình Terminal để biết vì sao nó lỗi Status: lúc nào cũng là true
            WriteLine("Patient status: " + patient.Status.ToString());
            WriteLine("Patient status input: " + HttpContext.Request.Form["Status"]);

            // Nếu người dùng nhấp chuột vào checkbox Status thì có nghĩa là sách mới
            if (this.Request.Form["Status"].Equals("1"))
                patient.Status = 1;
            else // ngược lại thì là sách cũ
                patient.Status = 0;

            // Lưu bệnh nhân vào cơ sở dữ liệu
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return RedirectToAction("PatientIndex");
        }

        [HttpGet]
        [Route("/admin/Patient/list")]
        public IActionResult PatientList()
        {
            // Nếu danh tính chưa có
            // thì điều hướng sang trang User Login
            // if(HttpContext.Session.GetInt32("User_Id") == null)
            // {
            //     // todo: Lưu lại url ngay trước khi bị điều hướng sang trang đăng nhập
            //     // để sau khi Login xong, thì quay lại trang đó.
            //     return RedirectToAction("UserLogin");
            // }

            // Gửi các quyển sách sang bên View HTML
            // ViewData["PatientList"] = context.Patient.ToList();
            ViewData["PatientList"] = _context.Patients.Include(Patient => Patient.Publisher).ToList();

            return View();
        }

        [HttpGet]
        [Route("/admin/Patient/edit")]
        public IActionResult PatientEdit(int id)
        {
            ViewData["publisherList"] = _context.Publishers.ToList();
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [Route("/admin/Patient/edit")]
        public IActionResult PatientEdit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Update(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["publisherList"] = _context.Publishers.ToList();
            return View(patient);
        }

        //http://localhost:5017/Patient/delete?id=2
        // Xác nhận có chắc muốn xóa
        [HttpGet]
        [Route("/admin/Patient/delete")]
        public IActionResult PatientDelete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [Route("/admin/Patient/delete")]
        public IActionResult PatientDeleteConfirmed(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}