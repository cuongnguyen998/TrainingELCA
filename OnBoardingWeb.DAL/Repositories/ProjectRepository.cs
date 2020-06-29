using OnBoardingWeb.DAL.Contracts;
using OnBoardingWeb.DAL.Models;
using System;
using System.Collections.Generic;
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
            return _db.Projects.ToList();
        }
    }
}
