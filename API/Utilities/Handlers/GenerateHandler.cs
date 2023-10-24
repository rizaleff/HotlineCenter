﻿namespace API.Utilities.Handlers;

public class GenerateHandler
{
    public static string GenerateNik(string lastNik)
    {
        if (lastNik == "") return "111111";
        int nik = Convert.ToInt32(lastNik);
        nik += 1;
        return nik.ToString();
    }

    public static int GenerateOtp()
    {
        Random random = new Random();
        int otp = random.Next(100000, 999999);
        return otp;
    }
}