using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.BLL.Contracts
{
    public interface IArticleService
    {
        Task<bool> CreateAsync(ArticleModel model);
        Task<bool> EditAsync(ArticleModel model);
        Task DeleteByIdAsync(Guid id);
        Task<ArticleModel> GetByIdAsync(Guid id);
        Task<IEnumerable<ArticleModel>> GetAllAsync();
    }
}
