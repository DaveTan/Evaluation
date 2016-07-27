using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluation.WebMVC.Models;
using Newtonsoft.Json;

namespace Evaluation.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        //************************RECORD VIEW PAGE*****************************
        public ActionResult RecordForm(){
            return View();
        }
        public ActionResult RecordView(int Id)
        {
            Session["EvalId"] = Id;
            if (Session["Year"] == null)
            {
                Session["Year"] = DateTime.Now.Year;
            }
            return RedirectToAction("RecordForm");
        }
        // GET: Home
        //************************EVALUATION FORM PAGE**************************
        public JsonResult SearchCoreCompetency2(int Id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_getForm(Id, Convert.ToInt32(Session["Year"]), Convert.ToInt32(Session["Quarter"]), Convert.ToInt32(Session["EvalId"]));
                var searchResult = resultSet.ToList();
                foreach (var c in searchResult)
                {
                    c.QuestionString = c.QuestionString.Replace(System.Environment.NewLine, "<br/>");
                }
                return Json(searchResult, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EvaluationForm()
        {
            ViewBag.Test = Session["EvalId"];
            return View();
        }
        [HttpPost]
        public ActionResult EvaluationForm(FormCollection input)
        {
            int Id;
            var isConfirmed = false;
            if (!string.IsNullOrEmpty(input["Finalize"]))
                isConfirmed = true;
            using (var ctx = new EmployeeEvaluationEntities())
            {
                Id = Convert.ToInt32(ctx.sp_AddEvalHeader(Convert.ToInt32(input["Quarter"]), Convert.ToInt32(input["Year"]), Convert.ToInt32(input["EmployeeId"]), Convert.ToInt32(Session["userId"]), isConfirmed, input["Improve"], input["Comments"]).ElementAt(0));
                
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                for (int a = 3; a < input.AllKeys.Length - 3; a +=2)
                {
                    System.Diagnostics.Debug.WriteLine(input[a] + "=)");
                    var score = Convert.ToInt32(input[a + 1]);
                    ctx.sp_AddEvalItem(Convert.ToInt32(input[a]), score, Convert.ToInt32(Id));
                }
            }
            return RedirectToAction("Evaluation");
        }
        //************************EVALUATION PAGE*******************************
        public ActionResult Evaluation()
        {
            if (Session["Deparment"] == null)
            {
                Session["Deparment"] = 3;
            }
            var DepartmentList = "";
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchDepartment("");
                var searchResult = resultSet.ToList();
                foreach (sp_SearchDepartment_Result c in searchResult)
                {
                    DepartmentList = DepartmentList + "<option value = '" + c.Id + "'>" + c.Name + "</option>";
                }
            }
            ViewBag.DepartmentList = DepartmentList;
            if (Session["Year"] == null)
            {
                Session["Year"] = DateTime.Now.Year;
            }
            if (Session["Quarter"] == null)
            {
                Session["Quarter"] = Math.Floor(Convert.ToDouble(DateTime.Now.Month / 4))+1;
            }
            String temp = "";
            for (int a = DateTime.Now.Year; a >= 2010; a--)
            {
                if (a == Convert.ToInt32(Session["Year"]))
                {
                    temp = temp + "<option value='" + a + "' selected>" + a + "</option>";
                }
                else
                {
                    temp = temp + "<option value='" + a + "'>" + a + "</option>";
                }
            }
            ViewBag.YearSelection = temp;
            temp = "";
            for (int a = 1; a <= 4; a++)
            {
                if (a == Convert.ToInt32(Session["Quarter"]))
                {
                    temp = temp + "<option value='" + a + "' selected>" + a + "</option>";
                }
                else
                {
                    temp = temp + "<option value='" + a + "'>" + a + "</option>";
                }
            }
            if (Session["EvalId"] != null)
            {
                if (Session["Year"] == null)
                {
                    Session["Year"] = DateTime.Now.Year;
                }
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    var retval = ctx.sp_getYearGraph(Convert.ToInt32(Session["Year"]), Convert.ToInt32(Session["EvalId"]));
                    foreach (var c in retval)
                    {
                        Session["Name"] = c.NAME;
                        Session["Q1"] = c.Q1;
                        Session["Q2"] = c.Q2;
                        Session["Q3"] = c.Q3;
                        Session["Q4"] = c.Q4;
                    }
                }
            }
            ViewBag.QuarterSelection = temp;
            return View();
        }
        public ActionResult viewGraph(int Id)
        {
            Session["EvalId"] = Id;
            return RedirectToAction("Evaluation");
        }
        public ActionResult startEvaluate(int Id)
        {
            Session["EvalId"] = Id;
            if(Session["Year"]==null)
            {
                Session["Year"] = DateTime.Now.Year;
            }
            return RedirectToAction("EvaluationForm");
        }
        [HttpPost]
        public ActionResult Evaluation(FormCollection input)
        {
            if (!string.IsNullOrEmpty(input["View"]))
            {
                Session["Year"] = input["Year"];
                Session["Quarter"] = input["Quarter"];
                Session["Department"] = input["Department"];
                return RedirectToAction("Evaluation");
            }
            else
            {
                Session["EvalId"] = input["Id"];
                Session["Year"] = input["Year"];
                Session["Quarter"] = input["Quarter"];
                return RedirectToAction("EvaluationForm");
            }
        }
        public JsonResult SearchEvaluate(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            var temp = Session["Year"];
            var temp2 = Session["Quarter"];
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchQuarters(search, Convert.ToInt32(Session["Year"]), Convert.ToInt32(Session["Quarter"]), Convert.ToInt32(Session["Department"]));
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        //************************COMPETENCIES PAGE*****************************
        public ActionResult Competencies()
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var TotalCat = Convert.ToInt32(ctx.sp_GetSumCat().ToArray()[0]);
                var TotalCompetentcy = Convert.ToInt32(ctx.sp_GetSumCompetency(Convert.ToInt32(Session["CategoryId"])).ToArray()[0]);
                ViewBag.TotalCat = TotalCat + "%";
                ViewBag.TotalCompetency = TotalCompetentcy + "%";
                if (TotalCat > 100)
                {
                    ViewBag.Warning += "The Total Category Score Exceeds 100%\n";
                }
                if(TotalCompetentcy>100){
                    ViewBag.Warning += "The Total Field Score Exceeds 100%";
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Competencies(FormCollection input)
        {
            if (!string.IsNullOrEmpty(input["AddCat"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_AddCompetencyCat(input["Name"], Convert.ToInt32(input["Score"]));
                }
            }
            if (!string.IsNullOrEmpty(input["EditCategory"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_EditCompetencyCat(Convert.ToInt32(input["Id"]), input["NameEdit"], Convert.ToInt32(input["ScoreEdit"]));
                }
            }
            if (!string.IsNullOrEmpty(input["AddCompetency"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_AddCoreCompetency(input["Name"], input["Question"], Convert.ToInt32(input["Weight"]), Convert.ToInt32(Session["CategoryId"]));
                }
            }
            if (!string.IsNullOrEmpty(input["EditCompetency"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_EditCoreCompetency(Convert.ToInt32(input["Id2"]), input["NameEdit"], input["QuestionEdit"], Convert.ToInt32(input["WeightEdit"]));
                }
            }
            return RedirectToAction("Competencies");
        }
            //************************COMPETENCIES CATEGORIES**************************
        public JsonResult SearchCompetencyCat(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchCompetencyCat(search);
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteCategory(int id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                ctx.sp_DeleteCompetencyCat(id);
            }
            return RedirectToAction("Competencies");
        }
            //***************CORE COMPETENCIES PAGE*****************************
        public JsonResult SearchCoreCompetency(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            if (Session["categoryId"]==null)
            {
                Session["categoryId"] = 1;
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchCoreCompetency(search, Convert.ToInt32(Session["categoryId"]));
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UpdateFields(int Id)
        {
            Session["categoryId"] = Id;
            return RedirectToAction("Competencies");
        }
        public ActionResult DeleteCompetency(int id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                ctx.sp_DeleteCoreCompetency(id);
            }
            return RedirectToAction("Competencies");
        }
        //************************DEPARTMENTS PAGE******************************
        public ActionResult Departments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Departments(FormCollection input)
        {
            if (!string.IsNullOrEmpty(input["Add"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_AddDepartment(input["NameAdd"]);
                }
            }
            else
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_EditDepartment(Convert.ToInt32(input["Id"]), input["Name"]);
                }
            }
            return View();
        }
        public JsonResult SearchDepartment(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchDepartment(search);
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteDepartment(int id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                ctx.sp_DeleteDepartment(id);
            }
            return RedirectToAction("Departments");
        }
        //************************DESIGNATION PAGE******************************
        public ActionResult Designations()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Designations(FormCollection input)
        {
            if (!string.IsNullOrEmpty(input["Add"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_AddDesignation(input["NameAdd"]);
                }
            }
            else
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_EditDesignation(Convert.ToInt32(input["Id"]), input["Name"]);
                }
            }
            return View();
        }
        public JsonResult SearchDesignation(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchDesignation(search);
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteDesignation(int id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                ctx.sp_DeleteDesignation(id);
            }
            return RedirectToAction("Designations");
        }
        //************************EMPLOYEE PAGE*********************************
        public ActionResult Employees()
        {
            var DepartmentList = "";
            var DesignationList = "";
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchDepartment("");
                var searchResult = resultSet.ToList();
                foreach (sp_SearchDepartment_Result c in searchResult)
                {
                    DepartmentList = DepartmentList + "<option value = '" + c.Id + "'>" + c.Name + "</option>";
                }
                var resultSet2 = ctx.sp_SearchDesignation("");
                var searchResult2 = resultSet2.ToList();
                foreach (sp_SearchDesignation_Result c in searchResult2)
                {
                    DesignationList = DesignationList + "<option value = '" + c.Id + "'>" + c.Name + "</option>";
                }
            }
            ViewBag.DepartmentList = DepartmentList;
            ViewBag.DesignationList = DesignationList;
            return View();
        }
        [HttpPost]
        public ActionResult Employees(FormCollection input)
        {
            if (!string.IsNullOrEmpty(input["Add"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_AddEmployees(input["FirstName"], input["LastName"], Convert.ToInt32(input["Department"]), Convert.ToInt32(input["Designation"]));
                }
            }
            else
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_EditEmployees(Convert.ToInt32(input["Id"]), input["FirstNameEdit"], input["LastNameEdit"], Convert.ToInt32(input["DepartmentEdit"]), Convert.ToInt32(input["DesignationEdit"]));
                }
            }
            return RedirectToAction("Employees");
        }
        public JsonResult SearchEmployee(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchEmployees(search);
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteEmployees(int id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                ctx.sp_DeleteEmployees(id);
            }
            return RedirectToAction("Employees");
        }
        //************************ACCOUNTS PAGE*********************************
        public ActionResult Accounts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Accounts(FormCollection input)
        {
            if (!string.IsNullOrEmpty(input["Add"]))
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_AddAccounts(input["Username"], input["Password"], input["Email"]);
                }
            }
            else
            {
                using (var ctx = new EmployeeEvaluationEntities())
                {
                    ctx.sp_EditAccounts(Convert.ToInt32(input["Id"]), input["UsernameEdit"], input["PasswordEdit"], input["EmailEdit"]);
                }
            }
            return RedirectToAction("Accounts");
        }
        public JsonResult SearchAccounts(int offset, int limit, string search, string sort, string order)
        {
            if (search == null)
            {
                search = "";
            }
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var resultSet = ctx.sp_SearchAccounts(search);
                var searchResult = resultSet.ToList();
                var model = new
                {
                    total = searchResult.Count(),
                    rows = searchResult.Skip((offset / limit) * limit).Take(limit),
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteAccounts(int id)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                ctx.sp_DeleteAccounts(id);
            }
            return RedirectToAction("Accounts");
        }
    }
}