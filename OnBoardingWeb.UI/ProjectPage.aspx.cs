using OnBoardingWeb.DAL;
using OnBoardingWeb.DAL.Models;
using OnBoardingWeb.DAL.Repositories;
using OnBoardingWeb.UI.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        void LoadDataToGridView()
        {
            GvProject.DataSource = _rep.ProjectRepository.LoadProject();
            GvProject.DataBind();
        }
        void LogError(string message)
        {
            CreateLogFile createLogFile = new CreateLogFile();
            createLogFile.LogError(Server.MapPath("Logs/ErrorLog"), message);
        }
        #endregion



        #region Events
        protected void SearchButton_Click(object sender, EventArgs e)
        {

        }

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
            catch (Exception ex)
            {
                e.Cancel = true;
                ErrorMessageLabel.Visible = true;
                ErrorMessageLabel.Text = string.Format("Update failed. {0}", ex.ToString());
                LogError(ex.Message);
            }
        }
        #endregion
    }
}