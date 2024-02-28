namespace Devify.Application.Configs
{
    public class ApiRoutes
    {
        public static string category { get; set; } = "/api/category";
        public static string language { get; set; } = "/api/language";
        public static string level { get; set; } = "/api/level";
        public static string discount { get; set; } = "/api/discount";
        public static string user { get; set; } = "/api/user";
        public static string profile { get; set; } = $"{user}/profile";
        public static string course { get; set; } = "/api/course";
        public static string inventory { get; set; } = "/api/user/get-inventory";
        public static string cart { get; set; } = "/api/cart";
        public static string role { get; set; } = "/api/role";

        public static string viewInfoCourse(string code)
        {
            return $"{course}/{code}/get-view-info-course";
        }

        public static string detailCourse(string code)
        {
            return $"{course}/{code}/get-course";
        }

        public static string learning(string code)
        {
            return $"{course}/{code}/get-learning-info";
        }

        public static string creatorCourse(string code)
        {
            return $"{user}/get-creator-courses";
        }
    }
}
