using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlaceContext _context;
        public IPlaceRepository Places { get; set; }

        public IQuestionRepository Questions { get; set; }

        public UnitOfWork(string connectionString)
        {
            _context = new PlaceContext(connectionString);
            Places = new PlaceRepository(_context);
            Questions = new QuestionRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void UpdatePlace(Place place)
        {
            Places.Update(place);
        }
        public void UpdateQuestion(Question question)
        {
            Questions.Update(question);
        }
    }
}
