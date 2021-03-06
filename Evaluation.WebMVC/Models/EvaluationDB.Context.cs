﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evaluation.WebMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeEvaluationEntities : DbContext
    {
        public EmployeeEvaluationEntities()
            : base("name=EmployeeEvaluationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CompetencyCat> CompetencyCats { get; set; }
        public virtual DbSet<CoreCompetency> CoreCompetencies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EvalHeader> EvalHeaders { get; set; }
        public virtual DbSet<EvalItem> EvalItems { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual int sp_AddAccounts(string username, string password, string email)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddAccounts", usernameParameter, passwordParameter, emailParameter);
        }
    
        public virtual int sp_AddCompetencyCat(string name, Nullable<int> weightedScore)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var weightedScoreParameter = weightedScore.HasValue ?
                new ObjectParameter("WeightedScore", weightedScore) :
                new ObjectParameter("WeightedScore", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddCompetencyCat", nameParameter, weightedScoreParameter);
        }
    
        public virtual int sp_AddCoreCompetency(string name, string questionString, Nullable<int> weight, Nullable<int> competenctCatId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var questionStringParameter = questionString != null ?
                new ObjectParameter("QuestionString", questionString) :
                new ObjectParameter("QuestionString", typeof(string));
    
            var weightParameter = weight.HasValue ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(int));
    
            var competenctCatIdParameter = competenctCatId.HasValue ?
                new ObjectParameter("CompetenctCatId", competenctCatId) :
                new ObjectParameter("CompetenctCatId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddCoreCompetency", nameParameter, questionStringParameter, weightParameter, competenctCatIdParameter);
        }
    
        public virtual int sp_AddDepartment(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddDepartment", nameParameter);
        }
    
        public virtual int sp_AddDesignation(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddDesignation", nameParameter);
        }
    
        public virtual int sp_AddEmployees(string firstName, string lastName, Nullable<int> departmentId, Nullable<int> designationId)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("DepartmentId", departmentId) :
                new ObjectParameter("DepartmentId", typeof(int));
    
            var designationIdParameter = designationId.HasValue ?
                new ObjectParameter("DesignationId", designationId) :
                new ObjectParameter("DesignationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEmployees", firstNameParameter, lastNameParameter, departmentIdParameter, designationIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> sp_AddEvalHeader(Nullable<int> quarter, Nullable<int> year, Nullable<int> employeeId, Nullable<int> accountId, Nullable<bool> isConfirmed, string areaToImprove, string comment)
        {
            var quarterParameter = quarter.HasValue ?
                new ObjectParameter("Quarter", quarter) :
                new ObjectParameter("Quarter", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var accountIdParameter = accountId.HasValue ?
                new ObjectParameter("AccountId", accountId) :
                new ObjectParameter("AccountId", typeof(int));
    
            var isConfirmedParameter = isConfirmed.HasValue ?
                new ObjectParameter("isConfirmed", isConfirmed) :
                new ObjectParameter("isConfirmed", typeof(bool));
    
            var areaToImproveParameter = areaToImprove != null ?
                new ObjectParameter("AreaToImprove", areaToImprove) :
                new ObjectParameter("AreaToImprove", typeof(string));
    
            var commentParameter = comment != null ?
                new ObjectParameter("Comment", comment) :
                new ObjectParameter("Comment", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("sp_AddEvalHeader", quarterParameter, yearParameter, employeeIdParameter, accountIdParameter, isConfirmedParameter, areaToImproveParameter, commentParameter);
        }
    
        public virtual int sp_AddEvalItem(Nullable<int> coreCompetencyId, Nullable<int> score, Nullable<int> evalHeaderId)
        {
            var coreCompetencyIdParameter = coreCompetencyId.HasValue ?
                new ObjectParameter("CoreCompetencyId", coreCompetencyId) :
                new ObjectParameter("CoreCompetencyId", typeof(int));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(int));
    
            var evalHeaderIdParameter = evalHeaderId.HasValue ?
                new ObjectParameter("EvalHeaderId", evalHeaderId) :
                new ObjectParameter("EvalHeaderId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEvalItem", coreCompetencyIdParameter, scoreParameter, evalHeaderIdParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_DeleteAccounts(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteAccounts", idParameter);
        }
    
        public virtual int sp_DeleteCompetencyCat(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCompetencyCat", idParameter);
        }
    
        public virtual int sp_DeleteCoreCompetency(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCoreCompetency", idParameter);
        }
    
        public virtual int sp_DeleteDepartment(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteDepartment", idParameter);
        }
    
        public virtual int sp_DeleteDesignation(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteDesignation", idParameter);
        }
    
        public virtual int sp_DeleteEmployees(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteEmployees", idParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_EditAccounts(Nullable<int> id, string username, string password, string email)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditAccounts", idParameter, usernameParameter, passwordParameter, emailParameter);
        }
    
        public virtual int sp_EditCompetencyCat(Nullable<int> id, string name, Nullable<int> weightedScore)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var weightedScoreParameter = weightedScore.HasValue ?
                new ObjectParameter("WeightedScore", weightedScore) :
                new ObjectParameter("WeightedScore", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditCompetencyCat", idParameter, nameParameter, weightedScoreParameter);
        }
    
        public virtual int sp_EditCoreCompetency(Nullable<int> id, string name, string questionString, Nullable<int> weight)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var questionStringParameter = questionString != null ?
                new ObjectParameter("QuestionString", questionString) :
                new ObjectParameter("QuestionString", typeof(string));
    
            var weightParameter = weight.HasValue ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditCoreCompetency", idParameter, nameParameter, questionStringParameter, weightParameter);
        }
    
        public virtual int sp_EditDepartment(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditDepartment", idParameter, nameParameter);
        }
    
        public virtual int sp_EditDesignation(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditDesignation", idParameter, nameParameter);
        }
    
        public virtual int sp_EditEmployees(Nullable<int> id, string firstName, string lastName, Nullable<int> departmentId, Nullable<int> designationId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("DepartmentId", departmentId) :
                new ObjectParameter("DepartmentId", typeof(int));
    
            var designationIdParameter = designationId.HasValue ?
                new ObjectParameter("DesignationId", designationId) :
                new ObjectParameter("DesignationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditEmployees", idParameter, firstNameParameter, lastNameParameter, departmentIdParameter, designationIdParameter);
        }
    
        public virtual ObjectResult<sp_GetEmployeeDetail_Result> sp_GetEmployeeDetail(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetEmployeeDetail_Result>("sp_GetEmployeeDetail", idParameter);
        }
    
        public virtual ObjectResult<sp_getForm_Result> sp_getForm(Nullable<int> catId, Nullable<int> year, Nullable<int> quarter, Nullable<int> employeeId)
        {
            var catIdParameter = catId.HasValue ?
                new ObjectParameter("CatId", catId) :
                new ObjectParameter("CatId", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var quarterParameter = quarter.HasValue ?
                new ObjectParameter("Quarter", quarter) :
                new ObjectParameter("Quarter", typeof(int));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getForm_Result>("sp_getForm", catIdParameter, yearParameter, quarterParameter, employeeIdParameter);
        }
    
        public virtual ObjectResult<sp_GetHeader_Result> sp_GetHeader(Nullable<int> employeeId, Nullable<int> year, Nullable<int> quarter)
        {
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var quarterParameter = quarter.HasValue ?
                new ObjectParameter("Quarter", quarter) :
                new ObjectParameter("Quarter", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetHeader_Result>("sp_GetHeader", employeeIdParameter, yearParameter, quarterParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_GetSumCat()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetSumCat");
        }
    
        public virtual ObjectResult<Nullable<int>> sp_GetSumCompetency(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetSumCompetency", idParameter);
        }
    
        public virtual ObjectResult<sp_getYearGraph_Result> sp_getYearGraph(Nullable<int> year, Nullable<int> employeeId)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getYearGraph_Result>("sp_getYearGraph", yearParameter, employeeIdParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<sp_SearchAccounts_Result> sp_SearchAccounts(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchAccounts_Result>("sp_SearchAccounts", searchParameter);
        }
    
        public virtual ObjectResult<sp_SearchCompetencyCat_Result> sp_SearchCompetencyCat(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchCompetencyCat_Result>("sp_SearchCompetencyCat", searchParameter);
        }
    
        public virtual ObjectResult<sp_SearchCoreCompetency_Result> sp_SearchCoreCompetency(string search, Nullable<int> catId)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var catIdParameter = catId.HasValue ?
                new ObjectParameter("CatId", catId) :
                new ObjectParameter("CatId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchCoreCompetency_Result>("sp_SearchCoreCompetency", searchParameter, catIdParameter);
        }
    
        public virtual ObjectResult<sp_SearchDepartment_Result> sp_SearchDepartment(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchDepartment_Result>("sp_SearchDepartment", searchParameter);
        }
    
        public virtual ObjectResult<sp_SearchDesignation_Result> sp_SearchDesignation(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchDesignation_Result>("sp_SearchDesignation", searchParameter);
        }
    
        public virtual ObjectResult<sp_SearchEmployees_Result> sp_SearchEmployees(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchEmployees_Result>("sp_SearchEmployees", searchParameter);
        }
    
        public virtual ObjectResult<sp_SearchQuarters_Result> sp_SearchQuarters(string search, Nullable<int> year, Nullable<int> quarter, Nullable<int> deparmentId)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var quarterParameter = quarter.HasValue ?
                new ObjectParameter("Quarter", quarter) :
                new ObjectParameter("Quarter", typeof(int));
    
            var deparmentIdParameter = deparmentId.HasValue ?
                new ObjectParameter("DeparmentId", deparmentId) :
                new ObjectParameter("DeparmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchQuarters_Result>("sp_SearchQuarters", searchParameter, yearParameter, quarterParameter, deparmentIdParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_ValidateLogin_Result> sp_ValidateLogin(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ValidateLogin_Result>("sp_ValidateLogin", usernameParameter, passwordParameter);
        }
    }
}
