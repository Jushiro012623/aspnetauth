namespace AspAuth.Common.Responses;

public record ApiResponse<T>(
    bool Success,
    T? Data,
    string? Message
);