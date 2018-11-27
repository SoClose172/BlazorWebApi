using Microsoft.EntityFrameworkCore;
using WebBlazorAppNew.Shared.Models;

namespace WebBlazorAppNew.Server.DataAccess
{
    public class HomeWorkContext : DbContext
    {
        public virtual DbSet<HomeWork> HomeWork { get; set; }

        public HomeWorkContext(DbContextOptions<HomeWorkContext> options)
            : base(options)
        {
        }

        //Mifort: убрал конфигурацию отсюда
    }
}