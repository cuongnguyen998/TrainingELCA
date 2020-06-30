using OnBoardingWeb.DAL;
using OnBoardingWeb.DAL.Models;
using OnBoardingWeb.UI.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnBoardingWeb.UI
{
    public partial class AddProject : System.Web.UI.Page
    {
        private OnBoardingDataAccess _rep;
        protected void Page_Load(object sender, EventArgs e)
        {
            _rep = new OnBoardingDataAccess();
            if (!IsPostBack)
            {
                lbError.Visible = false;
            }
        }
        void LogError(string message)
        {
            CreateLogFile createLogFile = new CreateLogFile();
            createLogFile.LogError(Server.MapPath("Logs/ErrorLog"), message);
        }

        void AddNewProject()
        {
            try
            {
                Project project = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = txtName.Text,
                    Description = txtaDescription.InnerHtml,
                    StartDate = Convert.ToDateTime(txtStartDate.Text),
                    StudyHour = Convert.ToDecimal(txtStudyHour.Text),
                    Active = true

                };
                _rep.ProjectRepository.AddProject(project);
                _rep.SaveChange();
                Response.Redirect("~/ProjectPage.aspx");
            }
            catch (FormatException formatEx)
            {
                lbError.Visible = true;
                lbError.Text = formatEx.Message + formatEx.StackTrace;
                LogError(formatEx.Message + " " +formatEx.StackTrace);
            }
            catch (NullReferenceException nullEx)
            {
                lbError.Visible = true;
                lbError.Text = "Can not add project. Please see log file to see detail";
                LogError(nullEx.Message);
            }
            catch (DuplicateNameException duplicateEx)
            {
                lbError.Visible = true;
                lbError.Text = duplicateEx.Message + ". Please see log file to see detail";
                LogError(duplicateEx.Message);
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddNewProject();
        }
    }
}