using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournamet.Api.Data;

namespace Tournament.Data.Repositories;
public class GameRepository(TournametContext context) : IGameRepository
{
    public void Add(Game tournament)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Game>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(Game tournament)
    {
        throw new NotImplementedException();
    }

    public void Update(Game tournament)
    {
        throw new NotImplementedException();
    }
}
