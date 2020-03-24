using System;
using System.Threading.Tasks;
using PuzzleLibrary.Domain.Model;
using PuzzleLibrary.Domain.Service;

namespace PuzzleLibrary.Application.Service
{
    public class GameService
    {
        private readonly IGameModelRepository _repository;

        public GameService(IGameModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameModel> Play(int index, Guid gameId, int gameTimer)
        {
            var gameModel = await _repository.Read(gameId);
            var hasPlayed = gameModel.Play(index);
            gameModel.aTimer = gameTimer;
            await _repository.Update(gameModel);
            return gameModel;
        }

        public async Task<GameModel> StartGame()
        {
            var gameModel = new GameModel();
            await _repository.Create(gameModel);
            return gameModel;
        }

        public async Task<GameModel> Read(Guid gameId)
        {
            return await _repository.Read(gameId);
        }
    }

}




