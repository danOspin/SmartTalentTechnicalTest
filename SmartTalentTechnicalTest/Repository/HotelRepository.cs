using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartTalentTechnicalTest.Repository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetActiveHotelsAsync();
    }
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Hotel>> GetActiveHotelsAsync()
        {
            return await _dbSet.Where(h => h.IsActive).ToListAsync();
        }
    }


}
