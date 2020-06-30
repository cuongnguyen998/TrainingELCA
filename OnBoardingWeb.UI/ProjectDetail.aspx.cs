using OnBoardingWeb.DAL;
using OnBoardingWeb.DAL.Models;
using OnBoardingWeb.UI.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnBoardingWeb.UI
{
    public partial class ProjectDetail : System.Web.UI.Page
    {
        private OnBoardingDataAccess _rep;
        private Project _selectedProject;
        protected void Page_Load(object sender, EventArgs e)
        {
            _rep = new OnBoardingDataAccess();
            _selectedProject = new Project();
            if (!IsPostBack)
            {
                lbError.Visible = false;
                GetProjectById();
            }
        }

        #region Methods
        void GetProjectById()
        {
            string id = Request.QueryString["Id"];
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            Guid projectId = Guid.Parse(id);
            _selectedProject = _rep.ProjectRepository.GetProjectById(projectId);

            if (_selectedProject != null)
            {
                txtName.Text = _selectedProject.Name;
                txtaDescription.InnerHtml = _selectedProject.Description; //.Text = _selectedProject.Description;
                txtStartDate.Text = Convert.ToDateTime(_selectedProject.StartDate).ToString("yyyy-MM-dd");
                txtStudyHour.Text = _selectedProject.StudyHour.ToString();
            }
        }
        void LogError(string message)
        {
            CreateLogFile createLogFile = new CreateLogFile();
            createLogFile.LogError(Server.MapPath("Logs/ErrorLog"), message);
        }
        #endregion

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedProject.Id = Guid.Parse(Request.QueryString["Id"]);
                _selectedProject.Name = txtName.Text;
                _selectedProject.Description = txtaDescription.InnerHtml; //txtDescription.Text;
                _selectedProject.StartDate = Convert.ToDateTime(txtStartDate.Text);
                _selectedProject.StudyHour = Convert.ToDecimal(txtStudyHour.Text);
                _rep.ProjectRepository.UpdateProject(_selectedProject.Id, _selectedProject);
                _rep.SaveChange();
                Response.Redirect("~/ProjectPage.aspx", false);
            }
            catch (FormatException formatEx)
            {
                lbError.Visible = true;
                lbError.Text = formatEx.Message + formatEx.StackTrace;
                LogError(formatEx.Message + " " + formatEx.StackTrace);
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                lbError.Text = "Error while saving. Please check again or see log file for detail";
                LogError(ex.Message);
            }
        }
        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                try
                {
                    bool isDeleted = _rep.ProjectRepository.DeleteProject(Guid.Parse(Request.QueryString["Id"]));
                    if (isDeleted)
                    {
                        _rep.SaveChange();
                    }
                }
                catch(ArgumentNullException argNullEx)
                {
                    lbError.Visible = true;
                    lbError.Text = "The Id cannot be null. Please check again or see log file for detail";
                    LogError(argNullEx.Message);
                }
                catch (InvalidCastException castException)
                {
                    lbError.Visible = true;
                    lbError.Text = "Invalid cast exception. Please check again or see log file for detail";
                    LogError(castException.Message);
                }
                Response.Redirect("~/ProjectPage.aspx", false);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }


            
        }

        
    }
}