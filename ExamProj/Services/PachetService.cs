using ExamProj.Models;
using ExamProj.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProj.Services
{
    public interface IPachetService
    {
        PaginatedList<PachetGetModel> GetAll(int page);
        Pachet GetById(int id);
        Pachet Create(PachetPostModel pachet, User addedBy);
        Pachet Upsert(int id, Pachet pachet);
        Pachet Delete(int id);
    }

    public class PachetService : IPachetService
    {
        //aici tb sa declar un DB context
        private ExamDbContext context;
        //tb constructor
        public PachetService(ExamDbContext context)
        {
            this.context = context;
        }

        //acum mutam logica din Controller pe Service.
        //Nu il eliminam dar Controller-ul va apela Service si nu va mai apela UI-ul Service-ul

        public Pachet Create(PachetPostModel pachet, User addedBy)
        {
            Pachet toAdd = PachetPostModel.ToPachet(pachet);
            toAdd.Owner = addedBy;
            context.Pachete.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Pachet Delete(int id)
        {
            // var existing = context.Entities.Include(x => x.Comments).FirstOrDefault(movie => movie.Id == id);
            var existing = context.Pachete.FirstOrDefault(entity => entity.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Pachete.Remove(existing);
            context.SaveChanges();

            return existing;
        }
        public PaginatedList<PachetGetModel> GetAll(int page)
        {
            //IQueryable<Movie> result = context.Movies.Include(f => f.Comments);
            IQueryable<Pachet> result = context
                .Pachete
                .OrderBy(f => f.Id)
                //  .Include(c => c.Comments)
                .OrderByDescending(m => m.Cost);
            PaginatedList<PachetGetModel> paginatedResult = new PaginatedList<PachetGetModel>();
            paginatedResult.CurrentPage = page;

            //if (from != null)
            //{
            //    result = result.Where(f => f.Date >= from);
            //}
            //if (to != null)
            //{
            //    result = result.Where(f => f.Date <= to);
            //}

            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<PachetGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<PachetGetModel>.EntriesPerPage)
                .Take(PaginatedList<PachetGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(m => PachetGetModel.FromPachet(m)).ToList();

            return paginatedResult;
        }

        public Pachet GetById(int id)
        {
            // sau context.Movies.Find()
            return context.Pachete
                // .Include(f => f.Comments)
                .FirstOrDefault(f => f.Id == id);
        }


        public Pachet Upsert(int id, Pachet pachet)
        {
            var existing = context.Pachete.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Pachete.Add(pachet);
                context.SaveChanges();
                return pachet;
            }
            pachet.Id = id;
            context.Pachete.Update(pachet);
            context.SaveChanges();
            return pachet;
        }


    }

}


