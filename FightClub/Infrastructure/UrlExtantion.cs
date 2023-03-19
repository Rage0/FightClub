﻿namespace NetworkClub.Infrastructure
{
    public static class UrlExtantion
    {
        public static string PathAndQuery(this HttpRequest request) =>
                    request.QueryString.HasValue
                    ? $"{request.Path}{request.QueryString}"
                    : request.Path.ToString();
    }
}
