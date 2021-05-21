using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Models;
using VictimsHelp.DAL;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Article> _articles;

        public ArticleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _articles = context.Set<Article>();
        }

        public async Task<bool> CreateAsync(ArticleModel model)
        {
            try
            {
                var article = await _articles.FirstOrDefaultAsync(u => u.Id == model.Id);

                if (article != null)
                {
                    return false;
                }

                article = _mapper.Map<Article>(model);

                await _articles.AddAsync(article);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(ArticleModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
