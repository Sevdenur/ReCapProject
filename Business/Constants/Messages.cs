using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string NameInvalid = "Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";

        public static string CarAdded = "Ürün Eklendi";
        public static string CarDeleted = "Ürün Silindi";
        public static string CarUpdated = "Ürün Güncellendi";                
        public static string CarsListed = "Ürünler Listelendi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed = "Markalar Listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler Listelendi";

        public static string UserAdded = "User Eklendi";
        public static string UserDeleted = "User Silindi";
        public static string UserUpdated = "User Güncellendi";
        public static string UsersListed = "Users Listelendi";

        public static string CustomerAdded = "Customer Eklendi";
        public static string CustomerDeleted = "Customer Silindi";
        public static string CustomerUpdated = "Customer Güncellendi";
        public static string CustomersListed = "Customer Listelendi";

        public static string RentalAdded = "Rental Eklendi";
        public static string RentalDeleted = "Rental Silindi";
        public static string RentalUpdated = "Rental Güncellendi";
        public static string RentalsListed = "Rental Listelendi";
        public static string RentalsFailed = "Kiralama işlemi gerçekleştirilemedi";

        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImagesListed = "Resimler listelendi";
        public static string CarImageUpdated = "Resimler güncellendi";
        internal static string CarImageLimitExceded="Bir arabaya ait 5 adet resim eklenebilir";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
