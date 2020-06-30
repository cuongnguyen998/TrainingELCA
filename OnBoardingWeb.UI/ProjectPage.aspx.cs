using OnBoardingWeb.DAL;
using OnBoardingWeb.DAL.Models;
using OnBoardingWeb.DAL.Repositories;
using OnBoardingWeb.UI.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnBoardingWeb.UI
{
    public partial class ProjectPage : Page
    {
        //private OnBoardingExerciseEntities _db;
        private OnBoardingDataAccess _rep;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_db = new OnBoardingExerciseEntities();
            _rep = new OnBoardingDataAccess();
            //LoadDataToGridView();
        }

        #region Methods
        private void LoadDataToGridView()
        {
            GvProject.DataSource = _rep.ProjectRepository.LoadProject();
            GvProject.DataBind();
        }
        private void LogError(string message)
        {
            CreateLogFile createLogFile = new CreateLogFile();
            createLogFile.LogError(Server.MapPath("Logs/ErrorLog"), message);
        }
        protected override void InitializeCulture()
        {
            HttpCookie cookie = Request.Cookies["langCookie"];
            if (!string.IsNullOrEmpty(cookie.Value))
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(cookie.Value);
            }

        }
        #endregion



        #region Events
        //protected void SearchButton_Click(object sender, EventArgs e)
        //{

        //}

        protected void GvProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var updatedId = e.Keys[0];

            Project updatedItem = new Project()
            {
                Id = (Guid)e.Keys[0],
                Name = e.NewValues["Name"].ToString(),
                Description = e.NewValues["Description"].ToString(),
                StartDate = Convert.ToDateTime(e.NewValues["StartDate"]),
                StudyHour = Convert.ToDecimal(e.NewValues["StudyHour"])
            };

            try
            {
                _rep.ProjectRepository.UpdateProject((Guid)updatedId, updatedItem);
                _rep.SaveChange();
                SearchTextBox.Text = string.Empty;

            }
            catch(NullReferenceException ex)
            {
                e.Cancel = true;
                ErrorMessageLabel.Visible = true;
                ErrorMessageLabel.Text = string.Format("Can not update. Updated item can not be null");
                LogError(ex.Message);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                ErrorMessageLabel.Visible = true;
                ErrorMessageLabel.Text = string.Format("Update failed. {0}", ex.ToString());
                LogError(ex.Message);
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddProject.aspx", false);
        }
        #endregion


    }
}