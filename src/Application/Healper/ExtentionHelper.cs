using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Application.Healper;

public static class ExtentionHelper
{
    public static CsvReader GetCsvReader(this IFormFile file)
    {
        var streamReader = new StreamReader(file.OpenReadStream());
        var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        return csv;
    }

    public static void ThrowIfNull<T>(this T @this, string errorMessage = "")
    {
        if (EqualityComparer<T>.Default.Equals(@this, default))
        {
            throw new ArgumentNullException(@this?.GetType()?.Name, errorMessage);
        }
    }

    public static async Task<T> ConvertExeption<T>(this Task<T> task, string key)
    {
        try
        {
            var result = await task;
            return result;
        }
        catch (NullReferenceException ex)
        {
            throw new NullReferenceException(key, ex);
        }
    }
}