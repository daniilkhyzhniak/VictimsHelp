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

        public async Task DeleteByIdAsync(Guid id)
        {
            try
            {
                var article = await _articles.FirstOrDefaultAsync(u => u.Id == id);

                if (article != null)
                {
                    return;
                }

                _articles.Remove(article);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task<bool> EditAsync(ArticleModel model)
        {
            try
            {
                var article = await _articles.FirstOrDefaultAsync(u => u.Id == model.Id);

                if (article != null)
                {
                    return false;
                }

                article.Title = model.Title;
                article.Text = model.Text;

                _articles.Update(article);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ArticleModel>> GetAllAsync()
        {
            try
            {
                var articles = await _articles.ToListAsync();

                var models = _mapper.Map<IEnumerable<ArticleModel>>(articles);

                return models;
            }
            catch (Exception)
            {
                return new List<ArticleModel>();
            }
        }

        public async Task<ArticleModel> GetByIdAsync(Guid id)
        {
            try
            {
                var article = await _articles.FirstOrDefaultAsync(a => a.Id == id);

                var model = _mapper.Map<ArticleModel>(article);

                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
