using CreateWithCodeGameJam2020.Utility;

namespace CreateWithCodeGameJam2020.Manager
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        public static bool _hasFlute = false;

        public void SetHasFlute(bool hasFlute)
        {
            _hasFlute = hasFlute;
        }

        public bool GetHasFlute()
        {
            return _hasFlute;
        }
    }
}