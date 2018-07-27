namespace TicTacToe
{
    public static class PrintHelper
    {
        public static string GetDisplayText(LocationMarker marker)
        {
            var type = marker.GetType();

            var memberInfo = type.GetMember(marker.ToString());
            if (memberInfo == null || memberInfo.Length < 1)
                return marker.ToString();

            var attributes = memberInfo[0].GetCustomAttributes(typeof(PrintTextAttribute), false);
            if (attributes == null || attributes.Length < 1)
                return marker.ToString();

            return ((PrintTextAttribute)attributes[0]).Text;
        }
    }
}
