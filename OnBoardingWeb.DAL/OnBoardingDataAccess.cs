using OnBoardingWeb.DAL.Contracts;
using OnBoardingWeb.DAL.Models;
using OnBoardingWeb.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingWeb.DAL
{
    public class OnBoardingDataAccess : IOnBoardingDataAccess
    {
        private OnBoardingExerciseEntities _context;
        private ProjectRepository _projectRepository;
        public OnBoardingDataAccess()
        {
            _context = new OnBoardingExerciseEntities();
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new ProjectRepository(_context);
                }
                return _projectRepository;
            }
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
