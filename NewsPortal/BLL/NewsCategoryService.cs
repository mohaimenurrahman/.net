using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NewsCategoryService
    {
        public static List<NewsCategoryModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, NewsCategoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsCategoryModel>>(DataAccessFactory.NewsCategoryDataAccess().Get());
            return data;
        }

        public static NewsCategoryModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, NewsCategoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsCategoryModel>(DataAccessFactory.NewsCategoryDataAccess().Get(id));
            return data;
        }

        public static bool Add(NewsCategoryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsCategoryModel, Category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(n);
            return DataAccessFactory.NewsCategoryDataAccess().Add(data);
        }

        public static bool Edit(NewsCategoryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsCategoryModel, Category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(n);
            return DataAccessFactory.NewsCategoryDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.NewsCategoryDataAccess().Delete(id);
        }
    }
}
