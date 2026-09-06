
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            /* IoC -- arka planda referans oluþturduk. ioc'ler bizim yerimize bu referanslarý newler. 
            IoC yerine Autofac, Ninject, CastleWindsor, LightInject, DryInject gibi alternatif projeleri de kullanacaðýz. 
            peki neden bu alternatifleri kullanýyoruz çünkü AOP kullanacaðýz. AOP nedir? 
            AOP, bir metodun önünde veya sonunda çalýþan kod parçacýklarýný AOP mimarisi ile yazarýz. business'ýn içinde business yazarýz. 
            ne iþe yarar peki. örneðin sen bir metotta loglama, performans, doðrulama, hata gibi iþlemleri AOP ile yaparsýn. 
            bu yüzden Autofac gibi AOP imkaný sunan ürünleri IoC Container yerine kullanýrýz. */

            builder.Services.AddSingleton<IProductService, ProductManager>();   /* IProductService türünde bir baðýmlýlýk görürsen karþýlýðý ProductManager'dýr. 
                                                                                 * Singleton baya performanslýdýr. çok sýk kullanýlmamalýdýr. 
                                                                                 * Singleton, tüm bellekte bir tane ProductManager oluþturur. 
                                                                                 * isterse bin tane istek gelsin hepsine ayný instance veriyor. 
                                                                                 * yani biz bin tane new yazmak yerine bir tane singleton ile 
                                                                                 * bu iþi tamamladýk. 
                                                                                 * !!Signleton'ý data yoksa kullanýrýz. */
            builder.Services.AddSingleton<IProductDal, EfProductDal>();      /* uygulamayý çalýþtýrdýðýmýzda yine hata alarýz çünkü ProductManager'da 
                                                                              * IProductDal'a baðlý ve IProductDal'ýn kime baðýmlý olduðunu yazmadýk.
                                                                              * bu kod satýrý ile bu iþlemi tamamlarýz. */


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
