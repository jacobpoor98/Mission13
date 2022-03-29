using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingDbContext _context { get; set; }

        // create an instance of the bowling table
        public EFBowlersRepository (BowlingDbContext temp)
        {
            _context = temp;
        }

        // make bowler and team classes queryable
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;

        // add bowler option
        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
            
        }

        // edit bowler
        public void EditBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        // delete bowler
        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
