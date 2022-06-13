using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Constants
{
    public class BusinessMessages
    {
        public static string SuccessAdd = "Ekleme Başarılı";
        public static string UnSuccessfulAdd = "Ekleme Başarısız";

        public static string SuccessUpdate = "Güncelleme Başarılı";
        public static string UnSuccessfulUpdate = "Güncelleme Başarısız";

        public static string SuccessDelete = "Silme Başarılı";
        public static string UnSuccessfulDelete = "Silme Başarısız";

        public static string SuccessList = "Listeleme Başarılı";
        public static string UnSuccessfulList = "Getirme Başarılı";

        public static string CreateToken = "Token Oluşturuldu";
        public static string UserNameOrPasswordWrong = "Kullanıcı adı veya şifre hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserEmailAlreadyExists = "Bu eposta başka biri tarafından alınmış";
        public static string UserUserNameAlreadyExists = "Bu kullanıcı adı başka biri tarafından alınmış";
        public static string SuccessfulRegister = "Kayıt işlemi başarılı";

        public static string NotFound = "Kayıt bulunamadı";
    }
}
