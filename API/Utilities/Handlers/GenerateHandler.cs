﻿namespace API.Utilities.Handlers;

public class GenerateHandler
{
    public static string Nik(string? lastNik = null)
    {
        if (lastNik is null)
        {
            return "111111"; // First employee
        }

        var generateNik = Convert.ToInt32(lastNik) + 1;

        return generateNik.ToString();
    }

    // public static int GenerateOtp()
    // {
    //     Random random = new Random();
    //     int otp = random.Next(100000, 999999);
    //     return otp;
    // }
}
