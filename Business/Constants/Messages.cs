using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandNameInvalid = "Marka ismi bir karakter olamaz!";
        public static string BrandAdded ="Marka eklendi.";
        public static string BrandDeleted ="Marka silindi.";
        public static string BrandsListed="Markalar Listelendi.";
        public static string BrandDetail="Marka Detayı.";
        public static string BrandUpdated="Marka Güncellendi.";
        public static string CarsListed ="Arabalar Listelendi";
        public static string CarDetail="Araba Detayı";
        public static string CarDeleted="Araba Silindi.";
        public static string CarAdded="Araba Eklendi.";
        public static string CarPriceInvalid="Araba fiyat sıfırdan büyük olmalı.";
        public static string CarNameInvalid ="Araba ismi en az 3 karakter olmalı.";
        public static string CarsByBrand ="Marka bazında arabalar listelendi.";
        public static string CarUpdated="Araba Güncellendi";
        public static string CarsByColor="Renge göre arabalar listelendi.";
        public static string CarsDetailListed="Araba detayları listelendi.";
        public static string ColorAdded="Renk Eklendi";
        public static string ColorDeleted="Renk Silindi";
        public static string ColorsListed="Renkler Listelendi.";
        public static string ColorDetail="Renk Detayı.";
        public static string ColorUpdated="Renk Güncellendi";
        public static string RentalAdded ="Kiralama Başlatıldı.";
        public static string RentalDeleted="Kiralama İptal edildi.";
        public static string RentalsListed ="Kiralamalar listelendi";
        public static string RentalUpdated="Kiralama Güncellendi.";
        public static string CustomerAdded= "Müşteri Eklendi";
        public static string CustomerDeleted ="Müşteri Silindi";
        public static string CustomersListed ="Müşteriler Listelendi";
        public static string CustomerUpdated ="Müşteri Güncellendi";
        public static string UserAdded ="Kullanıcı Eklendi.";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string UsersListed="Kullanıcılar Listelendi";
        public static string UserUpdated="Kullanıcı Güncellendi.";
        public static string UserListed ="Kullanıcı detayı.";
        public static string CustomerListed="Müşteri detayı";
        public static string rentalListed ="Kiralama listesi";
        public static string RentalAvailableListed="Kiralabilecek araçlar listelendi. ";
        public static string RentalDetailListed="Kiralamalar detaylı listelendi.";
        public static string RentalByCarListed="Aracın kiralamaları listelendi";
        public static string RentalAddedError="Araç teslim tarihi açıkken kiralanamaz";
        public static string RentalUpdatedReturnDateError="Teslim tarihi güncellenemedi çünkü açık değil";
        public static string RentalUpdatedReturnDate="Teslim tarihi güncellendi";
    }
}
