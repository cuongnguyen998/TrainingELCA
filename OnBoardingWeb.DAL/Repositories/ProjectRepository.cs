using OnBoardingWeb.DAL.Contracts;
using OnBoardingWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingWeb.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private OnBoardingExerciseEntities _db;
        public ProjectRepository(OnBoardingExerciseEntities context)
        {
            _db = context;
        }
        public void UpdateProject(Guid id, Project p)
        {
            if (id != p.Id)
            {
                return;
            }
            _db.Entry(p).State = System.Data.EntityState.Modified;
            //_db.SaveChanges();
        }

        public List<Project> SearchProjectByName(string name)
        {
            return _db.Projects.Where(p => p.Name.Contains(name)).ToList();
        }

        public Project GetProjectById(Guid id)
        {
            return _db.Projects.Find(id);
        }

        public List<Project> LoadProject()
        {
            return _db.Projects.Where(p => p.Active.Value).ToList();
        }

        public bool DeleteProject(Guid id)
        {
            Project projectToDelete = _db.Projects.Find(id);
            if (projectToDelete != null)
            {
                projectToDelete.Active = false;
                _db.Entry(projectToDelete).State = System.Data.EntityState.Modified;
                return true;
            }
            return false;


        }

        public void AddProject(Project p)
        {
            if (IsDuplicate(p))
            {
                throw new DuplicateNameException("This project name is already exist");
            }

            _db.Projects.Add(p);
        }


        private bool IsDuplicate(Project project)
        {
            return _db.Projects.Where(p => p.Active.Value && p.Name.Equals(project.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null;
        }
    }
}
