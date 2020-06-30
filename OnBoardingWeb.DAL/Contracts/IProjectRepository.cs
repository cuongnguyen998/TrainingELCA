using OnBoardingWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingWeb.DAL.Contracts
{
    public interface IProjectRepository
    {
        void UpdateProject(Guid id, Project p);
        List<Project> SearchProjectByName(string name);
        Project GetProjectById(Guid id);
        List<Project> LoadProject();
        bool DeleteProject(Guid id);
        void AddProject(Project p);
    }
}
