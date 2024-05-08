using Microsoft.Extensions.DependencyInjection;

namespace AndriiKlym.Mailtrap.Client.Infrastructure
{
    public static class RegisterDIContainer
    {
        /// <summary>
        /// Registers a singleton instance of the MailtrapClient with the specified username, password.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the MailtrapClient to.</param>
        /// <param name="username">The username for the Mailtrap account.</param>
        /// <param name="password">The password for the Mailtrap account.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSingletonMailtrapClient(this IServiceCollection services, 
            string username, string password)
        {
            services.AddSingleton(provider => new MailtrapClient(username, password));
            return services;
        }

        /// <summary>
        /// Registers a singleton instance of the MailtrapClient with the specified username, password, host, and port.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the MailtrapClient to.</param>
        /// <param name="username">The username for the Mailtrap account.</param>
        /// <param name="password">The password for the Mailtrap account.</param>
        /// <param name="host">The host for the Mailtrap account.</param>
        /// <param name="port">The port for the Mailtrap account.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSingletonMailtrapClient(this IServiceCollection services,
            string username, string password, string host, int port)
        {
            services.AddSingleton(provider => new MailtrapClient(username, password, host, port));
            return services;
        }

        /// <summary>
        /// Registers a transient instance of the MailtrapClient with the specified username, password.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the MailtrapClient to.</param>
        /// <param name="username">The username for the Mailtrap account.</param>
        /// <param name="password">The password for the Mailtrap account.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTransientMailtrapClient(this IServiceCollection services,
            string username, string password)
        {
            services.AddTransient(provider => new MailtrapClient(username, password));
            return services;
        }

        /// <summary>
        /// Registers a transient instance of the MailtrapClient with the specified username, password, host, and port.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the MailtrapClient to.</param>
        /// <param name="username">The username for the Mailtrap account.</param>
        /// <param name="password">The password for the Mailtrap account.</param>
        /// <param name="host">The host for the Mailtrap account.</param>
        /// <param name="port">The port for the Mailtrap account.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTransientMailtrapClient(this IServiceCollection services,
            string username, string password, string host, int port)
        {
            services.AddTransient(provider => new MailtrapClient(username, password, host, port));
            return services;
        }

        /// <summary>
        /// Registers a scoped instance of the MailtrapClient with the specified username, password.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the MailtrapClient to.</param>
        /// <param name="username">The username for the Mailtrap account.</param>
        /// <param name="password">The password for the Mailtrap account.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddScopedMailtrapClient(this IServiceCollection services,
            string username, string password)
        {
            services.AddScoped(provider => new MailtrapClient(username, password));
            return services;
        }

        /// <summary>
        /// Registers a scoped instance of the MailtrapClient with the specified username, password, host, and port.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the MailtrapClient to.</param>
        /// <param name="username">The username for the Mailtrap account.</param>
        /// <param name="password">The password for the Mailtrap account.</param>
        /// <param name="host">The host for the Mailtrap account.</param>
        /// <param name="port">The port for the Mailtrap account.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddScopedMailtrapClient(this IServiceCollection services,
            string username, string password, string host, int port)
        {
            services.AddScoped(provider => new MailtrapClient(username, password, host, port));
            return services;
        }
    }
}
