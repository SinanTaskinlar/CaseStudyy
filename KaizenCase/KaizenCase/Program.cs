class Program
{
    static void Main(string[] args)
    {
        // Oluşturulacak hediye çeki kodu sayısını kullanıcıdan al
        Console.Write("Kaç adet hediye çeki kodu oluşturmak istiyorsunuz? ");
        int? numberOfGiftCodes = int.Parse(Console.ReadLine());

        // Hediye çeki kodları oluşturuluyor ve ekrana yazdırılıyor
        for (int i = 0; i < numberOfGiftCodes; i++)
        {
            string giftCode = GenerateGiftCode();
            Console.WriteLine($"Oluşturulan hediye çeki kodu: {giftCode}");
        }

        // Doğrulanacak hediye çeki kodunu kullanıcıdan al
        Console.Write("Doğrulamak istediğiniz hediye çeki kodunu girin: ");
        string? giftCodeToValidate = Console.ReadLine();

        // Hediye çeki kodu doğrulanıyor ve sonuç ekrana yazdırılıyor
        var isValidGiftCode = ValidateGiftCode(giftCodeToValidate);
        if (isValidGiftCode)
        {
            Console.WriteLine("Hediye çeki kodu geçerlidir.");
        }
        else
        {
            Console.WriteLine("Hediye çeki kodu geçersizdir.");
        }

        Console.ReadLine();
    }

    static string GenerateGiftCode()
    {
        string chars = "ACDEFGHKLMNPRTXYZ234579";
        var random = new Random();
        string giftCode = new string(
            Enumerable.Repeat(chars, 5)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());

        int checksum = 0;
        for (int i = 0; i < giftCode.Length; i++)
        {
            checksum += (int)giftCode[i]; // ASCII değerleri toplamı hesaplanıyor
        }

        // Doğrulama kodu olarak son 3 hane, ASCII değerleri toplamının son 3 hanesi kullanılıyor
        string checksumStr = checksum.ToString();
        string validationCode = checksumStr.Substring(checksumStr.Length - 3);

        return giftCode + validationCode; // Hediye çeki kodu, doğrulama kodu ile birlikte döndürülüyor
    }

    static bool ValidateGiftCode(string giftCode)
    {
        if (string.IsNullOrEmpty(giftCode) || giftCode.Length != 8)
        {
            return false;
        }

        string giftCodeWithoutValidation = giftCode.Substring(0, giftCode.Length - 3);
        int checksum = 0;
        for (int i = 0; i < giftCodeWithoutValidation.Length; i++)
        {
            checksum += (int)giftCodeWithoutValidation[i]; // ASCII değerleri toplamı hesaplanıyor
        }

        // Doğrulama kodu olarak son 3 hane, ASCII değerleri toplamının son 3 hanesi kullanılıyor
        string checksumStr = checksum.ToString();
        string validationCode = checksumStr.Substring(checksumStr.Length - 3);

        return giftCode.Substring(giftCode.Length - 3) == validationCode; // Hediye çeki kodunun doğruluğu kontrol ediliyor
    }
}