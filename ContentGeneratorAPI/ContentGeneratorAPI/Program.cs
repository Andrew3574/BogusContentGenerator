using ContentGeneratorAPI.Services.Generators;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Установите URL для прослушивания
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<BookGenerator>();

        var app = builder.Build();

        // Настройка Swagger
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}