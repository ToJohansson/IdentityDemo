namespace Tournament.Application.Interfaces;

public interface IUnitOfWork
{
    ITournamentRepository TournamentRepository { get; }
    IGameRepository GameRepository { get; }

    Task PersistAsync();
}