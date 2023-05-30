using static System.Net.WebRequestMethods;

namespace QuanLyKho
{
    public static class Constants
    {
        public static class APIEndpoint
        {
            public const string defaultXuatNhapKhoEndpoint = "api/xuatnhapkho";
        }

        public static class TempDataKeys
        {
            public const string successedDelete = "successedDelete";
            public const string createdMessage = "createdMessage";
            public const string searchTerm = "searchTerm";
        }
    }
}
