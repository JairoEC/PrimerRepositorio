using System.Reflection.Metadata.Ecma335;
using WebApplication_NET_CORE.Context;
using WebApplication_NET_CORE.Entities;
using WebApplication_NET_CORE.Models;

namespace WebApplication_NET_CORE.Managers
{
    public class ServiceManager(AppDbContext _dbContext)
    {
        public List<ServiceVM> GetAll(int userId)
        {
            var list = _dbContext.Service
                .Where(i => i.UserId == userId)
                .Select(i => new ServiceVM
                {
                    ServiceId = i.ServiceId,
                    UserId = i.UserId,
                    Name = i.Name,
                    Type = i.Type
                })
                .ToList();
            return list;
        }
        public int New(ServiceVM viewModel)
        {
            var entity = new Service
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                UserId= viewModel.UserId,
            };
            _dbContext.Service.Add(entity);
            var rowsAfected = _dbContext.SaveChanges();
            return rowsAfected;
        }
        public ServiceVM GetById(int id)
        {
            var entity = _dbContext.Service.Find(id);
            var model = new ServiceVM
            {
                ServiceId = id,
                Name = entity.Name,
                Type = entity.Type
            };
            return model;
        }
        public int Edit(ServiceVM model)
        {
            var entity = _dbContext.Service.Find(model.ServiceId);
            entity.Name = model.Name;
            entity.Type = model.Type;

            _dbContext.Service.Update(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;

        }
        public int Delete(int id)
        {
            var entity = _dbContext.Service.Find(id);
            _dbContext.Service.Remove(entity);
            var affected_rows = _dbContext.SaveChanges();

            return affected_rows;
        }
    }
}
