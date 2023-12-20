using GraphQL.API.Models;

namespace GraphQL.API.Repository
{
    public interface IMovieRepository
    {
        Task<Movie?> GetMovieByIdAsync(Guid id);
        Task<Movie?> AddReviewToMovieAsync(Guid id, Review review);
    }
}
