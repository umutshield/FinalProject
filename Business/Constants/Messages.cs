using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages      //static verildiğinde newlenmez
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed ="Ürünler listelendi";
        public static string ProductCountOfCategoryError="Ürün sayısını aştınız!";
        public static string ProductNameAlreadyExists="Böyle bir ürün ismi sisteme kayıtlı";
        public static string CategoryLimitExceded="Kategori limitini aştığınız için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
    }
}
