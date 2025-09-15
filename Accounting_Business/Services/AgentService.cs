using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface IAgentService
    {
        void Add(Agent agent);
        void Delete(Agent agent);
        Task<Agent> Get(int id);
        Task<List<Agent>> GetAll();
    }
    public class AgentService : IAgentService
    {
        private readonly AppDbContext _context;
        public AgentService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Agent agent)
        {
            _context.Agents.Add(agent);
        }

        public void Delete(Agent agent)
        {
            _context.Agents.Remove(agent);
        }

        public async Task<Agent> Get(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            // if (agents == null) { throw new NotFo}
            return agent;
        }
        public async Task<List<Agent>> GetAll()
        {
            var agents = await _context.Agents.Where(e => e.IsActive == true).ToListAsync();
            return agents;
        }
    }
}
