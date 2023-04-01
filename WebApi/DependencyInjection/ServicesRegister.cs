
using Application.AuthorServices;
using Application.BookRequestServices;
using Application.BookServices;
using Application.EditorialServices;
using Application.GenreServices;
using Application.LanguageServices;
using Application.UserServices;
using Infrastructure.Repository;

namespace WebApi.DependencyInjection
{
    public static class ServicesRegister
    {
        public static IServiceCollection AddDependencyService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<IBookRequestService, BookRequestService>();
            services.AddTransient<IBookService, BookService>();

            return services;
        }
    }
}
