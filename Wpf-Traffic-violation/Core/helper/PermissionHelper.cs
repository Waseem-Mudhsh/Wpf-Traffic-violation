using System.Windows;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.Core.helper
{
    public static class PermissionHelper
    {
        public static readonly DependencyProperty IsAllowedProperty =
            DependencyProperty.RegisterAttached("IsAllowed", typeof(string), typeof(PermissionHelper),
                                                new FrameworkPropertyMetadata(string.Empty,
                                                                            OnIsAllowedChanged));

        public static string GetIsAllowed(UIElement element)
        {
            return (string)element.GetValue(IsAllowedProperty);
        }

        public static void SetIsAllowed(UIElement element, string value)
        {
            element.SetValue(IsAllowedProperty, value);
        }

        private static void OnIsAllowedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement)d;
            string permissionName = (string)e.NewValue;

            // Check if current user has permission and set visibility accordingly
            element.Visibility = CanUserAccess(permissionName) ? Visibility.Visible : Visibility.Collapsed;
        }

        private static bool CanUserAccess(string permissionName)
        {
            // Implement logic to check user permissions against current logged-in user
            // This example assumes a static User object with permissions
            PermissionUser currentUser = GetCurrentUser();
            //return currentUser != null && currentUser.HasPermission(permissionName);
            return true;
        }

        private static PermissionUser GetCurrentUser()
        {
            return null;
            // Replace this with your logic to retrieve the currently logged-in user
            // You can store user information in a database, session, or application state
            //return new PermissionUser("JohnDoe"); // Replace with actual user retrieval logic
        }
    }
}
